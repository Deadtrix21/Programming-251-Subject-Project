using System.Collections.Specialized;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Prg251_Porject_01.apps
{
    internal class DBManager
    {
        #region Fields

        private dynamic path;

        public Dictionary<string, dynamic> abuse = new Dictionary<string, dynamic>()
        {
            {"admin", false},
            {"class", null}
        };

        public NameValueCollection SQLStatements = new NameValueCollection()
        {
            #region Table

                {"Student", "CREATE TABLE Student(" +
                    "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "StudentName VARCHAR(40)," +
                    "StudentSurname VARCHAR(20)," +
                    "StudentEmail VARCHAR(28)," +
                    "StudentPassword VARCHAR(64)," +
                    "StudentIDNumber INTEGER(13)," +
                    "StudentGender VARCHAR(1)," +
                    "StudentAttendance VARCHAR(30)," +
                    "StudentType TEXT(1)," +
                    "StudentProvince TEXT(50)," +
                    "StudentPasswordChange TEXT(1)" +
                ");"},

                {"Administrator","CREATE TABLE Administrator(" +
                    "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "AdministratorName VARCHAR(20)," +
                    "AdministratorEmail VARCHAR(20),"+
                    "AdministratorPassword VARCHAR(50),"+
                    "SuperAdmin VARCHAR(1),"+
                    "Locked VARCHAR(1)"+
                ");"},

            #endregion Table

            #region SearchStudent

                {"SearchStudentID","Select * FROM Student WHERE ID = @param;"},
                {"SearchStudentIDNumber","Select * FROM Student WHERE StudentIDNumber = @param;"},

            #endregion SearchStudent

            #region StudentType

                {"FaceToFace","SELECT * FROM Student WHERE StudentType = 1"},
                {"OnlineAttending","SELECT * FROM Student WHERE StudentType = 0"},

            #endregion StudentType

            #region UsersLogin

                {"AdminName",       "Select * FROM Administrator WHERE AdministratorEmail = @param "},
                {"StudentName",     "Select * FROM Student WHERE StudentEmail = @param "},

            #endregion UsersLogin

            #region UpdateStatements

                {"AdminStudentUpdate",
                " UPDATE Student" +
                    " SET" +
                    " StudentName             = @new_value_1," +
                    " StudentSurname          = @new_value_2," +
                    " StudentEmail            = @new_value_3," +
                    " StudentPassword         = @new_value_4," +
                    " StudentIDNumber         = @new_value_5," +
                    " StudentAttendance       = @new_value_6," +
                    " StudentType             = @new_value_7," +
                    " StudentProvince         = @new_value_8," +
                    " StudentPasswordChange   = @new_value_9"+
                " WHERE StudentEmail = @param"},
                {"UserStudentUpdate",
                " UPDATE Student" +
                    " SET" +
                    " StudentName             = @new_value_1," +
                    " StudentSurname          = @new_value_2," +
                    " StudentPassword         = @new_value_3," +
                    " StudentAttendance       = @new_value_4," +
                    " StudentType             = @new_value_5," +
                    " StudentProvince         = @new_value_6," +
                " WHERE StudentEmail = @param"},
                {"AdminUpdate",""},

            #endregion UpdateStatements

            #region CreateStatements

                {"StudentCreate",
                    "INSERT INTO Student" +
                    "(StudentName,StudentSurname,StudentEmail,StudentPassword,StudentIDNumber," +
                    " StudentGender,StudentAttendance,StudentType,StudentProvince) " +
                    "VALUES(@Name, @Email, @Password, @IDnumber, @Gender, @Attending, @Type, @Home)"
                },

                {"AdminCreate",
                    "INSERT INTO Administrator"+
                    "(AdministratorName,    AdministratorEmail,    AdministratorPassword,    SuperAdmin,    Locked) " +
                    "VALUES(@Name, @Email, @Password, @param, @param1)"},

                {"DefaultSuperAdmin",
                    "INSERT INTO Administrator"+
                    "(AdministratorName,    AdministratorEmail,    AdministratorPassword,    SuperAdmin,    Locked) " +
                    "VALUES('DeadTrix', 'Nightmarefeverdream@outlook.com', 'Deadtrix@2001s21', 1, 3)"
                }

            #endregion CreateStatements
        };

        #endregion Fields



        #region Properties

        public dynamic Path { get => path; set => path = value; }

        #endregion Properties



        #region Methods

        private dynamic build_string()
        {
            return "URI=file:" + path + "\\table.draw";
        }

        private Dictionary<string, dynamic> connect()
        {
            Dictionary<string, dynamic> abuse_obj = new Dictionary<string, dynamic>();
            SQLiteConnection conn = new SQLiteConnection(build_string());
            conn.Open();
            SQLiteCommand cur = new SQLiteCommand(conn);
            abuse_obj["cur"] = cur;
            abuse_obj["connect"] = conn;
            return abuse_obj;
        }

        public void create_tbl()
        {
            bool file = File.Exists(Path + "\\table.draw");
            if (!file)
            {
                SQLiteConnection conn = new SQLiteConnection(build_string());
                conn.Open();
                SQLiteCommand cur = new SQLiteCommand(conn);
                cur.CommandText = SQLStatements["Student"];
                cur.ExecuteNonQuery();
                cur.CommandText = SQLStatements["Administrator"];
                cur.ExecuteNonQuery();
                cur.CommandText = SQLStatements["DefaultSuperAdmin"];
                cur.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CreateSql(bool Admin, NameValueCollection data)
        {
            bool file = File.Exists(Path + "\\table.draw");
            if (file)
            {
                Dictionary<string, dynamic> __obj__ = connect();
                SQLiteConnection conn = __obj__["connect"];
                SQLiteCommand cur = __obj__["cur"];
                SQLiteDataReader rdr;
                if (!Admin)
                {
                    cur.CommandText = SQLStatements["StudentCreate"];
                    cur.Parameters.AddWithValue("@Name", data["name"]);
                    cur.Parameters.AddWithValue("@Email", data["email"]);
                    cur.Parameters.AddWithValue("@Password", data["pass"]);
                    cur.Parameters.AddWithValue("@IDnumber", data["sa"]);
                    cur.Parameters.AddWithValue("@Gender", data["gender"]);

                    cur.Parameters.AddWithValue("@Atteneding", data["campus"]);
                    cur.Parameters.AddWithValue("@Type", data["type"]);
                    cur.Parameters.AddWithValue("@Home", data["home"]);
                    cur.Prepare();
                    cur.ExecuteNonQuery();
                    //"VALUES(@Name, @Email, @Password, @IDnumber, @Gender, @Attending, @Type, @Home)"
                }
                if (Admin)
                {
                    {
                        cur.CommandText = SQLStatements["AdminCreate"];
                        cur.Parameters.AddWithValue("@Name", data["name"]);
                        cur.Parameters.AddWithValue("@Email", data["email"]);
                        cur.Parameters.AddWithValue("@Password", data["pass"]);
                        cur.Parameters.AddWithValue("@SA", data["sa"]);
                        cur.Parameters.AddWithValue("@Lock", data["lock"]);
                        cur.Prepare();
                        cur.ExecuteNonQuery();
                    }
                }
                else { MessageBox.Show("There is no database"); }
            }
        }

        public dynamic LoginSql(bool aAdmin, string param)
        {
            bool file = File.Exists(Path + "\\table.draw");
            if (file)
            {
                Dictionary<string, dynamic> __obj__ = connect();
                SQLiteConnection conn = __obj__["connect"];
                SQLiteCommand cur = __obj__["cur"];
                SQLiteDataReader rdr;
                if (!aAdmin)
                {
                    cur.CommandText = SQLStatements["StudentName"];
                    cur.Parameters.AddWithValue("@param", param);
                    cur.Prepare();
                    rdr = cur.ExecuteReader();
                    Student obj = new Student();
                    obj.CurrentReturn(rdr);
                    abuse["admin"] = aAdmin;
                    abuse["class"] = obj.Current_Data_Set;
                }
                else if (aAdmin)
                {
                    cur.CommandText = SQLStatements["AdminName"];
                    cur.Parameters.AddWithValue("@param", param);
                    cur.Prepare();
                    rdr = cur.ExecuteReader();
                    Admin obj = new Admin();
                    obj.CurrentReturn(rdr);
                    abuse["admin"] = aAdmin;
                    abuse["class"] = obj.Current_Data_Set;
                }
            }
            else { MessageBox.Show("There is no database"); }
            return abuse;
        }

        public void UpdateSql(bool Admin, bool superAdmin, Dictionary<string, Dictionary<int, dynamic>> data)
        {
            bool file = File.Exists(Path + "\\table.draw");
            if (file)
            {
                Dictionary<string, dynamic> __obj__ = connect();
                SQLiteConnection conn = __obj__["connect"];
                SQLiteCommand cur = __obj__["cur"];
                SQLiteDataReader rdr;
                if (!Admin)
                {
                    cur.CommandText = SQLStatements["UserStudentUpdate"];
                    cur.Parameters.AddWithValue("@new_value_1", data["student"][1]);
                    cur.Parameters.AddWithValue("@new_value_2", data["student"][2]);
                    cur.Parameters.AddWithValue("@new_value_3", data["student"][3]);
                    cur.Parameters.AddWithValue("@new_value_4", data["student"][4]);
                    cur.Parameters.AddWithValue("@new_value_5", data["student"][5]);
                    cur.Parameters.AddWithValue("@new_value_6", data["student"][6]);
                    cur.Parameters.AddWithValue("@param", data["student"][7]);
                    cur.Prepare();
                    cur.ExecuteNonQuery();
                }
                else if (Admin)
                {
                    if (!superAdmin)
                    {
                        cur.CommandText = SQLStatements["AdminStudentUpdate"];
                        cur.Parameters.AddWithValue("@new_value_1", data["Admin_student"][1]);
                        cur.Parameters.AddWithValue("@new_value_2", data["Admin_student"][2]);
                        cur.Parameters.AddWithValue("@new_value_3", data["Admin_student"][3]);
                        cur.Parameters.AddWithValue("@new_value_4", data["Admin_student"][4]);
                        cur.Parameters.AddWithValue("@new_value_5", data["Admin_student"][5]);
                        cur.Parameters.AddWithValue("@new_value_6", data["Admin_student"][6]);
                        cur.Parameters.AddWithValue("@new_value_7", data["Admin_student"][7]);
                        cur.Parameters.AddWithValue("@new_value_8", data["Admin_student"][8]);
                        cur.Parameters.AddWithValue("@new_value_9", data["Admin_student"][9]);
                        cur.Parameters.AddWithValue("@param", data["Admin_studentt"][10]);
                        cur.Prepare();
                        cur.ExecuteNonQuery();
                    }
                    else if (superAdmin)
                    { }
                }
                conn.Close();
            }
            else { MessageBox.Show("There is no database"); }
        }

        #endregion Methods
    }
}