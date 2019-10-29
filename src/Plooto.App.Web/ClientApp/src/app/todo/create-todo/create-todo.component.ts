import { Component, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { AddTodo } from '../todo.action';
import { Todo } from '../models/todo';

@Component({
  selector: 'app-create-todo',
  templateUrl: './create-todo.component.html',
  styleUrls: ['./create-todo.component.css']
})
export class CreateTodoComponent implements OnInit {

  todoForm = this.formBuilder.group({
    name: ['', [Validators.required]]
  });

  constructor(
    private formBuilder: FormBuilder,
    public store: Store) { }

  ngOnInit() {
  }

  onSubmit(form: FormGroupDirective) {
    this.store.dispatch(new AddTodo(
      new Todo(0, this.todoForm.value.name, false)
    )).subscribe({
      complete: () => {
        this.onClear(form);
      }
    });
  }

  onClear(form: FormGroupDirective) {
    form.resetForm({
      name: ''
    });
  }
}
