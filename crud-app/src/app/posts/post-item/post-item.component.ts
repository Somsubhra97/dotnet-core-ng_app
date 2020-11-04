import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from "@angular/router";

import { PostsService } from "../posts.service";
import { Post } from "../post.model";

@Component({
  selector: 'app-post-item',
  templateUrl: './post-item.component.html',
  styleUrls: ['./post-item.component.css']
})
export class PostItemComponent implements OnInit {
  
  post:Post;
  
  constructor(
    public postsService: PostsService,
    public route: ActivatedRoute
  ) {}

  ngOnInit(): void {

  	this.route.paramMap.subscribe((paramMap: ParamMap) => {
  		if(paramMap.get("postId")){
       		this.post=this.postsService.getPost(parseInt(paramMap.get("postId")));
  		}
    });
  }
}
