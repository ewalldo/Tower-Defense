using System.Collections;
using System.Collections.Generic;

public class CommandStack
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void Execute(ICommand command)
    {
        command.Execute();
        commandHistory.Push(command);
    }

    public void UndoLast()
    {
        if (commandHistory.Count <= 0)
        {
            return;
        }

        commandHistory.Pop().Undo();
    }
}
