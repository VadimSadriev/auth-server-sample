import { UserManagerSettings } from 'oidc-client'
import { authConfig } from './authContext.Model'

export const authConfigToUserManagerSettingsMapper = (authConfig: authConfig) : UserManagerSettings => {

    return {
        userStore: authConfig.userStore,
        authority: authConfig.authority,
        client_id: authConfig.client_id,
        redirect_uri: authConfig.redirect_uri,
        response_type: authConfig.response_type,
        post_logout_redirect_uri: authConfig.post_logout_redirect_uri,
        scope: authConfig.scope,
    }
}