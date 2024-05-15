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
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        public AddEdit()
        {
            InitializeComponent();
        }

        public int id;
        public int cont
        {
            get { return id; }
            set { id = value; }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Телефонный_справочникEntities1())
                {
                    //Контакт contact = db.Контакт.Find(cont);
                    //Группа_контактов group = db.Группа_контактов.Find(contact.ID_Группа_контактов);

                    //Lastname.Text = contact.Фамилия;
                    //Namecont.Text = contact.Имя;
                    //nameTB.Text = contact.Отчество;
                    //number.Text = contact.Номер_Телефона;
                    //datebirth1.Text = contact.Дата_Рождения.ToString();
                    //email.Text = contact.E_mail;
                    //Company.Text = contact.Компания.ToString();
                    //WorkTb.Text = contact.Должность;
                    ////ID_group.ItemsSource = group.Название_группы;
                    ////imagescont.Source = contact.Фото;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка БД");
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Телефонный_справочникEntities1())
                {
                    var groupCont = new Группа_контактов();
                    int ID = 0;
                    var contact = new Контакт();

                    switch (ID_group.SelectedIndex)
                    {
                        case 0:
                            ID = 1;
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

                    var cont = new Контакт();
                    int i = Convert.ToInt32(Company.Text);

                    cont.Фамилия = Lastname.Text;
                    cont.Имя = Namecont.Text;
                    cont.Отчество = nameTB.Text;
                    cont.Номер_Телефона = number.Text;
                    cont.E_mail = email.Text;
                    cont.Компания = i;
                    cont.Должность = WorkTb.Text;
                    cont.Группа_контактов = groupCont;
                    cont.Дата_Рождения = Convert.ToDateTime(datebirth1.Text);
                    //cont.Фото

                    
                    db.SaveChanges();
                }
                MessageBox.Show("Запись обновлена");
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения");
            }
            
        }
    }
}
