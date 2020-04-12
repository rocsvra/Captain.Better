using System;
using System.Collections.Generic;
using UUMS.Enitites;

namespace UUMS.Services.IServices
{
    public interface IAppService
    {
        AppDto Get(Guid id);
        List<AppDto> GetAll();
        void Add(AppDto appDto);
        void Modify(AppDto appDto);
        void Remove(Guid id);
    }
}
