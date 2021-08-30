using System.Collections.Generic;
using System.Data;
using PUBLIC;

namespace DAL
{
    public class BanDal
    {
        private readonly DataProvider _conn = new();

        public DataTable load_ban()
        {
            var sql = @"LOAD_BAN";
            return _conn.Load_Data(sql);
        }

        public DataTable load_ban_trong()
        {
            var sql = @"LOAD_BAN_TRONG";
            return _conn.Load_Data(sql);
        }

        public DataTable load_ban_conguoi()
        {
            var sql = @"LOAD_BAN_CONGUOI";
            return _conn.Load_Data(sql);
        }

        public int insert_ban(BAN_PUBLIC ban_public)
        {
            var parameter = 3;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@TEN";
            name[1] = "@TRANGTHAI";
            name[2] = "@ODER";
            values[0] = ban_public.TEN;
            values[1] = ban_public.TRANGTHAI;
            values[2] = ban_public.ODER;
            var sql = "INSERT_BAN";
            return _conn.ExecuteData(sql, name, values, parameter);
        }

        public int update_ban(BAN_PUBLIC ban_public)
        {
            var parameter = 3;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDBAN";
            name[1] = "@TEN";
            name[2] = "@TRANGTHAI";
            values[0] = ban_public.IDBAN;
            values[1] = ban_public.TEN;
            values[2] = ban_public.TRANGTHAI;
            var sql = "UPDATE_BAN";
            return _conn.ExecuteData(sql, name, values, parameter);
        }

        public int delete_ban(BAN_PUBLIC ban_public)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDBAN";
            values[0] = ban_public.IDBAN;
            var sql = "DELETE_BAN";
            return _conn.ExecuteData(sql, name, values, parameter);
        }

        public List<BAN_PUBLIC> Loaddsban()
        {
            var dsban = new List<BAN_PUBLIC>();
            var dt = load_ban();
            foreach (DataRow dong in dt.Rows)
            {
                var table = new BAN_PUBLIC(dong);
                dsban.Add(table);
            }

            return dsban;
        }

        public int update_trangthaiban(BAN_PUBLIC ban_public)
        {
            var parameter = 2;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDBAN";
            name[1] = "@TRANGTHAI";
            values[0] = ban_public.IDBAN;
            values[1] = ban_public.TRANGTHAI;
            var sql = "UPDATE_trangthaiban";
            return _conn.ExecuteData(sql, name, values, parameter);
        }
    }
}