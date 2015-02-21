namespace Corcav.Behaviors
{
	using System;
	using Xamarin.Forms;

	/// <summary>
	/// Represents a behavior that can be attached only to elements of type <T>
	/// </summary>
	/// <typeparam name="T">The type of the element that behavior can be attached to</typeparam>
	public abstract class Behavior<T> : Behavior where T : BindableObject
	{

		/// <summary>
		/// Gets the associated object.
		/// </summary>
		/// <value>
		/// The associated object.
		/// </value>
		public T AssociatedObject
		{
			get
			{
				return base.AssociatedObject as T;
			}
		}

		/// <summary>
		/// Attaches the specified dependency object to this behavior.
		/// </summary>
		/// <param name="dependencyObject">The dependency object.</param>
		/// <exception cref="System.InvalidOperationException">Raised when attached element doesn't match declared type</exception>
		public override void Attach(BindableObject dependencyObject)
		{
			var t = dependencyObject as T;
			if (t == null)
			{
				throw new InvalidOperationException(string.Format("This behavior can only be attached on '{0}' instances.", typeof(T)));
			}
			base.Attach(dependencyObject);
		}

	}
}
