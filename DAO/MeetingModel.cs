using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDirectum.DAO
{
    public class MeetingModel
    {
        public DateTime StartMetting { get; set; }
        public DateTime EndMetting { get; set; }
        public TimeSpan? NotificationTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<MeetingUserModel> MeetingUsers { get; set; }
    }
}
