import { Component, OnInit } from '@angular/core';
import { HttpService } from "../core/http/http.service";
import { Person } from "./person";
import 'rxjs/add/operator/finally';

@Component({
  templateUrl: './directory.component.html',
  styleUrls: ['./directory.component.scss']
})
export class DirectoryComponent implements OnInit {
  people: Array<Person>;
  loading: boolean;
  searchText: string;

  constructor(private http: HttpService) {
    this.people = [];
   }

  ngOnInit() {
    this.loadResults('/api/directory');
  }
  
  searchTextChanged(text: string) {
    this.searchText = text;
    this.people = [];
    this.loadResults('/api/directory/search?text=' + text + '&skip=0');
  }

  onScroll() {
    if (this.searchText) {
      this.loadResults('/api/directory/search?text=' + this.searchText + '&skip=' + this.people.length);    
    } else {
       this.loadResults('/api/directory/search?text=&skip=' + this.people.length);
    }
  }

  private loadResults(path: string) {
    this.loading = true;
    this.http.get<Array<Person>>(path)
      .finally(() => {
        this.loading = false;
      })  
      .subscribe((results) => {
          results.forEach((person: Person) => {
            this.people.push(person);
          });  
      });
  }

}
