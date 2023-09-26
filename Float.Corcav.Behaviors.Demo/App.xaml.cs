#if NETSTANDARD
using Xamarin.Forms;
#else
using Microsoft.Maui;
#endif

namespace Corcav.Behaviors.Demo
{
    /// <summary>
    /// The application.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        /// <inheritdoc />
        protected override void OnStart()
        {
        }

        /// <inheritdoc />
        protected override void OnSleep()
        {
        }

        /// <inheritdoc />
        protected override void OnResume()
        {
        }
    }
}
