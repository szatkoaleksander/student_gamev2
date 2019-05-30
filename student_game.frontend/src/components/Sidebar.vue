<template>
  <nav class="navbar-Items">
    <div class>
      <h1>Akcje</h1>
    </div>


        <router-link
      class="btn btn-info btn-block"
      to="home"
    >Home</router-link>
            <router-link
      class="btn btn-info btn-block"
      to="fightboard"
    >Fightboard</router-link>
        <router-link
      class="btn btn-info btn-block"
      to="shopboard"
    >Shop</router-link>


    <i
      class="fa fa-gear fa-spin"
      style="font-size:24px"
    ></i>

    <Modal
      v-show="isModalVisible"
      @close="closeModal"
    />
  </nav>

</template>

<script>
import Modal from '@/components/Modal.vue'

export default {
  name: 'sidebar',

  methods: {

  }
}
</script>
