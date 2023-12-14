using KP.Model;
using KP.ViewAdd;
using KP.ViewEdit;
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
using Word = Microsoft.Office.Interop.Word;

namespace KP.View
{
    /// <summary>
    /// Логика взаимодействия для WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        public WindowUser()
        {
            InitializeComponent();
            if (MainWindow.Globals.UserRole == 1)
            {
                Btn_User1.Visibility = Visibility.Visible;
            }
            else
            {
                Btn_User1.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserGrid.ItemsSource = AppData.db.User.ToList();
        }

        private void Button_Click_Contract(object sender, RoutedEventArgs e)
        {
            WindowContract windowContract = new WindowContract();
            windowContract.Show();
            this.Close();
        }

        private void Button_Click_Users(object sender, RoutedEventArgs e)
        {
            WindowUser user = new WindowUser();
            user.Show();
            this.Close();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Btn_Del(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить пользователя?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentUser = UserGrid.SelectedItem as User;
                AppData.db.User.Remove(CurrentUser);
                AppData.db.SaveChanges();
                UserGrid.ItemsSource = AppData.db.User.ToList();
                MessageBox.Show("Удалено");
            }
        }

        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            AddUser user = new AddUser();
            user.Show();
        }

        private void Btn_Edit(object sender, RoutedEventArgs e)
        {
            EditUser user = new EditUser(UserGrid.SelectedItem as User);
            user.Show();
        }

        private void Btn_Otchet(object sender, RoutedEventArgs e)
        {
            var allRequest = BDStrahEntitis.GetContext().User.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Отчет пользователей";
            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allRequest.Count() + 1, 4);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "id";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Login";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Password";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Post";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRequest.Count(); i++)
            {
                var currentCategory = allRequest[i];
                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = Convert.ToString(currentCategory.id);
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = Convert.ToString(currentCategory.Login);

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = Convert.ToString(currentCategory.Password);

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = Convert.ToString(currentCategory.Position);
            }
            application.Visible = true;
        }
    }
}
