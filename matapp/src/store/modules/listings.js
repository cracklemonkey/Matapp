import axios from 'axios';
/* import users from './users';
 */
const state = {
    listings: [],
    oneListing: "",
    userListing: [],
    images: [],
    oneImage: ""
};

const getters = {
    allListings: (state) => state.listings,

    oneListing: (state) => state.oneListing,
    userListing: (state) => state.userListing,
    oneImage: (state) => state.oneImage

};

const actions = {
    async getListings(context) {
        const response = await axios.get("https://localhost:5001/api/listings");

        context.commit('setListings', response.data);
    },

    async getImages(context) {
        const response = await axios.get(`https://localhost:5001/api/image`);
        console.log(response)
        context.commit('setImages', response.data)
    },

    async getImage(context, name) {
        const response = await axios.get(`https://localhost:5001/api/image/${name}`);
        context.commit('setImage', response.data)
    },

    async addImage(context, fd) {
        const response = await axios.post(`https://localhost:5001/api/image`, fd)
        
        console.log(response.data);
        context.commit('newImage', response.data);
        return response.data;
        
    },
    async deleteImage(context, name) {
        console.log("inside del", name)
        await axios.delete(`https://localhost:5001/api/image/${name}`);
        context.commit('removeImage', name);
    },

    async addListing(context, posts) {
        const response = await axios.post(`https://localhost:5001/api/listings`, posts)
        console.log(response.data);
        console.log(posts)
        context.commit('newListing', response.data);
    },
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

        console.log(response)
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
        setImages: (state, images) => (state.images = images),
        newListing: (state, oneListing) => state.listings.unshift(oneListing),
        newImage: (state, oneImage) => state.images.push(oneImage),
        removeListing: (state, id) => state.listings = state.listings.filter(listing => listing.id !== id),
        removeImage: (state, name) => state.images = state.images.filter(image => image.name !== name),
        updateListing: (state, oneListing) => state.listings.forEach(upd => {
            if (upd.updListingId == oneListing.updListingId) {
                upd = oneListing
            }
        }),
        setImage: (state, oneImage) => (state.oneImage = oneImage),
        setListing: (state, oneListing) => (state.oneListing = oneListing),
        listingOwner: (state, userListing) => (state.userListing = userListing),
    };

    export default {
        state,
        getters,
        actions,
        mutations
    };