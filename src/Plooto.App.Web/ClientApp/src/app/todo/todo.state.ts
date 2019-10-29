import { Todo } from './models/todo';
import { State, Selector, Action, StateContext } from '@ngxs/store';
import { TodoService } from './todo.service';
import { GetAllTodos, AddTodo, GetTodo, DeleteTodo, UpdateTodo } from './todo.action';
import { tap } from 'rxjs/operators';

export interface TodoStateModel {
    todos: Todo[];
    todo: Todo;
}

@State<TodoStateModel>({
    name: 'todos',
    defaults: {
        todos: [],
        todo: null
    }
})
export class TodoState {
    constructor(public todoService: TodoService) {
    }

    @Selector()
    static todos(stateModel: TodoStateModel) {
        return stateModel.todos;
    }

    @Selector()
    static todo(stateModel: TodoStateModel) {
        return stateModel.todo;
    }

    @Action(GetAllTodos)
    getTodos(ctx: StateContext<TodoStateModel>, action: GetAllTodos) {
        return this.todoService.getTodos().pipe(
            tap(response => {
                const state = ctx.getState();
                ctx.patchState({
                    ...state,
                    todos: response
                });
            })
        );
    }

    @Action(GetTodo)
    getTodo(ctx: StateContext<TodoStateModel>, action: GetTodo) {
        return this.todoService.getTodo(action.id).pipe(
            tap(response => {
                const state = ctx.getState();
                ctx.patchState({
                    ...state,
                    todo: response
                });
            })
        );
    }

    @Action(AddTodo)
    addTodo(ctx: StateContext<TodoStateModel>, action: AddTodo) {
        return this.todoService.addTodo(action.todo)
            .subscribe({
                next: (todo) => {
                    const state = ctx.getState();
                    ctx.patchState({
                        todos: [
                            ...state.todos,
                            todo
                        ]
                    });
                }
            });
    }

    @Action(DeleteTodo)
    deleteTodo(ctx: StateContext<TodoStateModel>, action: DeleteTodo) {
        return this.todoService.deleteTodo(action.id)
            .subscribe({
                next: (todo) => {
                    const state = ctx.getState();
                }
            });
    }

    @Action(UpdateTodo)
    updateTodo(ctx: StateContext<TodoStateModel>, action: UpdateTodo) {
        return this.todoService.updateTodo(action.todo)
            .subscribe({
                next: (todo) => {
                    const state = ctx.getState();
                    ctx.dispatch(new GetAllTodos());
                }
            });
    }
}
