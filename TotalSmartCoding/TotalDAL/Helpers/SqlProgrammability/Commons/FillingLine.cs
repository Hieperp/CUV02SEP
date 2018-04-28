using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class FillingLine
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public FillingLine(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetFillingLineIndexes();

            this.FillingLineEditable();
            this.FillingLineDeletable();
            this.FillingLineSaveRelative();

            this.GetFillingLineBases();
        }


        private void GetFillingLineIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      FillingLines.FillingLineID, FillingLines.Code, FillingLines.Name, FillingLines.NickName " + "\r\n";
            queryString = queryString + "       FROM        FillingLines " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetFillingLineIndexes", queryString);
        }


        private void FillingLineSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("FillingLineSaveRelative", queryString);
        }


        private void FillingLineEditable()
        {
            string[] queryArray = new string[0];

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("FillingLineEditable", queryArray);
        }

        private void FillingLineDeletable()
        {
            string[] queryArray = new string[1];
            queryArray[0] = " SELECT TOP 1 @FoundEntity = FillingLineID FROM FillingLines WHERE FillingLineID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("FillingLineDeletable", queryArray);
        }

        private void GetFillingLineBases()
        {
            string queryString;

            queryString = " " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      FillingLineID, Code, Name, NickName " + "\r\n";
            queryString = queryString + "       FROM        FillingLines " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetFillingLineBases", queryString);
        }

    }
}
