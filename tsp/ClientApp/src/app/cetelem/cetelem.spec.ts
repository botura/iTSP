import { TestBed, inject } from '@angular/core/testing';

import { CetelemService } from './cetelem.service';

describe('CarteiraAtualService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CetelemService]
    });
  });

  it('should be created', inject([CetelemService], (service: CetelemService) => {
    expect(service).toBeTruthy();
  }));
});
