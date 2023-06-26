import { UserDTOModel } from "./userDTO.model";


export class registerModel
{
    constructor
        (
        public id:string="",
        public email:string="",
        public firstName: string="",
        public lastName: string="",
        public gender: string="",
        public role: string="",
        public password: string="",
        public hashKey: string="",
        public passwordClear: string=""
        )
        {
            
        } 
}