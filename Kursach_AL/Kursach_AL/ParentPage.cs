using System;
using Xamarin.Forms;

namespace Kursach_AL
{
    public class ParentPage : TabbedPage
    {
        public ParentPage()
        {
            Children.Add(new MainPage());
            Children.Add(new AnalysisPage());
            BarBackgroundColor = Color.Green;
        }
    }
}
