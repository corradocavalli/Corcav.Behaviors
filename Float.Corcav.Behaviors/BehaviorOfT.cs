using System;
using Xamarin.Forms;

namespace Corcav.Behaviors
{
    /// <summary>
    /// Represents a behavior that can be attached only to elements of type T.
    /// </summary>
    /// <typeparam name="T">The type of the element to which the behavior can be attached.</typeparam>
    public abstract class Behavior<T> : Behavior where T : BindableObject
    {
        /// <summary>
        /// Gets the associated object.
        /// </summary>
        /// <value>
        /// The associated object.
        /// </value>
        public new T AssociatedObject => base.AssociatedObject as T;

        /// <summary>
        /// Attaches the specified dependency object to this behavior.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <exception cref="InvalidOperationException">Raised when attached element doesn't match declared type.</exception>
        public override void Attach(BindableObject dependencyObject)
        {
            if (dependencyObject is not T t)
            {
                throw new InvalidOperationException($"This behavior can only be attached on '{typeof(T)}' instances.");
            }

            base.Attach(t);
        }
    }
}
