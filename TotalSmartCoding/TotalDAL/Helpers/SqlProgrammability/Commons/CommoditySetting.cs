﻿using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class CommoditySetting
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public CommoditySetting(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetCommoditySettingIndexes();

            this.CommoditySettingEditable();
            this.CommoditySettingInitReference();
        }

        private void GetCommoditySettingIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      CommoditySettings.CommoditySettingID, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, CommodityCategories.CommodityCategoryID, CommodityCategories.Name AS CommodityCategoryName, Commodities.PackageSize, Commodities.PackageVolume, CommoditySettings.LowDSI1, CommoditySettings.HighDSI1, CommoditySettings.AlertDSI1, CommoditySettings.LowDSI2, CommoditySettings.HighDSI2, CommoditySettings.AlertDSI2, CommoditySettings.LowDSI3, CommoditySettings.HighDSI3, CommoditySettings.AlertDSI3, CommoditySettings.LowDSI4, CommoditySettings.HighDSI4, CommoditySettings.AlertDSI4 " + "\r\n";
            queryString = queryString + "       FROM        ( " + "\r\n";
            queryString = queryString + "                   SELECT  CommoditySettingID, MIN(CommodityID) AS CommodityID, SUM(LowDSI1) AS LowDSI1, SUM(HighDSI1) AS HighDSI1, SUM(AlertDSI1) AS AlertDSI1, SUM(LowDSI2) AS LowDSI2, SUM(HighDSI2) AS HighDSI2, SUM(AlertDSI2) AS AlertDSI2, SUM(LowDSI3) AS LowDSI3, SUM(HighDSI3) AS HighDSI3, SUM(AlertDSI3) AS AlertDSI3, SUM(LowDSI4) AS LowDSI4, SUM(HighDSI4) AS HighDSI4, SUM(AlertDSI4) AS AlertDSI4 " + "\r\n";
            queryString = queryString + "                   FROM    ( " + "\r\n";
            queryString = queryString + "                           SELECT          CommoditySettingID, CommodityID, LowDSI AS LowDSI1, HighDSI AS HighDSI1, AlertDSI AS AlertDSI1, 0 AS LowDSI2, 0 AS HighDSI2, 0 AS AlertDSI2, 0 AS LowDSI3, 0 AS HighDSI3, 0 AS AlertDSI3, 0 AS LowDSI4, 0 AS HighDSI4, 0 AS AlertDSI4 " + "\r\n";
            queryString = queryString + "                           FROM            CommoditySettingDetails " + "\r\n";
            queryString = queryString + "                           WHERE           LocationID = 1 " + "\r\n";

            queryString = queryString + "                           UNION ALL " + "\r\n";

            queryString = queryString + "                           SELECT          CommoditySettingID, CommodityID, 0 AS LowDSI1, 0 AS HighDSI1, 0 AS AlertDSI1, LowDSI AS LowDSI2, HighDSI AS HighDSI2, AlertDSI AS AlertDSI2, 0 AS LowDSI3, 0 AS HighDSI3, 0 AS AlertDSI3, 0 AS LowDSI4, 0 AS HighDSI4, 0 AS AlertDSI4 " + "\r\n";
            queryString = queryString + "                           FROM            CommoditySettingDetails " + "\r\n";
            queryString = queryString + "                           WHERE           LocationID = 2 " + "\r\n";

            queryString = queryString + "                           UNION ALL " + "\r\n";

            queryString = queryString + "                           SELECT          CommoditySettingID, CommodityID, 0 AS LowDSI1, 0 AS HighDSI1, 0 AS AlertDSI1, 0 AS LowDSI2, 0 AS HighDSI2, 0 AS AlertDSI2, LowDSI AS LowDSI3, HighDSI AS HighDSI3, AlertDSI AS AlertDSI3, 0 AS LowDSI4, 0 AS HighDSI4, 0 AS AlertDSI4 " + "\r\n";
            queryString = queryString + "                           FROM            CommoditySettingDetails " + "\r\n";
            queryString = queryString + "                           WHERE           LocationID = 3 " + "\r\n";

            queryString = queryString + "                           UNION ALL " + "\r\n";

            queryString = queryString + "                           SELECT          CommoditySettingID, CommodityID, 0 AS LowDSI1, 0 AS HighDSI1, 0 AS AlertDSI1, 0 AS LowDSI2, 0 AS HighDSI2, 0 AS AlertDSI2, 0 AS LowDSI3, 0 AS HighDSI3, 0 AS AlertDSI3, LowDSI AS LowDSI4, HighDSI AS HighDSI4, AlertDSI AS AlertDSI4 " + "\r\n";
            queryString = queryString + "                           FROM            CommoditySettingDetails " + "\r\n";
            queryString = queryString + "                           WHERE           LocationID = 4 " + "\r\n";
            queryString = queryString + "                           ) AS ABC " + "\r\n";
            queryString = queryString + "                   GROUP BY CommoditySettingID " + "\r\n";

            queryString = queryString + "                   ) AS CommoditySettings INNER JOIN Commodities ON CommoditySettings.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN CommodityCategories ON Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetCommoditySettingIndexes", queryString);
        }

        private void CommoditySettingEditable()
        {
            string[] queryArray = new string[0];

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("CommoditySettingEditable", queryArray);
        }


        private void CommoditySettingInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("CommoditySettings", "CommoditySettingID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.CommoditySetting));
            this.totalSmartCodingEntities.CreateTrigger("CommoditySettingInitReference", simpleInitReference.CreateQuery());
        }

    }
}
