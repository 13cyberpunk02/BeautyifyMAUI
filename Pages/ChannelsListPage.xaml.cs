using BeautyifyMAUI.ViewModels;

namespace BeautyifyMAUI.Pages;

public partial class ChannelsListPage : ContentPage
{
    public ChannelsListPage(ChannelsListViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}