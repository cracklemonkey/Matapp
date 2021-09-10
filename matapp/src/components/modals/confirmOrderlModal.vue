<template>
  <div class="modal">
    <p>Are you sure you want order {{ listing.title }}?</p>
    <button @click="orderListing(listing.listingId)">Yes</button>
    <button @click="closeConfirm">No</button>
  </div>
</template>

<script>
export default {
  name: "ConfirmOrder",
  props: ["listing"],
  methods: {
    closeConfirm() {
      this.$emit("close");
    },
  },
};
</script>

<style>
.modal {
  background: #42b983;
  width: 100%;
  font-size: 30px;
}
</style>