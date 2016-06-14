
namespace Corcav.Behaviors
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Reflection;
	using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>
	/// Invoked a command when an event raises
	/// </summary>
	public class EventToCommand : Behavior
	{
		public static readonly BindableProperty EventNameProperty = BindableProperty.Create<EventToCommand, string>(p => p.EventName, null);
		public static readonly BindableProperty CommandProperty = BindableProperty.Create<EventToCommand, ICommand>(p => p.Command, null);
		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<EventToCommand, object>(p => p.CommandParameter, null);
		public static readonly BindableProperty CommandNameProperty = BindableProperty.Create<EventToCommand, string>(p => p.CommandName, null);
		public static readonly BindableProperty CommandNameContextProperty = BindableProperty.Create<EventToCommand, object>(p => p.CommandNameContext, null);

		private Delegate handler;
		private EventInfo eventInfo;

		/// <summary>
		/// Gets or sets the name of the event to subscribe
		/// </summary>
		/// <value>
		/// The name of the event.
		/// </value>
		public string EventName
		{
			get { return (string)GetValue(EventNameProperty); }
			set { SetValue(EventNameProperty, value); }
		}

		/// <summary>
		/// Gets or sets the command to invoke when event raised
		/// </summary>
		/// <value>
		/// The command.
		/// </value>
		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}


		/// <summary>
		/// Gets or sets the optional command parameter.
		/// </summary>
		/// <value>
		/// The command parameter.
		/// </value>
		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		/// <summary>
		/// Gets or sets the name of the relative command.
		/// </summary>
		/// <value>
		/// The name of the command.
		/// </value>
		public string CommandName
		{
			get { return (string)GetValue(CommandNameProperty); }
			set { SetValue(CommandNameProperty, value); }
		}

		/// <summary>
		/// Gets or sets the relative context used with command name.
		/// </summary>
		/// <value>
		/// The command name context.
		/// </value>
		public object CommandNameContext
		{
			get { return GetValue(CommandNameContextProperty); }
			set { SetValue(CommandNameContextProperty, value); }
		}


		protected override void OnAttach()
		{
			var events = this.AssociatedObject.GetType().GetRuntimeEvents();
			if (events.Any())
			{
				this.eventInfo = events.FirstOrDefault(e => e.Name == this.EventName);
				if (this.eventInfo == null) throw new ArgumentException(string.Format("EventToCommand: Can't find any event named '{0}' on attached type"));
				this.AddEventHandler(eventInfo, this.AssociatedObject, this.OnFired);
			}
		}


		protected override void OnDetach()
		{
			if (this.handler != null) this.eventInfo.RemoveEventHandler(this.AssociatedObject, this.handler);
		}

		/// <summary>
		/// Subscribes the event handler.
		/// </summary>
		/// <param name="eventInfo">The event information.</param>
		/// <param name="item">The item.</param>
		/// <param name="action">The action.</param>
		private void AddEventHandler(EventInfo eventInfo, object item, Action<EventArgs> action)
		{
			//Got inspiration from here: http://stackoverflow.com/questions/9753366/subscribing-an-action-to-any-event-type-via-reflection
			//Maybe it is possible to pass Event arguments as CommanParameter

			var mi = eventInfo.EventHandlerType.GetRuntimeMethods().First(rtm => rtm.Name == "Invoke");
			List<ParameterExpression> parameters = mi.GetParameters().Select(p => Expression.Parameter(p.ParameterType)).ToList();
			MethodInfo actionMethodInfo = action.GetMethodInfo();
			Expression exp = Expression.Call(Expression.Constant(this), actionMethodInfo, parameters.Last());
			this.handler = Expression.Lambda(eventInfo.EventHandlerType, exp, parameters).Compile();
			eventInfo.AddEventHandler(item, handler);
		}

        /// <summary>
        /// Called when subscribed event fires
        /// 
        /// If a CommandParameter isn't assigned, the EventArgs parameter to the Event you're attaching to will be sent instead.
        /// You will want to have your Command to accept a parameter type of EventArgs for this to work correctly.
        /// 
        /// </summary>
        /// <example>This is an example of using a Command and accepting an object of the ItemVisibilityEventArgs Type
        /// <code>
        /// ICommand ItemAppearingCommand
        /// {
        ///     get
        ///     {
        ///         return new Command&lt;ItemVisibilityEventArgs&gt;(async args => 
        ///         {
        ///             if(viewModel.Items != null &amp;&amp; e.Item == viewModel.Items[viewModel.Items.Count -1])
        ///             {
        ///                 await viewModel.RetrieveNextItemSet(viewModel.Items.Count).ConfigureAwait(false);
        ///             }
        ///         }
        ///     }    
        /// }
        /// </code>
        /// </example>
        /// <param name="e">The EventArgs value accompanying the Event</param>
        private void OnFired(EventArgs e)
		{
            object returnParam = e ?? this.CommandParameter;

            if (!string.IsNullOrEmpty(this.CommandName))
			{
				if (this.Command == null) this.CreateRelativeBinding();
			}

			if (this.Command == null) throw new InvalidOperationException("No command available, Is Command properly set up?");

			if (e == null && this.CommandParameter == null) throw new InvalidOperationException("You need a CommandParameter");

			if (this.Command.CanExecute(returnParam))
			{
				this.Command.Execute(returnParam);
			}
		}

		/// <summary>
		/// Cretes a binding between relative context and provided Command name
		/// </summary>
		private void CreateRelativeBinding()
		{
			if (this.CommandNameContext == null) throw new ArgumentNullException("CommandNameContext property cannot be null when using CommandName property, consider using CommandNameContext={b:RelativeContext [ElementName]} markup markup extension.");
			if (this.Command != null) throw new InvalidOperationException("Both Command and CommandName properties specified, only one mode supported.");

			PropertyInfo pi = this.CommandNameContext.GetType().GetRuntimeProperty(this.CommandName);
			if (pi == null) throw new ArgumentNullException(string.Format("Can't find a command named '{0}'", this.CommandName));
			this.Command = pi.GetValue(this.CommandNameContext) as ICommand;
			if (this.Command == null) throw new ArgumentNullException(string.Format("Can't create binding with CommandName '{0}'", this.CommandName));
		}
	}
}
