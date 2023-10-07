
create Procedure [dbo].[Update_Data]
(
@id int,
@nama_barang varchar(200),
@kode_barang varchar(50),
@jumlah_barang int,
@tanggal Datetime
)
AS
BEGIN
Update Product set nama_barang=@nama_barang,kode_barang=@kode_barang,jumlah_barang=@jumlah_barang,tanggal=@tanggal
where id=@id
END