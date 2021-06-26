<template>
  <div class="container-fluid">
    <div class="row mt-4">
      <div class="col-12">
        <h2>Profile Page</h2>
      </div>
    </div>
    <div class="row my-4">
      <div class="col-2">
        <img :src="profile.picture" alt="profile picture" height="100">
      </div>
      <div class="col-10">
        <div>
          <p class="m-0">
            Profile Name: {{ profile.name }}
          </p>
        </div>
        <div>
          <p class="m-0">
            Profile Vaults: {{ vaults.length }}
          </p>
        </div>
        <div>
          <p class="m-0">
            Profile Keeps: {{ keeps.length }}
          </p>
        </div>
      </div>
    </div>
    <div class="row">
      <h3>
        Vaults:
      </h3>
    </div>
    <div class="row mb-4">
      <Vault :vault="vault" v-for="vault in vaults" :key="vault.id" />
    </div>
    <div class="row">
      <h3>
        Keeps:
      </h3>
    </div>
    <div class="row mb-4">
      <Keep :keep="keep" v-for="keep in keeps" :key="keep.id" />
    </div>
    <KeepDetailsModal />
  </div>
</template>

<script>
import { computed, reactive, watchEffect } from 'vue'
import { useRoute } from 'vue-router'
import { profilesService } from '../services/ProfilesService'
import { AppState } from '../AppState'
export default {
  name: 'Profile',
  setup() {
    const route = useRoute()
    watchEffect(() => {
      profilesService.getProfile(route.params.id)
      profilesService.getKeepsByProfile(route.params.id)
      profilesService.getVaultsByProfile(route.params.id)
    })
    return reactive({
      keeps: computed(() => AppState.profileKeeps),
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.profileVaults),
      account: computed(() => AppState.account)
    })
  }
}
</script>

<style>

</style>
