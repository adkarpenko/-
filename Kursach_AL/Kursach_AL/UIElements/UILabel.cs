using System;
using Xamarin.Forms;
namespace Kursach_AL.UIElements
{
    public class UILabel : Label
    {
        public UILabel(string text)
        {
            TextColor = Color.Green;
            Text = text;
            Margin = 30;
        }
    }
}
