using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Demo.SessionState
{
    public static  class LocalStorage
    {
        public static ValueTask<T> GetAsync<T>(IJSRuntime jSRuntime,string key){
            return jSRuntime.InvokeAsync<T>("blazorLocalStorage.get",key);
        }

        public static ValueTask<T> SetAsync<T>(IJSRuntime jSRuntime,string key,object value){
            return jSRuntime.InvokeAsync<T>("blazorLocalStorage.set",key,value);
        }
        public static ValueTask<T> DeleteAsync<T>(IJSRuntime jSRuntime,string key){
            return jSRuntime.InvokeAsync<T>("blazorLocalStorage.delete",key);
        }
    }
}