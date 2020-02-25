using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace necore.model
{
    public class studentrep : IstudentRep
    {
        public List<student> _studentlist;
        public studentrep()
        {
            _studentlist = new List<student>()
            {
                new student(){ id=1,name="abhi",location="bangalore",city="kaannur",salary=2000},
                new student(){ id=2,name="abhinac",location="bangalore",city="kannur",salary=43000},
                new student(){ id=3,name="amal",location="kerala",city="kannur",salary=900000}

            };
        }
        public student GetStudent(int id)
        {
            return _studentlist.FirstOrDefault(e => e.id == id);
        }
    }
}
