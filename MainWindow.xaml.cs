using Bai1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bai1.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Bai1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        QuanLyBenhNhanDBContext db = new QuanLyBenhNhanDBContext();
        private void View()
        {
            var benhnhanList = db.BenhNhans.Include(bn => bn.MaKhoaNavigation).OrderByDescending(bn => bn.SoNgayNamVien).ToList();
            foreach (var item in benhnhanList)
                item.VienPhi = item.SoNgayNamVien * 200000;
            dgvQLBenhNhan.ItemsSource= benhnhanList.Select(bn => new
            {
                MaBn=bn.MaBn,
                HoTen=bn.HoTen,
                SoNgayNamVien= bn.SoNgayNamVien,
                TenKhoa=bn.MaKhoaNavigation.TenKhoa,
                VienPhi = string.Format("{0:#,##0}", bn.VienPhi)

            }).ToList();
        }
        private void load_ComboBox()
        {
            var khoaList = db.Khoas.ToList();
            txtKhoa.ItemsSource = khoaList;
        }
        private void Windown_Load(object sender, RoutedEventArgs e)
        {
            View();
            load_ComboBox();
        }
        private bool IsCheck()
        {
            if (txtMBN.Text == "")
            {
                MessageBox.Show("Chưa nhập mã bệnh nhân","Valid Data",MessageBoxButton.OK, MessageBoxImage.Error);
                txtMBN.Focus();
                return false;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa nhập tên bệnh nhân", "Valid Data", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMBN.Focus();
                return false;
            }
            if (txtNgay.Text == "")
            {
                MessageBox.Show("Chưa nhập số ngày nằm viện", "Valid Data", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMBN.Focus();
                return false;
            }
            int mBN;
            if (!int.TryParse(txtMBN.Text, out mBN))
            {
                // Chuỗi không phải là một số hợp lệ
                MessageBox.Show("Mã bệnh nhân kiểu số nguyên", "Valid data", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMBN.Focus();
                return false;
            }
            else
            {
                foreach (var item in db.BenhNhans)
                {
                    if (mBN == item.MaBn)
                    {
                        MessageBox.Show("Mã bệnh nhân bị trùng", "Valid data", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtMBN.Focus();
                        return false;
                    }
                }
            }
            if (!Regex.IsMatch(txtNgay.Text, @"\d+"))
            {
                MessageBox.Show("Số ngày kiểu số nguyên", "Valid data", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMBN.Focus();
                return false;
            }
            else
            {
                int sNgay=int.Parse(txtNgay.Text);
                if (sNgay < 1)
                {
                    MessageBox.Show("Số ngày nằm viện phải lớn hơn 1", "Valid data", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtNgay.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (IsCheck() == true)
            {
                BenhNhan bn = new BenhNhan();
                bn.MaBn = int.Parse(txtMBN.Text);
                bn.HoTen = txtHoTen.Text;
                bn.SoNgayNamVien = int.Parse(txtNgay.Text);
                Khoa khoa = (Khoa)txtKhoa.SelectedItem;
                bn.MaKhoa = khoa.MaKhoa;
                db.BenhNhans.Add(bn);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                View();
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var query = from bn in db.BenhNhans where bn.MaKhoa == 1 select bn;
            Window2 check = new Window2();
            check.dgvtim.ItemsSource= query.Select(query =>new {
                MaBn = query.MaBn,
                HoTen = query.HoTen,
                SoNgayNamVien = query.SoNgayNamVien,
                TenKhoa = query.MaKhoaNavigation.TenKhoa,
                VienPhi = string.Format("{0:#,##0}", query.VienPhi)
            }).ToList();
            check.Show();
        }

        private void dgvQLBenhNhan_cellchange(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dgvQLBenhNhan.SelectedItem != null)
            {
                try
                {
                    Type t = dgvQLBenhNhan.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtMBN.Text = p[0].GetValue(dgvQLBenhNhan.SelectedValue).ToString();
                    txtHoTen.Text = p[1].GetValue(dgvQLBenhNhan.SelectedValue).ToString();
                    txtKhoa.Text = p[3].GetValue(dgvQLBenhNhan.SelectedValue).ToString();
                    txtNgay.Text = p[2].GetValue(dgvQLBenhNhan.SelectedValue).ToString();
                }catch(Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn" +ex.Message);
                }
            }
        }
    }
}
