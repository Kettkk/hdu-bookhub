import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

export default defineConfig({
  plugins: [
    vue(),
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server:{
    host:'0.0.0.0',
    port:8081,
    cors:true,
    proxy:{
      '/5062':{
        target:'http://101.34.70.172:5062',
        changeOrigin:true
      },
    }
  }

})

