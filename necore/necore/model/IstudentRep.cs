using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace necore.model
{
    public interface IstudentRep
    {
        student GetStudent(int id);
        IEnumerable<student> allStudent();
        Task<student> addAsync(student s);
        student search(int id, string name);
        List<string> querysearch(int id,string name);
        bool Username(string _Username);
        bool Password(string password, string username);
        bool update(string username);
        userlog OTPcheck(int Otp, string username);
        IEnumerable<student> like(string name);
        bool updateApi(student s);
    }
}
