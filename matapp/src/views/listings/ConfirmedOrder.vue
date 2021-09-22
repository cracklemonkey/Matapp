<template>
  <div class="background-historik space">
    <h1 class="title-page">Your order is confirmed!</h1>

    <h1>
      <router-link class="back" :to="`/listing`">
        Back to Listings
      </router-link>
    </h1>
  </div>
</template>

<script>
export default {};
</script>

<style>
.back {
  font-size: 25px;
  color: white;
}
</style>