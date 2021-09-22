<template>
  <div class="background-listing space">
    <div class="listing-details">
      <div class="listing-image">
        <img
          v-if="oneListing.image != null"
          class="details-image"
          :src="`https://localhost:5001/api/image/${oneListing.image}`"
          alt=""
        />
      </div>
      <div class="listing-info">
        <h1>{{ oneListing.title }}</h1>
        <hr />
        <div class="listing-description">
          <p class="list-label">Description:</p>
          <p>{{ oneListing.description }}</p>
        </div>

        <div>
          <p class="list-label">Pick-up before:</p>
          <p>{{ formatDate(oneListing.deadline) }}</p>
        </div>

        <div>
          <p class="list-label">Category :</p>
          <span
            v-for="(foodtype, index) in setOfFoodTypes"
            :key="foodtype + index"
          >
            {{ foodtype.name }} <span> </span>
          </span>
        </div>
        <div>
          <div>
            <p class="list-label">Allergies :</p>
            <span
              v-for="(allergie, index) in setOfAllergies"
              :key="allergie + index"
            >
              {{ allergie.name }} <span> </span>
            </span>
          </div>

          <div>
            <p class="list-label">Posted by:</p>
            <p class="cap-user">
              {{ oneListing.userOwner }},
              {{ formatDateTwo(oneListing.creationDate) }}
            </p>
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
            <button
              v-if="
                $auth.authenticated &&
                $auth.user.preferred_username === oneListing.userOwner
              "
              @click="remove(oneListing.listingId, oneListing.image)"
            >
              Delete
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
    orderupdate() {
      console.log("done");
      /*  window.location.reload(); */
      this.$router.push({ name: "Listings" });
    },
    remove(listingId, imageName) {
      this.deleteListing(listingId);
      this.deleteImage(imageName);
      this.$router.push({ name: "Listings" });
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
.listing-description {
  width: 75%;
  margin: auto;
}

hr {
  border: solid 2px white;
  border-radius: 40%;
  margin: 2% 30%;
}
.list-label {
  font-family: "Bad Script", cursive;
}

@media (max-width: 768px) {
  .listing-details {
    width: 85%;
    display: block;
  }
}
</style>