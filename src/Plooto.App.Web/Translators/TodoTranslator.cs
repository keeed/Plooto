namespace Plooto.App.Web.Translators
{
    public static class TodoTranslator
    {
        public static Core.Models.Todo Translate(Models.TodoDTO from)
        {
            return new Core.Models.Todo()
            {
                Id = from.Id,
                Name = from.Name,
                Completed = from.Completed
            };
        }

        public static Models.TodoDTO Translate(Core.Models.Todo from)
        {
            return new Models.TodoDTO()
            {
                Id = from.Id,
                Name = from.Name,
                Completed = from.Completed
            };
        }
    }
}