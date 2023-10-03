/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MontadorasComponent } from './montadoras.component';

describe('MontadorasComponent', () => {
  let component: MontadorasComponent;
  let fixture: ComponentFixture<MontadorasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MontadorasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MontadorasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
