using System.Data;
using PUBLIC;

namespace DAL
{
    public class NhanvienDal
    {
        private readonly DataProvider _ketnoi = new();

        public DataTable load_nhanvien()
        {
            var sql = @"LOAD_NHANVIEN";
            return _ketnoi.Load_Data(sql);
        }

        public int insert_nhanvien(NHANVIEN_PUBLIC nhanvienPublic)
        {
            var parameter = 5;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDNV";
            name[1] = "@TENNV";
            name[2] = "@NGAYSINH";
            name[3] = "@SDT";
            name[4] = "@GIOITINH";
            values[0] = nhanvienPublic.IDNV;
            values[1] = nhanvienPublic.TENNV;
            values[2] = nhanvienPublic.NGAYSINH;
            values[3] = nhanvienPublic.SDT;
            values[4] = nhanvienPublic.GIOITINH;
            var sql = "INSERT_NHANVIEN";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int update_nhanvien(NHANVIEN_PUBLIC nhanvienPublic)
        {
            var parameter = 5;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDNV";
            name[1] = "@TENNV";
            name[2] = "@NGAYSINH";
            name[3] = "@SDT";
            name[4] = "@GIOITINH";
            values[0] = nhanvienPublic.IDNV;
            values[1] = nhanvienPublic.TENNV;
            values[2] = nhanvienPublic.NGAYSINH;
            values[3] = nhanvienPublic.SDT;
            values[4] = nhanvienPublic.GIOITINH;
            var sql = "UPDATE_NHANVIEN";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int delete_nhanvien(NHANVIEN_PUBLIC nhanvienPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@IDNV";
            values[0] = nhanvienPublic.IDNV;
            var sql = "DELETE_NHANVIEN";
            return _ketnoi.ExecuteData(sql, name, values, parameter);
        }

        public int count_nhanvien()
        {
            var sql = "COUNT_NHANVIEN";
            return _ketnoi.ReturnValueInt(sql);
        }

        public DataTable Tim_nv(NHANVIEN_PUBLIC nhanvienPublic)
        {
            var parameter = 1;
            var name = new string[parameter];
            var values = new object[parameter];
            name[0] = "@TEN";
            values[0] = nhanvienPublic.TIMTEN;
            var sql = "TIM_TENNV";
            return _ketnoi.LoadDataWithParameter(sql, name, values, parameter);
        }
    }
}