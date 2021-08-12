<template>
  <div class="profile-banner">
    <img
      class="banner-img"
      src="../../assets/images/david-fartek-8xxW3z31k8A-unsplash2.jpeg"
      alt=""
    />
    <img
      class="profile-img"
      src="../../assets/images/evi-radauscher-U_D5NWMmTTM-unsplash.jpeg"
      alt=""
    />

    <p>{{ users.username }}</p>
    <div class="rating">
      <i class="fas fa-star"></i>
      <i class="fas fa-star"></i>
      <i class="fas fa-star"></i>
      <i class="fas fa-star"></i>
      <i class="fas fa-star-half-alt"></i>
      <span> 4.5/5</span>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
export default {
  name: "ProfileBanner",
  data() {
    return {
      users: [],
    };
  },
  methods: {
    ...mapActions(["fetchUsers", "deleteUser", "updateUser"]),
  },
  computed: mapGetters(["alleUsers"]),
};
</script>

<style>
.banner-img {
  max-height: 35vh;
  width: 100%;
  position: relative;
}

.profile-img {
  width: 200px;
  border-radius: 50%;
  position: absolute;
  z-index: 2;
  left: 44%;
  bottom: 40%;
}

.profile-banner p {
  font-size: 40px;
  position: relative;
  margin-top: 130px;
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