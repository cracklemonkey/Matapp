<template>
  <div>
    <h1>
      All listings from user: <br />
      {{ routeId }}
    </h1>
    <div>
      <button
        v-if="$auth.authenticated"
        @click="togglePlus"
        class="plus-button"
      >
        <i class="far fa-plus-square"></i>
      </button>
    </div>
    <div v-if="plusButton">
      <AddListings />
    </div>

    <div
      class="listing-div"
      v-for="(listing, index) in userListing"
      :key="listing + index"
    >
      <h3>{{ listing.title }}</h3>

      <p>Posted : {{ formatDate(listing.creationDate) }}</p>
      <p>Pick-up before : {{ formatDate(listing.deadline) }}</p>
      <p>{{ listing.foodType }}</p>
      <p>Posted by : {{ listing.userOwner }}</p>
      <button>
        <router-link :to="`/listing/${listing.listingId}`">
          View more details
        </router-link>
      </button>
      <button
        v-if="
          $auth.authenticated &&
          $auth.user.preferred_username === listing.userOwner
        "
        @click="deleteListing(listing.listingId)"
      >
        Delete
      </button>
      <button>
        <router-link :to="`/listing`"> Back to Listing </router-link>
      </button>
    </div>
  </div>
  <!-- </div> -->
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddListings from "../components/AddListings.vue";
import dayjs from "dayjs";

export default {
  name: "ListingByUser",
  components: { AddListings },
  data() {
    return {
      plusButton: false,
      routeId: this.$route.params.id,

      /*       listingByUser: this.$route.params.userOwner,
       */
    };
  },
  created() {
    this.getListingsByUser(this.$route.params.id);
  },
  /* created() {
    this.getListings();
  }, */
  methods: {
    ...mapActions([
      "getListings",
      "addListing",
      "deleteListing",
      "getListingById",
      "getListingsByUser",
      "getUserById",
      "getUsers",
    ]),
    togglePlus() {
      this.plusButton = !this.plusButton;
    },
    formatDate(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("dddd D of MMMM, YYYY");
    },
  },
  computed: mapGetters([
    "oneListing",
    "allListings",
    "userListing",
    "allUsers",
    "oneUser",
  ]),
};
</script>

<style>
</style>