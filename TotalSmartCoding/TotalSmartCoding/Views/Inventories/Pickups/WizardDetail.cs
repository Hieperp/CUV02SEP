using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BrightIdeasSoftware;

using Ninject;

using TotalModel.Models;
using TotalDTO.Inventories;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Inventories;
using TotalBase;
using TotalCore.Repositories.Commons;
using System.ComponentModel;
using TotalDTO.Helpers.Interfaces;



namespace TotalSmartCoding.Views.Inventories.Pickups
{
    public partial class WizardDetail : Form, IToolstripMerge, IToolstripTablet
    {
        private CustomTabControl tabBinLocation;
        public virtual ToolStrip toolstripChild { get; protected set; }

        private ILineDetailBinlLocation pickupDetailDTO;

        Binding bindingCodeID;
        Binding bindingCommodityCodeAndName;
        Binding bindingBinLocationCode;
        Binding bindingQuantity;
        Binding bindingLineVolume;

        public WizardDetail(ILineDetailBinlLocation pickupDetailDTO)
        {
            InitializeComponent();

            this.toolstripChild = this.toolStripAction;
            this.tabBinLocation = new CustomTabControl();
            this.tabBinLocation.DisplayStyle = TabStyle.VisualStudio;

            this.tabBinLocation.TabPages.Add("tabBinLocations", "Available Bin Location   ");
            this.tabBinLocation.TabPages[0].Controls.Add(this.fastBinLocations);

            this.tabBinLocation.Dock = DockStyle.Fill;
            this.fastBinLocations.Dock = DockStyle.Fill;
            this.splitContainerCenter.Panel2.Controls.Add(this.tabBinLocation);

            if (GlobalVariables.ConfigID == (int)GlobalVariables.FillingLine.Pickup) ViewHelpers.SetFont(this, new Font("Calibri", 11), new Font("Calibri", 11), new Font("Calibri", 11));

            this.splitContainerCenter.SplitterDistance = this.textexCode.Height + this.textexCommodityCodeAndName.Height + this.textexQuantity.Height + this.textexLineVolume.Height + this.textexBinLocationCode.Height + 5 * 5 + 15;

            this.pickupDetailDTO = pickupDetailDTO;
        }

        private void WizardDetail_Load(object sender, EventArgs e)
        {
            try
            {
                this.pickupDetailDTO.PropertyChanged += pickupDetailDTO_PropertyChanged;

                this.bindingCodeID = this.textexCode.DataBindings.Add("Text", this.pickupDetailDTO, CommonExpressions.PropertyName<ILineDetailBinlLocation>(p => p.BarcodeCode));
                this.bindingCommodityCodeAndName = this.textexCommodityCodeAndName.DataBindings.Add("Text", this.pickupDetailDTO, CommonExpressions.PropertyName<ILineDetailBinlLocation>(p => p.CommodityCodeAndName));
                this.bindingBinLocationCode = this.textexBinLocationCode.DataBindings.Add("Text", this.pickupDetailDTO, CommonExpressions.PropertyName<ILineDetailBinlLocation>(p => p.BinLocationCode));
                this.bindingQuantity = this.textexQuantity.DataBindings.Add("Text", this.pickupDetailDTO, CommonExpressions.PropertyName<ILineDetailBinlLocation>(p => p.Quantity));
                this.bindingLineVolume = this.textexLineVolume.DataBindings.Add("Text", this.pickupDetailDTO, CommonExpressions.PropertyName<ILineDetailBinlLocation>(p => p.LineVolume));

                this.fastBinLocations.SetObjects((new BinLocationAPIs(CommonNinject.Kernel.Get<IBinLocationAPIRepository>())).GetBinLocationBases(this.pickupDetailDTO.WarehouseID));
                this.ShowRowCount();

                this.bindingCodeID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingCommodityCodeAndName.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingBinLocationCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingQuantity.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingLineVolume.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.errorProviderMaster.DataSource = this.pickupDetailDTO;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void pickupDetailDTO_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.buttonAdd.Enabled = this.pickupDetailDTO.IsValid;
        }

        private void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState == BindingCompleteState.Exception) { ExceptionHandlers.ShowExceptionMessageBox(this, e.ErrorText); e.Cancel = true; }
        }

        private void fastBinLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.fastBinLocations.SelectedObject != null)
            {
                BinLocationBase baseIndex = (BinLocationBase)this.fastBinLocations.SelectedObject;
                if (baseIndex != null) { this.pickupDetailDTO.BinLocationID = baseIndex.BinLocationID; this.pickupDetailDTO.BinLocationCode = baseIndex.Code; } else { this.pickupDetailDTO.BinLocationID = null; this.pickupDetailDTO.BinLocationCode = ""; };
            }
            else { this.pickupDetailDTO.BinLocationID = null; this.pickupDetailDTO.BinLocationCode = ""; };
        }

        public void ApplyFilter(string filterTexts)
        {
            this.fastBinLocations.SelectedObject = null;
            OLVHelpers.ApplyFilters(this.fastBinLocations, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            this.ShowRowCount();
        }

        private void ShowRowCount()
        {
            this.tabBinLocation.TabPages[0].Text = "Available " + this.fastBinLocations.GetItemCount().ToString("N0") + " Bin" + (this.fastBinLocations.GetItemCount() > 1 ? "s" : "") + "        ";
        }

        private void buttonAddESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonAdd) && this.pickupDetailDTO.IsValid)
                    this.MdiParent.DialogResult = DialogResult.OK;

                if (sender.Equals(this.buttonESC))
                    this.MdiParent.DialogResult = DialogResult.Cancel;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void fastBinLocations_DoubleClick(object sender, EventArgs e)
        {
            if (this.buttonAdd.Enabled)
                this.buttonAddESC_Click(this.buttonAdd, new EventArgs());
        }

    }
}
