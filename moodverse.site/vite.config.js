import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import { LOCALHOST } from './src/constants.js';

export default defineConfig({
    plugins: [react()],
    css: {
        preprocessorOptions: {
            scss: {
                api: 'modern-compiler'
            },
            server: {
                proxy: {
                    '/api': {
                        target: LOCALHOST,
                        changeOrigin: true,
                        rewrite: (path) => path.replace(/^\/api/, ''),
                    },
                },
            },
        }
    },
})
