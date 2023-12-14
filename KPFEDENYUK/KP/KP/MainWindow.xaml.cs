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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KP.Model;
using KP.View;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static class Globals
        {
            public static int UserRole;

            public static string Login;
            public static User userinfo { get; set; }
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string loga = MD5Gen.MD5Hash(Txb_Login.Text);
            var CurrentUser = AppData.db.User.FirstOrDefault(u => u.Login == loga);
            if (CurrentUser != null)
            {

                Globals.UserRole = CurrentUser.id;
                Globals.userinfo = CurrentUser;
                Txb_Pass.IsEnabled = true;
                Btn_Login.Visibility = Visibility.Hidden;
                Btn_Pass.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
                Txb_Login.Clear();
            }
        }

        private void Btn_Pass_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BDStrahEntitis())
            {
                string pword = MD5Gen.MD5Hash(Txb_Pass.Text);
                var CurrentUser1 = AppData.db.User.FirstOrDefault(u => u.Password == pword);
                if (CurrentUser1 != null)
                {
                    Globals.UserRole = CurrentUser1.id;
                    Globals.userinfo = CurrentUser1;
                    Txb_PassPod.IsEnabled = true;
                    Btn_Pass.Visibility = Visibility.Hidden;
                    Btn_PassProv.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Пароль не верен!");
                    Txb_Pass.Clear();
                }
            } 
        }

        private async void Btn_PassProv_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BDStrahEntitis()) 
            {
                string pword = MD5Gen.MD5Hash(Txb_Pass.Text);
                if (pword == pword)
                {
                    GridCode.Visibility = Visibility.Visible;
                    while (true)
                    {
                        Random x = new Random();
                        int a = x.Next(1000, 9999);
                        Txb_Code.Text = a.ToString();
                        await Task.Delay(10000);
                    }
                }
                else
                {
                    MessageBox.Show("Не верно введено подтверждение пароля!");
                    Txb_PassPod.Clear();
                }
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Txb_Login.Clear();
            Txb_Pass.IsEnabled = false;
            Txb_Pass.Clear();
            Txb_PassPod.IsEnabled = false;
            Txb_PassPod.Clear();
            Txb_Code.Clear();
            Txb_CodePod.Clear();
            Btn_Login.Visibility = Visibility.Visible;
            Btn_Pass.Visibility = Visibility.Hidden;
            Btn_PassProv.Visibility = Visibility.Hidden;
            GridCode.Visibility = Visibility.Hidden;
        }

        private void Btn_Next_Click(object sender, RoutedEventArgs e)
        {
            if (Txb_Code.Text == Txb_CodePod.Text)
            {
                if (MainWindow.Globals.UserRole == 1)
                {
                    MessageBox.Show("Вы вошли под администратором!");
                    WindowContract windowGlav = new WindowContract();
                    windowGlav.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы вошли под пользователем!");
                    WindowContract windowGlav = new WindowContract();
                    windowGlav.Show();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Вы не вошли!");
            }
        }

        private async void Btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Random x = new Random();
            int a = x.Next(1000, 9999);
            Txb_Code.Text = a.ToString();
            await Task.Delay(10000);
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Txb_Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
