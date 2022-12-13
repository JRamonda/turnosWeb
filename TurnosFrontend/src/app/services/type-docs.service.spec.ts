/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TypeDocsService } from './type-docs.service';

describe('Service: TypeDocs', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TypeDocsService]
    });
  });

  it('should ...', inject([TypeDocsService], (service: TypeDocsService) => {
    expect(service).toBeTruthy();
  }));
});
