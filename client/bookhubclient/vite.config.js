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
    port:8080,
    proxy:{
      '/5152':{
        target:'http://101.34.70.172:5152',
        changeOrigin:true
      }
    }
  }
})
