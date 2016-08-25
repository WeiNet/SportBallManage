using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Web;

namespace CommLib
{
    public enum DbProvider
    {
        MsSql = 0,
        Sqlite = 1,
        OleDb = 2,
        Oracle = 3,
        MySql = 4
    }
    /// <summary>
    /// Database dbo = DbFactory.Instance(); 
    /// dbo.Open(); 
    /// dbo.BeginTransaction(); 
    /// dbo.ExecuteNonQuery(SqlString); 
    /// dbo.CommitTransaction(); 
    /// dbo.Close(); 
    /// </summary>
    internal class DbFactory
    {
        /// <summary>
        /// 实例 DatabaseOperator 类。
        /// </summary>
        /// <returns></returns>
        public static Database Instance()
        {
            return new DatabaseOperator();
        }
        /// <summary>
        /// 根据不同数据源类型，实例 DatabaseOperator 类。
        /// </summary>
        /// <param name="dbProviderType"></param>
        /// <returns></returns>
        public static Database Instance(DbProvider dbProviderType)
        {
            return new DatabaseOperator(dbProviderType);
        }
        /// <summary> 
        /// 根据数据库连接字符参数，实例 DatabaseOperator 类。 
        /// </summary> 
        /// <param name="ConnectionString">数据源连接字符。</param> 
        /// <returns>返回 DatabaseOperator 。</returns> 
        public static Database Instance(string ConnectionString)
        {
            return new DatabaseOperator(ConnectionString);
        }
        /// <summary> 
        /// 根据不同数据源类型、数据库连接字符参数，实例 DatabaseOperator 类。 
        /// </summary> 
        /// <param name="DBType">DOCFlying.DataEngine.DatabaseType 数据源类型</param> 
        /// <param name="ConnectionString">数据源连接字符。</param> 
        /// <returns>返回 DatabaseOperator 。</returns> 
        public static Database Instance(string ConnectionString, DbProvider dbProviderType)
        {
            return new DatabaseOperator(ConnectionString, dbProviderType);
        }
    }
    /// <summary>
    ///
    /// </summary>
    public abstract class Database
    {
        public abstract DbConnection Connection { get; }
        public abstract DbParameter CreateDbParameter(string parameterName);
        public abstract DbParameter CreateDbParameter(string parameterName, object value);
        public abstract DbParameter CreateDbParameter(string parameterName, object value, DbType dbType);
        public abstract DbParameter CreateDbParameter(string parameterName, object value, DbType dbType, int size);
        public abstract DbParameter CreateDbParameter(string parameterName, object value, DbType dbType, int size, ParameterDirection parameterDirection);
        /// <summary>
        /// 返回结果的存储过程
        /// </summary>
        /// <param name="strSql">任何SQL语句</param>
        /// <param name="parameters">参数值</param>
        /// <returns></returns>
        public abstract DbDataReader ExecuteReader(string strSql, params DbParameter[] parameters);
        /// <summary>
        /// 返回结果的存储过程
        /// </summary>
        /// <param name="strSql">任何SQL语句</param>
        /// <param name="parameters">参数值</param>
        /// <returns></returns>
        public abstract string ExecuteJson(string strSql, params DbParameter[] parameters);
        /// <summary>
        /// 返回dateSet
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public abstract DataSet Query(string strSql, string tableName, params DbParameter[] parameters);
        /// <summary>
        /// 使用SqlDataAdapter返回指定范围的数据
        /// </summary>
        /// <param name="strSql">存储过程名</param>
        /// <param name="parameters">参数名</param>
        /// <param name="start">起始行</param>
        /// <param name="maxRecord">记录数</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public abstract DataSet Query(string strSql, int start, int maxRecord, string tableName, DbParameter[] parameters);
        /// <summary>
        /// 返回Datatable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract DataTable Query(string strSql, params DbParameter[] parameters);
        /// <summary>
        /// 通過存儲過程及自定義參數組查詢返回SqlDataAdapter對象
        /// </summary>
        public abstract DbDataAdapter GetDataAdapter(string strSql, params DbParameter[] parameters);
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        public abstract void ExecuteNonQuery(string strSql, params DbParameter[] parameters);
        /// <summary>
        /// 返回第一行第一列值
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="error"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract object ExecuteScalar(string strSql, params DbParameter[] parameters);
        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="dic"></param>
        public abstract void ExecuteTran(Dictionary<DbParameter[], string> dic);
        /// <summary>
        /// 
        /// </summary>
        public abstract void ExecuteTran();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="sql"></param>
        public abstract void Add(DbParameter[] param, string sql);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public abstract void Remove(DbParameter[] param);
        /// <summary>
        /// 
        /// </summary>
        public abstract void Clear();
        ///<summary>
        ///如果数据库连接已关闭,则打开
        ///</summary>
        public abstract void Open();
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public abstract void Close();
        /// <summary>
        /// 
        /// </summary>
        public abstract void BeginTran();
        /// <summary>
        /// 
        /// </summary>
        public abstract void CommitTran();
        /// <summary>
        /// 
        /// </summary>
        public abstract void RollbackTran();
    }
    /// <summary>
    /// 
    /// </summary>
    internal class DatabaseOperator : Database
    {
        #region 属性
        private DbConnection _Connection;
        public override DbConnection Connection
        {
            get { return _Connection; }
        }
        private string ConnectionString;
        private DbProvider DbProviderType;
        private DbTransaction Transaction;
        private DbProviderFactory dbFactory;
        private Dictionary<DbParameter[], string> dicDbParameter;
        #endregion

