<template>
  <div>
    <h1>Edit</h1>
    <form class="form-listing" @submit.prevent="editListing" method="PUT">
      <div>
        <label for="title">Title</label>
        <input id="title" type="text" v-model="updListing.title" />
      </div>
        <div>
        <label for="deadline">Deadline</label>
        <input id="deadline" type="date" v-model="updListing.deadline" />
      </div>
      <div>
        <label for="expiration">Expiration Date</label>
        <input
          id="expiration"
          type="date"
          v-model="updListing.expirationDate"
        />
      </div> 
      
 <div>
        <label for="foodType">Food Type</label>
        <input id="foodType" type="text" v-model="updListing.foodType" />
      </div>
      <div>
        <label for="description">Description</label>
        <textarea
          id="description"
          rows="5"
          cols="20"
          v-model="updListing.description"
        />
      </div>

      <button type="submit">Update</button>
    </form>
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
        expirationDate: Date.parse(""),
        foodType: null,
        description: null,
      },
    };
  },
  created() {
    console.log(this.$route.params.id);
    this.getListingById(this.$route.params.id);
  },
  methods: {
    ...mapActions(["updateListing", "getListingById"]),

    editListing() {
      console.log(this.updListing);
      this.updateListing(this.updListing);
    },
  },
  computed: mapGetters(["oneListing"]),
};
</script>

<style>
</style>