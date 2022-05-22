using System;
using WheatherApp.Domain.ValueObjects;

namespace WheatherApp.Domain.Entities
{
    public sealed class WheatherEntity
    {
        // 完全コンストラクタパターン
        public WheatherEntity(int areaId, DateTime dataDate, int condition, float temperature)
        {
            AreaId = areaId;
            DataDate = dataDate;
            Condition = new Condition(condition);
            Temperature = new Temperature(temperature);
        }

        public int AreaId { get;  }
        public DateTime DataDate { get; }
        public Condition Condition { get;  }
        public Temperature Temperature { get;  }

        public bool IsOK()
        {
            if(DataDate < DateTime.Now.AddMonths(-1))
            {
                if(Temperature.Value < 10)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
