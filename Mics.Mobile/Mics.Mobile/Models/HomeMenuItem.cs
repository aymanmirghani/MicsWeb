using System;
using System.Collections.Generic;
using System.Text;

namespace Mics.Mobile.Models
{
    public enum MenuItemType
    {
        Orders,
        Customers,
        Products,
        Territories,
        Invoices,
        Settings,
        Browse,
        About,
        Download,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
