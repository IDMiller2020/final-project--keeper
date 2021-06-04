const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class VaultsService {
  async createVault(newVault) {
    const res = await api.post('api/vaults', newVault)
    AppState.vaults.push(res.data)
  }

  async deleteVault(vaultId) {
    await api.delete('api/vaults/' + vaultId)
    AppState.vaults = AppState.vaults.filter(v => v.id !== vaultId)
  }

  async getVaults() {
    const res = await api.get('api/vaults')
    AppState.vaults = res.data
  }

  async getVaultById(id) {
    const res = await api.get('api/vaults/' + id)
    AppState.activeVault = res.data
  }
}
export const vaultsService = new VaultsService()
