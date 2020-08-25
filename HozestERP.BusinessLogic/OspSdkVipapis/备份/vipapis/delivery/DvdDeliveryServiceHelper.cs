using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.delivery{
	
	
	public class DvdDeliveryServiceHelper {
		
		
		
		public class editShipInfo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 发货单
			/// @sampleValue ship_list 
			///</summary>
			
			private List<vipapis.delivery.Ship> ship_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.delivery.Ship> GetShip_list(){
				return this.ship_list_;
			}
			
			public void SetShip_list(List<vipapis.delivery.Ship> value){
				this.ship_list_ = value;
			}
			
		}
		
		
		
		
		public class exportOrderById_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 导出订单的订单号码(多个订单号码之间用半角逗号区分)
			/// @sampleValue order_id 
			///</summary>
			
			private string order_id_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			
		}
		
		
		
		
		public class getCarrierList_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 550
			///</summary>
			
			private string vendor_id_;
			
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
		
		
		
		
		public class getOrderDetail_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 需要查询订单明细的订单号(多个订单号之间用半角逗号区分)
			/// @sampleValue order_id 
			///</summary>
			
			private string order_id_;
			
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
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
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
		
		
		
		
		public class getOrderList_args {
			
			///<summary>
			/// 开始查询的下单时间 以订单下单时间为准
			/// @sampleValue st_add_time 2014-07-01 10:00:00
			///</summary>
			
			private string st_add_time_;
			
			///<summary>
			/// 结束查询的下单时间 以订单下单时间为准
			/// @sampleValue et_add_time 2014-07-01 10:00:00
			///</summary>
			
			private string et_add_time_;
			
			///<summary>
			/// 订单状态编码
			/// @sampleValue order_status 
			///</summary>
			
			private vipapis.common.OrderStatus? order_status_;
			
			///<summary>
			/// PO单编号(多个用逗号分隔最多限制5个)
			/// @sampleValue po_no 
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 订单号
			/// @sampleValue order_id 
			///</summary>
			
			private string order_id_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 页码参数
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 返回结果数量(默认为20,最大支持100)
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			public string GetSt_add_time(){
				return this.st_add_time_;
			}
			
			public void SetSt_add_time(string value){
				this.st_add_time_ = value;
			}
			public string GetEt_add_time(){
				return this.et_add_time_;
			}
			
			public void SetEt_add_time(string value){
				this.et_add_time_ = value;
			}
			public vipapis.common.OrderStatus? GetOrder_status(){
				return this.order_status_;
			}
			
			public void SetOrder_status(vipapis.common.OrderStatus? value){
				this.order_status_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
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
		
		
		
		
		public class getOrderListByCreateTime_args {
			
			///<summary>
			/// 订单进入vis时间(开始时间,格式'yyyy-MM-dd HH:mm:ss')
			/// @sampleValue st_create_time st_create_time=2014-07-15 10:24:45
			///</summary>
			
			private string st_create_time_;
			
			///<summary>
			/// 订单进入vis时间(结束时间,格式'yyyy-MM-dd HH:mm:ss')
			/// @sampleValue et_create_time et_create_time=2014-07-15 10:24:45
			///</summary>
			
			private string et_create_time_;
			
			///<summary>
			/// 订单状态编码
			///</summary>
			
			private vipapis.common.OrderStatus? order_status_;
			
			///<summary>
			/// PO号(多个用半角逗号分隔，最多限制5个)
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string order_id_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
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
			public vipapis.common.OrderStatus? GetOrder_status(){
				return this.order_status_;
			}
			
			public void SetOrder_status(vipapis.common.OrderStatus? value){
				this.order_status_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
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
		
		
		
		
		public class getOrderStatusById_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 需要查询订单状态的订单号 多个订单号之间用半角逗号区分
			/// @sampleValue order_id 
			///</summary>
			
			private string order_id_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			
		}
		
		
		
		
		public class getPrintTemplate_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 打印类型 A4 B5，默认A4
			/// @sampleValue print_type A4
			///</summary>
			
			private string print_type_;
			
			///<summary>
			/// 订单编号
			/// @sampleValue order_id 14060901371013
			///</summary>
			
			private string order_id_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetPrint_type(){
				return this.print_type_;
			}
			
			public void SetPrint_type(string value){
				this.print_type_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			
		}
		
		
		
		
		public class getReturnList_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 开始查询的下单时间 以退货申请单申请时间为准
			/// @sampleValue st_create_time 
			///</summary>
			
			private string st_create_time_;
			
			///<summary>
			/// 结束查询的下单时间 以退货申请单申请时间为准
			/// @sampleValue et_create_time 
			///</summary>
			
			private string et_create_time_;
			
			///<summary>
			/// 退货申请单状态
			/// @sampleValue return_status 
			///</summary>
			
			private int? return_status_;
			
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
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
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
			public int? GetReturn_status(){
				return this.return_status_;
			}
			
			public void SetReturn_status(int? value){
				this.return_status_ = value;
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
		
		
		
		
		public class getReturnProduct_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 需要查询订单明细的订单号(多个订单号之间用半角逗号区分)
			/// @sampleValue back_sn 5556
			///</summary>
			
			private string back_sn_;
			
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
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetBack_sn(){
				return this.back_sn_;
			}
			
			public void SetBack_sn(string value){
				this.back_sn_ = value;
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
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class mergeAfterSaleAddress_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 收货人
			/// @sampleValue username 
			///</summary>
			
			private string username_;
			
			///<summary>
			/// 收货地址
			/// @sampleValue address 
			///</summary>
			
			private string address_;
			
			///<summary>
			/// 邮政编码
			/// @sampleValue postcode 
			///</summary>
			
			private string postcode_;
			
			///<summary>
			/// 联系电话
			/// @sampleValue tel 
			///</summary>
			
			private string tel_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public string GetUsername(){
				return this.username_;
			}
			
			public void SetUsername(string value){
				this.username_ = value;
			}
			public string GetAddress(){
				return this.address_;
			}
			
			public void SetAddress(string value){
				this.address_ = value;
			}
			public string GetPostcode(){
				return this.postcode_;
			}
			
			public void SetPostcode(string value){
				this.postcode_ = value;
			}
			public string GetTel(){
				return this.tel_;
			}
			
			public void SetTel(string value){
				this.tel_ = value;
			}
			
		}
		
		
		
		
		public class refuseOrder_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 订单拒收信息
			///</summary>
			
			private List<vipapis.delivery.RefuseOrReturnOrder> refuse_product_list_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public List<vipapis.delivery.RefuseOrReturnOrder> GetRefuse_product_list(){
				return this.refuse_product_list_;
			}
			
			public void SetRefuse_product_list(List<vipapis.delivery.RefuseOrReturnOrder> value){
				this.refuse_product_list_ = value;
			}
			
		}
		
		
		
		
		public class returnOrder_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 退货信息
			///</summary>
			
			private List<vipapis.delivery.RefuseOrReturnOrder> dvd_return_list_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public List<vipapis.delivery.RefuseOrReturnOrder> GetDvd_return_list(){
				return this.dvd_return_list_;
			}
			
			public void SetDvd_return_list(List<vipapis.delivery.RefuseOrReturnOrder> value){
				this.dvd_return_list_ = value;
			}
			
		}
		
		
		
		
		public class ship_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 发货单
			/// @sampleValue ship_list 
			///</summary>
			
			private List<vipapis.delivery.Ship> ship_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.delivery.Ship> GetShip_list(){
				return this.ship_list_;
			}
			
			public void SetShip_list(List<vipapis.delivery.Ship> value){
				this.ship_list_ = value;
			}
			
		}
		
		
		
		
		public class editShipInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.ShipResult success_;
			
			public vipapis.delivery.ShipResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.ShipResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class exportOrderById_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.ExportOrderByIdResponse success_;
			
			public vipapis.delivery.ExportOrderByIdResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.ExportOrderByIdResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCarrierList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetCarrierListResponse success_;
			
			public vipapis.delivery.GetCarrierListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetCarrierListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderDetail_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetOrderDetailResponse success_;
			
			public vipapis.delivery.GetOrderDetailResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetOrderDetailResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetOrderListResponse success_;
			
			public vipapis.delivery.GetOrderListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetOrderListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderListByCreateTime_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetOrderListByCreateTimeResponse success_;
			
			public vipapis.delivery.GetOrderListByCreateTimeResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetOrderListByCreateTimeResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderStatusById_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.delivery.DvdOrderStatus> success_;
			
			public List<vipapis.delivery.DvdOrderStatus> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.delivery.DvdOrderStatus> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPrintTemplate_result {
			
			///<summary>
			/// 打印页面HTML
			///</summary>
			
			private vipapis.delivery.PrintTemplateResponse success_;
			
			public vipapis.delivery.PrintTemplateResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.PrintTemplateResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getReturnList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetReturnListResponse success_;
			
			public vipapis.delivery.GetReturnListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetReturnListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getReturnProduct_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.GetReturnProductResponse success_;
			
			public vipapis.delivery.GetReturnProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.GetReturnProductResponse value){
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
		
		
		
		
		public class mergeAfterSaleAddress_result {
			
			///<summary>
			/// 是否推送成功
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class refuseOrder_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.RefuseOrReturnProductResponse success_;
			
			public vipapis.delivery.RefuseOrReturnProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.RefuseOrReturnProductResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class returnOrder_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.RefuseOrReturnProductResponse success_;
			
			public vipapis.delivery.RefuseOrReturnProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.RefuseOrReturnProductResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class ship_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.ShipResult success_;
			
			public vipapis.delivery.ShipResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.ShipResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class editShipInfo_argsHelper : BeanSerializer<editShipInfo_args>
		{
			
			public static editShipInfo_argsHelper OBJ = new editShipInfo_argsHelper();
			
			public static editShipInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editShipInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.delivery.Ship> value;
					
					value = new List<vipapis.delivery.Ship>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.delivery.Ship elem1;
							
							elem1 = new vipapis.delivery.Ship();
							vipapis.delivery.ShipHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetShip_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editShipInfo_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetShip_list() != null) {
					
					oprot.WriteFieldBegin("ship_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.delivery.Ship _item0 in structs.GetShip_list()){
						
						
						vipapis.delivery.ShipHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("ship_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editShipInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class exportOrderById_argsHelper : BeanSerializer<exportOrderById_args>
		{
			
			public static exportOrderById_argsHelper OBJ = new exportOrderById_argsHelper();
			
			public static exportOrderById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(exportOrderById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(exportOrderById_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(exportOrderById_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCarrierList_argsHelper : BeanSerializer<getCarrierList_args>
		{
			
			public static getCarrierList_argsHelper OBJ = new getCarrierList_argsHelper();
			
			public static getCarrierList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCarrierList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
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
			
			
			public void Write(getCarrierList_args structs, Protocol oprot){
				
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
			
			
			public void Validate(getCarrierList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderDetail_argsHelper : BeanSerializer<getOrderDetail_args>
		{
			
			public static getOrderDetail_argsHelper OBJ = new getOrderDetail_argsHelper();
			
			public static getOrderDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
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
			
			
			public void Write(getOrderDetail_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_id can not be null!");
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
			
			
			public void Validate(getOrderDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderList_argsHelper : BeanSerializer<getOrderList_args>
		{
			
			public static getOrderList_argsHelper OBJ = new getOrderList_argsHelper();
			
			public static getOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_add_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_add_time(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.OrderStatus? value;
					
					value = vipapis.common.OrderStatusUtil.FindByName(iprot.ReadString());
					
					structs.SetOrder_status(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
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
			
			
			public void Write(getOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSt_add_time() != null) {
					
					oprot.WriteFieldBegin("st_add_time");
					oprot.WriteString(structs.GetSt_add_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("st_add_time can not be null!");
				}
				
				
				if(structs.GetEt_add_time() != null) {
					
					oprot.WriteFieldBegin("et_add_time");
					oprot.WriteString(structs.GetEt_add_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("et_add_time can not be null!");
				}
				
				
				if(structs.GetOrder_status() != null) {
					
					oprot.WriteFieldBegin("order_status");
					oprot.WriteString(structs.GetOrder_status().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
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
			
			
			public void Validate(getOrderList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderListByCreateTime_argsHelper : BeanSerializer<getOrderListByCreateTime_args>
		{
			
			public static getOrderListByCreateTime_argsHelper OBJ = new getOrderListByCreateTime_argsHelper();
			
			public static getOrderListByCreateTime_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderListByCreateTime_args structs, Protocol iprot){
				
				
				
				
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
					
					vipapis.common.OrderStatus? value;
					
					value = vipapis.common.OrderStatusUtil.FindByName(iprot.ReadString());
					
					structs.SetOrder_status(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
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
			
			
			public void Write(getOrderListByCreateTime_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSt_create_time() != null) {
					
					oprot.WriteFieldBegin("st_create_time");
					oprot.WriteString(structs.GetSt_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("st_create_time can not be null!");
				}
				
				
				if(structs.GetEt_create_time() != null) {
					
					oprot.WriteFieldBegin("et_create_time");
					oprot.WriteString(structs.GetEt_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("et_create_time can not be null!");
				}
				
				
				if(structs.GetOrder_status() != null) {
					
					oprot.WriteFieldBegin("order_status");
					oprot.WriteString(structs.GetOrder_status().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
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
			
			
			public void Validate(getOrderListByCreateTime_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderStatusById_argsHelper : BeanSerializer<getOrderStatusById_args>
		{
			
			public static getOrderStatusById_argsHelper OBJ = new getOrderStatusById_argsHelper();
			
			public static getOrderStatusById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderStatusById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderStatusById_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderStatusById_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrintTemplate_argsHelper : BeanSerializer<getPrintTemplate_args>
		{
			
			public static getPrintTemplate_argsHelper OBJ = new getPrintTemplate_argsHelper();
			
			public static getPrintTemplate_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrintTemplate_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPrint_type(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrder_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrintTemplate_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetPrint_type() != null) {
					
					oprot.WriteFieldBegin("print_type");
					oprot.WriteString(structs.GetPrint_type());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrder_id() != null) {
					
					oprot.WriteFieldBegin("order_id");
					oprot.WriteString(structs.GetOrder_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrintTemplate_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnList_argsHelper : BeanSerializer<getReturnList_args>
		{
			
			public static getReturnList_argsHelper OBJ = new getReturnList_argsHelper();
			
			public static getReturnList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
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
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetReturn_status(value);
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
			
			
			public void Write(getReturnList_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSt_create_time() != null) {
					
					oprot.WriteFieldBegin("st_create_time");
					oprot.WriteString(structs.GetSt_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("st_create_time can not be null!");
				}
				
				
				if(structs.GetEt_create_time() != null) {
					
					oprot.WriteFieldBegin("et_create_time");
					oprot.WriteString(structs.GetEt_create_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("et_create_time can not be null!");
				}
				
				
				if(structs.GetReturn_status() != null) {
					
					oprot.WriteFieldBegin("return_status");
					oprot.WriteI32((int)structs.GetReturn_status()); 
					
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
			
			
			public void Validate(getReturnList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnProduct_argsHelper : BeanSerializer<getReturnProduct_args>
		{
			
			public static getReturnProduct_argsHelper OBJ = new getReturnProduct_argsHelper();
			
			public static getReturnProduct_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnProduct_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBack_sn(value);
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
			
			
			public void Write(getReturnProduct_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetBack_sn() != null) {
					
					oprot.WriteFieldBegin("back_sn");
					oprot.WriteString(structs.GetBack_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("back_sn can not be null!");
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
			
			
			public void Validate(getReturnProduct_args bean){
				
				
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
		
		
		
		
		public class mergeAfterSaleAddress_argsHelper : BeanSerializer<mergeAfterSaleAddress_args>
		{
			
			public static mergeAfterSaleAddress_argsHelper OBJ = new mergeAfterSaleAddress_argsHelper();
			
			public static mergeAfterSaleAddress_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(mergeAfterSaleAddress_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetUsername(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetAddress(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPostcode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetTel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(mergeAfterSaleAddress_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetUsername() != null) {
					
					oprot.WriteFieldBegin("username");
					oprot.WriteString(structs.GetUsername());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("username can not be null!");
				}
				
				
				if(structs.GetAddress() != null) {
					
					oprot.WriteFieldBegin("address");
					oprot.WriteString(structs.GetAddress());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("address can not be null!");
				}
				
				
				if(structs.GetPostcode() != null) {
					
					oprot.WriteFieldBegin("postcode");
					oprot.WriteString(structs.GetPostcode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("postcode can not be null!");
				}
				
				
				if(structs.GetTel() != null) {
					
					oprot.WriteFieldBegin("tel");
					oprot.WriteString(structs.GetTel());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("tel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(mergeAfterSaleAddress_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class refuseOrder_argsHelper : BeanSerializer<refuseOrder_args>
		{
			
			public static refuseOrder_argsHelper OBJ = new refuseOrder_argsHelper();
			
			public static refuseOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(refuseOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.delivery.RefuseOrReturnOrder> value;
					
					value = new List<vipapis.delivery.RefuseOrReturnOrder>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.delivery.RefuseOrReturnOrder elem0;
							
							elem0 = new vipapis.delivery.RefuseOrReturnOrder();
							vipapis.delivery.RefuseOrReturnOrderHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetRefuse_product_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(refuseOrder_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetRefuse_product_list() != null) {
					
					oprot.WriteFieldBegin("refuse_product_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.delivery.RefuseOrReturnOrder _item0 in structs.GetRefuse_product_list()){
						
						
						vipapis.delivery.RefuseOrReturnOrderHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("refuse_product_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(refuseOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class returnOrder_argsHelper : BeanSerializer<returnOrder_args>
		{
			
			public static returnOrder_argsHelper OBJ = new returnOrder_argsHelper();
			
			public static returnOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(returnOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.delivery.RefuseOrReturnOrder> value;
					
					value = new List<vipapis.delivery.RefuseOrReturnOrder>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.delivery.RefuseOrReturnOrder elem1;
							
							elem1 = new vipapis.delivery.RefuseOrReturnOrder();
							vipapis.delivery.RefuseOrReturnOrderHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetDvd_return_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(returnOrder_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetDvd_return_list() != null) {
					
					oprot.WriteFieldBegin("dvd_return_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.delivery.RefuseOrReturnOrder _item0 in structs.GetDvd_return_list()){
						
						
						vipapis.delivery.RefuseOrReturnOrderHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("dvd_return_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(returnOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class ship_argsHelper : BeanSerializer<ship_args>
		{
			
			public static ship_argsHelper OBJ = new ship_argsHelper();
			
			public static ship_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(ship_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.delivery.Ship> value;
					
					value = new List<vipapis.delivery.Ship>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.delivery.Ship elem1;
							
							elem1 = new vipapis.delivery.Ship();
							vipapis.delivery.ShipHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetShip_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(ship_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetShip_list() != null) {
					
					oprot.WriteFieldBegin("ship_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.delivery.Ship _item0 in structs.GetShip_list()){
						
						
						vipapis.delivery.ShipHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("ship_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(ship_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editShipInfo_resultHelper : BeanSerializer<editShipInfo_result>
		{
			
			public static editShipInfo_resultHelper OBJ = new editShipInfo_resultHelper();
			
			public static editShipInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editShipInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.ShipResult value;
					
					value = new vipapis.delivery.ShipResult();
					vipapis.delivery.ShipResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editShipInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.ShipResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editShipInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class exportOrderById_resultHelper : BeanSerializer<exportOrderById_result>
		{
			
			public static exportOrderById_resultHelper OBJ = new exportOrderById_resultHelper();
			
			public static exportOrderById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(exportOrderById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.ExportOrderByIdResponse value;
					
					value = new vipapis.delivery.ExportOrderByIdResponse();
					vipapis.delivery.ExportOrderByIdResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(exportOrderById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.ExportOrderByIdResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(exportOrderById_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCarrierList_resultHelper : BeanSerializer<getCarrierList_result>
		{
			
			public static getCarrierList_resultHelper OBJ = new getCarrierList_resultHelper();
			
			public static getCarrierList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCarrierList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetCarrierListResponse value;
					
					value = new vipapis.delivery.GetCarrierListResponse();
					vipapis.delivery.GetCarrierListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCarrierList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetCarrierListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCarrierList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderDetail_resultHelper : BeanSerializer<getOrderDetail_result>
		{
			
			public static getOrderDetail_resultHelper OBJ = new getOrderDetail_resultHelper();
			
			public static getOrderDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetOrderDetailResponse value;
					
					value = new vipapis.delivery.GetOrderDetailResponse();
					vipapis.delivery.GetOrderDetailResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetOrderDetailResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderList_resultHelper : BeanSerializer<getOrderList_result>
		{
			
			public static getOrderList_resultHelper OBJ = new getOrderList_resultHelper();
			
			public static getOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetOrderListResponse value;
					
					value = new vipapis.delivery.GetOrderListResponse();
					vipapis.delivery.GetOrderListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetOrderListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderListByCreateTime_resultHelper : BeanSerializer<getOrderListByCreateTime_result>
		{
			
			public static getOrderListByCreateTime_resultHelper OBJ = new getOrderListByCreateTime_resultHelper();
			
			public static getOrderListByCreateTime_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderListByCreateTime_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetOrderListByCreateTimeResponse value;
					
					value = new vipapis.delivery.GetOrderListByCreateTimeResponse();
					vipapis.delivery.GetOrderListByCreateTimeResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderListByCreateTime_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetOrderListByCreateTimeResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderListByCreateTime_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderStatusById_resultHelper : BeanSerializer<getOrderStatusById_result>
		{
			
			public static getOrderStatusById_resultHelper OBJ = new getOrderStatusById_resultHelper();
			
			public static getOrderStatusById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderStatusById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.delivery.DvdOrderStatus> value;
					
					value = new List<vipapis.delivery.DvdOrderStatus>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.delivery.DvdOrderStatus elem0;
							
							elem0 = new vipapis.delivery.DvdOrderStatus();
							vipapis.delivery.DvdOrderStatusHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getOrderStatusById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.delivery.DvdOrderStatus _item0 in structs.GetSuccess()){
						
						
						vipapis.delivery.DvdOrderStatusHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderStatusById_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPrintTemplate_resultHelper : BeanSerializer<getPrintTemplate_result>
		{
			
			public static getPrintTemplate_resultHelper OBJ = new getPrintTemplate_resultHelper();
			
			public static getPrintTemplate_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPrintTemplate_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.PrintTemplateResponse value;
					
					value = new vipapis.delivery.PrintTemplateResponse();
					vipapis.delivery.PrintTemplateResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPrintTemplate_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.PrintTemplateResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPrintTemplate_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnList_resultHelper : BeanSerializer<getReturnList_result>
		{
			
			public static getReturnList_resultHelper OBJ = new getReturnList_resultHelper();
			
			public static getReturnList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetReturnListResponse value;
					
					value = new vipapis.delivery.GetReturnListResponse();
					vipapis.delivery.GetReturnListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetReturnListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnProduct_resultHelper : BeanSerializer<getReturnProduct_result>
		{
			
			public static getReturnProduct_resultHelper OBJ = new getReturnProduct_resultHelper();
			
			public static getReturnProduct_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnProduct_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.GetReturnProductResponse value;
					
					value = new vipapis.delivery.GetReturnProductResponse();
					vipapis.delivery.GetReturnProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnProduct_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.GetReturnProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnProduct_result bean){
				
				
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
		
		
		
		
		public class mergeAfterSaleAddress_resultHelper : BeanSerializer<mergeAfterSaleAddress_result>
		{
			
			public static mergeAfterSaleAddress_resultHelper OBJ = new mergeAfterSaleAddress_resultHelper();
			
			public static mergeAfterSaleAddress_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(mergeAfterSaleAddress_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool? value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(mergeAfterSaleAddress_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(mergeAfterSaleAddress_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class refuseOrder_resultHelper : BeanSerializer<refuseOrder_result>
		{
			
			public static refuseOrder_resultHelper OBJ = new refuseOrder_resultHelper();
			
			public static refuseOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(refuseOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.RefuseOrReturnProductResponse value;
					
					value = new vipapis.delivery.RefuseOrReturnProductResponse();
					vipapis.delivery.RefuseOrReturnProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(refuseOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.RefuseOrReturnProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(refuseOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class returnOrder_resultHelper : BeanSerializer<returnOrder_result>
		{
			
			public static returnOrder_resultHelper OBJ = new returnOrder_resultHelper();
			
			public static returnOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(returnOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.RefuseOrReturnProductResponse value;
					
					value = new vipapis.delivery.RefuseOrReturnProductResponse();
					vipapis.delivery.RefuseOrReturnProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(returnOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.RefuseOrReturnProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(returnOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class ship_resultHelper : BeanSerializer<ship_result>
		{
			
			public static ship_resultHelper OBJ = new ship_resultHelper();
			
			public static ship_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(ship_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.ShipResult value;
					
					value = new vipapis.delivery.ShipResult();
					vipapis.delivery.ShipResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(ship_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.ShipResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(ship_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class DvdDeliveryServiceClient : OspRestStub , DvdDeliveryService  {
			
			
			public DvdDeliveryServiceClient():base("vipapis.delivery.DvdDeliveryService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.delivery.ShipResult editShipInfo(int vendor_id_,List<vipapis.delivery.Ship> ship_list_) {
				
				send_editShipInfo(vendor_id_,ship_list_);
				return recv_editShipInfo(); 
				
			}
			
			
			private void send_editShipInfo(int vendor_id_,List<vipapis.delivery.Ship> ship_list_){
				
				InitInvocation("editShipInfo");
				
				editShipInfo_args args = new editShipInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetShip_list(ship_list_);
				
				SendBase(args, editShipInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.ShipResult recv_editShipInfo(){
				
				editShipInfo_result result = new editShipInfo_result();
				ReceiveBase(result, editShipInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.ExportOrderByIdResponse exportOrderById(int vendor_id_,string order_id_) {
				
				send_exportOrderById(vendor_id_,order_id_);
				return recv_exportOrderById(); 
				
			}
			
			
			private void send_exportOrderById(int vendor_id_,string order_id_){
				
				InitInvocation("exportOrderById");
				
				exportOrderById_args args = new exportOrderById_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_id(order_id_);
				
				SendBase(args, exportOrderById_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.ExportOrderByIdResponse recv_exportOrderById(){
				
				exportOrderById_result result = new exportOrderById_result();
				ReceiveBase(result, exportOrderById_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetCarrierListResponse getCarrierList(string vendor_id_,int? page_,int? limit_) {
				
				send_getCarrierList(vendor_id_,page_,limit_);
				return recv_getCarrierList(); 
				
			}
			
			
			private void send_getCarrierList(string vendor_id_,int? page_,int? limit_){
				
				InitInvocation("getCarrierList");
				
				getCarrierList_args args = new getCarrierList_args();
				args.SetVendor_id(vendor_id_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getCarrierList_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetCarrierListResponse recv_getCarrierList(){
				
				getCarrierList_result result = new getCarrierList_result();
				ReceiveBase(result, getCarrierList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetOrderDetailResponse getOrderDetail(int vendor_id_,string order_id_,int? page_,int? limit_) {
				
				send_getOrderDetail(vendor_id_,order_id_,page_,limit_);
				return recv_getOrderDetail(); 
				
			}
			
			
			private void send_getOrderDetail(int vendor_id_,string order_id_,int? page_,int? limit_){
				
				InitInvocation("getOrderDetail");
				
				getOrderDetail_args args = new getOrderDetail_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_id(order_id_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getOrderDetail_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetOrderDetailResponse recv_getOrderDetail(){
				
				getOrderDetail_result result = new getOrderDetail_result();
				ReceiveBase(result, getOrderDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetOrderListResponse getOrderList(string st_add_time_,string et_add_time_,vipapis.common.OrderStatus? order_status_,string po_no_,string order_id_,string vendor_id_,int? page_,int? limit_) {
				
				send_getOrderList(st_add_time_,et_add_time_,order_status_,po_no_,order_id_,vendor_id_,page_,limit_);
				return recv_getOrderList(); 
				
			}
			
			
			private void send_getOrderList(string st_add_time_,string et_add_time_,vipapis.common.OrderStatus? order_status_,string po_no_,string order_id_,string vendor_id_,int? page_,int? limit_){
				
				InitInvocation("getOrderList");
				
				getOrderList_args args = new getOrderList_args();
				args.SetSt_add_time(st_add_time_);
				args.SetEt_add_time(et_add_time_);
				args.SetOrder_status(order_status_);
				args.SetPo_no(po_no_);
				args.SetOrder_id(order_id_);
				args.SetVendor_id(vendor_id_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getOrderList_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetOrderListResponse recv_getOrderList(){
				
				getOrderList_result result = new getOrderList_result();
				ReceiveBase(result, getOrderList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetOrderListByCreateTimeResponse getOrderListByCreateTime(string st_create_time_,string et_create_time_,vipapis.common.OrderStatus? order_status_,string po_no_,string order_id_,string vendor_id_,int? page_,int? limit_) {
				
				send_getOrderListByCreateTime(st_create_time_,et_create_time_,order_status_,po_no_,order_id_,vendor_id_,page_,limit_);
				return recv_getOrderListByCreateTime(); 
				
			}
			
			
			private void send_getOrderListByCreateTime(string st_create_time_,string et_create_time_,vipapis.common.OrderStatus? order_status_,string po_no_,string order_id_,string vendor_id_,int? page_,int? limit_){
				
				InitInvocation("getOrderListByCreateTime");
				
				getOrderListByCreateTime_args args = new getOrderListByCreateTime_args();
				args.SetSt_create_time(st_create_time_);
				args.SetEt_create_time(et_create_time_);
				args.SetOrder_status(order_status_);
				args.SetPo_no(po_no_);
				args.SetOrder_id(order_id_);
				args.SetVendor_id(vendor_id_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getOrderListByCreateTime_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetOrderListByCreateTimeResponse recv_getOrderListByCreateTime(){
				
				getOrderListByCreateTime_result result = new getOrderListByCreateTime_result();
				ReceiveBase(result, getOrderListByCreateTime_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.delivery.DvdOrderStatus> getOrderStatusById(int vendor_id_,string order_id_) {
				
				send_getOrderStatusById(vendor_id_,order_id_);
				return recv_getOrderStatusById(); 
				
			}
			
			
			private void send_getOrderStatusById(int vendor_id_,string order_id_){
				
				InitInvocation("getOrderStatusById");
				
				getOrderStatusById_args args = new getOrderStatusById_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_id(order_id_);
				
				SendBase(args, getOrderStatusById_argsHelper.getInstance());
			}
			
			
			private List<vipapis.delivery.DvdOrderStatus> recv_getOrderStatusById(){
				
				getOrderStatusById_result result = new getOrderStatusById_result();
				ReceiveBase(result, getOrderStatusById_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.PrintTemplateResponse getPrintTemplate(int vendor_id_,string print_type_,string order_id_) {
				
				send_getPrintTemplate(vendor_id_,print_type_,order_id_);
				return recv_getPrintTemplate(); 
				
			}
			
			
			private void send_getPrintTemplate(int vendor_id_,string print_type_,string order_id_){
				
				InitInvocation("getPrintTemplate");
				
				getPrintTemplate_args args = new getPrintTemplate_args();
				args.SetVendor_id(vendor_id_);
				args.SetPrint_type(print_type_);
				args.SetOrder_id(order_id_);
				
				SendBase(args, getPrintTemplate_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.PrintTemplateResponse recv_getPrintTemplate(){
				
				getPrintTemplate_result result = new getPrintTemplate_result();
				ReceiveBase(result, getPrintTemplate_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetReturnListResponse getReturnList(int vendor_id_,string st_create_time_,string et_create_time_,int? return_status_,int? page_,int? limit_) {
				
				send_getReturnList(vendor_id_,st_create_time_,et_create_time_,return_status_,page_,limit_);
				return recv_getReturnList(); 
				
			}
			
			
			private void send_getReturnList(int vendor_id_,string st_create_time_,string et_create_time_,int? return_status_,int? page_,int? limit_){
				
				InitInvocation("getReturnList");
				
				getReturnList_args args = new getReturnList_args();
				args.SetVendor_id(vendor_id_);
				args.SetSt_create_time(st_create_time_);
				args.SetEt_create_time(et_create_time_);
				args.SetReturn_status(return_status_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getReturnList_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetReturnListResponse recv_getReturnList(){
				
				getReturnList_result result = new getReturnList_result();
				ReceiveBase(result, getReturnList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetReturnProductResponse getReturnProduct(int vendor_id_,string back_sn_,int? page_,int? limit_) {
				
				send_getReturnProduct(vendor_id_,back_sn_,page_,limit_);
				return recv_getReturnProduct(); 
				
			}
			
			
			private void send_getReturnProduct(int vendor_id_,string back_sn_,int? page_,int? limit_){
				
				InitInvocation("getReturnProduct");
				
				getReturnProduct_args args = new getReturnProduct_args();
				args.SetVendor_id(vendor_id_);
				args.SetBack_sn(back_sn_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getReturnProduct_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.GetReturnProductResponse recv_getReturnProduct(){
				
				getReturnProduct_result result = new getReturnProduct_result();
				ReceiveBase(result, getReturnProduct_resultHelper.getInstance());
				
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
			
			
			public bool? mergeAfterSaleAddress(string vendor_id_,string username_,string address_,string postcode_,string tel_) {
				
				send_mergeAfterSaleAddress(vendor_id_,username_,address_,postcode_,tel_);
				return recv_mergeAfterSaleAddress(); 
				
			}
			
			
			private void send_mergeAfterSaleAddress(string vendor_id_,string username_,string address_,string postcode_,string tel_){
				
				InitInvocation("mergeAfterSaleAddress");
				
				mergeAfterSaleAddress_args args = new mergeAfterSaleAddress_args();
				args.SetVendor_id(vendor_id_);
				args.SetUsername(username_);
				args.SetAddress(address_);
				args.SetPostcode(postcode_);
				args.SetTel(tel_);
				
				SendBase(args, mergeAfterSaleAddress_argsHelper.getInstance());
			}
			
			
			private bool? recv_mergeAfterSaleAddress(){
				
				mergeAfterSaleAddress_result result = new mergeAfterSaleAddress_result();
				ReceiveBase(result, mergeAfterSaleAddress_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.RefuseOrReturnProductResponse refuseOrder(string vendor_id_,List<vipapis.delivery.RefuseOrReturnOrder> refuse_product_list_) {
				
				send_refuseOrder(vendor_id_,refuse_product_list_);
				return recv_refuseOrder(); 
				
			}
			
			
			private void send_refuseOrder(string vendor_id_,List<vipapis.delivery.RefuseOrReturnOrder> refuse_product_list_){
				
				InitInvocation("refuseOrder");
				
				refuseOrder_args args = new refuseOrder_args();
				args.SetVendor_id(vendor_id_);
				args.SetRefuse_product_list(refuse_product_list_);
				
				SendBase(args, refuseOrder_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.RefuseOrReturnProductResponse recv_refuseOrder(){
				
				refuseOrder_result result = new refuseOrder_result();
				ReceiveBase(result, refuseOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.RefuseOrReturnProductResponse returnOrder(string vendor_id_,List<vipapis.delivery.RefuseOrReturnOrder> dvd_return_list_) {
				
				send_returnOrder(vendor_id_,dvd_return_list_);
				return recv_returnOrder(); 
				
			}
			
			
			private void send_returnOrder(string vendor_id_,List<vipapis.delivery.RefuseOrReturnOrder> dvd_return_list_){
				
				InitInvocation("returnOrder");
				
				returnOrder_args args = new returnOrder_args();
				args.SetVendor_id(vendor_id_);
				args.SetDvd_return_list(dvd_return_list_);
				
				SendBase(args, returnOrder_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.RefuseOrReturnProductResponse recv_returnOrder(){
				
				returnOrder_result result = new returnOrder_result();
				ReceiveBase(result, returnOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.ShipResult ship(int vendor_id_,List<vipapis.delivery.Ship> ship_list_) {
				
				send_ship(vendor_id_,ship_list_);
				return recv_ship(); 
				
			}
			
			
			private void send_ship(int vendor_id_,List<vipapis.delivery.Ship> ship_list_){
				
				InitInvocation("ship");
				
				ship_args args = new ship_args();
				args.SetVendor_id(vendor_id_);
				args.SetShip_list(ship_list_);
				
				SendBase(args, ship_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.ShipResult recv_ship(){
				
				ship_result result = new ship_result();
				ReceiveBase(result, ship_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}