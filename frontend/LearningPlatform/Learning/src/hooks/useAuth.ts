import { useAppSelector } from "../store/hooks"
import { ICourse } from "../types/types";

export const useAuth = (): boolean =>{
    const isAuth = useAppSelector((state) => state.user.isAuth)
    return isAuth;
}  

export const userId = (): string => {
    const userId = useAppSelector((state) => state.user.id)
    return userId;
}

export const useRole = (): string => {
    const isRole = useAppSelector((state) => state.user.hasRole)
    return isRole;
}

export const useCourses = (): Array<ICourse> => {
    const isCourses = useAppSelector((state) => state.user.courses)
    return isCourses;
} 

