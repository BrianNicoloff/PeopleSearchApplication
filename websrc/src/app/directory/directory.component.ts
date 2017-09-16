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
  constructor(private http: HttpService) {
    this.people = [];
   }

  ngOnInit() {
    this.loading = true;
    this.http.get<Array<Person>>('/api/directory?skip=0')
      .finally(() => {
        this.loading = false;
      })  
      .subscribe((results) => {
        // if (results) {
          results.forEach((person: Person) => {
            this.people.push(person);
          });  
        // }
      });
  }
  
}
