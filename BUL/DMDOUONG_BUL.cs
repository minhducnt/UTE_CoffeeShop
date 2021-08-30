using System.Data;
using DAL;
using PUBLIC;

namespace BUL
{
    public class DmdouongBul
    {
        private readonly DmdouongDal _dmdouongDal = new DmdouongDal();

        public DataTable load_dmdouong()
        {
            return _dmdouongDal.load_dmdouong();
        }

        public int insert_dmdouong(DMDOUONG_PUBLIC dmdouongPublic)
        {
            return _dmdouongDal.insert_dmdouong(dmdouongPublic);
        }

        public int update_dmdouong(DMDOUONG_PUBLIC dmdouongPublic)
        {
            return _dmdouongDal.update_dmdouong(dmdouongPublic);
        }

        public int delete_dmdouong(DMDOUONG_PUBLIC dmdouongPublic)
        {
            return _dmdouongDal.delete_dmdouong(dmdouongPublic);
        }
    }
}