using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDirectum.DAO;

namespace TestTaskDirectum.Services
{
    public interface IMeetingsExportService
    {
        public Task Export(IEnumerable<MeetingResultModel> meetings, string fileName);
    }


}
