using Microsoft.AspNetCore.Mvc;
using necore.model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System;
using System.Collections;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace necore.Controllers
{
    public class HomeController : Controller
    {

        private IstudentRep _emprep;

        public IConfiguration Configuration;

        public HomeController(IstudentRep emprep, IConfiguration configuration)
        {
            _emprep = emprep;
            Configuration = configuration;
        }

        [Route("")]
        [Route("home")]
        [Route("home/index")]
        public async Task<ActionResult> Index()
        {
            List<student> studentinfo = new List<student>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63314/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Student");
                if(res.IsSuccessStatusCode)
                {
                    var studentresponse = res.Content.ReadAsStringAsync().Result;
                    studentinfo = JsonConvert.DeserializeObject<List<student>>(studentresponse);
                    return View(studentinfo);
                }
                else
                {
                    return View();
                }
            }

            //var model = _emprep.allStudent();
            //return View(model);
        }

        [Route("home/details/{id?}")]
        public ViewResult Details(int? id)
        {
            student stu = _emprep.GetStudent(id ?? 1);
            ViewBag.desc = "Student Data";
            return View(stu);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(student s)
        {
           Task<student> stu = _emprep.addAsync(s);
            student student = stu.Result;
            if(student!=null)
            {
                return RedirectToAction("Details", new { id = s.id });
            }
            else
            {
                ViewBag.mess = "error in adding";
                return View();
            }
           
        }

        [HttpGet]
        public ViewResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search([FromBody] login obj)
        {
            student c = _emprep.search(obj.id, obj.Password);
            if (c != null)
            {
                return Json("Id : " + c.id + " Name: " + c.name + " Salary : " + c.salary + " Location : " + c.location);
            }
            else
            {
                ViewBag.ErrorMessage = "Incorrect Username Password";
                return Json("Incorrect username and password");
            }
        }

        [HttpPost]
        public IActionResult Query([FromBody] login l)
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult query()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Query()
        {
            string c = Configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(c))
            {
                string id = "", name = "";
                id = HttpContext.Request.Query["id"];
                name = HttpContext.Request.Query["Password"];
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from student where id='" + id + "' and name='" + name + "'", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    ViewBag.id = id;
                    ViewBag.name = name;
                }
                else
                {
                    ViewBag.id = "not found";
                    ViewBag.name = "Not found";
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult Queryjson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Queryjson([FromForm] login l)
        {
            var jsonString = HttpContext.Request.Query["query"];
            login result = JsonConvert.DeserializeObject<login>(jsonString);
            ViewBag.loginid = result.id;
            ViewBag.pass = result.Password;
            ViewBag.json = jsonString;
            //ViewBag.jsonid = l.id;
            ViewBag.json = "inside view";
            return View();
        }

        [HttpGet]
        public IActionResult Username()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Username([FromForm] UserLogin l)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("Username", l.Username, cookie);
            string username = Request.Cookies["username"];

            bool b = _emprep.Username(username);
            if (b)
            {
                return RedirectToAction("Password", new { Username = l.Username });
            }
            else
            {
                ViewBag.error = "Incorrecr Username";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Password(string Username)
        {
            //UserLogin l=new UserLogin();
            //l.Username = Username;
            ViewBag.user = Username;

            return View();
        }

        [HttpPost]
        public IActionResult Password([FromForm] UserLogin l)
        {
            string username = Request.Cookies["username"];
            TempData["password"] = l.Password;
           
            bool b = _emprep.Password(TempData["password"].ToString(),username);
            if (b)
            {
                return RedirectToAction("Otp", new { Username = TempData["username"] });
            }
            else
            {
                ViewBag.user = username;
                ViewBag.error = "Incorrect Password";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Otp(string Username)
        {
            
            string username = Request.Cookies["username"];
           
            bool b = _emprep.update(username);
            if (b)
            {
                ViewBag.user = username;
                ViewBag.error = "OTP sucessfully send";
                return View();
            }
            else
            {
                ViewBag.error = "OTP generation failed";
                return View();
            }
        }

        [HttpPost]
        public ViewResult Otp([FromForm] UserLogin l)
        {

            string username = Request.Cookies["username"];
            
            TempData["otp"] = l.Otp;
            int otp = int.Parse(TempData["otp"].ToString());
            userlog user = _emprep.OTPcheck(otp, username);
            if (user != null)
            {
                ViewBag.log = "Sucess fully logged in " + user.username;
                return View();
            }
            else
            {
                ViewBag.error = "Invalid otp";
                return View();
            }
            //ViewBag.pass = " " + TempData["username"] + " " + TempData["password"] + " " + TempData["otp"];
        }

        [HttpGet]
        public ViewResult Jquery()
        {
            return View();
        }
        
        [HttpPost]
        public ViewResult Jquery(string name)
        {
            ViewBag.mess = name;
           var student=_emprep.like(name);
            // string c = Configuration.GetConnectionString("DefaultConnection");
            //using (SqlConnection con = new SqlConnection(c))
            //{
            //    SqlCommand cmd = new SqlCommand("select * from userlog where name like '%" + name + "%'", con);
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        return View();
            //    }

            //}
                return View(student);
        }

        [HttpGet]
        public ViewResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update([FromForm] student s)
        {
            bool Result =_emprep.updateApi(s);
            if(Result)
            {
                return RedirectToAction("Details", new { id = s.id });
            }
            else
            {
                ViewBag.mess = "Update Failed";
                return View();
            }
        }
    }
}
