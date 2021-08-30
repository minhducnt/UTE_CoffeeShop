using System;
using System.Windows.Forms;
using BUL;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FCategory : Form
    {
        private readonly DmdouongBul _dmBul = new();
        private readonly DouongBul _drinkBul = new();
        private bool _nutThem, _nutSua;

        public FCategory()
        {
            InitializeComponent();
        }

        #region Method

        private void Tat()
        {
            txtmadm.ReadOnly = true;
            txttendm.ReadOnly = true;
            lbmadm.Show();
            txtmadm.Show();
        }

        private void Mo()
        {
            txtmadm.ReadOnly = false;
            txttendm.ReadOnly = false;
            lbmadm.Hide();
            txtmadm.Hide();
        }

        private void Xulybuttion(bool b)
        {
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btThoat.Enabled = b;
            btLuu.Enabled = btHuy.Enabled = !b;
        }

        private void Load_TreeView()
        {
            try
            {
                var dt1 = _dmBul.load_dmdouong();

                var category = new TreeNode(@"Danh mục đồ ăn và đồ uống");

                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    category.Nodes.Add(dt1.Rows[i][0].ToString(), dt1.Rows[i][1].ToString());
                    var dt2 = _drinkBul.Foodfind(int.Parse(dt1.Rows[i][0].ToString()));
                    for (var j = 0; j < dt2.Rows.Count; j++)
                        category.Nodes[i].Nodes.Add(dt2.Rows[j][0] + ": " + dt2.Rows[j][1] + " VNĐ");
                }

                TV_DANHMUC.Nodes.Add(category);
                TV_DANHMUC.SelectedNode = TV_DANHMUC.Nodes[0].Nodes[0];
            }
            catch
            {
                // ignored
            }
        }

        private void Insert()
        {
            var categoryPublic = new DMDOUONG_PUBLIC {TENDM = txttendm.Text};
            _dmBul.insert_dmdouong(categoryPublic);
        }

        private new void Update()
        {
            var categoryPublic = new DMDOUONG_PUBLIC {TENDM = txttendm.Text, IDDM = int.Parse(txtmadm.Text)};
            _dmBul.update_dmdouong(categoryPublic);
        }

        private void Delete()
        {
            var categoryPublic = new DMDOUONG_PUBLIC {IDDM = int.Parse(txtmadm.Text)};
            _dmBul.delete_dmdouong(categoryPublic);
        }

        #endregion

        #region Event

        private void FCategory_Load(object sender, EventArgs e)
        {
            Tat();
            Load_TreeView();
            Xulybuttion(true);
        }

        public void FCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            FMenu.Formmenu.Opacity = 1;
            FMenu.Formmenu.FMenu_Load(sender, e);
        }

        private void TV_DANHMUC_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = TV_DANHMUC.SelectedNode;
            txtmadm.Text = node.Name;
            txttendm.Text = node.Text;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            _nutThem = true;
            txttendm.Text = "";
            Xulybuttion(false);
            Mo();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            _nutSua = true;
            Xulybuttion(false);
            Mo();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(@"Muốn xóa một danh mục?", @"Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question))
            {
                if (txtmadm.TextLength == 0)
                {
                    MessageBox.Show(@"Nhấn vào tên danh mục để xóa.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    Delete();
                    TV_DANHMUC.Nodes.Clear();
                    Load_TreeView();
                }
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (_nutThem)
            {
                if (txttendm.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa điền tên danh mục.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    Insert();
                    TV_DANHMUC.Nodes.Clear();
                    Load_TreeView();
                    _nutThem = false;
                    Xulybuttion(true);
                    Tat();
                }
            }
            else if (_nutSua)
            {
                if (txttendm.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa điền tên danh mục.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (txtmadm.TextLength == 0)
                {
                    MessageBox.Show(@"Nhấn vào tên danh mục để thay đổi.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    Update();
                    TV_DANHMUC.Nodes.Clear();
                    Load_TreeView();
                    _nutSua = false;
                    Xulybuttion(true);
                    Tat();
                }
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            if (_nutThem)
            {
                _nutThem = false;
                Xulybuttion(true);
                Tat();
                TV_DANHMUC.Nodes.Clear();
                Load_TreeView();
            }
            else if (_nutSua)
            {
                _nutSua = false;
                Xulybuttion(true);
                Tat();
                TV_DANHMUC.Nodes.Clear();
                Load_TreeView();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}