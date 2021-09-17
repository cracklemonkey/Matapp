<template>
  <div class="profile-banner">
    <img
      class="banner-img"
      src="../../assets/images/shumilov-ludmila-j7X_hySaUa4-unsplash.jpeg"
      alt=""
    />
    <img
      class="banner-img second-image"
      src="../../assets/images/shumilov-ludmila-j7X_hySaUa4-unsplash.jpeg"
      alt=""
    />
    <img class="profile-img" :src="$auth.user.picture" alt="" />

    <p>{{ $auth.user.preferred_username }}</p>
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

.profile-banner p {
  font-size: 40px;
  position: relative;
  bottom: 40px;
}
</style>