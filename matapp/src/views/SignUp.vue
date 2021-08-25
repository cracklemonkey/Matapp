<template>
  <div class="signup">
          <div class="signup-screen">
            <div class="app-title">
              <h1>Sign up</h1>
            </div>

            <form @submit.prevent="submit">
              <div class="control-group">
              <input type="text" name="username" class="signup-field"  placeholder="username" v-model="form.username">
              </div>

              <div class="control-group">
                <input type="text"  name="email" class="signup-field"  placeholder="email" v-model="form.email">
                </div>

              <div class="control-group">
              <input type="password" name="password" class="signup-field" placeholder="password" v-model="form.password">
              </div>

              <button type="submit" class="btn btn-primary btn-large btn-block" href="#">Submit</button>
            </form>
              <p>Already a member? <a href="#" class="blue"></a><span class="fontawesome-arrow-right"></span>
              <router-link to="/loggin">Log in now</router-link>
              </p>
          </div>
            <p v-if="showError" id="error">Username already exists</p>
        </div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  name: 'SignUp',
  components: {},
  data () {
    return {
      form: {
        username: '',
        email: '',
        password: ''
      },
      showError: false
    }
  },
  methods: {
    ...mapActions(['SignUp']),
    async submit () {
      try {
        await this.SignUp(this.form)
        this.$router.push('/home')
        this.showError = false
      } catch (error) {
        this.showError = true
      }
    }
  }
}
</script>

<style>

* {
    box-sizing: border-box;
    }

    *:focus {
      outline: none;
    }
    body {
    font-family: Arial;
    background-color: #fafafa;
    padding: 50px;
    }
    .signup {
    margin: 20px auto;
    width: 300px;
    }
    .signup-screen {
  background-color: rgb(99, 203, 211);
    padding: 20px;
    border-radius: 5px
    }

    .app-title {
    text-align: center;
    color: #3498DB;
    }

    .signup-form {
    text-align: center;
    }
    .control-group {
    margin-bottom: 10px;
    }

    input {
    text-align: center;
    background-color: #c0cacc;
    border: 2px solid transparent;
    border-radius: 3px;
    font-size: 16px;
    font-weight: 200;
    padding: 10px 0;
    width: 250px;
    transition: border .5s;
    }

    input:focus {
    border: 2px solid #3498DB;
    box-shadow: none;
    }

    .btn {
      border: 2px solid transparent;
      background: #3498DB;
      color: #ffffff;
      font-size: 16px;
      line-height: 25px;
      padding: 10px 0;
      text-decoration: none;
      text-shadow: none;
      border-radius: 3px;
      box-shadow: none;
      transition: 0.25s;
      display: block;
      width: 250px;
      margin: 0 auto;
    }

    .btn:hover {
      background-color: #2980B9;
    }

    .signup-link {
      font-size: 12px;
      color: #444;
      display: block;
      margin-top: 12px;
    }
</style>
