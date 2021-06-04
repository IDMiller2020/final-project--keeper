const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class KeepsService {
  async createKeep(newKeep) {
    const res = await api.post('api/keeps', newKeep)
    AppState.keeps.push(res.data)
  }

  async deleteKeep(id) {
    await api.delete('api/keeps/' + id)
    AppState.keeps = AppState.keeps.filter(k => k.id !== id)
  }

  async getKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async getKeepById(id) {
    const res = await api.get('api/keeps/' + id)
    AppState.activeKeep = res.data
  }
}
export const keepsService = new KeepsService()
