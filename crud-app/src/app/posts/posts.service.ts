import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Subject } from "rxjs";
import { map } from "rxjs/operators";
import { Router } from "@angular/router";

import { Post } from "./post.model";

@Injectable({ providedIn: "root" })
export class PostsService {

  private posts: Post[] = [];
  private postsUpdated = new Subject<Post[]>();

  constructor(private http: HttpClient, private router: Router) {}

  getPostUpdateListener() {
    return this.postsUpdated.asObservable();
  }

  getPosts() {
    this.http
      .get("https://localhost:5001/api/posts")
       .subscribe(x => {
        this.posts=x.data;
        this.postsUpdated.next([...this.posts]);
      });
  }

  getPost(id: number) {
    return {...this.posts.find(p=>p.id==id)};
    }

  addPost(title: string, content: string) {
    const post: Post = { id: Math.floor(Math.random() * (100 - 1) + 1), title: title, content: content };
    this.http
      .post(
        "https://localhost:5001/api/posts", post)
      .subscribe(res => {        
        this.posts.push(res.data);
        this.postsUpdated.next([...this.posts]);
        this.router.navigate(["/"]);
      });
   
  }

  updatePost(id: number, title: string, content: string) {
    const post: Post = { id: id, title: title, content: content };
    this.http
      .put(`https://localhost:5001/api/posts/${id}`, post)
      .subscribe(()=> {          
         this.posts=this.posts.map(i=>i.id===id ? post : i);        
        this.postsUpdated.next([...this.posts]);
        this.router.navigate(["/"]);
      });
    }
  

  deletePost(postId: number) { 

   this.http
      .delete("https://localhost:5001/api/posts/" + postId)
      .subscribe(() => {
        this.posts = this.posts.filter(post => post.id !== postId);
         
        this.postsUpdated.next([...this.posts]);
      });
 }
}
