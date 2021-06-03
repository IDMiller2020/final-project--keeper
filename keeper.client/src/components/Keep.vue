<template>
  <div class="col-md-3 px-md-4 px-2 col-6 d-flex flex-column align-items-center justify-content-center">
    <div class="card bg-dark text-white my-md-4 my-2" @click="setActiveKeep(keep.id)" data-toggle="modal" data-target="#keepModal">
      <img :src="keep.img" class="card-img" alt="keep image">
      <div class="card-img-overlay d-flex justify-content-between align-items-end">
        <h5 class="card-title">
          {{ keep.name }}
        </h5>
        <div class="user-icon">
          <img class="rounded-circle" :src="keep.creator.picture" alt="keep creator picture" height="50">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import { computed, reactive } from 'vue'
// import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'Keep',
  props: {
    keep: {
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
      setActiveKeep(keepId) {
        keepsService.getKeepById(keepId)
      }
    }
  }
}
</script>

<style>

</style>
