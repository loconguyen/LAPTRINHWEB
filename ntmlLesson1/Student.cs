using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ntmlLesson1
{
    class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string NganhHoc { get; set; }
        public double DiemTB { get; set; }
        public string TrangThai { get; set; }
        public SinhVien() { }
        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string email, string sdt, string nganhHoc, double diemTB, string trangThai)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Email = email;
            SDT = sdt;
            NganhHoc = nganhHoc;
            DiemTB = diemTB;
            TrangThai = trangThai;
        }
        public void xuatThongTin()
        {
            Console.WriteLine($"Mã SV: {MaSV}");
            Console.WriteLine($"Họ tên: {HoTen}");
            Console.WriteLine($"Ngày sinh: {NgaySinh.ToShortDateString()}");
            Console.WriteLine($"Giới tính: {GioiTinh}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"SĐT: {SDT}");
            Console.WriteLine($"Ngành học: {NganhHoc}");
            Console.WriteLine($"Điểm TB: {DiemTB}");
            Console.WriteLine($"Trạng thái: {TrangThai}");
        }
    }
    class Program
    {
        static List<SinhVien> dsSV = new List<SinhVien>();
        static void Main(string[] args)
        {
            SinhVien sv1 = new SinhVien("SV001", "Nguyen Van A", new DateTime(2000, 1, 1), "Nam", "nguyenvana@email.com", "0123456789", "CNTT", 8.5, "Đang học");
            dsSV.Add(sv1);
            sv1.xuatThongTin();

            int chon = -1;
            do
            {
                Console.WriteLine("Quan Ly Sinh vien");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xuat danh sach sinh vien");
                Console.WriteLine("3. Tim sinh vien theo ma");
                Console.WriteLine("4.Tim gan dung theo ho ten");
                Console.WriteLine("5. cap nhap sinh vien");
                Console.WriteLine("6. xoa sinh vien");
                Console.WriteLine("7.sap xep theo ho ten");
                Console.WriteLine("8. Sắp xếp theo điểm trung bình");
                Console.WriteLine("9. Hiển thị sinh viên điểm >= 8");
                Console.WriteLine("10. Hiển thị sinh viên điểm cao nhất");
                Console.WriteLine("11. Tính điểm trung bình toàn bộ SV");
                Console.WriteLine("12. Thống kê theo ngành");
                Console.WriteLine("13. Thống kê theo trạng thái");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("=======================================");
                Console.Write("Chọn chức năng (0-13): ");
                while (!int.TryParse(Console.ReadLine(), out chon) || chon < 0 || chon > 13)
                {
                    Console.WriteLine("Chức năng không hợp lệ. Vui lòng chọn lại.");
                    Console.Write("Chọn chức năng (0-13): ");
                }


                switch (chon)
                {
                    case 1:
                        ThemSinhVien();
                        break;
                    case 2:
                        XuatDanhSachSinhVien();
                        break;
                    case 3:
                        TimSinhVienTheoMa();
                        break;
                    case 4:
                        TimGanDungTheoHoTen();
                        break;
                    case 5:
                        CapNhatSinhVien();
                        break;
                    case 6:
                        XoaSinhVien();
                        break;
                    case 7:
                        SapXepTheoHoTen();
                        break;
                    case 8:
                        SapXepTheoDiemTB();
                        break;
                    case 9:
                        HienThiSinhVienDiemCaoHon8();
                        break;
                    case 10:
                        HienThiSinhVienDiemCaoNhat();
                        break;
                    case 11:
                        TinhDiemTrungBinhToanBoSV();
                        break;
                    case 12:
                        ThongKeTheoNganh();
                        break;
                    case 13:
                        ThongKeTheoTrangThai();
                        break;
                    case 0:
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            } while (chon != 0);
        }
            static SinhVien TimSVtheoMa(string maSV)
            {
                foreach (SinhVien sv in dsSV)
                {
                    if (sv.MaSV == maSV)
                    {
                        return sv;
                    }
                }
                return null;
            }
            // kiem tra ma trung
            static bool KiemTraMaTrung(string ma)
            {
                foreach (SinhVien sv in dsSV)
                {
                    if (sv.MaSV == ma)
                    {
                        return true;
                    }
                }
                return false;
            }
            static void ThemSinhVien()
            {
                SinhVien sv = new SinhVien();
                while (true)
                {
                    Console.WriteLine("Nhập thông tin sinh viên:");
                    Console.Write("Ma sinh vien :");
                    sv.MaSV = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sv.MaSV))
                    {
                        Console.WriteLine("Mã sinh viên không được để trống. Vui lòng nhập lại.");
                        continue;
                    }
                    else if (KiemTraMaTrung(sv.MaSV))
                    {
                        Console.WriteLine("Mã sinh viên đã tồn tại. Vui lòng nhập lại.");
                        continue;

                    }
                    else
                    {
                        break;

                    }
                }
                while (true)
                {
                    Console.Write("Ho ten:");
                    sv.HoTen = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sv.HoTen))
                    {
                        Console.WriteLine("Họ tên không được để trống. Vui lòng nhập lại.");
                        continue;
                    }
                    else
                    {
                        break;
                    }


                }
                Console.Write("ngay sinh ");
                sv.NgaySinh = DateTime.Parse(Console.ReadLine());
                Console.Write("gioi tinh :");
                sv.GioiTinh = Console.ReadLine();
                while (true)
                {
                    Console.Write("Email :");
                    sv.Email = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sv.Email))
                    {
                        Console.WriteLine("Email không được để trống. Vui lòng nhập lại.");
                        continue;
                    }
                    else if (!Regex.IsMatch(sv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    {
                        Console.WriteLine("Email không hợp lệ. Vui lòng nhập lại.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Write("so dien thoai :");
                sv.SDT = Console.ReadLine();
                Console.Write("nganh hoc :");
                sv.NganhHoc = Console.ReadLine();
                while (true)
                {
                    Console.Write("diem trung binh:");
                    if (!double.TryParse(Console.ReadLine(), out double diemTB))
                    {
                        Console.WriteLine("Điểm trung bình không hợp lệ. Vui lòng nhập lại.");
                        continue;
                    }
                    else if (diemTB < 0 || diemTB > 10)
                    {
                        Console.WriteLine("Điểm trung bình phải từ 0 đến 10. Vui lòng nhập lại.");
                        continue;
                    }
                    else
                    {
                        sv.DiemTB = diemTB;
                        break;
                    }
                }
                Console.Write("trang thai:");
                sv.TrangThai = Console.ReadLine();
                dsSV.Add(sv);
                Console.WriteLine("Thêm sinh viên thành công.");
            }

            // 2 hien thi danh sach
            static void XuatDanhSachSinhVien()
            {
                Console.WriteLine("Danh sách sinh viên:");
                foreach (SinhVien sv in dsSV)
                {
                    sv.xuatThongTin();
                    Console.WriteLine("--------------------");
                }
            }
            //3 tim sinh vien theo ma
            static void TimSinhVienTheoMa()
            {
                Console.Write("Nhập mã sinh viên cần tìm: ");
                string maSV = Console.ReadLine();
                SinhVien sv = TimSVtheoMa(maSV);
                if (sv != null)
                {
                    Console.WriteLine("Thông tin sinh viên:");
                    sv.xuatThongTin();
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sinh viên với mã đã nhập.");
                }
            }
            //4
            static void TimGanDungTheoHoTen()
            {
                Console.Write("Nhập họ tên sinh viên cần tìm: ");
                string hoTen = Console.ReadLine();
                List<SinhVien> dsKetQua = new List<SinhVien>();
                foreach (SinhVien sv in dsSV)
                {
                    if (sv.HoTen.Contains(hoTen, StringComparison.OrdinalIgnoreCase))
                    {
                        dsKetQua.Add(sv);
                    }
                }
                if (dsKetQua.Count > 0)
                {
                    Console.WriteLine("Kết quả tìm kiếm:");
                    foreach (SinhVien sv in dsKetQua)
                    {
                        sv.xuatThongTin();
                        Console.WriteLine("--------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sinh viên với họ tên đã nhập.");
                }
            }
            //5 
            static void CapNhatSinhVien()
            {
                Console.Write("Nhập mã sinh viên cần cập nhật: ");
                string maSV = Console.ReadLine();
                SinhVien sv = TimSVtheoMa(maSV);
                if (sv != null)
                {
                    Console.WriteLine("Nhập thông tin mới cho sinh viên:");
                    Console.Write("Họ tên: ");
                    sv.HoTen = Console.ReadLine();
                    Console.Write("Ngày sinh (dd/MM/yyyy): ");
                    sv.NgaySinh = DateTime.Parse(Console.ReadLine());
                    Console.Write("Giới tính: ");
                    sv.GioiTinh = Console.ReadLine();
                    Console.Write("Email: ");
                    sv.Email = Console.ReadLine();
                    Console.Write("SĐT: ");
                    sv.SDT = Console.ReadLine();
                    Console.Write("Ngành học: ");
                    sv.NganhHoc = Console.ReadLine();
                    Console.Write("Điểm TB: ");
                    sv.DiemTB = double.Parse(Console.ReadLine());
                    Console.Write("Trạng thái: ");
                    sv.TrangThai = Console.ReadLine();
                    Console.WriteLine("Cập nhật thông tin sinh viên thành công.");
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sinh viên với mã đã nhập.");
                }
            }
            //6
            static void XoaSinhVien()
            {
                Console.Write("Nhập mã sinh viên cần xóa: ");
                string maSV = Console.ReadLine();
                SinhVien sv = TimSVtheoMa(maSV);
                if (sv != null)
                {
                    dsSV.Remove(sv);
                    Console.WriteLine("Xóa sinh viên thành công.");
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sinh viên với mã đã nhập.");
                }
            }
            //7
            static void SapXepTheoHoTen()
            {
                dsSV.Sort((sv1, sv2) => string.Compare(sv1.HoTen, sv2.HoTen, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Danh sách sinh viên đã được sắp xếp theo họ tên.");
            }
            //8
            static void SapXepTheoDiemTB()
            {
                dsSV.Sort((sv1, sv2) => sv2.DiemTB.CompareTo(sv1.DiemTB));
                Console.WriteLine("Danh sách sinh viên đã được sắp xếp theo điểm trung bình.");
            }
            //9
            static void HienThiSinhVienDiemCaoHon8()
            {
                Console.WriteLine("Danh sách sinh viên có điểm trung bình >= 8:");
                foreach (SinhVien sv in dsSV)
                {
                    if (sv.DiemTB >= 8)
                    {
                        sv.xuatThongTin();
                        Console.WriteLine("--------------------");
                    }
                }
            }
            //10
            static void HienThiSinhVienDiemCaoNhat()
            {
                if (dsSV.Count == 0)
                {
                    Console.WriteLine("Danh sách sinh viên trống.");
                    return;
                }
                double diemCaoNhat = dsSV.Max(sv => sv.DiemTB);
                Console.WriteLine($"Danh sách sinh viên có điểm trung bình cao nhất ({diemCaoNhat}):");
                foreach (SinhVien sv in dsSV)
                {
                    if (sv.DiemTB == diemCaoNhat)
                    {
                        sv.xuatThongTin();
                        Console.WriteLine("--------------------");
                    }
                }
            }
            //11
            static void TinhDiemTrungBinhToanBoSV()
            {
                if (dsSV.Count == 0)
                {
                    Console.WriteLine("Danh sách sinh viên trống.");
                    return;
                }
                double diemTrungBinh = dsSV.Average(sv => sv.DiemTB);
                Console.WriteLine($"Điểm trung bình toàn bộ sinh viên: {diemTrungBinh}");
            }
            //12
            static void ThongKeTheoNganh()
            {
                var thongKe = dsSV.GroupBy(sv => sv.NganhHoc)
                                  .Select(g => new { NganhHoc = g.Key, SoLuong = g.Count() });
                Console.WriteLine("Thống kê số lượng sinh viên theo ngành học:");
                foreach (var item in thongKe)
                {
                    Console.WriteLine($"Ngành học: {item.NganhHoc}, Số lượng: {item.SoLuong}");
                }
            }
            //13
            static void ThongKeTheoTrangThai()
            {
                var thongKe = dsSV.GroupBy(sv => sv.TrangThai)
                                  .Select(g => new { TrangThai = g.Key, SoLuong = g.Count() });
                Console.WriteLine("Thống kê số lượng sinh viên theo trạng thái:");
                foreach (var item in thongKe)
                {
                    Console.WriteLine($"Trạng thái: {item.TrangThai}, Số lượng: {item.SoLuong}");
                }
            }


        }
    }

