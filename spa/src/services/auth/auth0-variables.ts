interface AuthConfig {
  clientID: string;
  domain: string;
  callbackURL: string;
  apiUrl: string;
}

export const AUTH_CONFIG: AuthConfig = {
  clientID: 'sFC2WE2dWFOE0wGzw4QqHzyDllTtK4sY',
  domain: 'iedge.auth0.com',
  callbackURL: 'http://localhost:4200/callback',
  apiUrl: 'https://api.iedge.com'
};
