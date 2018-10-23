# BlazorConfirm

A Blazor wrapper of [Window.confirm()](https://developer.mozilla.org/en-US/docs/Web/API/Window/confirm) as .Net Blazor Component. 

The sample project has been published [here](https://github.com/BlazorConfirm/).

## ScreenShot and Demo

Because we love screen shots and [demo](https://goo.gl/k1swZb)

![BlazorConfig ScreenShot](./ScreenShots/BlazorConfirm.gif)


## Changes

- version 0.6.0
  - initial version for blazor 0.6.0


## Configuration

* `dotnet add package BlazorConfirm --version 0.6.0`
* `Install-Package BlazorConfirm -Version 0.6.0`
* `paket add BlazorConfirm --version 0.6.0`


## Configure the dependency injection

```c#
using ctrlaltd.SimpleBlazorComponents;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddSingleton<IBlazorConfirmDialog, BlazorConfirmDialog>();
        }
```

and add the component to `App.cshtml` (or to another component always loaded in the application)

```c#
@addTagHelper *, BlazorConfirm
<BlazorConfirmContainer />

<Router AppAssembly=typeof(Program).Assembly />
```

## Usage

In a component

```c#
@inject ctrlaltd.SimpleBlazorComponents.IBlazorConfirmDialog blazorConfirmDialog
```

In a class

```c#
[Inject] 
protected ctrlaltd.SimpleBlazorComponents.IBlazorConfirmDialog blazorConfirmDialog { get; set; }
```

Wrap your function into the dialog:

```c#
    void IncrementCount()
    {
        blazorConfirmDialog.NewDialog( message: "Are you sure do you want to increment the counter?", 
                                       onSuccessDelegate: ( () => {currentCount++;
                                                                   StateHasChanged();
                                                                   } ) );
    }
```

Confirm navigate:

```c#
    blazorConfirmDialog.NewDialog( onSuccessDelegate: ( () => {UriHelper.NavigateTo(  "/fetchdata" ); } ) );
```

## Credits

Dani Herrera

## License

BlazorConfirm is licensed under [MIT license](http://www.opensource.org/licenses/mit-license.php)

### Special Thanks

Thankyou to [@ghidello](https://github.com/ghidello) and  https://github.com/sotsera/sotsera.blazor.toaster repo.
