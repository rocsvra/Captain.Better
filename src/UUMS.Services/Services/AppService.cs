using Captain.CO2NET.AutoMapper;
using Captain.DB2NET.NPoco;
using UUMS.Enitites;
using UUMS.Services.Entities;

namespace UUMS.Services
{
    public class AppService
    {
        private IDb _db;

        public AppService(IDb db)
        {
            _db = db;
        }

        public void Add(AppDto appDto)
        {
            var app = appDto.Map<App>();
            _db.Insert(app);
        }
    }
}
