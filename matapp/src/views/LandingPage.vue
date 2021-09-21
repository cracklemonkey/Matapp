<template>
  <div class="background-landing space">
    <div v-if="!$auth.authenticated">
      <button class="landing-bubble">
        <h3 @click="login">
          <p>Want to join the Kastikke Family?</p>
          <p>Sign up here!</p>
        </h3>
      </button>
      <button class="landing-bubble">
        <h3 @click="login">
          <p>Already a member?</p>
          <p>Just log in!</p>
        </h3>
      </button>
    </div>
    <div class="welcome" v-if="$auth.authenticated">
      <h3>Welcome Back</h3>
      <h3 class="cap-user">{{ $auth.user.preferred_username }}</h3>
      <h3><i class="far fa-heart"></i></h3>
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
};
</script>

<style>
.welcome {
  color: white;
  font-size: 3em;
  /*   font-family: "Bad Script", cursive;
 */
  font-family: "Poiret One", cursive;
}
.landing-bubble {
  display: flex;

  background-color: transparent;
  font-size: 35px;
  border: none;
  color: white;
  margin: 10% auto;
}

.landing-bubble:hover {
  color: black;
}

.cap-user {
  text-transform: capitalize;
}
</style>