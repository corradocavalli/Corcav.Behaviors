#if NETSTANDARD
using Xamarin.Forms;
#else
using Microsoft.Maui;
using Microsoft.Maui.Controls;
#endif

namespace Corcav.Behaviors
{
    /// <summary>
    /// An abstract implementation of a behavior.
    /// </summary>
    public abstract class Behavior : BindableObject, IBehavior
    {
        /// <summary>
        /// Gets the object associated with this behavior.
        /// </summary>
        /// <value>The associated object.</value>
        public virtual BindableObject AssociatedObject
        {
            get;
            private set;
        }

        /// <summary>
        /// Detach this behavior.
        /// </summary>
        public virtual void Detach()
        {
            OnDetach();
            AssociatedObject = null;
        }

        /// <summary>
        /// Attach this behavior to the given object.
        /// </summary>
        /// <param name="dependencyObject">The object to which this behavior will be attached.</param>
        public virtual void Attach(BindableObject dependencyObject)
        {
            AssociatedObject = dependencyObject;
            OnAttach();
        }

        /// <summary>
        /// Will be invoked when this behavior is attached.
        /// </summary>
        protected abstract void OnAttach();

        /// <summary>
        /// Will be invoked when this behavior is detached.
        /// </summary>
        protected abstract void OnDetach();
    }
}
