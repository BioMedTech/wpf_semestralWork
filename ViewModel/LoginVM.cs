﻿using Expence_Tracker.Model;
using Expence_Tracker.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Expence_Tracker.ViewModel
{
    public class LoginVM
    {
        private User user;

        public User User
        {
            get { return user; }
            set {
                user = value;
                Update();
            }
        }

        public RegisterCommand RegisterCommand { get; set; }

        public LoginCommand LoginCommand { get; set; }

        public event EventHandler HasLoggedIn;

        public LoginVM()
        {
            User = new User();
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }

        public void Login()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<User>();

                var user = conn.Table<User>().Where(u => u.Username == User.Username).FirstOrDefault();

                if (user.Password == User.Password)
                {
                    App.UserId = user.Id.ToString();
                    HasLoggedIn(this, new EventArgs());
                }
            }
        }

        public void Register()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<User>();

                var result = DatabaseHelper.Insert(User);

                if (result)
                {
                    App.UserId = User.Id.ToString();
                    HasLoggedIn(this, new EventArgs());
                }
            }
        }

        public void Update()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<User>();
                int id;
                Int32.TryParse(App.UserId, out id);
                var user = conn.Table<User>().Where(u => u.Id == id).FirstOrDefault();

                if (user!=null)
                {
                    DatabaseHelper.Update(User);
                }
            }
        }
    }
    }
