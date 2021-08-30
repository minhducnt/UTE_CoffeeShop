using System.Data;
using PUBLIC;

namespace DAL
{
    public class HoadonOldDal
    {
        private readonly DataProvider _ketnoi = new();

        public DataTable load_hoadon_old()
        {
            var sql = @"LOAD_HOADON_OLD";
            return _ketnoi.Load_Data(sql);
        }

        public DataTable load_hoadon_old_NOTID()
        {
            var sql = @"LOAD_HOADON_OLD_NOTID";
            return _ketnoi.Load_Data(sql);
        }

        public int insert_hoadon_old(HOADON_OLD_PUBLIC hdOld)
        {
            var parameter = 6;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHOADON";
            name[1] = "@IDBAN";
            name[2] = "@IDNV";
            name[3] = "@NGAYLAP";
            name[4] = "@TRANGTHAI";
            name[5] = "@TONGTIEN";
            values[0] = hdOld.IDHOADON;
            values[1] = hdOld.IDBAN;
            values[2] = hdOld.IDNV;
            values[3] = hdOld.NGAYLAP;
            values[4] = hdOld.TRANGTHAI;
            values[5] = hdOld.TONGTIEN;
            var sql = "INSERT_HOADON_OLD";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int delete_hoadon_old(HOADON_OLD_PUBLIC hdOld)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHD_OLD";
            values[0] = hdOld.IDHOADON;
            var sql = "DELETE_HOADON_OLD";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public DataTable load_timhd_old(HOADON_OLD_PUBLIC hdOld)
        {
            var paramater = 1;
            var name = new string[paramater];
            var values = new object[paramater];
            name[0] = "@TEMBAN";
            values[0] = hdOld.Soban;
            var sql = "TIM_HOADON_OLD";
            return _ketnoi.LoadDataWithParameter(sql, name, values, paramater);
        }

        public DataTable load_timhd_old_TENNV(HOADON_OLD_PUBLIC hdOld)
        {
            var paramater = 1;
            var name = new string[paramater];
            var values = new object[paramater];
            name[0] = "@TENNV";
            values[0] = hdOld.TENNV;
            var sql = "TIM_HOADON_OLD_tennv";
            return _ketnoi.LoadDataWithParameter(sql, name, values, paramater);
        }

        public DataTable load_hd_day(HOADON_OLD_PUBLIC hdOld)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@NGAY";
            values[0] = hdOld.NGAY;
            var sql = "LOAD_HD_DAY";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public DataTable load_hd_month(HOADON_OLD_PUBLIC hdOld)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@THANG";
            values[0] = hdOld.THANG;
            var sql = "LOAD_HD_MONTH";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }

        public DataTable load_hd_year(HOADON_OLD_PUBLIC hdOld)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@NAM";
            values[0] = hdOld.NAM;
            var sql = "LOAD_HD_YEAR";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }
    }
}