using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace ctrlaltd.SimpleBlazorComponents
{

    public class BlazorConfirmContainerBase : BlazorComponent
    {

        [Inject] protected IBlazorConfirmDialog BlazorConfirmDialog { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            BlazorConfirmDialog.OnSetFunc += Confirm;
        }

        protected void Confirm()
        {

            Task.Run(async () =>
            {
                bool letsGo = await ConfirmExitJsInterop
                                    .ConfirmExit(BlazorConfirmDialog.Message ?? "Are you sure?");
                if (letsGo) {
                    BlazorConfirmDialog.OnSuccessDelegate?.Invoke();
                }
            });
        }
    }
}