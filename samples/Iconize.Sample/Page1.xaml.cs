using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Iconize.Sample
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Page1"/> class.
        /// </summary>
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