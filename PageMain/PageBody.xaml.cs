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
    /// Interaction logic for PageBody.xaml
    /// </summary>
    public partial class PageBody : Page
    {
        public PageBody()
        {
            InitializeComponent();
        }

        private void AddGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddGroup());
        }

        private void AddActivityBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddActivity());
        }
    }
}
