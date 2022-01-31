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
  export class Study {
      id:number;
      Name: string;
      location:string;
      Interval: string;
  }