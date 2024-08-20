/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { DivisasComponent } from './divisas.component';

describe('DivisePredictionComponent', () => {
  let component: DivisasComponent;
  let fixture: ComponentFixture<DivisasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DivisasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DivisasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
