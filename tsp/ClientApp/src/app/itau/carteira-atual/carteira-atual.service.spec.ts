import { TestBed, inject } from '@angular/core/testing';

import { CarteiraAtualService } from './carteira-atual.service';

describe('ItauService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ CarteiraAtualService ]
    });
  });

  it('should be created', inject([CarteiraAtualService], (service: CarteiraAtualService) => {
    expect(service).toBeTruthy();
  }));
});
