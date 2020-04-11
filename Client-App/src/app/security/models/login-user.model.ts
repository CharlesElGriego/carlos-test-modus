export class LoginUser {
  username: string;
  password: string;

  constructor(source: any = {}) {
    Object.assign(this, source);
  }

}
