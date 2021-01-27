using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Aplicacion_Prueba.Pages
{
    public partial class Index
    {
        [Inject] protected IJSRuntime JS { get; set; }
        protected string InputTextF = "";
        IJSObjectReference Module;
        ElementReference InputTextRef;

        protected override async Task OnInitializedAsync() 
        {
            Module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/Utilitario.js");
            await Task.Delay(2000);
            await Module.InvokeVoidAsync("Obtener", DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public void MostrarInfo(string dato) 
        {
            InputTextRef.FocusAsync();
            Console.WriteLine(dato);
            StateHasChanged();
        }
    }
}
