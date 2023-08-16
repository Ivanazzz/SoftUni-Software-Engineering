namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split();

            string commandName = input[0];
            string[] value = input.Skip(1).ToArray();

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName + "Command");

            if (type == null)
            {
                throw new InvalidOperationException("Missing command");
            } 

            Type commandInterface = type.GetInterface("ICommand");
            if (commandInterface == null)
            {
                throw new InvalidOperationException("Not a command");
            }

            ICommand command = Activator.CreateInstance(type) as ICommand;

            string result = command.Execute(value);

            return result;
        }
    }
}
