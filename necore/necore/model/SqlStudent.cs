using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace necore.model
{
    public class SqlStudent : IstudentRep
    {
        private readonly AppDbContext context;

        public SqlStudent(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<student> addAsync(student s)
        {
            List<student> studentinfo = new List<student>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63314/");
                HttpResponseMessage student = await client.GetAsync("api/Student");
                if(student.IsSuccessStatusCode)
                {
                    var studentresponse = student.Content.ReadAsStringAsync().Result;
                    studentinfo = JsonConvert.DeserializeObject<List<student>>(studentresponse);
                }
                s.id = studentinfo.Max(E => E.id) + 1;
                string output = JsonConvert.SerializeObject(s);
                HttpContent inputContent = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                
                //client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync("api/Student", inputContent);

                if (response.IsSuccessStatusCode)
                {
                    return s;
                }
                else
                {
                    s = null;
                    return s;
                }

            }
            //context.student.Add(s);
            //context.SaveChanges();
            //return s;
        }

        public IEnumerable<student> allStudent()
        {
            return context.student;

        }

        public student GetStudent(int id)
        {
            return context.student.Find(id);
        }

        public student search(int id, string name)
        {
            student s = context.student.Find(id);
            if (s != null && s.name.Equals(name))
            {
                return s;
            }
            else
            {
                s = null;
                return s;
            }
        }
        public List<string> querysearch(int id, string name)
        {
            List<string> student = new List<string>();
            student.Add("");
            return student;
        }
        string pass;
        userlog log;
        public bool Username(string _Username)
        {
            log = context.userlog.Where(b => b.username == _Username).FirstOrDefault();

            if (log != null)
            {
                pass = log.password;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Password(string password, string username)
        {
            log = context.userlog.Where(b => b.username == username).FirstOrDefault();
            if (log.password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool update(string username)
        {
            try
            {
                Random rnd = new Random();
                int randOTP = rnd.Next(10000, 99999);
                userlog log = context.userlog.Where(d => d.username == username).FirstOrDefault();
                if (log != null)
                {
                    log.otp = randOTP;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public userlog OTPcheck(int Otp, string username)
        {
            userlog otp = log = context.userlog.Where(b => b.username == username).FirstOrDefault();
            if (otp.otp == Otp)
            {
                return otp;
            }
            else
            {
                otp = null;
                return otp;
            }

        }

        public IEnumerable<student> like(string name)
        {
            IEnumerable<student> stu = from e in context.student where EF.Functions.Like(e.name, "%" + name + "%") select e;
            return stu;

        }

    }
}
