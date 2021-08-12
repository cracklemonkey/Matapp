<template>
  <div>
    <h1>listing details</h1>
    <p>{{ annons.title }}</p>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
export default {
  created() {
    console.log(this.$route.params.id);
    this.getAnnonserById(this.$route.params.id);
  },
  methods: {
    ...mapActions([
      "fetchAnnonser",
      "addAnnonser",
      "deleteAnnonser",
      "getAnnonserById",
    ]),
  },
  computed: mapGetters(["annons"]),
  annonserWithImage(annons) {
    return {
      ...this.annons,
      image: this.annons.image && require(`../assets/images/${annons.image}`),
    };
  },
};
</script>

<style>
</style>