<template>
  <div class="profile-banner">
    <img
      class="banner-img"
      src="../../assets/images/david-fartek-8xxW3z31k8A-unsplash2.jpeg"
      alt=""
    />
    <img
      class="banner-img"
      src="../../assets/images/david-fartek-8xxW3z31k8A-unsplash2.jpeg"
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

.profile-banner p {
  font-size: 40px;
  position: relative;
  bottom: 40px;
}

.rating i {
  color: gold;
  font-size: 1.5em;
}
.rating {
  margin: 10px;
}
.rating span {
  margin-left: 10px;
}
</style>