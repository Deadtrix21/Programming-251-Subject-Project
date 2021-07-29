using System.Data.SQLite;

namespace Prg251_Porject_01.apps
{
    /*
    "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
    "StudentName VARCHAR(40)," +
    "StudentSurname VARCHAR(20)," +
    "StudentEmail VARCHAR(28)," +
    "StudentPassword VARCHAR," +
    "StudentIDNumber INTEGER(13)," +
    "StudentGender VARCHAR(1)," +
    "StudentAttendance VARCHAR(30)," +
    "StudentType TEXT(1)," +
    "StudentProvince TEXT(50)," +
    "StudentPasswordChange TEXT(1)" +

    "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
    "AdministratorName VARCHAR(20)," +
    "AdministratorEmail VARCHAR(20),"+
    "AdministratorPassword VARCHAR(50),"+
    "SuperAdmin VARCHAR(1),"+
    "Locked VARCHAR(1)"+
    */

    public class Admin
    {
        #region Fields

        private AdminInternal Current = null;

        #endregion Fields



        #region Properties

        // The Current Fed in Profile
        public AdminInternal Current_Data_Set { get => Current; }

        #endregion Properties



        #region Methods

        public void CurrentReturn(dynamic SQL_Obj)         //
        {
            Current = new AdminInternal(SQL_Obj);
        }

        #endregion Methods



        #region Classes

        public class AdminInternal                         //  The Data Class that get returned
        {
            #region Enter

            public string Administrator_Email;
            public string Administrator_Name;
            public string Administrator_Password;
            public dynamic Auto_ID;
            public string Locked;
            public SQLiteDataReader SQL_Data;
            public string SuperAdmin;

            public AdminInternal(SQLiteDataReader SQL_Obj)
            {
                SQL_Data = SQL_Obj;
                setten();
            }

            private void setten()
            {
                SQL_Data.Read();
                Auto_ID = SQL_Data.GetInt32(0);
                Administrator_Name = SQL_Data.GetString(1);
                Administrator_Email = SQL_Data.GetString(2);
                Administrator_Password = SQL_Data.GetString(3);
                SuperAdmin = SQL_Data.GetString(4);
                Locked = SQL_Data.GetString(5);
            }

            #endregion Enter
        }

        #endregion Classes
    }

    public class Student
    {
        #region Fields

        private StudentInternal Current = null;

        #endregion Fields



        #region Properties

        // The Current Fed in Profile
        public StudentInternal Current_Data_Set { get => Current; }

        #endregion Properties



        #region Methods

        public void CurrentReturn(SQLiteDataReader SQL_Obj)         //
        {
            Current = new StudentInternal(SQL_Obj);
        }

        #endregion Methods



        #region Classes

        public class StudentInternal                       //  The Data Class that get returned
        {
            #region Enter

            private dynamic SQL_Data;

            public StudentInternal(SQLiteDataReader SQL_Obj)
            {
                SQL_Data = SQL_Obj;
                setten();
            }

            #endregion Enter

            #region Data

            public string Studen_Attendance;
            public dynamic Student_Auto_ID;
            public string Student_Email;
            public string Student_Gender;
            public string Student_ID_Number;
            public string Student_Name;
            public string Student_Password;
            public string Student_Password_Change;
            public string Student_Province;
            public string Student_Surname;
            public string Student_Type;

            #endregion Data



            #region Methods

            private void setten()
            {
                SQL_Data.Read();
                Student_Auto_ID = SQL_Data.GetInt32(0); ;
                Student_Name = SQL_Data.GetString(1);
                Student_Surname = SQL_Data.GetString(2);
                Student_Email = SQL_Data.GetString(3);
                Student_Password = SQL_Data.GetString(4);
                Student_ID_Number = SQL_Data.GetInt32(5);
                Student_Gender = SQL_Data.GetString(6);
                Studen_Attendance = SQL_Data.GetString(7);
                Student_Type = SQL_Data.GetString(8);
                Student_Province = SQL_Data.GetString(9);
                Student_Password_Change = SQL_Data.GetString(10);
            }

            #endregion Methods
        }

        #endregion Classes
    }
}