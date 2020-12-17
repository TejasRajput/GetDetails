import { Component } from '@angular/core';
import { HomeServices } from "../services/home.service";
import { Items } from "../models/Items";
import { ItemDetails } from '../models/ItemDetails';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {

  public items: Items[];

  public itemDetails: ItemDetails[];


  constructor(public readonly homeServices: HomeServices, private router: Router) { }

  public ngOnInit() {
    this.getItems();
  }

  public getItems() {
    this.homeServices.getItems().subscribe(results => {
      this.items = results;
    }, error => {
      alert('Server side error occured.');
    });
  }

  public getDetails(id:number) {
    this.homeServices.getItemDetails(id).subscribe(results => {
      this.itemDetails = results;
      return this.itemDetails; 
    }, error => {
     alert('Server side error occured.');
    });
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigateByUrl('login');
  }
}
