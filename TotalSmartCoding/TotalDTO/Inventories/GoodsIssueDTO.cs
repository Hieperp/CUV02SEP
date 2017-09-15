using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Equin.ApplicationFramework;

using TotalModel;
using TotalBase.Enums;
using TotalDTO.Helpers;
using TotalDTO.Commons;

namespace TotalDTO.Inventories
{
    public class GoodsIssuePrimitiveDTO : QuantityDTO<GoodsIssueDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.GoodsIssue; } }

        public override int GetID() { return this.GoodsIssueID; }
        public void SetID(int id) { this.GoodsIssueID = id; }

        private int goodsIssueID;
        [DefaultValue(0)]
        public int GoodsIssueID
        {
            get { return this.goodsIssueID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, int>(ref this.goodsIssueID, o => o.GoodsIssueID, value); }
        }



        private Nullable<int> deliveryAdviceID;
        [DefaultValue(null)]
        public Nullable<int> DeliveryAdviceID
        {
            get { return this.deliveryAdviceID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, Nullable<int>>(ref this.deliveryAdviceID, o => o.DeliveryAdviceID, value); }
        }
        public string DeliveryAdviceReferences { get; set; }


        private int customerID;
        [DefaultValue(null)]
        public int CustomerID
        {
            get { return this.customerID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, int>(ref this.customerID, o => o.CustomerID, value); }
        }
        private string customerName;
        [DefaultValue("")]
        public string CustomerName
        {
            get { return this.customerName; }
            set { ApplyPropertyChange<GoodsIssueDTO, string>(ref this.customerName, o => o.CustomerName, value); }
        }


        private int storekeeperID;
        [DefaultValue(1)]
        public int StorekeeperID
        {
            get { return this.storekeeperID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, int>(ref this.storekeeperID, o => o.StorekeeperID, value); }
        }


        public override int PreparedPersonID { get { return 1; } }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            string deliveryAdviceReferences = "";
            this.DtoDetails().ToList().ForEach(e => { e.CustomerID = this.CustomerID; if (deliveryAdviceReferences.IndexOf(e.DeliveryAdviceReference) < 0) deliveryAdviceReferences = deliveryAdviceReferences + (deliveryAdviceReferences != "" ? ", " : "") + e.DeliveryAdviceReference; });
            this.DeliveryAdviceReferences = deliveryAdviceReferences;
        }
    }

    public class GoodsIssueDTO : GoodsIssuePrimitiveDTO, IBaseDetailEntity<GoodsIssueDetailDTO>
    {
        public GoodsIssueDTO()
        {
            this.GoodsIssueViewDetails = new BindingList<GoodsIssueDetailDTO>();






            this.PackDetails = new BindingListView<GoodsIssueDetailDTO>(this.GoodsIssueViewDetails);
            this.CartonDetails = new BindingListView<GoodsIssueDetailDTO>(this.GoodsIssueViewDetails);
            this.PalletDetails = new BindingListView<GoodsIssueDetailDTO>(this.GoodsIssueViewDetails);

            this.PalletDetails.ApplyFilter(f => f.PackID != null);
            this.PalletDetails.ApplyFilter(f => f.CartonID != null);
            this.PalletDetails.ApplyFilter(f => f.PalletID != null);
        }


        public BindingList<GoodsIssueDetailDTO> GoodsIssueViewDetails { get; set; }
        public BindingList<GoodsIssueDetailDTO> ViewDetails { get { return this.GoodsIssueViewDetails; } set { this.GoodsIssueViewDetails = value; } }

        public ICollection<GoodsIssueDetailDTO> GetDetails() { return this.GoodsIssueViewDetails; }

        protected override IEnumerable<GoodsIssueDetailDTO> DtoDetails() { return this.GoodsIssueViewDetails; }






        public BindingListView<GoodsIssueDetailDTO> PackDetails { get; private set; }
        public BindingListView<GoodsIssueDetailDTO> CartonDetails { get; private set; }
        public BindingListView<GoodsIssueDetailDTO> PalletDetails { get; private set; }

    }

}
