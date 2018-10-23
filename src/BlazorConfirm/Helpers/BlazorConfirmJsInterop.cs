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
    }
}
