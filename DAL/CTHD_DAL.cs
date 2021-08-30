using System.Data;
using PUBLIC;

namespace DAL
{
    public class CthdDal
    {
        private readonly DataProvider _ketnoi = new();

        public DataTable load_cthd(CTHD_PUBLIC cthdPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHOADON";
            values[0] = cthdPublic.IDHOADON;
            var sql = "LOAD_CTHD";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public DataTable load_cthd_thanhtoan(CTHD_PUBLIC cthdPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHOADON";
            values[0] = cthdPublic.IDHOADON;
            var sql = "LOAD_CTHD_thanhtoan";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public int insert_cthd(CTHD_PUBLIC cthdPublic)
        {
            var parameter = 3;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHOADON";
            name[1] = "@IDDOUONG";
            name[2] = "@SOLUONG";
            values[0] = cthdPublic.IDHOADON;
            values[1] = cthdPublic.IDDOUONG;
            values[2] = cthdPublic.SOLUONG;
            var sql = "INSERT_CTHD";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int update_cthd(CTHD_PUBLIC cthdPublic)
        {
            var parameter = 4;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDCTHD";
            name[1] = "@IDHOADON";
            name[2] = "@IDDOUONG";
            name[3] = "@SOLUONG";
            values[0] = cthdPublic.IDCTHD;
            values[1] = cthdPublic.IDHOADON;
            values[2] = cthdPublic.IDDOUONG;
            values[3] = cthdPublic.SOLUONG;
            var sql = "UPDATE_CTHD";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int delete_cthd(CTHD_PUBLIC cthdPublic)
        {
            var parameter = 2;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHOADON";
            name[1] = "@IDDOUONG";
            values[0] = cthdPublic.IDHOADON;
            values[1] = cthdPublic.IDDOUONG;
            var sql = "DELETE_CTHD";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }
    }
}