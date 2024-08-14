/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { OutlierComponent } from './outlier.component';

describe('OutlierComponent', () => {
  let component: OutlierComponent;
  let fixture: ComponentFixture<OutlierComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OutlierComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OutlierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
