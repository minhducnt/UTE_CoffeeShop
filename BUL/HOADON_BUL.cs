using System.Data;
using DAL;
using PUBLIC;

namespace BUL
{
    public class HoadonBul
    {
        private readonly HoadonDal _hoadonDal = new HoadonDal();

        public DataTable load_hoadon()
        {
            return _hoadonDal.load_hoadon();
        }

        public int insert_hoadon(HOADON_PUBLIC hoadonPublic)
        {
            return _hoadonDal.insert_hoadon(hoadonPublic);
        }

        public int update_hoadon(HOADON_PUBLIC hoadonPublic)
        {
            return _hoadonDal.update_hoadon(hoadonPublic);
        }

        public int delete_hoadon(HOADON_PUBLIC hoadonPublic)
        {
            return _hoadonDal.delete_hoadon(hoadonPublic);
        }

        public int count_hoadon_ban(HOADON_PUBLIC hoadonPublic)
        {
            return _hoadonDal.count_hoadon_ban(hoadonPublic);
        }

        public int delete_hoadon_with_idban(HOADON_PUBLIC hoadon_public)
        {
            return _hoadonDal.delete_hoadon_with_idban(hoadon_public);
        }

        public int load_IDHD_WITH_IDBAN(HOADON_PUBLIC hd_public)
        {
            return _hoadonDal.load_IDHD_WITH_IDBAN(hd_public);
        }

        public int update_hoadon_doiban(HOADON_PUBLIC hoadon_public)
        {
            return _hoadonDal.update_hoadon_doiban(hoadon_public);
        }
    }
}