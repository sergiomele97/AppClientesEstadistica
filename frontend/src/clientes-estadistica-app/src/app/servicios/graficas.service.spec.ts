/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GraficasService } from './graficas.service';

describe('Service: Graficas', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GraficasService]
    });
  });

  it('should ...', inject([GraficasService], (service: GraficasService) => {
    expect(service).toBeTruthy();
  }));
});
