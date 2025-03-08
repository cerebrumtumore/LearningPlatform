import { createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'
import type { RootState } from '../store'
import { IUser } from '../../types/types'
import { accordionActionsClasses } from '@mui/material'

// Define a type for the slice state
interface UserState {
    user: IUser | null,
    isAuth: boolean,
    hasRole: string,
    id: string,
    courses: Array<JSON>,
}

// Define the initial state using that type
const initialState: UserState = {
    user: null,
    isAuth: false,
    hasRole: '',
    id: '',
    courses: []
}

export const userSlice = createSlice({
  name: 'user',
  // `createSlice` will infer the state type from the `initialState` argument
  initialState,
  reducers: {
    getCourses: (state, action:PayloadAction<IUser>) => {
      state.courses = action.payload.courses
    },

    login: (state, action:PayloadAction<IUser>) => {
        state.user = action.payload,
        state.isAuth = true,
        state.hasRole = action.payload.role,
        state.id = action.payload.id
    },
    logout: (state) => {
        state.isAuth = false,
        state.user = null,
        state.hasRole = '',
        state.id = ''
    }
  },
})

export const { login, logout, getCourses } = userSlice.actions

// Other code such as selectors can use the imported `RootState` type
export const selectCount = (state: RootState) => state.user

export default userSlice.reducer