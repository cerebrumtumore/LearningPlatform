import AppTheme from "./components/shared-theme/AppTheme";
import ColorModeSelect from "./components/shared-theme/ColorModeSelect";
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import FormLabel from '@mui/material/FormLabel';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import { styled } from "@mui/material/styles";
import MuiCard from '@mui/material/Card';
import Stack from "@mui/material/Stack";
import { useNavigate } from "react-router-dom";
import { useRole } from "../../hooks/useAuth";
import { SyntheticEvent } from "react";
import { userId } from '../../hooks/useAuth';
import { courseService } from "../../services/courseService";
import { toast } from "react-toastify";
import React from "react";
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

const CourseContainer = styled(Stack)(({ theme }) => ({
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


export default function createCourse(props: {disableCustomTheme?: boolean}){
  const authorId = userId();
  const hasRole = useRole();
  const [title, setTitle] = React.useState('');
  const [description, setDescription] = React.useState('');
  const [price, setPrice] = React.useState('');
  const [titleError, setTitleError] = React.useState(false);
  const [titleErrorMessage, setTitleErrorMessage] = React.useState('');
  const [descriptionError, setDescriptionError] = React.useState(false);
  const [descriptionErrorMessage, setDescriptionErrorMessage] = React.useState('');
  const [priceError, setPriceError] = React.useState(false);
  const [priceErrorMessage, setPriceErrorMessage] = React.useState('');
    const validateInputs = () => {
      let isValid = true;

    if (!description || description.length < 1) {
      setDescriptionError(true);
      setDescriptionErrorMessage('Description is required.');
      isValid = false;
    } else if (description.length > 1000) {
      setDescriptionError(true);
      setDescriptionErrorMessage('Maximum 1000 characters.');
      isValid = false;
    } else {
      setDescriptionError(false);
      setDescriptionErrorMessage('');
    }

    if (!title || title.length < 1) {
      setTitleError(true);
      setTitleErrorMessage('Title is required.');
      isValid = false;
    } else {
      setTitleError(false);
      setTitleErrorMessage('');
    }

    if (!price || isNaN(Number(price)) || Number(price) <=0) {
      setPriceError(true);
      setPriceErrorMessage('Price must be a positive number.');
      isValid = false;
    } else {
      setPriceError(false);
      setPriceErrorMessage('');
    }


    return isValid;
    };

    const handleSubmit = async (e: SyntheticEvent) => {
      if(titleError || descriptionError || priceError){
        e.preventDefault();
        return;
      }
      console.log(userId)
      try {
        console.log(authorId);
        
        const response = await courseService.createCourse( {title, description, price, authorId: authorId} )
        if (response) {
          toast.success('Successful')
        } else {
          toast.error('Error')              
        }
      } catch (error) {
        console.error('Ошибка:', error);
      }
    
    };


    return (
        <AppTheme {...props}>
          <CssBaseline enableColorScheme />
          <ColorModeSelect sx={{ position: 'absolute', top: '6rem', right: '3rem' }} />
          
          {hasRole == "AUTHOR" && (
            <Box sx={{width:"100%", justifyContent: 'center', alignSelf: "center",alignItems: 'center', display: 'flex', height: '100vh'}}>
              <Typography variant="h1" gutterBottom>
                Доступ запрещен.
              </Typography>
            </Box>

          )}
          {hasRole == "STUDENT" && (
            <CourseContainer  direction="column" justifyContent="space-between">
            <Card variant="outlined">
                      <Typography
                      component="h1"
                      variant="h4"
                      sx={{ width: '100%', fontSize: 'clamp(2rem, 10vw, 2.15rem)' }}
                      >
                      Create Course
                      </Typography>
  
                      <Box 
                      component="form"
                      onSubmit={handleSubmit} 
                      sx={{display: 'flex', flexDirection: 'column', gap: 2}}>
                          <FormControl>
                              <FormLabel htmlFor="title">Title</FormLabel>
                              <TextField
                                id="title"
                                name="title"
                                required
                                fullWidth
                                placeholder="Title" 
                                onChange={e => setTitle(e.target.value)}
                                error={titleError}
                                helperText={titleErrorMessage}
                                color={titleError ? 'error' : 'primary'}
                              />
                          </FormControl>
                          <FormControl >
                              <FormLabel htmlFor="description">Description</FormLabel>
                              <TextField
                                  name="description"
                                  id="description"
                                  variant="outlined"
                                  multiline={true}
                                  fullWidth
                                  rows={6}
  
                                  onChange={e => setDescription(e.target.value)}
                                  error={descriptionError}
                                  helperText={descriptionErrorMessage}
                                  color={descriptionError ? 'error' : 'primary'}
                                  placeholder="Description"
                                  InputProps={{
                                      style: {minHeight:'150px'},
                                  }}
                              />
                          </FormControl>
                          <FormControl>
                              <FormLabel htmlFor="price" >Price</FormLabel>
                              <TextField
                                  required
                                  variant="outlined"
                                  fullWidth
                                  name="price"
                                  id="price"
                                  autoComplete="price"
                                  placeholder="Price"
                                  onChange={e => setPrice(e.target.value)}
                                  error={priceError}
                                  helperText={priceErrorMessage}
                                  color={priceError ? 'error' : 'primary'}
                              />
                          </FormControl>
                          <Button
                              type='submit'
                              sx={{marginTop: '20px'}}
                              fullWidth
                              variant="contained"
                              onClick={validateInputs}
                              >
                              Create
                          </Button>
                      </Box>
                  </Card>
                </CourseContainer>
          )}
        </AppTheme>
    );
}