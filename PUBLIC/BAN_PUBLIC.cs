using System.Data;

namespace PUBLIC
{
    public class BAN_PUBLIC
    {
        public BAN_PUBLIC(int id, string ten, string sst)
        {
            IDBAN = id;
            TEN = ten;
            TRANGTHAI = sst;
        }

        public BAN_PUBLIC(DataRow rows)
        {
            IDBAN = (int) rows["IDBAN"];
            TEN = rows["TEN"].ToString();
            TRANGTHAI = rows["TRANGTHAI"].ToString();
        }

        public BAN_PUBLIC()
        {
        }

        public int IDBAN { get; set; }

        public string TEN { get; set; }

        public string TRANGTHAI { get; set; }

        public int ODER { get; set; }
    }
}