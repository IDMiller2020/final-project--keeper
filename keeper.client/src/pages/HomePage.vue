<template>
  <div class="home row flex-grow-1">
    <div class="col d-flex flex-column align-items-center justify-content-center">
      <p>keeps go here</p>
      <Keep :keep="keep" v-for="keep in state.keeps" :key="keep.id" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      keep: computed(() => AppState.keeps)
    })
    onMounted(async() => {
      try {
        debugger
        await keepsService.getKeeps()
      } catch (error) {
        console.error(error)
      }
    })
    return {
      state
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
