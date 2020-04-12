using Captain.CO2NET.AutoMapper;
using Captain.DB2NET.NPoco;
using System;
using System.Collections.Generic;
using UUMS.Enitites;
using UUMS.Services.Entities;
using UUMS.Services.IServices;

namespace UUMS.Services
{
    public class AppService : IAppService
    {
        private IDb _db;

        public AppService(IDb db)
        {
            _db = db;
        }

        public AppDto Get(Guid id)
        {
            var app = _db.SingleOrDefaultById<App>(id);
            return app.Map<AppDto>();
        }

        public List<AppDto> GetAll()
        {
            var apps = _db.Fetch<App>();
            return apps.Map<AppDto>();
        }

        public void Add(AppDto appDto)
        {
            var app = appDto.Map<App>();
            _db.Insert(app);
        }

        public void Modify(AppDto appDto)
        {
            var app = appDto.Map<App>();
            _db.Update(app);
        }

        public void Remove(Guid id)
        {
            _db.Delete<App>(id);
        }
    }
}
