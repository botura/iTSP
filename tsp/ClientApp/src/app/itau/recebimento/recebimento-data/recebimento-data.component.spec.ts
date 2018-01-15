import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecebimentoDataComponent } from './recebimento-data.component';

describe('RecebimentoDataComponent', () => {
  let component: RecebimentoDataComponent;
  let fixture: ComponentFixture<RecebimentoDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecebimentoDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecebimentoDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
