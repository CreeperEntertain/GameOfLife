namespace GameOfLife.Exec.Utilities.IO
{
    internal abstract class CommandBase
    {
        public abstract object? Invoke(params object?[] args);
    }

    internal class ActionCommand : CommandBase
    {
        private readonly Action<object?[]> action;
        public ActionCommand(Action<object?[]> action)
            => this.action = action;
        public override object? Invoke(params object?[] args)
        {
            action(args);
            return null;
        }
    }
    internal class FuncCommand<T> : CommandBase
    {
        private readonly Func<object?[], T> func;
        public FuncCommand(Func<object?[], T> func)
            => this.func = func;
        public override object? Invoke(params object?[] args)
            => func(args);
    }
}