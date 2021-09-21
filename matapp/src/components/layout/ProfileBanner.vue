<template>
  <div class="profile-banner">
    <!--  <img
      class="banner-img repeating-radial"
      src="../../assets/images/shumilov-ludmila-j7X_hySaUa4-unsplash.jpeg"
      alt=""
    />
    <img
      class="banner-img second-image repeating-radial"
      src="../../assets/images/shumilov-ludmila-j7X_hySaUa4-unsplash.jpeg"
      alt=""
    /> -->
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
.banner-img {
  max-height: 40vh;
  width: 50%;

  position: relative;
}

.profile-img {
  width: 100px;
  border-radius: 50%;
  position: relative;
  z-index: 2;
  text-align: center;
  bottom: 40px;
}
.second-image {
  -webkit-transform: scaleX(-1);
  transform: scaleX(-1);
}

.repeating-radial {
  background: repeating-radial-gradient(
    black,
    black 5px,
    white 5px,
    white 10px
  );
  z-index: 99999;
}
.profile-banner p {
  font-size: 40px;
  position: relative;
  bottom: 40px;
}
</style>