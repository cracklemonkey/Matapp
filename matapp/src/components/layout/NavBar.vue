<template>
  <div
    class="nav"
    :class="{
      'nav--show': !showNavbar,
      'nav--about': adaptColor,
      'nav--about-bis': !showNavbar,
    }"
  >
    <div>
      <router-link class="link brand" to="/"
        >MatApp <i class="fas fa-cookie-bite"></i
      ></router-link>
    </div>
    <div>
      <router-link class="link" to="/listing">Listing</router-link>
      <router-link class="link" to="/about">About</router-link>

      <router-link class="link" v-if="$auth.authenticated" to="/profile"
        ><i class="far fa-user-circle profile-icon"></i
      ></router-link>

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
  data() {
    return {
      showNavbar: true,
      lastScrollPosition: 0,
    };
  },
  mounted() {
    window.addEventListener("scroll", this.onScroll);
  },
  beforeUnmount() {
    window.removeEventListener("scroll", this.onScroll);
  },
  computed: {
    adaptColor() {
      return this.$route.meta.adaptColor;
    },
  },
  methods: {
    onScroll() {
      const currentScrollPosition =
        window.pageYOffset || document.documentElement.scrollTop;
      if (currentScrollPosition < 0) {
        return;
      }
      // Stop executing this function if the difference between
      // current scroll position and last scroll position is less than some offset
      if (Math.abs(currentScrollPosition - this.lastScrollPosition) < 75) {
        return;
      }

      this.showNavbar = currentScrollPosition < this.lastScrollPosition;
      if (this.lastScrollPosition) {
        return;
      }
      this.lastScrollPosition = currentScrollPosition;
    },
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
.log-btn {
  font-family: inherit;
  color: white;
  font-weight: bold;
  padding: 0 4px;
  margin-right: 20px;
  background: transparent;
  border: 2px solid white;
  border-radius: 10px;
}

.log-btn:hover {
  background: #070b0f;
  color: white;
}

.nav--show .log-btn {
  color: black;
}
.nav--about .log-btn {
  color: black;
  border: 2px solid black;
}

.profile-icon {
  font-size: 1.5em;
}

.nav--about .profile-icon {
  font-size: 1.5em;
  color: black;
}

.profile-icon:hover {
  color: #070b0f;
}

.link {
  padding-right: 10px;
  padding-left: 10px;
}
.brand {
  font-size: 1.5em;
}
</style>