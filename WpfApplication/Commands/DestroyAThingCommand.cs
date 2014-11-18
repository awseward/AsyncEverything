using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Api;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public class DestroyAThingCommand : Command<ThingVM>
    {
        public override bool CanExecute(object parameter)
        {
            // Bad
            return true;
        }

        protected override async void Execute(ThingVM viewModel)
        {
            Task<bool> request = null;

            try
            {
                var client = new ApiClient<Thing>();
                request = client.DestroyAsync(viewModel.ToThing());
                viewModel.Add(request);

                var deleted = await request;
                if (deleted && viewModel.MainVM != null)
                {
                    viewModel.MainVM.Remove(viewModel);
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
