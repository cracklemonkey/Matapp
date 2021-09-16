import { createStore } from 'vuex';

import listings from './modules/listings';
import orderlisting from './modules/orderlisting';




const store = createStore({
    modules: {
        listings,
        orderlisting
    }
})

export default store