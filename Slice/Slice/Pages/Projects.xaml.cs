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
    public partial class Projects : ContentPage
    {
        private User _currentUser;

        public Projects(User user)
        {
            InitializeComponent();

            _currentUser = user;
            NavigationPage.SetHasBackButton(this, false);
        }

        protected override void OnAppearing()
        {
            ProjectsLV.ItemsSource = App.Db.GetProjectsByUser(_currentUser.Id);
            base.OnAppearing();
        }

        private async void NewProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Project(_currentUser));
        }

        private async void ProjectsLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DataBase.Project selectedProject = (DataBase.Project)e.SelectedItem;
            await Navigation.PushAsync(new Project(selectedProject, _currentUser)
            {
                BindingContext = selectedProject
            });
        }
    }
}