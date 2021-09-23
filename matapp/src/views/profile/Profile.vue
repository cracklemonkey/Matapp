<template>
  <div class="background-profile">
    <ProfileBanner />

    <div class="my-listings">
      <div class="title-section">
        <router-link :to="`/profile/myposts`"
          ><h2>
            My Current Listings <i class="fas fa-chevron-circle-right"></i>
          </h2>
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
        </div>

        <button class="view-more" v-if="userListing.length > 4">
          <router-link :to="`/profile/myposts`">
            View more <i class="fas fa-chevron-circle-right"></i>
          </router-link>
        </button>
      </div>
    </div>
    <div class="my-listings">
      <div class="title-section">
        <router-link :to="`/profile/previousorders`">
          <h2>
            My previous orders <i class="fas fa-chevron-circle-right"></i>
          </h2>
        </router-link>
        <div class="oneListing">
          <div
            class="listing-card"
            v-for="(orderListing, index) in orderByUser.slice(0, 4)"
            :key="orderListing + index"
          >
            <router-link :to="`/listing/${orderListing.title}`">
              <h3>{{ orderListing.title }}</h3>
            </router-link>
            <p>Posted: {{ formatDate(orderListing.creationDate) }}</p>
            <p>Ordered : {{ formatDate(orderListing.orderDate) }}</p>
          </div>
          <button class="" v-if="orderByUser.length > 4">
            <router-link :to="`/profile/previousorders`">
              View more <i class="fas fa-chevron-circle-right"></i
            ></router-link>
          </button>
        </div>
      </div>
    </div>
    <div class="my-listings">
      <div class="title-section">
        <router-link :to="`/profile/pastlistings`">
          <h2>My past listings <i class="fas fa-chevron-circle-right"></i></h2>
        </router-link>

        <div class="oneListing">
          <div
            class="listing-card"
            v-for="(orderListing, index) in orderByOwner.slice(0, 4)"
            :key="orderListing + index"
          >
            <router-link :to="`/listing/${orderListing.title}`">
              <h3>{{ orderListing.title }}</h3>
            </router-link>

            <p>Ordered : {{ formatDate(orderListing.orderDate) }}</p>
          </div>

          <button class="" v-if="orderByOwner.length > 4">
            <router-link :to="`/profile/pastlistings`">
              View more <i class="fas fa-chevron-circle-right"></i
            ></router-link>
          </button>
        </div>
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
    this.getOrdersByUser(this.$auth.user.preferred_username);
    this.getOrdersByOwner(this.$auth.user.preferred_username);
  },

  methods: {
    ...mapActions([
      "getListings",
      "getListingById",
      "addListing",
      "deleteListing",
      "updateListing",
      "getListingsByUser",
      "getOrderListings",
      "getOrdersByUser",
      "getOrdersByOwner",
    ]),
    formatDate(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("D/MM/YY");
    },
  },
  computed: mapGetters([
    "allListings",
    "userListing",
    "orderByUser",
    "orderByOwner",
  ]),
};
</script>

<style>
.my-listings {
  width: 80%;
  margin: 1% auto;
  font-family: "Poiret One", cursive;
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
  text-decoration: underline;
}

.oneListing {
  display: flex;
  flex-direction: row;
}

.listing-card {
  width: 20%;
  margin: 10px;
  text-align: left;
  font-weight: bold;
}
.listing-card h3 {
  font-family: "Bad Script", cursive;
}

.listing-card a {
  color: black;
}
.listing-card a:hover {
  color: #2999ac;
}

.oneListing button {
  font-family: inherit;
  height: 40px;
  align-self: center;
  width: 20%;
  margin: 15px;
  border: none;

  background-color: transparent;
}

.oneListing button a {
  text-decoration: none;
  color: black;
  font-size: 18px;
  font-weight: bold;
}

.view-more:hover {
  color: #2999ac;
}
.btn-settings {
  font-size: 25px;
  border: none;
  position: relative;
  bottom: 20px;
}
/* .btn-settings a {
  text-decoration: none;
  color: black;
} */
@media (max-width: 768px) {
  .oneListing {
    display: block;
  }
  .listing-card {
    width: 80%;
    margin: 10px;
    text-align: left;
  }
  .oneListing button {
    align-self: center;
    width: 60%;
  }

  .title-section {
    font-size: 13px;
  }
}
</style>