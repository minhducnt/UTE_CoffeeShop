using System.Collections.Generic;
using System.Data;
using DAL;
using PUBLIC;

namespace BUL
{
    public class BanBul
    {
        private readonly BanDal _banDal = new BanDal();

        public DataTable load_ban()
        {
            return _banDal.load_ban();
        }

        public int insert_ban(BAN_PUBLIC banPublic)
        {
            return _banDal.insert_ban(banPublic);
        }

        public int update_ban(BAN_PUBLIC banPublic)
        {
            return _banDal.update_ban(banPublic);
        }

        public int delete_ban(BAN_PUBLIC banPublic)
        {
            return _banDal.delete_ban(banPublic);
        }

        public List<BAN_PUBLIC> Loaddsban()
        {
            return _banDal.Loaddsban();
        }

        public int update_trangthaiban(BAN_PUBLIC banPublic)
        {
            return _banDal.update_trangthaiban(banPublic);
        }

        public DataTable load_ban_trong()
        {
            return _banDal.load_ban_trong();
        }

        public DataTable load_ban_conguoi()
        {
            return _banDal.load_ban_conguoi();
        }
    }
}