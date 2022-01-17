using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Corcav.Behaviors.Demo.ViewModels
{
    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        string firstName = "FirstName";
        string lastName = "LastName";
        Command testCommand;
        Command<object> unfocusedCommand;
        string message;
        string welcomeMessage;
        Command<string> nickSelectedCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            Items = new ObservableCollection<Item>()
            {
                new Item()
                {
                    NickName = "corcav",
                },
                new Item()
                {
                    NickName = "foo99",
                },
                new Item()
                {
                    NickName = "bar76",
                },
            };
        }

        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets FirstName property.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get => firstName;

            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    RaisePropertyChanged();
                    TestCommand.ChangeCanExecute();
                }
            }
        }

        /// <summary>
        /// Gets or sets LastName property.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get => lastName;

            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    RaisePropertyChanged();
                    TestCommand.ChangeCanExecute();
                }
            }
        }

        /// <summary>
        /// Gets then Message for the user.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get => message;

            private set
            {
                if (value != message)
                {
                    message = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets WelcomeMessage property.
        /// </summary>
        /// <value>The welcome message.</value>
        public string WelcomeMessage
        {
            get => welcomeMessage;

            set
            {
                if (value != welcomeMessage)
                {
                    welcomeMessage = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the TestCommand.
        /// </summary>
        /// <value>The test command.</value>
        public Command TestCommand
        {
            get
            {
                return testCommand ??= new Command(
                     () =>
                     {
                         WelcomeMessage = $"Hello {FirstName} {LastName}";
                     },
                     () =>
                     {
                         // CanExecute delegate
                         return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
                     });
            }
        }

        /// <summary>
        /// Gets the UnfocusedCommand.
        /// </summary>
        /// <value>The unfocused command.</value>
        public Command<object> UnfocusedCommand
        {
            get
            {
                return unfocusedCommand ??= new Command<object>(
                     (param) =>
                     {
                         Message = $"Unfocused raised with param {param}";
                     },
                     (param) =>
                     {
                         // CanExecute delegate
                         return true;
                     });
            }
        }

        /// <summary>
        /// Gets the NickSelectedCommand.
        /// </summary>
        /// <value>The nick selected command.</value>
        public Command<string> NickSelectedCommand
        {
            get
            {
                return nickSelectedCommand ??= new Command<string>(
                     (param) =>
                     {
                         Message = string.Format("Item {0} selected", param);
                     },
                     (param) =>
                     {
                         // CanExecute delegate
                         return true;
                     });
            }
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public ObservableCollection<Item> Items { get; private set; }

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
