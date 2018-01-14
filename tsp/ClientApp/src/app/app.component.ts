import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'TSP';

  constructor(private router: Router) {
  }

  onHomeClick() {
    console.log('home');
    this.router.navigateByUrl('/home');
  }

  onItauCarteiraClick() {
    this.router.navigateByUrl('/pagina1');
  }

  onItauRecAssRejMisClick() {
    this.router.navigateByUrl('/pagina2');
  }
}
