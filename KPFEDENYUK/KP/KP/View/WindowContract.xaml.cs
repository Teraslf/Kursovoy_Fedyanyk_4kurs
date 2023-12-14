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
using KP.ViewAdd;
using KP.ViewEdit;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace KP.View
{
    /// <summary>
    /// Логика взаимодействия для WindowContract.xaml
    /// </summary>
    public partial class WindowContract : System.Windows.Window
    {
        public WindowContract()
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
            ContractGrid.ItemsSource = AppData.db.ContractAndClient.ToList();
        }

        private void Button_Click_Contract(object sender, RoutedEventArgs e)
        {
            WindowContract windowContract = new WindowContract();
            windowContract.Show();
            this.Close();
        }

        private void Button_Click_Users(object sender, RoutedEventArgs e)
        {
            WindowUser windowUser = new WindowUser();
            windowUser.Show();
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
                var CurrentUser = ContractGrid.SelectedItem as ContractAndClient;
                AppData.db.ContractAndClient.Remove(CurrentUser);
                AppData.db.SaveChanges();
                ContractGrid.ItemsSource = AppData.db.ContractAndClient.ToList();
                MessageBox.Show("Удалено");
            }
        }

        private void Btn_Edit(object sender, RoutedEventArgs e)
        {
            EditContract editContract = new EditContract(ContractGrid.SelectedItem as ContractAndClient);
            editContract.Show();
        }

        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            AddContract addContract = new AddContract();
            addContract.Show();
        }

        private void Btn_Otchet(object sender, RoutedEventArgs e)
        {
            var allRequest = BDStrahEntitis.GetContext().ContractAndClient.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Отчет Договоров";
            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allRequest.Count() + 1, 11);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "id";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Фамилия";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Имя";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Отчество";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Номер Телефона";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Вид страховки";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Дата заключения";
            cellRange = paymentsTable.Cell(1, 8).Range;
            cellRange.Text = "Платеж";
            cellRange = paymentsTable.Cell(1, 9).Range;
            cellRange.Text = "Действие до";
            cellRange = paymentsTable.Cell(1, 10).Range;
            cellRange.Text = "Гос.номер";
            cellRange = paymentsTable.Cell(1, 11).Range;
            cellRange.Text = "Марка авто";



            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRequest.Count(); i++)
            {
                var currentCategory = allRequest[i];
                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = Convert.ToString(currentCategory.id);
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = Convert.ToString(currentCategory.FirstName);

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = Convert.ToString(currentCategory.Name);

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = Convert.ToString(currentCategory.MiddleName);

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = Convert.ToString(currentCategory.Number);

                cellRange = paymentsTable.Cell(i + 2, 6).Range;
                cellRange.Text = Convert.ToString(currentCategory.Insurance);

                cellRange = paymentsTable.Cell(i + 2, 7).Range;
                cellRange.Text = currentCategory.DateFirts.ToString("dd.MM.yyyy");

                cellRange = paymentsTable.Cell(i + 2, 8).Range;
                cellRange.Text = Convert.ToString(currentCategory.IncurancePayment);

                cellRange = paymentsTable.Cell(i + 2, 9).Range;
                cellRange.Text = currentCategory.Tern.ToString("dd.MM.yyyy");

                cellRange = paymentsTable.Cell(i + 2, 10).Range;
                cellRange.Text = Convert.ToString(currentCategory.GosNumber);

                cellRange = paymentsTable.Cell(i + 2, 11).Range;
                cellRange.Text = Convert.ToString(currentCategory.NameCar);
            }
            application.Visible = true;
        }

        private void Rezerv_Click(object sender, RoutedEventArgs e)
        {
            {
                string serverName = "ZHIGAS\\SQLEXPRESS";
                string databaseName = "StrahovanieDB";
                string backupPath = "D:\\555.bak";

                ServerConnection serverConnection = new ServerConnection(serverName);
                Server server = new Server(serverConnection);
                Backup backup = new Backup() { Action = BackupActionType.Database, Database = databaseName };
                backup.Devices.AddDevice(backupPath, DeviceType.File);
                backup.Initialize = true;
                try
                {
                    backup.SqlBackup(server);
                    MessageBox.Show("Backup completed successfully", "Backup Status", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating backup: " + ex.Message, "Backup Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Vostav_click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Database Files (*.bak)|*.bak";
                if (openFileDialog.ShowDialog() == true)
                {
                    string databaseFileName = openFileDialog.FileName;

                    string connectionString = "Data Source=ZHIGAS\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = $"ALTER DATABASE StrahovanieDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE StrahovanieDB FROM DISK = '{databaseFileName}' WITH REPLACE; ALTER DATABASE StrahovanieDB SET MULTI_USER";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Я ЕБУСЬ В АНАЛ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
