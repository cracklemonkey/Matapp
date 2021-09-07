import { createApp } from 'vue'
import VueAuth0Plugin from 'vue-auth0-plugin'
import { domain, client_id, redirect_uri } from '../auth_config.json'
import App from './App.vue'
import router from './router'
import store from './store';
import dayjs from 'dayjs'

import './assets/css/style.css'

const app = createApp(App)
app.use(VueAuth0Plugin, {
    domain,
    client_id,
    redirect_uri,
    onRedirectCallback: appState => {
        router.push(
            appState && appState.targetUrl
                ? appState.targetUrl
                : window.location.pathname
        )
    }

});
app.use(router);
app.use(store);

app.config.globalProperties.$dayjs = dayjs

app.mount('#app');