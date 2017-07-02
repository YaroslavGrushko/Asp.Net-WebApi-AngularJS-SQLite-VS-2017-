using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;

namespace OwnersPetsVS2017.Models
{
    public class FromToDB
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data/";
        public static string dbFileName = "Owners.sqlite";
        public static string dbFileNamePath = path + dbFileName;
        public static void AddOwner(String value)
        { //Db:
          //------------------------------------------------------
          
            string conStr = "Data Source=" + dbFileNamePath + ";Version=3;";
            if (!File.Exists(path + dbFileName))
            {
                SQLiteConnection.CreateFile(path + dbFileName);
                

            }
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                //try
                //{
                //
                // Open the SQLiteConnection.
                //
                con.Open();
                //
                // The following code uses an SQLiteCommand based on the SQLiteConnection.
                //



                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS " + value.ToString() + " (petID INTEGER PRIMARY KEY AUTOINCREMENT, petName TEXT)", con))
                command.ExecuteNonQuery();

                //}
                //catch (Exception ex)
                //{
                //}
                //------------------------------------------------------


            }
        }
        public static List<OwnerCount> GetOwners()
        {
            List<OwnerCount> ownerCount = new List<OwnerCount>();
            DataTable dt = new DataTable();
            DataTable dtPets = new DataTable();
            //DB:
            //------------------------------------------------------
            string conStr = "Data Source=" + dbFileNamePath + ";Version=3;";
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                //try
                //{
                //
                // Open the SQLiteConnection.
                //
                con.Open();
                //
                // The following code uses an SQLiteCommand based on the SQLiteConnection.
                //

                
                SQLiteCommand mycommand = new SQLiteCommand(con);
                //выбераем все таблицы из базы данных:
                mycommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY 1;";

                SQLiteDataReader reader = mycommand.ExecuteReader();

                dt.Load(reader);
                foreach (DataRow raw in dt.Rows)
                {
                    String Owner = raw[0].ToString();//имя владельца(таблицы):
                    ////выбераем все животные (строки) из таблицы:
                    //mycommand.CommandText = "SELECT petName FROM '" + Owner + "'ORDER BY 1;";
                    ////выполняем:
                    //try
                    //{
                    //    using (SQLiteDataReader readerPets = mycommand.ExecuteReader())
                    //    {
                    //        //загружаем в DataTable:
                    //        dtPets.Load(reader);
                    //        //подсчитываем количество строк в текущей таблице:
                    //        int count = 0;//= dtPets.Rows.Count;
                    //        foreach (DataRow pet in dtPets.Rows)
                    //        {
                    //            count++;
                    //            var Mypet = pet[0].ToString();
                    //        }
                    //        String ownerName = Owner;//имя владельца(таблицы):
                    //        ownerCount.Add(new OwnerCount(ownerName, count));
                    //    }
                    //}
                    //catch (Exception) { }
                    //выбераем все животные (строки) из таблицы:
                    SQLiteDataAdapter myAdapter = new SQLiteDataAdapter("SELECT * FROM "+ Owner, con);
                    myAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    
                    DataSet myDataSet = new DataSet();

                    //загружаем в myDataSet:            
                    myAdapter.Fill(myDataSet, Owner);

                    //подсчитываем количество строк в текущей таблице:
                    int count =  myDataSet.Tables[Owner].Rows.Count;

                    //добавляем очередной элемент(владелец, кол-во животных) в список:
                  ownerCount.Add(new OwnerCount(Owner, count));
                }

                reader.Close();

            }



            //}
            //catch (Exception ex)
            //{
            //}
            //------------------------------------------------------
            ownerCount.RemoveRange(ownerCount.Count - 1, 1);
            return ownerCount;
        }
        public static void DeleteOwner(String name)
        {
            //DB:
            //------------------------------------------------------
            string conStr = "Data Source=" + dbFileNamePath + ";Version=3;";
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                //try
                //{
                //
                // Open the SQLiteConnection.
                //
                con.Open();
                //
                // The following code uses an SQLiteCommand based on the SQLiteConnection.
                //

                using (SQLiteCommand command = new SQLiteCommand("DROP Table '"+ name + "'", con))
                    command.ExecuteNonQuery();

                //}
                //catch (Exception ex)
                //{
                //}


            }
        }
        public static void AddPet (PetOwner item)
        {
            //Db:
            //------------------------------------------------------

            string conStr = "Data Source=" + dbFileNamePath + ";Version=3;";
            
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                //try
                //{
                //
                // Open the SQLiteConnection.
                //
                con.Open();
                //
                // The following code uses an SQLiteCommand based on the SQLiteConnection.
                //
                SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO "+ item.OwnerName.ToString() + " (petName) VALUES ('"+item.PetName+"')", con);
                
                insertSQL.ExecuteNonQuery();
                

               
                //}
                //catch (Exception ex)
                //{
                //}
                //------------------------------------------------------


            }

        }
        public static List<string> GetPets(String ownerName)
        {
            List<string> list = new List<string>();
            DataTable dt = new DataTable();
            //DB:
            //------------------------------------------------------
            string conStr = "Data Source=" + dbFileNamePath + ";Version=3;";
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                //try
                //{
                //
                // Open the SQLiteConnection.
                //
                con.Open();
                //
                // The following code uses an SQLiteCommand based on the SQLiteConnection.
                //

                //using (SQLiteCommand command = new SQLiteCommand("ATTACH " + dbFileNamePath + " AS my_db;", con))
                //    command.ExecuteNonQuery();

                SQLiteCommand mycommand = new SQLiteCommand(con);
                mycommand.CommandText = "SELECT petName FROM '"+ownerName.ToString()+"' ORDER BY 1;";

                SQLiteDataReader reader = mycommand.ExecuteReader();

                dt.Load(reader);
                foreach (DataRow raw in dt.Rows)
                {
                    list.Add(raw[0].ToString());
                }
                reader.Close();

            }



            //}
            //catch (Exception ex)
            //{
            //}
            //------------------------------------------------------
            //list.RemoveRange(list.Count - 1, 1);
            return list;
        }
        public static void DeletePet(PetOwner petOwner)
        {
            //DB:
            //------------------------------------------------------
            string conStr = "Data Source=" + dbFileNamePath + ";Version=3;";
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                //try
                //{
                //
                // Open the SQLiteConnection.
                //
                con.Open();
                //
                // The following code uses an SQLiteCommand based on the SQLiteConnection.
                //
                
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM " + petOwner.OwnerName + " WHERE petName='" + petOwner.PetName + "'", con))
                    command.ExecuteNonQuery();

                //}
                //catch (Exception ex)
                //{
                //}


            }
        }
    }
}