<template>
  <div class="col-md-3 col-6 px-md-4 px-2 d-flex flex-column align-items-center justify-content-center">
    <div class="card bg-dark text-white my-md-4 my-2" @click="setActiveKeep(keep.id)" data-toggle="modal" data-target="#keepModal">
      <img :src="keep.img" class="card-img" alt="keep image">
      <div class="card-img-overlay d-flex justify-content-between align-items-end">
        <div v-if="state.activeVault">
          <button type="button" class="btn btn-danger btn-sm" @click="deleteVaultKeep(keep.vaultKeepId)" v-if="state.account.id == state.activeVault.creatorId">
            D
          </button>
        </div>
        <h5 class="card-title">
          {{ keep.name }}
        </h5>
        <div class="user-icon">
          <router-link :to="{name: 'Profile', params: {id: keep.creatorId}}" @click.stop="">
            <img class="rounded-circle" :src="keep.creator.picture" alt="keep creator picture" height="50">
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'Keep',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
      account: computed(() => AppState.account),
      activeVault: computed(() => AppState.activeVault)
    })
    return {
      state,
      setActiveKeep(keepId) {
        keepsService.getKeepById(keepId)
        vaultsService.getProfileVaults(state.account.id)
      },
      deleteVaultKeep(vaultKeepId) {
        vaultsService.deleteVaultKeep(vaultKeepId)
      }
    }
  }
}
</script>

<style>

</style>
