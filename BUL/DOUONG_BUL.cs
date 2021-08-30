using System.Data;
using DAL;
using PUBLIC;

namespace BUL
{
    public class DouongBul
    {
        private readonly DouongDal _douongDal = new DouongDal();

        public DataTable load_douong()
        {
            return _douongDal.load_douong();
        }

        public int insert_douong(DOUONG_PUBLIC douongPublic)
        {
            return _douongDal.insert_douong(douongPublic);
        }

        public int update_douong(DOUONG_PUBLIC douongPublic)
        {
            return _douongDal.update_douong(douongPublic);
        }

        public int delete_douong(DOUONG_PUBLIC douongPublic)
        {
            return _douongDal.delete_douong(douongPublic);
        }

        public DataTable Foodfind(int iddm)
        {
            return _douongDal.foodfind(iddm);
        }

        public DataTable TIM_DOUONG(DOUONG_PUBLIC douongPublic)
        {
            return _douongDal.TIM_DOUONG(douongPublic);
        }

        public DataTable load_indsdouong()
        {
            return _douongDal.load_indsdouong();
        }

        public DataTable load_douongvoi_where(DOUONG_PUBLIC douongPublic)
        {
            return _douongDal.load_douongvoi_where(douongPublic);
        }
    }
}