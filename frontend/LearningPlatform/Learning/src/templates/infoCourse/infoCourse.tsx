import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import AppTheme from "../component/shared-theme/AppTheme";
import { useNavigate, useParams } from "react-router-dom";
import { ICourse, ILesson } from "../../types/types";
import { getTokenFromLocalStorage } from "../../helpers/cookiesHelper";
import { login, logout } from "../../store/user/userSlice";
import { AuthService } from "../../services/auth.service";
import { courseService } from "../../services/courseService";
import { JSXElementConstructor, ReactElement, ReactNode, ReactPortal, SyntheticEvent, useEffect, useState } from "react";
import { Card, Stack, styled } from "@mui/material";
import ColorModeSelect from "../component/shared-theme/ColorModeSelect";
import { toast } from "react-toastify";

export default function infoCourse(props: {disableCustomTheme?: boolean}) {
    const params = useParams<Record<string, string | undefined>>(); // Используем Record для параметров
    const id = params.id; // Получаем id из параметров
    const [course, setCourse] = useState<ICourse | null>(null);
    const navigate = useNavigate();
    const [lessons, setLessons] = useState<Array<ILesson> | null>(null);
    const navigatees = () => {
        navigate(`/lesson/createLesson/${id}`)
    }

    const removeSubmit = async (e: SyntheticEvent) => {
          try {
            if(id)
                await courseService.removeCourse(id);      
                toast.success('Successful')             
            
          } catch (error) {
            console.error('Ошибка:', error);
          }
        
        };
    const checkCourse = async () => {
        const token = getTokenFromLocalStorage()
        try {
          if(id !== undefined){
            if(token){
                const fetchCourse = await courseService.getCourseById(id)
                
                if(fetchCourse)
                    setCourse(fetchCourse)
                    // setLessons(fetchCourse.lessons)
                
              }
          }
        } catch (error) {
            console.log(error);
            
        }
    
      }
       useEffect(() =>  {
          checkCourse()
        }, [])

        const SignInContainer = styled(Stack)(({ theme }) => ({
            height: 'calc((1 - var(--template-frame-height, 0)) * 100dvh)',
            minHeight: '100%',
            marginTop: '100px',
            width: '600px',
            margin: 'auto',
            padding: theme.spacing(2),
            [theme.breakpoints.up('sm')]: {
              padding: theme.spacing(4),
            },
            '&::before': {
              content: '""',
             
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
    return (
      <AppTheme {...props}>
        <SignInContainer direction="column" justifyContent="space-between">
        <ColorModeSelect sx={{ position: 'fixed', top: '1rem', right: '1rem' }} />
        
        <Card variant="outlined" sx={{marginTop: '200px'}}>
        <Box sx={{ display: 'flex', flexDirection: 'column', gap: 4, padding: 3, }}>
            <Typography variant="h2" gutterBottom >
             {course?.title}
            </Typography>
            
            <Typography variant="body1" gutterBottom sx={{overflowWrap:'break-word'}}>
                Описание
            {course?.description}
            </Typography>
            <Typography variant="h6" color="text.secondary" gutterBottom>
            Цена
            {course?.price}₽
            </Typography>
            <Box sx={{ display: 'flex', flexDirection: 'column', gap: 2 }}>
            <Typography variant="h5">Содержание курса:</Typography>
            <ul>
                {course?.lessons.map((lesson) => (
                <li>
                    <Typography variant="body2">{lesson.title}</Typography>
                </li>
                ))}
            </ul>
            </Box>
            <Button variant="contained" color="primary" onClick={navigatees}>
            Создать урок
            </Button>

            <Button variant="contained" color="primary" onClick={removeSubmit}>
            Удалить курс
            </Button>
        </Box>
        </Card>
        </SignInContainer>
      </AppTheme>
    );
};

