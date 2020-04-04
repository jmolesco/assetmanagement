using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.API.Services.Dashboard
{
    public interface IDashboardService
    {
        object TotalNumbers();

        object TotalChartNumbers();

        object Activity();
    }
}
