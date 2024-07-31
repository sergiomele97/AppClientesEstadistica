/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { OutliersComponent } from './outliers.component';

describe('OutliersComponent', () => {
  let component: OutliersComponent;
  let fixture: ComponentFixture<OutliersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OutliersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OutliersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
