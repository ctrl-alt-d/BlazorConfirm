using System;

namespace ctrlaltd.SimpleBlazorComponents
{
    public interface IBlazorConfirmDialog: IDisposable
    {
        bool DontAskjJustExecute {get; set;}
        event Action OnSetFunc;
        Action OnSuccessDelegate { get;    }
        string Message { get;  }
        void NewDialog( string message = null, Action onSuccessDelegate = null );
    }

    public class BlazorConfirmDialog : IBlazorConfirmDialog
    {
        public event Action OnSetFunc;
        public Action OnSuccessDelegate { get; protected set;  }
        public string Message { get;  protected set; }
        public bool DontAskjJustExecute {get; set;} = false;

        public void NewDialog( string message = null, 
                              Action onSuccessDelegate = null )
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
    }
}