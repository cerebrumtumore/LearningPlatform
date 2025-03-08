import axios from 'axios'
import { getTokenFromLocalStorage } from '../helpers/cookiesHelper'

export const instance = axios.create({
    baseURL: 'https://localhost:7296',
    headers: {
        Authorization: `Bearer ` + getTokenFromLocalStorage() || '',

    }
})