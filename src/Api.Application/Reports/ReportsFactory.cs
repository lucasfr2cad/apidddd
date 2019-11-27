using System;
using System.Collections.Generic;
using Aplication.Reports;
using DevExpress.XtraReports.UI;

namespace Api.Application.Reports
{
    public static class ReportsFactory
    {

        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["UserReport"] = () => new UserReport(),
            ["Filipe"] = () => new FilipeReport()
        };

    }
}
