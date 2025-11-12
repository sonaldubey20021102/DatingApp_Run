import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RegisterCreds, User } from '../../../types/user';
import { AccountService } from '../../../core/services/account-service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {

  // membersFromHome = input.required<User[]>(); //passing data from home component using input decorator 

  private accountService = inject(AccountService);

  cancleRegister = output<boolean>();
  protected creds = {} as RegisterCreds;

  register() {
    // console.log(this.creds);
    this.accountService.register(this.creds).subscribe({
      next:response=>{
        console.log(response);
        this.cancel();
      },
      error:error=>console.log(error)
    })
  }

  cancel(){
    this.cancleRegister.emit(false);
  }
}
