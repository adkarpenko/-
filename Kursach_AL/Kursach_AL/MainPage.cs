using System;
using Kursach_AL.UIElements;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Kursach_AL.Entities;

namespace Kursach_AL
{
    public class MainPage : UIContentPage
    {
        public static PurchaseList list;
        /// <summary>
        /// Кнопка для сканирования QR-кода
        /// </summary>
        RoundButton ScanButton = new RoundButton("Сканировать QR-код")
        {
            VerticalOptions = LayoutOptions.End
        };

        public MainPage()
        {
            list = new PurchaseList();
            //Сохранение объектов в память 
            using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes((string)App.Current.Properties["purchases"])))
            {
                var formatter = new DataContractJsonSerializer(typeof(PurchaseList));
                list = (PurchaseList)formatter.ReadObject(ms);
            }
            Title = "Покупки";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    list,
                    ScanButton
                }
            };
            ScanButton.Clicked += Scan;
        }


        async void Scan(object sender, EventArgs e)
        {
            string res = "";
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                res = await scanner.ScanAsync();
            }
            catch
            {
                return;
            }
            try
            {
                //вытаскиваем информацию по чеку
                string[] data = res.Split('&');
                double price;
                try
                {
                    string pp = data[1].Split('=')[1];
                    price = double.Parse(pp);
                }
                catch
                {
                    string pp = data[1].Split('=')[1].Replace(".", ",");
                    price = double.Parse(pp);
                }
                string fn = data[2].Split('=')[1];
                if (App.shops.ContainsKey(fn))
                {
                    string shop = App.shops[fn];
                    list.Add(new PurchaseEntity
                    {
                        shop = shop,
                        price = price
                    });
                }
                else
                {
                    await Navigation.PushModalAsync(new AddShopPage(price, fn));
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Ошибка", "Ошибка чтения QR кода", "Ок");
            }
        }
    }
}
