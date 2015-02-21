

namespace Corcav.Behaviors
{
	using Xamarin.Forms;
	/// <summary>
	/// Abstracts a behavior implementation
	/// </summary>
	public interface IBehavior
	{
		BindableObject AssociatedObject { get; }
		void Attach(BindableObject associatedObject);
		void Detach();
	}
}
