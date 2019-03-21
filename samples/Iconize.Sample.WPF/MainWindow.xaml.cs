using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace Iconize.Sample.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();

            Forms.Init();
            Plugin.Iconize.Iconize.Init();

            LoadApplication(new Sample.App());
        }
    }
}
