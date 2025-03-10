import { ICourse, ICourseCreate, ILessonCreate, IUser, IUserData } from "../types/types";
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
    
    async getCourseById(id: string) : Promise<ICourse>{
        const { data } = await instance.get<ICourse>('course/getById/?id=' + id);
        return data;
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
    },

    async createLesson(lesson: ILessonCreate, id:any) : Promise<ILessonCreate> {
        try {
            const { data } = await instance.post<ILessonCreate>('lesson/createLesson?courseId=' + id, lesson, id);
            return data;
        } catch (error) {
            console.error('Ошибка при создании курса:');
            throw error;
        }
    },

    async removeCourse(id: string) {
        try{
            await instance.post<string>('remove?id=' + id, id);
        } catch (error) {
            console.error('Ошибка при удалении курса:');
            throw error;
        }
    }

}