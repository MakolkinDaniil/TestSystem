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

namespace TRBD_WPF
{
    /// <summary>
    /// Логика взаимодействия для UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        public UserPanel()
        {
            InitializeComponent();
            bindcombo();
            TestDG.ItemsSource = DataBaseTestSystemEntities1.GetContext().Result.ToList();
            DataBaseTestSystemEntities1 db = new DataBaseTestSystemEntities1();
            LabelLogin.Content = DataBank.TextLogin; 
            // Из переменной Text класса DataBank берём логин.
            var user = db.Users.Where(u => u.Login == DataBank.TextLogin && u.Password == DataBank.TextPassword).SingleOrDefault(); 
            // Контекст таблицы user для обращения к данным.
            string FIO = user.FIO;
            LabelFIO.Content = FIO;
        }
        public List<Test> tes { get; set; }
        private void bindcombo() // Привязка данных к combobox.
        {
            DataBaseTestSystemEntities1 db = new DataBaseTestSystemEntities1();
            var item = db.Test.ToList();
            tes = item;
            DataContext = tes;
        }


        public class dataGrid
        {
            public string TestName { get; set; }
            public string Rating { get; set; }
            public string Time { get; set; }
            public string Scores { get; set; }
            public string Data { get; set; }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeData ChangeD = new ChangeData();
            ChangeD.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataBank.TextCB = cb.Text;
            // Берём выбранный вариант в combobox и засовываем в переменную.
            if (cb.SelectedItem != null)
            {
                Testing tst = new Testing();
                tst.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Выберете тест");
            }
        }
    }
}
