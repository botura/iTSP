import { Http } from '@angular/http';
import { Component, OnInit, Inject } from '@angular/core';
import { CetelemService } from './cetelem.service';
import notify from 'devextreme/ui/notify';

@Component({
    selector: 'cetelem-carteira',
    templateUrl: 'carteiraatual.component.html',
    providers: [CetelemService]
})

export class CetelemCarteiraAtualComponent implements OnInit {
    public queryResult: any = [];
    public queryResultUf: any = [];
    public searching = false;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private dbService: CetelemService) {
    }

    ngOnInit() {
        this.populate();
    }

    populate() {
        this.searching = true;
        this.queryResultUf = null;
        this.queryResult = null;

        this.dbService.GetSomatoriaUf()
            .subscribe(result => this.queryResultUf = result);

        this.dbService.GetGrid()
            .finally(() => {
                notify("Dados atualizados", "success", 3000);
                this.searching = false;
            })
            .subscribe(result => this.queryResult = result)



    }
}
