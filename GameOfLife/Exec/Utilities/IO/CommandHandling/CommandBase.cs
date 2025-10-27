namespace GameOfLife.Exec.Utilities.IO.CommandHandling
{
    internal abstract class CommandBase
    {
        public abstract object? Invoke(params object?[] args);
    }

    internal class ActionCommand(Action<object?[]> action) : CommandBase
    {
        public override object? Invoke(params object?[] args)
        {
            action(args);
            return null;
        }
    }
    internal class FuncCommand<T>(Func<object?[], T> func) : CommandBase
    {
        public override object? Invoke(params object?[] args)
            => func(args);
    }
}