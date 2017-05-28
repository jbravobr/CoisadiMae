using System.Linq;
using Xamarin.Forms;

namespace CoisadiMae.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            //lvtChat.BindingContextChanged += LvtChat_BindingContextChanged;
            lvtChat.PropertyChanged += LvtChat_PropertyChanged;
            lvtChat.DescendantAdded += LvtChat_DescendantAdded;
        }

        private void LvtChat_DescendantAdded(object sender, ElementEventArgs e)
        {
            lvtChat.ScrollTo(e.Element, ScrollToPosition.End, true);
        }

        private void LvtChat_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (lvtChat.ItemsSource != null)
            {
                object lastItem = null;
                foreach (var item in lvtChat.ItemsSource)
                {
                    lastItem = item;
                }

                lvtChat.ScrollTo(lastItem, ScrollToPosition.End, true);
            }
        }

        private void LvtChat_BindingContextChanged(object sender, System.EventArgs e)
        {
            //var x = Enumerable.Cast<Lis>
            object lastItem = null;
            foreach (var item in lvtChat.ItemsSource)
            {
                lastItem = item;
            }

            lvtChat.ScrollTo(lastItem, ScrollToPosition.End, true);
        }
    }
}