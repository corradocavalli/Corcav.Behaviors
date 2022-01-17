using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Corcav.Behaviors
{
    /// <summary>
    /// Custom markup extension that gets the BindingContext of a UI element.
    /// </summary>
    [ContentProperty("Name")]
    public class RelativeContextExtension : IMarkupExtension
    {
        BindableObject attachedObject;
        Element rootElement;

        /// <summary>
        /// Gets or sets the element name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Provide a new attached object that will be retrieved from the value provider in the given service provider.
        /// </summary>
        /// <param name="serviceProvider">The provider of services.</param>
        /// <returns>The provided root object or a new object if the root object is null.</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            if (serviceProvider.GetService(typeof(IRootObjectProvider)) is not IRootObjectProvider rootObjectProvider)
            {
                throw new ArgumentException("serviceProvider does not provide an IRootObjectProvider");
            }

            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Name");
            }

            var nameScope = rootObjectProvider.RootObject as Element;

            if (nameScope.FindByName<Element>(Name) is not Element element)
            {
                throw new ArgumentNullException($"Can't find element named '{Name}'");
            }

            var context = element.BindingContext;
            rootElement = element;

            if (serviceProvider.GetService(typeof(IProvideValueTarget)) is not IProvideValueTarget ipvt)
            {
                throw new ArgumentException("serviceProvider does not provide an IProvideValueTarget");
            }

            attachedObject = ipvt.TargetObject as BindableObject;
            attachedObject.BindingContextChanged += OnContextChanged;

            return context ?? new object();
        }

        void OnContextChanged(object sender, EventArgs e)
        {
            // if used with EventToCommand, markup extension automatically acts on CommandNameContext
            if (attachedObject is EventToCommand command)
            {
                command.CommandNameContext = rootElement.BindingContext;
            }
            else
            {
                attachedObject.BindingContext = rootElement.BindingContext;
            }
        }
    }
}
