import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecebimentoGridComponent } from './recebimento-grid.component';

describe('RecebimentoGridComponent', () => {
  let component: RecebimentoGridComponent;
  let fixture: ComponentFixture<RecebimentoGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecebimentoGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecebimentoGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
