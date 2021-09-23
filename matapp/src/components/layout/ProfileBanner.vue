<template>
  <div class="profile-banner">
    <div class="banner-bg"></div>
    <img class="profile-img" :src="$auth.user.picture" alt="" />

    <p class="cap-user">{{ $auth.user.preferred_username }}</p>
  </div>
</template>

<script>
export default {
  name: "ProfileBanner",
  data() {
    return {};
  },
  methods: {},
};
</script>

<style>
.profile-banner {
  font-family: "Bad Script", cursive;
}

.profile-img {
  width: 100px;
  border-radius: 50%;
  position: relative;
  z-index: 2;
  text-align: center;
  bottom: 40px;
}

.profile-banner p {
  font-size: 40px;
  position: relative;
  bottom: 40px;
}
</style>