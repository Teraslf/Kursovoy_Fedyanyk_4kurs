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
    /// Логика взаимодействия для AddContract.xaml
    /// </summary>
    public partial class AddContract : Window
    {
        public AddContract()
        {
            InitializeComponent();
        }

        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            ContractAndClient contract = new ContractAndClient();
            contract.FirstName = FirtsName.Text;
            contract.Name = Name.Text;
            contract.MiddleName = MiddleName.Text;
            contract.Number = Number.Text;
            contract.Insurance = Strahov.Text;
            contract.DateFirts = DateEnd1.DisplayDate;
            contract.IncurancePayment = Price.Text;
            contract.Tern = Date.DisplayDate;
            contract.GosNumber = GosNumber.Text;
            contract.NameCar = NameAuto.Text;

            AppData.db.ContractAndClient.Add(contract);
            AppData.db.SaveChanges();
            MessageBox.Show("Пользователь был добавлен в базу!");
            this.Close();
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
