import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public movies?: Movie[];
  public directors?: Director[];

  constructor(http: HttpClient) {
    // get all directors
    http.get<Director[]>('/api/v1/Directors').subscribe(result => {
      this.directors = result;
    }, error => console.error(error));

    // get all movies
    http.get<Movie[]>('/api/v1/Movies').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  }

  title = 'angularproject3';
}

interface Director {
  name: string;
  nationality: string;
  age: number;
  active: number;
}

interface Movie {
  name: string;
  releaseYear: string;
  gender: string;
  duration: string;
  directorId: number;
}
