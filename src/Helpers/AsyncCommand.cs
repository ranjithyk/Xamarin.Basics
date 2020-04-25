using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Xamarin.Basics.Helpers
{
    public delegate Task ActionAsync();
    public delegate Task ActionAsync<in T>(T obj);
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter = null);
    }

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class AsyncCommand<T> : AsyncCommand
    {
        public AsyncCommand(ActionAsync<T> execute)
            : base(async (o) =>
            {
                if (IsValidParameter(o))
                {
                    await execute((T)o);
                }
            })
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
        }

        public AsyncCommand(ActionAsync<T> execute, Func<T, bool> canExecute)
            : base(async (o) =>
            {
                if (IsValidParameter(o))
                {
                    await execute((T)o);
                }
            }, o => IsValidParameter(o) && canExecute((T)o))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        static bool IsValidParameter(object o)
        {
            if (o != null)
            {
                // The parameter isn't null, so we don't have to worry whether null is a valid option
                return o is T;
            }

            var t = typeof(T);

            // The parameter is null. Is T Nullable?
            if (Nullable.GetUnderlyingType(t) != null)
            {
                return true;
            }

            // Not a Nullable, if it's a value type then null is not valid
            return !t.GetTypeInfo().IsValueType;
        }
    }

    public class AsyncCommand : IAsyncCommand
    {
        readonly Func<object, bool> _canExecute;
        readonly ActionAsync<object> _executeAsync;
        bool _isBusy;

        #region Async CTR

        public AsyncCommand(ActionAsync<object> execute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _executeAsync = execute;
        }

        public AsyncCommand(ActionAsync execute) : this(o => execute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        public AsyncCommand(ActionAsync<object> execute, Func<object, bool> canExecute) : this(o => execute(o))
        {
            if (canExecute == null)
                throw new ArgumentNullException(nameof(execute));

            _canExecute = canExecute;
        }

        public AsyncCommand(ActionAsync execute, Func<bool> canExecute) : this(o => execute(), (arg) => canExecute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }
        #endregion


        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        public event EventHandler CanExecuteChanged;

        public async Task ExecuteAsync(object parameter = null)
        {
            try
            {
                if (!_isBusy && CanExecute(parameter))
                {
                    _isBusy = true;

                    await _executeAsync(parameter);

                    _isBusy = false;
                }
            }
            catch (Exception)
            {
                _isBusy = false;
            }
        }

        public void ChangeCanExecute()
        {
            EventHandler changed = CanExecuteChanged;
            changed?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            if (_executeAsync != null)
                 _= ExecuteAsync(parameter);
        }
    }
}
