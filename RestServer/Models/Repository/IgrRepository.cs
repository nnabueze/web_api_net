﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using System.Collections;

namespace RestServer.Models.Repository
{
    public class IgrRepository
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public IgrRepository()
        {
            string myContectionString;
            myContectionString = "server=127.0.0.1;uid=root;pwd=;database=igr;convert zero datetime=True";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myContectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                throw ex;
            }
        }

        //saving IGR
        public long saveIgr(Igr igrToSave)
        {
            try
            {
                String sqlString = "INSERT INTO igrs(igr_key,state_name,igr_code,igr_abbre,logo,created_at,updated_at)VALUES('" + igrToSave.Igr_Key + "','" + igrToSave.State_name + "','" + igrToSave.Igr_code + "','" + igrToSave.Igr_abbre + "','" + igrToSave.Logo + "','" + igrToSave.created_at.ToString("yyyy-MM-dd HH:mm:ss") + "','" + igrToSave.Updated_at.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString,conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                throw ex;
            }           
        }

        //getting  a single result
        public Igr getIgr(long ID)
        {
            Igr p = new Igr();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

            String sqlString = "SELECT * FROM igrs WHERE ID = " + ID;
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString,conn);
                mySqlReader = cmd.ExecuteReader();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                throw ex;
            }

            if (mySqlReader.Read())
            {
                p.Id = mySqlReader.GetInt32(0);
                p.Igr_abbre = (string) mySqlReader["igr_abbre"];
                p.Igr_code = (string)mySqlReader["igr_code"];
                p.Igr_Key = (string)mySqlReader["Igr_Key"];
                p.Logo = (string)mySqlReader["Logo"];
                p.State_name = (string)mySqlReader["State_name"];
                p.created_at = (DateTime)mySqlReader["created_at"];
                p.Updated_at = (DateTime)mySqlReader["updated_at"];


                return p;
            }
            else
            {
                return null;
            }
        }

        //return list of IGR
        public ArrayList GetIgrs()
        {
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = selectData();

            ArrayList IgrArrayList = new ArrayList();

            while(mySqlReader.Read())
            {
                Igr p = new Igr();
                p.Id = mySqlReader.GetInt32(0);
                p.Igr_abbre = (string) mySqlReader["igr_abbre"];
                p.Igr_code = (string)mySqlReader["igr_code"];
                p.Igr_Key = (string)mySqlReader["Igr_Key"];
                p.Logo = (string)mySqlReader["Logo"];
                p.State_name = (string)mySqlReader["State_name"];
                p.created_at = (DateTime)mySqlReader["created_at"];
                p.Updated_at = (DateTime)mySqlReader["updated_at"];

                IgrArrayList.Add(p);
            }

            return IgrArrayList;
        }


        //reusable function select
        private MySql.Data.MySqlClient.MySqlDataReader selectData(int? ID = null)
        {
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

            String sqlString = null;

            if (ID != null)
            {
                sqlString = "SELECT * FROM igrs WHERE ID = " + ID;
            }
            else
            {
                sqlString = "SELECT * FROM igrs";
            }


            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString,conn);
                mySqlReader = cmd.ExecuteReader();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                throw ex;
            }

            return mySqlReader;

        }
    }
}