<template>
  <div v-if="vault">
    <h1>
      Vault Title: {{ vault.name }} - {{ vault.id }} - {{ vault.creatorId }} ~~ {{ account.id }}
    </h1>
    <div>
      <div type="button" class="btn btn-secondary" @click="deleteVault(vault.id)" v-if="account.id == vault.creatorId">
        Delete Vault
      </div>
    </div>
  </div>
</template>

<script>
import { computed, watchEffect } from 'vue'
// import router from '../router'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'
import Notification from '../utils/Notification'
export default {
  setup() {
    const route = useRoute()
    watchEffect(() => {
      vaultsService.getVaultById(route.params.id)
    })
    return {
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      async deleteVault(vaultId) {
        try {
          if (await Notification.confirmAction('Are you sure you want to delete this Vault:', 'You won\'t be able to reverse this action.', 'warning', 'Yes, Delete')) {
            await vaultsService.deleteVault(vaultId)
            AppState.activeVault = null
            // FIXME Can't figure out how to get this router push to work neither one of the below pushes work.
            // router.push({ name: 'profile/' + AppState.account.id })
            // router.push({ name: 'home' })
            Notification.toast('Successfully Deleted', 'success')
          }
        } catch (error) {
          Notification.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style>

</style>
