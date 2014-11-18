using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Api;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public class IndexCommand : Command<MainVM>
    {
        protected override async void Execute(MainVM viewModel)
        {
            Task<IEnumerable<Thing>> request = null;

            try
            {
                var client = new ApiClient<Thing>();
                request = client.IndexAsync();
                viewModel.Add(request);
                var things = await request;

                foreach (var thing in things)
                {
                    viewModel.Add(new ThingVM(thing));
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.DoSomething(ex);
            }
            finally
            {
                viewModel.Remove(request);
            }
        }
    }
}
