<template>
  <div>
    <form class="form-listing" @submit.prevent="postListing" method="POST">
      <div class="form-div">
        <label for="title">Title</label>
        <input
          id="title"
          type="text"
          v-model="posts.title"
          placeholder="name your listing"
          required
        />
      </div>
      <div class="form-div">
        <label for="deadline">Deadline</label>
        <input
          id="deadline"
          type="date"
          :min="new Date().toISOString().substr(0, 10)"
          v-model="posts.deadline"
          required
        />
      </div>

      <div class="form-div">
        <label for="description">Description</label>
        <textarea
          id="description"
          rows="3"
          cols="10"
          v-model="posts.description"
          placeholder="describe your listing"
          required
        />
      </div>
      <div>
        <p class="title-label">What kind of food is it?</p>
        <div class="checked-boxes">
          <div
            class="check-inputs"
            v-for="(foodType, i) in allFoodTypes"
            :key="foodType + i"
            required
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
        <div class="checked-boxes">
          <div
            class="check-inputs"
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
      </div>
      <div class="form-div">
        <label for="image">Upload an image</label>
        <input
          id="image"
          type="file"
          accept="image/jpg, image/png, image/jpeg"
          ref="file"
          capture="camera"
          class="custom-file-input"
          @change="onImageSelected"
        />
      </div>

      <button class="form-btn" type="submit">Add</button>
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
        this.$emit("toggle");
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
  width: 40%;
  margin: auto;
}
.form-listing .form-div {
  display: flex;
  flex-direction: column;
  padding: 5px;
}

.form-listing .form-div label {
  font-weight: bold;
  color: white;
}

.form-listing .form-div input {
  border-radius: 10px;
  padding: 5px;
  font-family: inherit;
  font-weight: bold;
}
.form-listing .form-div textarea {
  border-radius: 20px;
  padding: 10px;
  font-family: inherit;
  font-weight: bold;
}

.custom-file-input::-webkit-file-upload-button {
  visibility: hidden;
}
.custom-file-input::before {
  content: "Select an image";
  display: inline-block;
  background: white;
  border: 1px solid #999;
  border-radius: 10px;
  padding: 5px 8px;
  outline: none;
  white-space: nowrap;
  -webkit-user-select: none;
  cursor: pointer;
  color: black;
  font-weight: 700;
  font-size: 10pt;
}
.custom-file-input:hover::before {
  border-color: black;
}
.custom-file-input:active::before {
  background: -webkit-linear-gradient(top, #e3e3e3, #f9f9f9);
}

.title-label {
  font-weight: bold;
  padding: 5px;
  color: white;
}

.checked-boxes {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}
.check-inputs {
  align-items: center;
  padding: 5px;
  flex-direction: row;
}
.check-inputs label {
  text-transform: capitalize;
  padding-right: 5px;
  color: black;
  font-weight: bold;
}
.check-inputs input {
  accent-color: black;
}
.form-btn {
  font-family: inherit;
  font-size: 15px;
  padding: 5px 10px;
  margin: 10px;
  border-radius: 30px;
  border: black 1px solid;
  font-weight: bold;
}
.form-btn:hover {
  font-size: 20px;
  background-color: rgba(231, 224, 224, 0.7);
}

@media (max-width: 768px) {
  .form-listing {
    font-size: 18px;
    width: 80%;
    margin: auto;
  }
}
</style>