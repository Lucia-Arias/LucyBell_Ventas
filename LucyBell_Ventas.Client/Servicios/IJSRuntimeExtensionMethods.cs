using Microsoft.JSInterop;

namespace LucyBell_Ventas.Client.Servicios
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirmar(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<bool>("confirm", mensaje);
        }

        public static ValueTask<object> GuardarEnLocalStorage(this IJSRuntime js,
            string llave, string contenido)
        {
            return js.InvokeAsync<object>("localStorage.setItem", llave, contenido);
        }

        public static ValueTask<object> ObtenerDeLocalStorage(this IJSRuntime js,
            string llave)
        {
            return js.InvokeAsync<object>("localStorage.getItem", llave);
        }

        public static ValueTask<object> RemoverDelLocalStorage(this IJSRuntime js,
            string llave)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", llave);
        }
    }
}
