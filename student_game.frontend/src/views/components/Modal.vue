<template>
  <div class="modal-mask">
    <div class="container">

      <div class="modal-wrapper">
        <div>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur finibus scelerisque dui vel convallis. Nullam mollis nunc nec finibus luctus. Pellentesque laoreet ligula vel erat tincidunt, vel imperdiet odio suscipit. Fusce eleifend faucibus lacinia. Cras laoreet tellus eu nisi consequat rhoncus. Donec pellentesque pretium eleifend. Maecenas pretium molestie neque, eget lacinia purus facilisis ut. Aliquam erat volutpat. Proin id ligula eget mi feugiat lobortis ornare non tortor. Integer turpis est, auctor ac gravida at, tempor eu nunc. Etiam dui dolor, cursus ut accumsan eu, posuere vitae lacus. Vivamus malesuada rhoncus consequat. Quisque eu lorem pretium nulla ullamcorper interdum eu eu sapien. Mauris ac velit quis est luctus ullamcorper sed in neque.
        </div>
        <button
          class="modal-button"
          @click="close"
        >
          OK
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Modal',
  methods: {
    close () {
      this.$emit('close')
    }
  }
}
</script>

<style>
</style>
