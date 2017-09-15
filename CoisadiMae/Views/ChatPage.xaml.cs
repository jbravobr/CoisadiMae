using CoisadiMae.ViewModels;
using System.Linq;
using Xamarin.Forms;

namespace CoisadiMae.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            lvtChat.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

            var context = (this.BindingContext as ChatPageViewModel);
            context.NewMessage = (messsage) =>
            {
                if (messsage != null)
                    lvtChat.ScrollTo(messsage, ScrollToPosition.End, true);
            };
        }


    }
}