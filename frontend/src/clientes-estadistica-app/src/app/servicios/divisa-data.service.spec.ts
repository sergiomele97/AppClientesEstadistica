/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DivisaService } from './divisa.service';

describe('Service: DivisaData', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DivisaService]
    });
  });

  it('should ...', inject([DivisaService], (service: DivisaService) => {
    expect(service).toBeTruthy();
  }));
});
