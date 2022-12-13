import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnsManagerComponent } from './turns-manager.component';

describe('TurnsManagerComponent', () => {
  let component: TurnsManagerComponent;
  let fixture: ComponentFixture<TurnsManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TurnsManagerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TurnsManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
