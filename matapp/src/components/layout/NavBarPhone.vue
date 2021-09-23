<template>
  <div>
    <div
      class="navphone"
      :class="{
        'phone-nav--about': adaptColor,
      }"
    >
      <router-link class="link brand" to="/"
        >Kasti Ké <i class="fas fa-cookie-bite"></i
      ></router-link>
    </div>
    <div class="navphone-two">
      <router-link class="link" v-if="$auth.authenticated" to="/profile"
        ><i class="fas fa-user-circle phone-profile-icon"></i
      ></router-link>
      <router-link class="link" to="/about"
        ><i class="fas fa-question"></i><i class="fas fa-cookie-bite"></i>
      </router-link>
      <router-link class="link" to="/listing"
        ><i class="fas fa-shopping-basket"></i
      ></router-link>

      <button v-if="!$auth.authenticated" @click="login" class="phone-log-btn">
        <i class="fas fa-sign-in-alt"></i>
      </button>
      <button v-if="$auth.authenticated" @click="logout" class="phone-log-btn">
        <i class="fas fa-sign-out-alt"></i>
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "NavBarPhone",

  methods: {
    // Log the user in
    login() {
      this.$auth.loginWithRedirect({
        redirect_uri: "http://localhost:8080",
      });
    },
    // Log the user out
    logout() {
      this.$auth.logout({
        returnTo: "http://localhost:8080",
      });
    },
  },
  computed: {
    adaptColor() {
      return this.$route.meta.adaptColor;
    },
  },
};
</script>



<style>
</style>