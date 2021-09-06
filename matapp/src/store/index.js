import { createStore } from 'vuex';

import listings from './modules/listings';




const store = createStore({
    modules: {
        listings
    }
})

export default store