/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LocadoraService } from './locadora.service';

describe('Service: Locadora', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LocadoraService]
    });
  });

  it('should ...', inject([LocadoraService], (service: LocadoraService) => {
    expect(service).toBeTruthy();
  }));
});
