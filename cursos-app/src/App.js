import MuithemeProvider from '@mui/material/styles/ThemeProvider';

import React from 'react';
import theme from './components/Tools/Theme';
import RegistrarUsuario from './components/Seguridad/RegistrarUsuario';

function App() {
  return (
    <MuithemeProvider theme={theme}>
      <h1 style={{textAlign:"center"}}>🌊 que tal?</h1>
      <RegistrarUsuario />
      <RegistrarUsuario />
      <RegistrarUsuario />
      <RegistrarUsuario />
      <RegistrarUsuario />
    </MuithemeProvider>
  );
}

export default App;
