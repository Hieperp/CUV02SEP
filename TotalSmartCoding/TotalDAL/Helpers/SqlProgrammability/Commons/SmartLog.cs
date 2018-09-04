using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class SmartLog
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public SmartLog(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.AddDataLogs();
            this.AddEventLogs();
        }

        private void AddDataLogs()
        {
            string queryString = " @LocationID Int, @EntryID int, @EntryDetailID int, @EntryDate DateTime, @ModuleName nvarchar(100), @UserName  nvarchar(100), @IPAddress nvarchar(100), @ActionType nvarchar(100), @EntityName nvarchar(100), @PropertyName nvarchar(100), @PropertyValue nvarchar(500)" + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "               INSERT TotalSmartLogs.dbo.DataLogs      (LocationID, EntryID, EntryDetailID, EntryDate, ModuleName, UserName, IPAddress, ActionType, EntityName, PropertyName, PropertyValue) " + "\r\n";
            queryString = queryString + "               VALUES                                  (@LocationID, @EntryID, @EntryDetailID, @EntryDate, @ModuleName, @UserName, @IPAddress, @ActionType, @EntityName, @PropertyName, @PropertyValue) " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("AddDataLogs", queryString);
        }

        private void AddEventLogs()
        {
            string queryString = " @LocationID Int, @EntryDate DateTime, @UserName nvarchar(100), @IPAddress nvarchar(100), @ModuleName nvarchar(100), @ActionType nvarchar(100), @EntryID int, @Remarks nvarchar(200) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "               INSERT TotalSmartLogs.dbo.EventLogs     (LocationID, EntryDate, UserName, IPAddress, ModuleName, ActionType, EntryID, Remarks) " + "\r\n";
            queryString = queryString + "               VALUES                                  (@LocationID, @EntryDate, @UserName, @IPAddress, @ModuleName, @ActionType, @EntryID, @Remarks) " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("AddEventLogs", queryString);
        }


        private void DataLogJournals()
        {
            string queryString = " @LocationID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   BEGIN " + "\r\n";

           
            queryString = queryString + "   END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("DataLogJournals", queryString);
        }

    }
}

