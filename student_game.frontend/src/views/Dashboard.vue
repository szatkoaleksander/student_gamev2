<template>
  <div class="container-fluid">
    <Navbar />
    <div class="row">
        <Sidebar></Sidebar>
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
