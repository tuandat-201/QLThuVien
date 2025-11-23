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
    public partial class FormQuanLySach : Form
    {
        // Connection String - Thay YOUR_SERVER bằng tên server của bạn
        private string connectionString = @"Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        private int selectedSachID = -1;
        public FormQuanLySach()
        {
            InitializeComponent();
            LoadData();
        }

        private void FormQuanLySach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Hàm load dữ liệu lên DataGridView
        private void LoadData()
        {
            string query = @"SELECT s.SachID, s.TieuDe, tg.TenTacGia, tl.TenTheLoai, 
                                    s.NamXuatBan, s.SoLuong, s.TacGiaID, s.TheLoaiID
                            FROM Sach s
                            INNER JOIN TacGia tg ON s.TacGiaID = tg.TacGiaID
                            INNER JOIN TheLoai tl ON s.TheLoaiID = tl.TheLoaiID
                            ORDER BY s.SachID DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSach.DataSource = dt;

                    // Ẩn các cột ID
                    if (dgvSach.Columns["SachID"] != null)
                        dgvSach.Columns["SachID"].Visible = false;
                    if (dgvSach.Columns["TacGiaID"] != null)
                        dgvSach.Columns["TacGiaID"].Visible = false;
                    if (dgvSach.Columns["TheLoaiID"] != null)
                        dgvSach.Columns["TheLoaiID"].Visible = false;

                    // Đổi tên hiển thị cột
                    dgvSach.Columns["TieuDe"].HeaderText = "Tiêu Đề";
                    dgvSach.Columns["TenTacGia"].HeaderText = "Tác Giả";
                    dgvSach.Columns["TenTheLoai"].HeaderText = "Thể Loại";
                    dgvSach.Columns["NamXuatBan"].HeaderText = "Năm XB";
                    dgvSach.Columns["SoLuong"].HeaderText = "Số Lượng";
                }

                LoadComboBoxTheLoai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load dữ liệu vào ComboBox Thể Loại
        private void LoadComboBoxTheLoai()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Load Thể loại
                    string queryTheLoai = "SELECT TheLoaiID, TenTheLoai FROM TheLoai";
                    SqlDataAdapter daTheLoai = new SqlDataAdapter(queryTheLoai, conn);
                    DataTable dtTheLoai = new DataTable();
                    daTheLoai.Fill(dtTheLoai);

                    cboTheLoai.DataSource = dtTheLoai;
                    cboTheLoai.DisplayMember = "TenTheLoai";
                    cboTheLoai.ValueMember = "TheLoaiID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thể loại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm lấy hoặc tạo mới TacGiaID
        private int GetOrCreateTacGiaID(string tenTacGia)
        {
            tenTacGia = tenTacGia.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra tác giả đã tồn tại chưa
                    string queryCheck = "SELECT TacGiaID FROM TacGia WHERE TenTacGia = @TenTacGia";
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@TenTacGia", tenTacGia);
                        object result = cmdCheck.ExecuteScalar();

                        if (result != null)
                        {
                            // Tác giả đã tồn tại, trả về ID
                            return Convert.ToInt32(result);
                        }
                    }

                    // Tác giả chưa tồn tại, thêm mới
                    string queryInsert = "INSERT INTO TacGia (TenTacGia) VALUES (@TenTacGia); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmdInsert = new SqlCommand(queryInsert, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@TenTacGia", tenTacGia);
                        int newID = Convert.ToInt32(cmdInsert.ExecuteScalar());
                        return newID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý tác giả: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        // Sự kiện nút THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTieuDe.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTacGia.Focus();
                return;
            }

            // Lấy hoặc tạo mới TacGiaID
            int tacGiaID = GetOrCreateTacGiaID(txtTacGia.Text);
            if (tacGiaID == -1) return;

            string query = @"INSERT INTO Sach (TieuDe, TacGiaID, TheLoaiID, NamXuatBan, SoLuong)
                            VALUES (@TieuDe, @TacGiaID, @TheLoaiID, @NamXuatBan, @SoLuong)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TieuDe", txtTieuDe.Text.Trim());
                        cmd.Parameters.AddWithValue("@TacGiaID", tacGiaID);
                        cmd.Parameters.AddWithValue("@TheLoaiID", cboTheLoai.SelectedValue);

                        // Xử lý năm xuất bản
                        if (string.IsNullOrEmpty(txtNamXuatBan.Text))
                            cmd.Parameters.AddWithValue("@NamXuatBan", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@NamXuatBan", int.Parse(txtNamXuatBan.Text));

                        // Xử lý số lượng
                        if (string.IsNullOrEmpty(txtSoLuong.Text))
                            cmd.Parameters.AddWithValue("@SoLuong", 1);
                        else
                            cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm sách thành công!", "Thông báo",
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
            if (selectedSachID == -1)
            {
                MessageBox.Show("Vui lòng chọn sách cần sửa trong danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTieuDe.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTacGia.Focus();
                return;
            }

            // Lấy hoặc tạo mới TacGiaID
            int tacGiaID = GetOrCreateTacGiaID(txtTacGia.Text);
            if (tacGiaID == -1) return;

            string query = @"UPDATE Sach 
                            SET TieuDe = @TieuDe, 
                                TacGiaID = @TacGiaID, 
                                TheLoaiID = @TheLoaiID, 
                                NamXuatBan = @NamXuatBan, 
                                SoLuong = @SoLuong
                            WHERE SachID = @SachID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SachID", selectedSachID);
                        cmd.Parameters.AddWithValue("@TieuDe", txtTieuDe.Text.Trim());
                        cmd.Parameters.AddWithValue("@TacGiaID", tacGiaID);
                        cmd.Parameters.AddWithValue("@TheLoaiID", cboTheLoai.SelectedValue);

                        if (string.IsNullOrEmpty(txtNamXuatBan.Text))
                            cmd.Parameters.AddWithValue("@NamXuatBan", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@NamXuatBan", int.Parse(txtNamXuatBan.Text));

                        if (string.IsNullOrEmpty(txtSoLuong.Text))
                            cmd.Parameters.AddWithValue("@SoLuong", 1);
                        else
                            cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật sách thành công!", "Thông báo",
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
            if (selectedSachID == -1)
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa trong danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sách này?\n\nLưu ý: Không thể xóa sách đã được mượn!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Sach WHERE SachID = @SachID";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@SachID", selectedSachID);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Xóa sách thành công!", "Thông báo",
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
                        MessageBox.Show("Không thể xóa sách này vì đã có người mượn!",
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

            string query = @"SELECT s.SachID, s.TieuDe, tg.TenTacGia, tl.TenTheLoai, 
                                    s.NamXuatBan, s.SoLuong, s.TacGiaID, s.TheLoaiID
                            FROM Sach s
                            INNER JOIN TacGia tg ON s.TacGiaID = tg.TacGiaID
                            INNER JOIN TheLoai tl ON s.TheLoaiID = tl.TheLoaiID
                            WHERE s.TieuDe LIKE @Keyword 
                               OR tg.TenTacGia LIKE @Keyword 
                               OR tl.TenTheLoai LIKE @Keyword";

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

                        dgvSach.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo",
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
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvSach.Rows[e.RowIndex];

                    selectedSachID = Convert.ToInt32(row.Cells["SachID"].Value);
                    txtTieuDe.Text = row.Cells["TieuDe"].Value.ToString();
                    txtTacGia.Text = row.Cells["TenTacGia"].Value.ToString();
                    cboTheLoai.SelectedValue = row.Cells["TheLoaiID"].Value;
                    txtNamXuatBan.Text = row.Cells["NamXuatBan"].Value != DBNull.Value
                        ? row.Cells["NamXuatBan"].Value.ToString() : "";
                    txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm xóa trắng các ô nhập liệu
        private void ClearInputs()
        {
            selectedSachID = -1;
            txtTieuDe.Clear();
            txtTacGia.Clear();
            txtNamXuatBan.Clear();
            txtSoLuong.Clear();

            if (cboTheLoai.Items.Count > 0)
                cboTheLoai.SelectedIndex = 0;

            txtTieuDe.Focus();
        }

    }
}
