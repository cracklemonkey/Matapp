<template>
  <div>
    <h1>
      All listings from <br />
      {{ this.$route.params.id }}
    </h1>
    <div>
      <button @click="togglePlus" class="plus-button">
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

      <p>Posted : {{ listing.creationDate }}</p>
      <p>Pick-up before : {{ listing.deadline }}</p>
      <p>Expires : {{ listing.expirationDate }}</p>
      <p>{{ listing.foodType }}</p>
      <p>Posted by : {{ listing.userOwner }}</p>
      <button>
        <router-link :to="`/listing/${listing.id}`">
          View more details
        </router-link>
      </button>
      <button @click="deleteListing(listing.id)">Delete</button>
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

export default {
  name: "ListingByUser",
  components: { AddListings },
  data() {
    return {
      plusButton: false,

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
    ]),
    togglePlus() {
      this.plusButton = !this.plusButton;
    },
  },
  computed: mapGetters(["oneListing", "allListings", "userListing"]),
};
</script>

<style>
</style>