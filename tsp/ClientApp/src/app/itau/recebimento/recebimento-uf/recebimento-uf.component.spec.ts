import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecebimentoUfComponent } from './recebimento-uf.component';

describe('RecebimentoUfComponent', () => {
  let component: RecebimentoUfComponent;
  let fixture: ComponentFixture<RecebimentoUfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecebimentoUfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecebimentoUfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
