/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { VolumetriaComponent } from './volumetria.component';

describe('VolumetriaComponent', () => {
  let component: VolumetriaComponent;
  let fixture: ComponentFixture<VolumetriaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VolumetriaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VolumetriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
