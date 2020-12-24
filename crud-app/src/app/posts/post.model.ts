export interface Post {
  id?: number,
  title: string;
  content: string;
}

export interface Data{
	info:Post[], 
	isLoading:boolean
}
