using Mics.Mobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mics.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                 new HomeMenuItem {Id = MenuItemType.Customers, Title="Customers" },
                new HomeMenuItem {Id = MenuItemType.Products, Title="Products" },
                 new HomeMenuItem {Id = MenuItemType.Orders, Title="Orders" },
                  new HomeMenuItem {Id = MenuItemType.Territories, Title="Territories" },
                new HomeMenuItem {Id = MenuItemType.Invoices, Title="Invoices" },
                new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings" },
                new HomeMenuItem {Id = MenuItemType.Download, Title="Download Data" },
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}