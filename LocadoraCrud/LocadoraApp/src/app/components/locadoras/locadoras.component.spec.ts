/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LocadorasComponent } from './locadoras.component';

describe('LocadorasComponent', () => {
  let component: LocadorasComponent;
  let fixture: ComponentFixture<LocadorasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LocadorasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LocadorasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
