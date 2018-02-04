// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Iconize.Sample.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
                        
            LoadApplication(new Sample.Application());
        }
    }
}
