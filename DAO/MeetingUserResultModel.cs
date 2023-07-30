using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDirectum.Entities;

namespace TestTaskDirectum.DAO
{
    public class MeetingUserResultModel
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public int UserId { get; set; }
    }
}
