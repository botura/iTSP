import { AuthService } from '../services/auth/auth.service';
import { Component } from '@angular/core';
import { AppComponent } from './app.component';

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html'
})
export class AppTopBarComponent {

    constructor(public app: AppComponent, public auth: AuthService) {
        // if (!auth.isAuthenticated()) {
        //     auth.logout();
        // }
    }
}
