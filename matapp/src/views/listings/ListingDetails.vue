<template>
  <div class="background-listing space">
    <div class="listing-details">
      <div class="listing-image">
        <img
          class="details-image"
          :src="`https://localhost:5001/api/image/${oneListing.image}`"
          alt=""
        />
      </div>
      <div class="listing-info">
        <h1>{{ oneListing.title }}</h1>
        <div class="listing-description">
          <p>Description:</p>
          <p>{{ oneListing.description }}</p>
        </div>
        <div>
          <p>Pick-up before:</p>
          <p>{{ formatDate(oneListing.deadline) }}</p>
        </div>
        <div>
          <p>Category :</p>
          <span
            v-for="(foodtype, index) in setOfFoodTypes"
            :key="foodtype + index"
          >
            {{ foodtype.name }} <span> </span>
          </span>
        </div>
        <div>
          <div>
            <p>Allergies :</p>
            <span
              v-for="(allergie, index) in setOfAllergies"
              :key="allergie + index"
            >
              {{ allergie.name }} <span> </span>
            </span>
          </div>
          <div>
            <p>Posted by:</p>
            <p class="cap-user">{{ oneListing.userOwner }}</p>
          </div>
          <div>
            <p>Posted on: {{ formatDateTwo(oneListing.creationDate) }}</p>
          </div>
          <div class="buttons-details">
            <button
              v-if="
                $auth.authenticated &&
                $auth.user.preferred_username === oneListing.userOwner
              "
            >
              <router-link :to="`/listing/${oneListing.listingId}/edit`">
                Edit
              </router-link>
            </button>
            <order-listing :listing="oneListing" @update="orderupdate()" />

            <button>
              <router-link :to="`/listing`"> Back to Listing </router-link>
            </button>
            <button
              v-if="
                $auth.authenticated &&
                $auth.user.preferred_username != oneListing.userOwner
              "
            >
              <router-link
                class="cap-user"
                :to="`/listing/user/${oneListing.userOwner}`"
              >
                {{ oneListing.userOwner }}'s listings<br />
              </router-link>
            </button>
            <button
              v-if="
                $auth.authenticated &&
                $auth.user.preferred_username === oneListing.userOwner
              "
            >
              <router-link :to="`/profile/myposts`">
                see all my listings
              </router-link>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import dayjs from "dayjs";
import { mapGetters, mapActions } from "vuex";
import OrderListing from "../../components/OrderListing.vue";

export default {
  components: { OrderListing },

  created() {
    console.log(this.$route.params.id);
    this.getListingById(this.$route.params.id);
    this.getFTByListingId(this.$route.params.id);
    this.getAllergiesByListingId(this.$route.params.id);
  },
  methods: {
    ...mapActions([
      "getListings",
      "addListing",
      "deleteListing",
      "getListingById",
      "getAllergiesByListingId",
      "getFTByListingId",
    ]),
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
  },
  computed: mapGetters(["oneListing", "setOfAllergies", "setOfFoodTypes"]),
};
</script>

<style>
.details-image {
  width: 250px;
  height: 250px;
  object-fit: cover;
  border-radius: 0px 30px;
  border: 2px solid rgba(255, 255, 255, 0.8);
}
.listing-details h1 {
  font-family: "Bad Script", cursive;
}
.listing-details {
  width: 55%;
  margin: 10px auto;
  background-color: rgba(255, 255, 255, 0.5);
  padding: 10px;
  border-radius: 20px;
  display: flex;
  flex-direction: row;
}
.listing-info {
  font-family: "Poiret One", cursive;
  font-weight: bold;
}
.listing-image {
  align-self: center;
}

.listing-details p {
  padding: 5px;
  font-size: 18px;
  text-align: center;
}

.buttons-details button {
  font-family: inherit;
  font-size: 18px;
  padding: 5px;
  margin: 10px;
  border-radius: 30px;
  border: black 1px solid;
  font-family: "Poiret One", cursive;
  font-weight: bold;
}
.buttons-details button a {
  text-decoration: none;
  color: black;
}
</style>