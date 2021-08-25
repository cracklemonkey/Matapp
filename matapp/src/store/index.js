import { createStore } from 'vuex';

import users from './modules/users';
import listings from './modules/listings';
import auth from './modules/auth';
import auth2 from './modules/auth2';


const store = createStore({
    modules: {
        users, listings, auth, auth2
    }
})

export default store