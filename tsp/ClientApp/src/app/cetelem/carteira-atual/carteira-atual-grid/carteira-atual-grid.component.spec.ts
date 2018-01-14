import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarteiraAtualGridComponent } from './carteira-atual-grid.component';

describe('CarteiraAtualGridComponent', () => {
  let component: CarteiraAtualGridComponent;
  let fixture: ComponentFixture<CarteiraAtualGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarteiraAtualGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarteiraAtualGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
