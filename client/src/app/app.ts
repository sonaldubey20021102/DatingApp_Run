import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, Signal, signal } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { AccountService } from '../core/services/account-service';
import { Nav } from '../layout/nav/nav';
import { Home } from "../features/home/home";
import { User } from '../types/user';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Nav, RouterOutlet,NgClass],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {

  // private accountService = inject(AccountService)

  protected router = inject(Router)

  // private http = inject(HttpClient);

  // protected readonly title = signal('client');

  // protected members = signal<User[]>([]);

  // async ngOnInit() {
  //   this.members.set(await this.getMembers());
  //   // this.setCurrentUser();
  //   console.log(this.members());
  // }

  // setCurrentUser(){
  //   const userString = localStorage.getItem('user');
  //   if(!userString) return;
  //   const user = JSON.parse(userString);
  //   this.accountService.currentUser.set(user)
  // }

  // async getMembers() {
  //   try {
  //     return lastValueFrom(this.http.get<User[]>('https://localhost:5001/api/members'));
  //   } catch (err) {
  //     console.error(err);
  //     throw err;
  //   }
  // }
}
