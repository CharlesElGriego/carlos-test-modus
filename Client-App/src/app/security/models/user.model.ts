export class User {
  email: string;
  name: string;
  role: string;
  constructor(source: any = {}) {
    Object.assign(this, source);
  }

}
