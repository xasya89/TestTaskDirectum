using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDirectum.DAO;
using TestTaskDirectum.Fuaturies;

namespace TestTaskDirectum.Services
{
    /// <summary>
    /// Уведомления о новых встреч
    /// </summary>
    public class MeetingNotificationService
    {
        private readonly MettingsContext _db;

        private readonly Mapper _mapper;
        public MeetingNotificationService(MettingsContext db)
        {
            _db = db;
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<MapProfile>()));
        }

        public async Task<IEnumerable<MeetingResultModel>> GetNotifications(int userId)
        {
            var result = await _db.Meetings.Include(x => x.MeetingUsers)
                .Where(x => x.StartMetting.TimeOfDay - (x.NotificationTime ?? TimeSpan.Zero) <= DateTime.Now.TimeOfDay & x.MeetingUsers.FirstOrDefault(x => x.UserId == userId) != null)
                .ToListAsync();
            return _mapper.Map<IEnumerable<MeetingResultModel>>(result);
        }

    }
}
