import axios from 'axios';
/* import users from './users';
 */
const state = {
    listings: [],
    oneListing: "",
    userListing: [],
};

const getters = {
    allListings: (state) => state.listings,
    oneListing: (state) => state.oneListing,
    userListing: (state) => state.userListing

};

const actions = {
    async getListings(context) {
        const response = await axios.get("https://localhost:5001/api/listings");

        context.commit('setListings', response.data);
    },
    async addListing(context, posts) {
        const response = await axios.post(`https://localhost:5001/api/listings`, posts)
        console.log(response);
        console.log(posts)
        context.commit('newListing', response.data);
    },
    /*  async deleteAnnonser(context, annons) {
     
         context.commit('removeAnnonser', annons);
     }, */
    async deleteListing(context, id) {
        await axios.delete(`https://localhost:5001/api/listings/${id}`);
        context.commit('removeListing', id);
    },
    async updateListing(context, oneListing) {
        const response = await axios.put(`https://localhost:5001/api/listings/${oneListing.id}`, oneListing);
        context.commit('updateListing', response.data);
        console.log(response.data)

    },
    async getListingById(context, listingid) {
        const response = await axios.get(`https://localhost:5001/api/listings/${listingid}`);

        console.log(response.data)
        context.commit('setListing', response.data)

    },
    async getListingsByUser(context, userid) {
        const response = await axios.get(`https://localhost:5001/api/listings/userlistings/${userid}`);
        console.log(response.data)
        context.commit('listingOwner', response.data)
    }



};


const mutations = {
    setListings: (state, listings) => (state.listings = listings),
    newListing: (state, oneListing) => state.listings.unshift(oneListing),
/*     removeAnnonser: (state, annons) => state.annonser = state.annonser.filter(annonsI => annonsI.id !== annons),
 */     removeListing: (state, id) => state.listings = state.listings.filter(listing => listing.id !== id),

    updateListing: (state, oneListing) => state.listings.forEach(upd => {
        if (upd.updListingId == oneListing.updListingId) {
            upd = oneListing
        }

    }),
    setListing: (state, oneListing) => (state.oneListing = oneListing),
    listingOwner: (state, userListing) => (state.userListing = userListing),
};

export default {
    state,
    getters,
    actions,
    mutations
};