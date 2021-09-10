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
      <div v-if="!listing.isOpened">
        <h3>{{ listing.title }}</h3>
        <img
          v-if="listing.image != null"
          class="listing-img"
          :src="`https://localhost:5001/api/image/${listing.image}`"
          alt=""
        />

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
          @click="orderListing(listing.listingId)"
        >
          Order
        </button>
        <ConfirmOrder />
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddListings from "../../components/AddListings.vue";
import ConfirmOrder from "../../components/modals/confirmOrderlModal.vue";
import dayjs from "dayjs";
export default {
  name: "Listings",
  components: { AddListings, ConfirmOrder },
  data() {
    return {
      plusButton: false,
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
      "updateOrder",
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
    orderListing(id) {
      this.postOrder.listingId = id;
      this.postOrder.username = this.$auth.user.preferred_username;
      /* this.updateOrder(this.postOrder); */
      /* this.moveListing(id); */
      console.log(this.postOrder);
    },
  },
  computed: mapGetters(["allListings", "oneImage", "oneListing"]),
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

.listing-img {
  padding: 20px;
  height: 100px;
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