import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import LandingPage from '../views/LandingPage.vue'
import LoggIn from '../views/LoggIn.vue'
import SignUp from '../views/SignUp.vue'
import Listings from '../views/Listings.vue'
import ListingDetails from '../components/ListingDetails.vue'
import OrderPage from '../views/OrderPage.vue'
import Profile from '../views/Profile.vue'
import Settings from '../views/Settings.vue'
import MyPosts from '../views/MyPosts.vue'
import Historik from '../views/Historik.vue'
import ListingByUser from '../components/ListingByUser.vue'
import EditListing from '../components/EditListing.vue'


const routes = [
  {
    path: '/',
    name: 'LandingPage',
    component: LandingPage
  },

  {
    path: '/home',
    name: 'Home',
    component: Home
  },

  {
    path: '/loggin',
    name: 'LoggIn',
    component: LoggIn
  },

  {
    path: '/signup',
    name: 'SignUp',
    component: SignUp
  },

  {
    path: '/listing',
    name: 'Listings',
    component: Listings
  },

  {
    path: '/listing/:id',
    name: 'ListingDetails',
    component: ListingDetails
  },
  {
    path: '/listing/:id/edit',
    name: 'EditListing',
    component: EditListing
  },



  {
    path: '/order',
    name: 'OrderPage',
    component: OrderPage
  },

  {
    path: '/profile',
    name: 'Profile',
    component: Profile
  },
  {
    path: '/profile/settings',
    name: 'Settings',
    component: Settings
  },
  {
    path: '/profile/myposts',
    name: 'MyPosts',
    component: MyPosts
  },
  {
    path: `/profile/:id/listing`,
    name: 'ListingByUser',
    component: ListingByUser
  },
  {
    path: '/profile/historik',
    name: 'Historik',
    component: Historik
  },
  {
    path: `/listing/user/:id`,
    name: 'ListingByUser',
    component: ListingByUser
  },





  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
