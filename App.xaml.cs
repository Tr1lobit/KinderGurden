using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AfonichevKinderGarden.Model;

namespace AfonichevKinderGarden
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static KinderGardenEntities _context;

        public static KinderGardenEntities GetContext()
        {
            if(_context==null)
            {
                _context = new KinderGardenEntities();
            }
            return _context;
        }
	} 
}
