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

namespace Телефонный_справочник
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Телефонный_справочникEntities1())
                {
                    var groupCont = new Группа_контактов();
                    int ID=0;
                    var contact = new Контакт();

                    switch (ID_group.SelectedIndex)
                    {
                        case 0:
                            ID=1;
                            groupCont = db.Группа_контактов.Find(ID);
                            //Друзья
                            break;
                        case 1:
                            ID = 2;
                            groupCont = db.Группа_контактов.Find(ID);
                            //Коллеги
                            break;
                        case 2:
                            ID = 3;
                            groupCont = db.Группа_контактов.Find(ID);
                            //Родственники
                            break;
                    }

                    int i = Convert.ToInt32(Company.Text);
                    contact.Фамилия = Lastname.Text;
                    contact.Имя = Namecont.Text;
                    contact.Отчество = nameTB.Text;
                    contact.Номер_Телефона = number.Text;
                    contact.E_mail = email.Text;
                    contact.Компания = i;
                    contact.Должность = WorkTb.Text;
                    contact.Группа_контактов =groupCont;
                    contact.Дата_Рождения = Convert.ToDateTime(datebirth1.Text);
                    //contact.Фото
                    db.Контакт.Add(contact);
                    db.SaveChanges();

                    MainWindow MW = new MainWindow();
                    MW.DGrid.ItemsSource = db.Группа_контактов.ToList();
                    MW.DGrid.ItemsSource = db.Контакт.ToList();
                }
                MessageBox.Show("Информация сохранена!");
            }
            catch
            {
                MessageBox.Show("Ошибка БД");
            }
            
        }
    }
}
