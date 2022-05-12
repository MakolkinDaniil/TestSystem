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
using System.Data.Entity;

namespace TRBD_WPF
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        DataBaseTestSystemEntities1 db = new DataBaseTestSystemEntities1();
        public static DataBaseTestSystemEntities1 DataBaseTestSystemEntities1;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login.Text = ""; FIO.Text = ""; Password.Text = ""; PasswordAgain.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var user = db.Users.Where(u => u.Login == DataBank.TextLogin && u.Password == DataBank.TextPassword).SingleOrDefault();
            if (Login.Text == "" || FIO.Text == "" || Password.Text == "" || PasswordAgain.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                var loginCheck = db.Users.Where(u => u.Login == Login.Text).SingleOrDefault();
                // Проверяем, есть ли данный логин в базе или нет.
                // Если текущий логин и логин в поле ввода совпадает, то сообщение показывать не надо.
                if (loginCheck != null)
                { // Обрезаем пробелы в конце.
                    MessageBox.Show("Логин занят, выберете другой");
                }
                else
                {
                    if (Password.Text != PasswordAgain.Text) { MessageBox.Show("Введённые пароли не совпадают"); }
                    else
                    {
                        if (Password.Text.Length < 6) { MessageBox.Show("Пароль не может быть короче 6 символов"); }
                        else
                        {
                            bool numb = Password.Text.Any(char.IsDigit);
                            // Проверка на цифры в строке.
                            if (numb == false) { MessageBox.Show("Пароль должен содержать по-крайней мере одну цифру"); }
                            else
                            {
                                if (Latchar(Password.Text) == false)
                                {
                                    MessageBox.Show("Пароль должен содержать по-крайней мере одну заглавную и одну строчную латинскую букву");
                                }
                                else
                                {
                                    Users users = new Users // считываем данные из textbox и присваиваем эти данные переменным
                                    {
                                        Login = Login.Text,
                                        FIO = FIO.Text,
                                        Password = Password.Text,
                                        UserTypeID = 1
                                    };
                                    db.Users.Add(users);
                                    // Эти переменные под именем users добавляем в таблицу Users

                                    if (users != null)
                                    {
                                        db.SaveChanges();
                                        MessageBox.Show("Регистрация прошла успешно");
                                        DataBank.TextLogin = Login.Text; // в переменную Text класса DataBank запишем текст из текстбокса TBLogin
                                        DataBank.TextPassword = Password.Text;
                                        UserPanel UsP = new UserPanel(); UsP.Show();
                                        MainWindow Mw = new MainWindow(); Mw.Hide();
                                        this.Hide();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static bool Latchar(string ss)
        {
            bool REGISTR = false;
            bool registr = false;
            for (int i = 0; i < ss.Length; i++)
            {
                if (((ss[i] >= 'A') && (ss[i] <= 'Z'))) REGISTR = true;
                if (((ss[i] >= 'a') && (ss[i] <= 'z'))) registr = true;
            }
            if (REGISTR == true && registr == true) { return true; }
            else { return false; }
        }
    }
}
