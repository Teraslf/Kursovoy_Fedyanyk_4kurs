using KP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KP.ViewAdd
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Login = Login.Text;
            user.Password = Pass.Text;
            user.Position = Post.Text;
            AppData.db.User.Add(user);
            AppData.db.SaveChanges();
            MessageBox.Show("Пользователь был добавлен в базу!");
            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
