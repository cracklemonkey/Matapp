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
        <label for="expiration">Expiration Date</label>
        <input id="expiration" type="date" v-model="posts.expirationDate" />
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

      <!--       <label for="image">Upload a picture</label>
      <input id="image" type="file" accept="image/png, image/jpeg" v-model="posts.image" /> -->

      <button type="submit">Add</button>
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
        deadline: "0001-01-01",
        expirationDate: "0001-01-01",

        description: null,
      },
    };
  },
  methods: {
    ...mapActions(["addListing"]),

    postListing() {
      console.log(this.posts);
      this.addListing(this.posts);
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
</style>