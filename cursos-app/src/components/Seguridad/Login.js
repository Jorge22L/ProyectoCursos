import { Avatar, Container, TextField, Typography, Button } from '@mui/material';
import styles from '../Tools/Style';
import React from 'react';
import LockClockOutlinedIcon from '@mui/icons-material/LockClockOutlined';

const Login = () =>{
    return (
        <Container maxWidth="xs">
            <div style={styles.paper} >
                <Avatar style={styles.avatar}>
                    <LockClockOutlinedIcon style={styles.icon} />
                </Avatar>
                <Typography component="h1" variant="h5" style={{textAlign:"center"}}>
                    Login de usuario
                </Typography>
                <form style={styles.form}>
                    <TextField variant="outlined" label="Ingrese su username" name="username" fullWidth />
                    <br />
                    <br />
                    <TextField variant="outlined" type="password" label="Ingrese su contraseña" name="password" fullWidth />
                    <Button type="submit" fullWidth variant="contained" color="primary" style={styles.submit}>
                        Enviar
                    </Button>
                </form>
            </div>
        </Container>
    )
}

export default Login;