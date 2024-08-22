import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogsOutlierComponent } from './logs-outlier.component';

describe('LogsOutlierComponent', () => {
  let component: LogsOutlierComponent;
  let fixture: ComponentFixture<LogsOutlierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LogsOutlierComponent]
    });
    fixture = TestBed.createComponent(LogsOutlierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
