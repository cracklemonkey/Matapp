import { createApp } from 'vue'
import App from './App.vue'
import store from './store';
import router from './router'
import './assets/css/style.css';

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