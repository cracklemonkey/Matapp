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

      <!-- <div>
        <label for="foodType">Type of Food</label>
        <select id="foodType"
          v-model="value">
          <option value="vegetables">vegetables</option>
          <option value="dairy"> dairy</option>
          <option value="fruits">fruits </option>
          <option value="fish"> fish</option>
          
         
        </select>
      </div> -->
      <div>
        <label for="description">Description</label>
        <textarea
          id="description"
          rows="5"
          cols="20"
          v-model="posts.description"
        />
      </div>

      <!--       <label for="image">Upload a picture</label>
      <input id="image" type="file" accept="image/png, image/jpeg" v-model="posts.image" /> -->

      <button class="add-btn" type="submit">Add</button>
    </form>
  </div>
</template>

<script>
import { mapActions } from "vuex";
export default {
  name: "AddListings",
  data() {
    return {
      posts: {
        title: null,
        deadline: Date.now(),

        /*         foodType: [],
         */ description: null,
        userOwner: null,

        creationDate: new Date(),
      },
      /* value: null, */
    };
  },
  methods: {
    ...mapActions(["addListing"]),

    postListing() {
      if (this.$auth.authenticated) {
        console.log(this.posts);
        this.posts.userOwner = this.$auth.user.preferred_username;

        this.addListing(this.posts);
        event.target.reset();
      }
    },
  },
};
</script>

<style>
/* .form-annonser input,
.form-annonser select,
.form-annonser label,
.form-annonser textarea {
  display: flex;
}
 */
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
</style>