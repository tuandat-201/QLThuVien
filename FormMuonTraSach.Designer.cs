namespace QLThuVien
{
    partial class FormMuonTraSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpTaoPhieu;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.Label lblDocGia;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.Label lblSach;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.Label lblTongSach;

        // Controls cho tìm kiếm độc giả
        private System.Windows.Forms.TextBox txtTimDocGia;
        private System.Windows.Forms.Button btnXoaTimDocGia;
        private System.Windows.Forms.Label lblKetQuaDocGia;

        // Controls MỚI cho tìm kiếm sách
        private System.Windows.Forms.TextBox txtTimSach;
        private System.Windows.Forms.Button btnXoaTimSach;
        private System.Windows.Forms.Label lblKetQuaSach;

        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.DateTimePicker dtpNgayMuon;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ListBox lstSachMuon;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Button btnTaoPhieu;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvPhieuMuon;
        private System.Windows.Forms.DataGridView dgvChiTiet;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnTaoPhieu = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.lstSachMuon = new System.Windows.Forms.ListBox();
            this.lblTongSach = new System.Windows.Forms.Label();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.grpTaoPhieu = new System.Windows.Forms.GroupBox();
            this.lblDocGia = new System.Windows.Forms.Label();
            this.txtTimDocGia = new System.Windows.Forms.TextBox();
            this.btnXoaTimDocGia = new System.Windows.Forms.Button();
            this.lblKetQuaDocGia = new System.Windows.Forms.Label();
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.lblSach = new System.Windows.Forms.Label();
            this.txtTimSach = new System.Windows.Forms.TextBox();
            this.btnXoaTimSach = new System.Windows.Forms.Button();
            this.lblKetQuaSach = new System.Windows.Forms.Label();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvPhieuMuon = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            this.grpTaoPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1400, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1400, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ MƯỢN TRẢ SÁCH";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeft.Controls.Add(this.btnTaoPhieu);
            this.pnlLeft.Controls.Add(this.grpDanhSach);
            this.pnlLeft.Controls.Add(this.grpTaoPhieu);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 60);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(380, 640);
            this.pnlLeft.TabIndex = 1;
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTaoPhieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoPhieu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTaoPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoPhieu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTaoPhieu.ForeColor = System.Drawing.Color.White;
            this.btnTaoPhieu.Location = new System.Drawing.Point(10, 585);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(360, 45);
            this.btnTaoPhieu.TabIndex = 2;
            this.btnTaoPhieu.Text = "📋 TẠO PHIẾU MƯỢN";
            this.btnTaoPhieu.UseVisualStyleBackColor = false;
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.lstSachMuon);
            this.grpDanhSach.Controls.Add(this.lblTongSach);
            this.grpDanhSach.Controls.Add(this.btnXoaSach);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDanhSach.Location = new System.Drawing.Point(10, 380);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(360, 250);
            this.grpDanhSach.TabIndex = 1;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh Sách Sách Mượn";
            // 
            // lstSachMuon
            // 
            this.lstSachMuon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstSachMuon.FormattingEnabled = true;
            this.lstSachMuon.ItemHeight = 15;
            this.lstSachMuon.Location = new System.Drawing.Point(18, 30);
            this.lstSachMuon.Name = "lstSachMuon";
            this.lstSachMuon.Size = new System.Drawing.Size(325, 109);
            this.lstSachMuon.TabIndex = 0;
            // 
            // lblTongSach
            // 
            this.lblTongSach.AutoSize = true;
            this.lblTongSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTongSach.Location = new System.Drawing.Point(18, 152);
            this.lblTongSach.Name = "lblTongSach";
            this.lblTongSach.Size = new System.Drawing.Size(114, 15);
            this.lblTongSach.TabIndex = 1;
            this.lblTongSach.Text = "Tổng Sách Mượn: 0";
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaSach.ForeColor = System.Drawing.Color.White;
            this.btnXoaSach.Location = new System.Drawing.Point(18, 170);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(325, 30);
            this.btnXoaSach.TabIndex = 2;
            this.btnXoaSach.Text = "🗑 XÓA KHỎI DANH SÁCH";
            this.btnXoaSach.UseVisualStyleBackColor = false;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // grpTaoPhieu
            // 
            this.grpTaoPhieu.Controls.Add(this.lblDocGia);
            this.grpTaoPhieu.Controls.Add(this.txtTimDocGia);
            this.grpTaoPhieu.Controls.Add(this.btnXoaTimDocGia);
            this.grpTaoPhieu.Controls.Add(this.lblKetQuaDocGia);
            this.grpTaoPhieu.Controls.Add(this.cboDocGia);
            this.grpTaoPhieu.Controls.Add(this.lblNgayMuon);
            this.grpTaoPhieu.Controls.Add(this.dtpNgayMuon);
            this.grpTaoPhieu.Controls.Add(this.lblSach);
            this.grpTaoPhieu.Controls.Add(this.txtTimSach);
            this.grpTaoPhieu.Controls.Add(this.btnXoaTimSach);
            this.grpTaoPhieu.Controls.Add(this.lblKetQuaSach);
            this.grpTaoPhieu.Controls.Add(this.cboSach);
            this.grpTaoPhieu.Controls.Add(this.lblSoLuong);
            this.grpTaoPhieu.Controls.Add(this.nudSoLuong);
            this.grpTaoPhieu.Controls.Add(this.btnThemSach);
            this.grpTaoPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTaoPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTaoPhieu.Location = new System.Drawing.Point(10, 10);
            this.grpTaoPhieu.Name = "grpTaoPhieu";
            this.grpTaoPhieu.Size = new System.Drawing.Size(360, 370);
            this.grpTaoPhieu.TabIndex = 0;
            this.grpTaoPhieu.TabStop = false;
            this.grpTaoPhieu.Text = "Tạo Phiếu Mượn Mới";
            // 
            // lblDocGia
            // 
            this.lblDocGia.AutoSize = true;
            this.lblDocGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDocGia.Location = new System.Drawing.Point(15, 30);
            this.lblDocGia.Name = "lblDocGia";
            this.lblDocGia.Size = new System.Drawing.Size(50, 15);
            this.lblDocGia.TabIndex = 0;
            this.lblDocGia.Text = "Độc giả:";
            // 
            // txtTimDocGia
            // 
            this.txtTimDocGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimDocGia.Location = new System.Drawing.Point(18, 48);
            this.txtTimDocGia.Name = "txtTimDocGia";
            this.txtTimDocGia.Size = new System.Drawing.Size(265, 23);
            this.txtTimDocGia.TabIndex = 1;
            this.txtTimDocGia.TextChanged += new System.EventHandler(this.txtTimDocGia_TextChanged);
            this.txtTimDocGia.Enter += new System.EventHandler(this.txtTimDocGia_Enter);
            this.txtTimDocGia.Leave += new System.EventHandler(this.txtTimDocGia_Leave);
            // 
            // btnXoaTimDocGia
            // 
            this.btnXoaTimDocGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnXoaTimDocGia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaTimDocGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTimDocGia.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnXoaTimDocGia.ForeColor = System.Drawing.Color.White;
            this.btnXoaTimDocGia.Location = new System.Drawing.Point(289, 48);
            this.btnXoaTimDocGia.Name = "btnXoaTimDocGia";
            this.btnXoaTimDocGia.Size = new System.Drawing.Size(54, 23);
            this.btnXoaTimDocGia.TabIndex = 2;
            this.btnXoaTimDocGia.Text = "✖ Xóa";
            this.btnXoaTimDocGia.UseVisualStyleBackColor = false;
            this.btnXoaTimDocGia.Click += new System.EventHandler(this.btnXoaTimDocGia_Click);
            // 
            // lblKetQuaDocGia
            // 
            this.lblKetQuaDocGia.AutoSize = true;
            this.lblKetQuaDocGia.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblKetQuaDocGia.ForeColor = System.Drawing.Color.Green;
            this.lblKetQuaDocGia.Location = new System.Drawing.Point(18, 74);
            this.lblKetQuaDocGia.Name = "lblKetQuaDocGia";
            this.lblKetQuaDocGia.Text = "(0 độc giả)";
            this.lblKetQuaDocGia.Size = new System.Drawing.Size(0, 13);
            this.lblKetQuaDocGia.TabIndex = 3;
            // 
            // cboDocGia
            // 
            this.cboDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Location = new System.Drawing.Point(18, 90);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(325, 23);
            this.cboDocGia.TabIndex = 4;
            // 
            // lblNgayMuon
            // 
            this.lblNgayMuon.AutoSize = true;
            this.lblNgayMuon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayMuon.Location = new System.Drawing.Point(15, 122);
            this.lblNgayMuon.Name = "lblNgayMuon";
            this.lblNgayMuon.Size = new System.Drawing.Size(73, 15);
            this.lblNgayMuon.TabIndex = 5;
            this.lblNgayMuon.Text = "Ngày mượn:";
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayMuon.Location = new System.Drawing.Point(18, 140);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(325, 23);
            this.dtpNgayMuon.TabIndex = 6;
            // 
            // lblSach
            // 
            this.lblSach.AutoSize = true;
            this.lblSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSach.Location = new System.Drawing.Point(15, 172);
            this.lblSach.Name = "lblSach";
            this.lblSach.Size = new System.Drawing.Size(35, 15);
            this.lblSach.TabIndex = 7;
            this.lblSach.Text = "Sách:";
            // 
            // txtTimSach
            // 
            this.txtTimSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimSach.Location = new System.Drawing.Point(18, 190);
            this.txtTimSach.Name = "txtTimSach";
            this.txtTimSach.Size = new System.Drawing.Size(265, 23);
            this.txtTimSach.TabIndex = 8;
            this.txtTimSach.TextChanged += new System.EventHandler(this.txtTimSach_TextChanged);
            this.txtTimSach.Enter += new System.EventHandler(this.txtTimSach_Enter);
            this.txtTimSach.Leave += new System.EventHandler(this.txtTimSach_Leave);
            // 
            // btnXoaTimSach
            // 
            this.btnXoaTimSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnXoaTimSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaTimSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTimSach.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnXoaTimSach.ForeColor = System.Drawing.Color.White;
            this.btnXoaTimSach.Location = new System.Drawing.Point(289, 190);
            this.btnXoaTimSach.Name = "btnXoaTimSach";
            this.btnXoaTimSach.Size = new System.Drawing.Size(54, 23);
            this.btnXoaTimSach.TabIndex = 9;
            this.btnXoaTimSach.Text = "✖ Xóa";
            this.btnXoaTimSach.UseVisualStyleBackColor = false;
            this.btnXoaTimSach.Click += new System.EventHandler(this.btnXoaTimSach_Click);
            // 
            // lblKetQuaSach
            // 
            this.lblKetQuaSach.AutoSize = true;
            this.lblKetQuaSach.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblKetQuaSach.ForeColor = System.Drawing.Color.Green;
            this.lblKetQuaSach.Location = new System.Drawing.Point(18, 216);
            this.lblKetQuaSach.Name = "lblKetQuaSach";
            this.lblKetQuaSach.Text = "(0 sách)";
            this.lblKetQuaSach.Size = new System.Drawing.Size(0, 13);
            this.lblKetQuaSach.TabIndex = 10;
            // 
            // cboSach
            // 
            this.cboSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(18, 232);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(325, 23);
            this.cboSach.TabIndex = 11;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuong.Location = new System.Drawing.Point(15, 264);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(57, 15);
            this.lblSoLuong.TabIndex = 12;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudSoLuong.Location = new System.Drawing.Point(18, 282);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(100, 23);
            this.nudSoLuong.TabIndex = 13;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemSach
            // 
            this.btnThemSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThemSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemSach.ForeColor = System.Drawing.Color.White;
            this.btnThemSach.Location = new System.Drawing.Point(135, 282);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(208, 30);
            this.btnThemSach.TabIndex = 14;
            this.btnThemSach.Text = "➕ THÊM VÀO DANH SÁCH";
            this.btnThemSach.UseVisualStyleBackColor = false;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.dgvPhieuMuon);
            this.pnlRight.Controls.Add(this.btnLamMoi);
            this.pnlRight.Controls.Add(this.cboLocTrangThai);
            this.pnlRight.Controls.Add(this.lblLocTrangThai);
            this.pnlRight.Controls.Add(this.btnTimKiem);
            this.pnlRight.Controls.Add(this.txtTimKiem);
            this.pnlRight.Controls.Add(this.lblTimKiem);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRight.Location = new System.Drawing.Point(380, 60);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(1020, 400);
            this.pnlRight.TabIndex = 2;
            // 
            // dgvPhieuMuon
            // 
            this.dgvPhieuMuon.AllowUserToAddRows = false;
            this.dgvPhieuMuon.AllowUserToDeleteRows = false;
            this.dgvPhieuMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuMuon.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuon.Location = new System.Drawing.Point(15, 50);
            this.dgvPhieuMuon.MultiSelect = false;
            this.dgvPhieuMuon.Name = "dgvPhieuMuon";
            this.dgvPhieuMuon.ReadOnly = true;
            this.dgvPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuMuon.Size = new System.Drawing.Size(990, 335);
            this.dgvPhieuMuon.TabIndex = 6;
            this.dgvPhieuMuon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuMuon_CellClick);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(810, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 27);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "🔄 LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Đang mượn",
            "Đã trả"});
            this.cboLocTrangThai.Location = new System.Drawing.Point(646, 14);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(150, 23);
            this.cboLocTrangThai.TabIndex = 4;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocTrangThai.Location = new System.Drawing.Point(575, 17);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(62, 15);
            this.lblLocTrangThai.TabIndex = 3;
            this.lblLocTrangThai.Text = "Trạng thái:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(455, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 27);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "🔍 TÌM";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.Location = new System.Drawing.Point(145, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 23);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiem.Location = new System.Drawing.Point(15, 17);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(113, 15);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm (Tên/SĐT):";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.btnTraSach);
            this.pnlBottom.Controls.Add(this.dgvChiTiet);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(380, 460);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(1020, 240);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnTraSach
            // 
            this.btnTraSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnTraSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTraSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraSach.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTraSach.ForeColor = System.Drawing.Color.White;
            this.btnTraSach.Location = new System.Drawing.Point(10, 185);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(1000, 45);
            this.btnTraSach.TabIndex = 1;
            this.btnTraSach.Text = "📤 TRẢ SÁCH";
            this.btnTraSach.UseVisualStyleBackColor = false;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 10);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1000, 220);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // FormMuonTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Name = "FormMuonTraSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Mượn Trả Sách - Thư Viện";
            this.Load += new System.EventHandler(this.FormMuonTraSach_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            this.grpDanhSach.PerformLayout();
            this.grpTaoPhieu.ResumeLayout(false);
            this.grpTaoPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}