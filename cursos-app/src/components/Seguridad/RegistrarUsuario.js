import { Button, Container, Grid, TextField, Typography } from '@mui/material';
import React from 'react';
import styles from '../Tools/Style';

const RegistrarUsuario = () =>{
    return(
        <Container component="main" maxWidth="md" justify = "center">
            <div style={styles.paper}>
                <Typography component="h1" variant="h5" style={{textAlign:"center"}}>
                    Registrar Usuario
                </Typography>
                <form style={styles.form}>
                    <Grid container spacing={2}>
                        <Grid item xs={12} md={6}>
                            <TextField name="nombre" variant="outlined" fullWidth label="Ingrese su nombre" />
                        </Grid>
                        <Grid item xs={12} md={6}>
                            <TextField name="username" variant="outlined" fullWidth label="Ingrese su username" />
                        </Grid>
                        <Grid item xs={12} md={6}>
                            <TextField name="password" type="password" variant="outlined" fullWidth label="Ingrese su contraseña" />
                        </Grid>
                        <Grid item xs={12} md={6}>
                            <TextField name="confirmepassword" type="password" variant="outlined" fullWidth label="Confirme su contraseña" />
                        </Grid>
                    </Grid>
                    <Grid container justify="center">
                        <Grid item xs={12} md={12}>
                            <Button type="submit" fullWidth variant="contained" color="primary" size="large" style={styles.submit}>
                                Enviar
                            </Button>
                        </Grid>
                    </Grid>
                </form>
            </div>
        </Container>
    )
}

export default RegistrarUsuario;