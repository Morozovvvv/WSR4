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

namespace Magazin
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
        }

     
        private void buttonDeleted_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = Dtproduct.SelectedItems.Cast<Product>().ToList();                                      // если не работает удаление в sql поменять отношения на каскадные
            if (MessageBox.Show($"Вы точно хотите удалить следующие {productForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TradeEntities4.GetContext().Products.RemoveRange(productForRemoving);
                    TradeEntities4.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    Dtproduct.ItemsSource = TradeEntities4.GetContext().Products.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd add = new WindowAdd(null);
            add.ShowDialog();
        }

        private void buttonReload_Click(object sender, RoutedEventArgs e)
        {
            TradeEntities4.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Dtproduct.ItemsSource = TradeEntities4.GetContext().Products.ToList();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            Avtorizaciya vxod = new Avtorizaciya();
            vxod.Show();
            this.Close();
        }

        
    }
}
