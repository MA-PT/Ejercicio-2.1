using PictureDB.Data;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PictureDB
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        //byte[] img;

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var cameraOptions = new StoreCameraMediaOptions();

            cameraOptions.PhotoSize = PhotoSize.Full;

            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(cameraOptions);

            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });

                byte[] img = GetImageBytes(photo);

                Foto foto = new Foto
                {
                    nombre = DateTime.Now + "jpg",
                    image = img
                };
                await App.SQLiteDB.SaveFotoAsync(foto);

                await DisplayAlert("Registro", "Foto guardada correctamente", "Ok");
            }
        }

        private void save_Clicked(object sender, EventArgs e)
        {
            //byte[] img = null;
            //Foto foto = new Foto
            //{
            //    image = img
            //};
            //await App.SQLiteDB.SaveFotoAsync(foto);

            //await DisplayAlert("Registro", "Foto guardada correctamente", "Ok");
        }

        private byte[] GetImageBytes(MediaFile file)
        {
            byte[] ImageBytes;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }

        private async void btnver_Clicked(object sender, EventArgs e)
        {
            var detalles = new Photos();
            await Navigation.PushAsync(detalles);
        }
    }
}
