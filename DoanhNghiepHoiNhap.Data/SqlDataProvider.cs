using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DoanhNghiepHoiNhap.Data
{
    public class SqlDataProvider
    {
        private static readonly string strConStr =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        public static SqlConnection GetConnect()
        {
            try
            {
                var con = new SqlConnection(strConStr);
                return con;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetTable(SqlCommand cmd)
        {
            var dt = new DataTable();
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            SqlTransaction transaction = cmd.Connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch
            {
                transaction.Rollback();
                return dt;
            }
            finally
            {
                try
                {
                    transaction.Commit();
                    transaction.Dispose();
                    cmd.Connection.Close();
                }
                catch
                {
                }
            }
        }

        public static void ExeCuteNonquery(SqlCommand cmd)
        {
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            SqlTransaction transaction = cmd.Connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection != null)
                {
                    return cmd.ExecuteReader();
                }
                else
                {
                    using (SqlConnection conn = GetConnect())
                    {
                        cmd.Connection = conn;
                        return cmd.ExecuteReader();
                    }
                }
            }
            finally
            {
            }
        }

        public static DataSet GetDsData(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection != null)
                {
                    using (var ds = new DataSet())
                    {
                        using (var da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = GetConnect())
                    {
                        using (var ds = new DataSet())
                        {
                            using (var da = new SqlDataAdapter())
                            {
                                da.SelectCommand = cmd;
                                da.SelectCommand.Connection = conn;
                                da.Fill(ds);
                                return ds;
                            }
                        }
                    }
                }
            }
            finally
            {
            }
        }

        public static DataTable GetTable(string sql)
        {
            try
            {
                using (SqlConnection conn = GetConnect())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        if (cmd.Connection.State == ConnectionState.Closed)
                            cmd.Connection.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        using (var ds = new DataSet())
                        {
                            using (var da = new SqlDataAdapter())
                            {
                                da.SelectCommand = cmd;
                                da.SelectCommand.Connection = conn;
                                da.Fill(ds);
                                return ds.Tables[0];
                            }
                        }
                    }
                }
            }
            finally
            {
            }
        }

        public static void ExeCuteNonquery(string sql)
        {
            SqlConnection conn = GetConnect();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public static SqlDataReader ExecuteReader(string sql)
        {
            try
            {
                var cmd = new SqlCommand(sql, GetConnect());
                return cmd.ExecuteReader();
            }
            finally
            {
            }
        }

        public static string ExecuteScalar(string sql)
        {
            try
            {
                SqlConnection conn = GetConnect();
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                var cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteScalar().ToString();
            }
            finally
            {
            }
        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                SqlConnection conn = GetConnect();
                cmd.Connection = conn;
                return cmd.ExecuteScalar();
            }
            finally
            {
            }
        }

        public int DBSize()
        {
            using (var cmd = new SqlCommand("select sum(size) * 8 * 1024 from sysfiles"))
            {
                cmd.CommandType = CommandType.Text;
                return (int) ExecuteScalar(cmd);
            }
        }

        public bool CheckConnect()
        {
            var cmd = new SqlCommand("select getdate()");
            if (GetTable(cmd).Rows.Count > 0)
                return true;
            return false;
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("THANHNV"));
            }
            else keyArray = Encoding.UTF8.GetBytes("THANHNV");
            var tdes = new TripleDESCryptoServiceProvider
                           {
                               Key = keyArray,
                               Mode = CipherMode.ECB,
                               Padding = PaddingMode.PKCS7
                           };
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string toDecrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("THANHNV"));
            }
            else keyArray = Encoding.UTF8.GetBytes("THANHNV");
            var tdes = new TripleDESCryptoServiceProvider
                           {
                               Key = keyArray,
                               Mode = CipherMode.ECB,
                               Padding = PaddingMode.PKCS7
                           };
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }


        public static string FilterSqlInjection(string url)
        {
            return url;
        }
    }
}