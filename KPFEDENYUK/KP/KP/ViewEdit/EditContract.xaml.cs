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

namespace KP.ViewEdit
{
    /// <summary>
    /// Логика взаимодействия для EditContract.xaml
    /// </summary>
    public partial class EditContract : Window
    {
        private ContractAndClient _contract = new ContractAndClient();
        public EditContract(ContractAndClient selectedContract)
        {
            InitializeComponent();
            if (selectedContract != null)
                _contract = selectedContract;
            DataContext = _contract;
        }

        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            StringBuilder erros = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_contract.FirstName))
                erros.AppendLine("Укажите Фамилию");
            if (string.IsNullOrWhiteSpace(_contract.Name))
                erros.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_contract.MiddleName))
                erros.AppendLine("Укажите Отчество");
            if (string.IsNullOrWhiteSpace(_contract.Number))
                erros.AppendLine("Укажите Номер телефона");
            if (string.IsNullOrWhiteSpace(_contract.Insurance))
                erros.AppendLine("Укажите Вид страховки");
            if (_contract.DateFirts == null)
                erros.AppendLine("Укажите дату регистрации страховки");
            if (string.IsNullOrWhiteSpace(_contract.IncurancePayment))
                erros.AppendLine("Укажите Стоимость");
            if (_contract.Tern == null)
                erros.AppendLine("Укажите конец страховки");
            if (string.IsNullOrWhiteSpace(_contract.GosNumber))
                erros.AppendLine("Укажите Гос.Номер");
            if (string.IsNullOrWhiteSpace(_contract.GosNumber))
                erros.AppendLine("Укажите Марку автомобиля");
            if (erros.Length > 0)
            {
                MessageBox.Show(erros.ToString());
            }
            if (_contract.id == 0)
            {
                BDStrahEntitis.GetContext().ContractAndClient.Add(_contract);
            }
            try
            {
                AppData.db.SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
