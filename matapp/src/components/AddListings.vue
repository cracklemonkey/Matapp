<template>
  <div>
    <p class="add-title">Add a new listing</p>
    <form class="form-listing" @submit.prevent="postListing" method="POST">
      <div>
        <label for="title">Title</label>
        <input
          id="title"
          type="text"
          v-model="posts.title"
          placeholder="name your listing"
        />
      </div>
      <div>
        <label for="deadline">Deadline</label>
        <input id="deadline" type="date" v-model="posts.deadline" />
      </div>

      <div>
        <label for="description">Description</label>
        <textarea
          id="description"
          rows="5"
          cols="20"
          v-model="posts.description"
        />
      </div>
      <div class="foodtype-boxes">
        <p>What kind of food is it?</p>
        <div
          class="foodtypes"
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
      <div class="allergies-boxes">
        <p>Which allergies does it contain?</p>
        <div
          class="allergies"
          v-for="(allergie, i) in allAllergies"
          :key="allergie + i"
        >
          <label for="allergie">{{ allergie.name }}</label>
          <input
            id="allergie"
            type="checkbox"
            :value="allergie.allergieId"
            v-model="checkedAllergies"
          />
        </div>
      </div>
      <div>
        <input
          type="file"
          accept="image/jpg, image/png, image/jpeg"
          ref="file"
          @change="onImageSelected"
        />
      </div>

      <button class="add-btn" type="submit">Add</button>
    </form>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
export default {
  name: "AddListings",
  created() {
    this.getFoodTypes();
    this.getAllergies();
  },
  data() {
    return {
      posts: {
        title: null,
        deadline: Date.now(),
        description: null,
        image: null,
        userOwner: null,
        creationDate: new Date(),
      },
      postType: {
        foodTypeId: null,
        listingId: null,
      },
      postAllergies: {
        allergieId: null,
        listingId: null,
      },
      checked: [],
      checkedAllergies: [],
    };
  },
  computed: mapGetters(["oneImage", "allFoodTypes", "allAllergies"]),
  methods: {
    ...mapActions([
      "addListing",
      "addImage",
      "getFoodTypes",
      "addFoodType",
      "getAllergies",
      "addAllergies",
    ]),
    onImageSelected(e) {
      this.posts.image = e.target.files[0];
    },
    async postListing(event) {
      if (this.$auth.authenticated) {
        console.log(this.posts);

        if (this.posts.image != null) {
          this.posts.userOwner = this.$auth.user.preferred_username;
          const fd = new FormData();
          fd.append("file", this.posts.image);

          this.posts.image = await this.addImage(fd);

          const data = await this.addListing(this.posts);
          console.log("here is the data", data);
          this.postType.listingId = data.listingId;
          console.log(this.postType.listingId);
          for (let i = 0; i < this.checked.length; i++) {
            this.postType.foodTypeId = this.checked[i];
            await this.addFoodType(this.postType);
            console.log(this.postType);
          }
          this.postAllergies.listingId = data.listingId;
          for (let i = 0; i < this.checkedAllergies.length; i++) {
            this.postAllergies.allergieId = this.checkedAllergies[i];
            await this.addAllergies(this.postAllergies);
            console.log(this.postAllergies);
          }
        } else {
          this.posts.userOwner = this.$auth.user.preferred_username;
          const data = await this.addListing(this.posts);
          console.log("here is the data", data);
          this.postType.listingId = data.listingId;
          console.log(this.postType.listingId);
          for (let i = 0; i < this.checked.length; i++) {
            this.postType.foodTypeId = this.checked[i];
            await this.addFoodType(this.postType);
            console.log(this.postType);
          }
          this.postAllergies.listingId = data.listingId;
          for (let i = 0; i < this.checkedAllergies.length; i++) {
            this.postAllergies.allergieId = this.checkedAllergies[i];
            await this.addAllergies(this.postAllergies);
            console.log(this.postAllergies);
          }
        }
        event.target.reset();
      }
    },
  },
};
</script>

<style>
.add-title {
  font-size: 20px;
  font-family: "Oswald", sans-serif;
}
.form-listing {
  font-size: 18px;
  width: 30%;
  margin: auto;
}
.form-listing div {
  display: flex;
  flex-direction: column;
}
.add-btn {
  font-family: inherit;
  font-size: 15px;
  padding: 5px;
  margin: 10px;
  border-radius: 30px;
  border: black 1px solid;
}
.add-btn:hover {
  font-size: 18px;
  color: #42b983;
}
.foodtype-boxes div {
}
.foodtypes {
  text-align: start;
  flex-direction: row;
  align-items: center;
  flex-wrap: wrap;
}

.foodtype {
}
</style>