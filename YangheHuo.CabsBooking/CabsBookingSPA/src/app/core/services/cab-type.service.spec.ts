import { TestBed } from '@angular/core/testing';

import { CabTypeService } from './cab-type.service';

describe('CabTypeService', () => {
  let service: CabTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CabTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
