using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.delivery{
	
	
	public class JitDeliveryServiceHelper {
		
		
		
		public class confirmDelivery_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 入库单编号
			///</summary>
			
			private string storage_no_;
			
			///<summary>
			/// PO订单号
			///</summary>
			
			private string po_no_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetStorage_no(){
				return this.storage_no_;
			}
			
			public void SetStorage_no(string value){
				this.storage_no_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			
		}
		
		
		
		
		public class createDelivery_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// po号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 送货单编号
			///</summary>
			
			private string delivery_no_;
			
			///<summary>
			/// 送货仓库
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 送货时间
			///</summary>
			
			private string delivery_time_;
			
			///<summary>
			/// 预计到货时间
			///</summary>
			
			private string arrival_time_;
			
			///<summary>
			/// 预计收货时间
			///</summary>
			
			private string race_time_;
			
			///<summary>
			/// 承运商名称
			///</summary>
			
			private string carrier_name_;
			
			///<summary>
			/// 联系电话
			///</summary>
			
			private string tel_;
			
			///<summary>
			/// 司机姓名
			///</summary>
			
			private string driver_;
			
			///<summary>
			/// 司机联系电话
			///</summary>
			
			private string driver_tel_;
			
			///<summary>
			/// 车牌号
			///</summary>
			
			private string plate_number_;
			
			///<summary>
			/// 页码
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数(如果超过100,也只返回100条记录)
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetDelivery_no(){
				return this.delivery_no_;
			}
			
			public void SetDelivery_no(string value){
				this.delivery_no_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetDelivery_time(){
				return this.delivery_time_;
			}
			
			public void SetDelivery_time(string value){
				this.delivery_time_ = value;
			}
			public string GetArrival_time(){
				return this.arrival_time_;
			}
			
			public void SetArrival_time(string value){
				this.arrival_time_ = value;
			}
			public string GetRace_time(){
				return this.race_time_;
			}
			
			public void SetRace_time(string value){
				this.race_time_ = value;
			}
			public string GetCarrier_name(){
				return this.carrier_name_;
			}
			
			public void SetCarrier_name(string value){
				this.carrier_name_ = value;
			}
			public string GetTel(){
				return this.tel_;
			}
			
			public void SetTel(string value){
				this.tel_ = value;
			}
			public string GetDriver(){
				return this.driver_;
			}
			
			public void SetDriver(string value){
				this.driver_ = value;
			}
			public string GetDriver_tel(){
				return this.driver_tel_;
			}
			
			public void SetDriver_tel(string value){
				this.driver_tel_ = value;
			}
			public string GetPlate_number(){
				return this.plate_number_;
			}
			
			public void SetPlate_number(string value){
				this.plate_number_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class createPick_args {
			
			///<summary>
			/// PO单编号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			
		}
		
		
		
		
		public class deleteDeliveryDetail_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 入库单编号
			///</summary>
			
			private string storage_no_;
			
			///<summary>
			/// PO订单号
			///</summary>
			
			private string po_no_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetStorage_no(){
				return this.storage_no_;
			}
			
			public void SetStorage_no(string value){
				this.storage_no_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			
		}
		
		
		
		
		public class editDelivery_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 入库单编号
			///</summary>
			
			private string storage_no_;
			
			///<summary>
			/// 送货单编号
			///</summary>
			
			private string delivery_no_;
			
			///<summary>
			/// 送货仓库
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 送货时间
			///</summary>
			
			private string delivery_time_;
			
			///<summary>
			/// 预计到货时间
			///</summary>
			
			private string arrival_time_;
			
			///<summary>
			/// 预计收货时间
			///</summary>
			
			private string race_time_;
			
			///<summary>
			/// 承运商名称
			///</summary>
			
			private string carrier_name_;
			
			///<summary>
			/// 联系电话
			///</summary>
			
			private string tel_;
			
			///<summary>
			/// 司机姓名
			///</summary>
			
			private string driver_;
			
			///<summary>
			/// 司机联系电话
			///</summary>
			
			private string driver_tel_;
			
			///<summary>
			/// 车牌号
			///</summary>
			
			private string plate_number_;
			
			///<summary>
			/// 页码
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数(如果超过100,也只返回100条记录)
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetStorage_no(){
				return this.storage_no_;
			}
			
			public void SetStorage_no(string value){
				this.storage_no_ = value;
			}
			public string GetDelivery_no(){
				return this.delivery_no_;
			}
			
			public void SetDelivery_no(string value){
				this.delivery_no_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetDelivery_time(){
				return this.delivery_time_;
			}
			
			public void SetDelivery_time(string value){
				this.delivery_time_ = value;
			}
			public string GetArrival_time(){
				return this.arrival_time_;
			}
			
			public void SetArrival_time(string value){
				this.arrival_time_ = value;
			}
			public string GetRace_time(){
				return this.race_time_;
			}
			
			public void SetRace_time(string value){
				this.race_time_ = value;
			}
			public string GetCarrier_name(){
				return this.carrier_name_;
			}
			
			public void SetCarrier_name(string value){
				this.carrier_name_ = value;
			}
			public string GetTel(){
				return this.tel_;
			}
			
			public void SetTel(string value){
				this.tel_ = value;
			}
			public string GetDriver(){
				return this.driver_;
			}
			
			public void SetDriver(string value){
				this.driver_ = value;
			}
			public string GetDriver_tel(){
				return this.driver_tel_;
			}
			
			public void SetDriver_tel(string value){
				this.driver_tel_ = value;
			}
			public string GetPlate_number(){
				return this.plate_number_;
			}
			
			public void SetPlate_number(string value){
				this.plate_number_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryGoods_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 入库单号
			///</summary>
			
			private string storage_no_;
			
			///<summary>
			/// 页码参数
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 返回结果数量(默认为50,最大支持100)
			/// @sampleValue limit limit=50
			///</summary>
			
			private int? limit_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public string GetStorage_no(){
				return this.storage_no_;
			}
			
			public void SetStorage_no(string value){
				this.storage_no_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryList_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// PO单号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 送货单号
			///</summary>
			
			private string delivery_no_;
			
			///<summary>
			/// 送货仓库
			/// @sampleValue warehouse warehouse=VIP_NH
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 送货状态(0=未出仓,1=已出仓)
			///</summary>
			
			private string out_flag_;
			
			///<summary>
			/// 送货时间(开始时间,格式'yyyy-MM-dd HH:mm:ss')
			/// @sampleValue st_out_time st_out_time=2014-07-15 10:24:45
			///</summary>
			
			private string st_out_time_;
			
			///<summary>
			/// 送货时间(结束时间,格式'yyyy-MM-dd HH:mm:ss')
			/// @sampleValue et_out_time et_out_time=2014-07-15 10:24:45
			///</summary>
			
			private string et_out_time_;
			
			///<summary>
			/// 预计到货时间(开始时间,格式'yyyy-MM-dd HH:mm:ss')
			/// @sampleValue st_estimate_arrive_time st_estimate_arrive_time=2014-07-18 10:24:45
			///</summary>
			
			private string st_estimate_arrive_time_;
			
			///<summary>
			/// 预计到货时间(结束时间,格式'yyyy-MM-dd HH:mm:ss')
			/// @sampleValue et_estimate_arrive_time et_estimate_arrive_time=2014-07-18 10:24:45
			///</summary>
			
			private string et_estimate_arrive_time_;
			
			///<summary>
			/// 实际到货时间(开始时间,格式'yyyy-MM-dd HH:mm:ss')
			/// @sampleValue st_arrive_time st_arrive_time=2014-07-17 10:24:45
			///</summary>
			
			private string st_arrive_time_;
			
			///<summary>
			/// 实际到货时间(结束时间,格式'yyyy-MM-dd HH:mm:ss')
			/// @sampleValue et_arrive_time et_arrive_time=2014-07-17 10:24:45
			///</summary>
			
			private string et_arrive_time_;
			
			///<summary>
			/// 页码参数
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 返回结果数量(默认为50,最大支持100)
			/// @sampleValue limit limit=50
			///</summary>
			
			private int? limit_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetDelivery_no(){
				return this.delivery_no_;
			}
			
			public void SetDelivery_no(string value){
				this.delivery_no_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetOut_flag(){
				return this.out_flag_;
			}
			
			public void SetOut_flag(string value){
				this.out_flag_ = value;
			}
			public string GetSt_out_time(){
				return this.st_out_time_;
			}
			
			public void SetSt_out_time(string value){
				this.st_out_time_ = value;
			}
			public string GetEt_out_time(){
				return this.et_out_time_;
			}
			
			public void SetEt_out_time(string value){
				this.et_out_time_ = value;
			}
			public string GetSt_estimate_arrive_time(){
				return this.st_estimate_arrive_time_;
			}
			
			public void SetSt_estimate_arrive_time(string value){
				this.st_estimate_arrive_time_ = value;
			}
			public string GetEt_estimate_arrive_time(){
				return this.et_estimate_arrive_time_;
			}
			
			public void SetEt_estimate_arrive_time(string value){
				this.et_estimate_arrive_time_ = value;
			}
			public string GetSt_arrive_time(){
				return this.st_arrive_time_;
			}
			
			public void SetSt_arrive_time(string value){
				this.st_arrive_time_ = value;
			}
			public string GetEt_arrive_time(){
				return this.et_arrive_time_;
			}
			
			public void SetEt_arrive_time(string value){
				this.et_arrive_time_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getPickDetail_args {
			
			///<summary>
			/// PO单编号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 拣货单编号
			///</summary>
			
			private string pick_no_;
			
			///<summary>
			/// 页码参数
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录条数，默认50，最大100
			///</summary>
			
			private int? limit_;
			
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetPick_no(){
				return this.pick_no_;
			}
			
			public void SetPick_no(string value){
				this.pick_no_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getPickList_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// PO订单号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 拣货单编号
			///</summary>
			
			private string pick_no_;
			
			///<summary>
			/// 售卖站点
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 合作模式
			///</summary>
			
			private string co_mode_;
			
			///<summary>
			/// 订单类别
			///</summary>
			
			private string order_cate_;
			
			///<summary>
			/// 开始创建日期
			///</summary>
			
			private string st_create_time_;
			
			///<summary>
			/// 结束创建日期
			///</summary>
			
			private string et_create_time_;
			
			///<summary>
			/// 开始开售日期
			///</summary>
			
			private string st_sell_time_from_;
			
			///<summary>
			/// 结束开售日期
			///</summary>
			
			private string et_sell_time_from_;
			
			///<summary>
			/// 开始停售日期
			///</summary>
			
			private string st_sell_time_to_;
			
			///<summary>
			/// 结束停售日期
			///</summary>
			
			private string et_sell_time_to_;
			
			///<summary>
			/// 导出状态
			///</summary>
			
			private int? is_export_;
			
			///<summary>
			/// 页码
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数(如果超过100,也只返回100条记录)
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetPick_no(){
				return this.pick_no_;
			}
			
			public void SetPick_no(string value){
				this.pick_no_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetCo_mode(){
				return this.co_mode_;
			}
			
			public void SetCo_mode(string value){
				this.co_mode_ = value;
			}
			public string GetOrder_cate(){
				return this.order_cate_;
			}
			
			public void SetOrder_cate(string value){
				this.order_cate_ = value;
			}
			public string GetSt_create_time(){
				return this.st_create_time_;
			}
			
			public void SetSt_create_time(string value){
				this.st_create_time_ = value;
			}
			public string GetEt_create_time(){
				return this.et_create_time_;
			}
			
			public void SetEt_create_time(string value){
				this.et_create_time_ = value;
			}
			public string GetSt_sell_time_from(){
				return this.st_sell_time_from_;
			}
			
			public void SetSt_sell_time_from(string value){
				this.st_sell_time_from_ = value;
			}
			public string GetEt_sell_time_from(){
				return this.et_sell_time_from_;
			}
			
			public void SetEt_sell_time_from(string value){
				this.et_sell_time_from_ = value;
			}
			public string GetSt_sell_time_to(){
				return this.st_sell_time_to_;
			}
			
			public void SetSt_sell_time_to(string value){
				this.st_sell_time_to_ = value;
			}
			public string GetEt_sell_time_to(){
				return this.et_sell_time_to_;
			}
			
			public void SetEt_sell_time_to(string value){
				this.et_sell_time_to_ = value;
			}
			public int? GetIs_export(){
				return this.is_export_;
			}
			
			public void SetIs_export(int? value){
				this.is_export_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getPoList_args {
			
			///<summary>
			/// 开始查询的创建时间(格式为yyyy-MM-dd HH:mm:ss)
			/// @sampleValue st_create_time st_create_time=2014-06-18 00:00:00
			///</summary>
			
			private string st_create_time_;
			
			///<summary>
			/// 结束查询的创建时间(格式为yyyy-MM-dd HH:mm:ss)
			/// @sampleValue et_create_time et_create_time=2014-06-20 00:00:00
			///</summary>
			
			private string et_create_time_;
			
			///<summary>
			/// 仓库/销售地区
			/// @sampleValue warehouse warehouse=VIP_NH
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// po号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 合作模式
			///</summary>
			
			private string co_mode_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 开始查询的的销售开始时间(格式为yyyy-MM-dd HH:mm:ss)
			/// @sampleValue st_sell_st_time st_sell_st_time=2014-07-18 00:00:00
			///</summary>
			
			private string st_sell_st_time_;
			
			///<summary>
			/// 结束查询的销售开始时间(格式为yyyy-MM-dd HH:mm:ss)
			/// @sampleValue et_sell_st_time et_sell_st_time=2014-07-20 00:00:00
			///</summary>
			
			private string et_sell_st_time_;
			
			///<summary>
			/// 开始查询的销售结束时间(格式为yyyy-MM-dd HH:mm:ss)
			/// @sampleValue st_sell_et_time st_sell_et_time=2014-08-18 00:00:00
			///</summary>
			
			private string st_sell_et_time_;
			
			///<summary>
			/// 结束查询的销售结束时间(格式为yyyy-MM-dd HH:mm:ss)
			/// @sampleValue et_sell_et_time et_sell_et_time=2014-08-20 00:00:00
			///</summary>
			
			private string et_sell_et_time_;
			
			///<summary>
			/// 页码参数
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 返回结果数量(默认为50,最大支持100)
			/// @sampleValue limit limit=50
			///</summary>
			
			private int? limit_;
			
			public string GetSt_create_time(){
				return this.st_create_time_;
			}
			
			public void SetSt_create_time(string value){
				this.st_create_time_ = value;
			}
			public string GetEt_create_time(){
				return this.et_create_time_;
			}
			
			public void SetEt_create_time(string value){
				this.et_create_time_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetCo_mode(){
				return this.co_mode_;
			}
			
			public void SetCo_mode(string value){
				this.co_mode_ = value;
			}
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public string GetSt_sell_st_time(){
				return this.st_sell_st_time_;
			}
			
			public void SetSt_sell_st_time(string value){
				this.st_sell_st_time_ = value;
			}
			public string GetEt_sell_st_time(){
				return this.et_sell_st_time_;
			}
			
			public void SetEt_sell_st_time(string value){
				this.et_sell_st_time_ = value;
			}
			public string GetSt_sell_et_time(){
				return this.st_sell_et_time_;
			}
			
			public void SetSt_sell_et_time(string value){
				this.st_sell_et_time_ = value;
			}
			public string GetEt_sell_et_time(){
				return this.et_sell_et_time_;
			}
			
			public void SetEt_sell_et_time(string value){
				this.et_sell_et_time_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getPoSkuList_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// po编号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 售卖站点
			///</summary>
			
			private string sell_site_;
			
			///<summary>
			/// 仓库/销售地区
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 订单状态
			///</summary>
			
			private string order_status_;
			
			///<summary>
			/// 开始查询的订单支付（审核）时间
			///</summary>
			
			private string st_aduity_time_;
			
			///<summary>
			/// 结束查询的订单审核（支付）时间
			///</summary>
			
			private string et_aduity_time_;
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string order_id_;
			
			///<summary>
			/// 拣货单号
			///</summary>
			
			private string pick_no_;
			
			///<summary>
			/// 送货单号
			///</summary>
			
			private string delivery_no_;
			
			///<summary>
			/// 开始查询的拣货时间
			///</summary>
			
			private string st_pick_time_;
			
			///<summary>
			/// 结束查询的拣货时间
			///</summary>
			
			private string et_pick_time_;
			
			///<summary>
			/// 开始查询的送货时间
			///</summary>
			
			private string st_delivery_time_;
			
			///<summary>
			/// 结束查询的送货时间
			///</summary>
			
			private string et_delivery_time_;
			
			///<summary>
			/// 页码
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数(如果超过100,也只返回100条记录)
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetSell_site(){
				return this.sell_site_;
			}
			
			public void SetSell_site(string value){
				this.sell_site_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetOrder_status(){
				return this.order_status_;
			}
			
			public void SetOrder_status(string value){
				this.order_status_ = value;
			}
			public string GetSt_aduity_time(){
				return this.st_aduity_time_;
			}
			
			public void SetSt_aduity_time(string value){
				this.st_aduity_time_ = value;
			}
			public string GetEt_aduity_time(){
				return this.et_aduity_time_;
			}
			
			public void SetEt_aduity_time(string value){
				this.et_aduity_time_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			public string GetPick_no(){
				return this.pick_no_;
			}
			
			public void SetPick_no(string value){
				this.pick_no_ = value;
			}
			public string GetDelivery_no(){
				return this.delivery_no_;
			}
			
			public void SetDelivery_no(string value){
				this.delivery_no_ = value;
			}
			public string GetSt_pick_time(){
				return this.st_pick_time_;
			}
			
			public void SetSt_pick_time(string value){
				this.st_pick_time_ = value;
			}
			public string GetEt_pick_time(){
				return this.et_pick_time_;
			}
			
			public void SetEt_pick_time(string value){
				this.et_pick_time_ = value;
			}
			public string GetSt_delivery_time(){
				return this.st_delivery_time_;
			}
			
			public void SetSt_delivery_time(string value){
				this.st_delivery_time_ = value;
			}
			public string GetEt_delivery_time(){
				return this.et_delivery_time_;
			}
			
			public void SetEt_delivery_time(string value){
				this.et_delivery_time_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getPrintBox_args {
			
			///<summary>
			/// 拣货单编码
			///</summary>
			
			private string pick_no_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			public string GetPick_no(){
				return this.pick_no_;
			}
			
			public void SetPick_no(string value){
				this.pick_no_ = value;
			}
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			
		}
		
		
		
		
		public class getPrintDelivery_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 入库单编号
			///</summary>
			
			private string storage_no_;
			
			///<summary>
			/// PO订单号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 供应商箱号
			///</summary>
			
			private string box_no_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetStorage_no(){
				return this.storage_no_;
			}
			
			public void SetStorage_no(string value){
				this.storage_no_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetBox_no(){
				return this.box_no_;
			}
			
			public void SetBox_no(string value){
				this.box_no_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class importDeliveryDetail_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// PO单编号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 入库单号
			///</summary>
			
			private string storage_no_;
			
			///<summary>
			/// 创建送货单返回的ID
			///</summary>
			
			private string delivery_no_;
			
			///<summary>
			/// 门店编码，OXO业务要求填写，非OXO业务不用填写
			///</summary>
			
			private string store_sn_;
			
			///<summary>
			/// 出仓产品列表
			///</summary>
			
			private List<vipapis.delivery.Delivery> delivery_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetStorage_no(){
				return this.storage_no_;
			}
			
			public void SetStorage_no(string value){
				this.storage_no_ = value;
			}
			public string GetDelivery_no(){
				return this.delivery_no_;
			}
			
			public void SetDelivery_no(string value){
				this.delivery_no_ = value;
			}
			public string GetStore_sn(){
				return this.store_sn_;
			}
			
			public void SetStore_sn(string value){
				this.store_sn_ = value;
			}
			public List<vipapis.delivery.Delivery> GetDelivery_list(){
				return this.delivery_list_;
			}
			
			public void SetDelivery_list(List<vipapis.delivery.Delivery> value){
				this.delivery_list_ = value;
			}
			
		}
		
		
		
		
		public class confirmDelivery_result {
			
			///<summary>
			/// returnCode:返回码(0 成功 , -1 失败) ; returnMessage:返回原因
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createDelivery_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.CreateDeliveryResponse success_;
			
			public vipapis.delivery.CreateDeliveryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.CreateDeliveryResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createPick_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.delivery.SimplePick> success_;
			
			public List<vipapis.delivery.SimplePick> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.delivery.SimplePick> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deleteDeliveryDetail_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.delivery.DeleteDeliveryDetail> success_;
			
			public List<vipapis.delivery.DeleteDeliveryDetail> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.delivery.DeleteDeliveryDetail> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class editDelivery_result {
			
			///<summary>
			/// returnCode:返回码(0 成功 , -1 失败) ; returnMessage:返回原因
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryGoods_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetDeliveryGoodsResponse success_;
			
			public vipapis.delivery.GetDeliveryGoodsResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetDeliveryGoodsResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetDeliveryListResponse success_;
			
			public vipapis.delivery.GetDeliveryListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetDeliveryListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPickDetail_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.PickDetail success_;
			
			public vipapis.delivery.PickDetail GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.PickDetail value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPickList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetPickListResponse success_;
			
			public vipapis.delivery.GetPickListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetPickListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPoList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetPoListResponse success_;
			
			public vipapis.delivery.GetPoListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetPoListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPoSkuList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetPoSkuListResponse success_;
			
			public vipapis.delivery.GetPoSkuListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetPoSkuListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPrintBox_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetPrintBoxResponse success_;
			
			public vipapis.delivery.GetPrintBoxResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetPrintBoxResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPrintDelivery_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetPrintDeliveryResponse success_;
			
			public vipapis.delivery.GetPrintDeliveryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetPrintDeliveryResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_result {
			
			///<summary>
			///</summary>
			
			private com.vip.hermes.core.health.CheckResult success_;
			
			public com.vip.hermes.core.health.CheckResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.hermes.core.health.CheckResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class importDeliveryDetail_result {
			
			///<summary>
			/// 入库单号
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class confirmDelivery_argsHelper : BeanSerializer<confirmDelivery_args>
		{
			
			public static confirmDelivery_argsHelper OBJ = new confirmDelivery_argsHelper();
			
			public static confirmDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorage_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetStorage_no() != null) {
					
					oprot.WriteFieldBegin("storage_no");
					oprot.WriteString(structs.GetStorage_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storage_no can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createDelivery_argsHelper : BeanSerializer<createDelivery_args>
		{
			
			public static createDelivery_argsHelper OBJ = new createDelivery_argsHelper();
			
			public static createDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDelivery_no(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDelivery_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetArrival_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetRace_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarrier_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetTel(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDriver(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDriver_tel(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPlate_number(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				if(structs.GetDelivery_no() != null) {
					
					oprot.WriteFieldBegin("delivery_no");
					oprot.WriteString(structs.GetDelivery_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("delivery_no can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetDelivery_time() != null) {
					
					oprot.WriteFieldBegin("delivery_time");
					oprot.WriteString(structs.GetDelivery_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetArrival_time() != null) {
					
					oprot.WriteFieldBegin("arrival_time");
					oprot.WriteString(structs.GetArrival_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("arrival_time can not be null!");
				}
				
				
				if(structs.GetRace_time() != null) {
					
					oprot.WriteFieldBegin("race_time");
					oprot.WriteString(structs.GetRace_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCarrier_name() != null) {
					
					oprot.WriteFieldBegin("carrier_name");
					oprot.WriteString(structs.GetCarrier_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carrier_name can not be null!");
				}
				
				
				if(structs.GetTel() != null) {
					
					oprot.WriteFieldBegin("tel");
					oprot.WriteString(structs.GetTel());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDriver() != null) {
					
					oprot.WriteFieldBegin("driver");
					oprot.WriteString(structs.GetDriver());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDriver_tel() != null) {
					
					oprot.WriteFieldBegin("driver_tel");
					oprot.WriteString(structs.GetDriver_tel());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("driver_tel can not be null!");
				}
				
				
				if(structs.GetPlate_number() != null) {
					
					oprot.WriteFieldBegin("plate_number");
					oprot.WriteString(structs.GetPlate_number());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPick_argsHelper : BeanSerializer<createPick_args>
		{
			
			public static createPick_argsHelper OBJ = new createPick_argsHelper();
			
			public static createPick_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPick_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPick_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createPick_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteDeliveryDetail_argsHelper : BeanSerializer<deleteDeliveryDetail_args>
		{
			
			public static deleteDeliveryDetail_argsHelper OBJ = new deleteDeliveryDetail_argsHelper();
			
			public static deleteDeliveryDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteDeliveryDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorage_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteDeliveryDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetStorage_no() != null) {
					
					oprot.WriteFieldBegin("storage_no");
					oprot.WriteString(structs.GetStorage_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storage_no can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteDeliveryDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editDelivery_argsHelper : BeanSerializer<editDelivery_args>
		{
			
			public static editDelivery_argsHelper OBJ = new editDelivery_argsHelper();
			
			public static editDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorage_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDelivery_no(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDelivery_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetArrival_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetRace_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarrier_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetTel(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDriver(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDriver_tel(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPlate_number(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetStorage_no() != null) {
					
					oprot.WriteFieldBegin("storage_no");
					oprot.WriteString(structs.GetStorage_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storage_no can not be null!");
				}
				
				
				if(structs.GetDelivery_no() != null) {
					
					oprot.WriteFieldBegin("delivery_no");
					oprot.WriteString(structs.GetDelivery_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("delivery_no can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetDelivery_time() != null) {
					
					oprot.WriteFieldBegin("delivery_time");
					oprot.WriteString(structs.GetDelivery_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("delivery_time can not be null!");
				}
				
				
				if(structs.GetArrival_time() != null) {
					
					oprot.WriteFieldBegin("arrival_time");
					oprot.WriteString(structs.GetArrival_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("arrival_time can not be null!");
				}
				
				
				if(structs.GetRace_time() != null) {
					
					oprot.WriteFieldBegin("race_time");
					oprot.WriteString(structs.GetRace_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("race_time can not be null!");
				}
				
				
				if(structs.GetCarrier_name() != null) {
					
					oprot.WriteFieldBegin("carrier_name");
					oprot.WriteString(structs.GetCarrier_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carrier_name can not be null!");
				}
				
				
				if(structs.GetTel() != null) {
					
					oprot.WriteFieldBegin("tel");
					oprot.WriteString(structs.GetTel());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDriver() != null) {
					
					oprot.WriteFieldBegin("driver");
					oprot.WriteString(structs.GetDriver());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDriver_tel() != null) {
					
					oprot.WriteFieldBegin("driver_tel");
					oprot.WriteString(structs.GetDriver_tel());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("driver_tel can not be null!");
				}
				
				
				if(structs.GetPlate_number() != null) {
					
					oprot.WriteFieldBegin("plate_number");
					oprot.WriteString(structs.GetPlate_number());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryGoods_argsHelper : BeanSerializer<getDeliveryGoods_args>
		{
			
			public static getDeliveryGoods_argsHelper OBJ = new getDeliveryGoods_argsHelper();
			
			public static getDeliveryGoods_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryGoods_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorage_no(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryGoods_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetStorage_no() != null) {
					
					oprot.WriteFieldBegin("storage_no");
					oprot.WriteString(structs.GetStorage_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storage_no can not be null!");
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryGoods_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryList_argsHelper : BeanSerializer<getDeliveryList_args>
		{
			
			public static getDeliveryList_argsHelper OBJ = new getDeliveryList_argsHelper();
			
			public static getDeliveryList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDelivery_no(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOut_flag(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_out_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_out_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_estimate_arrive_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_estimate_arrive_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_arrive_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_arrive_time(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDelivery_no() != null) {
					
					oprot.WriteFieldBegin("delivery_no");
					oprot.WriteString(structs.GetDelivery_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOut_flag() != null) {
					
					oprot.WriteFieldBegin("out_flag");
					oprot.WriteString(structs.GetOut_flag());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_out_time() != null) {
					
					oprot.WriteFieldBegin("st_out_time");
					oprot.WriteString(structs.GetSt_out_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_out_time() != null) {
					
					oprot.WriteFieldBegin("et_out_time");
					oprot.WriteString(structs.GetEt_out_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_estimate_arrive_time() != null) {
					
					oprot.WriteFieldBegin("st_estimate_arrive_time");
					oprot.WriteString(structs.GetSt_estimate_arrive_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_estimate_arrive_time() != null) {
					
					oprot.WriteFieldBegin("et_estimate_arrive_time");
					oprot.WriteString(structs.GetEt_estimate_arrive_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_arrive_time() != null) {
					
					oprot.WriteFieldBegin("st_arrive_time");
					oprot.WriteString(structs.GetSt_arrive_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_arrive_time() != null) {
					
					oprot.WriteFieldBegin("et_arrive_time");
					oprot.WriteString(structs.GetEt_arrive_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPickDetail_argsHelper : BeanSerializer<getPickDetail_args>
		{
			
			public static getPickDetail_argsHelper OBJ = new getPickDetail_argsHelper();
			
			public static getPickDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPickDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPick_no(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPickDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPick_no() != null) {
					
					oprot.WriteFieldBegin("pick_no");
					oprot.WriteString(structs.GetPick_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pick_no can not be null!");
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPickDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPickList_argsHelper : BeanSerializer<getPickList_args>
		{
			
			public static getPickList_argsHelper OBJ = new getPickList_argsHelper();
			
			public static getPickList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPickList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPick_no(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCo_mode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_cate(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_create_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_create_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_sell_time_from(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_sell_time_from(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_sell_time_to(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_sell_time_to(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetIs_export(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPickList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPick_no() != null) {
					
					oprot.WriteFieldBegin("pick_no");
					oprot.WriteString(structs.GetPick_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCo_mode() != null) {
					
					oprot.WriteFieldBegin("co_mode");
					oprot.WriteString(structs.GetCo_mode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrder_cate() != null) {
					
					oprot.WriteFieldBegin("order_cate");
					oprot.WriteString(structs.GetOrder_cate());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_create_time() != null) {
					
					oprot.WriteFieldBegin("st_create_time");
					oprot.WriteString(structs.GetSt_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_create_time() != null) {
					
					oprot.WriteFieldBegin("et_create_time");
					oprot.WriteString(structs.GetEt_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_sell_time_from() != null) {
					
					oprot.WriteFieldBegin("st_sell_time_from");
					oprot.WriteString(structs.GetSt_sell_time_from());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_sell_time_from() != null) {
					
					oprot.WriteFieldBegin("et_sell_time_from");
					oprot.WriteString(structs.GetEt_sell_time_from());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_sell_time_to() != null) {
					
					oprot.WriteFieldBegin("st_sell_time_to");
					oprot.WriteString(structs.GetSt_sell_time_to());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_sell_time_to() != null) {
					
					oprot.WriteFieldBegin("et_sell_time_to");
					oprot.WriteString(structs.GetEt_sell_time_to());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetIs_export() != null) {
					
					oprot.WriteFieldBegin("is_export");
					oprot.WriteI32((int)structs.GetIs_export()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPickList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoList_argsHelper : BeanSerializer<getPoList_args>
		{
			
			public static getPoList_argsHelper OBJ = new getPoList_argsHelper();
			
			public static getPoList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_create_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_create_time(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCo_mode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_sell_st_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_sell_st_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_sell_et_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_sell_et_time(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSt_create_time() != null) {
					
					oprot.WriteFieldBegin("st_create_time");
					oprot.WriteString(structs.GetSt_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_create_time() != null) {
					
					oprot.WriteFieldBegin("et_create_time");
					oprot.WriteString(structs.GetEt_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCo_mode() != null) {
					
					oprot.WriteFieldBegin("co_mode");
					oprot.WriteString(structs.GetCo_mode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetSt_sell_st_time() != null) {
					
					oprot.WriteFieldBegin("st_sell_st_time");
					oprot.WriteString(structs.GetSt_sell_st_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_sell_st_time() != null) {
					
					oprot.WriteFieldBegin("et_sell_st_time");
					oprot.WriteString(structs.GetEt_sell_st_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_sell_et_time() != null) {
					
					oprot.WriteFieldBegin("st_sell_et_time");
					oprot.WriteString(structs.GetSt_sell_et_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_sell_et_time() != null) {
					
					oprot.WriteFieldBegin("et_sell_et_time");
					oprot.WriteString(structs.GetEt_sell_et_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoSkuList_argsHelper : BeanSerializer<getPoSkuList_args>
		{
			
			public static getPoSkuList_argsHelper OBJ = new getPoSkuList_argsHelper();
			
			public static getPoSkuList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoSkuList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSell_site(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_status(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_aduity_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_aduity_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPick_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDelivery_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_pick_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_pick_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_delivery_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_delivery_time(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoSkuList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				if(structs.GetSell_site() != null) {
					
					oprot.WriteFieldBegin("sell_site");
					oprot.WriteString(structs.GetSell_site());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrder_status() != null) {
					
					oprot.WriteFieldBegin("order_status");
					oprot.WriteString(structs.GetOrder_status());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_aduity_time() != null) {
					
					oprot.WriteFieldBegin("st_aduity_time");
					oprot.WriteString(structs.GetSt_aduity_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_aduity_time() != null) {
					
					oprot.WriteFieldBegin("et_aduity_time");
					oprot.WriteString(structs.GetEt_aduity_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPick_no() != null) {
					
					oprot.WriteFieldBegin("pick_no");
					oprot.WriteString(structs.GetPick_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDelivery_no() != null) {
					
					oprot.WriteFieldBegin("delivery_no");
					oprot.WriteString(structs.GetDelivery_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_pick_time() != null) {
					
					oprot.WriteFieldBegin("st_pick_time");
					oprot.WriteString(structs.GetSt_pick_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_pick_time() != null) {
					
					oprot.WriteFieldBegin("et_pick_time");
					oprot.WriteString(structs.GetEt_pick_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_delivery_time() != null) {
					
					oprot.WriteFieldBegin("st_delivery_time");
					oprot.WriteString(structs.GetSt_delivery_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_delivery_time() != null) {
					
					oprot.WriteFieldBegin("et_delivery_time");
					oprot.WriteString(structs.GetEt_delivery_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoSkuList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrintBox_argsHelper : BeanSerializer<getPrintBox_args>
		{
			
			public static getPrintBox_argsHelper OBJ = new getPrintBox_argsHelper();
			
			public static getPrintBox_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrintBox_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPick_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrintBox_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetPick_no() != null) {
					
					oprot.WriteFieldBegin("pick_no");
					oprot.WriteString(structs.GetPick_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pick_no can not be null!");
				}
				
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrintBox_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrintDelivery_argsHelper : BeanSerializer<getPrintDelivery_args>
		{
			
			public static getPrintDelivery_argsHelper OBJ = new getPrintDelivery_argsHelper();
			
			public static getPrintDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrintDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorage_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBox_no(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrintDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetStorage_no() != null) {
					
					oprot.WriteFieldBegin("storage_no");
					oprot.WriteString(structs.GetStorage_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storage_no can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				if(structs.GetBox_no() != null) {
					
					oprot.WriteFieldBegin("box_no");
					oprot.WriteString(structs.GetBox_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrintDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : BeanSerializer<healthCheck_args>
		{
			
			public static healthCheck_argsHelper OBJ = new healthCheck_argsHelper();
			
			public static healthCheck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class importDeliveryDetail_argsHelper : BeanSerializer<importDeliveryDetail_args>
		{
			
			public static importDeliveryDetail_argsHelper OBJ = new importDeliveryDetail_argsHelper();
			
			public static importDeliveryDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(importDeliveryDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorage_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetDelivery_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStore_sn(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.delivery.Delivery> value;
					
					value = new List<vipapis.delivery.Delivery>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.delivery.Delivery elem0;
							
							elem0 = new vipapis.delivery.Delivery();
							vipapis.delivery.DeliveryHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetDelivery_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(importDeliveryDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				if(structs.GetStorage_no() != null) {
					
					oprot.WriteFieldBegin("storage_no");
					oprot.WriteString(structs.GetStorage_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storage_no can not be null!");
				}
				
				
				if(structs.GetDelivery_no() != null) {
					
					oprot.WriteFieldBegin("delivery_no");
					oprot.WriteString(structs.GetDelivery_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStore_sn() != null) {
					
					oprot.WriteFieldBegin("store_sn");
					oprot.WriteString(structs.GetStore_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDelivery_list() != null) {
					
					oprot.WriteFieldBegin("delivery_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.delivery.Delivery _item0 in structs.GetDelivery_list()){
						
						
						vipapis.delivery.DeliveryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("delivery_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(importDeliveryDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmDelivery_resultHelper : BeanSerializer<confirmDelivery_result>
		{
			
			public static confirmDelivery_resultHelper OBJ = new confirmDelivery_resultHelper();
			
			public static confirmDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmDelivery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createDelivery_resultHelper : BeanSerializer<createDelivery_result>
		{
			
			public static createDelivery_resultHelper OBJ = new createDelivery_resultHelper();
			
			public static createDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createDelivery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.CreateDeliveryResponse value;
					
					value = new vipapis.delivery.CreateDeliveryResponse();
					vipapis.delivery.CreateDeliveryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.CreateDeliveryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPick_resultHelper : BeanSerializer<createPick_result>
		{
			
			public static createPick_resultHelper OBJ = new createPick_resultHelper();
			
			public static createPick_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPick_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.delivery.SimplePick> value;
					
					value = new List<vipapis.delivery.SimplePick>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.delivery.SimplePick elem0;
							
							elem0 = new vipapis.delivery.SimplePick();
							vipapis.delivery.SimplePickHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPick_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.delivery.SimplePick _item0 in structs.GetSuccess()){
						
						
						vipapis.delivery.SimplePickHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createPick_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteDeliveryDetail_resultHelper : BeanSerializer<deleteDeliveryDetail_result>
		{
			
			public static deleteDeliveryDetail_resultHelper OBJ = new deleteDeliveryDetail_resultHelper();
			
			public static deleteDeliveryDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteDeliveryDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.delivery.DeleteDeliveryDetail> value;
					
					value = new List<vipapis.delivery.DeleteDeliveryDetail>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.delivery.DeleteDeliveryDetail elem1;
							
							elem1 = new vipapis.delivery.DeleteDeliveryDetail();
							vipapis.delivery.DeleteDeliveryDetailHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteDeliveryDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.delivery.DeleteDeliveryDetail _item0 in structs.GetSuccess()){
						
						
						vipapis.delivery.DeleteDeliveryDetailHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteDeliveryDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editDelivery_resultHelper : BeanSerializer<editDelivery_result>
		{
			
			public static editDelivery_resultHelper OBJ = new editDelivery_resultHelper();
			
			public static editDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editDelivery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryGoods_resultHelper : BeanSerializer<getDeliveryGoods_result>
		{
			
			public static getDeliveryGoods_resultHelper OBJ = new getDeliveryGoods_resultHelper();
			
			public static getDeliveryGoods_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryGoods_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetDeliveryGoodsResponse value;
					
					value = new vipapis.delivery.GetDeliveryGoodsResponse();
					vipapis.delivery.GetDeliveryGoodsResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryGoods_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetDeliveryGoodsResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryGoods_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryList_resultHelper : BeanSerializer<getDeliveryList_result>
		{
			
			public static getDeliveryList_resultHelper OBJ = new getDeliveryList_resultHelper();
			
			public static getDeliveryList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetDeliveryListResponse value;
					
					value = new vipapis.delivery.GetDeliveryListResponse();
					vipapis.delivery.GetDeliveryListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetDeliveryListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPickDetail_resultHelper : BeanSerializer<getPickDetail_result>
		{
			
			public static getPickDetail_resultHelper OBJ = new getPickDetail_resultHelper();
			
			public static getPickDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPickDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.PickDetail value;
					
					value = new vipapis.delivery.PickDetail();
					vipapis.delivery.PickDetailHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPickDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.PickDetailHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPickDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPickList_resultHelper : BeanSerializer<getPickList_result>
		{
			
			public static getPickList_resultHelper OBJ = new getPickList_resultHelper();
			
			public static getPickList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPickList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetPickListResponse value;
					
					value = new vipapis.delivery.GetPickListResponse();
					vipapis.delivery.GetPickListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPickList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetPickListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPickList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoList_resultHelper : BeanSerializer<getPoList_result>
		{
			
			public static getPoList_resultHelper OBJ = new getPoList_resultHelper();
			
			public static getPoList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetPoListResponse value;
					
					value = new vipapis.delivery.GetPoListResponse();
					vipapis.delivery.GetPoListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetPoListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoSkuList_resultHelper : BeanSerializer<getPoSkuList_result>
		{
			
			public static getPoSkuList_resultHelper OBJ = new getPoSkuList_resultHelper();
			
			public static getPoSkuList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoSkuList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetPoSkuListResponse value;
					
					value = new vipapis.delivery.GetPoSkuListResponse();
					vipapis.delivery.GetPoSkuListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoSkuList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetPoSkuListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoSkuList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrintBox_resultHelper : BeanSerializer<getPrintBox_result>
		{
			
			public static getPrintBox_resultHelper OBJ = new getPrintBox_resultHelper();
			
			public static getPrintBox_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrintBox_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetPrintBoxResponse value;
					
					value = new vipapis.delivery.GetPrintBoxResponse();
					vipapis.delivery.GetPrintBoxResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrintBox_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetPrintBoxResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrintBox_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrintDelivery_resultHelper : BeanSerializer<getPrintDelivery_result>
		{
			
			public static getPrintDelivery_resultHelper OBJ = new getPrintDelivery_resultHelper();
			
			public static getPrintDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrintDelivery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetPrintDeliveryResponse value;
					
					value = new vipapis.delivery.GetPrintDeliveryResponse();
					vipapis.delivery.GetPrintDeliveryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrintDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetPrintDeliveryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrintDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : BeanSerializer<healthCheck_result>
		{
			
			public static healthCheck_resultHelper OBJ = new healthCheck_resultHelper();
			
			public static healthCheck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.hermes.core.health.CheckResult value;
					
					value = new com.vip.hermes.core.health.CheckResult();
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class importDeliveryDetail_resultHelper : BeanSerializer<importDeliveryDetail_result>
		{
			
			public static importDeliveryDetail_resultHelper OBJ = new importDeliveryDetail_resultHelper();
			
			public static importDeliveryDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(importDeliveryDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(importDeliveryDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(importDeliveryDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class JitDeliveryServiceClient : OspRestStub , JitDeliveryService  {
			
			
			public JitDeliveryServiceClient():base("vipapis.delivery.JitDeliveryService","1.0.0") {
				
				
			}
			
			
			
			public string confirmDelivery(int vendor_id_,string storage_no_,string po_no_) {
				
				send_confirmDelivery(vendor_id_,storage_no_,po_no_);
				return recv_confirmDelivery(); 
				
			}
			
			
			private void send_confirmDelivery(int vendor_id_,string storage_no_,string po_no_){
				
				InitInvocation("confirmDelivery");
				
				confirmDelivery_args args = new confirmDelivery_args();
				args.SetVendor_id(vendor_id_);
				args.SetStorage_no(storage_no_);
				args.SetPo_no(po_no_);
				
				SendBase(args, confirmDelivery_argsHelper.getInstance());
			}
			
			
			private string recv_confirmDelivery(){
				
				confirmDelivery_result result = new confirmDelivery_result();
				ReceiveBase(result, confirmDelivery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.CreateDeliveryResponse createDelivery(int vendor_id_,string po_no_,string delivery_no_,vipapis.common.Warehouse? warehouse_,string delivery_time_,string arrival_time_,string race_time_,string carrier_name_,string tel_,string driver_,string driver_tel_,string plate_number_,int? page_,int? limit_) {
				
				send_createDelivery(vendor_id_,po_no_,delivery_no_,warehouse_,delivery_time_,arrival_time_,race_time_,carrier_name_,tel_,driver_,driver_tel_,plate_number_,page_,limit_);
				return recv_createDelivery(); 
				
			}
			
			
			private void send_createDelivery(int vendor_id_,string po_no_,string delivery_no_,vipapis.common.Warehouse? warehouse_,string delivery_time_,string arrival_time_,string race_time_,string carrier_name_,string tel_,string driver_,string driver_tel_,string plate_number_,int? page_,int? limit_){
				
				InitInvocation("createDelivery");
				
				createDelivery_args args = new createDelivery_args();
				args.SetVendor_id(vendor_id_);
				args.SetPo_no(po_no_);
				args.SetDelivery_no(delivery_no_);
				args.SetWarehouse(warehouse_);
				args.SetDelivery_time(delivery_time_);
				args.SetArrival_time(arrival_time_);
				args.SetRace_time(race_time_);
				args.SetCarrier_name(carrier_name_);
				args.SetTel(tel_);
				args.SetDriver(driver_);
				args.SetDriver_tel(driver_tel_);
				args.SetPlate_number(plate_number_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, createDelivery_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.CreateDeliveryResponse recv_createDelivery(){
				
				createDelivery_result result = new createDelivery_result();
				ReceiveBase(result, createDelivery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.delivery.SimplePick> createPick(string po_no_,int vendor_id_) {
				
				send_createPick(po_no_,vendor_id_);
				return recv_createPick(); 
				
			}
			
			
			private void send_createPick(string po_no_,int vendor_id_){
				
				InitInvocation("createPick");
				
				createPick_args args = new createPick_args();
				args.SetPo_no(po_no_);
				args.SetVendor_id(vendor_id_);
				
				SendBase(args, createPick_argsHelper.getInstance());
			}
			
			
			private List<vipapis.delivery.SimplePick> recv_createPick(){
				
				createPick_result result = new createPick_result();
				ReceiveBase(result, createPick_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.delivery.DeleteDeliveryDetail> deleteDeliveryDetail(int vendor_id_,string storage_no_,string po_no_) {
				
				send_deleteDeliveryDetail(vendor_id_,storage_no_,po_no_);
				return recv_deleteDeliveryDetail(); 
				
			}
			
			
			private void send_deleteDeliveryDetail(int vendor_id_,string storage_no_,string po_no_){
				
				InitInvocation("deleteDeliveryDetail");
				
				deleteDeliveryDetail_args args = new deleteDeliveryDetail_args();
				args.SetVendor_id(vendor_id_);
				args.SetStorage_no(storage_no_);
				args.SetPo_no(po_no_);
				
				SendBase(args, deleteDeliveryDetail_argsHelper.getInstance());
			}
			
			
			private List<vipapis.delivery.DeleteDeliveryDetail> recv_deleteDeliveryDetail(){
				
				deleteDeliveryDetail_result result = new deleteDeliveryDetail_result();
				ReceiveBase(result, deleteDeliveryDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string editDelivery(int vendor_id_,string storage_no_,string delivery_no_,vipapis.common.Warehouse? warehouse_,string delivery_time_,string arrival_time_,string race_time_,string carrier_name_,string tel_,string driver_,string driver_tel_,string plate_number_,int? page_,int? limit_) {
				
				send_editDelivery(vendor_id_,storage_no_,delivery_no_,warehouse_,delivery_time_,arrival_time_,race_time_,carrier_name_,tel_,driver_,driver_tel_,plate_number_,page_,limit_);
				return recv_editDelivery(); 
				
			}
			
			
			private void send_editDelivery(int vendor_id_,string storage_no_,string delivery_no_,vipapis.common.Warehouse? warehouse_,string delivery_time_,string arrival_time_,string race_time_,string carrier_name_,string tel_,string driver_,string driver_tel_,string plate_number_,int? page_,int? limit_){
				
				InitInvocation("editDelivery");
				
				editDelivery_args args = new editDelivery_args();
				args.SetVendor_id(vendor_id_);
				args.SetStorage_no(storage_no_);
				args.SetDelivery_no(delivery_no_);
				args.SetWarehouse(warehouse_);
				args.SetDelivery_time(delivery_time_);
				args.SetArrival_time(arrival_time_);
				args.SetRace_time(race_time_);
				args.SetCarrier_name(carrier_name_);
				args.SetTel(tel_);
				args.SetDriver(driver_);
				args.SetDriver_tel(driver_tel_);
				args.SetPlate_number(plate_number_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, editDelivery_argsHelper.getInstance());
			}
			
			
			private string recv_editDelivery(){
				
				editDelivery_result result = new editDelivery_result();
				ReceiveBase(result, editDelivery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetDeliveryGoodsResponse getDeliveryGoods(string vendor_id_,string storage_no_,int? page_,int? limit_) {
				
				send_getDeliveryGoods(vendor_id_,storage_no_,page_,limit_);
				return recv_getDeliveryGoods(); 
				
			}
			
			
			private void send_getDeliveryGoods(string vendor_id_,string storage_no_,int? page_,int? limit_){
				
				InitInvocation("getDeliveryGoods");
				
				getDeliveryGoods_args args = new getDeliveryGoods_args();
				args.SetVendor_id(vendor_id_);
				args.SetStorage_no(storage_no_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getDeliveryGoods_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetDeliveryGoodsResponse recv_getDeliveryGoods(){
				
				getDeliveryGoods_result result = new getDeliveryGoods_result();
				ReceiveBase(result, getDeliveryGoods_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetDeliveryListResponse getDeliveryList(string vendor_id_,string po_no_,string delivery_no_,vipapis.common.Warehouse? warehouse_,string out_flag_,string st_out_time_,string et_out_time_,string st_estimate_arrive_time_,string et_estimate_arrive_time_,string st_arrive_time_,string et_arrive_time_,int? page_,int? limit_) {
				
				send_getDeliveryList(vendor_id_,po_no_,delivery_no_,warehouse_,out_flag_,st_out_time_,et_out_time_,st_estimate_arrive_time_,et_estimate_arrive_time_,st_arrive_time_,et_arrive_time_,page_,limit_);
				return recv_getDeliveryList(); 
				
			}
			
			
			private void send_getDeliveryList(string vendor_id_,string po_no_,string delivery_no_,vipapis.common.Warehouse? warehouse_,string out_flag_,string st_out_time_,string et_out_time_,string st_estimate_arrive_time_,string et_estimate_arrive_time_,string st_arrive_time_,string et_arrive_time_,int? page_,int? limit_){
				
				InitInvocation("getDeliveryList");
				
				getDeliveryList_args args = new getDeliveryList_args();
				args.SetVendor_id(vendor_id_);
				args.SetPo_no(po_no_);
				args.SetDelivery_no(delivery_no_);
				args.SetWarehouse(warehouse_);
				args.SetOut_flag(out_flag_);
				args.SetSt_out_time(st_out_time_);
				args.SetEt_out_time(et_out_time_);
				args.SetSt_estimate_arrive_time(st_estimate_arrive_time_);
				args.SetEt_estimate_arrive_time(et_estimate_arrive_time_);
				args.SetSt_arrive_time(st_arrive_time_);
				args.SetEt_arrive_time(et_arrive_time_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getDeliveryList_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetDeliveryListResponse recv_getDeliveryList(){
				
				getDeliveryList_result result = new getDeliveryList_result();
				ReceiveBase(result, getDeliveryList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.PickDetail getPickDetail(string po_no_,int vendor_id_,string pick_no_,int? page_,int? limit_) {
				
				send_getPickDetail(po_no_,vendor_id_,pick_no_,page_,limit_);
				return recv_getPickDetail(); 
				
			}
			
			
			private void send_getPickDetail(string po_no_,int vendor_id_,string pick_no_,int? page_,int? limit_){
				
				InitInvocation("getPickDetail");
				
				getPickDetail_args args = new getPickDetail_args();
				args.SetPo_no(po_no_);
				args.SetVendor_id(vendor_id_);
				args.SetPick_no(pick_no_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getPickDetail_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.PickDetail recv_getPickDetail(){
				
				getPickDetail_result result = new getPickDetail_result();
				ReceiveBase(result, getPickDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetPickListResponse getPickList(int vendor_id_,string po_no_,string pick_no_,vipapis.common.Warehouse? warehouse_,string co_mode_,string order_cate_,string st_create_time_,string et_create_time_,string st_sell_time_from_,string et_sell_time_from_,string st_sell_time_to_,string et_sell_time_to_,int? is_export_,int? page_,int? limit_) {
				
				send_getPickList(vendor_id_,po_no_,pick_no_,warehouse_,co_mode_,order_cate_,st_create_time_,et_create_time_,st_sell_time_from_,et_sell_time_from_,st_sell_time_to_,et_sell_time_to_,is_export_,page_,limit_);
				return recv_getPickList(); 
				
			}
			
			
			private void send_getPickList(int vendor_id_,string po_no_,string pick_no_,vipapis.common.Warehouse? warehouse_,string co_mode_,string order_cate_,string st_create_time_,string et_create_time_,string st_sell_time_from_,string et_sell_time_from_,string st_sell_time_to_,string et_sell_time_to_,int? is_export_,int? page_,int? limit_){
				
				InitInvocation("getPickList");
				
				getPickList_args args = new getPickList_args();
				args.SetVendor_id(vendor_id_);
				args.SetPo_no(po_no_);
				args.SetPick_no(pick_no_);
				args.SetWarehouse(warehouse_);
				args.SetCo_mode(co_mode_);
				args.SetOrder_cate(order_cate_);
				args.SetSt_create_time(st_create_time_);
				args.SetEt_create_time(et_create_time_);
				args.SetSt_sell_time_from(st_sell_time_from_);
				args.SetEt_sell_time_from(et_sell_time_from_);
				args.SetSt_sell_time_to(st_sell_time_to_);
				args.SetEt_sell_time_to(et_sell_time_to_);
				args.SetIs_export(is_export_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getPickList_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetPickListResponse recv_getPickList(){
				
				getPickList_result result = new getPickList_result();
				ReceiveBase(result, getPickList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetPoListResponse getPoList(string st_create_time_,string et_create_time_,vipapis.common.Warehouse? warehouse_,string po_no_,string co_mode_,string vendor_id_,string st_sell_st_time_,string et_sell_st_time_,string st_sell_et_time_,string et_sell_et_time_,int? page_,int? limit_) {
				
				send_getPoList(st_create_time_,et_create_time_,warehouse_,po_no_,co_mode_,vendor_id_,st_sell_st_time_,et_sell_st_time_,st_sell_et_time_,et_sell_et_time_,page_,limit_);
				return recv_getPoList(); 
				
			}
			
			
			private void send_getPoList(string st_create_time_,string et_create_time_,vipapis.common.Warehouse? warehouse_,string po_no_,string co_mode_,string vendor_id_,string st_sell_st_time_,string et_sell_st_time_,string st_sell_et_time_,string et_sell_et_time_,int? page_,int? limit_){
				
				InitInvocation("getPoList");
				
				getPoList_args args = new getPoList_args();
				args.SetSt_create_time(st_create_time_);
				args.SetEt_create_time(et_create_time_);
				args.SetWarehouse(warehouse_);
				args.SetPo_no(po_no_);
				args.SetCo_mode(co_mode_);
				args.SetVendor_id(vendor_id_);
				args.SetSt_sell_st_time(st_sell_st_time_);
				args.SetEt_sell_st_time(et_sell_st_time_);
				args.SetSt_sell_et_time(st_sell_et_time_);
				args.SetEt_sell_et_time(et_sell_et_time_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getPoList_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetPoListResponse recv_getPoList(){
				
				getPoList_result result = new getPoList_result();
				ReceiveBase(result, getPoList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetPoSkuListResponse getPoSkuList(int vendor_id_,string po_no_,string sell_site_,vipapis.common.Warehouse? warehouse_,string order_status_,string st_aduity_time_,string et_aduity_time_,string order_id_,string pick_no_,string delivery_no_,string st_pick_time_,string et_pick_time_,string st_delivery_time_,string et_delivery_time_,int? page_,int? limit_) {
				
				send_getPoSkuList(vendor_id_,po_no_,sell_site_,warehouse_,order_status_,st_aduity_time_,et_aduity_time_,order_id_,pick_no_,delivery_no_,st_pick_time_,et_pick_time_,st_delivery_time_,et_delivery_time_,page_,limit_);
				return recv_getPoSkuList(); 
				
			}
			
			
			private void send_getPoSkuList(int vendor_id_,string po_no_,string sell_site_,vipapis.common.Warehouse? warehouse_,string order_status_,string st_aduity_time_,string et_aduity_time_,string order_id_,string pick_no_,string delivery_no_,string st_pick_time_,string et_pick_time_,string st_delivery_time_,string et_delivery_time_,int? page_,int? limit_){
				
				InitInvocation("getPoSkuList");
				
				getPoSkuList_args args = new getPoSkuList_args();
				args.SetVendor_id(vendor_id_);
				args.SetPo_no(po_no_);
				args.SetSell_site(sell_site_);
				args.SetWarehouse(warehouse_);
				args.SetOrder_status(order_status_);
				args.SetSt_aduity_time(st_aduity_time_);
				args.SetEt_aduity_time(et_aduity_time_);
				args.SetOrder_id(order_id_);
				args.SetPick_no(pick_no_);
				args.SetDelivery_no(delivery_no_);
				args.SetSt_pick_time(st_pick_time_);
				args.SetEt_pick_time(et_pick_time_);
				args.SetSt_delivery_time(st_delivery_time_);
				args.SetEt_delivery_time(et_delivery_time_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getPoSkuList_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetPoSkuListResponse recv_getPoSkuList(){
				
				getPoSkuList_result result = new getPoSkuList_result();
				ReceiveBase(result, getPoSkuList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetPrintBoxResponse getPrintBox(string pick_no_,string vendor_id_) {
				
				send_getPrintBox(pick_no_,vendor_id_);
				return recv_getPrintBox(); 
				
			}
			
			
			private void send_getPrintBox(string pick_no_,string vendor_id_){
				
				InitInvocation("getPrintBox");
				
				getPrintBox_args args = new getPrintBox_args();
				args.SetPick_no(pick_no_);
				args.SetVendor_id(vendor_id_);
				
				SendBase(args, getPrintBox_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetPrintBoxResponse recv_getPrintBox(){
				
				getPrintBox_result result = new getPrintBox_result();
				ReceiveBase(result, getPrintBox_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetPrintDeliveryResponse getPrintDelivery(int vendor_id_,string storage_no_,string po_no_,string box_no_) {
				
				send_getPrintDelivery(vendor_id_,storage_no_,po_no_,box_no_);
				return recv_getPrintDelivery(); 
				
			}
			
			
			private void send_getPrintDelivery(int vendor_id_,string storage_no_,string po_no_,string box_no_){
				
				InitInvocation("getPrintDelivery");
				
				getPrintDelivery_args args = new getPrintDelivery_args();
				args.SetVendor_id(vendor_id_);
				args.SetStorage_no(storage_no_);
				args.SetPo_no(po_no_);
				args.SetBox_no(box_no_);
				
				SendBase(args, getPrintDelivery_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetPrintDeliveryResponse recv_getPrintDelivery(){
				
				getPrintDelivery_result result = new getPrintDelivery_result();
				ReceiveBase(result, getPrintDelivery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.hermes.core.health.CheckResult healthCheck() {
				
				send_healthCheck();
				return recv_healthCheck(); 
				
			}
			
			
			private void send_healthCheck(){
				
				InitInvocation("healthCheck");
				
				healthCheck_args args = new healthCheck_args();
				
				SendBase(args, healthCheck_argsHelper.getInstance());
			}
			
			
			private com.vip.hermes.core.health.CheckResult recv_healthCheck(){
				
				healthCheck_result result = new healthCheck_result();
				ReceiveBase(result, healthCheck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string importDeliveryDetail(int vendor_id_,string po_no_,string storage_no_,string delivery_no_,string store_sn_,List<vipapis.delivery.Delivery> delivery_list_) {
				
				send_importDeliveryDetail(vendor_id_,po_no_,storage_no_,delivery_no_,store_sn_,delivery_list_);
				return recv_importDeliveryDetail(); 
				
			}
			
			
			private void send_importDeliveryDetail(int vendor_id_,string po_no_,string storage_no_,string delivery_no_,string store_sn_,List<vipapis.delivery.Delivery> delivery_list_){
				
				InitInvocation("importDeliveryDetail");
				
				importDeliveryDetail_args args = new importDeliveryDetail_args();
				args.SetVendor_id(vendor_id_);
				args.SetPo_no(po_no_);
				args.SetStorage_no(storage_no_);
				args.SetDelivery_no(delivery_no_);
				args.SetStore_sn(store_sn_);
				args.SetDelivery_list(delivery_list_);
				
				SendBase(args, importDeliveryDetail_argsHelper.getInstance());
			}
			
			
			private string recv_importDeliveryDetail(){
				
				importDeliveryDetail_result result = new importDeliveryDetail_result();
				ReceiveBase(result, importDeliveryDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}