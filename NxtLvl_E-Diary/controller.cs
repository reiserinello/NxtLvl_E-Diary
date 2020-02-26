using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NxtLvl_E_Diary
{
    public class userManipulate
    {
        public bool CheckUserLogin(string insertedUsername, string insertedPassword)
        {
            using (var ctx = new databaseContext())
            {
                return ctx.tableObjUser.Any(u => u.username == insertedUsername && u.password == insertedPassword);
            }
        }

        public int getUserID(string loggedOnUser)
        {
            using (var ctx = new databaseContext())
            {
                return ctx.tableObjUser.Single(u => u.username == loggedOnUser).id;
            }
        }
    }

    public class typeManipulate
    {
        /*public void createTypes()
        {
            using(var ctx = new databaseContext())
            {
                if(!ctx.tableObjType.Any())
                {

                }
            }
        }*/


    }

    public class diaryManipulate
    {
        public int createDiary (int userID)
        {
            using (var ctx = new databaseContext())
            {
                // Get diary if it exists on user
                var existingDiary = ctx.tableObjDiary.Any(d => d.user_id == userID);

                // If diary not exist, create it and return id
                if (existingDiary != true)
                {
                    string diaryName = "diary_" + userID;
                    diary newDiary = new diary() { name = diaryName, user_id = userID };
                    ctx.tableObjDiary.Add(newDiary);
                    ctx.SaveChanges();

                    return ctx.tableObjDiary.Single(d => d.name == diaryName).id;
                } 
                else
                {
                    // If diary exists, just return id
                    return ctx.tableObjDiary.Single(d => d.user_id == userID).id;
                }
            }
        }
        public List<entry> getEntryList (int diaryID)
        {
            List<entry> entryList = new List<entry>();
            using (var ctx = new databaseContext())
            {
                
                entryList = ctx.tableObjentry.Where(e => e.diary_id == diaryID).ToList();

                return entryList;
            }
        }

        public void createEntry (bool updateEntry, int diaryID, int entryID, string title, string text, List<CheckBox> checkedBoxesTypes, DateTime entryDate)
        {
            int entryType1_id = 0;
            int entryType2_id = 0;
            int entryType3_id = 0;
            entry newEntry = new entry();

            using (var ctx = new databaseContext())
            {
                if (updateEntry == true)
                {
                    var entryToEdit = ctx.tableObjentry.Single(e => e.id == entryID);

                    entryToEdit.name = title;
                    entryToEdit.text = text;
                    entryToEdit.date = entryDate;
                }
                else
                {
                    if (checkedBoxesTypes.ElementAtOrDefault(0) != null)
                    {
                        string type1 = checkedBoxesTypes[0].Content.ToString();
                        entryType1_id = ctx.tableObjType.Single(t => t.typename == type1).id;
                    } 
                    if (checkedBoxesTypes.ElementAtOrDefault(1) != null)
                    {
                        string type2 = checkedBoxesTypes[1].Content.ToString();
                        entryType2_id = ctx.tableObjType.Single(t => t.typename == type2).id;
                    }
                    if (checkedBoxesTypes.ElementAtOrDefault(2) != null)
                    {
                        string type3 = checkedBoxesTypes[2].Content.ToString();
                        entryType3_id = ctx.tableObjType.Single(t => t.typename == type3).id;
                    }

                    if (entryType1_id != 0)
                    {
                        if (entryType2_id != 0)
                        {
                            if (entryType3_id != 0)
                            {
                                newEntry = new entry() { name = title, text = text, date = entryDate, entryType1_id = entryType1_id, entryType2_id = entryType2_id, entryType3_id = entryType3_id, diary_id = diaryID };
                            }
                            else
                            {
                                newEntry = new entry() { name = title, text = text, date = entryDate, entryType1_id = entryType1_id, entryType2_id = entryType2_id, diary_id = diaryID };
                            }
                        }
                        else
                        {
                            newEntry = new entry() { name = title, text = text, date = entryDate, entryType1_id = entryType1_id, diary_id = diaryID };
                        }
                    }
                    else
                    {
                        newEntry = new entry() {name = title,text = text,date = entryDate,diary_id = diaryID};
                    }
                    ctx.tableObjentry.Add(newEntry);
                }
                ctx.SaveChanges();
            }
        }

        public void deleteEntry (int entryID)
        {
            using (var ctx = new databaseContext())
            {
                var entryToDelete = ctx.tableObjentry.Where(e => e.id == entryID).First();
                ctx.tableObjentry.Remove(entryToDelete);
                ctx.SaveChanges();
            }
        }

        public entry loadEntry (int entryID)
        {
            using (var ctx = new databaseContext())
            {
                var getEntry = ctx.tableObjentry.Where(e => e.id == entryID).First();

                return getEntry;
            }
        }

        public void createTypes ()
        {
            List<String> myTypes = new List<string>() { "Family", "Sport","Work","School","Friends"};
            using (var ctx = new databaseContext())
            {
                foreach (string myType in myTypes)
                {
                    if (!ctx.tableObjType.Any(t => t.typename == myType))
                    {
                        type myNewType = new type() { typename = myType };
                        ctx.tableObjType.Add(myNewType);
                    }
                }
                ctx.SaveChanges();
            }
        }
    }
    /*
    class controller
    {
    }
    */
}
