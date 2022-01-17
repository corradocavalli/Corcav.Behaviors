using Xamarin.Forms;

namespace Corcav.Behaviors
{
    /// <summary>
    /// Updates text while Entry text changes.
    /// </summary>
    public class TextChangedBehavior : Behavior<Entry>
    {
        /// <summary>
        /// The bindable text property for this behavior.
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextChangedBehavior), propertyChanged: OnTextChanged);

        /// <summary>
        /// Gets or sets the text for this behavior.
        /// </summary>
        /// <value>The entry text.</value>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <inheritdoc />
        protected override void OnAttach()
        {
            AssociatedObject.TextChanged += OnTextChanged;
        }

        /// <inheritdoc />
        protected override void OnDetach()
        {
            AssociatedObject.TextChanged -= OnTextChanged;
        }

        static void OnTextChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue is string newstring)
            {
                (bindable as TextChangedBehavior).AssociatedObject.Text = newstring;
            }
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.Text = e.NewTextValue;
        }
    }
}
