<template>
  <NavBar />
  <router-view class="body" />
  <Footer />
</template>

<script>
import NavBar from "./components/layout/NavBar.vue";
import Footer from "./components/layout/Footer.vue";
export default {
  components: { NavBar, Footer },
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

.body {
  padding-bottom: 40px;
}
</style>
