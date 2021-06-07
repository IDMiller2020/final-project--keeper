<template>
  <!-- Modal -->
  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Keep Details
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="row modal-body" v-if="state.activeKeep">
          <div class="col-6">
            <img :src="state.activeKeep.img" alt="keep image" width="200">
          </div>
          <div class="col-6 d-flex flex-column align-items-start">
            <h3 class="keep-title">
              {{ state.activeKeep.name }}
            </h3>
            <h5 class="keep-description">
              {{ state.activeKeep.description }}
            </h5>
            <div class="user-icon d-flex flex-row" v-if="state.activeKeep.creator">
              <img class="rounded-circle" :src="state.activeKeep.creator.picture" alt="keep creator picture" height="30">
              <p class="pl-2">
                {{ state.activeKeep.creator.name }}
              </p>
            </div>
            <div class="keeps-count">
              <p>
                Keeps: {{ state.activeKeep.keeps }}
              </p>
            </div>
            <div class="views-count">
              <p>
                Views: {{ state.activeKeep.views }}
              </p>
            </div>
            <div class="shares-count">
              <p>
                Shares: {{ state.activeKeep.shares }}
              </p>
            </div>
          </div>
        </div>
        <div class="modal-footer" v-if="state.activeKeep">
          <!-- FIXME After delete an empty modal stays on the page.  Should go back to home page without having to close the modal. -->
          <button type="button" class="btn btn-secondary" v-if="state.account.id === state.activeKeep.creatorId" @click="deleteKeep(state.activeKeep.id)" data-dismiss="modal">
            Delete
          </button>

          <div class="btn-group">
            <button type="button" class="btn btn-primary">
              Add To Vault
            </button>
            <button type="button" class="btn btn-primary dropdown-toggle dropdown-toggle-split" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              <span class="sr-only">Toggle Dropdown</span>
            </button>
            <div class="dropdown-menu">
              <a class="dropdown-item"
                 v-for="v in state.profileVaults"
                 :key="v.id"
                 :vault-prop="v"
                 @click.prevent="createVaultKeep(v.id, state.activeKeep.id)"
              >{{ v.name }}</a>
            </div>
          </div>

          <!-- <button type="button" class="btn btn-primary" v-if="state.user">
            Add To Vault
          </button> -->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import router from '../router'
import Notification from '../utils/Notification'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'KeepDetailsModal',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
      newVaultKeep: {},
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      profileVaults: computed(() => AppState.profileVaults)
    })
    return {
      state,
      async deleteKeep(keepId) {
        try {
          if (await Notification.confirmAction('Are you sure you want to delete this keep?', 'You won\'t be able to reverse this action.', 'warning', 'Yes, Delete')) {
            await keepsService.deleteKeep(keepId)
            AppState.activeKeep = null
            router.push({ name: 'Home' })
            Notification.toast('Successfully Deleted', 'success')
          }
        } catch (error) {
          Notification.toast(error, 'error')
        }
      },
      async createVaultKeep(vaultId, keepId) {
        try {
          await vaultsService.createVaultKeep(vaultId, keepId)
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
