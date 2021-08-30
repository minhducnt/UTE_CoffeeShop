using System;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class FAccount : Form
    {
        public FAccount()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        #region Method

        public string Idnv { get; set; }

        public string Ten { get; set; }

        public string Quyen { get; set; }

        #endregion

        #region Event

        private void FAccount_Load(object sender, EventArgs e)
        {
            lbName.Text = Ten;
            lbRole.Text = Quyen;
            lbId.Text = Idnv;
        }

        public void FAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            FMainMenu.Mainmenu.EnableQuyen(Quyen, Ten, Idnv);
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}