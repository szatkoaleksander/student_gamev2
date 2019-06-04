<template>
  <div class='login'>
    <form
      id='login'
      v-on:submit.prevent='loginForm(email, password)'
    >
      <div class='form-group'>
        <label for='email'>Adres email</label>
        <input
          type='email'
          v-model='email'
          class='form-control'
          id='email'
          placeholder='Wpisz email'
        >
      </div>
      <div class='form-group'>
        <label for='password'>Hasło</label>
        <input
          type='password'
          v-model='password'
          class='form-control'
          id='password'
          placeholder='Password'
        >
      </div>
      <button
        type='submit'
        class='btn btn-primary'
      >Logowanie</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'Login',
  props: {},

  data () {
    return {
      email: null,
      password: null
    }
  },
  methods: {
    loginForm: function (email, password) {
      axios
        .post('http://localhost:5000/api/account/login', {
          email: email,
          password: password
        })
        .then((response) => {
          localStorage.setItem('token', response.data);
          this.$router.push({ name: 'Dashboard' })
        })
        .catch(function (error) {
          console.log(error)
        })
    }
  }
}
</script>

<!-- Add 'scoped' attribute to limit CSS to this component only -->
<style scoped lang='scss'>
</style>
