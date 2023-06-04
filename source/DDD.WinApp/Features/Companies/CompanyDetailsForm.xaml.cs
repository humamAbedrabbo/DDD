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

namespace DDD.WinApp.Features.Companies
{
    /// <summary>
    /// Interaction logic for CompanyDetailsForm.xaml
    /// </summary>
    public partial class CompanyDetailsForm : Window
    {
        public CompanyDetailsForm(CompanyViewModel model)
        {
            InitializeComponent();

            Model = model;

            this.DataContext = Model;

            Dispatcher.Invoke(async () => await Model.Load());
        }

        public CompanyViewModel Model { get; }
    }
}
