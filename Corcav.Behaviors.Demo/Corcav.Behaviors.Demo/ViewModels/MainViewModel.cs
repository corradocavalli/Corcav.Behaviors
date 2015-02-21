using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Corcav.Behaviors.Demo.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string firstName = "FirstName";
		private string lastName = "LastName";
		private Command testCommand;
		private Command<object> unfocusedCommand;
		private string message;
		private string welcomeMessage;
		private Command<string> nickSelectedCommand;

		/// <summary>
		/// Initializes a new instance of the <see cref="MainViewModel"/> class.
		/// </summary>
		public MainViewModel()
		{
			this.Items = new ObservableCollection<Item>() { new Item() { NickName = "corcav" }, new Item() { NickName = "foo99" }, new Item() { NickName = "bar76" } };
		}

		/// <summary>
		/// Gets or sets FirstName property
		/// </summary>
		public string FirstName
		{
			get
			{
				return this.firstName;
			}

			set
			{
				if (value != this.firstName)
				{
					this.firstName = value;
					this.RaisePropertyChanged();
					this.TestCommand.ChangeCanExecute();
				}
			}
		}

		/// <summary>
		/// Gets or sets LastName property
		/// </summary>
		public string LastName
		{
			get
			{
				return this.lastName;
			}

			set
			{
				if (value != this.lastName)
				{
					this.lastName = value;
					this.RaisePropertyChanged();
					this.TestCommand.ChangeCanExecute();
				}
			}
		}

		/// <summary>
		/// Gets then Message for the user
		/// </summary>
		public string Message
		{
			get
			{
				return this.message;
			}

			private set
			{
				if (value != this.message)
				{
					this.message = value;
					this.RaisePropertyChanged();
				}
			}
		}


		/// <summary>
		/// Gets or sets WelcomeMessage property
		/// </summary>
		public string WelcomeMessage
		{
			get
			{
				return this.welcomeMessage;
			}

			set
			{
				if (value != this.welcomeMessage)
				{
					this.welcomeMessage = value;
					this.RaisePropertyChanged();
				}
			}
		}


		/// <summary>
		/// Gets the TestCommand.
		/// </summary>
		public Command TestCommand
		{
			get
			{
				return this.testCommand ?? (this.testCommand = new Command(
					 () =>
					 {
						 this.WelcomeMessage = string.Format("Hello {0} {1}", this.FirstName, this.LastName);
					 },
					 () =>
					 {
						 // CanExecute delegate
						 return !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName);
					 }));
			}
		}

		/// <summary>
		/// Gets the UnfocusedCommand.
		/// </summary>
		public Command<object> UnfocusedCommand
		{
			get
			{
				return this.unfocusedCommand ?? (this.unfocusedCommand = new Command<object>(
					 (param) =>
					 {
						 this.Message = string.Format("Unfocused raised with param {0}", param);
					 },
					 (param) =>
					 {
						 // CanExecute delegate
						 return true;
					 }));
			}
		}

		public Command<string> NickSelectedCommand
		{
			get
			{
				return this.nickSelectedCommand ?? (this.nickSelectedCommand = new Command<string>(
					 (param) =>
					 {
						 this.Message = string.Format("Item {0} selected", param);
					 },
					 (param) =>
					 {
						 // CanExecute delegate
						 return true;
					 }));
			}
		}


		public ObservableCollection<Item> Items { get; private set; }


		protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
