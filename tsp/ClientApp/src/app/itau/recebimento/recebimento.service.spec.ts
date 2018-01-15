import { TestBed, inject } from '@angular/core/testing';

import { RecebimentoService } from './recebimento.service';

describe('RecebimentoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RecebimentoService]
    });
  });

  it('should be created', inject([RecebimentoService], (service: RecebimentoService) => {
    expect(service).toBeTruthy();
  }));
});
