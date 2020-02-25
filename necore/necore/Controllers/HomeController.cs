using Microsoft.AspNetCore.Mvc;
using necore.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace necore.Controllers
{
    public class HomeController :Controller
    {
        private IstudentRep _emprep;

        public HomeController(IstudentRep emprep)
        {
            _emprep = emprep;
        }
        public string Index()
        {
            return _emprep.GetStudent(1).name; 
        }
        public ViewResult Details()
        {
            student stu = _emprep.GetStudent(1);
            ViewBag.desc = "Student Data";
            return View(stu);
        }
    }
}
