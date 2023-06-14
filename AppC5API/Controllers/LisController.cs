using BanGiayTheThao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppC5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LisController : ControllerBase
    {
        public GiayDBcontext dbcontext;

        public LisController()
        {
            dbcontext = new GiayDBcontext();
        }

        // GET: api/<LisController>
        [HttpGet("get-all-CTGT")]
        public List<GioHangChiTiet> GetAllChiTietGioHang()
        {
            return dbcontext.GioHangChiTiets.Include(c => c.PhanLoaiSp).Include(c => c.GioHang)
                .Include(c => c.PhanLoaiSp.SanPham).Include(c => c.PhanLoaiSp.SanPham.Anhs)
                .Include(c => c.PhanLoaiSp.Mau).Include(c => c.PhanLoaiSp.Nsx).Include(c => c.PhanLoaiSp.Size)
                .Include(c => c.PhanLoaiSp).ToList();
        }

        // GET: api/<LisController>
        [HttpGet("get-all-HD")]
        public List<HoaDon> GetAllhoaDons()
        {
            return dbcontext.HoaDons.ToList();
        }

        [HttpGet("get-all-CTHD22")]
        public List<HoaDonChiTiet> GetAllChiTietHoaDon22(Guid id)
        {
            return dbcontext.HoaDonChiTiets.ToList().Where(c=>c.IDhoaDon==id).ToList();
        }
        // GET: api/<LisController>
        [HttpGet("get-all-CTHD")]
        public List<HoaDonChiTiet> GetAllChiTietHoaDon()
        {
            return dbcontext.HoaDonChiTiets.Include(c => c.PhanLoaiSp).Include(c => c.HoaDon)
                .Include(c => c.PhanLoaiSp.SanPham).Include(c => c.PhanLoaiSp.SanPham.Anhs)
                .Include(c => c.PhanLoaiSp.Mau).Include(c => c.PhanLoaiSp.Nsx).Include(c => c.PhanLoaiSp.Size)
                .Include(c => c.PhanLoaiSp).ToList();
        }
        [HttpPost("create-hoadon")]
        public bool CreateHoadon(HoaDon p)
        {
            try
            {
                dbcontext.HoaDons.Add(p);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("create-HDchitiet")]
        public bool CreateHoadonChiTiet(HoaDonChiTiet p)
        {
            try
            {
                dbcontext.HoaDonChiTiets.Add(p);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("update-phanloaisp")]
        public bool UpdatePlsanpham(PhanLoaiSP p)
        {
            try
            {
                dbcontext.PhanLoaiSps.Update(p);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpDelete("delete-GioHang")]
        public bool DeleteCTgiohang(Guid id)
        {
            try
            {
                var a = dbcontext.GioHangChiTiets.ToList().FirstOrDefault(c => c.IdGioHangCT == id);
                dbcontext.GioHangChiTiets.Remove(a);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("create-sauthanhtoan")]
        public bool sauThanhToan()
        {
            var a1 = new List<PhanLoaiSP>();
            //Kiểm tra số lượng sản phẩm trong giỏ hàng với số lượng sản phẩm còn lại
            foreach (var CT in GetAllChiTietGioHang())
            {
                var sp = dbcontext.PhanLoaiSps.ToList().FirstOrDefault(c => c.IdPhanLoaiSP == CT.IdPhanLoaiSP);
                if (sp.Soluong < CT.SoLuong)
                {
                    a1.Add(sp);
                }
            }

            if (a1.Count > 0)
            {
                // Trả về thông báo lỗi nếu có sản phẩm không đủ số lượng để thanh toán
                var message = "không đử số lượng để thanh toán ";
                foreach (var item in a1)
                {
                    message += item.SanPham.TenSanPham + item.Nsx.TenNSX + ", ";
                }

                message = message.Substring(0, message.Length - 2);
                return false;
            }
            else
            {
                Guid ida = Guid.NewGuid();
                //Tạo hóa đơn mới
                int tong = 0;
                foreach (var inso in GetAllChiTietGioHang())
                {
                    tong += Int32.Parse(inso.SoLuong.ToString()) *
                            Int32.Parse(inso.PhanLoaiSp.SanPham.GiaBan.ToString());
                }

                var hd = new HoaDon()
                {
                    IdHoaDon = ida,
                    NgayTao = DateTime.Now,
                    NgayDat = DateTime.Now,
                    NgayGiao = DateTime.Now,
                    DiaChi = "",
                    TongTien = tong,
                    TrangThai = 1,
                    IDNguoiDung = Guid.Parse("3012ac7b-c1de-4381-9813-ef76609f9f3c"),
                    IDGiamGia = Guid.Parse("6ca7d844-eb1d-404f-bd6c-ff59d69de5a5"),
                };
                if (CreateHoadon(hd) == false)
                    return false;

                //Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                foreach (var ct in GetAllChiTietGioHang())
                {
                    var cthd = new HoaDonChiTiet()
                    {
                        IDhoaDon = ida, //Id của hóa đơn vừa tạo
                        IdPhanLoaiSP = ct.IdPhanLoaiSP,
                        GiaTien = Int32.Parse(ct.PhanLoaiSp.SanPham.GiaBan.ToString()),
                        SoLuong = int.Parse(ct.SoLuong.ToString()),
                    };
                    if (CreateHoadonChiTiet(cthd) == false)
                        return false;
                    //Trừ số lượng sản phẩm trong CSDL
                    var product = dbcontext.PhanLoaiSps.ToList()
                        .FirstOrDefault(c => c.IdPhanLoaiSP == cthd.IdPhanLoaiSP);
                    product.Soluong -= ct.SoLuong;
                    UpdatePlsanpham(product);
                    if ((DeleteCTgiohang(ct.IdGioHangCT) == false))
                        return false;
                }

                return true;
            }

        }
    }
}
