import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'

createRoot(document.getElementById('root')!).render( // class the root and renders it
  <StrictMode>
    <App />
  </StrictMode>,
)
