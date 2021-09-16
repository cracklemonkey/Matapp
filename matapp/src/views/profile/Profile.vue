<template>
  <div class="">
    <ProfileBanner />
    <div>
      <button class="btn-settings">
        <router-link :to="`/profile/settings`">
          <i class="fas fa-user-cog"></i>
        </router-link>
      </button>
    </div>
    <div class="my-listings">
      <div class="title-section">
        <router-link :to="`/profile/myposts`"
          ><h2>My Listings</h2>
        </router-link>
      </div>

      <div class="oneListing">
        <div
          class="listing-card"
          v-for="(listing, index) in userListing.slice(0, 4)"
          :key="listing + index"
        >
          <router-link :to="`/listing/${listing.listingId}`">
            <h3>{{ listing.title }}</h3>
          </router-link>

          <p>Posted : {{ formatDate(listing.creationDate) }}</p>
          <p>Pick-up before : {{ formatDate(listing.deadline) }}</p>
          <p>Posted by : {{ listing.userOwner }}</p>
        </div>

        <button class="" v-if="userListing.length > 4">
          <router-link :to="`/profile/myposts`"> View more </router-link>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";

import ProfileBanner from "../../components/layout/ProfileBanner.vue";
import dayjs from "dayjs";
export default {
  components: { ProfileBanner },
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

.title-section a {
  text-decoration: none;
}

.title-section h2:hover {
  color: #42b983;
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
  height: 40px;
  align-self: center;
  width: 10%;
  margin: 15px;
  border-radius: 50px;
}

.oneListing button a {
  text-decoration: none;
  color: black;
  font-weight: bold;
}

.oneListing button a:hover {
  color: #42b983;
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