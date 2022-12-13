import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyTurnComponent } from './my-turn.component';

describe('MyTurnComponent', () => {
  let component: MyTurnComponent;
  let fixture: ComponentFixture<MyTurnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyTurnComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyTurnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
