<template>
  <div class="listing-div">
    <h1>{{ oneListing.title }}</h1>
    <p>
      Description: <br />
      {{ oneListing.description }}
    </p>
    <p>{{ oneListing.foodType }}</p>
    <p>Pick-up before: {{ formatDate(oneListing.deadline) }}</p>
    <p>{{ oneListing.allergies }}</p>
    <p>from {{ oneListing.userOwner }}</p>
    <p>Posted on: {{ formatDate(oneListing.creationDate) }}</p>
    <button>
      <router-link
        v-if="
          $auth.authenticated &&
          $auth.user.preferred_username === oneListing.userOwner
        "
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
import dayjs from "dayjs";
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
    formatDate(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("dddd D of MMMM, YYYY");
    },
  },
  computed: mapGetters(["oneListing", "allUsers"]),
};
</script>

<style>
</style>