<template>
    <div>
      <login />
      <Register />
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

  data() {
    return {

    }
  }
}
</script>

<style>

</style>
