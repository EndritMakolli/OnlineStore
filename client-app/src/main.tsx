import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './app/layout/styles.css'
import 'semantic-ui-css/semantic.min.css'
import App from './app/layout/App'

createRoot(document.getElementById('root')!).render( // class the root and renders it
  <StrictMode>
    <App />
  </StrictMode>,
)
