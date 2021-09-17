<template>
  <div class="space">
    <h1>Edit</h1>
    <form class="form-listing" @submit.prevent="editListing" method="PUT">
      <div>
        <label for="title">Title</label>
        <input id="title" type="text" v-model="oneListing.title" />
      </div>
      <div>
        <label for="deadline">Deadline</label>
        <input id="deadline" type="date" v-model="oneListing.deadline" />
      </div>

      <div>
        <label for="description">Description</label>
        <textarea
          id="description"
          rows="5"
          cols="20"
          v-model="oneListing.description"
        />
      </div>
      <div>
        <img :src="oneListing.image" alt="" />
        <p>{{ oneListing.image }}</p>
      </div>
      <div>
        <input
          type="file"
          accept="image/jpg, image/png, image/jpeg"
          ref="file"
          @change="onImageSelected"
        />
      </div>

      <button type="submit">Update</button>
    </form>
    <router-link :to="`/listing/${oneListing.listingId}`">
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
        const updateImage = await this.addImage(fd);
        this.updListing.image = updateImage;
        const updata = await this.updateListing(this.updListing);
        console.log(updata);
        this.$router.push({ name: "ListingDetails" });
      } else {
        this.updListing.image = this.oneListing.image;
        const updata = await this.updateListing(this.updListing);
        console.log(updata);
        this.$router.push({ name: "ListingDetails" });
      }
    },
  },
  computed: mapGetters(["oneListing"]),
};
</script>

<style>
</style>