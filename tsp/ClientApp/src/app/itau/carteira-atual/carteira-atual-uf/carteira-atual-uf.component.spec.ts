import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarteiraAtualUfComponent } from './carteira-atual-uf.component';

describe('CarteiraAtualUfComponent', () => {
  let component: CarteiraAtualUfComponent;
  let fixture: ComponentFixture<CarteiraAtualUfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarteiraAtualUfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarteiraAtualUfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
