using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PlainShellPOC.Pages
{
    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        private void TestButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var textEntryText = (string.IsNullOrEmpty(textEntry.Text)) ? "Hello World" : textEntry.Text;
                Shell.Current.GoToAsync($"TestPageOne?name={textEntryText}&text={textEntryText}");
            }
            catch(Exception ex)
            {
                Helpers.AppExceptionHandler.ExceptionLogger(ex);
            }
        }
    }
}