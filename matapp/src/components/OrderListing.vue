<template>
  <form @submit.prevent="orderListing" method="POST">
    
      <button
          v-if="
            $auth.authenticated &&
            $auth.user.preferred_username != listing.userOwner &&
            !showConfirm
          "
          @click="toggleConfirm()"
        >
          Order
        </button>
        
        <div v-if="showConfirm">
          
          <div class="modal">
          <p>Are you sure you want order {{ listing.title }}?</p>
          <button @click="orderListing(listing)">Yes</button>
          <button @click="toggleConfirm(listing)">No</button>
          </div>
          
          
        </div>
          
  </form>
    
 
  
</template>

<script>
import { mapActions } from "vuex";

 
export default {
 
    name: 'OrderListing',
    
    props:['listing'],
    data() {
    return {
      showConfirm: false,
      posts: {

          username: null,
          orderDate: new Date(),
          listingId: this.listing.listingId
      },
    };
  },

    methods: {
      ...mapActions(['addOrderedListing', 'addOrderListing']),
    
    
    async orderListing(listing){
      console.log(listing.listingId)
      this.posts.username = this.$auth.user.preferred_username
            
      await this.addOrderListing(this.posts)
      await this.addOrderedListing(listing)
      alert(`You have orderd: ${listing.title}`)
      this.toggleConfirm()
      this.$emit('update')
      
      
    },
  
    toggleConfirm() {
   
    this.showConfirm = !this.showConfirm;
    },

    },
}
</script>

<style>
.modal {
  background: #42b983;
  width: 100%;
  font-size: 30px;
}
</style>