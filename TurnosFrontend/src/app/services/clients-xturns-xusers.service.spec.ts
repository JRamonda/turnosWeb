import { TestBed } from '@angular/core/testing';

import { ClientsXTurnsXUsersService } from './clients-xturns-xusers.service';

describe('ClientsXTurnsXUsersService', () => {
  let service: ClientsXTurnsXUsersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClientsXTurnsXUsersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
