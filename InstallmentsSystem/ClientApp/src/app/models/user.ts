
export interface SaveUser {
  email: string;
  userName: string;
  password: string;
}

export interface loggedUser {
  id: number;
  email: string;
  userName: string;
  roles: any[];
  tokenString: string;
}
