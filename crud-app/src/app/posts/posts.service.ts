import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Subject } from "rxjs";
import { map } from "rxjs/operators";
import { Router } from "@angular/router";

import { Data,Post } from "./post.model";

@Injectable({ providedIn: "root" })
export class PostsService {

  private posts: Post[] = [];  
  private isLoading=true;
  private postsUpdated = new Subject<Data>();
//private errorSubject=new Subject<string>();

  constructor(private http: HttpClient, private router: Router) {}

  getPostUpdateListener() {
    return this.postsUpdated.asObservable();
  }

  getPosts() {
    this.http
      .get("http://localhost:5000/api/posts",{
        headers:HttpHeaders({'Custom-Header':'Test'})
      })
      .pipe(map(res =>{
        //Add transformation logic
      })
       .subscribe(x => {
        this.posts=x.data;
        this.isLoading=false;

        const receiver:Data={ 
          info:this.posts,
          isLoading:false
        }
        this.postsUpdated.next(receiver);
      }, err=>{
        //this.errorSubject.next(err.message);
      })
  }

   getPostById(id:number) {
    return this.http
      .get("http://localhost:5000/api/posts",{
       params: new HttpParams().set('id',id)
      })
      .pipe(map(res =>{
        //Add transformation logic
      })
  }



  getPost(id: number) {
    return {...this.posts.find(p=>p.id==id)};
    }

  addPost(title: string, content: string) {
    this.isLoading=true;
    const post: Post = { id: Math.floor(Math.random() * (100 - 1) + 1), title: title, content: content };
    this.http
      .post(
        "https://localhost:5001/api/posts", post)
      .subscribe(res => {        
        this.posts.push(res.data);

        const receiver:Data={ 
          info:this.posts,
          isLoading:false
        }
        this.postsUpdated.next(receiver);        
        this.router.navigate(["/"]);
      });
   
  }

  updatePost(id: number, title: string, content: string) {
    this.isLoading=true;
    const post: Post = { id: id, title: title, content: content };
    this.http
      .put(`https://localhost:5001/api/posts/${id}`, post)
      .subscribe(()=> {          
         this.posts=this.posts.map(i=>i.id===id ? post : i); 
         
         const receiver:Data={ 
          info:this.posts,
          isLoading:false
        }
        this.postsUpdated.next(receiver);  
        this.router.navigate(["/"]);
      });
    }
  

  deletePost(postId: number) { 
   this.isLoading=true;
   this.http
      .delete("https://localhost:5001/api/posts/" + postId)
      .subscribe(() => {
        this.posts = this.posts.filter(post => post.id !== postId);
        
        const receiver:Data={ 
          info:this.posts,
          isLoading:false
        }
        this.postsUpdated.next(receiver);          
      });
 }
}
