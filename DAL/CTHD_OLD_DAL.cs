using System.Data;
using PUBLIC;

namespace DAL
{
    public class CthdOldDal
    {
        private readonly DataProvider _ketnoi = new();

        public DataTable load_cthd_old(CTHD_OLD_PUBLIC cthdOld)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHD_OLD";
            values[0] = cthdOld.IDHOADON_OLD;
            var sql = "LOAD_CTHD_OLD";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public DataTable load_cthd_old_printer(CTHD_OLD_PUBLIC cthdOld)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHD_OLD";
            values[0] = cthdOld.IDHOADON_OLD;
            var sql = "LOAD_CTHD_OLD_PRINTER";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public int insert_cthd_old(CTHD_OLD_PUBLIC cthdOld)
        {
            var parameter = 3;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHD_OLD";
            name[1] = "@IDDOUONG";
            name[2] = "@SOLUONG";
            values[0] = cthdOld.IDHOADON_OLD;
            values[1] = cthdOld.IDDOUONG;
            values[2] = cthdOld.SOLUONG;
            var sql = "INSERT_CTHD_OLD";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int delete_cthd_old(CTHD_OLD_PUBLIC cthdOld)
        {
            var parameter = 2;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHD_OLD";
            values[0] = cthdOld.IDHOADON_OLD;
            var sql = "DELETE_CTHD_OLD";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }
    }
}