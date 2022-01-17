using Xamarin.Forms;

namespace Corcav.Behaviors
{
    /// <summary>
    /// Abstracts a behavior implementation.
    /// </summary>
    public interface IBehavior
    {
        /// <summary>
        /// Gets the associated bindable object.
        /// </summary>
        /// <value>The associated bindable.</value>
        BindableObject AssociatedObject { get; }

        /// <summary>
        /// Attach to the given object.
        /// </summary>
        /// <param name="associatedObject">The object to which this behavior should be attached.</param>
        void Attach(BindableObject associatedObject);

        /// <summary>
        /// Detach from any objects.
        /// </summary>
        void Detach();
    }
}
