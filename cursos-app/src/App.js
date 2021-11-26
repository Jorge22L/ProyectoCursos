import MuithemeProvider from '@mui/material/styles/ThemeProvider';

import React from 'react';
import theme from './components/Tools/Theme';
import RegistrarUsuario from './components/Seguridad/RegistrarUsuario';
import Login from './components/Seguridad/Login';

function App() {
  return (
    <MuithemeProvider theme={theme}>
      <h1 style={{textAlign:"center"}}>🌊 que tal?</h1>
      <RegistrarUsuario />
      
    </MuithemeProvider>
  );
}

export default App;
