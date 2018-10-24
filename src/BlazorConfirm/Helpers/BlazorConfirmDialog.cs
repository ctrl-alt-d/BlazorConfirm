using System;
using System.Threading.Tasks;

namespace ctrlaltd.SimpleBlazorComponents
{
    public interface IBlazorConfirmDialog : IDisposable
    {
        bool DontAskjJustExecute { get; set; }
        event Action OnSetFunc;
        Action OnSuccessDelegate { get; }
        string Message { get; }
        void NewDialog(string message = null, Action onSuccessDelegate = null);

        Task FixOnbeforeunload();
    }

    public class BlazorConfirmDialog : IBlazorConfirmDialog
    {
        public event Action OnSetFunc;
        public Action OnSuccessDelegate { get; protected set; }
        public string Message { get; protected set; }
        private bool _DontAskjJustExecute { get; set; } = true;
        public bool DontAskjJustExecute
        {
            get
            {
                return _DontAskjJustExecute;
            }
            set
            {
                _DontAskjJustExecute = value;
                Task.Run(async () =>
                {
                    await FixOnbeforeunload();
                });
            }
        }

        public void NewDialog(string message = null,
                              Action onSuccessDelegate = null)
        {
            OnSuccessDelegate = onSuccessDelegate;
            Message = message;
            if (DontAskjJustExecute)
            {
                OnSuccessDelegate?.Invoke();
            }
            else
            {
                OnSetFunc?.Invoke();
            }
        }

        public void Dispose()
        {
            OnSetFunc = null;
            OnSuccessDelegate = null;
            Message = null;
        }

        public async Task FixOnbeforeunload()
        {
            if (_DontAskjJustExecute)
            {
                await ConfirmExitJsInterop.UnsetOnbeforeunload();
            }
            else
            {
                await ConfirmExitJsInterop.SetOnbeforeunload();
            }
        }
    }
}