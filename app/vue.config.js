const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  pwa: {
    iconPaths: {
      favicon32: 'favicon.ico',
      favicon16: 'favicon.ico',
      appleTouchIcon: null,  // Disable Apple Touch Icon
      maskIcon: null,        // Disable Mask Icon
      msTileImage: null,     // Disable Microsoft Tile Image
      androidChrome: null    // Disable Android Chrome Icon
    }
  }
})
