using System;
using System.Data;
using System.Data.OleDb;

namespace Inspection.DBhelper
{
    public class PipeDistanceStandardDB
    {
        public int GetDistanceMin(string str1, string str2, int i = 0)
        {
            //连接数据库
            string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\Lenovo\Documents\Database1.mdb";
            OleDbConnection connection = new OleDbConnection(sAccessConnection);
            //建立连接
            connection.Open();

            //新建命令对象
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            //执行语句
            string commandString = "select Method,DistanceMin from PLUMBINGSYSTEM_STANDARD " +
                                   "where PipelineID1 = (select PipelineID from PIPELINE_INFO where Name = '" + str1 + "') " +
                                   "and PipelineID2 = (select PipelineID from PIPELINE_INFO where Name = '" + str2 + "') ";
            command.CommandText = commandString;
            OleDbDataReader testreader = command.ExecuteReader();
            int distancemin = 0;
            while (testreader.Read())
            {
                if ((i == 0) && (testreader["Method"] == DBNull.Value))
                {
                    distancemin = (int)testreader["DistanceMin"];
                }
                if ((i == 1) && ((string)testreader["Method"]) == "同一水平面")
                {
                    distancemin = (int)testreader["DistanceMin"];
                }
                if ((i == 2) && ((string)testreader["Method"]) == "水平交叉")
                {
                    distancemin = (int)testreader["DistanceMin"];
                }
                if ((i == 3) && ((string)testreader["Method"]) == "平行敷设")
                {
                    distancemin = (int)testreader["DistanceMin"];
                }
                if ((i == 4) && ((string)testreader["Method"]) == "交叉敷设")
                {
                    distancemin = (int)testreader["DistanceMin"];
                }
            }
            connection.Close();
            return distancemin;
        }

        public int GetDistanceMax(string str1, string str2, int i = 0)
        {
            //连接数据库
            string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\Lenovo\Documents\Database1.mdb";
            OleDbConnection connection = new OleDbConnection(sAccessConnection);
            //建立连接
            connection.Open();

            //新建命令对象
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            //执行语句
            string commandString = "select Method,DistanceMax from PLUMBINGSYSTEM_STANDARD" +
                                   "where PipelineID1 = (select PipelineID from PIPELINE_INFO where Name = '" + str1 + "') " +
                                   "and PipelineID2 = (select PipelineID from PIPELINE_INFO where Name = '" + str2 + "') ";
            command.CommandText = commandString;
            OleDbDataReader testreader = command.ExecuteReader();
            int distancemax = 0;
            while (testreader.Read())
            {
                if ((i == 0) && (testreader["Method"] == DBNull.Value))
                {
                    distancemax = (int)testreader["DistanceMax"];
                }
                if ((i == 1) && ((string)testreader["Method"]) == "同一水平面")
                {
                    distancemax = (int)testreader["DistanceMax"];
                }
                if ((i == 2) && ((string)testreader["Method"]) == "水平交叉")
                {
                    distancemax = (int)testreader["DistanceMax"];
                }
                if ((i == 3) && ((string)testreader["Method"]) == "平行敷设")
                {
                    distancemax = (int)testreader["DistanceMax"];
                }
                if ((i == 4) && ((string)testreader["Method"]) == "交叉敷设")
                {
                    distancemax = (int)testreader["DistanceMax"];
                }
            }
            connection.Close();
            return distancemax;
        }

        public string GetDistanceSourceContent(string str1, string str2, int i = 0)
        {
            //连接数据库
            string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\Lenovo\Documents\Database1.mdb";
            OleDbConnection connection = new OleDbConnection(sAccessConnection);
            //建立连接
            connection.Open();

            //新建命令对象
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            //执行语句
            string commandString = "select Method,Source,Content from PLUMBINGSYSTEM_STANDARD,STANDARD " +
                                   "where PipelineID1 = (select PipelineID from PIPELINE_INFO where Name = '" + str1 + "') " +
                                   "and PipelineID2 = (select PipelineID from PIPELINE_INFO where Name = '" + str2 + "') " +
                                   "and PLUMBINGSYSTEM_STANDARD.StandardID = STANDARD.StandardID";
            command.CommandText = commandString;
            OleDbDataReader testreader = command.ExecuteReader();
            string str = "";
            while (testreader.Read())
            {
                if ((i == 0) && (testreader["Method"] == DBNull.Value))
                {
                    str = "来自规范" + (string)testreader["Source"] + "的内容：" + (string)testreader["Content"];
                }
                if ((i == 1) && ((string)testreader["Method"]) == "同一水平面")
                {
                    str = "来自规范" + (string)testreader["Source"] + "的内容：" + (string)testreader["Content"];
                }
                if ((i == 2) && ((string)testreader["Method"]) == "水平交叉")
                {
                    str = "来自规范" + (string)testreader["Source"] + "的内容：" + (string)testreader["Content"];
                }
                if ((i == 3) && ((string)testreader["Method"]) == "平行敷设")
                {
                    str = "来自规范" + (string)testreader["Source"] + "的内容：" + (string)testreader["Content"];
                }
                if ((i == 4) && ((string)testreader["Method"]) == "交叉敷设")
                {
                    str = "来自规范" + (string)testreader["Source"] + "的内容：" + (string)testreader["Content"];
                }
            }
            connection.Close();
            return str;
        }
    }
}
