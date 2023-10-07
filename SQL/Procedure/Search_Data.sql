
CREATE Procedure [dbo].[Search_Data]
(
@searchdata varchar(max)
)
as
Begin

	Select * from Product where 
	id like '%' + ISNULL(@searchdata,'') + '%'
	OR nama_barang like '%' +  ISNULL(@searchdata,'') + '%'
	OR jumlah_barang like '%' +  ISNULL(@searchdata,0) + '%'
	OR kode_barang like '%' +  ISNULL(@searchdata,'') + '%' 
	OR CONVERT(DATE,tanggal) like '%' + @searchdata + '%'
END