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
using AfonichevKinderGarden.Model;

namespace AfonichevKinderGarden.PageMain
{
    /// <summary>
    /// Interaction logic for PageAddGroup.xaml
    /// </summary>
    public partial class PageAddGroup : Page
    {
        public PageAddGroup()
        {
            InitializeComponent();
            GroupTypeCmb.ItemsSource = App.GetContext().VidGroup.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string addCheck = "";

            if (string.IsNullOrWhiteSpace(GroupTb.Text))
            {
                addCheck += "Введите имя группы\n";
            }
            if (string.IsNullOrWhiteSpace(GroupTypeCmb.Text))
            {
                addCheck += "Выберите тип группы\n";
            }

            if (addCheck != "")
            {
                MessageBox.Show(addCheck);
                addCheck = "";
                return;
            }

            GroupDS groupDS = new GroupDS()
            {
                Name = GroupTb.Text,
                VidGroup = GroupTypeCmb.SelectedItem as VidGroup
            };

            App.GetContext().GroupDS.Add(groupDS);
            App.GetContext().SaveChanges();
            MessageBox.Show("Группа добавлена!");

        }
    }
}
