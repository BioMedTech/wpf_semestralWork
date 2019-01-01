using Expence_Tracker.Model;
using Expence_Tracker.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace Expence_Tracker.ViewModel
{
    public class ExpenseTrackerVM
    {
        public ObservableCollection<Expense> Expenses { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<BitmapImage> Icons { get; set; }
        public Category NewCategory;

        public AddExpanceCommand AddExpanceCommand { get; set; }
        public AddCategoryCommand AddCategoryCommand { get; set; }
        public Expense Current_Expence;

        string[] icons = Directory.GetFiles(@"../../Icons/", "*.png");

       
        public int Cols = 12;
        public int Rows;
        public ExpenseTrackerVM()
        {
            Expenses = new ObservableCollection<Expense>();
            Current_Expence = new Expense();
            NewCategory = new Category();

            Icons = new ObservableCollection<BitmapImage>();

            foreach (var path in icons)
            {
                Icons.Add(new BitmapImage(new Uri(@path.Substring(3), UriKind.Relative)));
            }
            Rows=Icons.Count / Cols;
            Categories = new ObservableCollection<Category> {
                new Category() {
                    Name ="Food",
                    Icon=new BitmapImage(new Uri(@"../Icons/apple-alt.png", UriKind.Relative))
                },
                new Category() {
                   Name="Coffee/Tea",
                   Icon=new BitmapImage(new Uri(@"../Icons/coffee.png", UriKind.Relative))
                },
                new Category() {
                    Name="Furniture",
                    Icon=new BitmapImage(new Uri(@"../Icons/couch.png", UriKind.Relative))
                },
                new Category() {
                    Name="Sport",
                    Icon=new BitmapImage(new Uri(@"../Icons/swimmer.png", UriKind.Relative))
                },
                new Category() {
                    Name="Technologies",
                    Icon=new BitmapImage(new Uri(@"../Icons/mobile-alt.png", UriKind.Relative))
                },
                new Category() {
                    Name="Leasure",
                   Icon=new BitmapImage(new Uri(@"../Icons/book.png",  UriKind.Relative))
                },
                new Category() {
                    Name="Presents",
                    Icon=new BitmapImage(new Uri(@"../Icons/gift.png", UriKind.Relative))
                },
                new Category() {
                    Name="Other",
                    Icon=new BitmapImage(new Uri(@"../Icons/leaf.png", UriKind.Relative))
                }
            };
            AddExpanceCommand = new AddExpanceCommand(this);
            AddCategoryCommand = new AddCategoryCommand(this);
        }

        public void AddExpence()
        {
            Expenses.Add(new Expense());
        }

        public void AddCategory()
        {
            Categories.Add(NewCategory);
        }

        //public void ReadDatabase()
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
        //    {
        //        conn.CreateTable<User>();
        //        var contacts = conn.Table<User>().ToList();
        //    }
        //}
    }
}
