import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OutliersDetailComponent } from './outliers-detail.component';

describe('OutliersDetailComponent', () => {
  let component: OutliersDetailComponent;
  let fixture: ComponentFixture<OutliersDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OutliersDetailComponent]
    });
    fixture = TestBed.createComponent(OutliersDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
