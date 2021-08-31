import axios from 'axios';


const state = {
    users: [],
    oneUser: ""
};

const getters = {
    allUsers: (state) => state.users
};

const actions = {
    async getUsers(context) {
        const response = await state.users;
        context.commit('setUsers', response);
    },
    async getUserById(context, userid) {
        const response = await axios.get(`https://localhost:5001/api/users/${userid}`);

        console.log(response.data)
        context.commit('setUser', response.data)

    },
    async deleteUser(context, id) {
        await axios.delete(`https://localhost:5001/api/users/${id}`);
        context.commit('removeUser', id);
    },
    async updateUser(context, updUser) {
        const response = await axios.put(`https://localhost:5001/api/users/${updUser}`);
        context.commit('updateUser', response.data)
    }



};

const mutations = {
    setUsers: (state, users) => (state.users = users),
    removeUser: (state, id) => state.users = state.users.filter(user => user.id !== id),
    newUser: (state, user) => state.users.push(user),
    setUser: (state, oneUser) => (state.oneUser = oneUser),

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