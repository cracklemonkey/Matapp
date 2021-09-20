import axios from 'axios';

const state = {
    listings: [],
    oneListing: "",
    userListing: [],
    images: [],
    oneImage: "",
    foodTypes: [],
    oneFoodType: "",
    allergies: [],
    oneAllergie: "",
    fullListing: [],
    oneFullListing: "",
    setOfAllergies: [],
    setOfFoodTypes: []
};

const getters = {
    allListings: (state) => state.listings,
    allFoodTypes: (state) => state.foodTypes,
    allAllergies: (state) => state.allergies,
    oneListing: (state) => state.oneListing,
    oneAllergie: (state) => state.oneAllergie,
    oneFoodType: (state) => state.oneFoodType,
    userListing: (state) => state.userListing,
    oneImage: (state) => state.oneImage,
/*     allFullListings: (state) => state.fullListing,
 */    oneFullListing: (state) => state.oneFullListing,

    setOfAllergies: (state) => state.setOfAllergies,
    setOfFoodTypes: (state) => state.setOfFoodTypes

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
    async getFoodTypes(context) {
        const response = await axios.get("https://localhost:5001/api/foodtypes");

        context.commit('setFoodTypes', response.data);
    },
    async getAllergies(context) {
        const response = await axios.get("https://localhost:5001/api/allergies");

        context.commit('setAllergies', response.data);
    },
    async getListingAllergies(context) {
        const response = await axios.get("https://localhost:5001/api/listingallergies");

        context.commit('setAllergies', response.data);
    },
    async getListingFT(context) {
        const response = await axios.get("https://localhost:5001/api/listinfoodtypes");

        context.commit('setFoodTypes', response.data);
    },
    async getFTByListingId(context, id) {
        const response = await axios.get(`https://localhost:5001/api/foodtypes/foodtypesbylistingid/${id}`);

        context.commit('setOfFoodTypes', response.data);
    },
    async getAllergiesByListingId(context, id) {
        const response = await axios.get(`https://localhost:5001/api/allergies/allergiesbylistingid/${id}`);

        context.commit('setOfAllergies', response.data);
    },
    async getAllColumns(context) {
        const response = await axios.get(`https://localhost:5001/api/getallcolumns`);

        context.commit('setAllColumns', response.data);
    },


    async addImage(context, fd) {
        const response = await axios.post(`https://localhost:5001/api/image`, fd)

        console.log(response.data);
        context.commit('newImage', response.data);
        return response.data;

    },

    async addListing(context, posts) {
        const response = await axios.post(`https://localhost:5001/api/listings`, posts)
        console.log(response.data);
        console.log(posts)
        context.commit('newListing', response.data);
        return response.data
    },
    async addFoodType(context, postType) {
        const response = await axios.post(`https://localhost:5001/api/listingfoodtypes`, postType)
        console.log(response);
        console.log(postType)
        context.commit('newFoodType', response.data);
    },
    async addAllergies(context, postAllergies) {
        const response = await axios.post(`https://localhost:5001/api/listingallergies`, postAllergies)
        console.log(response);
        console.log(postAllergies)
        context.commit('newAllergies', response.data);
    },
    async deleteListing(context, id) {
        await axios.delete(`https://localhost:5001/api/listings/${id}`);
        context.commit('removeListing', id);
    },

    async deleteImage(context, name) {
        console.log("inside del", name)
        await axios.delete(`https://localhost:5001/api/image/${name}`);
        context.commit('removeImage', name);
    },

    async deleteFoodType(context, id) {
        await axios.delete(`https://localhost:5001/api/listingfoodtypes/${id}`);
        context.commit('removeFoodType', id);
    },
    async deleteAllergie(context, id) {
        await axios.delete(`https://localhost:5001/api/listingallergies/${id}`);
        context.commit('removeAllergie', id);
    },
    async updateListing(context, oneListing) {
        const response = await axios.put(`https://localhost:5001/api/listings/${oneListing.id}`, oneListing);
        context.commit('updateListing', response.data);
        console.log(response.data)

    },
    async updateAllergie(context, oneAllergie) {
        const response = await axios.put(`https://localhost:5001/api/listingallergies/${oneAllergie.id}`, oneAllergie);
        context.commit('updateAllergie', response.data);
        console.log(response.data)

    },
    async updateFoodType(context, oneFoodType) {
        const response = await axios.put(`https://localhost:5001/api/listingfoodtypes/${oneFoodType.id}`, oneFoodType);
        context.commit('updateFoodType', response.data);
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
    setFoodTypes: (state, foodTypes) => (state.foodTypes = foodTypes),
    setAllergies: (state, allergies) => (state.allergies = allergies),
    setOfAllergies: (state, setOfAllergies) => (state.setOfAllergies = setOfAllergies),
    setOfFoodTypes: (state, setOfFoodTypes) => (state.setOfFoodTypes = setOfFoodTypes),
    setAllColumns: (state, oneFullListing) => (state.oneFullListing = oneFullListing),
    setImages: (state, images) => (state.images = images),
    newListing: (state, oneListing) => state.listings.unshift(oneListing),
    newFoodType: (state, oneFoodType) => state.foodTypes.push(oneFoodType),
    newAllergies: (state, oneAllergie) => state.allergies.push(oneAllergie),
    newImage: (state, oneImage) => state.images.push(oneImage),
    removeListing: (state, id) => state.listings = state.listings.filter(listing => listing.id !== id),
    removeImage: (state, name) => state.images = state.images.filter(oneImage => oneImage.name !== name),
    removeFoodtype: (state, id) => state.foodTypes = state.foodTypes.filter(foodtype => foodtype.id !== id),
    removeAllergie: (state, id) => state.allergies = state.allergies.filter(allergie => allergie.id !== id),
    updateListing: (state, oneListing) => state.listings.forEach(upd => {
        if (upd.updListingId == oneListing.updListingId) {
            upd = oneListing
        }
    }),
    updateAllergie: (state, oneAllergie) => state.allergies.forEach(upd => {
        if (upd.updAllergieId == oneAllergie.updAllergieId) {
            upd = oneAllergie
        }
    }),
    updateFoodType: (state, oneFoodType) => state.foodTypes.forEach(upd => {
        if (upd.updFoodTypeId == oneFoodType.updFoodTypeId) {
            upd = oneFoodType
        }
    }),
    setImage: (state, oneImage) => (state.oneImage = oneImage),
    setListing: (state, oneListing) => (state.oneListing = oneListing),
    setFoodType: (state, oneFoodType) => (state.oneFoodType = oneFoodType),
    setAllergie: (state, oneAllergie) => (state.oneAllergie = oneAllergie),
    listingOwner: (state, userListing) => (state.userListing = userListing),
};

export default {
    state,
    getters,
    actions,
    mutations
};
