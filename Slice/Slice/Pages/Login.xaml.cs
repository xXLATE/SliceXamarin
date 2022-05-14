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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Registration_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            var allUsers = App.Db.GetUsers();

            if (LoginEntry.Text == null && PasswordEntry.Text == null)
                await DisplayAlert("Alert!", "Не правилный логин или пароль", "OK");
            else
            {
                bool haveUser = false;

                foreach (var user in allUsers)
                {
                    if (user.Login == LoginEntry.Text && user.Password == PasswordEntry.Text)
                    {
                        App.userID = user.Id;
                        await Navigation.PushAsync(new Projects());
                        haveUser = true;
                    }
                }

                if (!haveUser)
                    await DisplayAlert("Alert!", "Не правилный логин или пароль", "OK");
            }
        }
    }
}