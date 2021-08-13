import { createStore } from 'vuex';

import users from './modules/users';
import listings from './modules/listings';
import auth from './modules/auth';


const store = createStore({
    modules: {
        users, listings, auth
    }
})

export default store