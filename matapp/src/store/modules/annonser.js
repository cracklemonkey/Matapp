/* import axios from 'axios'; */
/* import users from './users';
 */
const state = {
    annonser: [
        {
            id: 1,
            title: "Giving tomatoes away",
            creationDate: "15/08/21",
            deadline: "17/08/21",
            isOpened: false,
            foodType: "Vegetables",
            user: "user1",
            image: "artur-rutkowski-GdTLaWamFHw-unsplash.jpeg",
/*             address: `${users[0].street}, ${users[0].zipcode}, ${users[0].city}`
 */        },
        {
            id: 2,
            title: "Giving away Yoghurts",
            creationDate: "15/08/21",
            deadline: "16/08/21",
            isOpened: false,
            foodType: "Dairy",
            user: "user2",
            image: "artur-rutkowski-GdTLaWamFHw-unsplash.jpeg",
/*             address: `${users[1].street}, ${users[1].zipcode}, ${users[1].city}`
 */        },
        {
            id: 3,
            title: "Giving away Bananas",
            creationDate: "15/08/21",
            deadline: "16/08/21",
            isOpened: false,
            foodType: "Fruits",
            user: "user1",
            image: "artur-rutkowski-GdTLaWamFHw-unsplash.jpeg",
/*             address: `${users[1].street}, ${users[1].zipcode}, ${users[1].city}`
*/        }
    ],
    annons: "",
};

const getters = {
    alleAnnonser: (state) => state.annonser,
    annons: (state) => state.annons,

};

const actions = {
    /* async fetchAnnonser(context) {
        const response = await axios.get("apilink/listing");
        context.commit('setAnnonser', response.data);
    }, */
    /*  async addAnnonser(context, posts) {
         const response = await axios.post("https://link/listing", { posts });
 
         context.commit('newAnnonser', response.data);
     }, */
    async deleteAnnonser(context, annons) {

        context.commit('removeAnnonser', annons);
    },
    /*   async deleteTodo(context, id) {
          await axios.delete(`https://dblink/listing/${id}`);
          context.commit('removeAnnonser', id);
      }, */
    /* async updateTodo(context, updAnnons) {
        const response = await axios.put(`link/listing/${updAnnons.id}`, updAnnons);
        context.commit('updateAnnonser', response.data);
        console.log(response.data)

    }, 
     async getAnnonserById(context, annonsid) {
        const response = await axios.get(`apilink/listing/${annonsid}`);

        console.log(response.data)
        context.commit('setAnnons', response.data)

    },

    */
};


const mutations = {
    setAnnonser: (state, annonser) => (state.annonser = annonser),
    newAnnonser: (state, annons) => state.annonser.unshift(annons),
    removeAnnonser: (state, annons) => state.annonser = state.annonser.filter(annonsI => annonsI.id !== annons),
    /*     removeAnnonser: (state, id) => state.annonser = state.annonser.filter(annonsI => annonsI.id !== id), */

    updateAnnonser: (state, updAnnons) => state.annonser.forEach(upd => {
        if (upd.id == updAnnons.id) {
            upd = updAnnons
        }

    }),
    setAnnons: (state, annons) => (state.annons = annons),
};

export default {
    state,
    getters,
    actions,
    mutations
};