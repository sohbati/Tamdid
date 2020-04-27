using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using Insurance_Common;
using Insurance_dll;

namespace Insurance_BLL
{
    public class SqlServerSettingCheckBS
    {
        SqlServerSettingCheck _sqlServerSettingCheck = new SqlServerSettingCheck();
        public SqlServerSettingCheckBS()
        {

        }

        public int runAgent() {
            return _sqlServerSettingCheck.msServerAgentCheck();
        }

        public int msDoAgantsJobDirectly()
        {
            return _sqlServerSettingCheck.msDoAgantsJobDirectly();
        }
    }
}
