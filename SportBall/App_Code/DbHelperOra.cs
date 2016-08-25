using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using log4net;

namespace KingOfBall
{
    /// <summary>
    /// Copyright (C) 2004-2008  
    /// 数据访问基础类(基于Oracle)
    /// 可以用户可以修改满足自己项目的需要。
    /// </summary>
    public abstract class DbHelperOra
    {
        //数据库连接字符串(web.config来配置)
        //<add key="ConnectionString" value="server=127.0.0.1;database=DATABASE;uid=sa;pwd=" />		
        public static string connectionString = ConfigurationSettings.AppSettings["OracleConnString"];
        //public static ILog LogError = log4net.LogManager.GetLogger("logerror");
        public static ILog LogDB = log4net.LogManager.GetLogger("logDB");
        public static string strUserID;
        public static string language = ConfigurationSettings.AppSettings["Language"];
        public DbHelperOra()
        {

        }

        #region 公用方法

        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);

            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public static bool Exists(string strSql, params OracleParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 判斷否存在
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        LogDB.Info("USER=" + strUserID + "SQL=" + SQLString);
                        return rows;
                    }
                    catch (System.Data.OracleClient.OracleException E)
                    {
                        connection.Close();
                        LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, E);
                        throw new Exception(E.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand(SQLString, connection);
                System.Data.OracleClient.OracleParameter myParameter = new System.Data.OracleClient.OracleParameter(":content", System.Data.OracleClient.OracleType.LongVarChar);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    LogDB.Info("USER=" + strUserID + " SQL=" + SQLString + "#" + connection);
                    return rows;
                }
                catch (System.Data.OracleClient.OracleException E)
                {
                    LogDB.Error("USER=" + strUserID + "SQL=" + SQLString + "#" + connection, E);
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                OracleTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {

                            LogDB.Info("USER=" + strUserID + "SQL=" + strsql);
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.OracleClient.OracleException E)
                {
                    tx.Rollback();

                    LogDB.Error("USER=" + strUserID + "SQL=" + ListtoString(SQLStringList), E);
                    throw new Exception(E.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static string ListtoString(ArrayList a_List)
        {
            string strReturn = "";
            try
            {
                for (int n = 0; n < a_List.Count; n++)
                {
                    strReturn = a_List[n].ToString();
                    if (strReturn.Trim().Length > 1)
                    {
                        strReturn += strReturn;
                    }
                }
                return strReturn;
            }
            catch { return strReturn; }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OracleClient.OracleException e)
                    {
                        LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, e);
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回OracleDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader ExecuteReader(string strSQL)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand(strSQL, connection);
            try
            {
                connection.Open();
                OracleDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                LogDB.Error("USER=" + strUserID + "SQL=" + strSQL, e);
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OracleDataAdapter command = new OracleDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OracleClient.OracleException ex)
                {
                    LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, ex);
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        PrepareCommandExecute(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        //LogDB.Info("用户名" + strUserID + "SQL=" + SQLString);
                        return rows;
                    }
                    catch (System.Data.OracleClient.OracleException E)
                    {
                        LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, E);
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OracleParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    OracleCommand cmd = new OracleCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OracleParameter[] cmdParms = myDE.Value as OracleParameter[];
                            if (cmdParms == null)//key和value交換,此目的是爲了對同一個表同時新增多條數據
                            {
                                cmdText = myDE.Value.ToString();
                                cmdParms = (OracleParameter[])myDE.Key;
                            }
                            PrepareCommandExecute(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch (System.Data.OracleClient.OracleException E)
                    {
                        LogDB.Error("USER=" + strUserID, E);
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的双ArrayList（alSql为sql语句，alPar是该语句的OracleParameter[]）</param>
        public static bool ExecuteSqlTran(ArrayList alSql, ArrayList alPar)
        {
            if (alSql.Count != alPar.Count)
            {
                throw new Exception("Para Different");
            }
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    OracleCommand cmd = new OracleCommand();
                    try
                    {
                        //循环
                        for (int i = 0; i < alSql.Count; i++)
                        {
                            string cmdText = alSql[i].ToString();
                            OracleParameter[] cmdParms = (OracleParameter[])alPar[i];
                            PrepareCommandExecute(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        return true;
                    }
                    catch (System.Data.OracleClient.OracleException E)
                    {
                        trans.Rollback();
                        LogDB.Error("USER=" + strUserID, E);
                        return false;
                        throw;
                    }
                }
            }
        }

        public static void ExecuteSqlTran(ArrayList SQLStringList, ArrayList SQLStringList2, string ConnectStr)
        {
            string connectionString2 = ConfigurationSettings.AppSettings[ConnectStr].ToString();
            OracleConnection conn = new OracleConnection(connectionString);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            OracleTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
            OracleConnection conn2 = new OracleConnection(connectionString2);
            conn2.Open();
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn2;
            OracleTransaction tx2 = conn2.BeginTransaction();
            cmd2.Transaction = tx2;
            try
            {
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    string strsql = SQLStringList[n].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        cmd.ExecuteNonQuery();
                        LogDB.Info("USER=" + strUserID + "SQL=" + strsql + "#" + ConnectStr);
                    }
                }
                for (int n = 0; n < SQLStringList2.Count; n++)
                {
                    string strsql = SQLStringList2[n].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd2.CommandText = strsql;
                        cmd2.ExecuteNonQuery();
                        LogDB.Info("USER=" + strUserID + "SQL=" + strsql + "#" + ConnectStr);
                    }
                }
                tx.Commit();
                tx2.Commit();
            }
            catch (System.Data.OracleClient.OracleException E)
            {
                tx.Rollback();
                tx2.Rollback();
                tx.Dispose();
                tx2.Dispose();
                cmd.Dispose();
                cmd2.Dispose();
                conn.Close();
                conn2.Close();
                conn.Dispose();
                conn2.Dispose();
                LogDB.Error("USER=" + strUserID + "SQL=" + ListtoString(SQLStringList) + ListtoString(SQLStringList2) + "#" + ConnectStr, E);
                throw new Exception(E.Message);
            }
            finally
            {
                tx.Dispose();
                tx2.Dispose();
                cmd.Dispose();
                cmd2.Dispose();
                conn.Close();
                conn2.Close();
                conn.Dispose();
                conn2.Dispose();
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OracleClient.OracleException e)
                    {
                        LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, e);
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回OracleDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader ExecuteReader(string SQLString, params OracleParameter[] cmdParms)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand();
            OracleDataReader myReader;
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, e);
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
            }
            return myReader;
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                //string s_Parameter = "";
                //if (cmdParms != null)
                //{
                //    foreach (OracleParameter parm in cmdParms)
                //        s_Parameter += parm.ParameterName + ":" + parm.Value;
                //}
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OracleClient.OracleException ex)
                    {
                        LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, ex);
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText, OracleParameter[] cmdParms)
        {
            string sParms = "";
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        private static void PrepareCommandExecute(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText, OracleParameter[] cmdParms)
        {
            string sParms = "";
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                    sParms += parm.ParameterName + "：" + parm.Value + ";";
                }
            }
            //LogDB.Info("USER=" + strUserID + "SQL=" + cmdText + " PARA=" + sParms);
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleDataReader returnReader;
            connection.Open();
            OracleCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            return returnReader;
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                OracleDataAdapter sqlDA = new OracleDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 构建 OracleCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand</returns>
        private static OracleCommand BuildQueryCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = new OracleCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (OracleParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }
        /// <summary>
        /// 构建 OracleCommand 对象(用来返回一个结果集，而不是一个整数值),记录参数
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand</returns>
        private static OracleCommand BuildQueryCommandExecute(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            string spara = "";
            OracleCommand command = new OracleCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (OracleParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
                spara += parameter.ParameterName + "：" + parameter.Value + "；";
            }
            LogDB.Info("USER=" + strUserID + "PROC=" + storedProcName + " PARA=" + spara);
            return command;
        }
        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                int result;
                connection.Open();
                OracleCommand command = BuildIntCommandExecute(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        public static int CallProcedure(string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    int result = -1;
                    connection.Open();
                    OracleCommand command = BuildQueryCommandExecute(connection, storedProcName, parameters);
                    command.ExecuteNonQuery();
                    result = (int)command.Parameters["P_STATUS"].Value;
                    return result;
                }
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                LogDB.Error("USER=" + strUserID + "SQL=" + storedProcName, e);
                throw new Exception(e.Message);
            }
        }
        public static string CHECKIP(string s_IP)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand("SP_CHECKIP", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new OracleParameter("ReturnValue", OracleType.NVarChar, 20));
                command.Parameters["ReturnValue"].Direction = ParameterDirection.Output;
                command.Parameters.Add("s_IP", s_IP);
                //				command.Parameters.Add(new OracleParameter("sIP",OracleType.VarChar,20,s_IP));	
                //				command.Parameters["sIP"].Direction= ParameterDirection.Input;
                //				command.Parameters.Add( new OracleParameter ( "ReturnValue",
                //					OracleType.VarChar,20,ParameterDirection.ReturnValue,
                //					false,0,0,string.Empty,DataRowVersion.Default,null ));
                command.ExecuteNonQuery();
                return (string)command.Parameters["ReturnValue"].Value;
            }
        }
        /// <summary>
        /// 创建 OracleCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand 对象实例</returns>
        private static OracleCommand BuildIntCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new OracleParameter("ReturnValue",
                OracleType.Int32, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// 创建 OracleCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand 对象实例</returns>
        private static OracleCommand BuildIntCommandExecute(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = BuildQueryCommandExecute(connection, storedProcName, parameters);
            command.Parameters.Add(new OracleParameter("ReturnValue",
                OracleType.Int32, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion


        /// <summary>
        /// 执行查询语句，返回OracleDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader ExecuteReader(string SQLString, OracleConnection connection, params OracleParameter[] cmdParms)
        {
            //OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                OracleDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, e);
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
                //connection.Close();
            }

        }

        /// <summary>
        /// 执行查询语句，返回OracleDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader ExecuteReader(string strSQL, OracleConnection connection)
        {
            //OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand(strSQL, connection);
            try
            {
                connection.Open();
                OracleDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                LogDB.Error("USER=" + strUserID + "SQL=" + strSQL, e);
                throw new Exception(e.Message);
            }
            //finally
            //{
            //    connection.Close();
            //}

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(OracleConnection conn, OracleTransaction tran, string SQLString, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, conn, tran, SQLString, cmdParms);
            using (OracleDataAdapter da = new OracleDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (System.Data.OracleClient.OracleException ex)
                {
                    LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, ex);
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        public static void CallProcedure(OracleConnection conn, string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                OracleCommand command = BuildQueryCommandExecute(conn, storedProcName, parameters);
                command.ExecuteNonQuery();
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                LogDB.Error("USER=" + strUserID + "SQL=" + storedProcName, e);
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(OracleConnection conn, OracleTransaction tran, string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    PrepareCommandExecute(cmd, conn, null, SQLString, cmdParms);
                    cmd.Transaction = tran;
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    //LogDB.Info("用户名" + strUserID + "SQL=" + SQLString);
                    return rows;
                }
                catch (System.Data.OracleClient.OracleException E)
                {
                    LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, E);
                    throw new Exception(E.Message);
                }
            }
        }

        public static OracleDataReader RunProcedure(OracleConnection conn, string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                OracleCommand command = BuildQueryCommand(conn, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                return command.ExecuteReader();
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                LogDB.Error("USER=" + strUserID + "SQL=" + storedProcName, e);
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        public static void CallProcedure(OracleConnection connection, string storedProcName, IDataParameter[] parameters, OracleTransaction tran)
        {
            try
            {
                OracleCommand command = BuildQueryCommandExecute(connection, storedProcName, parameters);
                command.Transaction = tran;
                command.ExecuteNonQuery();
                //return (int)command.Parameters["P_STATUS"].Value;
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                LogDB.Error("USER=" + strUserID + "SQL=" + storedProcName, e);
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(OracleConnection conn, OracleTransaction tran, string SQLString)
        {
            using (OracleCommand cmd = new OracleCommand(SQLString, conn))
            {
                try
                {
                    cmd.Transaction = tran;
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.OracleClient.OracleException e)
                {
                    LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, e);
                    throw new Exception(e.Message);
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(OracleConnection conn, OracleTransaction tran, string SQLString, OracleParameter[] parameters)
        {
            using (OracleCommand cmd = new OracleCommand(SQLString, conn))
            {
                try
                {
                    PrepareCommand(cmd, conn, tran, SQLString, parameters);
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.OracleClient.OracleException e)
                {
                    LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, e);
                    throw new Exception(e.Message);
                }
            }
        }
        public static bool Exists(OracleConnection conn, OracleTransaction tran, string strSql, params OracleParameter[] cmdParms)
        {
            object obj = GetSingle(conn, tran, strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static OracleConnection Open()
        {
            OracleConnection conn = new OracleConnection(connectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            else if (conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
            return conn;
        }
        public static void Close(OracleConnection conn)
        {
            conn.Close();
        }
        public static OracleTransaction Tran(OracleConnection conn)
        {
            return conn.BeginTransaction();
        }
        public static void Commit(OracleTransaction tran)
        {
            tran.Commit();
        }
        public static void Rollback(OracleTransaction tran)
        {
            tran.Rollback();
        }


        public static object GetSingle(string SQLString, string strconnection, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(strconnection))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OracleClient.OracleException e)
                    {
                        LogDB.Error("USER=" + strUserID + "SQL=" + SQLString, e);
                        throw new Exception(e.Message);
                    }
                }
            }
        }
    }
}
