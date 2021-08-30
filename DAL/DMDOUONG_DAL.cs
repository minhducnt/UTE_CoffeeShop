using System.Data;
using PUBLIC;

namespace DAL
{
    public class DmdouongDal
    {
        private readonly DataProvider _ketnoi = new();

        public DataTable load_dmdouong()
        {
            var sql = @"LOAD_DANHMUC";
            return _ketnoi.Load_Data(sql);
        }

        public int insert_dmdouong(DMDOUONG_PUBLIC dmdouongPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@TENDM";
            values[0] = dmdouongPublic.TENDM;
            var sql = "INSERT_DANHMUC";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int update_dmdouong(DMDOUONG_PUBLIC dmdouongPublic)
        {
            var parameter = 2;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDDM";
            name[1] = "@TENDM";
            values[0] = dmdouongPublic.IDDM;
            values[1] = dmdouongPublic.TENDM;
            var sql = "UPDATE_DANHMUC";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int delete_dmdouong(DMDOUONG_PUBLIC dmdouongPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDDM";
            values[0] = dmdouongPublic.IDDM;
            var sql = "DELETE_DANHMUC";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }
    }
}