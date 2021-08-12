<template>

  <div>
    <h1>Products</h1>
    <AddProduct />
    <div
      class="annonser-listing"
      v-for="(annonser, index) in alleAnnonser"
      :key="annonser + index"
    >
      <p>{{ annonser.title }}</p>

      <img
        :src="require(`../assets/images/${annonser.image}`)"
        alt=""
        class="annonser-image"
      />

      <p>{{ annonser.creationDate }}</p>
      <p>{{ annonser.foodType }}</p>
      <p>{{ annonser.user }}</p>
      <router-link :to="`/listing/${annonser.id}`">
        View more details
      </router-link>

      <button @click="deleteAnnonser(annonser.id)">Slett annonser</button>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import AddProduct from "../components/AddProduct.vue";
/* import ConfirmDelete from "../components/modals/confirmDelModal.vue";
 */ export default {
  name: "Products",
  components: { AddProduct },
  /* data() {
    return {
      confirmDel: false,
    };
  }, */
  /*   components: { ConfirmDelete },
   */ /* created() {
    this.fetchAnnonser();
  }, */
  methods: {
    ...mapActions([
      "fetchAnnonser",
      "addAnnonser",
      "deleteAnnonser",
      "fetchUsers",
    ]),
    toggleModal() {
      this.confirmDel = !this.confirmDel;
    },
  },
  computed: mapGetters(["alleAnnonser"]),
  annonserWithImage(annonser) {
    return {
      ...this.annonser,
      image:
        this.annonser.image && require(`../assets/images/${annonser.image}`),
    };
  },
};
</script>

<style>
.annonser-image {
  width: 300px;
}

</style>