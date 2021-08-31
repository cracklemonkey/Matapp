<template>
  <div class="listing-div">
    <h1>listing details</h1>
    <p>{{ oneListing.title }}</p>
    <p>
      {{ oneListing.description }}
    </p>
    <p>{{ oneListing.foodType }}</p>
    <p>Pick-up before: {{ oneListing.deadline }}</p>
    <p>{{ oneListing.allergies }}</p>
    <p>from {{ oneListing.userId }}</p>
    <button>
      <router-link :to="`/listing/${oneListing.listingId}/edit`">
        Edit
      </router-link>
    </button>
    <button>
      <router-link :to="`/listing`"> Back to Listing </router-link>
    </button>
    <button>
      <router-link :to="`/listing/user/${oneListing.userId}`">
        see all ads from user
      </router-link>
    </button>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
export default {
  created() {
    console.log(this.$route.params.id);
    this.getListingById(this.$route.params.id);
  },
  methods: {
    ...mapActions([
      "getListings",
      "addListing",
      "deleteListing",
      "getListingById",
    ]),
  },
  computed: mapGetters(["oneListing", "allUsers"]),
};
</script>

<style>
</style>