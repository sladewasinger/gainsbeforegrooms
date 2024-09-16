import * as msal from "@azure/msal-browser";

// MSAL configuration
const msalConfig = {
  auth: {
    clientId: "791879ec-061d-4037-81ba-51be25f70731",  // Replace with your Azure B2C Client ID
    authority: "https://gainsbeforegrooms.b2clogin.com/gainsbeforegrooms.onmicrosoft.com/B2C_1_GBG_Google",
    redirectUri: "https://black-desert-006310210.5.azurestaticapps.net/#/",  // Replace with your app's redirect URI
  },
  cache: {
    cacheLocation: "localStorage", // Use localStorage to cache tokens
    storeAuthStateInCookie: true,  // Useful for older browsers (IE11/Edge)
  }
};

// Initialize the MSAL PublicClientApplication
const msalInstance = new msal.PublicClientApplication(msalConfig);

// Handle redirect promises (important for handling redirects if you are using redirect login)
export const initializeMsal = async () => {
  console.warn("Initializing MSAL...");
  try {
    await msalInstance.initialize();

    return await msalInstance.handleRedirectPromise();
  } catch (error) {
    console.error("Error handling redirect:", error);
    return false;
  }
}

// Function to handle login via popup
export const login = async () => {
  await initializeMsal();

  // Clear interaction state if stuck
  msalInstance.browserStorage?.removeItem('interaction_status');


  console.warn("[MSAL] Attempting to log in...");
  try {
    const accounts = msalInstance.getAllAccounts();

    if (accounts.length === 0) {
      const loginResponse = await msalInstance.loginPopup({
        scopes: ["openid", "profile"]
      });
      console.log("Login success:", loginResponse);
      return loginResponse;
    } else {
      console.log("User already logged in.");
      return accounts[0];  // Return the first logged-in account
    }
  } catch (error) {
    console.error("Login failed:", error);
    if (error.errorCode === "interaction_in_progress") {
      console.log("Interaction in progress, clearing cache...");
      msalInstance.clearCache();
    }
    throw error;
  }
};

// Function to get an access token silently
export const getToken = async () => {
  await initializeMsal();
  console.warn("[MSAL] Attempting to get token...");
  const accounts = msalInstance.getAllAccounts();
  if (accounts.length === 0) {
    console.warn("No accounts found. User is not logged in.");
    return null;
  }

  try {
    const response = await msalInstance.acquireTokenSilent({
      account: accounts[0],
      scopes: ["openid", "profile"]
    });
    console.log("Token acquired:", response.accessToken);
    return response.accessToken;
  } catch (error) {
    console.error("Token acquisition failed:", error);
    throw error;
  }
};

// Function to log out
export const logout = () => {
  msalInstance.logout();
};
