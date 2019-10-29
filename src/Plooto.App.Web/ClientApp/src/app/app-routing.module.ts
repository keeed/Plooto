import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TodoListComponent } from './todo/todo-list/todo-list.component';
import { CreateTodoComponent } from './todo/create-todo/create-todo.component';
import { TodoDetailComponent } from './todo/todo-detail/todo-detail.component';


const routes: Routes = [
  {
    path: '', redirectTo: 'todos', pathMatch: 'full'
  },
  {
    path: 'todos', component: TodoListComponent
  },
  {
    path: 'create-todo', component: CreateTodoComponent
  },
  {
    path: 'todos/:id', component: TodoDetailComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
