using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using Insurance_Common;

namespace Insurance_dll
{
    public class SqlServerSettingCheck
    {
        RMX_TOOLS.data.SqlServerProvider _dp;

        public SqlServerSettingCheck()
        {
            _dp = (SqlServerProvider)Config.provider;
        }

        public int msServerAgentCheck()
        {
            //string sql = "EXEC master.dbo.xp_ServiceControl 'QUERYSTATE','SQLServerAgent'";
            //sql = "EXEC master.dbo.xp_ServiceControl 'START', 'SQLServerAgent'";
            string storedProcedure = "agentRun";
            int n = _dp.RunStoredProcedure(storedProcedure);
            return n;
        }
        /**
         * same as job's wrork run update 
         */
        public int msDoAgantsJobDirectly()
        {
            string storedProcedure = "msDoAgantsJobDirectly";
            int n = _dp.RunStoredProcedure(storedProcedure);
            return n;

        }
    }
}
