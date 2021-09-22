import axios from 'axios';

/* import users from './users';
 */
const state = {
    orderlistings: [],
    oneOrderlisting: "",

    orderedlistings: [],
    oneOrderedlisting: "",

    userOrder: []


};

const getters = {
    allOrderListings: (state) => state.orderlistings,
    oneOrderListing: (state) => state.oneOrderListing,

    allOrderedListings: (state) => state.orderedlistings,
    oneOrderedListing: (state) => state.oneOrderedListing,
    orderByUser: (state) => state.userOrder


};

const actions = {
    async getOrderListings(context) {
        const response = await axios.get("https://localhost:5001/api/orderlistings/fullorders");

        context.commit('setOrderListings', response.data);
    },
    async getOrdersByUser(context, username) {
        const response = await axios.get(`https://localhost:5001/api/orderlistings/fullordersbyusername/${username}`);
        console.log(response.data)
        context.commit('orderUser', response.data)
    },

    async addOrderListing(context, posts) {
        const response = await axios.post(`https://localhost:5001/api/orderlistings`, posts)
        context.commit('newOrderListing', response.data);
        context.dispatch('listings/getListings', null, { root: true })

    },
    async deleteOrderListing(context, orderid) {
        await axios.delete(`https://localhost:5001/api/orderlistings/${orderid}`);
        context.commit('removeOrderListing', orderid);
    },
    async updateOrderListing(context, oneOrderListing) {
        const response = await axios.put(`https://localhost:5001/api/orderlistings/${oneOrderListing.orderid}`, oneOrderListing);
        context.commit('updateOrderListing', response.data);


    },
    async getOrderListingById(context, orderid) {
        const response = await axios.get(`https://localhost:5001/api/orderlistings/${orderid}`);

        console.log(response.data)
        context.commit('setOrderListing', response.data)

    },

    async getOrderedListings(context) {
        const response = await axios.get("https://localhost:5001/api/orderedlistings");

        context.commit('setOrderedListings', response.data);
    },

    async addOrderedListing(context, listing) {
        console.log(listing)
        const response = await axios.post(`https://localhost:5001/api/listings/${listing.listingId}`, listing)
        context.commit('newOrderedListing', response.data);
    },
    async deleteOrderedListing(context, listingid) {
        await axios.delete(`https://localhost:5001/api/orderedlistings/${listingid}`);
        context.commit('removeOrderedListing', listingid);
    },
    async updateOrderedListing(context, oneOrderedListing) {
        const response = await axios.put(`https://localhost:5001/api/orderedlistings/${oneOrderedListing.ListingId}`, oneOrderedListing);
        context.commit('updateOrderedListing', response.data);


    },
    async getOrderedListingById(context, listingid) {
        const response = await axios.get(`https://localhost:5001/api/orderedlistings/${listingid}`);

        console.log(response.data)
        context.commit('setOrderedListing', response.data)

    },

};


const mutations = {
    setOrderListings: (state, orderlistings) => (state.orderlistings = orderlistings),
    newOrderListing: (state, oneOrderListing) => state.orderlistings.unshift(oneOrderListing),
    removeOrderListing: (state, orderid) => state.orderlistings = state.orderlistings.filter(orderlisting => orderlisting.orderid !== orderid),
    updateOrderListing: (state, oneOrderListing) => state.orderlistings.forEach(upd => {
        if (upd.updOrderListingId == oneOrderListing.updOrderListingId) {
            upd = oneOrderListing
        }
    }),
    setOrderListing: (state, oneOrderListing) => (state.oneOrderListing = oneOrderListing),

    setOrderedListings: (state, orderedlistings) => (state.orderedlistings = orderedlistings),
    newOrderedListing: (state, oneOrderedListing) => state.orderedlistings.unshift(oneOrderedListing),
    removeOrderedListing: (state, listingid) => state.orderedlistings = state.orderedlistings.filter(orderedlisting => orderedlisting.listingid !== listingid),
    updateOrderedListing: (state, oneOrderedListing) => state.orderedlistings.forEach(upd => {
        if (upd.updListingId == oneOrderedListing.updListingId) {
            upd = oneOrderedListing
        }
    }),
    setOrderedListing: (state, oneOrderedListing) => (state.oneOrderedListing = oneOrderedListing),
    orderUser: (state, userOrder) => (state.userOrder = userOrder),



};

export default {
    state,
    getters,
    actions,
    mutations
};