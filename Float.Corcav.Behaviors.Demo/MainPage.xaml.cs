using Corcav.Behaviors.Demo.ViewModels;
using Xamarin.Forms;

namespace Corcav.Behaviors.Demo
{
    /// <summary>
    /// The main view.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
