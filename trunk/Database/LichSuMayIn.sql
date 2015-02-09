GO
DROP VIEW BAOCAOCHITIETLICHSUBANHANG
GO
CREATE VIEW BAOCAOCHITIETLICHSUBANHANG
AS
SELECT 
	CTLSBH.ChiTietLichSuBanHangID AS ID,
	LSBH.LichSuBanHangID,
	LSBH.NgayBan,
	CASE 
		WHEN KTM.TenLoaiBan <> '' THEN MM.TenDai + '('+KTM.TenLoaiBan+')'
		ELSE  MM.TenDai
	END AS Ten,
	CASE WHEN CTLSBH.SoLuong < 0 THEN CTLSBH.SoLuong * -1 ELSE CTLSBH.SoLuong END AS SoLuong,
	CASE WHEN CTLSBH.SoLuong < 0 THEN 'X�a' ELSE 'Th�m' END AS TrangThai,
	NV.TenNhanVien,
	B.TenBan
	FROM LICHSUBANHANG LSBH
	INNER JOIN CHITIETLICHSUBANHANG CTLSBH ON LSBH.LichSuBanHangID = CTLSBH.LichSuBanHangID
	INNER JOIN MENUKICHTHUOCMON KTM ON CTLSBH.KichThuocMonID = KTM.KichThuocMonID
	INNER JOIN MENUMON MM ON KTM.MonID = MM.MonID
	INNER JOIN NHANVIEN NV ON NV.NhanVienID = LSBH.NhanVienID
	INNER JOIN BANHANG BH ON BH.BanHangID = LSBH.BanHangID
	INNER JOIN BAN B ON B.BanID = BH.BanID