<template>
    <div id="main">
      <div class="container">
        <div id="login-register-div">
          <ul class="nav nav-pills nav-fill" id="pills-tab" role="tablist">
            <li class="nav-item">
              <a class="nav-link teal-text active" id="pills-home-tab" data-toggle="pill" href="#login" role="tab" aria-controls="login" aria-selected="true">Logowanie</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" id="pills-profile-tab" data-toggle="pill" href="#register" role="tab" aria-controls="register" aria-selected="false">Rejestracja</a>
            </li>
          </ul>
          <div class="tab-content" id="nav-tabContent">
            <div class="tab-pane fade show active" id="login" role="tabpanel" aria-labelledby="login-list"><Login /></div>
            <div class="tab-pane fade" id="register" role="tabpanel" aria-labelledby="register-list"><Register /></div>
          </div>
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
