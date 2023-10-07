using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication11.Model;

namespace WebApplication11.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? Search)
        {
            var prdct = _context.ProductsModels.FromSqlInterpolated($"[dbo].[Search_Data] {Search}").ToListAsync();
            return View(await prdct);
            //return View(await _context.ProductsModels.ToListAsync());
        }





        // GET: ProductController/Details/5
        public async Task<JsonResult> Details(int? id)
        {
            string result = "";
            if (id == null)
            {
                result = "data Not Found";
                return Json(result);
            }

            var productModel = await _context.ProductsModels
                .FirstOrDefaultAsync(m => m.id == id);

            if (productModel == null)
            {
                result = "data Not Found";
                return Json(result);
            }

            return Json(productModel);
        }

        // GET: ProductController/Create
        //[HttpPost]
        public async Task<JsonResult> Create(ProductsModel productModel)
        {
            string result = "";
            if (ModelState.IsValid)
            {
                var cektgl = productModel.tanggal;
                if (cektgl == null)
                {
                    cektgl = DateTime.Now;
                }
                var insrt = _context.Database.ExecuteSqlInterpolatedAsync(
                    $"[dbo].[Insert_Data] @nama_barang={productModel.nama_barang},@kode_barang={productModel.kode_barang},@jumlah_barang={productModel.jumlah_barang},@tanggal={productModel.tanggal}");

                await insrt;
                result = "berhasil di simpan";
            }
            else
            {
                result = "gagal di simpan";
            }
            return Json(result);
        }


        private bool ProductModelExists(int id)
        {
            return _context.ProductsModels.Any(e => e.id == id);
        }


        //[HttpPost]
        public async Task<JsonResult> Edit(ProductsModel productModel)
        {
            string result = "";
            ProductsModel PM_ = new ProductsModel();
            var cnt = _context.ProductsModels.Where(x => x.id == productModel.id).Count();
            if (cnt < 1)
            {
                result = "data tidak ada";
            }

            if (ModelState.IsValid)
            {
               
                try
                {
                    //_context.Update(productModel);
                    //await _context.SaveChangesAsync();
                    var update_ = _context.Database.ExecuteSqlInterpolatedAsync(
                    $"[dbo].[Update_Data]  @id={productModel.id},@nama_barang={productModel.nama_barang},@kode_barang={productModel.kode_barang},@jumlah_barang={productModel.jumlah_barang},@tanggal={productModel.tanggal}");
                    //_context.Add(productModel);

                    //await _context.SaveChangesAsync();
                    await update_;
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.id))
                    {
                         result = "data tidak ada";
                    }
                    else
                    {
                        result = "gagal di simpan";
                        throw;
                    }
                }
                result = "berhasil di simpan";
            }
            return  Json(result);
        }

        // POST: ProductController/Create
        

      
        public async Task<JsonResult> Delete(int id)
        {
            string result = "";
            var delete_ = _context.Database.ExecuteSqlInterpolatedAsync(
                  $"[dbo].[Delete_Data] @id={id}");
            await delete_;
            result = "berhasil di hapus";
            return Json(result);
        }
    }
}
