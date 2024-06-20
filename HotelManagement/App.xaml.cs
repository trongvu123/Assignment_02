using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using HotelManagement.Models;
using RepositoryPattern1;
using HotelManagement;

namespace MiniHotelManagement
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

            var loginWindow = _serviceProvider.GetRequiredService<Login_Window>();
            loginWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
 
            services.AddDbContext<FuminiHotelManagementContext>(options =>
            options.UseSqlServer("Data Source=localhost,1433;Initial Catalog=FUMiniHotelManagement;User ID=sa;Password=123456;TrustServerCertificate=True"));
            services.AddSingleton<CustomerRepository>();
            services.AddSingleton<RoomTypeRepository>();
            services.AddSingleton<RoomRepository>();
            services.AddSingleton<BookingDetailRepository>();
            services.AddSingleton<BookingReservationRepository>();


            services.AddTransient<Login_Window>();
            services.AddTransient<MainWindow>();
            services.AddTransient<UserProfile>();
            services.AddTransient<RoomManagerWindow>();
            services.AddTransient<BookingReservationWindow>();
            services.AddTransient<UserBookingWindow>();
            services.AddTransient<ReportWindow>();
        }

        public MainWindow GetMainWindow()
        {
            return _serviceProvider.GetRequiredService<MainWindow>();
        }

        public UserProfile GetProfileWindow()
        {
            return _serviceProvider.GetRequiredService<UserProfile>();
        }
        public RoomManagerWindow GetRoomInfoWindow()
        {
            return _serviceProvider.GetRequiredService<RoomManagerWindow>();
        }
        public BookingReservationWindow GetBookingReservationWindow()
        {
            return _serviceProvider.GetRequiredService<BookingReservationWindow>();
        }
        public UserBookingWindow GetUserBookingWindow()
        {
            return _serviceProvider.GetRequiredService<UserBookingWindow>();
        }
        public ReportWindow GetReportWindow()
        {
            return _serviceProvider.GetRequiredService<ReportWindow>();
        }
    }
}
