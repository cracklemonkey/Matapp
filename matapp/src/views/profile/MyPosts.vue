<template>
  <div class="space background-listing">
    <div class="my-listings-page">
      <h1 class="title-page">All My Listings</h1>
      <div>
        <router-link class="router-link" :to="`/listing`"
          ><p>Back to Listing</p></router-link
        >
        <router-link class="router-link" :to="`/profile`"
          ><p>Back to Profile</p></router-link
        >
      </div>
      <div
        class="listing-div"
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
          <p>Posted by : {{ listing.userOwner }}</p>
          <button>
            <router-link :to="`/listing/${listing.listingId}`">
              View details
            </router-link>
          </button>
          <button>
            <router-link :to="`/listing/${listing.listingId}/edit`">
              Edit
            </router-link>
          </button>
          <button @click="deleteListing(listing.listingId)">Delete</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";

import dayjs from "dayjs";
export default {
  data() {
    return {};
  },
  created() {
    this.getListingsByUser(this.$auth.user.preferred_username);
  },

  methods: {
    ...mapActions([
      "getListings",
      "getListingById",
      "addListing",
      "deleteListing",
      "updateListing",
      "getListingsByUser",
    ]),
    formatDate(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("D/MM/YY");
    },
  },
  computed: mapGetters(["allListings", "userListing"]),
};
</script>

<style scoped>
.my-listings-page {
  width: 80%;
  margin: 1% auto;
}

.oneListing {
  display: flex;
  flex-direction: column;
}

.listing-card {
  width: 70%;
  margin: 30px auto;
  text-align: center;
}
.listing-card img {
  width: 100%;
  max-height: 300px;
}

.listing-card-text {
  display: flex;
  justify-content: space-between;
  color: black;
}

.listing-card-text a {
  text-decoration: none;
  color: black;
}
.oneListing button {
  height: 30px;
  align-self: center;
  width: 5%;
  margin: 15px;
  border-radius: 50px;
}

.oneListing button a {
  text-decoration: none;
  color: black;
  font-weight: bold;
}

.btn-settings {
  font-size: 25px;
  border: none;
  position: relative;
  bottom: 20px;
}
.btn-settings a {
  text-decoration: none;
  color: black;
}
</style>