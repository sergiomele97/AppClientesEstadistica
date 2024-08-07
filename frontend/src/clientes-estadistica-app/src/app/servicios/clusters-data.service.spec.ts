/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ClustersDataService } from './clusters-data.service';

describe('Service: ClustersData', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ClustersDataService]
    });
  });

  it('should ...', inject([ClustersDataService], (service: ClustersDataService) => {
    expect(service).toBeTruthy();
  }));
});
