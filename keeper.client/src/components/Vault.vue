<template>
  <div class="col-md-3 col-6 px-md-4 px-2 d-flex flex-column align-items-center justify-content-center">
    <router-link :to="{name: 'Vault', params: {id: vault.id}}">
      <div class="card bg-dark text-white my-md-4 my-2" @click="setActiveVault(vault.id)">
        <!-- <img :src="vault.img" class="card-img" alt="vault image" v-if="vault.img">
      <img src="https://source.unsplash.com/200x250/?nature" alt="generic image" v-else> -->
        <div id="vaultImageContainer">
          <img :src="vault.img" class="card-img" alt="vault image">
        </div>
        <div class="card-img-overlay d-flex justify-content-between align-items-end">
          <h5 class="card-title">
            {{ vault.name }}
          </h5>
          <div class="user-icon">
            <img class="rounded-circle" :src="vault.creator.picture" alt="vault creator picture" height="50">
          </div>
        </div>
      </div>
    </router-link>
  </div>
</template>

<script>
// import { computed, reactive } from 'vue'
// import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'Vault',
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup() {
    // const state = reactive({
    //   keep: computed(() => AppState.activeKeep)
    // })
    return {
      // state,
      setActiveVault(vaultId) {
        vaultsService.getVaultById(vaultId)
      }
    }
  }
}
</script>
<style>
#vaultImageContainer {
  width: 100%;
}

#vaultImageContainer img {
  height: 400px;
  object-fit: cover;
}

</style>
