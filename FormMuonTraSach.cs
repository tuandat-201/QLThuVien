using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class FormMuonTraSach : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        private int selectedMuonID = -1;
        private int selectedDocGiaID = -1;
        private List<ChiTietMuonItem> danhSachMuon = new List<ChiTietMuonItem>();

        public FormMuonTraSach()
        {
            InitializeComponent();
        }

        // Class để lưu thông tin sách được chọn
        private class ChiTietMuonItem
        {
            public int SachID { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
        }

        private void FormMuonTraSach_Load(object sender, EventArgs e)
        {
            LoadPhieuMuon();

            // Thêm placeholder cho TextBox tìm kiếm độc giả
            txtTimDocGia.Text = "Nhập tên hoặc SĐT...";
            txtTimDocGia.ForeColor = Color.Gray;

            // Thêm placeholder cho TextBox tìm kiếm sách
            txtTimSach.Text = "Nhập tên sách hoặc tác giả...";
            txtTimSach.ForeColor = Color.Gray;

            // Load sẵn toàn bộ dữ liệu độc giả và sách
            LoadComboBoxDocGia("");
            LoadComboBoxSach("");

            dtpNgayMuon.Value = DateTime.Now;

        }

        // Load danh sách phiếu mượn
        // Load danh sách phiếu mượn
        private void LoadPhieuMuon()
        {
            string query = @"
        SELECT 
            MS.MuonID AS 'MaPhieu',
            DG.HoTen AS 'DocGia',
            DG.DienThoai AS 'SoDienThoai',
            MS.NgayMuon,
            MS.NgayTra,
            CASE 
                WHEN MS.NgayTra IS NULL THEN N'Đang mượn'
                ELSE N'Đã trả'
            END AS 'TrangThai',
            (SELECT COUNT(*) FROM ChiTietMuon WHERE MuonID = MS.MuonID) AS 'SoSach'
        FROM MuonSach MS
        INNER JOIN DocGia DG ON MS.DocGiaID = DG.DocGiaID
        ORDER BY MS.MuonID DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPhieuMuon.DataSource = dt;

                    // Đặt tên hiển thị cho các cột
                    dgvPhieuMuon.Columns["MaPhieu"].HeaderText = "Mã Phiếu";
                    dgvPhieuMuon.Columns["DocGia"].HeaderText = "Độc Giả";
                    dgvPhieuMuon.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                    dgvPhieuMuon.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
                    dgvPhieuMuon.Columns["NgayTra"].HeaderText = "Ngày Trả";
                    dgvPhieuMuon.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    dgvPhieuMuon.Columns["SoSach"].HeaderText = "Số Sách";

                    // Định dạng ngày
                    dgvPhieuMuon.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvPhieuMuon.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    // Căn giữa một số cột
                    dgvPhieuMuon.Columns["MaPhieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPhieuMuon.Columns["SoSach"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPhieuMuon.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Đổi màu theo trạng thái
                    foreach (DataGridViewRow row in dgvPhieuMuon.Rows)
                    {
                        string trangThai = row.Cells["TrangThai"].Value.ToString();
                        if (trangThai == "Đang mượn")
                        {
                            row.Cells["TrangThai"].Style.BackColor = Color.Orange;
                            row.Cells["TrangThai"].Style.ForeColor = Color.White;
                        }
                        else
                        {
                            row.Cells["TrangThai"].Style.BackColor = Color.LightGreen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load phiếu mượn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Load chi tiết sách của phiếu mượn
        private void LoadChiTietMuon(int muonID)
        {
            string query = @"
                SELECT 
                    S.TieuDe AS 'TenSach',
                    TG.TenTacGia AS 'TacGia',
                    CTM.SoLuong,
                    S.SachID
                FROM ChiTietMuon CTM
                INNER JOIN Sach S ON CTM.SachID = S.SachID
                INNER JOIN TacGia TG ON S.TacGiaID = TG.TacGiaID
                WHERE CTM.MuonID = @MuonID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MuonID", muonID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvChiTiet.DataSource = dt;

                        if (dgvChiTiet.Columns["SachID"] != null)
                            dgvChiTiet.Columns["SachID"].Visible = false;

                        dgvChiTiet.Columns["TenSach"].HeaderText = "Tên Sách";
                        dgvChiTiet.Columns["TacGia"].HeaderText = "Tác Giả";
                        dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load chi tiết: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load ComboBox độc giả
        private void LoadComboBoxDocGia(string keyword = "")
        {
            string query = "SELECT DocGiaID, HoTen, DienThoai FROM DocGia ";

            if (!string.IsNullOrEmpty(keyword))
            {
                query += "WHERE HoTen LIKE @Keyword OR DienThoai LIKE @Keyword ";
            }

            query += "ORDER BY HoTen";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(keyword))
                        {
                            cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Thêm cột hiển thị để dễ nhìn
                        dt.Columns.Add("DisplayText", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DisplayText"] = row["HoTen"].ToString() +
                                (row["DienThoai"] != DBNull.Value ? " - " + row["DienThoai"].ToString() : "");
                        }

                        cboDocGia.DataSource = dt;
                        cboDocGia.DisplayMember = "DisplayText";
                        cboDocGia.ValueMember = "DocGiaID";
                        cboDocGia.SelectedIndex = -1;

                        // Hiển thị số kết quả
                        lblKetQuaDocGia.Text = $"({dt.Rows.Count} độc giả)";
                        lblKetQuaDocGia.ForeColor = dt.Rows.Count > 0 ? Color.Green : Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load độc giả: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load ComboBox sách với tìm kiếm
        private void LoadComboBoxSach(string keyword = "")
        {
            string query = @"
                SELECT 
                    S.SachID,
                    S.TieuDe,
                    TG.TenTacGia,
                    S.SoLuong,
                    S.TieuDe + ' (' + TG.TenTacGia + ') - SL: ' + CAST(S.SoLuong AS VARCHAR) AS DisplayText
                FROM Sach S
                INNER JOIN TacGia TG ON S.TacGiaID = TG.TacGiaID
                WHERE S.SoLuong > 0 ";

            if (!string.IsNullOrEmpty(keyword))
            {
                query += "AND (S.TieuDe LIKE @Keyword OR TG.TenTacGia LIKE @Keyword) ";
            }

            query += "ORDER BY S.TieuDe";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(keyword))
                        {
                            cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboSach.DataSource = dt;
                        cboSach.DisplayMember = "DisplayText";
                        cboSach.ValueMember = "SachID";
                        cboSach.SelectedIndex = -1;

                        // Hiển thị số kết quả
                        lblKetQuaSach.Text = $"({dt.Rows.Count} sách)";
                        lblKetQuaSach.ForeColor = dt.Rows.Count > 0 ? Color.Green : Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XỬ LÝ TÌM KIẾM ĐỘC GIẢ
        private void txtTimDocGia_TextChanged(object sender, EventArgs e)
        {
            // Bỏ qua nếu đang là placeholder
            if (txtTimDocGia.ForeColor == Color.Gray)
                return;

            string keyword = txtTimDocGia.Text.Trim();
            LoadComboBoxDocGia(keyword);
        }

        private void txtTimDocGia_Enter(object sender, EventArgs e)
        {
            // Xóa placeholder khi focus vào
            if (txtTimDocGia.ForeColor == Color.Gray)
            {
                txtTimDocGia.Text = "";
                txtTimDocGia.ForeColor = Color.Black;
            }
        }

        private void txtTimDocGia_Leave(object sender, EventArgs e)
        {
            // Thêm lại placeholder nếu rỗng
            if (string.IsNullOrWhiteSpace(txtTimDocGia.Text))
            {
                txtTimDocGia.Text = "Nhập tên hoặc SĐT...";
                txtTimDocGia.ForeColor = Color.Gray;
                LoadComboBoxDocGia(""); // Load lại toàn bộ
            }
        }

        private void btnXoaTimDocGia_Click(object sender, EventArgs e)
        {
            txtTimDocGia.Text = "Nhập tên hoặc SĐT...";
            txtTimDocGia.ForeColor = Color.Gray;
            LoadComboBoxDocGia(""); // Load lại toàn bộ
            cboDocGia.SelectedIndex = -1;
        }

        // XỬ LÝ TÌM KIẾM SÁCH
        private void txtTimSach_TextChanged(object sender, EventArgs e)
        {
            // Bỏ qua nếu đang là placeholder
            if (txtTimSach.ForeColor == Color.Gray)
                return;

            string keyword = txtTimSach.Text.Trim();
            LoadComboBoxSach(keyword);
        }

        private void txtTimSach_Enter(object sender, EventArgs e)
        {
            // Xóa placeholder khi focus vào
            if (txtTimSach.ForeColor == Color.Gray)
            {
                txtTimSach.Text = "";
                txtTimSach.ForeColor = Color.Black;
            }
        }

        private void txtTimSach_Leave(object sender, EventArgs e)
        {
            // Thêm lại placeholder nếu rỗng
            if (string.IsNullOrWhiteSpace(txtTimSach.Text))
            {
                txtTimSach.Text = "Nhập tên sách hoặc tác giả...";
                txtTimSach.ForeColor = Color.Gray;
                LoadComboBoxSach(""); // Load lại toàn bộ
            }
        }

        private void btnXoaTimSach_Click(object sender, EventArgs e)
        {
            txtTimSach.Text = "Nhập tên sách hoặc tác giả...";
            txtTimSach.ForeColor = Color.Gray;
            LoadComboBoxSach(""); // Load lại toàn bộ
            cboSach.SelectedIndex = -1;
        }

        // Thêm sách vào danh sách mượn
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (cboSach.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sachID = Convert.ToInt32(cboSach.SelectedValue);
            int soLuongMuon = (int)nudSoLuong.Value;

            string tenSach = "";
            string tenTacGia = "";

            // Lấy số lượng sách còn lại trong kho
            int soLuongTrongKho = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT S.SoLuong, S.TieuDe, TG.TenTacGia 
                                    FROM Sach S
                                    INNER JOIN TacGia TG ON S.TacGiaID = TG.TacGiaID
                                    WHERE S.SachID = @SachID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SachID", sachID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                soLuongTrongKho = Convert.ToInt32(reader["SoLuong"]);
                                tenSach = reader["TieuDe"].ToString();
                                tenTacGia = reader["TenTacGia"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra số lượng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra số lượng đã thêm trước đó trong danh sách
            int soLuongDaChon = 0;
            var existing = danhSachMuon.FirstOrDefault(x => x.SachID == sachID);
            if (existing != null)
            {
                soLuongDaChon = existing.SoLuong;
            }

            // Kiểm tra tổng số lượng
            int tongSoLuongMuon = soLuongDaChon + soLuongMuon;
            if (tongSoLuongMuon > soLuongTrongKho)
            {
                MessageBox.Show(
                    $"Không đủ sách!\n\n" +
                    $"Số lượng trong kho: {soLuongTrongKho}\n" +
                    $"Đã chọn trước đó: {soLuongDaChon}\n" +
                    $"Đang muốn thêm: {soLuongMuon}\n" +
                    $"Tổng cộng: {tongSoLuongMuon}\n\n" +
                    $"Bạn chỉ có thể mượn thêm tối đa {soLuongTrongKho - soLuongDaChon} quyển.",
                    "Vượt quá số lượng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Thêm hoặc cập nhật số lượng
            if (existing != null)
            {
                existing.SoLuong += soLuongMuon;
            }
            else
            {
                danhSachMuon.Add(new ChiTietMuonItem
                {
                    SachID = sachID,
                    TenSach = $"{tenSach} ({tenTacGia})",
                    SoLuong = soLuongMuon
                });
            }

            HienThiDanhSachMuon();
            cboSach.SelectedIndex = -1;
            nudSoLuong.Value = 1;

            MessageBox.Show($"Đã thêm {soLuongMuon} quyển vào danh sách!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hiển thị danh sách sách sẽ mượn
        private void HienThiDanhSachMuon()
        {
            lstSachMuon.Items.Clear();
            foreach (var item in danhSachMuon)
            {
                lstSachMuon.Items.Add($"{item.TenSach} - SL: {item.SoLuong}");
            }
            lblTongSach.Text = $"Tổng: {danhSachMuon.Count} loại sách";
        }

        // Xóa sách khỏi danh sách mượn
        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (lstSachMuon.SelectedIndex >= 0)
            {
                danhSachMuon.RemoveAt(lstSachMuon.SelectedIndex);
                HienThiDanhSachMuon();
            }
        }

        // Tạo phiếu mượn mới
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (cboDocGia.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn độc giả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (danhSachMuon.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất 1 sách vào danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int docGiaID = Convert.ToInt32(cboDocGia.SelectedValue);
            DateTime ngayMuon = dtpNgayMuon.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Thêm phiếu mượn
                    string queryMuon = @"INSERT INTO MuonSach (DocGiaID, NgayMuon) 
                                        VALUES (@DocGiaID, @NgayMuon);
                                        SELECT SCOPE_IDENTITY();";

                    int muonID;
                    using (SqlCommand cmd = new SqlCommand(queryMuon, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@DocGiaID", docGiaID);
                        cmd.Parameters.AddWithValue("@NgayMuon", ngayMuon);
                        muonID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Thêm chi tiết mượn và cập nhật số lượng sách
                    foreach (var item in danhSachMuon)
                    {
                        // Thêm chi tiết
                        string queryChiTiet = @"INSERT INTO ChiTietMuon (MuonID, SachID, SoLuong)
                                               VALUES (@MuonID, @SachID, @SoLuong)";
                        using (SqlCommand cmd = new SqlCommand(queryChiTiet, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MuonID", muonID);
                            cmd.Parameters.AddWithValue("@SachID", item.SachID);
                            cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            cmd.ExecuteNonQuery();
                        }

                        // Giảm số lượng sách
                        string queryUpdate = @"UPDATE Sach 
                                              SET SoLuong = SoLuong - @SoLuong 
                                              WHERE SachID = @SachID";
                        using (SqlCommand cmd = new SqlCommand(queryUpdate, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@SachID", item.SachID);
                            cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    MessageBox.Show($"Tạo phiếu mượn thành công!\nMã phiếu: {muonID}", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form
                    danhSachMuon.Clear();
                    HienThiDanhSachMuon();
                    cboDocGia.SelectedIndex = -1;
                    txtTimDocGia.Text = "Nhập tên hoặc SĐT...";
                    txtTimDocGia.ForeColor = Color.Gray;
                    txtTimSach.Text = "Nhập tên sách hoặc tác giả...";
                    txtTimSach.ForeColor = Color.Gray;
                    LoadPhieuMuon();
                    LoadComboBoxSach("");
                    LoadComboBoxDocGia("");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi tạo phiếu: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Trả sách
        // Trả sách
        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (selectedMuonID == -1)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần trả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đã trả chưa
            string checkQuery = "SELECT NgayTra FROM MuonSach WHERE MuonID = @MuonID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MuonID", selectedMuonID);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        MessageBox.Show("Phiếu mượn này đã được trả!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            DialogResult dialogResult = MessageBox.Show(
                "Xác nhận trả sách cho phiếu mượn này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Lấy danh sách chi tiết mượn trước khi cập nhật
                        List<Tuple<int, int>> danhSachTraSach = new List<Tuple<int, int>>();
                        string queryLayChiTiet = @"SELECT SachID, SoLuong 
                                          FROM ChiTietMuon 
                                          WHERE MuonID = @MuonID";

                        using (SqlCommand cmd = new SqlCommand(queryLayChiTiet, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MuonID", selectedMuonID);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int sachID = Convert.ToInt32(reader["SachID"]);
                                    int soLuong = Convert.ToInt32(reader["SoLuong"]);
                                    danhSachTraSach.Add(new Tuple<int, int>(sachID, soLuong));
                                }
                            }
                        }

                        // 2. Cập nhật ngày trả
                        string queryTra = @"UPDATE MuonSach 
                                   SET NgayTra = @NgayTra 
                                   WHERE MuonID = @MuonID";
                        using (SqlCommand cmd = new SqlCommand(queryTra, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MuonID", selectedMuonID);
                            cmd.Parameters.AddWithValue("@NgayTra", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Trả lại số lượng sách vào kho (từng sách một)
                        foreach (var item in danhSachTraSach)
                        {
                            string queryTraSach = @"UPDATE Sach 
                                           SET SoLuong = SoLuong + @SoLuongTra
                                           WHERE SachID = @SachID";
                            using (SqlCommand cmd = new SqlCommand(queryTraSach, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@SachID", item.Item1);
                                cmd.Parameters.AddWithValue("@SoLuongTra", item.Item2);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        MessageBox.Show("Trả sách thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadPhieuMuon();
                        LoadComboBoxSach("");
                        dgvChiTiet.DataSource = null;
                        selectedMuonID = -1;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi trả sách: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // Click vào phiếu mượn
        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvPhieuMuon.Rows[e.RowIndex];
                    selectedMuonID = Convert.ToInt32(row.Cells["MaPhieu"].Value);

                    LoadChiTietMuon(selectedMuonID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Tìm kiếm phiếu mượn
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadPhieuMuon();
                return;
            }

            string query = @"
                    SELECT 
                        MS.MuonID AS 'MaPhieu',
                        DG.HoTen AS 'DocGia',
                        DG.DienThoai AS 'SoDienThoai',
                        MS.NgayMuon,
                        MS.NgayTra,
                        CASE 
                            WHEN MS.NgayTra IS NULL THEN N'Đang mượn'
                            ELSE N'Đã trả'
                        END AS 'TrangThai',
                        (SELECT COUNT(*) FROM ChiTietMuon WHERE MuonID = MS.MuonID) AS 'SoSach'
                    FROM MuonSach MS
                    INNER JOIN DocGia DG ON MS.DocGiaID = DG.DocGiaID
                    WHERE DG.HoTen LIKE @Keyword 
                       OR DG.DienThoai LIKE @Keyword
                       OR CAST(MS.MuonID AS VARCHAR) LIKE @Keyword
                    ORDER BY MS.MuonID DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvPhieuMuon.DataSource = dt;

                        // Đặt lại tên hiển thị
                        dgvPhieuMuon.Columns["MaPhieu"].HeaderText = "Mã Phiếu";
                        dgvPhieuMuon.Columns["DocGia"].HeaderText = "Độc Giả";
                        dgvPhieuMuon.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                        dgvPhieuMuon.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
                        dgvPhieuMuon.Columns["NgayTra"].HeaderText = "Ngày Trả";
                        dgvPhieuMuon.Columns["TrangThai"].HeaderText = "Trạng Thái";
                        dgvPhieuMuon.Columns["SoSach"].HeaderText = "Số Sách";

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy kết quả!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lọc theo trạng thái
        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load lại danh sách chi tiết
            dgvChiTiet.DataSource = null;

            string query = @"
            SELECT 
                MS.MuonID AS 'MaPhieu',
                DG.HoTen AS 'DocGia',
                DG.DienThoai AS 'SoDienThoai',
                MS.NgayMuon,
                MS.NgayTra,
                CASE 
                    WHEN MS.NgayTra IS NULL THEN N'Đang mượn'
                    ELSE N'Đã trả'
                END AS 'TrangThai',
                (SELECT COUNT(*) FROM ChiTietMuon WHERE MuonID = MS.MuonID) AS 'SoSach'
            FROM MuonSach MS
            INNER JOIN DocGia DG ON MS.DocGiaID = DG.DocGiaID ";

            if (cboLocTrangThai.SelectedIndex == 1) // Đang mượn
            {
                query += "WHERE MS.NgayTra IS NULL ";
            }
            else if (cboLocTrangThai.SelectedIndex == 2) // Đã trả
            {
                query += "WHERE MS.NgayTra IS NOT NULL ";
            }

            query += "ORDER BY MS.MuonID DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPhieuMuon.DataSource = dt;

                    // Đặt lại tên hiển thị
                    dgvPhieuMuon.Columns["MaPhieu"].HeaderText = "Mã Phiếu";
                    dgvPhieuMuon.Columns["DocGia"].HeaderText = "Độc Giả";
                    dgvPhieuMuon.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                    dgvPhieuMuon.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
                    dgvPhieuMuon.Columns["NgayTra"].HeaderText = "Ngày Trả";
                    dgvPhieuMuon.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    dgvPhieuMuon.Columns["SoSach"].HeaderText = "Số Sách";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadPhieuMuon();
            dgvChiTiet.DataSource = null;
            selectedMuonID = -1;
            txtTimKiem.Clear();
            cboLocTrangThai.SelectedIndex = 0;
        }
    }
}
