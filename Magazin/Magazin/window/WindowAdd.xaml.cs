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
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        private Product _currentproduct = new Product();
        public WindowAdd(Product selectedproduct)
        {
            InitializeComponent();
            if (selectedproduct != null)
                _currentproduct = selectedproduct;
            DataContext = _currentproduct;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            TradeEntities4.GetContext().Products.Add(_currentproduct);
            TradeEntities4.GetContext().SaveChanges();
            MessageBox.Show("Успешно добавлено");
            this.Close();
        }
    }
}
