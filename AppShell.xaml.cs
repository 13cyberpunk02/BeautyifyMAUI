using BeautyifyMAUI.Pages;

namespace BeautyifyMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("channellist", typeof(ChannelsListPage));
        }
    }
}
