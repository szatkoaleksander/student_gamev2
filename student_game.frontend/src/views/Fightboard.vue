<template>
  <div class="col main-content">
    <h1>FB</h1>
    <div id="accordion">
      <div class="card" v-for='enemies in orderedFight'>
        <div class="card-header" id="headingOne">
          <h5 class="mb-0">
            <button class="btn btn-link" data-toggle="collapse" :data-target="'#collapse'+enemies.level" aria-expanded="true" v-bind:aria-controls="enemies.level">
              Dungeon {{ enemies.level }}
            </button>
          </h5>
        </div>

        <div :id="'collapse' + enemies.level" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
          <div class="card-body">
            <div class="row">
              <div class="col enemie" v-for='enemi in enemies.enemy'>
                  <h3>HP: {{enemi.hp}}</h3>
                  <h3>Atak: {{enemi.attack}}</h3>
                  <h3>Obrona: {{enemi.defense}}</h3>
                  <button type="button" class="btn btn-dark" v-on:click="fightMethod('1', '1')">Walcz!</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import _ from 'lodash'

export default {
  data () {
    return {
      fight: 'a',
      token: localStorage.getItem('token'),
      enemiID: null,
      dungeonID: null,
      isModalVisible: false,
    }
  },
  mounted () {
    axios
      .get('http://localhost:5000/api/dungeon/getdungeon', { headers: { Authorization: 'Bearer ' + localStorage.getItem('token') } })
      .then(response => {
        this.fight = response.data;

      })
      .catch(error => console.log(error))
  },
  computed: {
    orderedFight: function () {
      return _.orderBy(this.fight, 'level')
    }
  },
  methods: {
    fightMethod: function (enemiID, dungeonID) {
      axios
        .post('http://localhost:5000/api/tournament/battlewithbot', {
            'Dungeon': dungeonID,
            'Enemy': enemiID,
          },
          {
          headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token')
            }
          }
        )
        .then((response) => {
          console.log(response)
          if(response.data==1){
            alert("Wygranko")
          }
          else {
            alert("Przegranko")
          }
        })
        .catch(function (error) {
          console.log(error)
        })
    }
  }
}
</script>
