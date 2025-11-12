import { Component, inject, signal } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { Router, RouterLink, RouterLinkActive } from "@angular/router";
import { ToastService } from '../../core/services/toast-service';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.css'
})
export class Nav {
  protected accountservice = inject(AccountService);
  protected creds:any={};

  private router = inject(Router);
private toast = inject(ToastService);

  login(){
    this.accountservice.login(this.creds).subscribe({
      next:()=>{
        this.router.navigateByUrl('/members');
        this.toast.success('Logged in successfully');
        this.creds={};
      },
      error:error=>{
        this.toast.error(error.error);
      }
    })
  }

  logout(){
    this.accountservice.logout();
    this.router.navigateByUrl('/');
  }
}
