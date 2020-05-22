using System;
using Xamarin.Forms;
namespace Kursach_AL.UIElements
{
    public class UIButton : Button
    {
        public UIButton(string text)
        {
            BackgroundColor = Color.Green;
            TextColor = Color.White;
            Text = text;
        }
    }
}
