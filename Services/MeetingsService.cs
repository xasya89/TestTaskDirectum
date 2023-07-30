using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDirectum.DAO;
using TestTaskDirectum.Entities;
using TestTaskDirectum.Fuaturies;

namespace TestTaskDirectum.Services
{
    /// <summary>
    /// CRUD операции ВСТРЕЧИ
    /// </summary>
    public class MeetingsService
    {
        private readonly MettingsContext _db;
        private readonly Mapper _mapper;
        public MeetingsService(MettingsContext db)
        {
            _db = db;
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile<MapProfile>()));
        }

        public async Task<MeetingResultModel> Add(MeetingModel model)
        {
            if (DateTime.Compare(model.StartMetting, DateTime.Now) < 0)
                throw new Exception("Невозможно добавить встречу, дата начала меньше текущей");
            if ((await getIntersectionMeeting(model)).Count() > 0)
                throw new Exception("Встречи пересекаются");

            var dbModel = _mapper.Map<Meeting>(model);
            _db.Meetings.Add(dbModel);
            await _db.SaveChangesAsync();

            return _mapper.Map<MeetingResultModel>(dbModel);
        }

        public async Task<MeetingResultModel> Edit(int meetingId, MeetingModel model)
        {
            var meeting = await _db.Meetings.Include(x=>x.MeetingUsers).FirstAsync(x=>x.Id== meetingId);
            meeting.Name = model.Name;
            meeting.Description = model.Description;
            meeting.StartMetting = model.StartMetting;
            meeting.EndMetting = model.EndMetting;
            meeting.NotificationTime = model.NotificationTime;
            meeting.MeetingUsers = _mapper.Map<IEnumerable<MeetingUser>>(model.MeetingUsers).ToList();
            await _db.SaveChangesAsync();
            return _mapper.Map<MeetingResultModel>(meeting);
        }

        public async Task Delete(int meetingId)
        {
            var meeting = await _db.Meetings.FindAsync(meetingId);
            _db.Remove(meeting);
            await _db.SaveChangesAsync();
        }
            

        /// <summary>
        /// Пересечение встреч
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Кол-во таких встреч</returns>
        private async Task<IEnumerable<Meeting>> getIntersectionMeeting(MeetingModel model) =>
            await _db.Meetings
                .Where(x => x.StartMetting >= model.StartMetting & x.EndMetting <= model.EndMetting)
                .ToListAsync();
    }
}
