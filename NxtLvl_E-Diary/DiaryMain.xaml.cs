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
using System.Collections;

namespace NxtLvl_E_Diary
{
    /// <summary>
    /// Interaktionslogik für DiaryMain.xaml
    /// </summary>
    public partial class DiaryMain : Window
    {
        private int diaryID;

        public DiaryMain(int userID)
        {
            InitializeComponent();

            diaryManipulate diaryManipulation = new diaryManipulate();

            diaryID = diaryManipulation.createDiary(userID);

            // Aufruf hier ohne diaryID möglich? da bereits in klasse definiert
            updateDiaryList();
        }

        public void updateDiaryList()
        //public void updateDiaryList(int diaryID)
        {
            diaryManipulate diaryManipulation = new diaryManipulate();

            var updatedList = diaryManipulation.getEntryList(diaryID);

            dtagrdDiaryEntrys.ItemsSource = updatedList.Select(e => new { ID = e.id, Name = e.name, Date = e.date});
        }

        private void btnNewEntry_Click(object sender, RoutedEventArgs e)
        {
            createEntry createEntryWindows = new createEntry(diaryID,null,null,System.DateTime.MinValue);
            createEntryWindows.Show();

            this.Close();
        }

        private void btnDeleteEntry_Click(object sender, RoutedEventArgs e)
        {
            //var selectedEntry = (entry)dtagrdDiaryEntrys.SelectedItem;
            dynamic selectedEntry = dtagrdDiaryEntrys.SelectedItem;
            int selectedEntryID = selectedEntry.ID;

            diaryManipulate diaryManipulateDeleteEntry = new diaryManipulate();
            diaryManipulateDeleteEntry.deleteEntry(selectedEntryID);

            updateDiaryList();
        }

        private void btnEditEntry_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectedEntry = dtagrdDiaryEntrys.SelectedItem;
            int selectedEntryID = selectedEntry.ID;

            diaryManipulate diaryManipulateEditEntry = new diaryManipulate();
            entry entryToEdit = diaryManipulateEditEntry.editEntry(selectedEntryID);

            createEntry createEntryWindows = new createEntry(diaryID, entryToEdit.name, entryToEdit.text, entryToEdit.date);
            createEntryWindows.Show();

            this.Close();
        }
    }
}
