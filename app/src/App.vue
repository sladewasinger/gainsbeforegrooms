<template>
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
    <button @click="loginUser">Login</button>
    <button @click="logoutUser">Logout</button>
    <p v-if="user">Welcome, {{ user.name }}</p>
  </nav>
  <!-- <div id="app"> -->

  <!-- </div> -->
  <router-view />
</template>

<script>
import { login, logout } from "./services/authService";

export default {
  data() {
    return {
      user: null,
      isLoggingIn: false,
    };
  },
  methods: {
    async loginUser() {
      console.log("Logging in...");
      if (this.isLoggingIn) return;
      this.isLoggingIn = true;
      try {
        const response = await login();
        this.user = response.account;
      } catch (error) {
        console.error("Login failed:", error);
      } finally {
        this.isLoggingIn = false;
      }
    },
    logoutUser() {
      logout();
      this.user = null;
    },
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
