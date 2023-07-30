using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDirectum.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<MeetingUser> MeetingUsers { get; set; }
    }
}
