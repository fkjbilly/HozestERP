using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.orderservice.service{
	
	
	public class HtSaleOrderVopServiceHelper {
		
		
		
		public class findOrderResultByParams_args {
			
			///<summary>
			/// 仓库编码,如:云仓代运营 HT_NBYC
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 订单号,多个订单号用英文逗号分开
			///</summary>
			
			private string orderSn_;
			
			///<summary>
			/// 数量,这里默认为不传默认为:100,最大只返回100条
			///</summary>
			
			private int? num_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			
		}
		
		
		
		
		public class findOrderResultModelByParams_args {
			
			///<summary>
			/// 仓库编码,如:云仓代运营 HT_NBYC
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 订单号,多个订单号用英文逗号分开
			///</summary>
			
			private string orderSn_;
			
			///<summary>
			/// 数量,这里默认为不传默认为:100,最大只返回100条
			///</summary>
			
			private int? num_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderCancellation_args {
			
			///<summary>
			/// 报关行编码
			///</summary>
			
			private string carrierCode_;
			
			///<summary>
			/// 关口
			///</summary>
			
			private string customsCode_;
			
			///<summary>
			/// 数量
			///</summary>
			
			private int? num_;
			
			public string GetCarrierCode(){
				return this.carrierCode_;
			}
			
			public void SetCarrierCode(string value){
				this.carrierCode_ = value;
			}
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderList_args {
			
			///<summary>
			/// 报关行
			///</summary>
			
			private string carriercode_;
			
			///<summary>
			/// 订单号,多个订单号用英文逗号分开
			///</summary>
			
			private string orderSn_;
			
			///<summary>
			/// 数量,这里默认为不传默认为:100,最大只返回100条
			///</summary>
			
			private int? num_;
			
			///<summary>
			/// 关口
			///</summary>
			
			private string customsCode_;
			
			public string GetCarriercode(){
				return this.carriercode_;
			}
			
			public void SetCarriercode(string value){
				this.carriercode_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderListByOrderType_args {
			
			///<summary>
			/// 报关行
			///</summary>
			
			private string carriercode_;
			
			///<summary>
			/// 订单号,多个订单号用英文逗号分开
			///</summary>
			
			private string orderSn_;
			
			///<summary>
			/// 数量,这里默认为不传默认为:100,最大只返回100条
			///</summary>
			
			private int? num_;
			
			///<summary>
			/// 关口
			///</summary>
			
			private string customsCode_;
			
			///<summary>
			/// 订单类型
			///</summary>
			
			private string orderType_;
			
			public string GetCarriercode(){
				return this.carriercode_;
			}
			
			public void SetCarriercode(string value){
				this.carriercode_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			public string GetOrderType(){
				return this.orderType_;
			}
			
			public void SetOrderType(string value){
				this.orderType_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderModelList_args {
			
			///<summary>
			/// 报关行
			///</summary>
			
			private string carriercode_;
			
			///<summary>
			/// 订单号,多个订单号用英文逗号分开
			///</summary>
			
			private string orderSn_;
			
			///<summary>
			/// 数量,这里默认为不传默认为:100,最大只返回100条
			///</summary>
			
			private int? num_;
			
			///<summary>
			/// 关口
			///</summary>
			
			private string customsCode_;
			
			public string GetCarriercode(){
				return this.carriercode_;
			}
			
			public void SetCarriercode(string value){
				this.carriercode_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderModelListByOrderType_args {
			
			///<summary>
			/// 报关行
			///</summary>
			
			private string carriercode_;
			
			///<summary>
			/// 订单号,多个订单号用英文逗号分开
			///</summary>
			
			private string orderSn_;
			
			///<summary>
			/// 数量,这里默认为不传默认为:100,最大只返回100条
			///</summary>
			
			private int? num_;
			
			///<summary>
			/// 关口
			///</summary>
			
			private string customsCode_;
			
			///<summary>
			/// 订单类型
			///</summary>
			
			private string orderType_;
			
			public string GetCarriercode(){
				return this.carriercode_;
			}
			
			public void SetCarriercode(string value){
				this.carriercode_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			public int? GetNum(){
				return this.num_;
			}
			
			public void SetNum(int? value){
				this.num_ = value;
			}
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			public string GetOrderType(){
				return this.orderType_;
			}
			
			public void SetOrderType(string value){
				this.orderType_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateCancelOrderStatus_args {
			
			///<summary>
			/// 报关行
			///</summary>
			
			private string carriercode_;
			
			///<summary>
			/// 回抛多个订单结果
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResult resultList_;
			
			///<summary>
			/// 是否更新状态
			///</summary>
			
			private bool? isUpdateStatus_;
			
			public string GetCarriercode(){
				return this.carriercode_;
			}
			
			public void SetCarriercode(string value){
				this.carriercode_ = value;
			}
			public com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResult GetResultList(){
				return this.resultList_;
			}
			
			public void SetResultList(com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResult value){
				this.resultList_ = value;
			}
			public bool? GetIsUpdateStatus(){
				return this.isUpdateStatus_;
			}
			
			public void SetIsUpdateStatus(bool? value){
				this.isUpdateStatus_ = value;
			}
			
		}
		
		
		
		
		public class updateSendChbOrderStatusByOrderSn_args {
			
			///<summary>
			/// 报关行
			///</summary>
			
			private string carriercode_;
			
			///<summary>
			/// 订单号,多个订单号用英文逗号分开
			///</summary>
			
			private string orderSn_;
			
			///<summary>
			/// 关口
			///</summary>
			
			private string customsCode_;
			
			public string GetCarriercode(){
				return this.carriercode_;
			}
			
			public void SetCarriercode(string value){
				this.carriercode_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			
		}
		
		
		
		
		public class updateSendOrderStatusByOrderSn_args {
			
			///<summary>
			/// 仓库编码,如:云仓代运营 HT_NBYC
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 订单请求参数,逗号多个以逗号分隔
			///</summary>
			
			private string orderSn_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			
		}
		
		
		
		
		public class findOrderResultByParams_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.haitao.orderservice.service.HtSaleOrderResult> success_;
			
			public List<com.vip.haitao.orderservice.service.HtSaleOrderResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.haitao.orderservice.service.HtSaleOrderResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class findOrderResultModelByParams_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.haitao.orderservice.service.HtSaleOrderResultModel> success_;
			
			public List<com.vip.haitao.orderservice.service.HtSaleOrderResultModel> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.haitao.orderservice.service.HtSaleOrderResultModel> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderCancellation_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtSaleOrderCancellationResult success_;
			
			public com.vip.haitao.orderservice.service.HtSaleOrderCancellationResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtSaleOrderCancellationResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult success_;
			
			public com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderListByOrderType_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult success_;
			
			public com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderModelList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel success_;
			
			public com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSaleOrderModelListByOrderType_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel success_;
			
			public com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel value){
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
		
		
		
		
		public class updateCancelOrderStatus_result {
			
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
		
		
		
		
		public class updateSendChbOrderStatusByOrderSn_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult success_;
			
			public com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateSendOrderStatusByOrderSn_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult success_;
			
			public com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class findOrderResultByParams_argsHelper : TBeanSerializer<findOrderResultByParams_args>
		{
			
			public static findOrderResultByParams_argsHelper OBJ = new findOrderResultByParams_argsHelper();
			
			public static findOrderResultByParams_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findOrderResultByParams_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findOrderResultByParams_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findOrderResultByParams_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findOrderResultModelByParams_argsHelper : TBeanSerializer<findOrderResultModelByParams_args>
		{
			
			public static findOrderResultModelByParams_argsHelper OBJ = new findOrderResultModelByParams_argsHelper();
			
			public static findOrderResultModelByParams_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findOrderResultModelByParams_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findOrderResultModelByParams_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findOrderResultModelByParams_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderCancellation_argsHelper : TBeanSerializer<getSaleOrderCancellation_args>
		{
			
			public static getSaleOrderCancellation_argsHelper OBJ = new getSaleOrderCancellation_argsHelper();
			
			public static getSaleOrderCancellation_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderCancellation_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarrierCode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderCancellation_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCarrierCode() != null) {
					
					oprot.WriteFieldBegin("carrierCode");
					oprot.WriteString(structs.GetCarrierCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carrierCode can not be null!");
				}
				
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("customsCode can not be null!");
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderCancellation_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderList_argsHelper : TBeanSerializer<getSaleOrderList_args>
		{
			
			public static getSaleOrderList_argsHelper OBJ = new getSaleOrderList_argsHelper();
			
			public static getSaleOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarriercode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCarriercode() != null) {
					
					oprot.WriteFieldBegin("carriercode");
					oprot.WriteString(structs.GetCarriercode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carriercode can not be null!");
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("customsCode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderListByOrderType_argsHelper : TBeanSerializer<getSaleOrderListByOrderType_args>
		{
			
			public static getSaleOrderListByOrderType_argsHelper OBJ = new getSaleOrderListByOrderType_argsHelper();
			
			public static getSaleOrderListByOrderType_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderListByOrderType_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarriercode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderType(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderListByOrderType_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCarriercode() != null) {
					
					oprot.WriteFieldBegin("carriercode");
					oprot.WriteString(structs.GetCarriercode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carriercode can not be null!");
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("customsCode can not be null!");
				}
				
				
				if(structs.GetOrderType() != null) {
					
					oprot.WriteFieldBegin("orderType");
					oprot.WriteString(structs.GetOrderType());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderType can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderListByOrderType_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderModelList_argsHelper : TBeanSerializer<getSaleOrderModelList_args>
		{
			
			public static getSaleOrderModelList_argsHelper OBJ = new getSaleOrderModelList_argsHelper();
			
			public static getSaleOrderModelList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderModelList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarriercode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderModelList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCarriercode() != null) {
					
					oprot.WriteFieldBegin("carriercode");
					oprot.WriteString(structs.GetCarriercode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carriercode can not be null!");
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("customsCode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderModelList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderModelListByOrderType_argsHelper : TBeanSerializer<getSaleOrderModelListByOrderType_args>
		{
			
			public static getSaleOrderModelListByOrderType_argsHelper OBJ = new getSaleOrderModelListByOrderType_argsHelper();
			
			public static getSaleOrderModelListByOrderType_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderModelListByOrderType_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarriercode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetNum(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderType(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderModelListByOrderType_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCarriercode() != null) {
					
					oprot.WriteFieldBegin("carriercode");
					oprot.WriteString(structs.GetCarriercode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carriercode can not be null!");
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetNum() != null) {
					
					oprot.WriteFieldBegin("num");
					oprot.WriteI32((int)structs.GetNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("customsCode can not be null!");
				}
				
				
				if(structs.GetOrderType() != null) {
					
					oprot.WriteFieldBegin("orderType");
					oprot.WriteString(structs.GetOrderType());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderType can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderModelListByOrderType_args bean){
				
				
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
		
		
		
		
		public class updateCancelOrderStatus_argsHelper : TBeanSerializer<updateCancelOrderStatus_args>
		{
			
			public static updateCancelOrderStatus_argsHelper OBJ = new updateCancelOrderStatus_argsHelper();
			
			public static updateCancelOrderStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateCancelOrderStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarriercode(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResult value;
					
					value = new com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResult();
					com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResultHelper.getInstance().Read(value, iprot);
					
					structs.SetResultList(value);
				}
				
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetIsUpdateStatus(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateCancelOrderStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCarriercode() != null) {
					
					oprot.WriteFieldBegin("carriercode");
					oprot.WriteString(structs.GetCarriercode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carriercode can not be null!");
				}
				
				
				if(structs.GetResultList() != null) {
					
					oprot.WriteFieldBegin("resultList");
					
					com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResultHelper.getInstance().Write(structs.GetResultList(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("resultList can not be null!");
				}
				
				
				if(structs.GetIsUpdateStatus() != null) {
					
					oprot.WriteFieldBegin("isUpdateStatus");
					oprot.WriteBool((bool)structs.GetIsUpdateStatus());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("isUpdateStatus can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateCancelOrderStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSendChbOrderStatusByOrderSn_argsHelper : TBeanSerializer<updateSendChbOrderStatusByOrderSn_args>
		{
			
			public static updateSendChbOrderStatusByOrderSn_argsHelper OBJ = new updateSendChbOrderStatusByOrderSn_argsHelper();
			
			public static updateSendChbOrderStatusByOrderSn_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSendChbOrderStatusByOrderSn_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarriercode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSendChbOrderStatusByOrderSn_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCarriercode() != null) {
					
					oprot.WriteFieldBegin("carriercode");
					oprot.WriteString(structs.GetCarriercode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carriercode can not be null!");
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderSn can not be null!");
				}
				
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("customsCode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSendChbOrderStatusByOrderSn_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSendOrderStatusByOrderSn_argsHelper : TBeanSerializer<updateSendOrderStatusByOrderSn_args>
		{
			
			public static updateSendOrderStatusByOrderSn_argsHelper OBJ = new updateSendOrderStatusByOrderSn_argsHelper();
			
			public static updateSendOrderStatusByOrderSn_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSendOrderStatusByOrderSn_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSendOrderStatusByOrderSn_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSendOrderStatusByOrderSn_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findOrderResultByParams_resultHelper : TBeanSerializer<findOrderResultByParams_result>
		{
			
			public static findOrderResultByParams_resultHelper OBJ = new findOrderResultByParams_resultHelper();
			
			public static findOrderResultByParams_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findOrderResultByParams_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.haitao.orderservice.service.HtSaleOrderResult> value;
					
					value = new List<com.vip.haitao.orderservice.service.HtSaleOrderResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.haitao.orderservice.service.HtSaleOrderResult elem0;
							
							elem0 = new com.vip.haitao.orderservice.service.HtSaleOrderResult();
							com.vip.haitao.orderservice.service.HtSaleOrderResultHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(findOrderResultByParams_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.haitao.orderservice.service.HtSaleOrderResult _item0 in structs.GetSuccess()){
						
						
						com.vip.haitao.orderservice.service.HtSaleOrderResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findOrderResultByParams_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findOrderResultModelByParams_resultHelper : TBeanSerializer<findOrderResultModelByParams_result>
		{
			
			public static findOrderResultModelByParams_resultHelper OBJ = new findOrderResultModelByParams_resultHelper();
			
			public static findOrderResultModelByParams_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findOrderResultModelByParams_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.haitao.orderservice.service.HtSaleOrderResultModel> value;
					
					value = new List<com.vip.haitao.orderservice.service.HtSaleOrderResultModel>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.haitao.orderservice.service.HtSaleOrderResultModel elem1;
							
							elem1 = new com.vip.haitao.orderservice.service.HtSaleOrderResultModel();
							com.vip.haitao.orderservice.service.HtSaleOrderResultModelHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(findOrderResultModelByParams_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.haitao.orderservice.service.HtSaleOrderResultModel _item0 in structs.GetSuccess()){
						
						
						com.vip.haitao.orderservice.service.HtSaleOrderResultModelHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findOrderResultModelByParams_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderCancellation_resultHelper : TBeanSerializer<getSaleOrderCancellation_result>
		{
			
			public static getSaleOrderCancellation_resultHelper OBJ = new getSaleOrderCancellation_resultHelper();
			
			public static getSaleOrderCancellation_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderCancellation_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtSaleOrderCancellationResult value;
					
					value = new com.vip.haitao.orderservice.service.HtSaleOrderCancellationResult();
					com.vip.haitao.orderservice.service.HtSaleOrderCancellationResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderCancellation_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtSaleOrderCancellationResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderCancellation_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderList_resultHelper : TBeanSerializer<getSaleOrderList_result>
		{
			
			public static getSaleOrderList_resultHelper OBJ = new getSaleOrderList_resultHelper();
			
			public static getSaleOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult value;
					
					value = new com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult();
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderListByOrderType_resultHelper : TBeanSerializer<getSaleOrderListByOrderType_result>
		{
			
			public static getSaleOrderListByOrderType_resultHelper OBJ = new getSaleOrderListByOrderType_resultHelper();
			
			public static getSaleOrderListByOrderType_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderListByOrderType_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult value;
					
					value = new com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult();
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderListByOrderType_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderListByOrderType_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderModelList_resultHelper : TBeanSerializer<getSaleOrderModelList_result>
		{
			
			public static getSaleOrderModelList_resultHelper OBJ = new getSaleOrderModelList_resultHelper();
			
			public static getSaleOrderModelList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderModelList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel value;
					
					value = new com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel();
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderModelList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderModelList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleOrderModelListByOrderType_resultHelper : TBeanSerializer<getSaleOrderModelListByOrderType_result>
		{
			
			public static getSaleOrderModelListByOrderType_resultHelper OBJ = new getSaleOrderModelListByOrderType_resultHelper();
			
			public static getSaleOrderModelListByOrderType_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleOrderModelListByOrderType_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel value;
					
					value = new com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel();
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleOrderModelListByOrderType_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleOrderModelListByOrderType_result bean){
				
				
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
		
		
		
		
		public class updateCancelOrderStatus_resultHelper : TBeanSerializer<updateCancelOrderStatus_result>
		{
			
			public static updateCancelOrderStatus_resultHelper OBJ = new updateCancelOrderStatus_resultHelper();
			
			public static updateCancelOrderStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateCancelOrderStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateCancelOrderStatus_result structs, Protocol oprot){
				
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
			
			
			public void Validate(updateCancelOrderStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSendChbOrderStatusByOrderSn_resultHelper : TBeanSerializer<updateSendChbOrderStatusByOrderSn_result>
		{
			
			public static updateSendChbOrderStatusByOrderSn_resultHelper OBJ = new updateSendChbOrderStatusByOrderSn_resultHelper();
			
			public static updateSendChbOrderStatusByOrderSn_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSendChbOrderStatusByOrderSn_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult value;
					
					value = new com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult();
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSendChbOrderStatusByOrderSn_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSendChbOrderStatusByOrderSn_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSendOrderStatusByOrderSn_resultHelper : TBeanSerializer<updateSendOrderStatusByOrderSn_result>
		{
			
			public static updateSendOrderStatusByOrderSn_resultHelper OBJ = new updateSendOrderStatusByOrderSn_resultHelper();
			
			public static updateSendOrderStatusByOrderSn_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSendOrderStatusByOrderSn_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult value;
					
					value = new com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult();
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSendOrderStatusByOrderSn_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSendOrderStatusByOrderSn_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class HtSaleOrderVopServiceClient : OspRestStub , HtSaleOrderVopService  {
			
			
			public HtSaleOrderVopServiceClient():base("vipapis.orderservice.service.HtSaleOrderVopService","1.0.0") {
				
				
			}
			
			
			
			public List<com.vip.haitao.orderservice.service.HtSaleOrderResult> findOrderResultByParams(string warehouse_,string orderSn_,int? num_) {
				
				send_findOrderResultByParams(warehouse_,orderSn_,num_);
				return recv_findOrderResultByParams(); 
				
			}
			
			
			private void send_findOrderResultByParams(string warehouse_,string orderSn_,int? num_){
				
				InitInvocation("findOrderResultByParams");
				
				findOrderResultByParams_args args = new findOrderResultByParams_args();
				args.SetWarehouse(warehouse_);
				args.SetOrderSn(orderSn_);
				args.SetNum(num_);
				
				SendBase(args, findOrderResultByParams_argsHelper.getInstance());
			}
			
			
			private List<com.vip.haitao.orderservice.service.HtSaleOrderResult> recv_findOrderResultByParams(){
				
				findOrderResultByParams_result result = new findOrderResultByParams_result();
				ReceiveBase(result, findOrderResultByParams_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.haitao.orderservice.service.HtSaleOrderResultModel> findOrderResultModelByParams(string warehouse_,string orderSn_,int? num_) {
				
				send_findOrderResultModelByParams(warehouse_,orderSn_,num_);
				return recv_findOrderResultModelByParams(); 
				
			}
			
			
			private void send_findOrderResultModelByParams(string warehouse_,string orderSn_,int? num_){
				
				InitInvocation("findOrderResultModelByParams");
				
				findOrderResultModelByParams_args args = new findOrderResultModelByParams_args();
				args.SetWarehouse(warehouse_);
				args.SetOrderSn(orderSn_);
				args.SetNum(num_);
				
				SendBase(args, findOrderResultModelByParams_argsHelper.getInstance());
			}
			
			
			private List<com.vip.haitao.orderservice.service.HtSaleOrderResultModel> recv_findOrderResultModelByParams(){
				
				findOrderResultModelByParams_result result = new findOrderResultModelByParams_result();
				ReceiveBase(result, findOrderResultModelByParams_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.orderservice.service.HtSaleOrderCancellationResult getSaleOrderCancellation(string carrierCode_,string customsCode_,int? num_) {
				
				send_getSaleOrderCancellation(carrierCode_,customsCode_,num_);
				return recv_getSaleOrderCancellation(); 
				
			}
			
			
			private void send_getSaleOrderCancellation(string carrierCode_,string customsCode_,int? num_){
				
				InitInvocation("getSaleOrderCancellation");
				
				getSaleOrderCancellation_args args = new getSaleOrderCancellation_args();
				args.SetCarrierCode(carrierCode_);
				args.SetCustomsCode(customsCode_);
				args.SetNum(num_);
				
				SendBase(args, getSaleOrderCancellation_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtSaleOrderCancellationResult recv_getSaleOrderCancellation(){
				
				getSaleOrderCancellation_result result = new getSaleOrderCancellation_result();
				ReceiveBase(result, getSaleOrderCancellation_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult getSaleOrderList(string carriercode_,string orderSn_,int? num_,string customsCode_) {
				
				send_getSaleOrderList(carriercode_,orderSn_,num_,customsCode_);
				return recv_getSaleOrderList(); 
				
			}
			
			
			private void send_getSaleOrderList(string carriercode_,string orderSn_,int? num_,string customsCode_){
				
				InitInvocation("getSaleOrderList");
				
				getSaleOrderList_args args = new getSaleOrderList_args();
				args.SetCarriercode(carriercode_);
				args.SetOrderSn(orderSn_);
				args.SetNum(num_);
				args.SetCustomsCode(customsCode_);
				
				SendBase(args, getSaleOrderList_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult recv_getSaleOrderList(){
				
				getSaleOrderList_result result = new getSaleOrderList_result();
				ReceiveBase(result, getSaleOrderList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult getSaleOrderListByOrderType(string carriercode_,string orderSn_,int? num_,string customsCode_,string orderType_) {
				
				send_getSaleOrderListByOrderType(carriercode_,orderSn_,num_,customsCode_,orderType_);
				return recv_getSaleOrderListByOrderType(); 
				
			}
			
			
			private void send_getSaleOrderListByOrderType(string carriercode_,string orderSn_,int? num_,string customsCode_,string orderType_){
				
				InitInvocation("getSaleOrderListByOrderType");
				
				getSaleOrderListByOrderType_args args = new getSaleOrderListByOrderType_args();
				args.SetCarriercode(carriercode_);
				args.SetOrderSn(orderSn_);
				args.SetNum(num_);
				args.SetCustomsCode(customsCode_);
				args.SetOrderType(orderType_);
				
				SendBase(args, getSaleOrderListByOrderType_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtCarrierSaleOrderResult recv_getSaleOrderListByOrderType(){
				
				getSaleOrderListByOrderType_result result = new getSaleOrderListByOrderType_result();
				ReceiveBase(result, getSaleOrderListByOrderType_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel getSaleOrderModelList(string carriercode_,string orderSn_,int? num_,string customsCode_) {
				
				send_getSaleOrderModelList(carriercode_,orderSn_,num_,customsCode_);
				return recv_getSaleOrderModelList(); 
				
			}
			
			
			private void send_getSaleOrderModelList(string carriercode_,string orderSn_,int? num_,string customsCode_){
				
				InitInvocation("getSaleOrderModelList");
				
				getSaleOrderModelList_args args = new getSaleOrderModelList_args();
				args.SetCarriercode(carriercode_);
				args.SetOrderSn(orderSn_);
				args.SetNum(num_);
				args.SetCustomsCode(customsCode_);
				
				SendBase(args, getSaleOrderModelList_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel recv_getSaleOrderModelList(){
				
				getSaleOrderModelList_result result = new getSaleOrderModelList_result();
				ReceiveBase(result, getSaleOrderModelList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel getSaleOrderModelListByOrderType(string carriercode_,string orderSn_,int? num_,string customsCode_,string orderType_) {
				
				send_getSaleOrderModelListByOrderType(carriercode_,orderSn_,num_,customsCode_,orderType_);
				return recv_getSaleOrderModelListByOrderType(); 
				
			}
			
			
			private void send_getSaleOrderModelListByOrderType(string carriercode_,string orderSn_,int? num_,string customsCode_,string orderType_){
				
				InitInvocation("getSaleOrderModelListByOrderType");
				
				getSaleOrderModelListByOrderType_args args = new getSaleOrderModelListByOrderType_args();
				args.SetCarriercode(carriercode_);
				args.SetOrderSn(orderSn_);
				args.SetNum(num_);
				args.SetCustomsCode(customsCode_);
				args.SetOrderType(orderType_);
				
				SendBase(args, getSaleOrderModelListByOrderType_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtCarrierSaleOrderResultModel recv_getSaleOrderModelListByOrderType(){
				
				getSaleOrderModelListByOrderType_result result = new getSaleOrderModelListByOrderType_result();
				ReceiveBase(result, getSaleOrderModelListByOrderType_resultHelper.getInstance());
				
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
			
			
			public bool? updateCancelOrderStatus(string carriercode_,com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResult resultList_,bool isUpdateStatus_) {
				
				send_updateCancelOrderStatus(carriercode_,resultList_,isUpdateStatus_);
				return recv_updateCancelOrderStatus(); 
				
			}
			
			
			private void send_updateCancelOrderStatus(string carriercode_,com.vip.haitao.orderservice.service.HtSaleOrderCancellationCallbackResult resultList_,bool isUpdateStatus_){
				
				InitInvocation("updateCancelOrderStatus");
				
				updateCancelOrderStatus_args args = new updateCancelOrderStatus_args();
				args.SetCarriercode(carriercode_);
				args.SetResultList(resultList_);
				args.SetIsUpdateStatus(isUpdateStatus_);
				
				SendBase(args, updateCancelOrderStatus_argsHelper.getInstance());
			}
			
			
			private bool? recv_updateCancelOrderStatus(){
				
				updateCancelOrderStatus_result result = new updateCancelOrderStatus_result();
				ReceiveBase(result, updateCancelOrderStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult updateSendChbOrderStatusByOrderSn(string carriercode_,string orderSn_,string customsCode_) {
				
				send_updateSendChbOrderStatusByOrderSn(carriercode_,orderSn_,customsCode_);
				return recv_updateSendChbOrderStatusByOrderSn(); 
				
			}
			
			
			private void send_updateSendChbOrderStatusByOrderSn(string carriercode_,string orderSn_,string customsCode_){
				
				InitInvocation("updateSendChbOrderStatusByOrderSn");
				
				updateSendChbOrderStatusByOrderSn_args args = new updateSendChbOrderStatusByOrderSn_args();
				args.SetCarriercode(carriercode_);
				args.SetOrderSn(orderSn_);
				args.SetCustomsCode(customsCode_);
				
				SendBase(args, updateSendChbOrderStatusByOrderSn_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult recv_updateSendChbOrderStatusByOrderSn(){
				
				updateSendChbOrderStatusByOrderSn_result result = new updateSendChbOrderStatusByOrderSn_result();
				ReceiveBase(result, updateSendChbOrderStatusByOrderSn_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult updateSendOrderStatusByOrderSn(string warehouse_,string orderSn_) {
				
				send_updateSendOrderStatusByOrderSn(warehouse_,orderSn_);
				return recv_updateSendOrderStatusByOrderSn(); 
				
			}
			
			
			private void send_updateSendOrderStatusByOrderSn(string warehouse_,string orderSn_){
				
				InitInvocation("updateSendOrderStatusByOrderSn");
				
				updateSendOrderStatusByOrderSn_args args = new updateSendOrderStatusByOrderSn_args();
				args.SetWarehouse(warehouse_);
				args.SetOrderSn(orderSn_);
				
				SendBase(args, updateSendOrderStatusByOrderSn_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult recv_updateSendOrderStatusByOrderSn(){
				
				updateSendOrderStatusByOrderSn_result result = new updateSendOrderStatusByOrderSn_result();
				ReceiveBase(result, updateSendOrderStatusByOrderSn_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}