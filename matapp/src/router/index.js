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


const routes = [
  {
    path: '/',
    name: 'LandingPage',
    component: LandingPage
  },

  {
    path: '/home',
    name: 'Home',
    component: Home,
    meta: { requiresAuth: true }
  },

  {
    path: '/loggin',
    name: 'LoggIn',
    component: LoggIn,
    meta: { guest: true }
  },

  {
    path: '/signup',
    name: 'SignUp',
    component: SignUp,
    meta: { guest: true }
  },

  {
    path: '/listing',
    name: 'Listings',
    component: Listings,
    meta: { requiresAuth: true }
  },

  {
    path: '/listing/:id',
    name: 'ListingDetails',
    component: ListingDetails,
    meta: { requiresAuth: true }
  },

  {
    path: '/order',
    name: 'OrderPage',
    component: OrderPage,
    meta: { requiresAuth: true }
  },

  {
    path: '/profile',
    name: 'Profile',
    component: Profile,
    meta: { requiresAuth: true }
  },
  {
    path: '/profile/settings',
    name: 'Settings',
    component: Settings,
    meta: { requiresAuth: true }
  },
  {
    path: '/profile/myposts',
    name: 'MyPosts',
    component: MyPosts
  },
  {
    path: '/profile/historik',
    name: 'Historik',
    component: Historik
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
