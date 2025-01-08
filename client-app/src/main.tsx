import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './app/layout/App';

console.log('Initializing React'); // Debug log to ensure main.tsx is running

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

console.log('ReactDOM.createRoot executed');