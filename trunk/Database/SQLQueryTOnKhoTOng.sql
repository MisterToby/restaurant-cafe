﻿DROP VIEW BAOCAOTONKHO
GO
CREATE VIEW BAOCAOTONKHO
AS
SELECT  
	
	CASE
		WHEN T.DonViID = 1 THEN  M.TenDai + ' (Cái, Lon, ...)' 
		WHEN T.DonViID = 2 THEN  M.TenDai + ' (Kg)' 
		WHEN T.DonViID = 3 THEN  M.TenDai + ' (Lít)' 
		WHEN T.DonViID = 4 THEN  M.TenDai + ' (giờ)'
		ELSE M.TenDai
	END							
	As TenBaoCao,       
	CASE
		WHEN T.DonViID = 1 THEN ISNULL(T.SoLuongTon, 0)
		WHEN T.DonViID = 2 THEN CAST(ISNULL(T.SoLuongTon, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 3 THEN CAST(ISNULL(T.SoLuongTon, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 4 THEN CAST(ISNULL(T.SoLuongTon, 0) / 3600.000 AS DECIMAL(10,3)) 					
		ELSE CAST(ISNULL(T.SoLuongTon, 0) AS DECIMAL(10,0)) 
	END
	AS SoluongTon,	
	CASE
		WHEN T.DonViID = 1 THEN ISNULL(T.SoLuongBan, 0)
		WHEN T.DonViID = 2 THEN CAST(ISNULL(T.SoLuongBan, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 3 THEN CAST(ISNULL(T.SoLuongBan, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 4 THEN CAST(ISNULL(T.SoLuongBan, 0) / 3600.000 AS DECIMAL(10,3)) 					
		ELSE CAST(ISNULL(T.SoLuongBan, 0) AS DECIMAL(10,0)) 
	END
	AS SoLuongBan,
	CASE
		WHEN T.DonViID = 1 THEN ISNULL(T.SoLuongNhap, 0)
		WHEN T.DonViID = 2 THEN CAST(ISNULL(T.SoLuongNhap, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 3 THEN CAST(ISNULL(T.SoLuongNhap, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 4 THEN CAST(ISNULL(T.SoLuongNhap, 0) / 3600.000 AS DECIMAL(10,3)) 					
		ELSE CAST(ISNULL(T.SoLuongNhap, 0) AS DECIMAL(10,0)) 
	END
	AS SoLuongNhap,
	CASE
		WHEN T.DonViID = 1 THEN ISNULL(T.SoLuongChuyen, 0)
		WHEN T.DonViID = 2 THEN CAST(ISNULL(T.SoLuongChuyen, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 3 THEN CAST(ISNULL(T.SoLuongChuyen, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 4 THEN CAST(ISNULL(T.SoLuongChuyen, 0) / 3600.000 AS DECIMAL(10,3)) 					
		ELSE CAST(ISNULL(T.SoLuongChuyen, 0) AS DECIMAL(10,0)) 
	END
	AS SoLuongChuyen,	
	CASE
		WHEN T.DonViID = 1 THEN ISNULL(T.SoLuongHu, 0)
		WHEN T.DonViID = 2 THEN CAST(ISNULL(T.SoLuongHu, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 3 THEN CAST(ISNULL(T.SoLuongHu, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 4 THEN CAST(ISNULL(T.SoLuongHu, 0) / 3600.000 AS DECIMAL(10,3)) 					
		ELSE CAST(ISNULL(T.SoLuongHu, 0) AS DECIMAL(10,0)) 
	END
	AS SoLuongHu,
	CASE
		WHEN T.DonViID = 1 THEN ISNULL(T.SoLuongDieuChinh, 0)
		WHEN T.DonViID = 2 THEN CAST(ISNULL(T.SoLuongDieuChinh, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 3 THEN CAST(ISNULL(T.SoLuongDieuChinh, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 4 THEN CAST(ISNULL(T.SoLuongDieuChinh, 0) / 3600.000 AS DECIMAL(10,3)) 					
		ELSE CAST(ISNULL(T.SoLuongDieuChinh, 0) AS DECIMAL(10,0)) 
	END
	AS SoLuongDieuChinh,
	CASE
		WHEN T.DonViID = 1 THEN ISNULL(T.SoLuongMat, 0)
		WHEN T.DonViID = 2 THEN CAST(ISNULL(T.SoLuongMat, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 3 THEN CAST(ISNULL(T.SoLuongMat, 0) / 1000.000 AS DECIMAL(10,3)) 
		WHEN T.DonViID = 4 THEN CAST(ISNULL(T.SoLuongMat, 0) / 3600.000 AS DECIMAL(10,3)) 					
		ELSE CAST(ISNULL(T.SoLuongMat, 0) AS DECIMAL(10,0)) 
	END
	AS SoLuongMat,
	M.MonID
	FROM	dbo.MENUMON AS M LEFT OUTER JOIN
			dbo.TONKHOTONG AS T ON M.MonID = T.MonID
	Where SLMonChoPhepTonKho > 0
GO
Select  * from BAOCAOTONKHO Order by SoLuongTon

