<template>
  <div class="col main-content">
    <h1>Shop</h1>
    <h2>Pozostałe pieniądze: {{ money }}</h2>
    <div id="accordion">
      <div class="card" v-for='item in shop'>
        <div class="card-header" id="headingOne">
          <h5 class="mb-0">
            <button class="btn btn-link" data-toggle="collapse" :data-target="'#collapse'+item.id" aria-expanded="true" v-bind:aria-controls="item.id">
              {{ item.name }}
            </button>
          </h5>
        </div>

        <div :id="'collapse' + item.id" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
          <div class="card-body">
            <h3>Opis: {{ item.description }}</h3>
            <h3>Cena: {{ item.price }}</h3>
            <button type="button" class="btn btn-dark" v-on:click="buyItem(item.id)">Buy!</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import axios from 'axios'
export default {
  data () {
    return {
      token: localStorage.getItem('token'),
      money: 0,
      shop: null,
    }
  },
  mounted () {
    axios
      .get('http://localhost:5000/api/shop/get', { headers: { Authorization: 'Bearer ' + localStorage.getItem('token') } })
      .then(response => {
        this.shop = response.data
      })
      .catch(error => console.log(error))
    this.getMoney()
  },
  methods: {
    getMoney: function() {
      axios
      .get('http://localhost:5000/api/account/me', { headers: { Authorization: 'Bearer ' + localStorage.getItem('token') } })
      .then(response => {
        this.money = response.data.money
      })
      .catch(error => console.log(error))
    },
    buyItem: function (productID) {
      axios
        .post('http://localhost:5000/api/shop/buy', {
            productId: productID
          },
          {
          headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token')
            }
          }
        )
        .then((response) => {
          alert("Kupiono")
          this.getMoney()
        })
        .catch(function (error) {
          console.log(error)
        })
    }
  }
}
</script>

