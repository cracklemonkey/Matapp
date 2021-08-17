<template>
  <div class="modal">
    <p>Are you sure you want to delete it?</p>
    <button @click="deleteAnnonser(annonser.id)">Yes</button>
    <button>No</button>
  </div>
</template>

<script>
export default {
  name: "ConfirmDelete",
};
</script>

<style>
.modal {
  background: red;
  width: 100%;
  font-size: 30px;
}
</style>