<template>
  <div class="background-listing space">
    <h1 class="title-page">
      All listings from
      <p class="cap-user">{{ username }}</p>
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
      class="listing-div nav-change"
      v-for="(listing, index) in userListing"
      :key="listing + index"
    >
      <div class="listing-img">
        <img
          v-if="listing.image != null"
          :src="`https://localhost:5001/api/image/${listing.image}`"
          alt=""
        />
      </div>
      <div class="listing-info">
        <h3>{{ listing.title }}</h3>

        <p>Posted : {{ formatDate(listing.creationDate) }}</p>
        <p>Pick-up before : {{ formatDate(listing.deadline) }}</p>
        <p>{{ listing.foodType }}</p>
        <div>
          <p>allergies:</p>
          <p
            v-for="(allergie, index) in setOfAllergies"
            :key="allergie + index"
          >
            {{ allergie.name }}
          </p>
        </div>
        <p class="cap-user">Posted by : {{ listing.userOwner }}</p>
        <div class="buttons-div">
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
            @click="remove(listing.listingId, listing.image)"
          >
            Delete
          </button>
          <order-listing :listing="listing" @update="orderupdate()" />
          <button>
            <router-link :to="`/listing`"> Back to Listing </router-link>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddListings from "../../components/AddListings.vue";
import dayjs from "dayjs";

export default {
  name: "ListingByUser",
  components: { AddListings },
  data() {
    return {
      plusButton: false,
      username: this.$route.params.id,
    };
  },
  created() {
    this.getListingsByUser(this.$route.params.id);
  },

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
    formatDate(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("dddd D of MMMM, YYYY");
    },
    orderupdate() {
      console.log("test");
      window.location.reload();
    },
  },
  computed: mapGetters(["oneListing", "allListings", "userListing"]),
};
</script>

<style>
</style>