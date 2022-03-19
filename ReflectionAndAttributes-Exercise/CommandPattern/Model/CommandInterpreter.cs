using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = input[0] + "Command" ;

            string[] value = input.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }

            ICommand command = Activator.CreateInstance(type) as ICommand;
            
            //switch (input[0])
            //{
            //    case "HelloCommand":
            //        command = new HelloCommand();
            //        break;
            //    case "ExitCommand":
            //        command = new ExitCommand();
            //        break;
            //    default:
            //        throw new ArgumentException("Invalid command");
            //}

            string result =  command.Execute(value);

            return result;
        }
    }
}