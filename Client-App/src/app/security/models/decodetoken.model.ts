export class DecodeToken {
  aud: string;
  email: string;
  exp: string;
  iat: string;
  nbf: string;
  role: string;
  // tslint:disable-next-line:variable-name
  unique_name: string;
  constructor(fields: any = {}) {
    Object.assign(this, fields);
  }
}
