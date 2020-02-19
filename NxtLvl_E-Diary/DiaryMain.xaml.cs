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
using System.Runtime.InteropServices;

namespace NxtLvl_E_Diary
{
    /// <summary>
    /// Interaktionslogik für DiaryMain.xaml
    /// </summary>
    public partial class DiaryMain : Window
    {
        public DiaryMain(int userID)
        {
            InitializeComponent();

            diaryManipulate diaryManipulation = new diaryManipulate();

            int diaryID = diaryManipulation.createDiary(userID);

            updateDiaryList(diaryID);
        }

        public void updateDiaryList(int diaryID)
        {
            diaryManipulate diaryManipulation = new diaryManipulate();

            var updatedList = diaryManipulation.getEntryList(diaryID);

            dtagrdDiaryEntrys.ItemsSource = updatedList.Select(e => new { ID = e.id, Name = e.name, Date = e.date});
        }

        private void btnNewEntry_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
