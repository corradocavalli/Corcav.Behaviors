#if NETSTANDARD
using Xamarin.Forms.Xaml;
#else
using Microsoft.Maui;
#endif

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
