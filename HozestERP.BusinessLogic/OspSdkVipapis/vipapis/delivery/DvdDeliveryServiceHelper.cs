using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.delivery{
	
	
	public class DvdDeliveryServiceHelper {
		
		
		
		public class auditReturnResult_args {
			
			///<summary>
			/// 客退审核结果
			///</summary>
			
			private vipapis.delivery.AuditReturnResultRequest request_;
			
			public vipapis.delivery.AuditReturnResultRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.delivery.AuditReturnResultRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class confirmRefuseResult_args {
			
			///<summary>
			/// 确认拒收结果请求
			///</summary>
			
			private vipapis.delivery.ConfirmRefuseResultRequest request_;
			
			public vipapis.delivery.ConfirmRefuseResultRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.delivery.ConfirmRefuseResultRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class confirmReturnOrder_args {
			
			///<summary>
			/// 确认拒收或者客退订单请求
			///</summary>
			
			private vipapis.delivery.ConfirmReturnOrderRequest request_;
			
			public vipapis.delivery.ConfirmReturnOrderRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.delivery.ConfirmReturnOrderRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class confirmReturnResult_args {
			
			///<summary>
			/// 确认客退结果请求
			///</summary>
			
			private vipapis.delivery.ConfirmReturnResultRequest request_;
			
			public vipapis.delivery.ConfirmReturnResultRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.delivery.ConfirmReturnResultRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
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
		
		
		
		
		public class getOrderFinancialFields_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 订单号(多个用半角逗号分隔，最多限制100个)
			/// @sampleValue order_id 465878421,6147897
			///</summary>
			
			private string order_id_;
			
			///<summary>
			/// po
			/// @sampleValue po_no 1343241
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 优惠活动发起标示0:供应商无优惠<br>1:有供应商发起的优惠活动，且所有活动都无分摊 <br>2：优惠分摊（优惠发起方可以是唯品会，也可以是供应商，也可以叠加非分摊的优惠）
			/// @sampleValue deduction_indicator 0
			///</summary>
			
			private int? deduction_indicator_;
			
			///<summary>
			/// 活动优惠编码<BR>deduction_indicator=0时非必填deduction_indicator=1&2时必填，如有多个活动，以英文逗号分开
			/// @sampleValue active_no 132412
			///</summary>
			
			private string active_no_;
			
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
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public int? GetDeduction_indicator(){
				return this.deduction_indicator_;
			}
			
			public void SetDeduction_indicator(int? value){
				this.deduction_indicator_ = value;
			}
			public string GetActive_no(){
				return this.active_no_;
			}
			
			public void SetActive_no(string value){
				this.active_no_ = value;
			}
			
		}
		
		
		
		
		public class getOrderList_args {
			
			///<summary>
			/// 开始查询的下单时间 以VIS订单创建时间为准
			/// @sampleValue st_add_time 2014-07-01 10:00:00
			///</summary>
			
			private string st_add_time_;
			
			///<summary>
			/// 结束查询的下单时间 以VIS订单创建时间为准
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
			
			///<summary>
			/// 订单类型：目前只支持：0：查询返回非sale_type不为114（大件仓中仓）订单，114：查询sale_type=114大件仓中仓订单
			/// @sampleValue sale_type 0
			///</summary>
			
			private string sale_type_;
			
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
			public string GetSale_type(){
				return this.sale_type_;
			}
			
			public void SetSale_type(string value){
				this.sale_type_ = value;
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
		
		
		
		
		public class getOrderReturnDetails_args {
			
			///<summary>
			/// 获取客退订单详情请求
			///</summary>
			
			private vipapis.delivery.ReturnOrderDetailsRequest request_;
			
			public vipapis.delivery.ReturnOrderDetailsRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.delivery.ReturnOrderDetailsRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getOrderReturnList_args {
			
			///<summary>
			/// 开始查询时间-客退订单创建时间
			/// @sampleValue st_time 2014-07-01 10:00:00
			///</summary>
			
			private string st_time_;
			
			///<summary>
			/// 结束查询时间-客退订单创建时间
			/// @sampleValue et_time 2014-07-01 10:00:00
			///</summary>
			
			private string et_time_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private long? vendor_id_;
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string order_id_;
			
			///<summary>
			/// 退货类型,0：拒收；1：客退；2：取消客退;若不填，则返回拒收及客退（即不包含类型2）
			///</summary>
			
			private int? return_type_;
			
			///<summary>
			/// 页码(默认为1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 返回结果数量(默认为20,最大支持100)
			///</summary>
			
			private int? limit_;
			
			public string GetSt_time(){
				return this.st_time_;
			}
			
			public void SetSt_time(string value){
				this.st_time_ = value;
			}
			public string GetEt_time(){
				return this.et_time_;
			}
			
			public void SetEt_time(string value){
				this.et_time_ = value;
			}
			public long? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(long? value){
				this.vendor_id_ = value;
			}
			public string GetOrder_id(){
				return this.order_id_;
			}
			
			public void SetOrder_id(string value){
				this.order_id_ = value;
			}
			public int? GetReturn_type(){
				return this.return_type_;
			}
			
			public void SetReturn_type(int? value){
				this.return_type_ = value;
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
			/// 发货单,发货单个数不能超过50
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
		
		
		
		
		public class auditReturnResult_result {
			
			///<summary>
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class confirmRefuseResult_result {
			
			
		}
		
		
		
		
		public class confirmReturnOrder_result {
			
			
		}
		
		
		
		
		public class confirmReturnResult_result {
			
			
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
		
		
		
		
		public class getOrderFinancialFields_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.delivery.OrderFinancialFields> success_;
			
			public List<vipapis.delivery.OrderFinancialFields> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.delivery.OrderFinancialFields> value){
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
		
		
		
		
		public class getOrderReturnDetails_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.OrderReturnDetailResponse success_;
			
			public vipapis.delivery.OrderReturnDetailResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.OrderReturnDetailResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderReturnList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.delivery.OrderReturnResponse success_;
			
			public vipapis.delivery.OrderReturnResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.delivery.OrderReturnResponse value){
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
		
		
		
		
		
		public class auditReturnResult_argsHelper : TBeanSerializer<auditReturnResult_args>
		{
			
			public static auditReturnResult_argsHelper OBJ = new auditReturnResult_argsHelper();
			
			public static auditReturnResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(auditReturnResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.AuditReturnResultRequest value;
					
					value = new vipapis.delivery.AuditReturnResultRequest();
					vipapis.delivery.AuditReturnResultRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(auditReturnResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.delivery.AuditReturnResultRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(auditReturnResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmRefuseResult_argsHelper : TBeanSerializer<confirmRefuseResult_args>
		{
			
			public static confirmRefuseResult_argsHelper OBJ = new confirmRefuseResult_argsHelper();
			
			public static confirmRefuseResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmRefuseResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.ConfirmRefuseResultRequest value;
					
					value = new vipapis.delivery.ConfirmRefuseResultRequest();
					vipapis.delivery.ConfirmRefuseResultRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmRefuseResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.delivery.ConfirmRefuseResultRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmRefuseResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmReturnOrder_argsHelper : TBeanSerializer<confirmReturnOrder_args>
		{
			
			public static confirmReturnOrder_argsHelper OBJ = new confirmReturnOrder_argsHelper();
			
			public static confirmReturnOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmReturnOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.ConfirmReturnOrderRequest value;
					
					value = new vipapis.delivery.ConfirmReturnOrderRequest();
					vipapis.delivery.ConfirmReturnOrderRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmReturnOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.delivery.ConfirmReturnOrderRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmReturnOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmReturnResult_argsHelper : TBeanSerializer<confirmReturnResult_args>
		{
			
			public static confirmReturnResult_argsHelper OBJ = new confirmReturnResult_argsHelper();
			
			public static confirmReturnResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmReturnResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.ConfirmReturnResultRequest value;
					
					value = new vipapis.delivery.ConfirmReturnResultRequest();
					vipapis.delivery.ConfirmReturnResultRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmReturnResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.delivery.ConfirmReturnResultRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmReturnResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editShipInfo_argsHelper : TBeanSerializer<editShipInfo_args>
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
							
							vipapis.delivery.Ship elem0;
							
							elem0 = new vipapis.delivery.Ship();
							vipapis.delivery.ShipHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
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
		
		
		
		
		public class exportOrderById_argsHelper : TBeanSerializer<exportOrderById_args>
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
		
		
		
		
		public class getCarrierList_argsHelper : TBeanSerializer<getCarrierList_args>
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
		
		
		
		
		public class getOrderDetail_argsHelper : TBeanSerializer<getOrderDetail_args>
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
		
		
		
		
		public class getOrderFinancialFields_argsHelper : TBeanSerializer<getOrderFinancialFields_args>
		{
			
			public static getOrderFinancialFields_argsHelper OBJ = new getOrderFinancialFields_argsHelper();
			
			public static getOrderFinancialFields_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderFinancialFields_args structs, Protocol iprot){
				
				
				
				
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
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetDeduction_indicator(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetActive_no(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderFinancialFields_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDeduction_indicator() != null) {
					
					oprot.WriteFieldBegin("deduction_indicator");
					oprot.WriteI32((int)structs.GetDeduction_indicator()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("deduction_indicator can not be null!");
				}
				
				
				if(structs.GetActive_no() != null) {
					
					oprot.WriteFieldBegin("active_no");
					oprot.WriteString(structs.GetActive_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderFinancialFields_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderList_argsHelper : TBeanSerializer<getOrderList_args>
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
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSale_type(value);
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
				
				
				if(structs.GetSale_type() != null) {
					
					oprot.WriteFieldBegin("sale_type");
					oprot.WriteString(structs.GetSale_type());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderListByCreateTime_argsHelper : TBeanSerializer<getOrderListByCreateTime_args>
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
		
		
		
		
		public class getOrderReturnDetails_argsHelper : TBeanSerializer<getOrderReturnDetails_args>
		{
			
			public static getOrderReturnDetails_argsHelper OBJ = new getOrderReturnDetails_argsHelper();
			
			public static getOrderReturnDetails_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderReturnDetails_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.ReturnOrderDetailsRequest value;
					
					value = new vipapis.delivery.ReturnOrderDetailsRequest();
					vipapis.delivery.ReturnOrderDetailsRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderReturnDetails_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.delivery.ReturnOrderDetailsRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderReturnDetails_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderReturnList_argsHelper : TBeanSerializer<getOrderReturnList_args>
		{
			
			public static getOrderReturnList_argsHelper OBJ = new getOrderReturnList_argsHelper();
			
			public static getOrderReturnList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderReturnList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSt_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEt_time(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
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
					
					structs.SetReturn_type(value);
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
			
			
			public void Write(getOrderReturnList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSt_time() != null) {
					
					oprot.WriteFieldBegin("st_time");
					oprot.WriteString(structs.GetSt_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("st_time can not be null!");
				}
				
				
				if(structs.GetEt_time() != null) {
					
					oprot.WriteFieldBegin("et_time");
					oprot.WriteString(structs.GetEt_time());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("et_time can not be null!");
				}
				
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI64((long)structs.GetVendor_id()); 
					
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
				
				
				if(structs.GetReturn_type() != null) {
					
					oprot.WriteFieldBegin("return_type");
					oprot.WriteI32((int)structs.GetReturn_type()); 
					
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
			
			
			public void Validate(getOrderReturnList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderStatusById_argsHelper : TBeanSerializer<getOrderStatusById_args>
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
		
		
		
		
		public class getPrintTemplate_argsHelper : TBeanSerializer<getPrintTemplate_args>
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
		
		
		
		
		public class getReturnList_argsHelper : TBeanSerializer<getReturnList_args>
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
		
		
		
		
		public class getReturnProduct_argsHelper : TBeanSerializer<getReturnProduct_args>
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
		
		
		
		
		public class healthCheck_argsHelper : TBeanSerializer<healthCheck_args>
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
		
		
		
		
		public class mergeAfterSaleAddress_argsHelper : TBeanSerializer<mergeAfterSaleAddress_args>
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
		
		
		
		
		public class refuseOrder_argsHelper : TBeanSerializer<refuseOrder_args>
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
		
		
		
		
		public class returnOrder_argsHelper : TBeanSerializer<returnOrder_args>
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
		
		
		
		
		public class ship_argsHelper : TBeanSerializer<ship_args>
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
		
		
		
		
		public class auditReturnResult_resultHelper : TBeanSerializer<auditReturnResult_result>
		{
			
			public static auditReturnResult_resultHelper OBJ = new auditReturnResult_resultHelper();
			
			public static auditReturnResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(auditReturnResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(auditReturnResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(auditReturnResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmRefuseResult_resultHelper : TBeanSerializer<confirmRefuseResult_result>
		{
			
			public static confirmRefuseResult_resultHelper OBJ = new confirmRefuseResult_resultHelper();
			
			public static confirmRefuseResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmRefuseResult_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmRefuseResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmRefuseResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmReturnOrder_resultHelper : TBeanSerializer<confirmReturnOrder_result>
		{
			
			public static confirmReturnOrder_resultHelper OBJ = new confirmReturnOrder_resultHelper();
			
			public static confirmReturnOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmReturnOrder_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmReturnOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmReturnOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmReturnResult_resultHelper : TBeanSerializer<confirmReturnResult_result>
		{
			
			public static confirmReturnResult_resultHelper OBJ = new confirmReturnResult_resultHelper();
			
			public static confirmReturnResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmReturnResult_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmReturnResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmReturnResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editShipInfo_resultHelper : TBeanSerializer<editShipInfo_result>
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
		
		
		
		
		public class exportOrderById_resultHelper : TBeanSerializer<exportOrderById_result>
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
		
		
		
		
		public class getCarrierList_resultHelper : TBeanSerializer<getCarrierList_result>
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
		
		
		
		
		public class getOrderDetail_resultHelper : TBeanSerializer<getOrderDetail_result>
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
		
		
		
		
		public class getOrderFinancialFields_resultHelper : TBeanSerializer<getOrderFinancialFields_result>
		{
			
			public static getOrderFinancialFields_resultHelper OBJ = new getOrderFinancialFields_resultHelper();
			
			public static getOrderFinancialFields_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderFinancialFields_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.delivery.OrderFinancialFields> value;
					
					value = new List<vipapis.delivery.OrderFinancialFields>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.delivery.OrderFinancialFields elem0;
							
							elem0 = new vipapis.delivery.OrderFinancialFields();
							vipapis.delivery.OrderFinancialFieldsHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getOrderFinancialFields_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.delivery.OrderFinancialFields _item0 in structs.GetSuccess()){
						
						
						vipapis.delivery.OrderFinancialFieldsHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderFinancialFields_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderList_resultHelper : TBeanSerializer<getOrderList_result>
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
		
		
		
		
		public class getOrderListByCreateTime_resultHelper : TBeanSerializer<getOrderListByCreateTime_result>
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
		
		
		
		
		public class getOrderReturnDetails_resultHelper : TBeanSerializer<getOrderReturnDetails_result>
		{
			
			public static getOrderReturnDetails_resultHelper OBJ = new getOrderReturnDetails_resultHelper();
			
			public static getOrderReturnDetails_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderReturnDetails_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.OrderReturnDetailResponse value;
					
					value = new vipapis.delivery.OrderReturnDetailResponse();
					vipapis.delivery.OrderReturnDetailResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderReturnDetails_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.OrderReturnDetailResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderReturnDetails_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderReturnList_resultHelper : TBeanSerializer<getOrderReturnList_result>
		{
			
			public static getOrderReturnList_resultHelper OBJ = new getOrderReturnList_resultHelper();
			
			public static getOrderReturnList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderReturnList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.delivery.OrderReturnResponse value;
					
					value = new vipapis.delivery.OrderReturnResponse();
					vipapis.delivery.OrderReturnResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderReturnList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.delivery.OrderReturnResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderReturnList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderStatusById_resultHelper : TBeanSerializer<getOrderStatusById_result>
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
		
		
		
		
		public class getPrintTemplate_resultHelper : TBeanSerializer<getPrintTemplate_result>
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
		
		
		
		
		public class getReturnList_resultHelper : TBeanSerializer<getReturnList_result>
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
		
		
		
		
		public class getReturnProduct_resultHelper : TBeanSerializer<getReturnProduct_result>
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
		
		
		
		
		public class healthCheck_resultHelper : TBeanSerializer<healthCheck_result>
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
		
		
		
		
		public class mergeAfterSaleAddress_resultHelper : TBeanSerializer<mergeAfterSaleAddress_result>
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
		
		
		
		
		public class refuseOrder_resultHelper : TBeanSerializer<refuseOrder_result>
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
		
		
		
		
		public class returnOrder_resultHelper : TBeanSerializer<returnOrder_result>
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
		
		
		
		
		public class ship_resultHelper : TBeanSerializer<ship_result>
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
			
			
			
			public bool? auditReturnResult(vipapis.delivery.AuditReturnResultRequest request_) {
				
				send_auditReturnResult(request_);
				return recv_auditReturnResult(); 
				
			}
			
			
			private void send_auditReturnResult(vipapis.delivery.AuditReturnResultRequest request_){
				
				InitInvocation("auditReturnResult");
				
				auditReturnResult_args args = new auditReturnResult_args();
				args.SetRequest(request_);
				
				SendBase(args, auditReturnResult_argsHelper.getInstance());
			}
			
			
			private bool? recv_auditReturnResult(){
				
				auditReturnResult_result result = new auditReturnResult_result();
				ReceiveBase(result, auditReturnResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void confirmRefuseResult(vipapis.delivery.ConfirmRefuseResultRequest request_) {
				
				send_confirmRefuseResult(request_);
				recv_confirmRefuseResult();
				
			}
			
			
			private void send_confirmRefuseResult(vipapis.delivery.ConfirmRefuseResultRequest request_){
				
				InitInvocation("confirmRefuseResult");
				
				confirmRefuseResult_args args = new confirmRefuseResult_args();
				args.SetRequest(request_);
				
				SendBase(args, confirmRefuseResult_argsHelper.getInstance());
			}
			
			
			private void recv_confirmRefuseResult(){
				
				confirmRefuseResult_result result = new confirmRefuseResult_result();
				ReceiveBase(result, confirmRefuseResult_resultHelper.getInstance());
				
				
			}
			
			
			public void confirmReturnOrder(vipapis.delivery.ConfirmReturnOrderRequest request_) {
				
				send_confirmReturnOrder(request_);
				recv_confirmReturnOrder();
				
			}
			
			
			private void send_confirmReturnOrder(vipapis.delivery.ConfirmReturnOrderRequest request_){
				
				InitInvocation("confirmReturnOrder");
				
				confirmReturnOrder_args args = new confirmReturnOrder_args();
				args.SetRequest(request_);
				
				SendBase(args, confirmReturnOrder_argsHelper.getInstance());
			}
			
			
			private void recv_confirmReturnOrder(){
				
				confirmReturnOrder_result result = new confirmReturnOrder_result();
				ReceiveBase(result, confirmReturnOrder_resultHelper.getInstance());
				
				
			}
			
			
			public void confirmReturnResult(vipapis.delivery.ConfirmReturnResultRequest request_) {
				
				send_confirmReturnResult(request_);
				recv_confirmReturnResult();
				
			}
			
			
			private void send_confirmReturnResult(vipapis.delivery.ConfirmReturnResultRequest request_){
				
				InitInvocation("confirmReturnResult");
				
				confirmReturnResult_args args = new confirmReturnResult_args();
				args.SetRequest(request_);
				
				SendBase(args, confirmReturnResult_argsHelper.getInstance());
			}
			
			
			private void recv_confirmReturnResult(){
				
				confirmReturnResult_result result = new confirmReturnResult_result();
				ReceiveBase(result, confirmReturnResult_resultHelper.getInstance());
				
				
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
			
			
			public List<vipapis.delivery.OrderFinancialFields> getOrderFinancialFields(int vendor_id_,string order_id_,string po_no_,int deduction_indicator_,string active_no_) {
				
				send_getOrderFinancialFields(vendor_id_,order_id_,po_no_,deduction_indicator_,active_no_);
				return recv_getOrderFinancialFields(); 
				
			}
			
			
			private void send_getOrderFinancialFields(int vendor_id_,string order_id_,string po_no_,int deduction_indicator_,string active_no_){
				
				InitInvocation("getOrderFinancialFields");
				
				getOrderFinancialFields_args args = new getOrderFinancialFields_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_id(order_id_);
				args.SetPo_no(po_no_);
				args.SetDeduction_indicator(deduction_indicator_);
				args.SetActive_no(active_no_);
				
				SendBase(args, getOrderFinancialFields_argsHelper.getInstance());
			}
			
			
			private List<vipapis.delivery.OrderFinancialFields> recv_getOrderFinancialFields(){
				
				getOrderFinancialFields_result result = new getOrderFinancialFields_result();
				ReceiveBase(result, getOrderFinancialFields_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.GetOrderListResponse getOrderList(string st_add_time_,string et_add_time_,vipapis.common.OrderStatus? order_status_,string po_no_,string order_id_,string vendor_id_,int? page_,int? limit_,string sale_type_) {
				
				send_getOrderList(st_add_time_,et_add_time_,order_status_,po_no_,order_id_,vendor_id_,page_,limit_,sale_type_);
				return recv_getOrderList(); 
				
			}
			
			
			private void send_getOrderList(string st_add_time_,string et_add_time_,vipapis.common.OrderStatus? order_status_,string po_no_,string order_id_,string vendor_id_,int? page_,int? limit_,string sale_type_){
				
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
				args.SetSale_type(sale_type_);
				
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
			
			
			public vipapis.delivery.OrderReturnDetailResponse getOrderReturnDetails(vipapis.delivery.ReturnOrderDetailsRequest request_) {
				
				send_getOrderReturnDetails(request_);
				return recv_getOrderReturnDetails(); 
				
			}
			
			
			private void send_getOrderReturnDetails(vipapis.delivery.ReturnOrderDetailsRequest request_){
				
				InitInvocation("getOrderReturnDetails");
				
				getOrderReturnDetails_args args = new getOrderReturnDetails_args();
				args.SetRequest(request_);
				
				SendBase(args, getOrderReturnDetails_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.OrderReturnDetailResponse recv_getOrderReturnDetails(){
				
				getOrderReturnDetails_result result = new getOrderReturnDetails_result();
				ReceiveBase(result, getOrderReturnDetails_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.delivery.OrderReturnResponse getOrderReturnList(string st_time_,string et_time_,long vendor_id_,string order_id_,int? return_type_,int? page_,int? limit_) {
				
				send_getOrderReturnList(st_time_,et_time_,vendor_id_,order_id_,return_type_,page_,limit_);
				return recv_getOrderReturnList(); 
				
			}
			
			
			private void send_getOrderReturnList(string st_time_,string et_time_,long vendor_id_,string order_id_,int? return_type_,int? page_,int? limit_){
				
				InitInvocation("getOrderReturnList");
				
				getOrderReturnList_args args = new getOrderReturnList_args();
				args.SetSt_time(st_time_);
				args.SetEt_time(et_time_);
				args.SetVendor_id(vendor_id_);
				args.SetOrder_id(order_id_);
				args.SetReturn_type(return_type_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getOrderReturnList_argsHelper.getInstance());
			}
			
			
			private vipapis.delivery.OrderReturnResponse recv_getOrderReturnList(){
				
				getOrderReturnList_result result = new getOrderReturnList_result();
				ReceiveBase(result, getOrderReturnList_resultHelper.getInstance());
				
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