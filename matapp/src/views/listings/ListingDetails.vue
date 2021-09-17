<template>
  <div class="space">
    <div class="listing-div">
      <img
        class="details-image"
        :src="`https://localhost:5001/api/image/${oneListing.image}`"
        alt=""
      />
      <h1>{{ oneListing.title }}</h1>
      <p>
        Description: <br />
        {{ oneListing.description }}
      </p>
      <p>{{ oneListing.foodType }}</p>
      <p>Pick-up before: {{ formatDate(oneListing.deadline) }}</p>
      <p>{{ oneListing.allergies }}</p>
      <p>from {{ oneListing.userOwner }}</p>
      <p>Posted on: {{ formatDate(oneListing.creationDate) }}</p>
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
          $auth.user.preferred_username != oneListing.userOwner
        "
      >
        Order
      </button>
      <button>
        <router-link :to="`/listing`"> Back to Listing </router-link>
      </button>
      <button
        v-if="
          $auth.authenticated &&
          $auth.user.preferred_username != oneListing.userOwner
        "
      >
        <router-link :to="`/listing/user/${oneListing.userOwner}`">
          see all listings from user
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
</template>

<script>
import dayjs from "dayjs";
import { mapGetters, mapActions } from "vuex";
export default {
  created() {
    console.log(this.$route.params.id);
    this.getListingById(this.$route.params.id);
  },
  methods: {
    ...mapActions([
      "getListings",
      "addListing",
      "deleteListing",
      "getListingById",
    ]),
    formatDate(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("dddd D of MMMM, YYYY");
    },
  },
  computed: mapGetters(["oneListing"]),
};
</script>

<style>
.details-image {
  width: 300px;
}
</style>