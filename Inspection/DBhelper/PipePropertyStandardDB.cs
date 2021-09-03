using System;
using System.Data;
using System.Data.OleDb;

namespace Inspection.DBhelper
{
    class PipePropertyStandardDB
    {
        public double GetGeneralSlope(string str1, string str2, int diameter)
        {
            string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\Lenovo\Documents\Database1.mdb";
            OleDbConnection connection = new OleDbConnection(sAccessConnection);
            connection.Open();
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            command.CommandText = " select GeneralSlope from PIPELINE_SLPOE " +
                                   "where PipelineID = ( select PipelineID from PIPELINE_INFO where Name = '" + str1 + "') " +
                                   " and MaterialID = (select MaterialID from PIPELINE_MATERIALI where Name = '" + str2 + "') " +
                                   " and Diameter =" + diameter;
            OleDbDataReader testreader = command.ExecuteReader();
            double generalslope = 0;
            while (testreader.Read())
            {
                generalslope = (double)testreader["GeneralSlope"];
            }
            connection.Close();
            return generalslope;
        }
        public double GetMinSlope(string str1, string str2, int diameter)
        {
            string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\Lenovo\Documents\Database1.mdb";
            OleDbConnection connection = new OleDbConnection(sAccessConnection);
            connection.Open();
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            command.CommandText = " select MInSlope from PIPELINE_SLPOE " +
                                   "where PipelineID = ( select PipelineID from PIPELINE_INFO where Name = '" + str1 + "') " +
                                   " and MaterialID = (select MaterialID from PIPELINE_MATERIALI where Name = '" + str2 + "') " +
                                   " and Diameter =" + diameter;
            OleDbDataReader testreader = command.ExecuteReader();
            double minslope = 0;
            while (testreader.Read())
            {
                minslope = (double)testreader["MInSlope"];
            }
            connection.Close();
            return minslope;
        }
        public int GetDiameter(string str)
        {
            string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\Lenovo\Documents\Database1.mdb";
            OleDbConnection connection = new OleDbConnection(sAccessConnection);
            connection.Open();
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            command.CommandText = " select RBS_PIPE_DIAMETER_PARAM from PIPELINE_DIAMETER " +
                                   "where PipelineID = ( select PipelineID from PIPELINE_INFO where Name = '" + str + "') ";
            OleDbDataReader testreader = command.ExecuteReader();
            int diameter = 0;
            while (testreader.Read())
            {
                diameter = (int)testreader["RBS_PIPE_DIAMETER_PARAM"];
            }
            return diameter;
        }

        public string GetSlopeSource(string str1, string str2, int diameter)
        {
            string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\Lenovo\Documents\Database1.mdb";
            OleDbConnection connection = new OleDbConnection(sAccessConnection);
            connection.Open();
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            command.CommandText = " select Source, Content from PIPELINE_SLPOE,STANDARD " +
                                   "where PipelineID = ( select PipelineID from PIPELINE_INFO where Name = '" + str1 + "') " +
                                   " and MaterialID = (select MaterialID from PIPELINE_MATERIALI where Name = '" + str2 + "') " +
                                   " and Diameter =" + diameter +
                                   " and PIPELINE_SLPOE.StandardID = STANDARD.StandardID";
            OleDbDataReader testreader = command.ExecuteReader();
            string str = "";
            while (testreader.Read())
            {
                str = "来自规范" + (string)testreader["Source"] + "的内容：" + (string)testreader["Content"];
            }
            connection.Close();
            return str;
        }
        public string GetDiameterSource(string pipe)
        {
            string sAccessConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\Lenovo\Documents\Database1.mdb";
            OleDbConnection connection = new OleDbConnection(sAccessConnection);
            connection.Open();
            OleDbCommand command = new OleDbCommand
            {
                Connection = connection
            };
            command.CommandText = " select Source, Content from PIPELINE_DIAMETER,STANDARD " +
                                   "where PipelineID = ( select PipelineID from PIPELINE_INFO where Name = '" + pipe + "') " +
                                   " and PIPELINE_DIAMETER.StandardID = STANDARD.StandardID";
            OleDbDataReader testreader = command.ExecuteReader();
            string str = "";
            while (testreader.Read())
            {
                str = "来自规范" + (string)testreader["Source"] + "的内容：" + (string)testreader["Content"];
            }
            connection.Close();
            return str;
        }
    }
}
