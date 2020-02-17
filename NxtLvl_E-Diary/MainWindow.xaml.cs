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

namespace NxtLvl_E_Diary
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            databaseContext ctx = new databaseContext();

            if(!ctx.tableObjUser.Any())
            {
                var diaryUser = new user() { username = "Fabrice", password = "gurke" };

                ctx.tableObjUser.Add(diaryUser);
                ctx.SaveChanges();
            }
        }
    }
}
