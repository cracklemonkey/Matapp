<template>
    <form @submit.prevent="orderListing" method="POST">
        
          <button
            v-if="
              $auth.authenticated &&
              $auth.user.preferred_username != listing.userOwner
            "
            @click="order(this.listing)"
          >
            Order
          </button>
        </form>
</template>

<script>
 import { mapActions } from "vuex";
export default {
    name: 'OrderListing',
    data() {
    return {
      posts: {

          username: null,
          orderDate: new Date(),
          listingId: this.listing.listingId

        
        
       
      },
    };
  },
    props:['listing'],
    methods: {
        ...mapActions(['addOrderedListing', 'addOrderListing']),

        async order(listing){
            console.log(listing.listingId)
            this.posts.username = this.$auth.user.preferred_username
            
            await this.addOrderListing(this.posts)
            await this.addOrderedListing(listing)
            alert(`You hav orderd: ${listing.title}`)
            window.location.reload()
        }
    },
}
</script>

<style>

</style>