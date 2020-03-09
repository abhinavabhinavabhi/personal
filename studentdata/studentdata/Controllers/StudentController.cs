using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students;

namespace studentdata.Controllers
{
    public class StudentController : ApiController
    {
        public IEnumerable<student> get()
        {
            using (demoEntities entity = new demoEntities())
            {
                return entity.students.ToList();
            }
        }

        public HttpResponseMessage get(int id)
        {
            using (demoEntities entity = new demoEntities())
            {
                var student = entity.students.FirstOrDefault(ds => ds.id == id);
                if (student != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, student);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with the id =" + id.ToString() + " not found");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] student student)
        {
            try
            {
                using (demoEntities entity = new demoEntities())
                {
                    entity.students.Add(student);
                    entity.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, student);
                    message.Headers.Location = new Uri(Request.RequestUri + "/"+student.id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (demoEntities entity = new demoEntities())
                {
                    var stud = entity.students.FirstOrDefault(p => p.id == id);
                    if (stud == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "THe student with id " + id.ToString() + "not found");
                    }
                    else
                    {
                        entity.students.Remove(stud);
                        entity.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Put(int id,student student)
        {
            try
            {
                using (demoEntities entity = new demoEntities())
                {
                    var stud = entity.students.FirstOrDefault(p => p.id == id);
                    if (stud != null)
                    {
                        stud.name = student.name;
                        stud.location = student.location;
                        stud.city = student.city;
                        stud.salary = student.salary;

                        entity.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, stud);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with id " + id.ToString() + " not exist");
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }

    }
}
