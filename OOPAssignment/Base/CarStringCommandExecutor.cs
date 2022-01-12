using OOPAssignment.IBase;
using System;

namespace OOPAssignment.Base
{
    public class CarStringCommandExecutor : CarCommandExecutorBase, IStringCommand
    {
        public CarStringCommandExecutor(ICarCommand CarCommand) : base(CarCommand)
        {
        }

        public void ExecuteCommand(string commandObject)
        {
            if (string.IsNullOrEmpty(commandObject))
                throw new Exception();


            foreach (char command in commandObject)
            {
                switch (command)
                {
                    case 'M':
                        CarCommand.Move();
                        break;
                    case 'R':
                        CarCommand.TurnRight();
                        break;
                    case 'L':
                        CarCommand.TurnLeft();
                        break;
                    default:
                        throw new Exception();
                }
            }

        }
    }
}
