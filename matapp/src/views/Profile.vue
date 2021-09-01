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
    <div></div>
    <div v-for="(listing, index) in userListing" :key="listing + index">
      <h3>{{ listing.title }}</h3>
      <p>Posted : {{ listing.creationDate }}</p>
      <p>Pick-up before : {{ listing.deadline }}</p>
      <p>Posted by : {{ listing.userOwner }}</p>
    </div>
    <!-- <div class="mine-anonser">
      <h3>Mine anonser</h3>
      <div class="anonser">
        <div class="anonser-card">
          <img
            src="../assets/images/artur-rutkowski-GdTLaWamFHw-unsplash1.jpeg"
            alt=""
          />
          <div class="anonser-card-text">
            <h4><router-link :to="`/products`">Title anonser</router-link></h4>
            <h4>Dato</h4>
          </div>
        </div>
        <div class="anonser-card">
          <img
            src="../assets/images/artur-rutkowski-GdTLaWamFHw-unsplash1.jpeg"
            alt=""
          />
          <div class="anonser-card-text">
            <h4><router-link :to="`/listing`">Title anonser</router-link></h4>
            <h4>Dato</h4>
          </div>
        </div>
        <div class="anonser-card">
          <img
            src="../assets/images/artur-rutkowski-GdTLaWamFHw-unsplash1.jpeg"
            alt=""
          />
          <div class="anonser-card-text">
            <h4><router-link :to="`/products`">Title anonser</router-link></h4>
            <h4>Dato</h4>
          </div>
        </div>
        <div class="anonser-card">
          <img
            src="../assets/images/artur-rutkowski-GdTLaWamFHw-unsplash1.jpeg"
            alt=""
          />
          <div class="anonser-card-text">
            <h4><router-link :to="`listing`">Title anonser</router-link></h4>
            <h4>Dato</h4>
          </div>
        </div>

        <button>
          <router-link :to="`/profile/myposts`"> ... </router-link>
        </button>
      </div>
    </div> -->
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";

import ProfileBanner from "../components/layout/ProfileBanner.vue";
export default {
  components: { ProfileBanner },
  data() {
    return {
      /* listings: [], */
    };
  },
  created() {
    this.getListingsByUser(this.$auth.user.name);
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
    myOwnListings() {
      return this.listings.filter(
        (list) => list.userOwner === this.$auth.user.name
      );
    },
  },
  computed: mapGetters(["allListings", "userListing"]),
};
</script>

<style>
.mine-anonser {
  width: 80%;
  margin: 2% auto;
}

.mine-anonser h3 {
  text-align: start;
  font-size: 2em;
  padding-left: 20px;
  color: black;
}
.anonser {
  display: flex;
}

.anonser-card {
  width: 20%;
  margin: 10px;
}
.anonser-card img {
  width: 100%;
  max-height: 300px;
}

.anonser-card-text {
  display: flex;
  justify-content: space-between;
  color: black;
}

.anonser-card-text a {
  text-decoration: none;
  color: black;
}
.anonser button {
  height: 30px;
  align-self: center;
  width: 5%;
  margin: 15px;
  border-radius: 50px;
}

.anonser button a {
  text-decoration: none;
  color: black;
  font-weight: bold;
}

.btn-settings {
  font-size: 25px;
  border: none;
}
.btn-settings a {
  text-decoration: none;
  color: black;
}
</style>