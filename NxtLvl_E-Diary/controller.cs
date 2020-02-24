using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void createEntry (int diaryID, string title, string text, DateTime entryDate)
        {
            using (var ctx = new databaseContext())
            {
                entry newEntry = new entry() { name = title, text = text, date = entryDate, domain = "test", diary_id = diaryID };

                ctx.tableObjentry.Add(newEntry);
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

        public entry editEntry (int entryID)
        {
            using (var ctx = new databaseContext())
            {
                var getEntry = ctx.tableObjentry.Where(e => e.id == entryID).First();

                return getEntry;
            }
        }
    }
    class controller
    {
    }
}
