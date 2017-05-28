using Prism.Unity;
using System.Net.Http;
using CoisadiMae.ApplicationServices;
using CoisadiMae.Util.UIFunctions;
using CoisadiMae.Infrastructure.Repositories;
using CoisadiMae.Util.ConnectivityFunctions;
using Microsoft.Practices.Unity;
using CoisadiMae.Views;

namespace CoisadiMae
{
    public class App : PrismApplication
    {
        public static SQLite.SQLiteConnection AppConn { get; set; }
        public static HttpClient AppBaseHttpClient { get; set; }

        protected override void OnInitialized()
        {
            try
            {
                NavigationService.NavigateAsync("RootPage");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType(typeof(IApplicationService<>), typeof(ApplicationService<>));
            Container.RegisterType(typeof(IChatApplicationService), typeof(ChatApplicationService));
            Container.RegisterType(typeof(IDialogsFunction), typeof(DialogsFunction));
            Container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Container.RegisterType(typeof(IConnectivityFunctions), typeof(ConnectivityFunctions));

            Container.RegisterInstance(Acr.UserDialogs.UserDialogs.Instance);
            //Container.RegisterInstance(Plugin.Connectivity.CrossConnectivity.Current);

            Container.RegisterTypeForNavigation<ChatPage>();
            Container.RegisterTypeForNavigation<RootPage>();
            Container.RegisterTypeForNavigation<MenuPage>();
            Container.RegisterTypeForNavigation<BasePageNavigation>();
        }
    }
}