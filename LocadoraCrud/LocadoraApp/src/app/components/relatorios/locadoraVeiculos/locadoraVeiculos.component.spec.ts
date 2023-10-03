/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LocadoraVeiculosComponent } from './locadoraVeiculos.component';

describe('LocadoraVeiculosComponent', () => {
  let component: LocadoraVeiculosComponent;
  let fixture: ComponentFixture<LocadoraVeiculosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LocadoraVeiculosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LocadoraVeiculosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
