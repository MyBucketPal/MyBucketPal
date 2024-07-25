import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      '/api': {
        target: 'https://127.0.0.1:7079', // Your backend API URL
        changeOrigin: true,
        secure: false, // If using self-signed certificates, set this to false
        rewrite: (path) => path.replace(/^\/api/, ''), // Rewrite path if necessary
      },
    },
  },
});

/*
export default defineConfig({

  server: {
    host: '127.0.0.1',
    port: 5173,
    proxy: {
      "/api": "http://localhost:7079",
      
    },

  },
  plugins: [react()]
})
*/