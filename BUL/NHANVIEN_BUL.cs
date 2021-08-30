using System.Data;
using DAL;
using PUBLIC;

namespace BUL
{
    public class NhanvienBul
    {
        private readonly NhanvienDal _nhanvienDal = new NhanvienDal();

        public DataTable load_nhanvien()
        {
            return _nhanvienDal.load_nhanvien();
        }

        public int insert_nhanvien(NHANVIEN_PUBLIC nhanvienPublic)
        {
            return _nhanvienDal.insert_nhanvien(nhanvienPublic);
        }

        public int update_nhanvien(NHANVIEN_PUBLIC nhanvienPublic)
        {
            return _nhanvienDal.update_nhanvien(nhanvienPublic);
        }

        public int delete_nhanvien(NHANVIEN_PUBLIC nhanvienPublic)
        {
            return _nhanvienDal.delete_nhanvien(nhanvienPublic);
        }

        public int count_nhanvien()
        {
            return _nhanvienDal.count_nhanvien();
        }

        public DataTable Tim_nv(NHANVIEN_PUBLIC nhanvienPublic)
        {
            return _nhanvienDal.Tim_nv(nhanvienPublic);
        }
    }
}