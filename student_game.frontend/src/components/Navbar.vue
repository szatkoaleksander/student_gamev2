<template>
  <div class="navbar">
    <div class="row">
      <div class="navbar-Link-brand">
        <h1>Student Game</h1>
      </div>
      <div class="float-right nav-btn">
        <div
          class="hamburger"
          id="hamburger"
        >
          <span class="line"></span>
          <span class="line"></span>
          <span class="line"></span>
        </div>
      </div>
    </div>
    <script type="application/javascript">
    function classToggle() {
      var navs = document.querySelectorAll(".navbar-Items");
      navs.forEach(nav => nav.classList.toggle("navbar-ToggleShow"));
      document.querySelector(".hamburger").classList.toggle("is-active");
    }
    document.querySelector(".nav-btn").addEventListener("click", classToggle);
    </script>
  </div>

</template>

<script>
</script>
