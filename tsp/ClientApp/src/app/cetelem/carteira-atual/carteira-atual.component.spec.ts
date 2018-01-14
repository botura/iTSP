import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarteiraAtualComponent } from './carteira-atual.component';

describe('CarteiraAtualComponent', () => {
  let component: CarteiraAtualComponent;
  let fixture: ComponentFixture<CarteiraAtualComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarteiraAtualComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarteiraAtualComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
