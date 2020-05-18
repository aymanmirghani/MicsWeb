using Mics.Web.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mics.Mobile.ViewModels
{
    public class CustomerViewDetailsModel : BaseViewModel
    {
        public CustomerView Item { get; set; }

        public CustomerViewDetailsModel(CustomerView item = null)
        {
            Title = item.Name;
            Item = item;
        }


    }
}
