export class Employee {
    id: number;
    name: string;
    description: string;
    ocupation: string;
    phoneNumber: string;
    address: string;
    email: string;
    github: string;
    instagram: string;
    studies: [{
      id:number;
      Name: string;
      location:string;
      Interval: string;
    }
    ]
  }

  export class EmployeeForCreation {
    name: string;
    description: string;
    ocupation: string;
    phoneNumber: string;
    address: string;
    email: string;
    github: string;
    instagram: string;
  }
  export class Skill {
    name: string;
    proficiency: number;
  }
  export class Interest {
    name: string;
  }
  export class DevTool {
    name: string;
    proficiency: number;
  }
  export class Study {
    name: string;
    location: string;
    interval: string;
  }
