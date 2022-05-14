using Slice.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Slice.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void Registration_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (FIOEntry.Text != null && LoginEntry.Text != null && PasswordEntry.Text != null)
                {
                    var user = new User
                    {
                        FIO = FIOEntry.Text,
                        Login = LoginEntry.Text,
                        Password = PasswordEntry.Text,
                    };

                    App.Db.SaveUser(user);
                    await Navigation.PopAsync();
                }
                else
                    await DisplayAlert("Alert!", "Введите в поля данные!", "OK");
            }
            catch
            {
                await DisplayAlert("Alert!", "Проверьте введённые данные", "OK");
            }
        }
    }
}