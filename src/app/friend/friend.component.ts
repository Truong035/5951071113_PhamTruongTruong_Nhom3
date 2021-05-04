import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ModalDismissReasons,NgbModal } from '@ng-bootstrap/ng-bootstrap';

export class Friend {
  constructor(
 public ID:Number,
 public f_name:string,
 public m_name:string,
 public l_name:string,
 public adress:string,
 public birthdate:string,
 public score:string,
 
  ) {}
 }
 
@Component({
  selector: 'app-friend',
  templateUrl:'./friend.component.html',
  styleUrls: ['./friend.component.css']
})
export class FriendComponent implements OnInit {
closeResualt !:string;

  friends :any={
    ID:1,
 f_name:"tr",
    m_name:"tr",
   l_name:"tr",
     adress:"tr",
     birthdate:"03-05-2000",
     score:"tr",
  };
  constructor(
private HttpClient:HttpClient,
private modalService:NgbModal,
  ) { }

  ngOnInit(): void {
 
 this.getFriends();
  }
  getFriends(){
    this.HttpClient.get<any>('/api/Student/').subscribe(
      response=>{
        console.log(response);
        this.friends=response;
        
      });
   
    };
    open(content:any){
      this.modalService.open(content,{ ariaLabelledBy:'modal-basic-title'}).result.then((result)=>{
        this.closeResualt='Closed with: ${resualt}';
      },(reason)=>{
        this.closeResualt='Dismissed ${this.getDismissReason(reason)}';

      });
    }
    private getDismissReason(reason:any){
      if(reason === ModalDismissReasons.ESC){
        return 'by pressing ESC'
      }
      else if(reason === ModalDismissReasons.BACKDROP_CLICK){
        return 'by clicking on a backdrop'
      }
      else{
        return 'with : ${reason}';
      }
    }
    onSubmit(f : NgForm){
      const url= '/api/Student/';
      this.HttpClient.post(url,f.value).subscribe((result)=>{
this.ngOnInit();
      });
      this.modalService.dismissAll();
    }
}
