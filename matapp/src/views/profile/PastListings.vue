<template>
  <div class="background-historik space">
    <h1 class="title-page">My Past Listings</h1>
    <div
      class="listing-div"
      v-for="(orderListing, index) in orderByOwner"
      :key="orderListing + index"
    >
      <div class="listing-img">
        <img
          v-if="orderListing.image != null"
          :src="`https://localhost:5001/api/image/${orderListing.image}`"
          alt=""
        />
        <img
          v-if="orderListing.image == null"
          src="../../assets/images/hoach-le-dinh-c8TWWQ5ZnUw-unsplash.jpeg"
          alt=""
        />
      </div>
      <div class="listing-info">
        <h3>{{ orderListing.title }}</h3>

        <p>{{ orderListing.description }}</p>
        <p>Posted : {{ formatDate(orderListing.creationDate) }}</p>
        <p>Ordered : {{ formatDate(orderListing.orderDate) }}</p>
        <p class="cap-user">Posted by : {{ orderListing.userOwner }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import dayjs from "dayjs";
import { mapGetters, mapActions } from "vuex";
export default {
  created() {
    this.getOrdersByOwner(this.$auth.user.preferred_username);
  },
  methods: {
    ...mapActions(["getOrdersByOwner"]),
    formatDate(dateString) {
      const date = dayjs(dateString);
      // Then specify how you want your dates to be formatted
      return date.format("dddd D of MMMM, YYYY");
    },
  },
  computed: mapGetters(["orderByOwner"]),
};
</script>

<style>
</style>