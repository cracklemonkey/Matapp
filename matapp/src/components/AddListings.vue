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
    };
  },
  computed: mapGetters(["oneImage"]),
  methods: {
    ...mapActions(["addListing", "addImage"]),
    onImageSelected(e) {
      this.posts.image = e.target.files[0];
    },
    postListing(event) {
      if (this.$auth.authenticated) {
        console.log(this.posts);

        if (this.posts.image != null) {
          this.posts.userOwner = this.$auth.user.preferred_username;
          const fd = new FormData();
          fd.append("file", this.posts.image);
          this.addImage(fd);
          this.posts.image = this.posts.image.name;
          this.addListing(this.posts);
        } else {
          this.posts.userOwner = this.$auth.user.preferred_username;
          this.addListing(this.posts);
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
</style>