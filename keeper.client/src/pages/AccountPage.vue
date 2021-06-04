<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <div class="about text-center">
          <h1>Welcome {{ account.name }}</h1>
          <img class="rounded" :src="account.picture" alt="" />
          <p>{{ account.email }}</p>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h2>Create A Keep</h2>
        <form @submit.prevent="createKeep">
          <div class="form-group">
            <label for="keepTitle">Keep Title</label>
            <input type="title" class="form-control" id="keepTitleInput" aria-describedby="keepTitle" v-model="state.newKeep.name">
          </div>
          <div class="form-group">
            <label for="keepImageUrl">Image Url</label>
            <input type="imageUrl" class="form-control" id="imageUrlInput" v-model="state.newKeep.img">
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <textarea class="form-control" id="description" rows="3" v-model="state.newKeep.description"></textarea>
          </div>
          <button type="submit" class="btn btn-primary">
            Create
          </button>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h2>Add A Vault</h2>
        <form @submit.prevent="createVault">
          <div class="form-group">
            <label for="vaultTitle">Vault Title</label>
            <input type="title" class="form-control" id="vaultTitleInput" aria-describedby="vaultTitle" v-model="state.newVault.name">
          </div>
          <div class="form-group">
            <label for="vaultImageUrl">Image Url</label>
            <input type="imageUrl" class="form-control" id="imageUrlInput" v-model="state.newVault.img">
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <textarea class="form-control" id="description" rows="3" v-model="state.newVault.description"></textarea>
          </div>
          <button type="submit" class="btn btn-primary">
            Create
          </button>
        </form>
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
  name: 'Account',
  setup() {
    const state = reactive({
      newKeep: {},
      newVault: {}
    })
    return {
      state,
      account: computed(() => AppState.account),
      async createKeep() {
        try {
          await keepsService.createKeep(state.newKeep)
          state.newKeep = {}
        } catch (error) {
          console.error(error)
        }
      },
      async createVault() {
        try {
          await vaultsService.createVault(state.newVault)
          state.newVault = {}
        } catch (error) {
          console.error(error)
        }
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
