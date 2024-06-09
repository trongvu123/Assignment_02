using DataModels1;
using RepositoryPattern1;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.Configuration;
namespace MiniHotelManagement
{
    public partial class Login_Window : Window
    {
        private readonly CustomerRepository _customerRepository;
        public Login_Window()
        {

            InitializeComponent();
            _customerRepository = new CustomerRepository();
        }
        public static IConfiguration Configuration { get; private set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var users = _customerRepository.GetAllCustomers();
            var user = users.FirstOrDefault(u => u.EmailAddress == txtUser.Text && u.Password == txtPass.Password);

            if (user != null)
            {
                if (user.EmailAddress == "admin@FUMiniHotelSystem.com" && user.Password == "@@abc123@@")
                {
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    this.Hide();
                    CurrentUser.LoggedInUser = user;
                    UserProfile userProfile = new UserProfile();
                    userProfile.Show();
                }
            }
            else
            {
                MessageBox.Show("User name or password is incorrect.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
