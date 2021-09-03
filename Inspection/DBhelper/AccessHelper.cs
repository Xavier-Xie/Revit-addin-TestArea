using System;
using System.Data;
using System.Data.OleDb;

namespace Inspection.DBhelper
{
    class AccessHelper
    {
        public Object Connect()
        {
            //连接数据库
            string sAccessConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = D:\OneDrive - cumt.edu.cn\大创\个人资料\Demo1\MEP_Standard.accdb";
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

        public void CreateAccessDate(OleDbConnection connection)
        {

            //新建命令对象
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            //执行语句
            string commandString = "create table 学生信息(学号 text(8),姓名 text(12))";//创建表
            command.CommandText = commandString;
            //执行非查询的数据库指令
            int f = command.ExecuteNonQuery();
            if (f == 0)
            {
                Console.WriteLine("Create Success");
            }
            else
            {
                Console.WriteLine("Creat Faild");
            }
        }

        public void InsertAccessDate(OleDbConnection connection)
        {
            //新建命令对象
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            //执行语句
            string commandString = "insert into 学生信息(学号,姓名) values('02190461','付雪海')";//插入行
            command.CommandText = commandString;
            int f = command.ExecuteNonQuery();
            if (f == 1)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Faild");
            }
        }

        public void SelectAccessDate(OleDbConnection connection, string str)
        {
            //新建命令对象
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };

            string[] strs = str.Split(',');
            string[] vs = new string[strs.Length];
            Console.WriteLine("输入成功");
            for (int i = 0; i < (strs.Length - 1); i++)
            {
                vs[i] = strs[i];
            }
            //再存一遍
            int t = strs.Length - 1;
            for (int i = 2; i < (strs.Length - 1); i++)
            {
                strs[1] = strs[1] + ',' + strs[i];
            }
            strs[2] = strs[(strs.Length - 1)];
            //保存表名strs[0]，列名strs[1]
            Console.WriteLine("表名：" + strs[0]);
            Console.WriteLine("列名：" + strs[1]);
            Console.WriteLine("匹配条件：" + strs[2]);
            string commandString = "select " + strs[1] + " from " + strs[0] + " where " + strs[2];//搜索
            Console.WriteLine(commandString);
            Console.WriteLine("查询结果如下：");
            command.CommandText = commandString;
            OleDbDataReader testReader = command.ExecuteReader();
            while (testReader.Read())
            {
                //将检索出来的数据，输出到屏幕上.
                string dateshow = string.Empty;
                for (int i = 1; i < t; i++)
                {
                    string s = vs[i] + "：" + testReader[vs[i]];
                    dateshow += s + " ";
                }
                Console.WriteLine(dateshow);
            }
            //关闭数据库连接
            //connection.Close();
        }
    }
}
