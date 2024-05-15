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
using System.IO;

namespace Телефонный_справочник
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            try
            {
                using (var db = new Телефонный_справочникEntities1())
                {
                    Контакт contact = new Контакт();

                    DGrid.ItemsSource = db.Группа_контактов.ToList();
                    DGrid.ItemsSource = db.Контакт.ToList();
                    
                }
            }

            catch
            {
                MessageBox.Show("Ошибка БД");
            }
        }
        

        private void SpisokBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Телефонный_справочникEntities1())
                {
                    Контакт contact = new Контакт();

                    DGrid.ItemsSource = db.Группа_контактов.ToList();
                    DGrid.ItemsSource = db.Контакт.ToList();

                }
            }

            catch
            {
                MessageBox.Show("Ошибка БД");
            }

        }

        private void visibleform(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Телефонный_справочникEntities1())
            {
                AddEdit edit = new AddEdit();

                //edit.cont = ((Контакт)DGrid.SelectedItem).ID;
                edit.Show();

                Контакт contact = db.Контакт.Find(((Контакт)DGrid.SelectedItem).ID);

                edit.Lastname.Text = contact.Фамилия;
                edit.Namecont.Text = contact.Имя;
                edit.nameTB.Text = contact.Отчество;
                edit.number.Text = contact.Номер_Телефона;
                edit.datebirth1.Text = contact.Дата_Рождения.ToString();
                edit.email.Text = contact.E_mail;
                edit.Company.Text = contact.Компания.ToString();
                edit.WorkTb.Text = contact.Должность;
                //ID_group.ItemsSource = group.Название_группы;
                //imagescont.Source = contact.Фото;

            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using ( var db = new Телефонный_справочникEntities1())
            {
                
                if(MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int id = ((Контакт)DGrid.SelectedItem).ID;

                    Контакт cont = db.Контакт.Find(id);
                    db.Контакт.Remove(cont);
                    db.SaveChanges();
                    MessageBox.Show("Запись удалена");
                    DGrid.ItemsSource = db.Группа_контактов.ToList();
                    DGrid.ItemsSource = db.Контакт.ToList();
                }
                else
                {
                    MessageBox.Show("Запись не удалена");
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var Add = new AddWindow();
            
            Add.Show();
        }

        private void poiskBtn_Click(object sender, RoutedEventArgs e)
        {
            string posikovik = poiskTB.Text;

            using (var db =new Телефонный_справочникEntities1())
            {
                Контакт contact = new Контакт();

                var contact1 = db.Контакт.FirstOrDefault(s => s.Фамилия == posikovik);

                if(contact1 != null)
                {
                      
                }
                else
                {
                    MessageBox.Show("Введите фамилию");
                }
            }
        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {
      
            using (var stream = new StreamWriter("D:\\test.csv", false, Encoding.UTF8))
            {
                stream.WriteLine("\"{0:yyyy-MM-dd HH:mm:ss}\",\"{1}\"", DateTime.Now, this.DGrid.ContextMenu);
                MessageBox.Show("Информация сохранена!");
            }

        }
    }
}
