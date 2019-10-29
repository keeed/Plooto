import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store, Select } from '@ngxs/store';
import { GetTodo, DeleteTodo } from '../todo.action';
import { TodoState } from '../todo.state';
import { Observable } from 'rxjs';
import { Todo } from '../models/todo';

@Component({
  selector: 'app-todo-detail',
  templateUrl: './todo-detail.component.html',
  styleUrls: ['./todo-detail.component.css']
})
export class TodoDetailComponent implements OnInit {

  @Select(TodoState.todo) todo$: Observable<Todo>;

  todo: Todo;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    public store: Store) { }

  ngOnInit() {
    this.todo$.subscribe(todo => {
      this.todo = todo;
    });

    this.getTodo();
  }

  getTodo() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.store.dispatch(new GetTodo(id));
  }

  delete() {
    this.store.dispatch(new DeleteTodo(this.todo.id))
      .subscribe({
        complete: () => {
          this.router.navigateByUrl('');
        }
      });
  }
}
