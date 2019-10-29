import { Component, OnInit } from '@angular/core';
import { Store, Select } from '@ngxs/store';
import { TodoState, TodoStateModel } from '../todo.state';
import { Observable } from 'rxjs';
import { GetAllTodos, UpdateTodo } from '../todo.action';
import { Todo } from '../models/todo';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  @Select(TodoState.todos) todos$: Observable<Todo[]>;

  constructor(public store: Store) { }

  ngOnInit() {
    this.getTodos();
  }

  getTodos() {
    this.store.dispatch(new GetAllTodos());
  }

  updateTodo(todo: Todo, isChecked: boolean) {
    this.store.dispatch(
      new UpdateTodo(
        new Todo(
          todo.id,
          todo.name,
          isChecked)));
  }
}
