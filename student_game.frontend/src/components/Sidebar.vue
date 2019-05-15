<template>
  <nav class="navbar-Items">
    <div class>
      <h1>Akcje</h1>
    </div>
    <button
      type="button"
      class="btn btn-info btn-block"
      @click="showModal"
    >
      Walka
    </button>

    <button
      type="button"
      class="btn btn-info btn-block"
      @click="showModal"
    >
      Piwo
    </button>

    <button
      type="button"
      class="btn btn-info btn-block"
      @click="showModal"
    >
      Sklep
    </button>

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
  name: 'app',
  components: {
    Modal
  },

  data () {
    return {
      isModalVisible: false
    }
  },

  methods: {
    showModal () {
      this.isModalVisible = true
    },
    closeModal () {
      this.isModalVisible = false
    }
  }
}
</script>
