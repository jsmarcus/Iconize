
using System;
using Xamarin.Forms;

namespace Iconize.Sample
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void ClickTest(object sender, EventArgs e)
        {
            (BindingContext as ModuleWrapper)?.ExecuteVisibleTest();
        }
    }
}
