namespace Plooto.Repositories.EFCore.Translators
{
    public static class TodoTranslator
    {
        public static Core.Models.Todo Translate(Repositories.EFCore.Models.Todo from)
        {
            return new Core.Models.Todo()
            {
                Id = from.Id,
                Name = from.Name,
                Completed = from.Completed
            };
        }

        public static Repositories.EFCore.Models.Todo Translate(Core.Models.Todo from)
        {
            return new Repositories.EFCore.Models.Todo()
            {
                Id = from.Id,
                Name = from.Name,
                Completed = from.Completed
            };
        }
    }
}