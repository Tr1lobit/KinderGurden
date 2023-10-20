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
    /// Interaction logic for PageJournal.xaml
    /// </summary>
    public partial class PageJournal : Page
    {
        public PageJournal()
        {
            InitializeComponent();
            ActivityCmb.ItemsSource = App.GetContext().Activity.ToList();
            ActivityTypeCmb.ItemsSource = App.GetContext().Direction.ToList();
            GroupCmb.ItemsSource = App.GetContext().GroupDS.ToList();
            GroupTypeCmb.ItemsSource = App.GetContext().VidGroup.ToList();
            GradeCmb.ItemsSource = App.GetContext().Mark.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";

            if (string.IsNullOrWhiteSpace(DateDP.Text))
                mes += "Выберите дату\n";
            
            if (string.IsNullOrWhiteSpace(GroupTypeCmb.Text))
                mes += "Выберите вид группы\n";
            
            if (string.IsNullOrWhiteSpace(GroupCmb.Text))
                mes += "Выберите группу\n";
            
            if (string.IsNullOrWhiteSpace(ActivityTypeCmb.Text))
                mes += "Выберите вид мероприятия\n";
            
            if (string.IsNullOrWhiteSpace(ActivityCmb.Text))
                mes += "Выберите мероприятие\n";
            
            if (string.IsNullOrWhiteSpace(GradeCmb.Text))
                mes += "Выберите оценку\n";

            if (mes != "")
                MessageBox.Show(mes);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageBody());
        }
    }
}
