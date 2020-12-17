import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { loginService } from "../services/login.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  formModel={
    UserName: "",
    Password: ""

  };

  constructor(private loginService: loginService, private router: Router) {}

  ngOnInit() {
    if (localStorage.getItem("token") != null)
      this.router.navigateByUrl("/home");
  }

  OnSubmit(form: NgForm) {
    this.loginService.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem("token", res.token);
        console.log(res.token);
        this.router.navigateByUrl("home");
      },
      err => {
        if (err.status == 400) {
          alert("incorrect username password");
        } else
          alert("Server side error");
      }
    );
  }

}
