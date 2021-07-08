import { WebStorageStateStore, User, UserManager } from "oidc-client";

export interface authConfig {
    userStore: WebStorageStateStore | undefined,
    authority: string,
    client_id: string,
    redirect_uri: string,
    response_type: string,
    post_logout_redirect_uri: string,
    scope: string,
    
    mockUser?: User
}

export interface authSettings {
    userManager: UserManager | null,
    login: Function,
    user: User | null,
    setUser: (user: User) => void
}