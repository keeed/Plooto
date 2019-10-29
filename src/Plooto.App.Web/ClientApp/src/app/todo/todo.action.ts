import { Todo } from './models/todo';

export class GetAllTodos {
    static readonly type = '[Todo] Get All Todos';
}

export class GetTodo {
    static readonly type = '[Todo] Get Todo';
    constructor(public id: number) { }
}

export class AddTodo {
    static readonly type = '[Todo] Add Todo';
    constructor(public todo: Todo) { }
}

export class DeleteTodo {
    static readonly type = '[Todo] Delete Todo';
    constructor(public id: number) { }
}

export class UpdateTodo {
    static readonly type = '[Todo] Update Todo';
    constructor(public todo: Todo) { }
}
