using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestTaskDirectum.DAO;

namespace TestTaskDirectum.Services
{
    /// <summary>
    /// Экспорт в JSON файл
    /// </summary>
    public class MeetingsToFileExportService : IMeetingsExportService
    {
        public async Task Export(IEnumerable<MeetingResultModel> meetings, string fileName)
        {
            var jsonStr = JsonSerializer.Serialize(meetings);
            await File.WriteAllTextAsync(fileName, jsonStr);
        }
    }
}
