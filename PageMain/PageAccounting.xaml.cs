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

namespace AfonichevKinderGarden.PageMain
{
    /// <summary>
    /// Interaction logic for PageAccounting.xaml
    /// </summary>
    public partial class PageAccounting : Page
    {
        public PageAccounting()
        {
            InitializeComponent();
            GroupCmb.SelectedValuePath = "Id";
            GroupCmb.DisplayMemberPath = "Name";
            GroupCmb.ItemsSource = App.GetContext().GroupDS.ToList();

            GroupDG.SelectedValuePath = "Id";
            GroupDG.ItemsSource = App.GetContext().Journal.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageBody());
        }

        private void GroupCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedGroup = Convert.ToInt32(GroupCmb.SelectedValue);
            GroupDG.ItemsSource = App.GetContext().Journal.Where(j => j.IdGroupDS == selectedGroup).ToList();
        }
    }
}
