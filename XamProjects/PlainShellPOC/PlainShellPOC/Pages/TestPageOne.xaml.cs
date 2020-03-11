using System;

using Xamarin.Forms;

namespace PlainShellPOC.Pages
{
    [QueryProperty("Name", "name")]
    public partial class TestPageOne : ContentPage
    {
        public string Name
        {
            set
            {
                //string key = Uri.EscapeDataString(key);
                //BindingContext = CatData.Cats.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
                testLabel.Text = Uri.UnescapeDataString(value);
            }
        }

        public TestPageOne()
        {
            InitializeComponent();
        }
    }
}