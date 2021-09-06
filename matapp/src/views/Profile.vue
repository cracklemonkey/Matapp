<template>
  <div>
    <ProfileBanner />
    <div>
      <button class="btn-settings">
        <router-link :to="`/profile/settings`">
          <i class="fas fa-user-cog"></i>
        </router-link>
      </button>
    </div>
    <div class="my-listings">
      <h2>My Listings</h2>
      <div class="oneListing">
        <div
          class="listing-card"
          v-for="(listing, index) in userListing"
          :key="listing + index"
        >
          <router-link :to="`/listing/${listing.listingId}`">
            <h3>{{ listing.title }}</h3>
          </router-link>

          <p>Posted : {{ formatDate(listing.creationDate) }}</p>
          <p>Pick-up before : {{ formatDate(listing.deadline) }}</p>
          <p>Posted by : {{ listing.userOwner }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";

import ProfileBanner from "../components/layout/ProfileBanner.vue";
import dayjs from "dayjs";
export default {
  components: { ProfileBanner },
  data() {
    return {
      /* listings: [], */
    };
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

<style>
.my-listings {
  width: 80%;
  margin: 1% auto;
}

.my-listings h2 {
  text-align: start;
  font-size: 2em;
  padding-left: 20px;
  color: black;
}
.oneListing {
  display: flex;
  flex-direction: row;
}

.listing-card {
  width: 20%;
  margin: 10px;
  text-align: left;
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