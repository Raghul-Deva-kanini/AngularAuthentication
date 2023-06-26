
export class UserDTOModel {
    constructor(
     public id:string= "",
     public email: string="",
     public password:string="",
     public token:string="",
     public role:string=""
     )
     {
      
     }
   }