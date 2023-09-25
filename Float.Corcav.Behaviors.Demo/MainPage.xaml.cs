using Corcav.Behaviors.Demo.ViewModels;
#if NETSTANDARD
using Xamarin.Forms;
#else
using Microsoft.Maui;
#endif

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
