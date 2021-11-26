import { Button, Container, Grid, TextField, Typography } from '@mui/material';
import React, { useState } from 'react';
import styles from '../Tools/Style';
import { registrarUsuario } from '../../actions/UsuarioAction';

const RegistrarUsuario = () =>{
    const [usuario, setUsuario] = useState({
        nombre:'',
        username:'',
        email:'',
        password:'',
    })

    const ingresarValores = e =>{
        const {name, value} = e.target;
        setUsuario( anterior =>({
            ...anterior,
            [name]:value
            //nombre: josé
        }))
    }

    const registrarUsuarioClick = e =>{
        e.preventDefault();

        registrarUsuario(usuario).then(response => {
            console.log('Se guardó el usuario con éxito', response);
        })

        console.log('Datos del usuario: ', usuario)
    }

    return(
        <Container component="main" maxWidth="md" justify = "center">
            <div style={styles.paper}>
                <Typography component="h1" variant="h5" style={{textAlign:"center"}}>
                    Registrar Usuario
                </Typography>
                <form style={styles.form}>
                    <Grid container spacing={2}>
                        <Grid item xs={12} md={12}>
                            <TextField name="nombre" value={usuario.nombre} onChange={ingresarValores} variant="outlined" fullWidth label="Ingrese su nombre" />
                        </Grid>
                        <Grid item xs={12} md={6}>
                            <TextField name="email" value={usuario.email} onChange={ingresarValores} variant="outlined" fullWidth label="Ingrese su email" />
                        </Grid>
                        <Grid item xs={12} md={6}>
                            <TextField name="username" value={usuario.username} onChange={ingresarValores} variant="outlined" fullWidth label="Ingrese su username" />
                        </Grid>
                        <Grid item xs={12} md={6}>
                            <TextField name="password" value={usuario.password} onChange={ingresarValores} type="password" variant="outlined" fullWidth label="Ingrese su contraseña" />
                        </Grid>
                        
                    </Grid>
                    <Grid container justify="center">
                        <Grid item xs={12} md={12}>
                            <Button type="submit" onClick={registrarUsuarioClick} fullWidth variant="contained" color="primary" size="large" style={styles.submit}>
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