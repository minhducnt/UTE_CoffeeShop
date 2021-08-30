using System.Data;
using PUBLIC;

namespace DAL
{
    public class HoadonDal
    {
        private readonly DataProvider _ketnoi = new();

        public DataTable load_hoadon()
        {
            var sql = @"LOAD_HOADON";
            return _ketnoi.Load_Data(sql);
        }

        public int insert_hoadon(HOADON_PUBLIC hoadonPublic)
        {
            var parameter = 4;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDBAN";
            name[1] = "@IDNV";
            name[2] = "@NGAYLAP";
            name[3] = "@TRANGTHAI";
            values[0] = hoadonPublic.IDBAN;
            values[1] = hoadonPublic.IDNV;
            values[2] = hoadonPublic.NGAYLAP;
            values[3] = hoadonPublic.TRANGTHAI;
            var sql = "INSERT_HOADON";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int update_hoadon(HOADON_PUBLIC hoadonPublic)
        {
            var parameter = 5;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHOADON";
            name[1] = "@IDBAN";
            name[2] = "@IDNV";
            name[3] = "@NGAYLAP";
            name[4] = "@TRANGTHAI";
            values[0] = hoadonPublic.IDHOADON;
            values[1] = hoadonPublic.IDBAN;
            values[2] = hoadonPublic.IDNV;
            values[3] = hoadonPublic.NGAYLAP;
            values[4] = hoadonPublic.TRANGTHAI;
            var sql = "UPDATE_HOADON";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int delete_hoadon(HOADON_PUBLIC hoadonPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHOADON";
            values[0] = hoadonPublic.IDHOADON;
            var sql = "DELETE_HOADON";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int count_hoadon_ban(HOADON_PUBLIC hoadonPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDBAN";
            values[0] = hoadonPublic.IDBAN;
            var sql = "DEMSOHD_OFBAN";
            return _ketnoi.ReturnValueIntWithParameter(sql, name, values, parameter);
        }

        public int delete_hoadon_with_idban(HOADON_PUBLIC hoadonPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDBAN";
            values[0] = hoadonPublic.IDBAN;
            var sql = "DELETE_HOADON_with_IDBAN";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int load_IDHD_WITH_IDBAN(HOADON_PUBLIC hdPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDBAN";
            values[0] = hdPublic.IDBAN;
            var sql = "LOAD_HOADON_WITH_IDBAN";
            return _ketnoi.ReturnValueIntWithParameter(sql, name, values, parameter);
        }

        public int update_hoadon_doiban(HOADON_PUBLIC hoadonPublic)
        {
            var parameter = 2;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDHOADON";
            name[1] = "@IDBAN";
            values[0] = hoadonPublic.IDHOADON;
            values[1] = hoadonPublic.IDBAN;
            var sql = "UPDATE_HOADON_doiban";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }
    }
}