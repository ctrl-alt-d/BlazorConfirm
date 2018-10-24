using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ctrlaltd.SimpleBlazorComponents
{
    public class ConfirmExitJsInterop
    {
        public static Task<bool> ConfirmExit(string message)
        {
            return JSRuntime.Current.InvokeAsync<bool>(
                "blazorConfirmJsFunctions.blazorConfirm",
                message);
        }

        public static Task SetOnbeforeunload()
        {
            return JSRuntime.Current.InvokeAsync<System.Action>(
                "blazorConfirmJsFunctions.setOnbeforeunload"
                );
        }

        public static Task UnsetOnbeforeunload()
        {
            return JSRuntime.Current.InvokeAsync<System.Action>(
                "blazorConfirmJsFunctions.unsetOnbeforeunload"
                );
        }
    }
}
