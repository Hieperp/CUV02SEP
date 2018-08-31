using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class Team
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public Team(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetTeamIndexes();

            //this.TeamEditable(); 
            //this.TeamSaveRelative();

            this.GetTeamBases();
            this.GetTeamTrees();
        }


        private void GetTeamIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Teams.TeamID, Teams.Name " + "\r\n";
            queryString = queryString + "       FROM        Teams " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetTeamIndexes", queryString);
        }


        private void TeamSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF (@SaveRelativeOption = 1) " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";

            queryString = queryString + "               INSERT INTO TeamTeams (TeamID, TeamID, TeamTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      TeamID, 46 AS TeamID, " + (int)GlobalEnums.NmvnTaskID.SalesOrder + " AS TeamTaskID, GETDATE(), '', 0 FROM Teams WHERE TeamID = @EntityID " + "\r\n";

            queryString = queryString + "               INSERT INTO TeamTeams (TeamID, TeamID, TeamTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      Teams.TeamID, Teams.TeamID, " + (int)GlobalEnums.NmvnTaskID.DeliveryAdvices + " AS TeamTaskID, GETDATE(), '', 0 FROM Teams INNER JOIN Teams ON Teams.TeamID = @EntityID AND Teams.TeamTypeID NOT IN (4, 5, 7, 9, 10, 11, 12) AND Teams.TeamTypeID = Teams.TeamTypeID " + "\r\n";

            queryString = queryString + "               INSERT INTO TeamTeams (TeamID, TeamID, TeamTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      TeamID, 82 AS TeamID, " + (int)GlobalEnums.NmvnTaskID.DeliveryAdvices + " AS TeamTaskID, GETDATE(), '', 0 FROM Teams WHERE TeamID = @EntityID AND TeamTypeID IN (4, 5, 7, 9, 10, 11, 12) " + "\r\n";

            queryString = queryString + "           END " + "\r\n";

            queryString = queryString + "       ELSE " + "\r\n"; //(@SaveRelativeOption = -1) 
            queryString = queryString + "           DELETE      TeamTeams WHERE TeamID = @EntityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("TeamSaveRelative", queryString);
        }


        private void TeamEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = TeamID FROM Teams WHERE TeamID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = TeamID FROM GoodsIssueDetails WHERE TeamID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("TeamEditable", queryArray);
        }


        private void GetTeamBases()
        {
            string queryString;

            queryString = " " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      TeamID, Code, Name " + "\r\n";
            queryString = queryString + "       FROM        Teams " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetTeamBases", queryString);
        }

        private void GetTeamTrees()
        {
            string queryString;

            queryString = " " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      " + GlobalEnums.RootNode + " AS NodeID, 0 AS ParentNodeID, NULL AS PrimaryID, NULL AS AncestorID, '[All]' AS Code, NULL AS Name, NULL AS ParameterName, CAST(1 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       UNION ALL " + "\r\n";
            queryString = queryString + "       SELECT      " + GlobalEnums.AncestorNode + " + TeamID AS NodeID, " + GlobalEnums.RootNode + " + 0 AS ParentNodeID, TeamID AS PrimaryID, NULL AS AncestorID, Name AS Code, N'' AS Name, 'TeamID' AS ParameterName, CAST(0 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       FROM        Teams " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetTeamTrees", queryString);
        }
    }
}
