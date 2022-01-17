using Foundation;
using UIKit;

namespace Corcav.Behaviors.Demo.iOS
{
    /// <summary>
    /// The application delegate.
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        /// <inheritdoc />
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();

            // Added to prevent iOS linker to strip behaviors assembly out of deployed package.
            Infrastructure.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
