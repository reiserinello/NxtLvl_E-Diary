﻿using System;
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

namespace NxtLvl_E_Diary
{
    /// <summary>
    /// Interaktionslogik für createEntry.xaml
    /// </summary>
    public partial class createEntry : Window
    {
        private int entryDiaryID;
        public createEntry(int diaryID, string entryTitle, string entryText, DateTime entryDate)
        {
            InitializeComponent();

            entryDiaryID = diaryID;

            if (entryText != null && entryText != null)
            {
                txtEntryTitle.Text = entryTitle;
                txtEntryText.Text = entryText;
                dtpEntryDate.SelectedDate = entryDate;
            }
        }

        private void btnSaveEntry_Click(object sender, RoutedEventArgs e)
        {
            string entryTitle = txtEntryTitle.Text;
            string entryText = txtEntryText.Text;
            DateTime entryDate = dtpEntryDate.SelectedDate.Value.Date;

            diaryManipulate manipulateDiary = new diaryManipulate();
            manipulateDiary.createEntry(entryDiaryID, entryTitle, entryText, entryDate);

            DiaryMain diaryMainClass = new DiaryMain(entryDiaryID);
            diaryMainClass.Show();

            this.Close();
        }
    }
}
