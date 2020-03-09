using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace necore.model
{
    public class studentrep 
    {
        public List<student> _studentlist;
        public studentrep()
        {
            _studentlist = new List<student>()
            {
                new student(){ id=1,name="abhi",location="bangalore",city="kannur",salary=2000},
                new student(){ id=2,name="abhinav",location="bangalore",city="kannur",salary=43000},
                new student(){ id=3,name="amal",location="kerala",city="kannur",salary=900000}
            };
        }

        public student add(student s)
        {
            s.id=_studentlist.Max(E => E.id) + 1;
            _studentlist.Add(s);
            return s;
        }

        public IEnumerable<student> allStudent()
        {
            return _studentlist; 
        }

        public student search(int id,string name)
        {
           
             return _studentlist.FirstOrDefault(e => e.id == id);
          //if(  _studentlist.Exists(e => e.id == id && e.name == name))
          //  { 

          //      return s;
          //  }
          //return s;
        }
        public student GetStudent(int id)
        {
            return _studentlist.FirstOrDefault(e => e.id == id);
        }
        public List<string> querysearch(int id, string name)
        {
            List<string> student = new List<string>();
            student.Add("");
            return student;
        }

    }
}
