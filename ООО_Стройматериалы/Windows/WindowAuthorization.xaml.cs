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

namespace ООО_Стройматериалы.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        public WindowAuthorization()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = DB.db.User.Where(u => u.UserLogin == tbLogin.Text).FirstOrDefault();

            if (user != null)
            {
                if (user.UserPassword == tbPass.Password)
                {
                    switch (user.UserRole)
                    {
                        case 1:
                            Properties.Settings.Default.GlobalRole = 1;
                            Properties.Settings.Default.GlobalUserID = user.UserID;
                            new MainWindow().Show();
                            this.Close();
                            break;
                        case 2:
                            Properties.Settings.Default.GlobalRole = 2;
                            Properties.Settings.Default.GlobalUserID = user.UserID;
                            new MainWindow().Show();
                            this.Close();
                            break;
                        case 3:
                            Properties.Settings.Default.GlobalRole = 3;
                            Properties.Settings.Default.GlobalUserID = user.UserID;
                            new MainWindow().Show();
                            this.Close();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Properties.Settings.Default.GlobalRole = 0;
            this.Close();
        }
    }
}
