<template>
  <div class="space background-listing">
    <h1>Edit</h1>
    <form class="form-listing" @submit.prevent="editListing" method="PUT">
      <div class="form-div">
        <label for="title">Title</label>
        <input id="title" type="text" v-model="oneListing.title" />
      </div>
      <div class="form-div">
        <label for="deadline"
          >Deadline <br />
          {{ formatDateTwo(oneListing.deadline) }}</label
        >

        <input
          id="deadline"
          type="date"
          :min="new Date().toISOString().substr(0, 10)"
          v-model="oneListing.deadline"
        />
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
import dayjs from "dayjs";
export default {
  name: "EditListing",
  data() {
    return {
      updListing: {
        id: this.$route.params.id,
        title: null,
        deadline: null,
        description: null,
        userOwner: null,
        image: null,
        creationDate: null,
      },
    };
  },

  created() {
    console.log(this.$route.params.id);
    this.getListingById(this.$route.params.id);
  },
  methods: {
    ...mapActions([
      "updateListing",
      "getListingById",
      "deleteImage",
      "addImage",
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

      const updata = await this.updateListing(this.updListing);
      console.log(updata);
      this.$router.push({ name: "ListingDetails" });
    },
    formatDateTwo(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("D/MM/YY");
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