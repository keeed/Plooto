import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTodoComponent } from './create-todo.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxsModule } from '@ngxs/store';
import { TodoState } from '../todo.state';
import { HttpClientModule } from '@angular/common/http';

describe('CreateTodoComponent', () => {
  let component: CreateTodoComponent;
  let fixture: ComponentFixture<CreateTodoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CreateTodoComponent],
      imports: [
        ReactiveFormsModule,
        NgxsModule.forRoot([
          TodoState
        ]),
        HttpClientModule
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateTodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
