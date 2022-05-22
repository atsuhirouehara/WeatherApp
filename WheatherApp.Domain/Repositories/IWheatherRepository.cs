using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheatherApp.Domain.Entities;

namespace WheatherApp.Domain.Repositories
{
    public interface IWheatherRepository
    {
        WheatherEntity GetLatest(int areaId);
    }
}
