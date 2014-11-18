using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public class IndexCmd : Cmd<MainVM>
    {
        protected override bool SetUpSteps(MainVM viewModel)
        {
            Task<IEnumerable<Thing>> request = null;

            _execution = () => HandleExecution(viewModel, request);

            _error = (ex) => ExceptionHelper.DoSomething(ex);

            _ensure = () => viewModel.Remove(request);

            return true;
        }

        private async void HandleExecution(MainVM viewModel, Task<IEnumerable<Thing>> request)
        {
            var client = new ApiClient<Thing>();
            request = client.IndexAsync();
            viewModel.Add(request);

            foreach (var thing in await request)
            {
                viewModel.Add(new ThingVM(thing));
            }
        }
    }
}
