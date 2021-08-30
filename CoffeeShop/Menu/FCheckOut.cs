using System;
using System.Globalization;
using System.Windows.Forms;
using BUL;
using Microsoft.Office.Interop.Word;
using PUBLIC;

namespace CoffeeShop
{
    public partial class FCheckOut : Form
    {
        private readonly BanBul _banBul = new();
        private readonly CthdBul _cthdBul = new();
        private readonly CthdOldBul _cthdOldBul = new();
        private readonly HoadonBul _hdBul = new();
        private readonly HoadonOldBul _hdOldBul = new();
        private int _billId;

        public FCheckOut()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        #region Method

        public int Idban { get; set; }

        public string Tenban { get; set; }

        public string Idnv { get; set; }

        private void EditDataGrid()
        {
            dgvListFood.ReadOnly = true;
            var dinhdangso = "###,###,##0";
            dgvListFood.Columns[0].HeaderText = @"Mã đồ uống";
            dgvListFood.Columns[1].HeaderText = @"Tên món";
            dgvListFood.Columns[2].HeaderText = @"Số lượng";
            dgvListFood.Columns[3].HeaderText = @"Đơn giá (VNĐ)";
            dgvListFood.Columns[3].DefaultCellStyle.Format = dinhdangso;
            dgvListFood.Columns[4].HeaderText = @"Thành tiền (VNĐ)";
            dgvListFood.Columns[4].DefaultCellStyle.Format = dinhdangso;
            dgvListFood.Columns[5].Visible = false;
            dgvListFood.Columns[5].HeaderText = @"Danh mục";
        }

        private void Load_CTHD(int mahoadon)
        {
            var cthdPublic = new CTHD_PUBLIC {IDHOADON = mahoadon};
            bindingSource1.DataSource = _cthdBul.load_cthd_thanhtoan(cthdPublic);
            dgvListFood.DataSource = bindingSource1;
            EditDataGrid();
        }

        private void Tinhtongtien()
        {
            double tongtien = 0;
            for (var i = 0; i < dgvListFood.Rows.Count - 1; ++i)
                tongtien += Convert.ToDouble(dgvListFood.Rows[i].Cells[4].Value.ToString());
            txtTotalPrice.Text = tongtien.ToString("###,###,##0");
        }

        private void txttongtien_TextChanged(object sender, EventArgs e)
        {
        }

        private void ExportFileWord(DataGridView dgv, string filename)
        {
            if (dgv.Rows.Count != 0)
            {
                var rowCount = dgv.Rows.Count;
                var columnCount = dgv.Columns.Count;
                var dataArray = new object[rowCount + 1, columnCount + 1];

                //add rows
                int r;
                for (var c = 0; c <= columnCount - 1; c++)
                for (r = 0; r <= rowCount - 1; r++)
                    dataArray[r, c] = dgv.Rows[r].Cells[c].Value;

                var oDoc = new Document();
                oDoc.Application.Visible = true;

                //page orientation
                oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;

                //header text
                oDoc.PageSetup.DifferentFirstPageHeaderFooter = -1;
                oDoc.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.Text = @"Hóa đơn";
                oDoc.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

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
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (var c = 0; c <= columnCount - 1; c++)
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dgv.Columns[c].HeaderText;

                //table style                        
                oDoc.Application.Selection.Tables[1].set_Style("Table Grid 3");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                foreach (Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    var headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                    headerRange.Text = @"Tổng tiền của " + Tenban;
                    headerRange.Font.Size = 16;
                    headerRange.Font.Bold = 1;
                    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }

                // insert a line text into word
                var p = oDoc.Paragraphs.Add();
                var totalPrice = p.Range;
                totalPrice.Text = @"Tổng tiền: " + txtTotalPrice.Text + " VNĐ";

                // change align of text 
                totalPrice.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                totalPrice.InsertParagraphAfter();

                // insert datetime
                var p1 = oDoc.Paragraphs.Add();
                var timeMade = p1.Range;
                timeMade.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                timeMade.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                timeMade.InsertParagraphAfter();

                //save the file
                oDoc.SaveAs(filename, WdSaveFormat.wdFormatPDF);
                oDoc.Close(false);
            }
        }

        private void PrintBill()
        {
            var save = new SaveFileDialog { Filter = @"PDF (*.pdf)|*.pdf" };
            save.FileName = save.FileName;
            if (save.ShowDialog() == DialogResult.OK) ExportFileWord(dgvListFood, save.FileName);
        }

        #endregion

        #region Event

        private void FCheckOut_Load(object sender, EventArgs e)
        {
            txtTotalPrice.ReadOnly = true;
            lbTitle.Text = @"Hóa đơn " + Tenban;
            var hdPublic = new HOADON_PUBLIC {IDBAN = Idban};
            _billId = _hdBul.load_IDHD_WITH_IDBAN(hdPublic);
            Load_CTHD(_billId);
            Tinhtongtien();
        }

        public void FCheckOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            FTableManager.Table.Load_CTHD(_billId);
            FTableManager.Table.CreateTable();
            FTableManager.Table.dg_monan_ofban.DataSource = 0;
            FTableManager.Table.DSMON.Text = @"Danh sách món ăn của bàn:";
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            var hdOldPublic = new HOADON_OLD_PUBLIC
            {
                IDHOADON = _billId,
                IDBAN = Idban,
                IDNV = Idnv,
                NGAYLAP = DateTime.Now,
                TRANGTHAI = "Rồi",
                TONGTIEN = double.Parse(txtTotalPrice.Text)
            };
            _hdOldBul.insert_hoadon_old(hdOldPublic);
            var cthdOldPublic = new CTHD_OLD_PUBLIC();
            for (var i = 0; i < dgvListFood.Rows.Count - 1; i++)
            {
                cthdOldPublic.IDHOADON_OLD = _billId;
                cthdOldPublic.IDDOUONG = int.Parse(dgvListFood[0, i].Value.ToString());
                cthdOldPublic.SOLUONG = int.Parse(dgvListFood[2, i].Value.ToString());
                _cthdOldBul.insert_cthd_old(cthdOldPublic);
            }

            // delete CTHD 
            var cthdPublic = new CTHD_PUBLIC();
            for (var j = 0; j < dgvListFood.Rows.Count - 1; j++)
            {
                cthdPublic.IDHOADON = _billId;
                cthdPublic.IDDOUONG = int.Parse(dgvListFood[0, j].Value.ToString());
                _cthdBul.delete_cthd(cthdPublic);
            }

            var hdPublic = new HOADON_PUBLIC {IDHOADON = _billId};
            _hdBul.delete_hoadon(hdPublic);

            // update trạng thái bàn
            var banPublic = new BAN_PUBLIC {IDBAN = Idban, TRANGTHAI = @"Trống"};
            _banBul.update_trangthaiban(banPublic);
            PrintBill();
            Close();
        }

        #endregion
    }
}