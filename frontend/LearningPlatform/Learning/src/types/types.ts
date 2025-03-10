import { Id } from "react-toastify"

export interface IUser {
    email: string,
    token: string,
    role: string,
    id: string
    courses: Array<ICourse>
}


export interface IUserDataLogin {
    email: string,
    password: string,
}

export interface IUserData{
    email: string,
    password: string,
    fullname: string,
    role: string
}

export interface IResponseUserData {
     email: string | undefined,
     password: string | undefined, 
     role: string | undefined,
     fullname: string | undefined,
     courses: Array<any> | undefined,
     authorCourses: Array<any> | undefined,
}


export interface ICourseCreate {
    title: string | undefined,
    description: string | undefined,
    price: string | undefined,
    authorId: string | undefined
}

export interface ILessonCreate {
    title: string | undefined,
    description: string | undefined,
    lessonText: string | undefined,
}


export interface ICourse {
    id: string,
    title: string,
    authorId: string,
    price: number,
    description: string,
    lessons : Array<ILesson>
}

export interface ILesson {
    id: string,
    title: string,
    description: string,
    lessonText: string,
    courseId: string
}