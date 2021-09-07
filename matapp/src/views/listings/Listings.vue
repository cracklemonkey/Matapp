<template>
  <div>
    <h1 class="title-page">All Listings</h1>

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
      v-for="(listing, index) in allListings"
      :key="listing + index"
    >
      <h3>{{ listing.title }}</h3>
      <img :src="`https://localhost:5001/api/image/${listing.image}`" alt="" />

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
      <button
        v-if="
          $auth.authenticated &&
          $auth.user.preferred_username != listing.userOwner
        "
      >
        Order
      </button>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddListings from "../../components/AddListings.vue";
import dayjs from "dayjs";
export default {
  name: "Listings",
  components: { AddListings },
  data() {
    return {
      plusButton: false,
    };
  },
  created() {
    this.getListings();
  },
  methods: {
    ...mapActions([
      "getListings",
      "addListing",
      "deleteListing",
      "updateListing",
      "getListingById",
      "getImage",
    ]),
    togglePlus() {
      if (this.$auth.authenticated) {
        this.plusButton = !this.plusButton;
      }
    },
    formatDate(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("dddd D of MMMM, YYYY");
    },
  },
  computed: mapGetters(["allListings", "oneImage"]),
};
</script>

<style>
.title-page {
  font-family: "Oswald", sans-serif;
  padding: 10px;
  margin-bottom: 20px;
}
.listing-div {
  font-family: "Raleway", sans-serif;
  font-weight: 500;
  width: 50%;
  margin: 10px auto;
  border: 3px solid black;
  padding: 10px;
  border-radius: 20px;
}

.listing-div p {
  padding: 5px;
  font-size: 18px;
}

.listing-div button {
  font-family: inherit;
  font-size: 15px;
  padding: 5px;
  margin: 10px;
  border-radius: 30px;
  border: black 1px solid;
}
.listing-div button a {
  text-decoration: none;
  color: black;
}

.listing-div button:hover {
  font-size: 18px;
}
.listing-div a:hover {
  color: #42b983;
}

.plus-button {
  background: none;
  border: none;
  font-size: 30px;
}
.plus-button:hover {
  color: #42b983;
}
</style>