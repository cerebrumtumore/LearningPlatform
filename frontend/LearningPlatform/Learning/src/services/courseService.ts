import { ICourseCreate, IUser, IUserData } from "../types/types";
import { instance } from "./axios.api";

export const courseService = {
    async createCourse(course: ICourseCreate) : Promise<ICourseCreate> {
        try {
            const { data } = await instance.post<ICourseCreate>('course/createCourse', course);
            return data;
        } catch (error) {
            console.error('Ошибка при создании курса:');
            throw error;
        }
    },
    
    async getCoursesByUser() : Promise<IUser> {
        try {
            const { data } = await instance.get<IUser>('User/getCourse');
            console.log(data);
            
            return data;
        } catch (error) {
            console.error('Ошибка при создании курса:');
            throw error;
        } 
    }
}