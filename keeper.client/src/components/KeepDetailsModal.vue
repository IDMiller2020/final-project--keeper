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
          <button type="button" class="btn btn-secondary" v-if="state.account.id === state.activeKeep.creatorId">
            Delete
          </button>
          <button type="button" class="btn btn-primary">
            Add To Vault
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
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
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account)
    })
    return {
      state
    }
  }
}
</script>

<style>

</style>
