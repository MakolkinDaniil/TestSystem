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
using System.Data.SqlClient;

namespace TRBD_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DataBaseTestSystemEntities1 db = new DataBaseTestSystemEntities1();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Login1 = TBLogin.Text;
            var Password1 = TBPassword.Text;
            DataBank.TextLogin = TBLogin.Text; // в переменную Text класса DataBank запишем текст из текстбокса TBLogin
            DataBank.TextPassword = TBPassword.Text;

            if ((TBLogin.Text != "" || TBPassword.Text != ""))
            {
                var user = db.Users.Where(u => u.Login == Login1 && u.Password == Password1).SingleOrDefault();
                if (user != null)
                {
                    switch (user.UserTypeID)
                    {
                        case 1:
                            {
                                MessageBox.Show("Авторизация прошла успешно");
                                UserPanel userP = new UserPanel();
                                userP.Show();
                                this.Hide();
                            }
                            break;
                        case 2:
                            {
                                MessageBox.Show("Авторизация прошла успешно");
                                AdminPanel admP = new AdminPanel();
                                admP.Show();
                                this.Hide();
                            }
                            break;
                    }
                } else { MessageBox.Show("Неверный логин или пароль"); }
            } else { MessageBox.Show("Не все поля заполнены"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TBLogin.Text = "";
            TBPassword.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }
    }
}
