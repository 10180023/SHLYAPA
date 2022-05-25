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
using ООО_Стройматериалы.Pages;
using ООО_Стройматериалы.Windows;

namespace ООО_Стройматериалы
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User u = new User();
        

        public MainWindow()
        {
            InitializeComponent();

            Manager.mainFrame = mainFrame;

            Manager.mainFrame.Navigate(new PageProducts());

            u = DB.db.User.Where(u => u.UserID == Properties.Settings.Default.GlobalUserID).FirstOrDefault();

            if (Properties.Settings.Default.GlobalRole != 0)
            {
                tbName.Text += u.UserSurname + " " + u.UserName + " " + u.UserPatronymic;
                tbRole.Text = u.Role.ToString();
            }
            else
            {
                tbName.Text += "здравстуйте, гость";
                tbRole.Visibility = Visibility.Hidden;
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            new WindowAuthorization().Show();
            this.Close();
        }
    }
}
