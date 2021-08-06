<template>
  <!-- <div
    class="background-landing"
    :style="{ backgroundImage: 'url(' + img + ')' }"
  > -->
  <div class="background-landing">
    <section class="landing-textarea">
      <div class="landing-bubble">
        <router-link :to="`/signup`">
          <h3>
            Are You New? <br />
            Sign Up!
          </h3>
        </router-link>
      </div>

      <div class="landing-bubble">
        <router-link :to="`/loggin`">
          <h3>
            Already a Member? <br />
            Log in here
          </h3>
        </router-link>
      </div>
    </section>
  </div>
</template>

<script>
/* import TempBg from "../assets/images/artur-rutkowski-GdTLaWamFHw-unsplash.jpeg";
 */ export default {
  data() {
    return {
      /* img: TempBg, */
    };
  },
};
</script>

<style>
</style>