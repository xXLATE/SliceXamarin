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
    public partial class Project : ContentPage
    {
        private User _currentUser;
        private DataBase.Project _currentProject;

        public Project(DataBase.Project project, User user)
        {
            InitializeComponent();
            _currentProject = project;
            _currentUser = user;
            BtnAddProject.IsVisible = false;
        }

        public Project(User user)
        {
            InitializeComponent();
            _currentUser = user;
            BtnEdit.IsVisible = false;
            BtnDeleteProject.IsVisible = false;
        }

        private async void BtnAddProject_Clicked(object sender, EventArgs e)
        {
            if (DPDate.Date < DateTime.Now)
            {
                DataBase.Project project = new DataBase.Project
                {
                    Name = EName.Text,
                    Description = EDDescription.Text,
                    Date = DPDate.Date,
                    User_Id = _currentUser.Id
                };

                App.Db.SaveProject(project);

                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Дата", "Дата не может быть позднее текущего дня", "Окей");
        }

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            if (DPDate.Date < DateTime.Now)
            {
                App.Db.SaveProject(_currentProject);

                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Дата", "Дата не может быть позднее текущего дня", "Окей");
        }

        private async void BtnDeleteProject_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Удаление", $"Вы действительно хотите удалить {_currentProject.Name}?", "Да", "Нет"))
            {
                App.Db.DeleteProject(_currentProject.Id);

                await Navigation.PopAsync();
            }
        }
    }
}