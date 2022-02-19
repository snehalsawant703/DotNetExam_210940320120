using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationudingMVC.Models;

namespace WebApplicationudingMVC.Controllers
{
    public class ProductssController : Controller
    {
        // GET: Productss
        public ActionResult Index()
        {
            List<Products> pro = new List<Products>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog='Exam DataBase';Integrated Security=True;";
            conn.Open();
            SqlCommand cmdIndex = new SqlCommand();
            cmdIndex.Connection = conn;
            // cmdCreat.CommandType = System.Data.CommandType.StoredProcedure;
            cmdIndex.CommandType = System.Data.CommandType.Text;
            cmdIndex.CommandText = "select * from Products";
            try
            {
                SqlDataReader drr = cmdIndex.ExecuteReader();
                while(drr.Read())
                {
                    pro.Add(new Products { ProductId = (int)drr["ProductId"], ProductName=(string)drr["ProductName"],Rate = (decimal)drr["Rate"],Description = (string)drr["Description"], CategoryName= (string)drr["CategoryName"]});
                }
                drr.Close();
            }
            catch(Exception e)
            {
               
            }
            finally
            {
                conn.Close();
            }
            return View(pro);
        }

        // GET: Productss/Details/5
        public ActionResult Details(int id)
        {
            List<Products> pro = new List<Products>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog='Exam DataBase';Integrated Security=True;";
            conn.Open();
            SqlCommand cmdIndex = new SqlCommand();
            cmdIndex.Connection = conn;
            // cmdCreat.CommandType = System.Data.CommandType.StoredProcedure;
            cmdIndex.CommandType = System.Data.CommandType.Text;
            cmdIndex.CommandText = "select * from Products where ProductId=@ProductId";
            cmdIndex.Parameters.AddWithValue("@ProductId", id);
            SqlDataReader drr = cmdIndex.ExecuteReader();
            Products obj = null;
            if(drr.Read())
            {
                obj = new Products { ProductId = id, ProductName = drr.GetString(1), Rate =drr.GetDecimal(2), Description =drr.GetString(3), CategoryName = drr.GetString(4) };
            }
            else
            {
                Console.WriteLine("Error");
            }
            conn.Close();
            return View(obj);
        }

        // GET: Productss/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productss/Create
        [HttpPost]
        public ActionResult Create(Products product)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog='Exam DataBase';Integrated Security=True;";
            conn.Open();
            SqlCommand cmdCreat = new SqlCommand();
            cmdCreat.Connection = conn;
            // cmdCreat.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCreat.CommandType = System.Data.CommandType.Text;
            cmdCreat.CommandText = "insert into Products values(@ProductName,@Rate,@Description, @CategoryName )";
            cmdCreat.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmdCreat.Parameters.AddWithValue("@Rate", product.ProductName);
            cmdCreat.Parameters.AddWithValue("@Description", product.Description);
            cmdCreat.Parameters.AddWithValue("@CategoryName", product.CategoryName);
            try
            {
                // TODO: Add insert logic here
                cmdCreat.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
            finally
            {
                conn.Close();
            }
        }

        // GET: Productss/Edit/5
        public ActionResult Edit(int id)
        {
            List<Products> pro = new List<Products>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog='Exam DataBase';Integrated Security=True;";
            conn.Open();
            SqlCommand cmdIndex = new SqlCommand();
            cmdIndex.Connection = conn;
            // cmdCreat.CommandType = System.Data.CommandType.StoredProcedure;
            cmdIndex.CommandType = System.Data.CommandType.Text;
            cmdIndex.CommandText = "select * from Products where ProductId=@ProductId";
            cmdIndex.Parameters.AddWithValue("@ProductId", id);
            SqlDataReader drr = cmdIndex.ExecuteReader();
            Products obj = null;
            if (drr.Read())
            {
                obj = new Products { ProductId = id, ProductName = drr.GetString(1), Rate = drr.GetDecimal(2), Description = drr.GetString(3), CategoryName = drr.GetString(4) };
            }
            else
            {
                Console.WriteLine("Error");
            }
            conn.Close();
            return View(obj);
        }

        // POST: Productss/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products product)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog='Exam DataBase';Integrated Security=True;";
            conn.Open();
            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.Connection = conn;
            // cmdCreat.CommandType = System.Data.CommandType.StoredProcedure;
            cmdEdit.CommandType = System.Data.CommandType.Text;
            cmdEdit.CommandText = "update Products set ProductName=@ProductName,Rate=@Rate,Description=@Description, CategoryName=@CategoryName";
            cmdEdit.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmdEdit.Parameters.AddWithValue("@Rate", product.ProductName);
            cmdEdit.Parameters.AddWithValue("@Description", product.Description);
            cmdEdit.Parameters.AddWithValue("@CategoryName", product.CategoryName);

            try
            {
                // TODO: Add update logic here
                cmdEdit.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        // GET: Productss/Delete/5
        public ActionResult Delete(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog='Exam DataBase';Integrated Security=True;";
            conn.Open();
            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.Connection = conn;
            // cmdCreat.CommandType = System.Data.CommandType.StoredProcedure;
            cmdEdit.CommandType = System.Data.CommandType.Text;
            cmdEdit.CommandText = "select * from Products where ProductId=@ProductId";
            cmdEdit.Parameters.AddWithValue("@ProductId", id);
            SqlDataReader drr = cmdEdit.ExecuteReader();
            Products obj = null;
            if (drr.Read())
            {
                obj = new Products { ProductId = id, ProductName = drr.GetString(1), Rate = drr.GetDecimal(2), Description = drr.GetString(3), CategoryName = drr.GetString(4) };
            }
            else
            {
                Console.WriteLine("Error");
            }
            conn.Close();
            return View(obj);
        }

        // POST: Productss/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog='Exam DataBase';Integrated Security=True;";
            conn.Open();
            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.Connection = conn;
            // cmdCreat.CommandType = System.Data.CommandType.StoredProcedure;
            cmdEdit.CommandType = System.Data.CommandType.Text;
            cmdEdit.CommandText = "delete from Products where ProductId=@ProductId";
            cmdEdit.Parameters.AddWithValue("@ProductId", id);
                cmdEdit.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
