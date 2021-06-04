const { AppState } = require('../AppState')
const { logger } = require('../utils/Logger')
const { api } = require('./AxiosService')

class ProfilesService {
  async getProfile(id) {
    try {
      const res = await api.get('api/profiles/' + id)
      AppState.profile = res.data
    } catch (error) {
      logger.error('Something went Wrong', error)
    }
  }

  async getKeepsByProfile(id) {
    try {
      const res = await api.get('api/profiles/' + id + '/keeps')
      AppState.profileKeeps = res.data
    } catch (error) {
      logger.error('Something went wrong', error)
    }
  }

  async getVaultsByProfile(id) {
    try {
      const res = await api.get('api/profiles/' + id + '/vaults')
      AppState.profileVaults = res.data
    } catch (error) {
      logger.error('Something went wrong', error)
    }
  }
}
export const profilesService = new ProfilesService()
