using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PlainShellPOC.Pages;
using Xamarin.Forms;

namespace PlainShellPOC.BaseFolder
{
    public partial class AppShell : Shell
    {
        Random rand = new Random();
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public ICommand HelpCommand => new Command<string>(async (url) => await Xamarin.Essentials.Launcher.OpenAsync(url));
        public ICommand RandomPageCommand => new Command(async () => await NavigateToRandomPageAsync());

        public AppShell()
        {
            SetNavBarIsVisible(this, false);
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            //http://alejandroruizvarela.blogspot.com/2019/02/xamarin-month-fall-in-love-with.html
            //https://github.com/AlejandroRuiz/XamarinFormsShellDemo/tree/master/FormsShellDemoApp/FormsShellDemoApp
            //https://github.com/xamarin/xamarin-forms-samples/tree/master/UserInterface/Xaminals/Xaminals
            //var type = e.GetType();
            //var memInfo = type.GetMember(e.AM1030.ToString());
            //var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            //var description = ((DescriptionAttribute)attributes[0]).Description;

            routes.Add("TestPageOne", typeof(TestPageOne));
            //routes.Add("beardetails", typeof(BearDetailPage));
            //routes.Add("catdetails", typeof(CatDetailPage));
            //routes.Add("dogdetails", typeof(DogDetailPage));
            //routes.Add("elephantdetails", typeof(ElephantDetailPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        public string GetDescription(PageNames pageNames)
        {
            var pageName = string.Empty;
            try
            {
                //var type = PageNames.GetType();
                //var memInfo = type.GetMember(pageName.ToString());
                //var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                //var description = ((DescriptionAttribute)attributes[0]).Description;
            }
            catch (Exception ex) { }
            return pageName;
        }

        async Task NavigateToRandomPageAsync()
        {
            string destinationRoute = routes.ElementAt(rand.Next(0, routes.Count)).Key;
            string animalName = string.Empty;

            //switch (destinationRoute)
            //{
            //    case "monkeydetails":
            //        animalName = MonkeyData.Monkeys.ElementAt(rand.Next(0, MonkeyData.Monkeys.Count)).Name;
            //        break;
            //    case "beardetails":
            //        animalName = BearData.Bears.ElementAt(rand.Next(0, BearData.Bears.Count)).Name;
            //        break;
            //    case "catdetails":
            //        animalName = CatData.Cats.ElementAt(rand.Next(0, CatData.Cats.Count)).Name;
            //        break;
            //    case "dogdetails":
            //        animalName = DogData.Dogs.ElementAt(rand.Next(0, DogData.Dogs.Count)).Name;
            //        break;
            //    case "elephantdetails":
            //        animalName = ElephantData.Elephants.ElementAt(rand.Next(0, ElephantData.Elephants.Count)).Name;
            //        break;
            //}

            if (!string.IsNullOrEmpty(animalName))
            {
                ShellNavigationState state = Shell.Current.CurrentState;
                await Shell.Current.GoToAsync($"{state.Location}/{destinationRoute}?name={animalName}");
                Shell.Current.FlyoutIsPresented = false;
            }
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }

    public enum PageNames
    {
        [Description("Intro Page")]
        IntroPage,

        [Description("Main Page")]
        MainPage
    }
}