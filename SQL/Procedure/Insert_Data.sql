
create Procedure [dbo].[Insert_Data]
(
@nama_barang varchar(200),
@kode_barang varchar(50),
@jumlah_barang int,
@tanggal Datetime
)
AS
BEGIN
INsert INto Product (nama_barang,kode_barang,jumlah_barang,tanggal) values (@nama_barang,@kode_barang,@jumlah_barang,@tanggal)
END