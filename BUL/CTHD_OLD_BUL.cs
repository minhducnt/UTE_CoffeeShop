using System.Data;
using DAL;
using PUBLIC;

namespace BUL
{
    public class CthdOldBul
    {
        private readonly CthdOldDal _cthdOldDal = new CthdOldDal();

        public DataTable load_cthd_old(CTHD_OLD_PUBLIC cthdOld)
        {
            return _cthdOldDal.load_cthd_old(cthdOld);
        }

        public DataTable load_cthd_old_printer(CTHD_OLD_PUBLIC cthdOld)
        {
            return _cthdOldDal.load_cthd_old_printer(cthdOld);
        }

        public int insert_cthd_old(CTHD_OLD_PUBLIC cthdOld)
        {
            return _cthdOldDal.insert_cthd_old(cthdOld);
        }

        public int delete_cthd_old(CTHD_OLD_PUBLIC cthdOld)
        {
            return _cthdOldDal.delete_cthd_old(cthdOld);
        }
    }
}