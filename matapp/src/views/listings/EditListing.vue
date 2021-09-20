<template>
  <div class="space background-listing">
    <h1>Edit</h1>
    <form class="form-listing" @submit.prevent="editListing" method="PUT">
      <div class="form-div">
        <label for="title">Title</label>
        <input id="title" type="text" v-model="oneListing.title" />
      </div>
      <div class="form-div">
        <label for="deadline">Deadline</label>
        <input id="deadline" type="date" v-model="oneListing.deadline" />
      </div>

      <div class="form-div">
        <label for="description">Description</label>
        <textarea
          id="description"
          rows="5"
          cols="20"
          v-model="oneListing.description"
        />
      </div>

      <div>
        <p class="title-label">What kind of food is it?</p>
        <div
          v-for="(foodType, index) in setOfFoodTypes"
          :key="foodType + index"
        >
          <p class="info-name">
            {{ foodType.name }}
          </p>
          <p class="hidden">{{ foodType.listingFoodTypeId }}</p>
        </div>
        <div class="checked-boxes">
          <div
            class="check-inputs"
            v-for="(foodType, i) in allFoodTypes"
            :key="foodType + i"
          >
            <label for="foodtype">{{ foodType.name }}</label>
            <input
              id="foodtype"
              type="checkbox"
              :value="foodType.foodTypeId"
              v-model="checked"
            />
          </div>
        </div>
      </div>
      <div>
        <p class="title-label">Which allergies does it contain?</p>
        <div
          v-for="(allergie, index) in setOfAllergies"
          :key="allergie + index"
        >
          <p class="info-name">
            {{ allergie.name }} {{ allergie.listingAllergieId }}
          </p>
        </div>
        <div class="checked-boxes">
          <div
            class="check-inputs"
            v-for="(allergies, i) in allAllergies"
            :key="allergies + i"
          >
            <label for="allergie">{{ allergies.name }}</label>
            <input
              id="allergie"
              type="checkbox"
              :value="allergies.allergieId"
              v-model="checkedAllergies"
            />
          </div>
        </div>
      </div>
      <div class="form-div">
        <input
          type="file"
          accept="image/jpg, image/png, image/jpeg"
          ref="file"
          @change="onImageSelected"
        />
      </div>
      <button class="form-btn" type="submit">Update</button>
    </form>
    <router-link class="router-link" :to="`/listing/${oneListing.listingId}`">
      back to details
    </router-link>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
export default {
  name: "EditListing",
  data() {
    return {
      updListing: {
        id: this.$route.params.id,
        title: null,
        deadline: Date.parse(""),
        description: null,
        userOwner: null,
        image: null,
        creationDate: null,
      },
      updateType: {
        foodTypeId: null,
        listingId: this.$route.params.id,
      },
      updateAllergies: {
        allergieId: null,
        listingId: this.$route.params.id,
      },
      checked: [],
      checkedAllergies: [],
    };
  },
  created() {
    console.log(this.$route.params.id);
    this.getListingById(this.$route.params.id);
    this.getFTByListingId(this.$route.params.id);
    this.getAllergiesByListingId(this.$route.params.id);
    this.getFoodTypes();
    this.getAllergies();
  },
  methods: {
    ...mapActions([
      "updateListing",
      "getListingById",
      "deleteImage",
      "addImage",
      "updateFoodType",
      "updateAllergie",
      "getFoodTypes",
      "getAllergies",
      "getListingFT",
      "getListingAllergies",
      "getFTByListingId",
      "getAllergiesByListingId",
      "deleteAllergie",
      "deleteFoodType",
    ]),

    onImageSelected(e) {
      this.updListing.image = e.target.files[0];
      console.log(this.updListing.image);
    },

    async editListing() {
      console.log(this.oneListing);
      this.updListing.title = this.oneListing.title;
      this.updListing.description = this.oneListing.description;
      this.updListing.deadline = this.oneListing.deadline;
      this.updListing.userOwner = this.$auth.user.preferred_username;
      this.updListing.creationDate = this.oneListing.creationDate;
      console.log(this.oneListing.image);
      if (this.updListing.image != null) {
        const dataimage = await this.deleteImage(this.oneListing.image);
        console.log(dataimage);

        const fd = new FormData();
        fd.append("file", this.updListing.image);
        this.updListing.image = await this.addImage(fd);
      } else {
        this.updListing.image = this.oneListing.image;
      }
      if (this.checked != null) {
        console.log(this.foodType);
        await this.deleteFoodType(this.foodType.foodType);
        for (let i = 0; i < this.checked.length; i++) {
          this.updateType.foodTypeId = this.checked[i];
          await this.updateFoodType(this.updateType);
          console.log(this.updateType);
        }
      }
      if (this.checkedAllergies != null) {
        await this.deleteAllergie(this.allergie.listingAllergieId);
        for (let i = 0; i < this.checkedAllergies.length; i++) {
          this.updateAllergies.allergieId = this.checkedAllergies[i];
          await this.updateAllergie(this.updateAllergies);
          console.log(this.updateAllergies);
        }
      }

      const updata = await this.updateListing(this.updListing);
      console.log(updata);
      this.$router.push({ name: "ListingDetails" });
    },
  },
  computed: mapGetters([
    "oneListing",
    "oneFoodType",
    "oneAllergie",
    "allAllergies",
    "allFoodTypes",
    "setOfAllergies",
    "setOfFoodTypes",
  ]),
};
</script>

<style>
.info-name {
  text-transform: capitalize;
}
.router-link {
  color: white;
  font-weight: bold;
}
</style>