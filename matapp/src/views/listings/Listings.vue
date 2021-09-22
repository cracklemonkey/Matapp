<template>
  <div class="background-listing">
    <div class="space">
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
        <AddListings @toggle="togglePlus()" />
      </div>

      <div
        class="listing-div nav-change"
        v-for="(listing, index) in allListings"
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
          </div>
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
    formatDateTwo(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("D/MM/YY");
    },

    orderupdate() {
      console.log("test");
      /*  window.location.reload(); */
    },
    remove(listingId, imageName) {
      this.deleteListing(listingId);
      this.deleteImage(imageName);
      this.getListings();
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
  font-family: "Poiret One", cursive;
  padding: 10px;
  margin-bottom: 20px;
  color: white;
}
.listing-div {
  font-family: "Poiret One", cursive;
  font-weight: bold;
  width: 50%;
  margin: 10px auto;
  background-color: rgba(255, 255, 255, 0.6);
  padding: 10px;
  border-radius: 20px;
  display: flex;
}

.listing-info {
  margin: auto;
}

.listing-info h3 {
  font-family: "Bad Script", cursive;
  font-size: 25px;
}

.listing-info p {
  padding: 5px;
  font-size: 20px;
  text-align: left;
}

.listing-info button {
  font-family: inherit;
  font-size: 18px;
  padding: 5px;
  margin: 10px;
  border-radius: 30px;
  border: black 1px solid;
  font-family: "Poiret One", cursive;
  font-weight: bold;
}

.listing-info button:hover {
  color: white;
  background-color: black;
}
.listing-info button a {
  text-decoration: none;
  color: black;
}
.listing-info button a:hover {
  color: white;
}

.listing-img {
  align-self: center;
}

.listing-img img {
  padding: 20px;
  width: 150px;
  height: 150px;
  object-fit: cover;
  border-radius: 0px 30px;
}

.plus-button {
  background: none;
  border: none;
  font-size: 30px;
}
.plus-button {
  color: white;
}
.plus-button:hover {
  color: black;
}

.buttons-div {
  display: flex;
  justify-content: center;
}
@media (max-width: 768px) {
  .listing-div {
    display: block;
    width: 90%;
  }
  .listing-info h3 {
    font-size: 20px;
  }

  .listing-info p {
    font-size: 17px;
    text-align: center;
  }

  .listing-info button {
    font-size: 15px;
  }

  .listing-img img {
    padding: 5px;
    width: 150px;
    height: 150px;
    object-fit: cover;
    border-radius: 0px 30px;
  }
}
</style>