        #region 构造函数
        public DatabaseOperator()
        {
            DatabaseInstance(System.Configuration.ConfigurationManager.AppSettings["OracleConnString"], DbProvider.Oracle);
        }
        public DatabaseOperator(string connectionString)
        {
            DatabaseInstance(connectionString, DbProvider.Oracle);
        }
        public DatabaseOperator(DbProvider dbProviderType)
        {
            DatabaseInstance(System.Configuration.ConfigurationManager.AppSettings["OracleConnString"], dbProviderType);
        }
        public DatabaseOperator(string connectionString, DbProvider dbProviderType)
        {
            DatabaseInstance(connectionString, dbProviderType);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbProviderType"></param>
        private void DatabaseInstance(string connectionString, DbProvider dbProviderType)
        {
            this.DbProviderType = dbProviderType;
            this.ConnectionString = connectionString;
            CreateFactory();
            this._Connection = this.dbFactory.CreateConnection();
            this.Connection.ConnectionString = this.ConnectionString;
            this.dicDbParameter = new Dictionary<DbParameter[], string>();
        }
        #endregion
        
        /// <summary>
        /// 创建数据操作工厂
        /// </summary>
        private void CreateFactory()
        {
            switch (DbProviderType)
            {
                case DbProvider.MsSql:
                    this.dbFactory = System.Data.SqlClient.SqlClientFactory.Instance;
                    break;
                //case DbProvider.Sqlite:
                //    this.dbFactory = System.Data.SQLite.SQLiteFactory.Instance;
                //    break;
                case DbProvider.OleDb:
                    this.dbFactory = System.Data.OleDb.OleDbFactory.Instance;
                    break;
                case DbProvider.Oracle:
                    this.dbFactory = System.Data.OracleClient.OracleClientFactory.Instance;
                    break;
                //case DbProvider.MySql:
                //    this.dbFactory = MySql.Data.MySqlClient.MySqlClientFactory.Instance;
                //    break;
            }
        }
        /// <summary>
        /// 创建操作对象
        /// </summary>
        /// <param name="procNameOrExText">如果包含@,则采用CommandType.Text</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private DbCommand BuilderQueryCommand(string procNameOrExText, params DbParameter[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
            {
                DbCommand command = this.dbFactory.CreateCommand();
                command.CommandText = procNameOrExText;
                command.Connection = this.Connection;
                command.Transaction = this.Transaction;
                return command;
            }
            if (procNameOrExText.IndexOf(':') > 0 || procNameOrExText.IndexOf('@') > 0)//sql
            {
                return BuilderQueryCommandText(procNameOrExText, parameters);
            }
            else//存储过程
            {
                return BuilderQueryCommandStorPro(procNameOrExText, parameters);
            }
        }
        /// <summary>
        /// 根据存储过程名称和参数生成对应的SQL命令对象
        /// </summary>
        /// <param name="strSql">存储过程名或者</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        private DbCommand BuilderQueryCommandStorPro(string strSql, params DbParameter[] parameters)
        {
            DbCommand command = this.dbFactory.CreateCommand();
            command.CommandText = strSql;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.Connection;
            command.Transaction = this.Transaction;
            if (parameters != null)
            {
                foreach (DbParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
            }
            return command;
        }
        /// <summary>
        /// 根据存SQL语句和参数生成对应的SQL命令对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private DbCommand BuilderQueryCommandText(string strSql, params DbParameter[] parameters)
        {
            DbCommand command = this.dbFactory.CreateCommand();
            command.CommandText = strSql;
            command.Connection = this.Connection;
            command.Transaction = this.Transaction;
            if (parameters != null)
            {
                foreach (DbParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
            }
            return command;
        }
        public override DbParameter CreateDbParameter(string parameterName)
        {
            return CreateDbParameter(parameterName, DBNull.Value, DbType.Object, 0, ParameterDirection.Input);
        }
        public override DbParameter CreateDbParameter(string parameterName, object value)
        {
            return CreateDbParameter(parameterName, value, DbType.Object, 0, ParameterDirection.Input);
        }
        public override DbParameter CreateDbParameter(string parameterName, object value, DbType dbType)
        {
            return CreateDbParameter(parameterName, value, dbType, 0, ParameterDirection.Input);
        }
        public override DbParameter CreateDbParameter(string parameterName, object value, DbType dbType, int size)
        {
            return CreateDbParameter(parameterName, value, dbType, size, ParameterDirection.Input);
        }
        public override DbParameter CreateDbParameter(string parameterName, object value, DbType dbType, int size, ParameterDirection parameterDirection)
        {
            DbParameter pat = this.dbFactory.CreateParameter();
            pat.ParameterName = parameterName;
            pat.Value = value;
            pat.DbType = dbType;
            if (size > 0)
            {
                pat.Size = size;
            }
            pat.Direction = parameterDirection;
            return pat;
        }
        /// <summary>
        /// 返回结果的存储过程
        /// </summary>
        /// <param name="strSql">任何SQL语句</param>
        /// <param name="parameters">参数值</param>
        /// <returns></returns>
        public override DbDataReader ExecuteReader(string strSql, params DbParameter[] parameters)
        {
            try
            {
                DbCommand cmd = BuilderQueryCommand(strSql, parameters);
                return cmd.ExecuteReader();//在dr关闭之后,就不需要进行cnn的关闭操作了
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 返回结果的存储过程
        /// </summary>
        /// <param name="strSql">任何SQL语句</param>
        /// <param name="parameters">参数值</param>
        /// <returns></returns>
        public override string ExecuteJson(string strSql, params DbParameter[] parameters)
        {
            try
            {
                DbCommand cmd = BuilderQueryCommand(strSql, parameters);

                System.IO.StringWriter sw = null;
                Newtonsoft.Json.JsonWriter writer = null;

                sw = new System.IO.StringWriter();
                writer = new Newtonsoft.Json.JsonTextWriter(sw);

                writer.WriteStartArray();
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    do
                    {
                        while (dr.Read())
                        {
                            writer.WriteStartObject();
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                writer.WritePropertyName(dr.GetName(i));
                                writer.WriteValue(Convert.ToString(dr[i]));
                            }
                            writer.WriteEndObject();
                        }
                    }
                    while (dr.NextResult());
                }

                writer.WriteEndArray();
                writer.Flush();
                return sw.GetStringBuilder().ToString();

            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 返回dateSet
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public override DataSet Query(string strSql, string tableName, params DbParameter[] parameters)
        {
            try
            {
                DataSet ds = new DataSet("ds");
                DbDataAdapter myDa = this.dbFactory.CreateDataAdapter();
                myDa.SelectCommand = BuilderQueryCommand(strSql, parameters);
                myDa.Fill(ds, tableName);
                return ds;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 使用SqlDataAdapter返回指定范围的数据
        /// </summary>
        /// <param name="strSql">存储过程名</param>
        /// <param name="parameters">参数名</param>
        /// <param name="start">起始行</param>
        /// <param name="maxRecord">记录数</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public override DataSet Query(string strSql, int start, int maxRecord, string tableName, DbParameter[] parameters)
        {
            try
            {
                DataSet ds = new DataSet("ds");
                DbDataAdapter myDa = this.dbFactory.CreateDataAdapter();
                myDa.SelectCommand = BuilderQueryCommand(strSql, parameters);
                myDa.Fill(ds, start, maxRecord, tableName);
                return ds;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 返回Datatable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override DataTable Query(string strSql, params DbParameter[] parameters)
        {
            try
            {
                DataTable dt = new DataTable("dt");
                DbDataAdapter myDa = this.dbFactory.CreateDataAdapter();
                myDa.SelectCommand = BuilderQueryCommand(strSql, parameters);
                myDa.Fill(dt);
                return dt;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 通過存儲過程及自定義參數組查詢返回SqlDataAdapter對象
        /// </summary>
        public override DbDataAdapter GetDataAdapter(string strSql, params DbParameter[] parameters)
        {
            try
            {
                DbCommand cmd = BuilderQueryCommand(strSql, parameters);
                DbDataAdapter myDa = this.dbFactory.CreateDataAdapter();
                myDa.SelectCommand = cmd;
                return myDa;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        public override void ExecuteNonQuery(string strSql, params DbParameter[] parameters)
        {
            try
            {
                DbCommand cmd = BuilderQueryCommand(strSql, parameters);
                cmd.Transaction = this.Transaction;
                cmd.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 返回第一行第一列值
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="error"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override object ExecuteScalar(string strSql, params DbParameter[] parameters)
        {
            try
            {
                DbCommand cmd = BuilderQueryCommand(strSql, parameters);
                cmd.Transaction = Transaction;
                return cmd.ExecuteScalar();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 执行批量sql事务
        /// </summary>
        /// <param name="dic"></param>
        public override void ExecuteTran(Dictionary<DbParameter[], string> dic)
        {
            try
            {
                DbCommand cmd = null;
                foreach (KeyValuePair<DbParameter[], string> kvp in dic)
                {
                    cmd = BuilderQueryCommand(kvp.Value, kvp.Key);
                    cmd.Transaction = this.Transaction;
                    cmd.ExecuteNonQuery();
                }
                this.Transaction.Commit();
            }
            catch (DbException ex)
            {
                this.Transaction.Rollback();
                throw ex;
            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// 执行批量sql事务
        /// </summary>
        public override void ExecuteTran()
        {
            try
            {
                DbCommand cmd = null;
                foreach (KeyValuePair<DbParameter[], string> kvp in dicDbParameter)
                {
                    cmd = BuilderQueryCommand(kvp.Value, kvp.Key);
                    cmd.Transaction = this.Transaction;
                    cmd.ExecuteNonQuery();
                }
                this.Transaction.Commit();
            }
            catch (DbException ex)
            {
                this.Transaction.Rollback();
                throw ex;
            }
            catch
            {
                throw;
            }

        }
        public override void Add(DbParameter[] param, string sql)
        {
            dicDbParameter.Add(param, sql);
        }
        public override void Remove(DbParameter[] param)
        {
            dicDbParameter.Remove(param);
        }
        public override void Clear()
        {
            dicDbParameter.Clear();
        }
        public override void Open()
        {
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                {
                    this.Connection.Open();
                    return;
                }
                else if (this.Connection.State == ConnectionState.Broken)
                {
                    this.Connection.Close();
                    this.Connection.Open();
                    return;
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        public override void Close()
        {
            try
            {
                if (this.Connection.State != ConnectionState.Closed)
                {
                    this.Connection.Close();
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        public override void BeginTran()
        {
            try
            {
                this.Transaction = this.Connection.BeginTransaction();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        public override void CommitTran()
        {
            try
            {
                this.Transaction.Commit();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
        public override void RollbackTran()
        {
            try
            {
                this.Transaction.Rollback();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="connection"></param>
    /// <returns></returns>
    public delegate T MethodDB<T>(params DbConnection[] conn);
    /// <summary>
    /// 
    /// </summary>
    public class MethodDB
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="invokeMethod"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public static T InvokeMethodWithDB<T>(MethodDB<T> invokeMethod, params string[] connStr)
        {
            T retObj = default(T);
            List<DbConnection> conns = new List<DbConnection>();
            try
            {
                foreach (string str in connStr)
                {
                    Database db = DbFactory.Instance(str);
                    db.Open();
                    conns.Add(db.Connection);
                }

                retObj = invokeMethod(conns.ToArray());


            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
            finally
            {
                foreach (DbConnection db in conns)
                {
                    db.Close();
                }
            }
            return retObj;
        }
    }
    /// <summary>
    ///  数学公式
    /// </summary>
    public class MathFormula
    {
        /// <summary>
        /// 排列组合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static class PermutationAndCombination<T>
        {
            /// <summary>
            /// 交换两个变量
            /// </summary>
            /// <param name="a">变量1</param>
            /// <param name="b">变量2</param>
            public static void Swap(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }

            /// <summary>
            /// 递归算法求数组的组合(私有成员)
            /// </summary>
            /// <param name="list">返回的范型</param>
            /// <param name="t">所求数组</param>
            /// <param name="n">辅助变量</param>
            /// <param name="m">辅助变量</param>
            /// <param name="b">辅助数组</param>
            /// <param name="M">辅助变量M</param>
            private static void GetCombination(ref List<T[]> list, T[] t, int n, int m, int[] b, int M)
            {
                for (int i = n; i >= m; i--)
                {
                    b[m - 1] = i - 1;
                    if (m > 1)
                    {
                        GetCombination(ref list, t, i - 1, m - 1, b, M);
                    }
                    else
                    {
                        if (list == null)
                        {
                            list = new List<T[]>();
                        }
                        T[] temp = new T[M];
                        for (int j = 0; j < b.Length; j++)
                        {
                            temp[j] = t[b[j]];
                        }
                        list.Add(temp);
                    }
                }
            }

            /// <summary>
            /// 递归算法求排列(私有成员)
            /// </summary>
            /// <param name="list">返回的列表</param>
            /// <param name="t">所求数组</param>
            /// <param name="startIndex">起始标号</param>
            /// <param name="endIndex">结束标号</param>
            private static void GetPermutation(ref List<T[]> list, T[] t, int startIndex, int endIndex)
            {
                if (startIndex == endIndex)
                {
                    if (list == null)
                    {
                        list = new List<T[]>();
                    }
                    T[] temp = new T[t.Length];
                    t.CopyTo(temp, 0);
                    list.Add(temp);
                }
                else
                {
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        Swap(ref t[startIndex], ref t[i]);
                        GetPermutation(ref list, t, startIndex + 1, endIndex);
                        Swap(ref t[startIndex], ref t[i]);
                    }
                }
            }

            /// <summary>
            /// 求从起始标号到结束标号的排列，其余元素不变
            /// </summary>
            /// <param name="t">所求数组</param>
            /// <param name="startIndex">起始标号</param>
            /// <param name="endIndex">结束标号</param>
            /// <returns>从起始标号到结束标号排列的范型</returns>
            public static List<T[]> GetPermutation(T[] t, int startIndex, int endIndex)
            {
                if (startIndex < 0 || endIndex > t.Length - 1)
                {
                    return null;
                }
                List<T[]> list = new List<T[]>();
                GetPermutation(ref list, t, startIndex, endIndex);
                return list;
            }

            /// <summary>
            /// 返回数组所有元素的全排列
            /// </summary>
            /// <param name="t">所求数组</param>
            /// <returns>全排列的范型</returns>
            public static List<T[]> GetPermutation(T[] t)
            {
                return GetPermutation(t, 0, t.Length - 1);
            }

            /// <summary>
            /// 求数组中n个元素的排列
            /// </summary>
            /// <param name="t">所求数组</param>
            /// <param name="n">元素个数</param>
            /// <returns>数组中n个元素的排列</returns>
            public static List<T[]> GetPermutation(T[] t, int n)
            {
                if (n > t.Length)
                {
                    return null;
                }
                List<T[]> list = new List<T[]>();
                List<T[]> c = GetCombination(t, n);
                for (int i = 0; i < c.Count; i++)
                {
                    List<T[]> l = new List<T[]>();
                    GetPermutation(ref l, c[i], 0, n - 1);
                    list.AddRange(l);
                }
                return list;
            }

            /// <summary>
            /// 求数组中n个元素的组合
            /// </summary>
            /// <param name="t">所求数组</param>
            /// <param name="n">元素个数</param>
            /// <returns>数组中n个元素的组合的范型</returns>
            public static List<T[]> GetCombination(T[] t, int n)
            {
                if (t.Length < n)
                {
                    return null;
                }
                int[] temp = new int[n];
                List<T[]> list = new List<T[]>();
                GetCombination(ref list, t, t.Length, n, temp, n);
                return list;
            }
        }
    }

    public class Utility
    {
        private static string key;
        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        static Utility()
        {
            key = "GameTree";
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
            provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
            //byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            stream.Close();
            return builder.ToString();
        }

        /// <summary>
        /// 解密 
        /// </summary>
        /// <param name="str">Desc string</param>
        /// <param name="key">Key ,必须为8位 </param>
        /// <returns></returns>
        public static string Decode(string str)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
            provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
            byte[] buffer = new byte[str.Length / 2];
            for (int i = 0; i < (str.Length / 2); i++)
            {
                int num2 = Convert.ToInt32(str.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte)num2;
            }
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            stream.Close();
            //return Encoding.GetEncoding("GB2312").GetString(stream.ToArray());
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        public static string GetIpAddress()
        {
            string ip = String.Empty;
            if (string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_VIA"])) //如果没有使用代理服务器或者得不到客户端的
            {
                //得到服务端的地址 
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; //While it can't get the Client IP, it will return proxy IP. 
            }
            else// 服务器， using proxy 
            {
                //得到真实的客户端地址 
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; // Return real client IP. 
            }
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.UserHostAddress;
            }
            return ip;
        }
    }

    public class DbCommon
    {
        private Database db = null;
        public Database DbHelper
        {
            get { return db; }
        }
        public DbCommon()
        {
            db = DbFactory.Instance();
            db.Open();
        }
        /// <summary>
        /// 是否开启事务
        /// </summary>
        /// <param name="isTran"></param>
        public DbCommon(bool isTran)
        {
            db = DbFactory.Instance();
            db.Open();
            if (isTran)
            {
                db.BeginTran();
            }
        }
    }
}