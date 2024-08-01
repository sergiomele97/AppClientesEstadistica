/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { OutliersBarComponent } from './outliers-bar.component';

describe('OutliersBarComponent', () => {
  let component: OutliersBarComponent;
  let fixture: ComponentFixture<OutliersBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OutliersBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OutliersBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
