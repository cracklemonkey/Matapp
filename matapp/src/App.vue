<template>
  <NavBar id="topdesk" class="desktop" />
  <NavBarPhone id="topphone" class="phone" />
  <router-view class="body" />
  <Footer class="desktop" />
</template>

<script>
import NavBarPhone from "./components/layout/NavBarPhone.vue";
import NavBar from "./components/layout/NavBar.vue";
import Footer from "./components/layout/Footer.vue";
export default {
  components: { NavBar, Footer, NavBarPhone },
};
</script>


<style>
* {
  padding: 0;
  margin: 0;
}
#app {
  font-family: "Poiret One", cursive;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  /* color: #2c3e50; */
  color: #070b0f;
}
.phone {
  display: none;
}

.body {
  padding-bottom: 40px;
}
@media (max-width: 768px) {
  .desktop {
    display: none;
  }
  .phone {
    display: block;
  }
  .body {
    padding-bottom: 150px;
  }
}
</style>
