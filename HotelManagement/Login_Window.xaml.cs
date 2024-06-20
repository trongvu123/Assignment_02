using HotelManagement.Models;
using RepositoryPattern1;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace MiniHotelManagement
{
    public partial class Login_Window : Window
    {
        private readonly CustomerRepository _customerRepository;
     
        public Login_Window(CustomerRepository customerRepository)
        {

            InitializeComponent();
            _customerRepository = customerRepository;
        }
        public static IConfiguration Configuration { get; private set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var users = _customerRepository.GetAllCustomers();
            var user = users.FirstOrDefault(u => u.EmailAddress == txtUser.Text && u.Password == txtPass.Password);

            if (user != null)
            {

                    this.Hide();
                    CurrentUser.LoggedInUser = user;
                    UserProfile roomManager = (App.Current as App)?.GetProfileWindow();
                    roomManager.Show();               
            }
            else
            {
                if (txtUser.Text == "admin@FUMiniHotelSystem.com" && txtPass.Password == "@@abc123@@")
                {
                    this.Hide();
                    MainWindow mainWindow = (App.Current as App)?.GetMainWindow();
                    mainWindow?.Show();
                } else
                {

                   MessageBox.Show("User name or password is incorrect.");
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
