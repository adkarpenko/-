using System;
using Kursach_AL.Entities;
using Kursach_AL.UIElements;
using Xamarin.Forms;
namespace Kursach_AL
{
    public class PurchaseInfoPage : UIContentPage
    {
        RoundButton delete = new RoundButton("Удалить");
        PurchaseEntity entity;
       
        public PurchaseInfoPage(PurchaseEntity p)
        {
            entity = p;
            Content = new StackLayout
            {
                Children =
                {

                    new UITitle("Информация о покупке")
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand
                    },
                    new UIInfoLabel("Магазин: " + p.shop),
                    new UIInfoLabel("Категория: " + App.shopCategories[p.shop]),
                    new UIInfoLabel("Расходы: " + p.price.ToString()),
                    new UIInfoLabel("Время:   " + p.dateTime.ToString()),
                    delete
                }
            };
            delete.Clicked += Delete;
        }
        /// <summary>
        /// Метод для удаление магазина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Delete(object sender, EventArgs e)
        {
            MainPage.list.Remove(entity);
            Navigation.PopModalAsync();
        }
    }
}
