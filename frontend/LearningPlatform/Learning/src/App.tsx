
import {BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import './App.css'
import SignUp from './templates/sign-up/SignUp'
import SignIn from './templates/sign-in/SignIn'
import СreateCourse from './templates/createCourse/createCourse'
import Header from './templates/component/header'
import { useAppDispatch } from './store/hooks'
import { getTokenFromLocalStorage } from './helpers/cookiesHelper'
import { AuthService } from './services/auth.service'
import { login, logout, getCourses} from './store/user/userSlice'
import { useEffect } from 'react'

function App() {
  const dispath = useAppDispatch()
  const checkAuth = async () => {
    const token = getTokenFromLocalStorage()
    try {
      if(token){
        const data = await AuthService.getme()
        console.log(data)
        if(data){
          dispath(login(data))
          dispath(getCourses(data))
        } else {
          dispath(logout())
        }
      }
    } catch (error) {
        console.log(error);
        
    }

  }


  useEffect(() =>  {
    checkAuth()
  }, [])
  return (
    
    <Router>
      <Header/>
      <Routes>
          <Route path="/sign-up" element={<SignUp />} />
          <Route path="/sign-in" element={<SignIn />} />
          <Route path="/createCourse" element={<СreateCourse />} />
      </Routes>
    </Router>
  )
}

export default App
