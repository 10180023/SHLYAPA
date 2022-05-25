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

namespace ООО_Стройматериалы.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddEdit.xaml
    /// </summary>
    public partial class PageAddEdit : Page
    {
        Product product = new Product();

        public PageAddEdit(Product selectedProduct)
        {
            InitializeComponent();

            if (selectedProduct != null)
            {
                product = selectedProduct;

            }
            else
            {
                btnDel.Visibility = Visibility.Hidden;
            }

            DataContext = product;

            cbCategory.ItemsSource = DB.db.ProductCategory.ToList();
            cbManuf.ItemsSource = DB.db.Manufacturer.ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "а", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    var op = DB.db.OrderProduct.Where(o => o.ProductID == product.ProductID).FirstOrDefault();

                    if (op == null)
                    {
                        DB.db.Product.Remove(product);
                        DB.db.SaveChanges();
                        MessageBox.Show("Удалено");
                        Manager.mainFrame.GoBack();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tbTitle.Text == null)
            {
                errors.AppendLine("Добавть название");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (product.ProductID == 0)
            {
                DB.db.Product.Add(product);
            }

            try
            {
                DB.db.SaveChanges();
                MessageBox.Show("Успешно");
                Manager.mainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
