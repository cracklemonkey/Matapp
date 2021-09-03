<template>
  <div class="listing-div">
    <h1>{{ oneListing.title }}</h1>
    <p>
      Description: <br />
      {{ oneListing.description }}
    </p>
    <p>{{ oneListing.foodType }}</p>
    <p>Pick-up before: {{ oneListing.deadline }}</p>
    <p>{{ oneListing.allergies }}</p>
    <p>from {{ oneListing.userOwner }}</p>
    <button>
      <router-link
        v-if="$auth.user.preferred_username === oneListing.userOwner"
        :to="`/listing/${oneListing.listingId}/edit`"
      >
        Edit
      </router-link>
    </button>
    <button>
      <router-link :to="`/listing`"> Back to Listing </router-link>
    </button>
    <button>
      <router-link :to="`/listing/user/${oneListing.userOwner}`">
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