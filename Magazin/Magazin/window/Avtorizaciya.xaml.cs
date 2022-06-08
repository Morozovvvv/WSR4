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
using System.Windows.Threading; // таймер

namespace Magazin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Avtorizaciya : Window
    {
        public DispatcherTimer timer = new DispatcherTimer(); // таймер
        public Avtorizaciya()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += capchatimer;
        }
        int intrerv = 10; // сколько секунд будет идти таймер 
        public void capchatimer(object sender, EventArgs e)
        {
            intrerv--;
            if (intrerv == 0)
            {
                timer.Stop();
                intrerv = 10;
                buttonVoxd.IsEnabled = true;                        // кнопка после 10 секунд  активна 
                labelSeconds.Visibility = Visibility.Hidden;        // лейбел с секундами скрыт
                CaptchaGenerator();
            }
            labelSeconds.Content = Convert.ToString(intrerv); // показывает сколько секунд заблокированна кнопка 
        }
        private void capchaRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            CaptchaGenerator();
        }

        private void buttonVoxd_Click(object sender, RoutedEventArgs e)     // кнопка ввхода 

        {
            string login = "admin";                                                                
            string password = "admin";
            StringBuilder errors = new StringBuilder();
            if (textBoxLogin.Text == "")
                errors.AppendLine("логин пустой");
            if (textBoxPassword.Password == "")
                errors.AppendLine("пароль пустой");  
            if (capchaBox.Text!= gencapchaBox.Text && stackpanelCapcha.Visibility == Visibility.Visible)
                errors.AppendLine("капча введена неверно");
            if (textBoxLogin.Text != login)
                errors.AppendLine("логин введен неверно");
            if (textBoxPassword.Password!=password)
                errors.AppendLine("пароль введен неверно");
            if (errors.Length > 0)                                                              
            {
                if (stackpanelCapcha.Visibility==Visibility.Visible && capchaBox.Text != gencapchaBox.Text)
                {
                    timer.Start();
                    buttonVoxd.IsEnabled = false;
                    labelSeconds.Visibility = Visibility.Visible;
                }
                else
                {
                    stackpanelCapcha.Visibility = Visibility.Visible;
                    labelCapcha.Visibility = Visibility.Visible;
                    capchaRefreshButton.Visibility = Visibility.Visible;
                    CaptchaGenerator();
                }
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                ProductWindow pr = new ProductWindow();
                pr.Show();
                this.Close();

            }


        }

        void CaptchaGenerator()  // метод генерации капчи 
        {
            char[] chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789".ToCharArray();
            string randomString = "";
            Random ran = new Random();
            for (int i = 0; i < 5; i++)
            {
                randomString += chars[ran.Next(0, chars.Length)];
            }
            gencapchaBox.Text = randomString;
        }

    }
}
