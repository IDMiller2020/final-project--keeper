import Notification from '../utils/Notification'

const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class VaultsService {
  async createVault(newVault) {
    const res = await api.post('api/vaults', newVault)
    AppState.vaults.push(res.data)
  }

  async createVaultKeep(vaultId, keepId) {
    const newVaultKeep = { vaultId: vaultId, keepId: keepId }
    await api.post('api/vaultKeeps', newVaultKeep)
  }

  async deleteVault(vaultId) {
    await api.delete('api/vaults/' + vaultId)
    AppState.vaults = AppState.vaults.filter(v => v.id !== vaultId)
  }

  async deleteVaultKeep(id) {
    await api.delete('api/vaultKeeps/' + id)
  }

  async getKeeps(vaultId) {
    try {
      const res = await api.get('api/vaults/' + vaultId + '/keeps')
      AppState.profileKeeps = res.data
    } catch (error) {
      Notification.toast('INVALID ACCESS', 'error')
    }
  }

  async getVaults() {
    const res = await api.get('api/vaults')
    AppState.vaults = res.data
  }

  async getProfileVaults(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.profileVaults = res.data
  }

  async getVaultById(id) {
    const res = await api.get('api/vaults/' + id)
    AppState.activeVault = res.data
  }
}
export const vaultsService = new VaultsService()
