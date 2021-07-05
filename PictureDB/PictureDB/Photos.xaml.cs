using PictureDB.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PictureDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Photos : ContentPage
    {

        public Photos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var lista = await App.SQLiteDB.GetFotoAsync();
            if (lista != null)
            {
                /*for (int i = 1; i < lista.Count(); i++)
                {
                    var fotobyte = lista.ElementAt(i).image;
                    Stream stream = new MemoryStream(fotobyte);
                    var image = new Image { Source = ImageSource.FromStream(() => stream),
                        HeightRequest = 60,
                        WidthRequest = 60,
                        Margin= new Thickness(0),
                    };
                    image.IsVisible = true;
                    contenedor.Children.Add(image);
                }*/
                lstfoto.ItemsSource = lista;
            }
        }

        private async void lstfoto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Foto)e.SelectedItem;

            byte[] foto = obj.image;

            var detail = new Foto
            {
                nombre = obj.nombre,
            };

            var detalles = new Details(foto);
            detalles.BindingContext = detail;
            await Navigation.PushAsync(detalles);
        }
    }
}