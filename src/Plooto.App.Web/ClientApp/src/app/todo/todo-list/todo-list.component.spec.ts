import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TodoListComponent } from './todo-list.component';
import { CreateTodoComponent } from '../create-todo/create-todo.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { TodoDetailComponent } from '../todo-detail/todo-detail.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxsModule } from '@ngxs/store';
import { TodoState } from '../todo.state';
import { HttpClientModule } from '@angular/common/http';

describe('TodoListComponent', () => {
  let component: TodoListComponent;
  let fixture: ComponentFixture<TodoListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        TodoListComponent,
        CreateTodoComponent,
        TodoDetailComponent
      ],
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
    fixture = TestBed.createComponent(TodoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
