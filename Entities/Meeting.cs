using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDirectum.Entities
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime StartMetting { get; set; }
        public DateTime EndMetting { get; set; }
        public TimeSpan? NotificationTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<MeetingUser> MeetingUsers { get; set; }
    }
}
