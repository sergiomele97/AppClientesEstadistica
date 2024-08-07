/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EnviosService } from './envios.service';

describe('Service: Envios', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EnviosService]
    });
  });

  it('should ...', inject([EnviosService], (service: EnviosService) => {
    expect(service).toBeTruthy();
  }));
});
