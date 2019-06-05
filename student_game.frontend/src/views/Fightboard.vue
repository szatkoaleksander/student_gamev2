<template>
  <div class="col main-content">
    <h1>FB</h1>
    <div>
      <div v-for="(statistics, key) in user" :key="key">
        {{ key }}: {{statistics}}
      </div>
    </div>
    <div id="accordion">
      <div class="card" v-for='(enemies, dungeonNumber) in orderedFight' :key="dungeonNumber">
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
              <div class="col enemy" v-for='(enemy, enemyNumber) in enemies.enemy' :key="enemyNumber">
                  <h3>HP: {{enemy.hp}}</h3>
                  <h3>Atak: {{enemy.attack}}</h3>
                  <h3>Obrona: {{enemy.defense}}</h3>
                  <button type="button" class="btn btn-dark" v-on:click="fightMethod(enemyNumber, dungeonNumber)">Fight!</button>
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
      isModalVisible: false,
      user: {
        Exp: 0,
        HP: 0,
        LVL: 0,
        Defense: 0,
        Attack: 0
      }
    }
  },
  mounted () {
    axios
      .get('http://localhost:5000/api/dungeon/getdungeon', { headers: { Authorization: 'Bearer ' + localStorage.getItem('token') } })
      .then(response => {
        this.fight = response.data
      })
      .catch(error => console.log(error))
    this.getUserData()
  },
  computed: {
    orderedFight: function () {
      return _.orderBy(this.fight, 'level')
    }
  },
  methods: {
    getUserData: function () {
      axios
        .get('http://localhost:5000/api/account/me', { headers: { Authorization: 'Bearer ' + localStorage.getItem('token') } })
        .then(response => {
          this.user.Exp = response.data.exp
          this.user.HP = response.data.hp
          this.user.LVL = response.data.lvl
          this.user.Defense = response.data.defense
          this.user.Attack = response.data.attack
        })
        .catch(error => console.log(error))
    },
    fightMethod: function (enemyNumber, dungeonNumber) {
      axios
        .post('http://localhost:5000/api/tournament/battlewithbot', {
          dungeon: dungeonNumber,
          enemy: enemyNumber
        },
        {
          headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token')
          }
        }
        )
        .then((response) => {
          this.getUserData()
          console.log(response)
          if (response.data === 1) {
            alert('Wygranko')
          } else {
            alert('Przegranko')
          }
        })
        .catch(function (error) {
          console.log(error)
        })
    }
  }
}
</script>
