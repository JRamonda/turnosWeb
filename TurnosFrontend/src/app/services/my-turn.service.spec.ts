/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MyTurnService } from './my-turn.service';

describe('Service: MyTurn', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MyTurnService]
    });
  });

  it('should ...', inject([MyTurnService], (service: MyTurnService) => {
    expect(service).toBeTruthy();
  }));
});
