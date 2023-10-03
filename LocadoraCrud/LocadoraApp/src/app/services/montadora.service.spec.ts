/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MontadoraService } from './montadora.service';

describe('Service: Montadora', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MontadoraService]
    });
  });

  it('should ...', inject([MontadoraService], (service: MontadoraService) => {
    expect(service).toBeTruthy();
  }));
});
