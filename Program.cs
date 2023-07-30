using TestTaskDirectum.DAO;
using TestTaskDirectum.Entities;
using TestTaskDirectum.Services;

namespace TestTaskDirectum
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var db = new MettingsContext();
            await db.Init();
            var meetingsService = new MeetingsService(db);
            var notificationService = new MeetingNotificationService(db);
            IMeetingsExportService exportService = new MeetingsToFileExportService();

            var newMeeting = new MeetingModel
            {
                Name = "Встреча 1",
                Description = "Описание",
                StartMetting = DateTime.Now.AddDays(1),
                EndMetting = DateTime.Now.AddDays(1).AddHours(2),
                MeetingUsers = new[] { new MeetingUserModel { UserId = 1 }, new MeetingUserModel { UserId = 2 } }.ToList()
            };
            //Создание встречи
            var meeting = await meetingsService.Add(newMeeting);

            //Редактирование встречи
            var editingMeeting = new MeetingModel
            {
                Name = "Встреча 1",
                Description = "Описание",
                StartMetting = DateTime.Now.AddDays(1),
                EndMetting = DateTime.Now.AddDays(1).AddHours(2),
                MeetingUsers = new[] { new MeetingUserModel { UserId = 1 }, new MeetingUserModel { UserId = 2 } }.ToList()
            };
            meeting = await meetingsService.Edit(meeting.Id, editingMeeting);

            //Получим текущие встречи
            var notifications = await notificationService.GetNotifications(1);

            //Экспортируем в файл
            await exportService.Export(notifications, "export.json");

            //Удаление встречи
            await meetingsService.Delete(meeting.Id);
        }


    }
}