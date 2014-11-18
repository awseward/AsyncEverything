using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Api;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public class GetAThingCommand : Command<MainVM>
    {
        protected async override void Execute(MainVM viewModel)
        {
            Task<Thing> request = null;

            try
            {
                var client = new ApiClient<Thing>();
                request = client.ShowAsync();
                viewModel.Requests.Add(request);

                var thing = new ThingVM(await request);
                viewModel.Add(thing);
            }
            catch (Exception ex)
            {
                ExceptionHelper.DoSomething(ex);
            }
            finally
            {
                viewModel.Requests.Remove(request);
            }
        }
    }
}
