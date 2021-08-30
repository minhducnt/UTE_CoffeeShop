using System;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class FMainMenu : Form
    {
        public static FMainMenu Mainmenu;
        private readonly FTableManager _banan = new();
        private readonly FMenu _menu = new();
        private readonly FStaff _nhanvien = new();
        private readonly FStatistic _thongke = new();

        private Form _activeForm;

        private bool _bbanan, _bmenu, _bnhanvien, _bthongke;
        private string _idnv = "", _quyenofnv = "", _tennv = "";

        public FMainMenu()
        {
            InitializeComponent();
            Mainmenu = this;
        }

        #region Method

        private void OpenChildForm(Form childForm)
        {
            _activeForm?.Hide();
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void EnableMnt()
        {
            btStaff.Visible = false;
            btStatistic.Visible = false;
            btMenu.Visible = false;
            btManage.Visible = false;
            btExit.Visible = false;
            lbquyen.Hide();
        }

        internal void EnableQuyen(string quyennv, string tennv, string idnv)
        {
            switch (quyennv)
            {
                case @"ADMIN":
                    btStaff.Visible = true;
                    btStatistic.Visible = true;
                    btMenu.Visible = true;
                    btManage.Visible = true;
                    btExit.Visible = true;
                    lbquyen.Show();
                    lbquyen.Text = @"Admin: " + tennv;
                    _idnv = idnv;
                    _quyenofnv = quyennv;
                    _tennv = tennv;
                    break;
                case @"NHANVIEN":
                    btManage.Visible = true;
                    btExit.Visible = true;
                    lbquyen.Show();
                    lbquyen.Text = @"Nhân viên: " + tennv;
                    _idnv = idnv;
                    _quyenofnv = quyennv;
                    _tennv = tennv;
                    break;
            }
        }

        #endregion

        #region Event

        private void FMainMenu_Load(object sender, EventArgs e)
        {
            EnableMnt();
            var dn = new FLogin();
            dn.FormClosing += dn.FLogin_FormClosing;
            dn.ShowDialog();
        }

        private void FMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btManage_Click(object sender, EventArgs e)
        {
            if (_bnhanvien)
            {
                _bnhanvien = false;
                _nhanvien.Hide();
                _bbanan = true;
                _banan.Idnv = _idnv;
                _banan.Quyen = _quyenofnv;
                OpenChildForm(_banan);
                _banan.FTableManager_Load(sender, e);
            }
            else if (_bmenu)
            {
                _bmenu = false;
                _menu.Hide();
                _bbanan = true;
                _banan.Idnv = _idnv;
                _banan.Quyen = _quyenofnv;
                OpenChildForm(_banan);
                _banan.FTableManager_Load(sender, e);
            }
            else if (_bthongke)
            {
                _bthongke = false;
                _thongke.Hide();
                _bbanan = true;
                _banan.Idnv = _idnv;
                _banan.Quyen = _quyenofnv;
                OpenChildForm(_banan);
                _banan.FTableManager_Load(sender, e);
            }
            else
            {
                _bbanan = true;
                _banan.Idnv = _idnv;
                _banan.Quyen = _quyenofnv;
                OpenChildForm(_banan);
                _banan.FTableManager_Load(sender, e);
            }
        }

        private void btMenu_Click(object sender, EventArgs e)
        {
            if (_bnhanvien)
            {
                _bnhanvien = false;
                _nhanvien.Hide();
                _bmenu = true;
                OpenChildForm(_menu);
            }
            else if (_bbanan)
            {
                _bbanan = false;
                _banan.Hide();
                _bmenu = true;
                OpenChildForm(_menu);
            }
            else if (_bthongke)
            {
                _bthongke = false;
                _thongke.Hide();
                _bmenu = true;
                OpenChildForm(_menu);
            }
            else
            {
                _bmenu = true;
                OpenChildForm(_menu);
            }
        }

        private void btAccount_Click(object sender, EventArgs e)
        {
            var dn = new FAccount {Ten = _tennv, Quyen = _quyenofnv, Idnv = _idnv};
            dn.FormClosing += dn.FAccount_FormClosing;
            dn.ShowDialog();
        }

        private void btStaff_Click(object sender, EventArgs e)
        {
            if (_bmenu)
            {
                _bmenu = false;
                _menu.Hide();
                _bnhanvien = true;
                OpenChildForm(_nhanvien);
            }
            else if (_bbanan)
            {
                _bbanan = false;
                _banan.Hide();
                _bnhanvien = true;
                OpenChildForm(_nhanvien);
            }
            else if (_bthongke)
            {
                _bthongke = false;
                _thongke.Hide();
                _bnhanvien = true;
                OpenChildForm(_nhanvien);
            }
            else
            {
                _bnhanvien = true;
                OpenChildForm(_nhanvien);
            }
        }

        private void btStatistic_Click(object sender, EventArgs e)
        {
            if (_bbanan)
            {
                _bbanan = false;
                _banan.Hide();
                _bthongke = true;
                OpenChildForm(_thongke);
                _thongke.btlammoi_Click(sender, e);
            }
            else if (_bmenu)
            {
                _bmenu = false;
                _menu.Hide();
                _bthongke = true;
                OpenChildForm(_thongke);
                _thongke.btlammoi_Click(sender, e);
            }
            else if (_bnhanvien)
            {
                _bnhanvien = false;
                _nhanvien.Hide();
                _bthongke = true;
                OpenChildForm(_thongke);
                _thongke.btlammoi_Click(sender, e);
            }
            else
            {
                _bthongke = true;
                OpenChildForm(_thongke);
                _thongke.btlammoi_Click(sender, e);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Hide();
            var h = new FMainMenu();
            h.ShowDialog();
            Application.Exit();
        }

        #endregion
    }
}