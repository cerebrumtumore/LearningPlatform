import { IResponseUserData, IUser, IUserData, IUserDataLogin } from "../types/types";
import { instance } from "./axios.api";

export const AuthService = {
    async registration(userData: IUserData) : Promise<IResponseUserData | undefined> {
        const {data} = await instance.post<IResponseUserData>('User/register', userData)
        return data;
    },
    async login(userData: IUserDataLogin): Promise<IUser | undefined>{
        const {data} = await instance.post<IUser>('User/login', userData)
        return data;
    },
    async getme(): Promise<IUser | undefined>{
        const {data} = await instance.get<IUser>('User/user')
        if(data) return data;
    },
}