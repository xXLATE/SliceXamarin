using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Slice.DataBase
{
    public class DataAccess
    {
        private SQLiteConnection _db;

        public DataAccess(string databasePath)
        {
            _db = new SQLiteConnection(databasePath);
            _db.CreateTable<User>();
            _db.CreateTable<Project>();
        }

        public int SaveUser(User user)
        {
            if (user.Id != 0)
            {
                _db.Update(user);
                return user.Id;
            }
            else
                return _db.Insert(user);
        }

        public int SaveProject(Project project)
        {
            if (project.Id != 0)
            {
                _db.Update(project);
                return project.Id;
            }
            else
                return _db.Insert(project);
        }

        public int DeleteProject(int idProject)
        {
            return _db.Delete<Project>(idProject);
        }

        public IEnumerable<User> GetUsers()
        {
            return _db.Table<User>();
        }

        public IEnumerable<Project> GetProjects()
        {
            return _db.Table<Project>().ToList();
        }

        public IEnumerable<Project> GetProjectsByUser(int idUser)
        {
            return GetProjects().Where(project => project.User_Id == idUser);
        }
    }
}
