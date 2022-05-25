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
    /// Логика взаимодействия для PageProducts.xaml
    /// </summary>
    public partial class PageProducts : Page
    {
        public PageProducts()
        {
            InitializeComponent();
            var category = DB.db.Manufacturer.ToList();

            cbSort.Items.Add("Сортировка");
            cbSort.Items.Add("По возрастанию стоимости");
            cbSort.Items.Add("По убыванию стоимости");


            category.Insert(0, new Manufacturer { Title = "Все производители" });
            cbFilter.ItemsSource = category;

            cbFilter.SelectedValuePath = "ManufacturerID";
            cbFilter.DisplayMemberPath = "Title";

            cbFilter.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;

            lvProducts.ItemsSource = DB.db.Product.ToList();

            if (Properties.Settings.Default.GlobalRole != 1)
            {
                btnAdd.Visibility = Visibility.Hidden;
                lvProducts.MouseDoubleClick -= lvProducts_MouseDoubleClick;
            }
            else
            {
                lvProducts.ToolTip = "Для просмотра нажмите дважды";
            }
        }

        void UpdateProducts()
        {
            var currentProducts = DB.db.Product.ToList();

            if (cbSort.SelectedIndex > 0)
            {
                switch (cbSort.SelectedIndex)
                {
                    case 1:
                        currentProducts = currentProducts.OrderBy(p => p.ProductCost).ToList();
                        break;
                    case 2:
                        currentProducts = currentProducts.OrderByDescending(p => p.ProductCost).ToList();
                        break;
                    default:
                        break;
                }
            }

            if (cbFilter.SelectedIndex > 0)
            {
                currentProducts = currentProducts.Where(p => p.ProductManufacturerID == int.Parse(cbFilter.SelectedValue.ToString())).ToList();
            }

            if (!string.IsNullOrEmpty(tbFinder.Text))
            {
                currentProducts = currentProducts.Where(p => p.ProductName.ToLower().Contains(tbFinder.Text.ToLower().ToString())).ToList();
            }          

            lvProducts.ItemsSource = currentProducts;

            tbCount.Text = lvProducts.Items.Count.ToString();
            tbAllCount.Text = DB.db.Product.Count().ToString();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new PageAddEdit(new Product()));
        }

        private void lvProducts_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DB.db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            lvProducts.ItemsSource = DB.db.Product.ToList(); ;
        }

        private void tbFinder_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void lvProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Manager.mainFrame.Navigate(new PageAddEdit(lvProducts.SelectedItem as Product));
        }

        
    }
}
