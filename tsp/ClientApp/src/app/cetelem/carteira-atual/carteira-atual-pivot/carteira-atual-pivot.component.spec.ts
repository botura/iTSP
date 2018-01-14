import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarteiraAtualPivotComponent } from './carteira-atual-pivot.component';

describe('CarteiraAtualPivotComponent', () => {
  let component: CarteiraAtualPivotComponent;
  let fixture: ComponentFixture<CarteiraAtualPivotComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarteiraAtualPivotComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarteiraAtualPivotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
