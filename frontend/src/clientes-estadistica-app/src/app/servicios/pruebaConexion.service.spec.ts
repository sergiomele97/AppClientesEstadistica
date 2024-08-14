/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PruebaConexionService } from './pruebaConexion.service';

describe('Service: PruebaConexion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PruebaConexionService]
    });
  });

  it('should ...', inject([PruebaConexionService], (service: PruebaConexionService) => {
    expect(service).toBeTruthy();
  }));
});
