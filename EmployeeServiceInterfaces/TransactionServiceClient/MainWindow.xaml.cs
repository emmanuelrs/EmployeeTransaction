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
using System.ServiceModel;
using TransactionServiceInterfaces;

namespace TransactionServiceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void enrollBtn_Click(object sender, RoutedEventArgs e)
        {
            if (studentNameTxt.Text == "") return;
            using (ChannelFactory<IEmployeeTransactionService> transactionServiceProxy =
                new ChannelFactory<IEmployeeTransactionService>("MyEmployeeServiceEndpoint"))
            {
                transactionServiceProxy.Open();
                IEmployeeTransactionService transactionService = transactionServiceProxy.CreateChannel();
                Employee emp = new Employee();
                emp.EmployeeName = studentNameTxt.Text;
                transactionService.employee_registration(emp);
                transactionServiceProxy.Close();
            }
            studentNameTxt.Text = " ";
        }

        private void getEnrollBtn_Click(object sender, RoutedEventArgs e)
        {
            enrolledTxt.Text = "";
            using (ChannelFactory<IEmployeeTransactionService> transactionServiceProxy =
                new ChannelFactory<IEmployeeTransactionService>("MyEmployeeServiceEndpoint"))
            {
                transactionServiceProxy.Open();
                IEmployeeTransactionService transactionService = transactionServiceProxy.CreateChannel();
                Employee[] addEmployeesList = transactionService.GetEmployeesTransaction();

                foreach (Employee emp in addEmployeesList )
                {
                    enrolledTxt.AppendText(emp.EmployeeName + "\n");
                    
                }
                transactionServiceProxy.Close();
            }
        }

    }
}
