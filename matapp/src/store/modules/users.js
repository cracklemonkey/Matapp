/* import axios from 'axios'; */


const state = {
    users: [
        {
            id: 1,
            username: "Jerry",
            password: "1234",
            email: "iamjerry@gmail.com",
            number: "43215698",
            street: "Torgata 45",
            city: "Oslo",
            country: "Norway",
            zipcode: "0186",


        },


    ]
};

const getters = {
    allUsers: (state) => state.users
};

const actions = {
    async fetchUsers(context) {
        const response = await state.users;
        context.commit('setUsers', response);
    },
    /*  async deleteUser(context, id) {
         await axios.delete(`http://link/${id}`);
         context.commit('removeUser', id);
     }, 
     async updateUser(context, id){
         const response = await axios.put(`http://link/profile/`);
         context.commit('updateUser', id)
     }
     */


};

const mutations = {
    setUsers: (state, users) => (state.users = users),
    removeUser: (state, id) => state.users = state.users.filter(user => user.id !== id),
    newUser: (state, user) => state.users.push(user),
    updateUser: (state, updUser) => state.users.forEach(upd => {
        if (upd.id == updUser.id) {
            upd = updUser
        }

    }),

};

export default {
    state,
    getters,
    actions,
    mutations
};