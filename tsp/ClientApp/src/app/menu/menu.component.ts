import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private router: Router) {
  }

  ngOnInit() {
  }

  onHomeClick() {
    this.router.navigateByUrl('/home');
  }

  onItauCarteiraClick() {
    this.router.navigateByUrl('/pagina1');
  }

  onItauRecAssRejMisClick() {
    this.router.navigateByUrl('/pagina2');
  }

  onCetelemCarteiraClick() {
    this.router.navigateByUrl('/cetelem-carteira-atual');
  }

}
