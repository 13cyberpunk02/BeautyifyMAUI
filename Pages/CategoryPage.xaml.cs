using BeautyifyMAUI.Models;
using BeautyifyMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace BeautyifyMAUI.Pages;

public partial class CategoryPage : ContentPage
{   
    public CategoryPage(CategoryViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}