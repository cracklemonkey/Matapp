<template>
  <div>
    <h1 class="title-page">All Listings</h1>

    <div>
      <button @click="togglePlus" class="plus-button">
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

      <!--       <img :src="require(`${listing.image}`)" alt="" class="annonser-image" />
 -->
      <p>Posted : {{ listing.creationDate }}</p>
      <p>Pick-up before : {{ listing.deadline }}</p>
      <p>Expires : {{ listing.expirationDate }}</p>
      <p>{{ listing.foodType }}</p>
      <p>Posted by : {{ listing.userOwner }}</p>
      <button>
        <router-link :to="`/listing/${listing.id}`">
          View more details
        </router-link>
      </button>
      <button @click="deleteListing(listing.id)">Delete</button>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddListings from "../components/AddListings.vue";
/* import ConfirmDelete from "../components/modals/confirmDelModal.vue";
 */ export default {
  name: "Listings",
  components: { AddListings },
  data() {
    return {
      /* confirmDel: false, */
      plusButton: false,
    };
  },
  /*   components: { ConfirmDelete },
   */ created() {
    this.getListings();
  },
  methods: {
    ...mapActions([
      "getListings",
      "addListing",
      "deleteListing",
      "updateListing",
      "getListingById",
      "getUsers",
    ]),
    toggleModal() {
      this.confirmDel = !this.confirmDel;
    },
    togglePlus() {
      this.plusButton = !this.plusButton;
    },
  },
  computed: mapGetters(["allListings"]),

  /* annonserWithImage(annonser) {
    return {
      ...this.annonser,
      image:
        this.annonser.image && require(`../assets/images/${annonser.image}`),
    };
  }, */
};
</script>

<style>
/* .annonser-image {
  width: 300px;
} */
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

.plus-button {
  background: none;
  border: none;
  font-size: 30px;
}
</style>