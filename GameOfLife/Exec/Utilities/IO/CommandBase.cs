namespace GameOfLife.Exec.Utilities.IO
{
    internal abstract class CommandBase
    {
        public abstract object? Invoke();
    }

    internal class ActionCommand : CommandBase
    {
        private readonly Action action;
        public ActionCommand(Action action)
            => this.action = action;
        public override object? Invoke()
        {
            action();
            return null;
        }
    }
    internal class FuncCommand<T> : CommandBase
    {
        private readonly Func<T> func;
        public FuncCommand(Func<T> func)
            => this.func = func;
        public override object? Invoke()
            => func();
    }
}