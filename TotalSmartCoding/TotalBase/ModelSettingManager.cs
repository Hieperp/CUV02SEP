﻿using TotalBase.Enums;

namespace TotalBase
{

    public static class ModelSettingManager
    {

        public static int ReferenceLength = 6;
        public static string ReferencePrefix(GlobalEnums.NmvnTaskID nmvnTaskID)
        {
            switch (nmvnTaskID)
            {
                case GlobalEnums.NmvnTaskID.Batch:
                    return "FI";

                case GlobalEnums.NmvnTaskID.PurchaseOrder:
                    return "D";
                case GlobalEnums.NmvnTaskID.PurchaseInvoice:
                    return "H";

                case GlobalEnums.NmvnTaskID.Pickup:
                    return "P";
                case GlobalEnums.NmvnTaskID.GoodsReceipt:
                    return "R";
                case GlobalEnums.NmvnTaskID.SalesOrder:
                    return "O";
                case GlobalEnums.NmvnTaskID.DeliveryAdvices:
                    return "D";
                case GlobalEnums.NmvnTaskID.SalesReturn:
                    return "SR";

                case GlobalEnums.NmvnTaskID.GoodsIssues:
                    return "K";
                case GlobalEnums.NmvnTaskID.TransferOrder:
                    return "TO";
                case GlobalEnums.NmvnTaskID.WarehouseAdjustment:
                    return "WA";


                case GlobalEnums.NmvnTaskID.Forecast:
                    return "FC";
                case GlobalEnums.NmvnTaskID.CommoditySetting:
                    return "Z";

                default:
                    return "A";
            }


        }
    }
}
