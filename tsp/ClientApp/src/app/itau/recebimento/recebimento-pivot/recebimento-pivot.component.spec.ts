import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecebimentoPivotComponent } from './recebimento-pivot.component';

describe('RecebimentoPivotComponent', () => {
  let component: RecebimentoPivotComponent;
  let fixture: ComponentFixture<RecebimentoPivotComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecebimentoPivotComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecebimentoPivotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
