using System.Linq;
using Xamarin.Forms;

namespace CoisadiMae.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            lvtChat.ItemSelected+= (sender, e) => {
                ((ListView)sender).SelectedItem = null;
            };
        }

       
    }
}