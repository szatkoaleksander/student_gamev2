<template>
  <div class="register">
    <form
      id="app"
      v-on:submit.prevent="registerForm(email, nick, password)"
    >
      <div class="form-group">
        <label for="email">Adres email</label>
        <input
          type="email"
          v-model="email"
          class="form-control"
          id="email"
          placeholder="Wpisz email"
        >
      </div>
      <div class="form-group">
        <label for="nick">Nick</label>
        <input
          type="text"
          v-model="nick"
          class="form-control"
          id="nick"
          placeholder="Nick"
        >
      </div>
      <div class="form-group">
        <label for="password">Hasło</label>
        <input
          type="password"
          v-model="password"
          class="form-control"
          id="password"
          placeholder="Password"
        >
      </div>
      <button type="submit" class="btn btn-primary">Rejestracja</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      email: null,
      nick: null,
      password: null
    }
  },

  methods: {
    registerForm: function (email, nick, password) {
      axios.post('http://localhost:5000/api/account/register', {
        email: email,
        username: nick,
        password: password
      })
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
    }
  }
}

</script>

<style scoped lang="scss">
</style>
