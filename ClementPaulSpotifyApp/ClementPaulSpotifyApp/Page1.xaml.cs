using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XXXXXX;

namespace ClementPaulSpotifyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            BindingContext = Page1ViewModel.Instance;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Page1ViewModel.Instance.UpdateColor();
        }
    }
}