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

            GroupTypeCmb.SelectedValuePath = "Id";
            GroupTypeCmb.DisplayMemberPath = "Name";
            GroupTypeCmb.ItemsSource = App.GetContext().VidGroup.ToList();

            GroupCmb.SelectedValuePath = "Id";
            GroupCmb.DisplayMemberPath = "Name";
            GroupCmb.ItemsSource = App.GetContext().GroupDS.ToList();

            ActivityTypeCmb.SelectedValuePath = "Id";
            ActivityTypeCmb.DisplayMemberPath = "Name";
            ActivityTypeCmb.ItemsSource = App.GetContext().Direction.ToList();

            ActivityCmb.SelectedValuePath = "Id";
            ActivityCmb.DisplayMemberPath = "Name";
            ActivityCmb.ItemsSource = App.GetContext().Activity.ToList();

            GradeCmb.SelectedValuePath = "Id";
            GradeCmb.DisplayMemberPath = "Name";
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

            if (mes == "")
            {
                Journal journal = new Journal()
                {
                    DateZan = (DateTime)DateDP.SelectedDate,
                    GroupDS = GroupCmb.SelectedItem as GroupDS,
                    Activity = ActivityCmb.SelectedItem as Activity,
                    Mark = GradeCmb.SelectedItem as Mark
                };

                App.GetContext().Journal.Add(journal);
                App.GetContext().SaveChanges();
                MessageBox.Show("Оценка проставлена!");
                NavigationService.Navigate(new PageBody());
            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageBody());
        }

        private void GroupTypeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedGT = Convert.ToInt32(GroupTypeCmb.SelectedValue);
            GroupCmb.ItemsSource = App.GetContext().GroupDS.Where(x => x.IdVidGroup == selectedGT).ToList();
        }

        private void ActivityTypeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedAT = Convert.ToInt32(ActivityTypeCmb.SelectedValue);
            ActivityCmb.ItemsSource = App.GetContext().Activity.Where(x => x.IdDirection == selectedAT).ToList();
        }
    }
}
