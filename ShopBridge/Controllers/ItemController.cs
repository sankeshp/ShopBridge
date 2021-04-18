using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    public class ItemController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select Id,Name,Description,Prize from Item";
            DataTable table = new DataTable();
            using (var con = new SqlConnection
                (ConfigurationManager.ConnectionStrings["ShopBridgeDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Item item)
        {
            try
            {
                string query = @"insert into dbo.Item values
                (
                '" + item.Id + @"'
                ,'" + item.Name + @"'
                ,'" + item.Description + @"'
                ,'" + item.Prize + @"'
                )";
                DataTable table = new DataTable();
                using (var con = new SqlConnection
                    (ConfigurationManager.ConnectionStrings["ShopBridgeDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Fail to add";
            }
        }

        public string Put(Item item)
        {
            try
            {
                string query = @"update dbo.Item set 
                Name='" + item.Name + @"' 
                ,Description='" + item.Description + @"' 
                ,Prize='" + item.Prize + @"' 
                where Id= " + item.Id + @" ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection
                    (ConfigurationManager.ConnectionStrings["ShopBridgeDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully";
            }
            catch (Exception)
            {
                return "Fail to update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Item where Id= " + id + @" ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection
                    (ConfigurationManager.ConnectionStrings["ShopBridgeDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Fail to delete";
            }
        }
       
    }
}