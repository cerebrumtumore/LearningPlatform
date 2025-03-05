import { Box, Card, CssBaseline, FormControl, FormLabel, TextField } from "@mui/material";
import AppTheme from "../sign-up/components/shared-theme/AppTheme";
import ColorModeSelect from "./components/shared-theme/ColorModeSelect";
import Typography from "@mui/material/Typography";
import { styled } from "@mui/material/styles";
import MuiCard from '@mui/material/Card';
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";
import { useNavigate } from "react-router-dom";
import React from "react";


export default function СreateCourse(props: {disableCustomTheme?: boolean}){
    const navigate = useNavigate()
    const [titleError, setTitleError] = React.useState(false);
    const [titleErrorMessage, setTitleErrorMessage] = React.useState('');
    const [descriptionError, setDescriptionError] = React.useState(false);
    const [descriptionErrorMessage, setDescriptionErrorMessage] = React.useState('');
    const [priceError, setPriceError] = React.useState(false);
    const [priceErrorMessage, setpriceErrorMessage] = React.useState('');
    const validateInputs = () => {
        const isNumber = (val: any) => typeof val === "number" && val === val;
        const Title = document.getElementById('Title') as HTMLInputElement;
        const Description = document.getElementById('Description') as HTMLInputElement;
        const Price = document.getElementById('Price') as HTMLInputElement;
    
        let isValid = true;
        if(!isNumber(Price.value)){
            setPriceError(true)
            setpriceErrorMessage('Is not Integer')
        } else{
            setPriceError(false)
            setpriceErrorMessage('')
        }


        if(!Description.value || Description.value.length < 1){
            setDescriptionError(true)
            setDescriptionErrorMessage('Description is required.')
        }
        else if(Description.value.length > 1000){
            setDescriptionError(true)
            setDescriptionErrorMessage('Maximum 1000 characters.')
        } else {
            setDescriptionError(false)
            setDescriptionErrorMessage('')
        }
    
        if (!Title.value || Title.value.length < 1) {
          setTitleError(true);
          setTitleErrorMessage('Title is required.');
          isValid = false;
        } else {
          setTitleError(false);
          setTitleErrorMessage('');
        }
    
        return isValid;
      };
    const SignUpContainer = styled(Stack)(({ theme }) => ({
        height: 'calc((1 - var(--template-frame-height, 0)) * 100dvh)',
        minHeight: '100%',
        padding: theme.spacing(2),
        [theme.breakpoints.up('sm')]: {
          padding: theme.spacing(4),
        },
        '&::before': {
          content: '""',
          display: 'block',
          position: 'absolute',
          zIndex: -1,
          inset: 0,
          backgroundImage:
            'radial-gradient(ellipse at 50% 50%, hsl(210, 100%, 97%), hsl(0, 0%, 100%))',
          backgroundRepeat: 'no-repeat',
          ...theme.applyStyles('dark', {
            backgroundImage:
              'radial-gradient(at 50% 50%, hsla(210, 100%, 16%, 0.5), hsl(220, 30%, 5%))',
          }),
        },
      }));
    const Card = styled(MuiCard)(({ theme }) => ({
        display: 'flex',
        flexDirection: 'column',
        alignSelf: 'center',
        width: '100%',
        padding: theme.spacing(4),
        gap: theme.spacing(2),
        margin: 'auto',
        boxShadow:
          'hsla(220, 30%, 5%, 0.05) 0px 5px 15px 0px, hsla(220, 25%, 10%, 0.05) 0px 15px 35px -5px',
        [theme.breakpoints.up('sm')]: {
          width: '450px',
        },
        ...theme.applyStyles('dark', {
          boxShadow:
            'hsla(220, 30%, 5%, 0.5) 0px 5px 15px 0px, hsla(220, 25%, 10%, 0.08) 0px 15px 35px -5px',
        }),
      }));

      const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        if(titleError || descriptionError || priceError){
            event.preventDefault();
            return;
        }
        
        const data = {
            Title: event.currentTarget.Title.value,
            Description: event.currentTarget.value,
            Price: event.currentTarget.value,
        }
        try {
            const response = await fetch('https://localhost:7296/course', 
              {
                method: 'POST',
                headers: {'Content-Type': 'application/json',},
                body: JSON.stringify(data),
              }
            );
            if (!response.ok) {
              const errorData = await response.json();
              console.error('Ошибка регистрации:', errorData);
            } else {
              console.log('Регистрация успешна!');
              navigate('/sign-in');
            }
          } catch (error) {
            console.error('Ошибка:', error);
          }
      
        };


    return (
        <AppTheme {...props}>
            <CssBaseline enableColorScheme/>
            <ColorModeSelect sx={{ position: 'fixed', top: '1rem', right: '1rem' }} />
            <SignUpContainer direction="column" justifyContent="space-between">
                <Card variant="outlined">
                    <Typography
                    component="h1"
                    variant="h4"
                    sx={{ width: '100%', fontSize: 'clamp(2rem, 10vw, 2.15rem)' }}
                    >
                    Create Course
                    </Typography>

                    <Box component="form" onSubmit={handleSubmit} sx={{display: 'flex', flexDirection: 'column', gap: 2}}>
                        <FormControl>
                            <FormLabel htmlFor="Title">Title</FormLabel>
                            <TextField
                                autoComplete="Title"
                                name="Title"
                                required
                                fullWidth
                                id="Title"
                                placeholder="Title" 
                            />
                        </FormControl>
                        <FormControl >
                            <FormLabel htmlFor="Description" >Description</FormLabel>
                            <TextField
                                variant="outlined"
                                autoComplete="off"
                                multiline={true}
                                fullWidth
                                rows={6} // Увеличьте количество строк здесь
                                name="Description"
                                id="Description"
                                placeholder="Description"
                                InputProps={{
                                    style: {minHeight:'150px'},
                                }}
                            />
                        </FormControl>
                        <FormControl >
                            <FormLabel htmlFor="Price" >Price</FormLabel>
                            <TextField
                                variant="outlined"
                                autoComplete="off"
                                fullWidth
                                name="Price"
                                id="Price"
                                placeholder="Price"
                            />
                        </FormControl>
                        <Button
                            sx={{marginTop: '20px'}}
                            type="submit"
                            fullWidth
                            variant="contained"
                            onClick={validateInputs}
                            >
                            Create
                        </Button>
                    </Box>
                </Card>

            </SignUpContainer>
        </AppTheme>
    );
}