using System.Data;
using DAL;
using PUBLIC;

namespace BUL
{
    public class HoadonOldBul
    {
        private readonly HoadonOldDal _hdDalOld = new HoadonOldDal();

        public DataTable load_hoadon_old()
        {
            return _hdDalOld.load_hoadon_old();
        }

        public int insert_hoadon_old(HOADON_OLD_PUBLIC hdOld)
        {
            return _hdDalOld.insert_hoadon_old(hdOld);
        }

        public int delete_hoadon_old(HOADON_OLD_PUBLIC hdOld)
        {
            return _hdDalOld.delete_hoadon_old(hdOld);
        }

        public DataTable load_timhd_old(HOADON_OLD_PUBLIC hdOld)
        {
            return _hdDalOld.load_timhd_old(hdOld);
        }

        public DataTable load_hd_day(HOADON_OLD_PUBLIC hdOld)
        {
            return _hdDalOld.load_hd_day(hdOld);
        }

        public DataTable load_hd_month(HOADON_OLD_PUBLIC hdOld)
        {
            return _hdDalOld.load_hd_month(hdOld);
        }

        public DataTable load_hd_year(HOADON_OLD_PUBLIC hdOld)
        {
            return _hdDalOld.load_hd_year(hdOld);
        }

        public DataTable load_hoadon_old_NOTID()
        {
            return _hdDalOld.load_hoadon_old_NOTID();
        }

        public DataTable load_timhd_old_TENNV(HOADON_OLD_PUBLIC hdOld)
        {
            return _hdDalOld.load_timhd_old_TENNV(hdOld);
        }
    }
}