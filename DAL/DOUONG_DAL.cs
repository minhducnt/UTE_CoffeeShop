using System.Data;
using PUBLIC;

namespace DAL
{
    public class DouongDal
    {
        private readonly DataProvider _ketnoi = new();

        public DataTable load_douong()
        {
            var sql = @"LOAD_DOUONG";
            return _ketnoi.Load_Data(sql);
        }

        public DataTable load_indsdouong()
        {
            var sql = "LOAD_INDSDOUONG";
            return _ketnoi.Load_Data(sql);
        }

        public DataTable load_douongvoi_where(DOUONG_PUBLIC douongPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@MADM";
            values[0] = douongPublic.IDDM;
            var sql = "LOAD_DOUONG_WITH_WHERE";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public DataTable foodfind(int iddm)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDDM";
            values[0] = iddm;
            var sql = "LOAD_DOUONG_ID";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public DataTable TIM_DOUONG(DOUONG_PUBLIC douongPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@TEN";
            values[0] = douongPublic.TEN;
            var sql = "TIM_TENDOUONG";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public int insert_douong(DOUONG_PUBLIC douongPublic)
        {
            var parameter = 3;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDDM";
            name[1] = "@TENDOUONG";
            name[2] = "@DONGIA";
            values[0] = douongPublic.IDDM;
            values[1] = douongPublic.TENDOUONG;
            values[2] = douongPublic.DONGIA;
            var sql = "INSERT_DOUONG";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int update_douong(DOUONG_PUBLIC douongPublic)
        {
            var parameter = 4;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDDOUONG";
            name[1] = "@IDDM";
            name[2] = "@TENDOUONG";
            name[3] = "@DONGIA";
            values[0] = douongPublic.IDDOUONG;
            values[1] = douongPublic.IDDM;
            values[2] = douongPublic.TENDOUONG;
            values[3] = douongPublic.DONGIA;
            var sql = "UPDATE_DOUONG";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int delete_douong(DOUONG_PUBLIC douongPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDDOUONG";
            values[0] = douongPublic.IDDOUONG;
            var sql = "DELETE_DOUONG";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }
    }
}