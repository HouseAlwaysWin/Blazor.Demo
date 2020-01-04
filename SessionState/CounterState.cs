using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Demo.SessionState {
    public class CounterState {
        private readonly IJSRuntime _jSRuntime;
        public CounterState(IJSRuntime jSRuntime){
           _jSRuntime = jSRuntime; 
        }

        private int _currentCount =0;
        public event EventHandler StateChanged;
        public int CurrentCount (){
            return _currentCount;
        }
      
        public async Task<int> GetCurrentCount () {
            try{
                _currentCount = await LocalStorage.GetAsync<int>(_jSRuntime,"CurrentCount");
            }catch(Exception ex){
                _currentCount = 0;
                SetCurrentCount(_currentCount);
            }
            return _currentCount;
        }

        public async void SetCurrentCount (int paramCount) {
            await LocalStorage.SetAsync<object>(_jSRuntime,"CurrentCount",paramCount);
            _currentCount = paramCount;
            StateHasChanged ();
        }

        public void ResetCurrentCount () {
            LocalStorage.SetAsync<object>(_jSRuntime,"CurrentCount",0);
            _currentCount = 0;
            StateHasChanged ();
        }

        private void StateHasChanged () {
            StateChanged?.Invoke (this, EventArgs.Empty);
        }
    }
}