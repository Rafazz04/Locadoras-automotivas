/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LocadoraModelosComponent } from './locadoraModelos.component';

describe('LocadoraModelosComponent', () => {
  let component: LocadoraModelosComponent;
  let fixture: ComponentFixture<LocadoraModelosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LocadoraModelosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LocadoraModelosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
