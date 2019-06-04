<template>
  <div class="container-fluid">
    <Navbar />
    <div class="row">
      <div class="col-2">
        <Sidebar></Sidebar>
      </div>
      <div class="col">
        <router-view></router-view>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
import Sidebar from '@/components/Sidebar.vue'

export default {
  name: 'Dashboard',
  components: {
    Navbar,
    Sidebar
  },

  data () {
    return {}
  }
}
</script>
