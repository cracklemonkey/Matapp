<template>
  <div id="nav">
    <div>
      <router-link class="link brand" to="/"
        >MatApp <i class="fas fa-cookie-bite"></i
      ></router-link>
    </div>
    <div>
      <router-link class="link" to="/listing">Listing</router-link>|
      <router-link class="link" to="/about">About</router-link>|

      <router-link class="link" v-if="$auth.authenticated" to="/profile"
        ><i class="far fa-user-circle profile-icon"></i
      ></router-link>
      |
      <button v-if="!$auth.authenticated" @click="login" class="log-btn">
        Log In
      </button>
      <button v-if="$auth.authenticated" @click="logout" class="log-btn">
        Log Out
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "NavBar",
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
#nav {
  padding: 30px;
  display: flex;
  justify-content: space-between;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

.log-btn {
  font-family: inherit;
  color: #2c3e50;
  font-weight: bold;
  padding: 0 4px;
  background: transparent;
  border: 2px solid #2c3e50;
  border-radius: 10px;
}

.log-btn:hover {
  background: #42b983;
  color: white;
}

.profile-icon {
  font-size: 1.5em;
}

.link {
  padding-right: 10px;
  padding-left: 10px;
}
.brand {
  font-size: 1.5em;
}
</style>