import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store';
import axios from 'axios'
import './assets/css/style.css';

axios.defaults.withCredentials = true
axios.defaults.baseURL = 'https://localhost:5001/api/users/'

axios.interceptors.response.use(undefined, function (error) {
  if (error) {
    const originalRequest = error.config
    if (error.response.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true
      store.dispatch('LogOut')
      return router.push('/loggin')
    }
  }
})

/* 
createApp(App).use(router).mount('#app')
import { createApp } from 'vue'
import App from './App.vue'
import store from './store'
 */


const app = createApp(App)
app.use(router);
app.use(store);



app.mount('#app');