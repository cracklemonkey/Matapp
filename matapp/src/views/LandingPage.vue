<template>
  <div class="background-landing">
    <button v-if="!$auth.loading" class="landing-bubble">
      <h3 v-if="!$auth.authenticated" @click="login">
        New to MatApp? <br />
        Sign up here! <br />
      </h3>
    </button>
    <button v-if="!$auth.loading" class="landing-bubble">
      <h3 v-if="!$auth.authenticated" @click="login">
        Already a member? <br />
        Just log in!
      </h3>
    </button>

    <div v-if="$auth.authenticated">
      <h3 class="welcome">Welcome {{ $auth.user.preferred_username }}</h3>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {};
  },
  methods: {
    // Log the user in
    login() {
      this.$auth.loginWithRedirect({
        redirect_uri: "http://localhost:8080/listing",
      });
    },
    // Log the user out
    logout() {
      this.$auth.logout({
        returnTo: "http://localhost:8080",
      });
    },
  },
};
</script>

<style>
.welcome {
  color: white;
}
</style>