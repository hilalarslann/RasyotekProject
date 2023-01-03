import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import EmployeeProvider from './context/EmployeeContext';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <EmployeeProvider>
    <App />
  </EmployeeProvider>
);