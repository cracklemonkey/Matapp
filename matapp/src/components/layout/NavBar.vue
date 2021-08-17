<template>
  <div id="nav">
    <router-link to="/">Landingpage</router-link>|
    <router-link to="/home">Home</router-link>|
    <router-link to="/listing">Listing</router-link>|
    <router-link to="/about">About</router-link>|
    <router-link to="/loggin">Loggin</router-link>|
    <router-link to="/signup">SignUp</router-link>|
    <router-link to="/profile">Profile</router-link>|
    <router-link to="/order">OrderPage</router-link>
  </div>
</template>

<script>
export default {
  name: "NavBar",
};
</script>

<style>
#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>