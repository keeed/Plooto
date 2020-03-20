import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TodoDetailComponent } from './todo-detail.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { TodoListComponent } from '../todo-list/todo-list.component';
import { CreateTodoComponent } from '../create-todo/create-todo.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxsModule } from '@ngxs/store';
import { TodoState } from '../todo.state';
import { HttpClientModule } from '@angular/common/http';

describe('TodoDetailComponent', () => {
  let component: TodoDetailComponent;
  let fixture: ComponentFixture<TodoDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TodoDetailComponent, TodoListComponent, CreateTodoComponent],
      imports: [
        AppRoutingModule,
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
    fixture = TestBed.createComponent(TodoDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
