/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ClienteEstService } from './cliente-est.service';

describe('Service: ClienteEst', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ClienteEstService]
    });
  });

  it('should ...', inject([ClienteEstService], (service: ClienteEstService) => {
    expect(service).toBeTruthy();
  }));
});
