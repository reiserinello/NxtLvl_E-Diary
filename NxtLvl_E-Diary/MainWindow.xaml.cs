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

            diaryManipulate manipulateTypes = new diaryManipulate();
            manipulateTypes.createTypes();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string varUsername = txtUsername.Text;
            string varPassword = txtPassword.Password;
            
            if (varUsername != null && varUsername != string.Empty && varPassword != null && varPassword != string.Empty)
            {
                userManipulate checkSubmitedCreds = new userManipulate();

                var loginSuccessful = checkSubmitedCreds.CheckUserLogin(varUsername, varPassword);

                if (loginSuccessful == true)
                {
                    int userID = checkSubmitedCreds.getUserID(varUsername);

                    DiaryMain DiaryMainWindow = new DiaryMain(userID);
                    DiaryMainWindow.Show();

                    // Hide because it's the main window / .close() would close the whole application
                    this.Close();
                }
            } 
            else
            {
                MessageBox.Show("Please enter values for Username and Password","Attention");
            }
        }
    }
}
