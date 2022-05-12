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
using System.Windows.Threading;

namespace TRBD_WPF
{
    /// <summary>
    /// Логика взаимодействия для Testing.xaml
    /// </summary>
    public partial class Testing : Window
    {
        static int tickTest = 3600;
        static int tickQuestion = 120;
        static int i = 0;
        public Testing()
        {
            //int i = 0;
            InitializeComponent();
            DataBaseTestSystemEntities1 db = new DataBaseTestSystemEntities1();
            var user = db.Users.Where(u => u.Login == DataBank.TextLogin && u.Password == DataBank.TextPassword).SingleOrDefault(); 
            // Контекст таблицы user для обращения к данным.
            string FIO = user.FIO;
            LabelFIO.Content = FIO;
            LabelTestName.Content = DataBank.TextCB;
            //var question = db.Questions.Where(u => u.TestID == TextBoxQuestion.Text).SingleOrDefault();

            var testid = db.Test.Where(u => u.TestName == DataBank.TextCB).SingleOrDefault();

            //string[] QuestTest = new string[100];
            

            var timerTest = new System.Timers.Timer();
            timerTest.Interval = 1000;
            timerTest.Elapsed += TimeTest;
            timerTest.Start();

            if (tickTest == 0)
            {
                // Завершаем тест.
            }

            var timerQuestion = new System.Timers.Timer();
            timerQuestion.Interval = 1000;
            timerQuestion.Elapsed += TimeQuestion;
            timerQuestion.Start();


            if (tickQuestion == 0)
            {
                string question = db.Questions.Where(u => u.TestID == testid.TestID).ToList();
                i++;
                TextBoxQuestion.Text = question[i];
                // Переходим на следующий вопрос.
                tickQuestion = 120;
            }

        }

        private void TimeTest(object sender, EventArgs e)
        {
            tickTest--;
            TimeTestLabel.Dispatcher.Invoke(() =>
            {
                TimeTestLabel.Content = tickTest/60 + " Минут " + tickTest % 60 + " Секунд";
            });
        }

        private void TimeQuestion(object sender, EventArgs e)
        {
            tickQuestion--;
            TimeQuestionLabel.Dispatcher.Invoke(() =>
            {
                TimeQuestionLabel.Content = tickQuestion / 60 + " Минут " + tickQuestion % 60 + " Секунд";
            });
        }

        private void ButtonAnswer_Click(object sender, RoutedEventArgs e)
        {
            DataBaseTestSystemEntities1 db = new DataBaseTestSystemEntities1();
            var testid = db.Test.Where(u => u.TestName == DataBank.TextCB).SingleOrDefault();
            string question = db.Questions.Where(u => u.TestID == testid.TestID).ToList(); // CS0029 №1.
            i++;
            TextBoxQuestion.Text = question[i]; // CS0029 №2.
            /*
            //Conn.Open();
            SqlCommand GetQuest = db.CreateCommand();
            int g = Convert.ToInt32(QuestTest[i]);
            GetQuest.CommandText = "Select Question from [Questions] where ID = '" + g + "'";
            string Question = Convert.ToString(GetTextQuest.ExecuteScalar());
            TextBoxQuestion.Text = Question;
            */
        }
    }
}
