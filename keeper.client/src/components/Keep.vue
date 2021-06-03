<template>
  <div class="card shadow">
    <img class="card-img-top" :src="keep.img" alt="keep image">
    <div class="card-body d-flex justify-content-between align-items-center">
      <p class="card-title m-0">
        keep card
        {{ keep.name }} - {{ keep.description }}
      </p>
      <div class="user-icon">
        <img class="w-100 rounded-circle" :src="keep.creator.picture" alt="keep creator picture">
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Keep',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  },
  components: {}
}
</script>

<style>

</style>
