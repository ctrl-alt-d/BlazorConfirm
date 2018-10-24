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

        private bool _IsSet { get; set; } = false;

        protected override async Task OnAfterRenderAsync()
        {
            if (!_IsSet)
            {
                _IsSet = true;
                BlazorConfirmDialog.OnSetFunc += Confirm;
                await BlazorConfirmDialog.FixOnbeforeunload();
            }
        }

        protected void Confirm()
        {

            Task.Run(async () =>
            {
                bool letsGo = await ConfirmExitJsInterop
                                    .ConfirmExit(BlazorConfirmDialog.Message ?? "Are you sure?");
                if (letsGo)
                {
                    BlazorConfirmDialog.OnSuccessDelegate?.Invoke();
                }
            });
        }
    }
}