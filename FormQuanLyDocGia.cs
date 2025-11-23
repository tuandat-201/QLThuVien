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
    public partial class FormQuanLyDocGia : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        private int selectedDocGiaID = -1;
        public FormQuanLyDocGia()
        {
            InitializeComponent();
        }

        private void FormQuanLyDocGia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Hàm load dữ liệu lên DataGridView
        private void LoadData()
        {
            string query = @"SELECT DocGiaID, HoTen, DienThoai, Email, DiaChi 
                            FROM DocGia 
                            ORDER BY DocGiaID DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDocGia.DataSource = dt;

                    // Ẩn cột ID
                    if (dgvDocGia.Columns["DocGiaID"] != null)
                        dgvDocGia.Columns["DocGiaID"].Visible = false;

                    // Đổi tên hiển thị cột
                    dgvDocGia.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dgvDocGia.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvDocGia.Columns["Email"].HeaderText = "Email";
                    dgvDocGia.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện nút THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên độc giả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            string query = @"INSERT INTO DocGia (HoTen, DienThoai, Email, DiaChi)
                            VALUES (@HoTen, @DienThoai, @Email, @DiaChi)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());

                        // Xử lý điện thoại
                        if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
                            cmd.Parameters.AddWithValue("@DienThoai", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text.Trim());

                        // Xử lý email
                        if (string.IsNullOrWhiteSpace(txtEmail.Text))
                            cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        // Xử lý địa chỉ
                        if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                            cmd.Parameters.AddWithValue("@DiaChi", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm độc giả thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện nút SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedDocGiaID == -1)
            {
                MessageBox.Show("Vui lòng chọn độc giả cần sửa trong danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên độc giả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            string query = @"UPDATE DocGia 
                            SET HoTen = @HoTen, 
                                DienThoai = @DienThoai, 
                                Email = @Email, 
                                DiaChi = @DiaChi
                            WHERE DocGiaID = @DocGiaID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DocGiaID", selectedDocGiaID);
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());

                        if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
                            cmd.Parameters.AddWithValue("@DienThoai", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text.Trim());

                        if (string.IsNullOrWhiteSpace(txtEmail.Text))
                            cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                            cmd.Parameters.AddWithValue("@DiaChi", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật độc giả thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện nút XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedDocGiaID == -1)
            {
                MessageBox.Show("Vui lòng chọn độc giả cần xóa trong danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa độc giả này?\n\nLưu ý: Không thể xóa độc giả đã có lịch sử mượn sách!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM DocGia WHERE DocGiaID = @DocGiaID";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@DocGiaID", selectedDocGiaID);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Xóa độc giả thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadData();
                            ClearInputs();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign Key Violation
                    {
                        MessageBox.Show("Không thể xóa độc giả này vì đã có lịch sử mượn sách!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Sự kiện nút LÀM MỚI
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtTimKiem.Clear();
            LoadData();
        }

        // Sự kiện nút TÌM KIẾM
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            string query = @"SELECT DocGiaID, HoTen, DienThoai, Email, DiaChi 
                            FROM DocGia 
                            WHERE HoTen LIKE @Keyword 
                               OR DienThoai LIKE @Keyword 
                               OR Email LIKE @Keyword 
                               OR DiaChi LIKE @Keyword";

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

                        dgvDocGia.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Tìm thấy {dt.Rows.Count} độc giả!", "Thông báo",
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

        // Sự kiện click vào dòng trong DataGridView
        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];

                    selectedDocGiaID = Convert.ToInt32(row.Cells["DocGiaID"].Value);
                    txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                    txtDienThoai.Text = row.Cells["DienThoai"].Value != DBNull.Value
                        ? row.Cells["DienThoai"].Value.ToString() : "";
                    txtEmail.Text = row.Cells["Email"].Value != DBNull.Value
                        ? row.Cells["Email"].Value.ToString() : "";
                    txtDiaChi.Text = row.Cells["DiaChi"].Value != DBNull.Value
                        ? row.Cells["DiaChi"].Value.ToString() : "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Thêm event double click vào dgvDocGia
        private void dgvDocGia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int docGiaID = Convert.ToInt32(dgvDocGia.Rows[e.RowIndex].Cells["DocGiaID"].Value);
                string hoTen = dgvDocGia.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();

                string query = @"
            SELECT S.TieuDe, MS.NgayMuon, 
                   DATEDIFF(DAY, MS.NgayMuon, GETDATE()) AS SoNgay
            FROM MuonSach MS
            INNER JOIN ChiTietMuon CTM ON MS.MuonID = CTM.MuonID
            INNER JOIN Sach S ON CTM.SachID = S.SachID
            WHERE MS.DocGiaID = @DocGiaID AND MS.NgayTra IS NULL";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@DocGiaID", docGiaID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string message = $"Độc giả: {hoTen}\n\nĐang mượn {dt.Rows.Count} sách:\n\n";
                        foreach (DataRow row in dt.Rows)
                        {
                            message += $"• {row["TieuDe"]} (Mượn {row["SoNgay"]} ngày)\n";
                        }
                        MessageBox.Show(message, "Chi tiết sách đang mượn",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Độc giả {hoTen} không mượn sách nào!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // Hàm xóa trắng các ô nhập liệu
        private void ClearInputs()
        {
            selectedDocGiaID = -1;
            txtHoTen.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtHoTen.Focus();
        }
    }
}
