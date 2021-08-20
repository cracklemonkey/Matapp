import axios from 'axios'

const state = {
    user: ""
};

const getters = {
    isAuthenticated: (state) => !!state.user,
    StateUser: (state) => state.user
};

const actions = {
    async LoggIn ({ commit }, user) {
        await axios.post('loggin', user)
        await commit('setUser', user.get('username'))
      },
    

      async SignUp ({ dispatch }, form) {
        await axios.post('register', form)
        const UserForm = new FormData()
        UserForm.append('username', form.username)
        UserForm.append('password', form.password)
        await dispatch('LoggIn', UserForm)
      },


      async logout ({ commit }) {
        const user = null
        commit('logout', user)
      }
};


const mutations = {
    setuser (state, username) {
        state.user = username
      },
    
      logout (state, user) {
        state.user = user
      }
} 

export default {
    state,
    getters,
    actions,
    mutations
  }
  