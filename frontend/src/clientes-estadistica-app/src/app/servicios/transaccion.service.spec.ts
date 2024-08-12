/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TransaccionService } from './transaccion.service';

describe('Service: Transaccion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TransaccionService]
    });
  });

  it('should ...', inject([TransaccionService], (service: TransaccionService) => {
    expect(service).toBeTruthy();
  }));
});
