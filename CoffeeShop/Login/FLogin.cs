using System;
using System.Threading;
using System.Windows.Forms;
using BUL;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FLogin : Form
    {
        private const int CpNocloseButton = 0x200;
        private readonly TaikhoanBul _accountPul = new();
        private string _quyen = "", _ten = "", _idnv = "";

        public FLogin()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var myCp = base.CreateParams;
                myCp.ClassStyle |= CpNocloseButton;
                return myCp;
            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            AcceptButton = btnLogin;
        }

        public void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            FMainMenu.Mainmenu.EnableQuyen(_quyen, _ten, _idnv);
        }

        private void ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var accountPublic = new TAIKHOAN_PUBLIC {TENTK = txtUsername.Text, MATKHAU = txtPassword.Text};
            var checkPass = _accountPul.check_taikhoan(accountPublic);
            switch (checkPass)
            {
                case 0:
                {
                    MessageBox.Show(@"Sai tên tài khoản hoặc mật khẩu.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    break;
                }
                case 1:
                {
                    var dgvRoleAndName = _accountPul.get_tenvaquyen_taikhoan(accountPublic);
                    _quyen = dgvRoleAndName.Rows[0][0].ToString().Trim();
                    _ten = dgvRoleAndName.Rows[0][1].ToString().Trim();
                    _idnv = dgvRoleAndName.Rows[0][2].ToString().Trim();
                    var t = new Thread(splash);
                    t.Start();
                    Thread.Sleep(5500);
                    t.Abort();
                    Close();
                    break;
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var dk = new FRegister();
            dk.ShowDialog();
        }

        private void splash()
        {
            Application.Run(new FLoading());
        }
    }
}