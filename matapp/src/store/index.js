import { createStore } from 'vuex';

import users from './modules/users';
import annonser from './modules/annonser';
import auth from './modules/auth';


const store = createStore({
    modules: {
        users, annonser, auth
    }
})

export default store