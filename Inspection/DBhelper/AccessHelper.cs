using System;
using System.Data;
using System.Data.OleDb;

namespace Inspection.DBhelper
{
    public class AccessHelper
    {
        public Object Connect()
        {
            //连接数据库
            string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = D:\OneDrive\OneDrive - cumt.edu.cn\大创\个人资料\数据库\Database1.mdb";
            OleDbConnection connection = new OleDbConnection(sAccessConnection);
            //建立连接
            connection.Open();
            //判断连接
            if (connection.State == ConnectionState.Open)
            {
                Console.WriteLine("Success"); ;
            }
            else
            {
                Console.WriteLine("Faild"); ;
            }
            return connection;
        }
    }
}
