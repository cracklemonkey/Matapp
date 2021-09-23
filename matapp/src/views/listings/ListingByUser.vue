<template>
  <div class="background-listing space">
    <h1 class="title-page">
      <p class="cap-user">{{ username }}'s</p>
      <p>listings</p>
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

        <p class="desktop">Posted : {{ formatDate(listing.creationDate) }}</p>
        <p class="desktop">
          Pick-up before : {{ formatDate(listing.deadline) }}
        </p>
        <p class="phone">Posted : {{ formatDateTwo(listing.creationDate) }}</p>
        <p class="phone">
          Pick-up before : {{ formatDateTwo(listing.deadline) }}
        </p>

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
          <order-listing :listing="listing" />
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
import OrderListing from "../../components/OrderListing.vue";

export default {
  name: "ListingByUser",
  components: { AddListings, OrderListing },
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
    formatDateTwo(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("D/MM/YY");
    },
  },
  computed: mapGetters(["oneListing", "allListings", "userListing"]),
};
</script>

<style>
</style>