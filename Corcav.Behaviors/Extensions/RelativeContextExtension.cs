
namespace Corcav.Behaviors
{
	using System;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;
	
	/// <summary>
	/// Custom markup extension that gets the BindingContext of a UI element
	/// </summary>
	[ContentProperty("Name")]
	public class RelativeContextExtension : IMarkupExtension
	{
		private BindableObject attachedObject;
		private Element rootElement;

		/// <summary>
		/// Gets or sets the element name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (serviceProvider == null) throw new ArgumentNullException("serviceProvider");
			IRootObjectProvider rootObjectProvider = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;
			if (rootObjectProvider == null) throw new ArgumentException("serviceProvider does not provide an IRootObjectProvider");
			if (string.IsNullOrEmpty(this.Name)) throw new ArgumentNullException("Name");


			Element nameScope = rootObjectProvider.RootObject as Element;
			Element element = nameScope.FindByName<Element>(this.Name);
			if (element == null) throw new ArgumentNullException(string.Format("Can't find element named '{0}'", this.Name));
			object context = element.BindingContext;

			this.rootElement = element;
			IProvideValueTarget ipvt = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
			this.attachedObject = ipvt.TargetObject as BindableObject;
			this.attachedObject.BindingContextChanged += this.OnContextChanged;

			return context ?? new object();
		}

		private void OnContextChanged(object sender, EventArgs e)
		{
			//If used with EventToCommand, markup extension automatically acts on CommandNameContext
			EventToCommand command = this.attachedObject as EventToCommand;
			if (command != null)
			{
				command.CommandNameContext = this.rootElement.BindingContext;
			}
			else
			{
				this.attachedObject.BindingContext = this.rootElement.BindingContext;
			}


		}
	}
}
