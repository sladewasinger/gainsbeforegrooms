import { createApp } from "vue";
import App from "./App.vue";
import { login, getToken, initializeMsal } from "./services/authService";
import router from './router'
import './assets/styles/tailwind.css';

const app = createApp(App);

// // Ensure MSAL is ready and trigger login
// (async () => {
//   try {
//     const tokenResponse = await initializeMsal();  // Initialize MSAL


//     const token = await getToken();  // Check if there's a valid token
//     if (!token) {
//       await login();  // No token, trigger login
//     }
//   } catch (error) {
//     console.error("Error during login flow:", error);
//   }
// })();

app.use(router).mount("#app");
