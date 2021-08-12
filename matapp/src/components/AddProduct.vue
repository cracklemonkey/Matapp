<template>
  <div>
    <p>Add a new listing</p>
    <form class="form-annonser" @submit.prevent="postAnnonser" method="post">
      <div>
        <label for="title">Title</label>
        <input id="title" type="text" v-model="posts.title" />
      </div>
      <div>
        <label for="deadline">Deadline</label>
        <input id="deadline" type="date" v-model="posts.deadlineDate" />
      </div>
      <div>
        <label for="expiration">Expiration Date</label>
        <input id="expiration" type="date" v-model="posts.expirationDate" />
      </div>
      <div>
        <label for="typefood">Type of food</label>
        <select id="typefood" v-model="posts.foodType">
          <option value="vegetables">Vegetables</option>
          <option value="fruits">Fruits</option>
          <option value="dairy">Dairy</option>
        </select>
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
  data() {
    return {
      posts: {
        annonserid: this.annonserid,
        title: null,
        deadLineDate: null,
        expirationDate: null,
        foodType: [],
        description: null,

        /* image: , */
      },
    };
  },
  methods: {
    ...mapActions(["addAnnonser"]),
    postAnnonser(e) {
      this.addAnnonser(this.posts);
      console.log(e);
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
.form-annonser {
}
</style>