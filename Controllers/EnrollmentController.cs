using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRIYANKAPROJECT.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace PRIYANKAPROJECT.Controllers
{
    public class EnrollmentController : Controller
    {
        public string value = "";

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Enroll e)
        {
            if (Request.HttpMethod == "POST")
            {
                Enroll er = new Enroll();
                using (SqlConnection con = new SqlConnection("Data Source=PRIYANKA\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Sample"))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EnrollDetail", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", e.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", e.LastName);
                        cmd.Parameters.AddWithValue("@Password", e.Password);
                        cmd.Parameters.AddWithValue("@Gender", e.Gender);
                        cmd.Parameters.AddWithValue("@Email", e.Email);
                        cmd.Parameters.AddWithValue("@Phone", e.PhoneNumber);
                        cmd.Parameters.AddWithValue("@SecurityAnwser", e.SecurityAnwser);
                        cmd.Parameters.AddWithValue("@status", "INSERT");
                        con.Open();
                        ViewData["result"] = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return View();
        }

    }
}