<template>
    <div id="main">
      <div id="container">
          <div class="list-group" id="list-tab" role="tablist">
            <a class="list-group-item list-group-item-action active" id="login-list" data-toggle="list" href="#login" role="tab" aria-controls="login">Logowanie</a>
            <a class="list-group-item list-group-item-action" id="register-list" data-toggle="list" href="#register" role="tab" aria-controls="register">Rejestracja</a>
          </div>
          <div class="tab-content" id="nav-tabContent">
            <div class="tab-pane fade show active" id="login" role="tabpanel" aria-labelledby="login-list"><Login /></div>
            <div class="tab-pane fade" id="register" role="tabpanel" aria-labelledby="register-list"><Register /></div>
          </div>
      </div>
    </div>
</template>

<script>
import Login from '@/components/Login.vue'
import Register from '@/components/Register.vue'

export default {
  name: 'Main',
  components: {
    Login,
    Register
  },

  data () {
    return {

    }
  }
}
</script>

<style>

</style>
