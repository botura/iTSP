import { ErrorHandler, Inject, NgZone, isDevMode } from '@angular/core';
// import { MessageService } from 'primeng/components/common/messageservice';

export class AppErrorHandler implements ErrorHandler {
    constructor(
        @Inject(NgZone) private ngZone: NgZone) {
        // @Inject(MessageService) private messageService: MessageService) {
    }

    handleError(error: any): void {
        // alert('Erro inesperado.');
        console.log('Erro by MB:');
        console.log(error);
        this.ngZone.run(() => {
            // this.messageService.add({
            //     severity: 'error', summary: 'Erro',
            //     detail: 'Alguma coisa deu errado.<br><br>Se não conseguir resolver, pergunte pro Matheus.'
            // });
        });
    }
}

