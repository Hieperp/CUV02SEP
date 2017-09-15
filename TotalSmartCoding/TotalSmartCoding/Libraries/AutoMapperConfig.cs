﻿using System;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;

using TotalModel.Models;

using TotalDTO.Commons;
using TotalDTO.Productions;
using TotalDTO.Sales;
using TotalDTO.Inventories;

using TotalSmartCoding.ViewModels.Productions;
using TotalSmartCoding.ViewModels.Sales;
using TotalSmartCoding.ViewModels.Inventories;

namespace TotalSmartCoding.Libraries
{
    public static class AutoMapperConfig
    {
        public static void SetupMappings()
        {
            ////////https://github.com/AutoMapper/AutoMapper/wiki/Static-and-Instance-API

            Mapper.Initialize(cfg =>
            {
               



                cfg.CreateMap<Pickup, PickupViewModel>();
                cfg.CreateMap<Pickup, PickupDTO>();
                cfg.CreateMap<PickupPrimitiveDTO, Pickup>();
                cfg.CreateMap<PickupViewDetail, PickupDetailDTO>();
                cfg.CreateMap<PickupDetailDTO, PickupDetail>();

                cfg.CreateMap<GoodsReceipt, GoodsReceiptViewModel>();
                cfg.CreateMap<GoodsReceipt, GoodsReceiptDTO>();
                cfg.CreateMap<GoodsReceiptPrimitiveDTO, GoodsReceipt>();
                cfg.CreateMap<GoodsReceiptViewDetail, GoodsReceiptDetailDTO>();
                cfg.CreateMap<GoodsReceiptDetailDTO, GoodsReceiptDetail>();


                cfg.CreateMap<SalesOrder, SalesOrderViewModel>();
                cfg.CreateMap<SalesOrder, SalesOrderDTO>();
                cfg.CreateMap<SalesOrderPrimitiveDTO, SalesOrder>();
                cfg.CreateMap<SalesOrderViewDetail, SalesOrderDetailDTO>();
                cfg.CreateMap<SalesOrderDetailDTO, SalesOrderDetail>();


                cfg.CreateMap<DeliveryAdvice, DeliveryAdviceViewModel>();
                cfg.CreateMap<DeliveryAdvice, DeliveryAdviceDTO>();
                cfg.CreateMap<DeliveryAdvicePrimitiveDTO, DeliveryAdvice>();
                cfg.CreateMap<DeliveryAdviceViewDetail, DeliveryAdviceDetailDTO>();
                cfg.CreateMap<DeliveryAdviceDetailDTO, DeliveryAdviceDetail>();








                cfg.CreateMap<Batch, BatchViewModel>();
                cfg.CreateMap<Batch, BatchDTO>();
                cfg.CreateMap<BatchPrimitiveDTO, Batch>();

                cfg.CreateMap<BatchIndex, FillingData>();
                


                cfg.CreateMap<Pack, PackViewModel>();
                cfg.CreateMap<Pack, PackDTO>();
                cfg.CreateMap<PackPrimitiveDTO, Pack>();


                cfg.CreateMap<Carton, CartonViewModel>();
                cfg.CreateMap<Carton, CartonDTO>();
                cfg.CreateMap<CartonPrimitiveDTO, Carton>();


                cfg.CreateMap<Pallet, PalletViewModel>();
                cfg.CreateMap<Pallet, PalletDTO>();
                cfg.CreateMap<PalletPrimitiveDTO, Pallet>();



                //cfg.CreateMap<Employee, EmployeeBaseDTO>();
                cfg.CreateMap<Customer, CustomerBaseDTO>();
                cfg.CreateMap<Warehouse, WarehouseBaseDTO>();
            });
        }
    }
}