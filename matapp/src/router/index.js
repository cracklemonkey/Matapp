import { createRouter, createWebHistory } from 'vue-router'
import { AuthenticationGuard } from 'vue-auth0-plugin';

import LandingPage from '../views/LandingPage.vue'
import Listings from '../views/listings/Listings.vue'
import ListingDetails from '../views/listings/ListingDetails.vue'
import Profile from '../views/profile/Profile.vue'
import MyPosts from '../views/profile/MyPosts.vue'
import PreviousOrders from '../views/profile/PreviousOrders.vue'
import PastListings from '../views/profile/PastListings.vue'
import ListingByUser from '../views/listings/ListingByUser.vue'
import EditListing from '../views/listings/EditListing.vue'
import ConfirmedOrder from '../views/listings/ConfirmedOrder.vue'
import About from '../views/About.vue'


const routes = [
  {
    path: '/',
    name: 'LandingPage',
    component: LandingPage
  },

  {
    path: '/listing',
    name: 'Listings',
    component: Listings,

  },

  {
    path: '/listing/:id',
    name: 'ListingDetails',
    component: ListingDetails,

  },
  {
    path: '/listing/:id/edit',
    name: 'EditListing',
    component: EditListing,
    beforeEnter: AuthenticationGuard
  },
  {
    path: '/orderconfirmed',
    name: 'Order Confirmed',
    component: ConfirmedOrder,
    beforeEnter: AuthenticationGuard
  },

  {
    path: '/profile',
    name: 'Profile',
    component: Profile,
    beforeEnter: AuthenticationGuard
  },
  {
    path: '/profile/myposts',
    name: 'MyPosts',
    component: MyPosts,
    beforeEnter: AuthenticationGuard
  },
  {
    path: `/profile/:id/listing`,
    name: 'ListingByUser',
    component: ListingByUser
  },
  {
    path: '/profile/previousorders',
    name: 'Previous Orders',
    component: PreviousOrders,
    beforeEnter: AuthenticationGuard
  },
  {
    path: '/profile/pastlistings',
    name: 'Past Listings',
    component: PastListings,
    beforeEnter: AuthenticationGuard
  },

  {
    path: `/listing/user/:id`,
    name: 'ListingByUser',
    component: ListingByUser
  },

  {
    path: '/about',
    name: 'About',
    component: About,
    meta: { adaptColor: 'nav--about phone-nav--about', onScroll: 'nav--about-bis' },


  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})



export default router
