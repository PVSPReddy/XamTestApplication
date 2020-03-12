using System;

using Xamarin.Forms;

namespace PlainShellPOC.Pages
{
    [QueryProperty("Name", "name")]
    [QueryProperty("Text", "text")]
    public partial class TestPageOne : ContentPage
    {
        public string Name
        {
            set
            {
                //string key = Uri.EscapeDataString(key);
                //BindingContext = CatData.Cats.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
                headerLabel.Text = Uri.UnescapeDataString(value);
            }
        }

        public string Text
        {
            set
            {
                //string key = Uri.EscapeDataString(key);
                //BindingContext = CatData.Cats.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
                textLabel.Text = Uri.UnescapeDataString(value);
            }
        }

        public TestPageOne()
        {
            Shell.SetNavBarIsVisible(this, true);
            InitializeComponent();
        }
    }
}