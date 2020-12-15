import { Component } from '@angular/core';
import { HomeServices } from "../services/home.service";
import { Items } from "../models/Items";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public items: Items[];

  constructor(public readonly homeServices: HomeServices) { }

  public ngOnInit() {
    this.getItems();
  }

  public getItems() {
    this.homeServices.getItems().subscribe(results => {
      this.items = results;
      console.log(results);
    }, error => {
    });
  }
}
