
import { Routes, Route } from 'react-router-dom'
import './App.css'
import SignUp from './templates/sign-up/SignUp'
import SignIn from './templates/sign-in/SignIn'
import СreateCourse from './templates/createCourse/createCourse'

function App() {

  return (

    <Routes>
          <Route path="/" element={<SignUp />} />
          <Route path="/sign-in" element={<SignIn />} />
          <Route path="/createCourse" element={<СreateCourse />} />
    </Routes>
  )
}

export default App
