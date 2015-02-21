
namespace Corcav.Behaviors
{
	using Xamarin.Forms;

	/// <summary>
	/// Updates text while Entry text changes
	/// </summary>
	public class TextChangedBehavior : Behavior<Entry>
	{
		public static readonly BindableProperty TextProperty = BindableProperty.Create<TextChangedBehavior, string>(p => p.Text, null, propertyChanged: OnTextChanged);

		private static void OnTextChanged(BindableObject bindable, string oldvalue, string newvalue)
		{
			(bindable as TextChangedBehavior).AssociatedObject.Text = newvalue;
		}

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		protected override void OnAttach()
		{
			this.AssociatedObject.TextChanged += this.OnTextChanged;

		}

		private void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			this.Text = e.NewTextValue;
		}

		protected override void OnDetach()
		{
			this.AssociatedObject.TextChanged -= this.OnTextChanged;
		}
	}
}
