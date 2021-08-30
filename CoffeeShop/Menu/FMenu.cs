using System;
using System.Windows.Forms;
using BUL;
using Microsoft.Office.Interop.Word;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FMenu : Form
    {
        public static FMenu Formmenu;
        private readonly DmdouongBul _dmdouongBul = new();
        private readonly DouongBul _douongBul = new();
        private bool _nutThem, _nutSua;

        public FMenu()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Formmenu = this;
        }

        #region Method

        private void Xulybuttion(bool b)
        {
            btThem.Enabled = dgvListFood.Enabled = btTim.Enabled = txtTim.Enabled =
                btSua.Enabled = btXoa.Enabled = btnPrintCategory.Enabled = b;
            btLuu.Enabled = btHuy.Enabled = !b;
        }

        private void Tat()
        {
            txtFoodId.Show();
            lbProductId.Show();
            txtName.ReadOnly = true;
            txtPrice.ReadOnly = true;
            cbCategoryName.Enabled = false;
        }

        private void Mo()
        {
            txtFoodId.Hide();
            lbProductId.Hide();
            txtName.ReadOnly = false;
            txtPrice.ReadOnly = false;
            cbCategoryName.Enabled = true;
        }

        private void LoadDataGrid()
        {
            bindingSource1.DataSource = _douongBul.load_douong();
            dgvListFood.DataSource = bindingSource1;
            dgvPrintList.DataSource = _douongBul.load_indsdouong();
        }

        private void EditDataGrid()
        {
            var dataGrid = "###,###,##0";
            dgvListFood.ReadOnly = true;
            dgvListFood.Columns[0].HeaderText = @"Mã sản phẩm";
            dgvListFood.Columns[1].Visible = false;
            dgvListFood.Columns[2].HeaderText = @"Danh mục";
            dgvListFood.Columns[3].HeaderText = @"Tên";
            dgvListFood.Columns[4].HeaderText = @"Đơn giá (VNĐ)";
            dgvListFood.Columns[4].DefaultCellStyle.Format = dataGrid;
        }

        private void EditDataGrid_PrintList()
        {
            var dataGrid = "###,###,##0";
            dgvPrintList.ReadOnly = true;
            dgvPrintList.Columns[0].HeaderText = @"Tên thực đơn";
            dgvPrintList.Columns[1].HeaderText = @"Đơn giá";
            dgvPrintList.Columns[1].DefaultCellStyle.Format = dataGrid;
        }

        private void ExportFileWord(DataGridView dgv, string filename)
        {
            if (dgv.Rows.Count != 0)
            {
                var rowCount = dgv.Rows.Count;
                var columnCount = dgv.Columns.Count;
                var dataArray = new object[rowCount + 1, columnCount + 1];

                var oDoc = new Document();
                oDoc.Application.Visible = true;

                //header text
                oDoc.PageSetup.DifferentFirstPageHeaderFooter = -1;
                oDoc.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Text = @"Menu đồ uống"; 
                oDoc.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                //add rows
                int r;
                for (var c = 0; c <= columnCount - 1; c++)
                for (r = 0; r <= rowCount - 1; r++)
                    dataArray[r, c] = dgv.Rows[r].Cells[c].Value;

                //page orientation
                oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                dynamic oRange = oDoc.Content.Application.Selection.Range;
                var oTemp = "";
                for (r = 0; r <= rowCount - 1; r++)
                for (var c = 0; c <= columnCount - 1; c++)
                    oTemp = oTemp + dataArray[r, c] + "\t";

                //table format
                oRange.Text = oTemp;

                object separator = WdTableFieldSeparator.wdSeparateByTabs;
                object applyBorders = true;
                object autoFit = true;
                object autoFitBehavior = WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref separator, ref rowCount, ref columnCount,
                    Type.Missing, Type.Missing, ref applyBorders,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, ref autoFit, ref autoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = @"Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (var c = 0; c <= columnCount - 1; c++)
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dgv.Columns[c].HeaderText;

                //table style                        
                oDoc.Application.Selection.Tables[1].set_Style("Table Grid 3");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //save the file
                oDoc.SaveAs(filename, WdSaveFormat.wdFormatPDF);
                oDoc.Close(false);
            }
        }

        #endregion

        #region Event

        public void FMenu_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
            EditDataGrid();
            EditDataGrid_PrintList();
            Xulybuttion(true);
            var dt = _dmdouongBul.load_dmdouong();
            cbCategoryId.DataSource = dt;
            cbCategoryId.DisplayMember = @"IDDM";
            cbCategoryName.DataSource = dt;
            cbCategoryName.DisplayMember = @"TENDM";
            Tat();
            txtFoodId.ReadOnly = true;
            cbCategoryId.Hide();
            dgvPrintList.Hide();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Opacity = 0.5;
            var dm = new FCategory();
            dm.FormClosing += dm.FCategory_FormClosing;
            dm.ShowDialog();
        }

        private void Insert()
        {
            var drinkPublic = new DOUONG_PUBLIC
            {
                IDDM = int.Parse(cbCategoryId.Text),
                TENDOUONG = txtName.Text,
                DONGIA = float.Parse(txtPrice.Text)
            };
            _douongBul.insert_douong(drinkPublic);
        }

        private new void Update()
        {
            var drinkPublic = new DOUONG_PUBLIC
            {
                IDDOUONG = int.Parse(txtFoodId.Text),
                IDDM = int.Parse(cbCategoryId.Text),
                TENDOUONG = txtName.Text,
                DONGIA = float.Parse(txtPrice.Text)
            };
            _douongBul.update_douong(drinkPublic);
        }

        private void Delete()
        {
            var drinkPublic = new DOUONG_PUBLIC {IDDOUONG = int.Parse(txtFoodId.Text)};
            _douongBul.delete_douong(drinkPublic);
        }

        private void btnPrintCategory_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog {Filter = @"PDF (*.pdf)|*.pdf"};
            save.FileName = save.FileName;
            if (save.ShowDialog() == DialogResult.OK) ExportFileWord(dgvPrintList, save.FileName);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Mo();
            _nutThem = true;
            Xulybuttion(false);
            txtName.Clear();
            txtPrice.Text = "0";
            cbCategoryName.SelectedIndex = -1;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Mo();
            _nutSua = true;
            Xulybuttion(false);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvListFood.Rows.Count == 1)
            {
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show(@"Muốn xóa một món ăn?", @"Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
                {
                    Delete();
                    LoadDataGrid();
                }
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (_nutThem)
            {
                if (txtName.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa điền tên.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (txtPrice.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa điền đơn giá.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (cbCategoryName.Text == "")
                {
                    MessageBox.Show(@"Chưa chọn danh mục.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    Insert();
                    _nutThem = false;
                    Xulybuttion(true);
                    Tat();
                    LoadDataGrid();
                }
            }
            else if (_nutSua)
            {
                if (txtName.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa điền tên.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (txtPrice.TextLength == 0)
                {
                    MessageBox.Show(@"Chưa điền đơn giá.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (cbCategoryName.Text == "")
                {
                    MessageBox.Show(@"Chưa chọn danh mục.", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    Update();
                    _nutSua = false;
                    Xulybuttion(true);
                    Tat();
                    LoadDataGrid();
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
                LoadDataGrid();
            }
            else if (_nutSua)
            {
                _nutSua = false;
                Xulybuttion(true);
                Tat();
            }
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            if (txtTim.TextLength == 0)
            {
                MessageBox.Show(@"Chưa điền tên cần tìm.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                var drinkPublic = new DOUONG_PUBLIC {TEN = txtTim.Text};
                dgvListFood.DataSource = _douongBul.TIM_DOUONG(drinkPublic);
            }
        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {
            dgvListFood.DataSource = _douongBul.load_douong();
        }

        private void dgvListFood_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dgvListFood_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dong = e.RowIndex;
                txtFoodId.Text = dgvListFood.Rows[dong].Cells[0].Value == null
                    ? string.Empty
                    : dgvListFood.Rows[dong].Cells[0].Value.ToString().Trim();
                cbCategoryId.Text = dgvListFood.Rows[dong].Cells[1].Value == null
                    ? string.Empty
                    : dgvListFood.Rows[dong].Cells[1].Value.ToString().Trim();
                cbCategoryName.Text = dgvListFood.Rows[dong].Cells[2].Value == null
                    ? string.Empty
                    : dgvListFood.Rows[dong].Cells[2].Value.ToString().Trim();
                txtName.Text = dgvListFood.Rows[dong].Cells[3].Value == null
                    ? string.Empty
                    : dgvListFood.Rows[dong].Cells[3].Value.ToString().Trim();
                txtPrice.Text = dgvListFood.Rows[dong].Cells[4].Value == null
                    ? string.Empty
                    : dgvListFood.Rows[dong].Cells[4].Value.ToString().Trim();
            }
            catch
            {
                // ignored
            }
        }

        private void txtdongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && ((TextBox) sender).Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void cbtendm_Click(object sender, EventArgs e)
        {
            if (cbCategoryName.DataSource == null)
                MessageBox.Show(@"Danh mục menu trống.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var a = double.Parse(txtPrice.Text);
                txtPrice.Text = a.ToString("###,###,##0");
            }
            catch
            {
                // ignored
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}