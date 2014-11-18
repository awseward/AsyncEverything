using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public class ShowCmd : Cmd<MainVM>
    {
        protected override bool SetUpSteps(MainVM viewModel)
        {
            Task<Thing> request = null;

            _execution = () => HandleExecution(viewModel, request);

            _error = (ex) => ExceptionHelper.DoSomething(ex);

            _ensure = () => viewModel.Remove(request);

            return true;
        }

        private async void HandleExecution(MainVM viewModel, Task<Thing> request)
        {
            var client = new ApiClient<Thing>();
            request = client.ShowAsync();
            viewModel.Add(request);

            var thing = new ThingVM(await request);
            viewModel.Add(thing);
        }
    }
}
