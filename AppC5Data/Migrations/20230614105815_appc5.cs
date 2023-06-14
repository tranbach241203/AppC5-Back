using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppC5Data.Migrations
{
    public partial class appc5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatLieus",
                columns: table => new
                {
                    IdChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaChatLieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenChatLieu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieus", x => x.IdChatLieu);
                });

            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    IdChucVu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenCV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.IdChucVu);
                });

            migrationBuilder.CreateTable(
                name: "GiamGias",
                columns: table => new
                {
                    IdGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaGiamGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTienDaGiam = table.Column<double>(type: "float", nullable: true),
                    TenGiamGia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGias", x => x.IdGiamGia);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    IdKhuyenMai = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoTienGiam = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.IdKhuyenMai);
                });

            migrationBuilder.CreateTable(
                name: "Maus",
                columns: table => new
                {
                    IdMau = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaMau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenMau = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maus", x => x.IdMau);
                });

            migrationBuilder.CreateTable(
                name: "NSXs",
                columns: table => new
                {
                    IdNSX = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNSX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNSX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NSXs", x => x.IdNSX);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaBan = table.Column<double>(type: "float", nullable: true),
                    GiaNhap = table.Column<double>(type: "float", nullable: true),
                    ChieuCaoDeGiay = table.Column<double>(type: "float", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaidien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.IdSanPham);
                });

            migrationBuilder.CreateTable(
                name: "Sizess",
                columns: table => new
                {
                    IdSize = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoSize = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizess", x => x.IdSize);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    IdNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdChucVu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.IdNguoiDung);
                    table.ForeignKey(
                        name: "FK_NguoiDungs_ChucVus_IdChucVu",
                        column: x => x.IdChucVu,
                        principalTable: "ChucVus",
                        principalColumn: "IdChucVu");
                });

            migrationBuilder.CreateTable(
                name: "Anhs",
                columns: table => new
                {
                    IdAnh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuongDanAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anhs", x => x.IdAnh);
                    table.ForeignKey(
                        name: "FK_Anhs_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "IdSanPham");
                });

            migrationBuilder.CreateTable(
                name: "KhSanPhams",
                columns: table => new
                {
                    IDKMSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    idKhuyenMai = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhSanPhams", x => x.IDKMSP);
                    table.ForeignKey(
                        name: "FK_KhSanPhams_KhuyenMais_idKhuyenMai",
                        column: x => x.idKhuyenMai,
                        principalTable: "KhuyenMais",
                        principalColumn: "IdKhuyenMai");
                    table.ForeignKey(
                        name: "FK_KhSanPhams_SanPhams_idSanPham",
                        column: x => x.idSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "IdSanPham");
                });

            migrationBuilder.CreateTable(
                name: "PhanLoaiSps",
                columns: table => new
                {
                    IdPhanLoaiSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSize = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDmau = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNSX = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Soluong = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanLoaiSps", x => x.IdPhanLoaiSP);
                    table.ForeignKey(
                        name: "FK_PhanLoaiSps_ChatLieus_IDChatLieu",
                        column: x => x.IDChatLieu,
                        principalTable: "ChatLieus",
                        principalColumn: "IdChatLieu");
                    table.ForeignKey(
                        name: "FK_PhanLoaiSps_Maus_IDmau",
                        column: x => x.IDmau,
                        principalTable: "Maus",
                        principalColumn: "IdMau");
                    table.ForeignKey(
                        name: "FK_PhanLoaiSps_NSXs_IDNSX",
                        column: x => x.IDNSX,
                        principalTable: "NSXs",
                        principalColumn: "IdNSX");
                    table.ForeignKey(
                        name: "FK_PhanLoaiSps_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "IdSanPham");
                    table.ForeignKey(
                        name: "FK_PhanLoaiSps_Sizess_IdSize",
                        column: x => x.IdSize,
                        principalTable: "Sizess",
                        principalColumn: "IdSize");
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    IdGioHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.IdGioHang);
                    table.ForeignKey(
                        name: "FK_GioHangs_NguoiDungs_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "IdNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongTien = table.Column<double>(type: "float", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.IdHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDons_GiamGias_IDGiamGia",
                        column: x => x.IDGiamGia,
                        principalTable: "GiamGias",
                        principalColumn: "IdGiamGia");
                    table.ForeignKey(
                        name: "FK_HoaDons_NguoiDungs_IDNguoiDung",
                        column: x => x.IDNguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "IdNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "GioHangChiTiets",
                columns: table => new
                {
                    IdGioHangCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGioHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPhanLoaiSP = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiets", x => x.IdGioHangCT);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_GioHangs_IdGioHang",
                        column: x => x.IdGioHang,
                        principalTable: "GioHangs",
                        principalColumn: "IdGioHang");
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_PhanLoaiSps_IdPhanLoaiSP",
                        column: x => x.IdPhanLoaiSP,
                        principalTable: "PhanLoaiSps",
                        principalColumn: "IdPhanLoaiSP");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiets",
                columns: table => new
                {
                    IdHoaDonChiTiet = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDhoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPhanLoaiSP = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiaTien = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiets", x => x.IdHoaDonChiTiet);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_HoaDons_IDhoaDon",
                        column: x => x.IDhoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "IdHoaDon");
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_PhanLoaiSps_IdPhanLoaiSP",
                        column: x => x.IdPhanLoaiSP,
                        principalTable: "PhanLoaiSps",
                        principalColumn: "IdPhanLoaiSP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anhs_IdSanPham",
                table: "Anhs",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_IdGioHang",
                table: "GioHangChiTiets",
                column: "IdGioHang");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_IdPhanLoaiSP",
                table: "GioHangChiTiets",
                column: "IdPhanLoaiSP");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_IdNguoiDung",
                table: "GioHangs",
                column: "IdNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_IDhoaDon",
                table: "HoaDonChiTiets",
                column: "IDhoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_IdPhanLoaiSP",
                table: "HoaDonChiTiets",
                column: "IdPhanLoaiSP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IDGiamGia",
                table: "HoaDons",
                column: "IDGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IDNguoiDung",
                table: "HoaDons",
                column: "IDNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_KhSanPhams_idKhuyenMai",
                table: "KhSanPhams",
                column: "idKhuyenMai");

            migrationBuilder.CreateIndex(
                name: "IX_KhSanPhams_idSanPham",
                table: "KhSanPhams",
                column: "idSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungs_IdChucVu",
                table: "NguoiDungs",
                column: "IdChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiSps_IDChatLieu",
                table: "PhanLoaiSps",
                column: "IDChatLieu");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiSps_IDmau",
                table: "PhanLoaiSps",
                column: "IDmau");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiSps_IDNSX",
                table: "PhanLoaiSps",
                column: "IDNSX");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiSps_IdSanPham",
                table: "PhanLoaiSps",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_PhanLoaiSps_IdSize",
                table: "PhanLoaiSps",
                column: "IdSize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anhs");

            migrationBuilder.DropTable(
                name: "GioHangChiTiets");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiets");

            migrationBuilder.DropTable(
                name: "KhSanPhams");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "PhanLoaiSps");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "ChatLieus");

            migrationBuilder.DropTable(
                name: "Maus");

            migrationBuilder.DropTable(
                name: "NSXs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "Sizess");

            migrationBuilder.DropTable(
                name: "ChucVus");
        }
    }
}
