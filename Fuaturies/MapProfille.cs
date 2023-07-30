using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDirectum.DAO;
using TestTaskDirectum.Entities;

namespace TestTaskDirectum.Fuaturies
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<MeetingModel, Meeting>();
            CreateMap<MeetingUserModel, MeetingUser>();
            CreateMap<Meeting, MeetingResultModel>();
            CreateMap<MeetingUser, MeetingUserResultModel>();
        }
    }
}
