﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security;
using Microsoft.AspNetCore.Mvc;
using PRIYANKAPROJECT.Models;

namespace MvcApplication.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: /UserLogin/  
        public string status;

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Enroll e)
        {
            String SqlCon = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            string SqlQuery = "select Email,Password from Enrollment where Email=@Email and Password=@Password";
            con.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, con); ;
            cmd.Parameters.AddWithValue("@Email", e.Email);
            cmd.Parameters.AddWithValue("@Password", e.Password);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Session["Email"] = e.Email.ToString();
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewData["Message"] = "User Login Details Failed!!";
            }
            if (e.Email.ToString() != null)
            {
                Session["Email"] = e.Email.ToString();
                status = "1";
            }
            else
            {
                status = "3";
            }

            con.Close();
            return View();
            //return new JsonResult { Data = new { status = status } };  
        }

        [HttpGet]
        public ActionResult Welcome(Enroll e)
        {
            Enroll user = new Enroll();
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection("Data Source=PRIYANKA\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Sample"))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetEnrollmentDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 30).Value = Session["Email"].ToString();
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    List<Enroll> userlist = new List<Enroll>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Enroll uobj = new Enroll();
                        uobj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                        uobj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                        uobj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                        uobj.Password = ds.Tables[0].Rows[i]["Password"].ToString();
                        uobj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                        uobj.PhoneNumber = ds.Tables[0].Rows[i]["Phone"].ToString();
                        uobj.SecurityAnwser = ds.Tables[0].Rows[i]["SecurityAnwser"].ToString();
                        uobj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();

                        userlist.Add(uobj);

                    }
                    user.Enrollsinfo = userlist;
                }
                con.Close();

            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "UserLogin");
        }

    }
}