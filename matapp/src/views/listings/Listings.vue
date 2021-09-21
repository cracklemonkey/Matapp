<template>
  <div class="background-listing space">
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
      class="listing-div nav-change"
      v-for="(listing, index) in allListings"
      :key="listing + index"
    >
      <div>
        <img
          v-if="listing.image != null"
          class="listing-img"
          :src="`https://localhost:5001/api/image/${listing.image}`"
          alt=""
        />
        <h3>{{ listing.title }}</h3>

        <p>Posted : {{ formatDate(listing.creationDate) }}</p>
        <p>Pick-up before : {{ formatDate(listing.deadline) }}</p>
        <p>{{ listing.foodType }}</p>
        <div
          v-for="(allergie, index) in setOfAllergies"
          :key="allergie + index"
        >
          <p>allergies:{{ allergie.name }}</p>
        </div>
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
          @click="remove(listing.listingId, listing.image)"
        >
          Delete
        </button>
        <order-listing :listing="listing" @update="orderupdate()" />
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
  name: "Listings",
  components: { AddListings, OrderListing },
  data() {
    return {
      plusButton: false,

      orderkey: 0,
      postOrder: {
        userName: null,
        orderDate: new Date(),
        listingId: null,
      },
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
      "deleteImage",
      "getAllergiesByListingId",
      "getFTByListingId",
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

    orderupdate() {
      console.log("test");
      window.location.reload();
    },
    remove(listingId, imageName) {
      this.deleteListing(listingId),
        this.deleteImage(imageName),
        window.location.reload();
    },
  },
  computed: mapGetters([
    "allListings",
    "oneImage",
    "oneListing",
    "oneAllergie",
    "oneFoodType",
    "setOfAllergies",
  ]),
};
</script>


<style>
.title-page {
  font-family: "Oswald", sans-serif;
  padding: 10px;
  margin-bottom: 20px;
}
.listing-div {
  font-family: "Poiret One", cursive;
  font-weight: bold;
  width: 50%;
  margin: 10px auto;
  /*   border: 3px solid black;
 */
  background-color: rgba(255, 255, 255, 0.7);
  padding: 10px;
  border-radius: 20px;
}

.listing-div h3 {
  font-family: "Bad Script", cursive;
}

.listing-div p {
  padding: 5px;
  font-size: 18px;
  text-align: center;
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

.listing-img {
  padding: 20px;
  width: 150px;
  height: 150px;
  object-fit: cover;
  float: left;
}

.plus-button {
  background: none;
  border: none;
  font-size: 30px;
}
.plus-button:hover {
  color: white;
}
</style>