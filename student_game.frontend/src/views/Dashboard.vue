<template>
  <div class="container-fluid">
    <Navbar />
    <div class="row">
      <Sidebar />
      <MainContent />
    </div>
    <script type="application/javascript">
    function classToggle() {
      var navs = document.querySelectorAll(".Navbar-Items");
      navs.forEach(nav => nav.classList.toggle("Navbar-ToggleShow"));
      document.querySelector(".hamburger").classList.toggle("is-active");
    }
    document.querySelector(".Nav-btn").addEventListener("click", classToggle);
    </script>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue'
import Sidebar from '@/components/Sidebar.vue'
import MainContent from '@/components/MainContent.vue'

export default {
  name: 'Dashboard',
  components: {
    Navbar,
    Sidebar,
    MainContent
  },

  data () {
    return {}
  }
}
</script>
