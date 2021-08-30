using System.Data;
using DAL;
using PUBLIC;

namespace BUL
{
    public class CthdBul
    {
        private readonly CthdDal _cthdDal = new CthdDal();

        public DataTable load_cthd(CTHD_PUBLIC cthdPublic)
        {
            return _cthdDal.load_cthd(cthdPublic);
        }

        public int insert_cthd(CTHD_PUBLIC cthdPublic)
        {
            return _cthdDal.insert_cthd(cthdPublic);
        }

        public int update_cthd(CTHD_PUBLIC cthdPublic)
        {
            return _cthdDal.update_cthd(cthdPublic);
        }

        public int delete_cthd(CTHD_PUBLIC cthdPublic)
        {
            return _cthdDal.delete_cthd(cthdPublic);
        }

        public DataTable load_cthd_thanhtoan(CTHD_PUBLIC cthdPublic)
        {
            return _cthdDal.load_cthd_thanhtoan(cthdPublic);
        }
    }
}