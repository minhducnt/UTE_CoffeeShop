using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using BUL;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FRegister : Form
    {
        private readonly NhanvienBul _nvBul = new();
        private readonly TaikhoanBul _tkBul = new();
        private int _manv;
        private string _quyen = "";

        public FRegister()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        #region Method

        private void Tatlbtrangthai()
        {
            Thread.Sleep(2000);
            lbtrangthai.Text = "";
        }

        private void Insertnhanvien()
        {
            var nvPublic = new NHANVIEN_PUBLIC();
            _manv = _nvBul.count_nhanvien();
            nvPublic.IDNV = "NV" + _manv;
            nvPublic.TENNV = txthovaten.Text;
            nvPublic.NGAYSINH = DateTime.Parse(datengaysinh.Text);
            nvPublic.SDT = txtsdt.Text;
            nvPublic.GIOITINH = cbgioitinh.Text;
            _nvBul.insert_nhanvien(nvPublic);
        }

        private void Inserttaikhoan()
        {
            var tkPublic = new TAIKHOAN_PUBLIC
            {
                TENTK = txttentk.Text,
                MATKHAU = txtmatkhau.Text,
                QUYEN = _quyen,
                IDNV = "NV" + _manv
            };
            _tkBul.insert_taikhoan(tkPublic);
        }

        #endregion

        #region Event

        private void FRegister_Load(object sender, EventArgs e)
        {
            cbgioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btdangky_Click(object sender, EventArgs e)
        {
            if (txttentk.TextLength == 0)
            {
                MessageBox.Show(@"Chưa điền tên tài khoản.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (txttentk.TextLength <= 3)
            {
                MessageBox.Show(@"Tên tài khoản quá ngắn.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (txttentk.TextLength >= 50)
            {
                MessageBox.Show(@"Tên tài khoản quá dài.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (txtmatkhau.TextLength == 0)
            {
                MessageBox.Show(@"Chưa điền mật khẩu.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (txtmatkhau.TextLength <= 6)
            {
                MessageBox.Show(@"Mật khẩu quá ngắn.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (txtmatkhau.TextLength >= 20)
            {
                MessageBox.Show(@"Mật khẩu quá dài.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (txthovaten.TextLength == 0)
            {
                MessageBox.Show(@"Chưa điền họ và tên.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (txthovaten.TextLength >= 100)
            {
                MessageBox.Show(@"Họ và tên quá dài.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (datengaysinh.Value.Year == DateTime.Today.Year)
            {
                MessageBox.Show(@"Chưa chọn ngày sinh.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (txtsdt.TextLength == 0)
            {
                MessageBox.Show(@"Chưa điền số điện thoại.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (txtsdt.TextLength >= 12)
            {
                MessageBox.Show(@"Số điện thoại quá dài.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (cbgioitinh.Text == "")
            {
                MessageBox.Show(@"Chưa chọn giới tính.", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else if (rdadmin.Checked == false && rdnhanvien.Checked == false)
            {
                MessageBox.Show(@"Chưa chọn quyền của tài khoản.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                var t = new Thread(Tatlbtrangthai) {IsBackground = false};
                t.Start();
            }
            else
            {
                try
                {
                    Insertnhanvien();
                    Inserttaikhoan();
                    Close();
                }
                catch (SqlException loi)
                {
                    if (loi.Message.Contains("Violation of PRIMARY KEY constraint 'PK_TENTK'"))
                    {
                        MessageBox.Show(@"Tên tài khoản bị trùng.", @"Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        DeleteNhanVien_Loi();
                    }
                }
            }
        }

        private void DeleteNhanVien_Loi()
        {
            var nhanvienPublic = new NHANVIEN_PUBLIC {IDNV = "NV" + _manv};
            _nvBul.delete_nhanvien(nhanvienPublic);
        }

        private void rdadmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdadmin.Checked) _quyen = @"ADMIN";
        }

        private void rdnhanvien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnhanvien.Checked) _quyen = @"NHANVIEN";
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && ((TextBox) sender).Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}