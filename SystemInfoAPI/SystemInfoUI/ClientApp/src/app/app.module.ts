import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { HomeServices } from "./services/home.service";
import { LoginComponent } from "./login/login.component";
import { loginService } from "./services/login.service";
import { AuthGuard } from "./auth/auth-guard.guard";
import { AuthInterCeptor } from "./auth/auth.intercepto";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: LoginComponent, pathMatch: "full" },
      { path: "login", component: LoginComponent, pathMatch: "full" },
      { path: "counter", component: CounterComponent },
      { path: "fetch-data", component: FetchDataComponent },
      { path: "home", component: HomeComponent, canActivate: [AuthGuard] }
    ])
  ],
  providers: [
    HomeServices, loginService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterCeptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
