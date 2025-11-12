import { Component, Input, input, signal } from '@angular/core';
import { Register } from "../account/register/register";
import { User } from '../../types/user';
import { required } from '@angular/forms/signals';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [Register],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {

  // @Input({required:true}) membersFromApp:User[]=[]; //passing data from app component using input decorator

  protected registerMode = signal(false);

  showregister(value:boolean){
    this.registerMode.set(value);
  }

}
