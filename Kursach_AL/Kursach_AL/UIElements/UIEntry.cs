using System;
using Xamarin.Forms;
namespace Kursach_AL.UIElements
{
    public class UIEntry : Entry
    {
        public UIEntry(string text)
        {
            TextColor = Color.Green;
            Margin = 40;
            Placeholder = text;
        }
    }
}
