import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import LandingPage from '../views/LandingPage.vue'
import LoggIn from '../views/LoggIn.vue'
import SignUp from '../views/SignUp.vue'
import Products from '../views/Products.vue'
import ProductDetails from '../components/ProductDetails.vue'
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
    path: '/products',
    name: 'Products',
    component: Products
  },

  {
    path: '/products/:productid',
    name: 'ProductDetails',
    component: ProductDetails
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
