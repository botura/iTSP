import { Message } from 'primeng/primeng';
import { BreadcrumbService } from '../../breadcrumb.service';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-importar',
    templateUrl: './importar.component.html'
})

export class ImportarComponent {
    msgs: Message[];
    uploadedFiles: any[] = [];

    constructor(private breadcrumbService: BreadcrumbService) {
        this.breadcrumbService.setItems([
            { label: 'Cadastro' },
            { label: 'Importar' }
        ]);
    }

    onUpload(event) {
        for (const file of event.files) {
            this.uploadedFiles.push(file);
            console.log('Arquivo: ', file);
        }

        this.msgs = [];
        this.msgs.push({ severity: 'info', summary: 'File Uploaded', detail: '' });
    }

    myUploader(event) {
        // event.files == files to upload
        console.log(event);
    }

}
