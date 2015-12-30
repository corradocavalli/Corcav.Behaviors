using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corcav.Behaviors.Demo.ViewModels;
using Xamarin.Forms;

namespace Corcav.Behaviors.Demo.Views
{
	public partial class MainView: ContentPage
	{
		public MainView()
		{
			InitializeComponent();
			this.BindingContext = new MainViewModel();
		}
	}
}
