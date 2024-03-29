using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        Notifiable,
        IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {            
            //Fail fast validation via command
            command.Validate();

            if(command.Invalid)
                return new GenericCommandResult(false, "Oops, incorrect task...", command.Notifications);

            var todo = new TodoItem(command.Title, command.Date, command.User);

            _repository.Create(todo);

            return new GenericCommandResult(true, "Your task has been saved!", todo);
        }
    }
}