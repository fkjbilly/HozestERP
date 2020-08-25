using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.vipcard{
	
	
	public class VipCardServiceHelper {
		
		
		
		public class applyGroup_args {
			
			///<summary>
			/// 申请唯品卡批次请求信息
			///</summary>
			
			private vipapis.vipcard.ApplyGroupRequest applyGroupRequest_;
			
			public vipapis.vipcard.ApplyGroupRequest GetApplyGroupRequest(){
				return this.applyGroupRequest_;
			}
			
			public void SetApplyGroupRequest(vipapis.vipcard.ApplyGroupRequest value){
				this.applyGroupRequest_ = value;
			}
			
		}
		
		
		
		
		public class cancelCard_args {
			
			///<summary>
			/// 请求client_id
			///</summary>
			
			private int? client_id_;
			
			///<summary>
			/// 商家卡类型编号
			///</summary>
			
			private int? type_;
			
			///<summary>
			/// 唯品卡卡号,最多支持100个
			///</summary>
			
			private List<string> card_code_;
			
			///<summary>
			/// 自增流水号，如果小于等于系统记录的最后处理流水号忽略处理
			///</summary>
			
			private int? trans_id_;
			
			///<summary>
			/// 商家编码，<font color='red'>自2017年4月1号起此参数将调整为必传参数</font>
			///</summary>
			
			private string merchant_code_;
			
			public int? GetClient_id(){
				return this.client_id_;
			}
			
			public void SetClient_id(int? value){
				this.client_id_ = value;
			}
			public int? GetType(){
				return this.type_;
			}
			
			public void SetType(int? value){
				this.type_ = value;
			}
			public List<string> GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(List<string> value){
				this.card_code_ = value;
			}
			public int? GetTrans_id(){
				return this.trans_id_;
			}
			
			public void SetTrans_id(int? value){
				this.trans_id_ = value;
			}
			public string GetMerchant_code(){
				return this.merchant_code_;
			}
			
			public void SetMerchant_code(string value){
				this.merchant_code_ = value;
			}
			
		}
		
		
		
		
		public class cancelSoldCard_args {
			
			///<summary>
			/// 店铺名称
			///</summary>
			
			private string shop_name_;
			
			///<summary>
			/// 店铺地址
			///</summary>
			
			private string shop_area_;
			
			///<summary>
			/// 请求client_id
			///</summary>
			
			private int? client_id_;
			
			///<summary>
			/// 商家卡类型编号
			///</summary>
			
			private int? type_;
			
			///<summary>
			/// 唯品卡卡号
			///</summary>
			
			private string card_code_;
			
			///<summary>
			/// 自增流水号，如果小于等于系统记录的最后处理流水号忽略处理
			///</summary>
			
			private int? trans_id_;
			
			///<summary>
			/// 售出唯品卡使用的流水号，该售出流水号一旦冲正成功即无法再次使用
			///</summary>
			
			private int? sale_trans_id_;
			
			///<summary>
			/// 商家编码，<font color='red'>自2017年4月1号起此参数将调整为必传参数</font>
			///</summary>
			
			private string merchant_code_;
			
			public string GetShop_name(){
				return this.shop_name_;
			}
			
			public void SetShop_name(string value){
				this.shop_name_ = value;
			}
			public string GetShop_area(){
				return this.shop_area_;
			}
			
			public void SetShop_area(string value){
				this.shop_area_ = value;
			}
			public int? GetClient_id(){
				return this.client_id_;
			}
			
			public void SetClient_id(int? value){
				this.client_id_ = value;
			}
			public int? GetType(){
				return this.type_;
			}
			
			public void SetType(int? value){
				this.type_ = value;
			}
			public string GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(string value){
				this.card_code_ = value;
			}
			public int? GetTrans_id(){
				return this.trans_id_;
			}
			
			public void SetTrans_id(int? value){
				this.trans_id_ = value;
			}
			public int? GetSale_trans_id(){
				return this.sale_trans_id_;
			}
			
			public void SetSale_trans_id(int? value){
				this.sale_trans_id_ = value;
			}
			public string GetMerchant_code(){
				return this.merchant_code_;
			}
			
			public void SetMerchant_code(string value){
				this.merchant_code_ = value;
			}
			
		}
		
		
		
		
		public class getActivateCode_args {
			
			///<summary>
			/// 唯品卡卡号，最多支持100个
			///</summary>
			
			private List<string> card_code_;
			
			///<summary>
			/// 商家编码
			///</summary>
			
			private string merchant_code_;
			
			public List<string> GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(List<string> value){
				this.card_code_ = value;
			}
			public string GetMerchant_code(){
				return this.merchant_code_;
			}
			
			public void SetMerchant_code(string value){
				this.merchant_code_ = value;
			}
			
		}
		
		
		
		
		public class getCardNumberList_args {
			
			///<summary>
			/// 商家编码
			///</summary>
			
			private string merchant_code_;
			
			///<summary>
			/// 批次id
			///</summary>
			
			private int? group_id_;
			
			///<summary>
			/// 状态过滤（-1全部，0未售卖，1已售，2已激活，3作废）
			///</summary>
			
			private int? status_filter_;
			
			///<summary>
			/// 分页
			/// @sampleValue page 1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页行数，默认20条，最大1000条
			/// @sampleValue limit 20
			///</summary>
			
			private int? limit_;
			
			public string GetMerchant_code(){
				return this.merchant_code_;
			}
			
			public void SetMerchant_code(string value){
				this.merchant_code_ = value;
			}
			public int? GetGroup_id(){
				return this.group_id_;
			}
			
			public void SetGroup_id(int? value){
				this.group_id_ = value;
			}
			public int? GetStatus_filter(){
				return this.status_filter_;
			}
			
			public void SetStatus_filter(int? value){
				this.status_filter_ = value;
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
		
		
		
		
		public class getCardStatus_args {
			
			///<summary>
			/// 店铺名称
			///</summary>
			
			private string shop_name_;
			
			///<summary>
			/// 店铺地址
			///</summary>
			
			private string shop_area_;
			
			///<summary>
			/// 请求clientId
			///</summary>
			
			private int? client_id_;
			
			///<summary>
			/// 商家卡类型编号
			///</summary>
			
			private int? type_;
			
			///<summary>
			/// 唯品卡号，支持批量
			///</summary>
			
			private List<string> card_code_;
			
			///<summary>
			/// 商家编码，<font color='red'>自2017年4月1号起此参数将调整为必传参数</font>
			///</summary>
			
			private string merchant_code_;
			
			public string GetShop_name(){
				return this.shop_name_;
			}
			
			public void SetShop_name(string value){
				this.shop_name_ = value;
			}
			public string GetShop_area(){
				return this.shop_area_;
			}
			
			public void SetShop_area(string value){
				this.shop_area_ = value;
			}
			public int? GetClient_id(){
				return this.client_id_;
			}
			
			public void SetClient_id(int? value){
				this.client_id_ = value;
			}
			public int? GetType(){
				return this.type_;
			}
			
			public void SetType(int? value){
				this.type_ = value;
			}
			public List<string> GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(List<string> value){
				this.card_code_ = value;
			}
			public string GetMerchant_code(){
				return this.merchant_code_;
			}
			
			public void SetMerchant_code(string value){
				this.merchant_code_ = value;
			}
			
		}
		
		
		
		
		public class getGroupInfo_args {
			
			///<summary>
			/// 商家编码
			/// @sampleValue merchant_code VIPS
			///</summary>
			
			private string merchant_code_;
			
			///<summary>
			/// 批次id
			/// @sampleValue group_id 1211
			///</summary>
			
			private int? group_id_;
			
			public string GetMerchant_code(){
				return this.merchant_code_;
			}
			
			public void SetMerchant_code(string value){
				this.merchant_code_ = value;
			}
			public int? GetGroup_id(){
				return this.group_id_;
			}
			
			public void SetGroup_id(int? value){
				this.group_id_ = value;
			}
			
		}
		
		
		
		
		public class getUserVipCardInfo_args {
			
			///<summary>
			/// 请求clientId
			///</summary>
			
			private int? client_id_;
			
			///<summary>
			/// 商家卡类型编号
			///</summary>
			
			private int? type_;
			
			///<summary>
			/// 唯品卡卡号，最多支持100个
			///</summary>
			
			private List<string> card_code_;
			
			///<summary>
			/// 商家编码，<font color='red'>自2017年4月1号起此参数将调整为必传参数</font>
			///</summary>
			
			private string merchant_code_;
			
			public int? GetClient_id(){
				return this.client_id_;
			}
			
			public void SetClient_id(int? value){
				this.client_id_ = value;
			}
			public int? GetType(){
				return this.type_;
			}
			
			public void SetType(int? value){
				this.type_ = value;
			}
			public List<string> GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(List<string> value){
				this.card_code_ = value;
			}
			public string GetMerchant_code(){
				return this.merchant_code_;
			}
			
			public void SetMerchant_code(string value){
				this.merchant_code_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class sellCard_args {
			
			///<summary>
			/// 店铺名称
			///</summary>
			
			private string shop_name_;
			
			///<summary>
			/// 店铺地址
			///</summary>
			
			private string shop_area_;
			
			///<summary>
			/// 请求client_id
			///</summary>
			
			private int? client_id_;
			
			///<summary>
			/// 商家卡类型编号
			///</summary>
			
			private int? type_;
			
			///<summary>
			/// 唯品卡卡号
			///</summary>
			
			private string card_code_;
			
			///<summary>
			/// 自增流水号，如果小于等于系统记录的最后处理流水号忽略处理
			///</summary>
			
			private int? trans_id_;
			
			///<summary>
			/// 商家编码
			///</summary>
			
			private string merchant_code_;
			
			public string GetShop_name(){
				return this.shop_name_;
			}
			
			public void SetShop_name(string value){
				this.shop_name_ = value;
			}
			public string GetShop_area(){
				return this.shop_area_;
			}
			
			public void SetShop_area(string value){
				this.shop_area_ = value;
			}
			public int? GetClient_id(){
				return this.client_id_;
			}
			
			public void SetClient_id(int? value){
				this.client_id_ = value;
			}
			public int? GetType(){
				return this.type_;
			}
			
			public void SetType(int? value){
				this.type_ = value;
			}
			public string GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(string value){
				this.card_code_ = value;
			}
			public int? GetTrans_id(){
				return this.trans_id_;
			}
			
			public void SetTrans_id(int? value){
				this.trans_id_ = value;
			}
			public string GetMerchant_code(){
				return this.merchant_code_;
			}
			
			public void SetMerchant_code(string value){
				this.merchant_code_ = value;
			}
			
		}
		
		
		
		
		public class sellVipCard_args {
			
			///<summary>
			/// 请求client_id
			///</summary>
			
			private int? client_id_;
			
			///<summary>
			/// 商家卡类型编号
			///</summary>
			
			private int? type_;
			
			///<summary>
			/// 唯品卡卡号
			///</summary>
			
			private string card_code_;
			
			///<summary>
			/// 自增流水号，如果小于等于系统记录的最后处理流水号忽略处理
			///</summary>
			
			private int? trans_id_;
			
			///<summary>
			/// 商家编码
			///</summary>
			
			private string merchant_code_;
			
			///<summary>
			/// 是否返回卡密（0：不返回，1返回）
			///</summary>
			
			private int? is_return_act_;
			
			public int? GetClient_id(){
				return this.client_id_;
			}
			
			public void SetClient_id(int? value){
				this.client_id_ = value;
			}
			public int? GetType(){
				return this.type_;
			}
			
			public void SetType(int? value){
				this.type_ = value;
			}
			public string GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(string value){
				this.card_code_ = value;
			}
			public int? GetTrans_id(){
				return this.trans_id_;
			}
			
			public void SetTrans_id(int? value){
				this.trans_id_ = value;
			}
			public string GetMerchant_code(){
				return this.merchant_code_;
			}
			
			public void SetMerchant_code(string value){
				this.merchant_code_ = value;
			}
			public int? GetIs_return_act(){
				return this.is_return_act_;
			}
			
			public void SetIs_return_act(int? value){
				this.is_return_act_ = value;
			}
			
		}
		
		
		
		
		public class applyGroup_result {
			
			///<summary>
			/// 返回批次id
			///</summary>
			
			private vipapis.vipcard.ApplyGroupResponse success_;
			
			public vipapis.vipcard.ApplyGroupResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vipcard.ApplyGroupResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class cancelCard_result {
			
			///<summary>
			/// 是否取消售出成功，true为成功，false为失败
			///</summary>
			
			private vipapis.vipcard.CancelCardResponse success_;
			
			public vipapis.vipcard.CancelCardResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vipcard.CancelCardResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class cancelSoldCard_result {
			
			///<summary>
			/// 是否取消售出成功，true为成功，false为失败
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getActivateCode_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.vipcard.ActivateCodeInfo> success_;
			
			public List<vipapis.vipcard.ActivateCodeInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.vipcard.ActivateCodeInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCardNumberList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.vipcard.CardNumberList success_;
			
			public vipapis.vipcard.CardNumberList GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vipcard.CardNumberList value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCardStatus_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.vipcard.VipCard> success_;
			
			public List<vipapis.vipcard.VipCard> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.vipcard.VipCard> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getGroupInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.vipcard.GroupInfo success_;
			
			public vipapis.vipcard.GroupInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vipcard.GroupInfo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getUserVipCardInfo_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.vipcard.VipCardInfo> success_;
			
			public List<vipapis.vipcard.VipCardInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.vipcard.VipCardInfo> value){
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
		
		
		
		
		public class sellCard_result {
			
			///<summary>
			/// 是否售出成功，true为成功，false为失败
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class sellVipCard_result {
			
			///<summary>
			/// SellCardResponse
			///</summary>
			
			private vipapis.vipcard.SellCardResponse success_;
			
			public vipapis.vipcard.SellCardResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vipcard.SellCardResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class applyGroup_argsHelper : TBeanSerializer<applyGroup_args>
		{
			
			public static applyGroup_argsHelper OBJ = new applyGroup_argsHelper();
			
			public static applyGroup_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(applyGroup_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vipcard.ApplyGroupRequest value;
					
					value = new vipapis.vipcard.ApplyGroupRequest();
					vipapis.vipcard.ApplyGroupRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetApplyGroupRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(applyGroup_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetApplyGroupRequest() != null) {
					
					oprot.WriteFieldBegin("applyGroupRequest");
					
					vipapis.vipcard.ApplyGroupRequestHelper.getInstance().Write(structs.GetApplyGroupRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("applyGroupRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(applyGroup_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelCard_argsHelper : TBeanSerializer<cancelCard_args>
		{
			
			public static cancelCard_argsHelper OBJ = new cancelCard_argsHelper();
			
			public static cancelCard_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelCard_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetClient_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetType(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetCard_code(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetTrans_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMerchant_code(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelCard_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetClient_id() != null) {
					
					oprot.WriteFieldBegin("client_id");
					oprot.WriteI32((int)structs.GetClient_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("client_id can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteI32((int)structs.GetType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetCard_code()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				if(structs.GetTrans_id() != null) {
					
					oprot.WriteFieldBegin("trans_id");
					oprot.WriteI32((int)structs.GetTrans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("trans_id can not be null!");
				}
				
				
				if(structs.GetMerchant_code() != null) {
					
					oprot.WriteFieldBegin("merchant_code");
					oprot.WriteString(structs.GetMerchant_code());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelCard_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelSoldCard_argsHelper : TBeanSerializer<cancelSoldCard_args>
		{
			
			public static cancelSoldCard_argsHelper OBJ = new cancelSoldCard_argsHelper();
			
			public static cancelSoldCard_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelSoldCard_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_area(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetClient_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetType(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCard_code(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetTrans_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSale_trans_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMerchant_code(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelSoldCard_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetShop_name() != null) {
					
					oprot.WriteFieldBegin("shop_name");
					oprot.WriteString(structs.GetShop_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("shop_name can not be null!");
				}
				
				
				if(structs.GetShop_area() != null) {
					
					oprot.WriteFieldBegin("shop_area");
					oprot.WriteString(structs.GetShop_area());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("shop_area can not be null!");
				}
				
				
				if(structs.GetClient_id() != null) {
					
					oprot.WriteFieldBegin("client_id");
					oprot.WriteI32((int)structs.GetClient_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("client_id can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteI32((int)structs.GetType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					oprot.WriteString(structs.GetCard_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				if(structs.GetTrans_id() != null) {
					
					oprot.WriteFieldBegin("trans_id");
					oprot.WriteI32((int)structs.GetTrans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("trans_id can not be null!");
				}
				
				
				if(structs.GetSale_trans_id() != null) {
					
					oprot.WriteFieldBegin("sale_trans_id");
					oprot.WriteI32((int)structs.GetSale_trans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sale_trans_id can not be null!");
				}
				
				
				if(structs.GetMerchant_code() != null) {
					
					oprot.WriteFieldBegin("merchant_code");
					oprot.WriteString(structs.GetMerchant_code());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelSoldCard_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getActivateCode_argsHelper : TBeanSerializer<getActivateCode_args>
		{
			
			public static getActivateCode_argsHelper OBJ = new getActivateCode_argsHelper();
			
			public static getActivateCode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getActivateCode_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetCard_code(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMerchant_code(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getActivateCode_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetCard_code()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				if(structs.GetMerchant_code() != null) {
					
					oprot.WriteFieldBegin("merchant_code");
					oprot.WriteString(structs.GetMerchant_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("merchant_code can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getActivateCode_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCardNumberList_argsHelper : TBeanSerializer<getCardNumberList_args>
		{
			
			public static getCardNumberList_argsHelper OBJ = new getCardNumberList_argsHelper();
			
			public static getCardNumberList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCardNumberList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMerchant_code(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetGroup_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetStatus_filter(value);
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
			
			
			public void Write(getCardNumberList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetMerchant_code() != null) {
					
					oprot.WriteFieldBegin("merchant_code");
					oprot.WriteString(structs.GetMerchant_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("merchant_code can not be null!");
				}
				
				
				if(structs.GetGroup_id() != null) {
					
					oprot.WriteFieldBegin("group_id");
					oprot.WriteI32((int)structs.GetGroup_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("group_id can not be null!");
				}
				
				
				if(structs.GetStatus_filter() != null) {
					
					oprot.WriteFieldBegin("status_filter");
					oprot.WriteI32((int)structs.GetStatus_filter()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("status_filter can not be null!");
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
			
			
			public void Validate(getCardNumberList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCardStatus_argsHelper : TBeanSerializer<getCardStatus_args>
		{
			
			public static getCardStatus_argsHelper OBJ = new getCardStatus_argsHelper();
			
			public static getCardStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCardStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_area(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetClient_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetType(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetCard_code(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMerchant_code(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCardStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetShop_name() != null) {
					
					oprot.WriteFieldBegin("shop_name");
					oprot.WriteString(structs.GetShop_name());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetShop_area() != null) {
					
					oprot.WriteFieldBegin("shop_area");
					oprot.WriteString(structs.GetShop_area());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetClient_id() != null) {
					
					oprot.WriteFieldBegin("client_id");
					oprot.WriteI32((int)structs.GetClient_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("client_id can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteI32((int)structs.GetType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetCard_code()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				if(structs.GetMerchant_code() != null) {
					
					oprot.WriteFieldBegin("merchant_code");
					oprot.WriteString(structs.GetMerchant_code());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCardStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getGroupInfo_argsHelper : TBeanSerializer<getGroupInfo_args>
		{
			
			public static getGroupInfo_argsHelper OBJ = new getGroupInfo_argsHelper();
			
			public static getGroupInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGroupInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMerchant_code(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetGroup_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGroupInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetMerchant_code() != null) {
					
					oprot.WriteFieldBegin("merchant_code");
					oprot.WriteString(structs.GetMerchant_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("merchant_code can not be null!");
				}
				
				
				if(structs.GetGroup_id() != null) {
					
					oprot.WriteFieldBegin("group_id");
					oprot.WriteI32((int)structs.GetGroup_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("group_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGroupInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUserVipCardInfo_argsHelper : TBeanSerializer<getUserVipCardInfo_args>
		{
			
			public static getUserVipCardInfo_argsHelper OBJ = new getUserVipCardInfo_argsHelper();
			
			public static getUserVipCardInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUserVipCardInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetClient_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetType(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetCard_code(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMerchant_code(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUserVipCardInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetClient_id() != null) {
					
					oprot.WriteFieldBegin("client_id");
					oprot.WriteI32((int)structs.GetClient_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("client_id can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteI32((int)structs.GetType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetCard_code()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				if(structs.GetMerchant_code() != null) {
					
					oprot.WriteFieldBegin("merchant_code");
					oprot.WriteString(structs.GetMerchant_code());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUserVipCardInfo_args bean){
				
				
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
		
		
		
		
		public class sellCard_argsHelper : TBeanSerializer<sellCard_args>
		{
			
			public static sellCard_argsHelper OBJ = new sellCard_argsHelper();
			
			public static sellCard_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sellCard_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_area(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetClient_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetType(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCard_code(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetTrans_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMerchant_code(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sellCard_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetShop_name() != null) {
					
					oprot.WriteFieldBegin("shop_name");
					oprot.WriteString(structs.GetShop_name());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetShop_area() != null) {
					
					oprot.WriteFieldBegin("shop_area");
					oprot.WriteString(structs.GetShop_area());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetClient_id() != null) {
					
					oprot.WriteFieldBegin("client_id");
					oprot.WriteI32((int)structs.GetClient_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("client_id can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteI32((int)structs.GetType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					oprot.WriteString(structs.GetCard_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				if(structs.GetTrans_id() != null) {
					
					oprot.WriteFieldBegin("trans_id");
					oprot.WriteI32((int)structs.GetTrans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("trans_id can not be null!");
				}
				
				
				if(structs.GetMerchant_code() != null) {
					
					oprot.WriteFieldBegin("merchant_code");
					oprot.WriteString(structs.GetMerchant_code());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(sellCard_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class sellVipCard_argsHelper : TBeanSerializer<sellVipCard_args>
		{
			
			public static sellVipCard_argsHelper OBJ = new sellVipCard_argsHelper();
			
			public static sellVipCard_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sellVipCard_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetClient_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetType(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCard_code(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetTrans_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetMerchant_code(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetIs_return_act(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sellVipCard_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetClient_id() != null) {
					
					oprot.WriteFieldBegin("client_id");
					oprot.WriteI32((int)structs.GetClient_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("client_id can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteI32((int)structs.GetType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					oprot.WriteString(structs.GetCard_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				if(structs.GetTrans_id() != null) {
					
					oprot.WriteFieldBegin("trans_id");
					oprot.WriteI32((int)structs.GetTrans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("trans_id can not be null!");
				}
				
				
				if(structs.GetMerchant_code() != null) {
					
					oprot.WriteFieldBegin("merchant_code");
					oprot.WriteString(structs.GetMerchant_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("merchant_code can not be null!");
				}
				
				
				if(structs.GetIs_return_act() != null) {
					
					oprot.WriteFieldBegin("is_return_act");
					oprot.WriteI32((int)structs.GetIs_return_act()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(sellVipCard_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class applyGroup_resultHelper : TBeanSerializer<applyGroup_result>
		{
			
			public static applyGroup_resultHelper OBJ = new applyGroup_resultHelper();
			
			public static applyGroup_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(applyGroup_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vipcard.ApplyGroupResponse value;
					
					value = new vipapis.vipcard.ApplyGroupResponse();
					vipapis.vipcard.ApplyGroupResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(applyGroup_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vipcard.ApplyGroupResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(applyGroup_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelCard_resultHelper : TBeanSerializer<cancelCard_result>
		{
			
			public static cancelCard_resultHelper OBJ = new cancelCard_resultHelper();
			
			public static cancelCard_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelCard_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vipcard.CancelCardResponse value;
					
					value = new vipapis.vipcard.CancelCardResponse();
					vipapis.vipcard.CancelCardResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelCard_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vipcard.CancelCardResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelCard_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelSoldCard_resultHelper : TBeanSerializer<cancelSoldCard_result>
		{
			
			public static cancelSoldCard_resultHelper OBJ = new cancelSoldCard_resultHelper();
			
			public static cancelSoldCard_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelSoldCard_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool? value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelSoldCard_result structs, Protocol oprot){
				
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
			
			
			public void Validate(cancelSoldCard_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getActivateCode_resultHelper : TBeanSerializer<getActivateCode_result>
		{
			
			public static getActivateCode_resultHelper OBJ = new getActivateCode_resultHelper();
			
			public static getActivateCode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getActivateCode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.vipcard.ActivateCodeInfo> value;
					
					value = new List<vipapis.vipcard.ActivateCodeInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.vipcard.ActivateCodeInfo elem0;
							
							elem0 = new vipapis.vipcard.ActivateCodeInfo();
							vipapis.vipcard.ActivateCodeInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getActivateCode_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.vipcard.ActivateCodeInfo _item0 in structs.GetSuccess()){
						
						
						vipapis.vipcard.ActivateCodeInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getActivateCode_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCardNumberList_resultHelper : TBeanSerializer<getCardNumberList_result>
		{
			
			public static getCardNumberList_resultHelper OBJ = new getCardNumberList_resultHelper();
			
			public static getCardNumberList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCardNumberList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vipcard.CardNumberList value;
					
					value = new vipapis.vipcard.CardNumberList();
					vipapis.vipcard.CardNumberListHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCardNumberList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vipcard.CardNumberListHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCardNumberList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCardStatus_resultHelper : TBeanSerializer<getCardStatus_result>
		{
			
			public static getCardStatus_resultHelper OBJ = new getCardStatus_resultHelper();
			
			public static getCardStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCardStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.vipcard.VipCard> value;
					
					value = new List<vipapis.vipcard.VipCard>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.vipcard.VipCard elem0;
							
							elem0 = new vipapis.vipcard.VipCard();
							vipapis.vipcard.VipCardHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getCardStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.vipcard.VipCard _item0 in structs.GetSuccess()){
						
						
						vipapis.vipcard.VipCardHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCardStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getGroupInfo_resultHelper : TBeanSerializer<getGroupInfo_result>
		{
			
			public static getGroupInfo_resultHelper OBJ = new getGroupInfo_resultHelper();
			
			public static getGroupInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGroupInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vipcard.GroupInfo value;
					
					value = new vipapis.vipcard.GroupInfo();
					vipapis.vipcard.GroupInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGroupInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vipcard.GroupInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGroupInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUserVipCardInfo_resultHelper : TBeanSerializer<getUserVipCardInfo_result>
		{
			
			public static getUserVipCardInfo_resultHelper OBJ = new getUserVipCardInfo_resultHelper();
			
			public static getUserVipCardInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUserVipCardInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.vipcard.VipCardInfo> value;
					
					value = new List<vipapis.vipcard.VipCardInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.vipcard.VipCardInfo elem0;
							
							elem0 = new vipapis.vipcard.VipCardInfo();
							vipapis.vipcard.VipCardInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getUserVipCardInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.vipcard.VipCardInfo _item0 in structs.GetSuccess()){
						
						
						vipapis.vipcard.VipCardInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUserVipCardInfo_result bean){
				
				
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
		
		
		
		
		public class sellCard_resultHelper : TBeanSerializer<sellCard_result>
		{
			
			public static sellCard_resultHelper OBJ = new sellCard_resultHelper();
			
			public static sellCard_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sellCard_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool? value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sellCard_result structs, Protocol oprot){
				
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
			
			
			public void Validate(sellCard_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class sellVipCard_resultHelper : TBeanSerializer<sellVipCard_result>
		{
			
			public static sellVipCard_resultHelper OBJ = new sellVipCard_resultHelper();
			
			public static sellVipCard_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sellVipCard_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vipcard.SellCardResponse value;
					
					value = new vipapis.vipcard.SellCardResponse();
					vipapis.vipcard.SellCardResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sellVipCard_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vipcard.SellCardResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(sellVipCard_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VipCardServiceClient : OspRestStub , VipCardService  {
			
			
			public VipCardServiceClient():base("vipapis.vipcard.VipCardService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.vipcard.ApplyGroupResponse applyGroup(vipapis.vipcard.ApplyGroupRequest applyGroupRequest_) {
				
				send_applyGroup(applyGroupRequest_);
				return recv_applyGroup(); 
				
			}
			
			
			private void send_applyGroup(vipapis.vipcard.ApplyGroupRequest applyGroupRequest_){
				
				InitInvocation("applyGroup");
				
				applyGroup_args args = new applyGroup_args();
				args.SetApplyGroupRequest(applyGroupRequest_);
				
				SendBase(args, applyGroup_argsHelper.getInstance());
			}
			
			
			private vipapis.vipcard.ApplyGroupResponse recv_applyGroup(){
				
				applyGroup_result result = new applyGroup_result();
				ReceiveBase(result, applyGroup_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.vipcard.CancelCardResponse cancelCard(int client_id_,int type_,List<string> card_code_,int trans_id_,string merchant_code_) {
				
				send_cancelCard(client_id_,type_,card_code_,trans_id_,merchant_code_);
				return recv_cancelCard(); 
				
			}
			
			
			private void send_cancelCard(int client_id_,int type_,List<string> card_code_,int trans_id_,string merchant_code_){
				
				InitInvocation("cancelCard");
				
				cancelCard_args args = new cancelCard_args();
				args.SetClient_id(client_id_);
				args.SetType(type_);
				args.SetCard_code(card_code_);
				args.SetTrans_id(trans_id_);
				args.SetMerchant_code(merchant_code_);
				
				SendBase(args, cancelCard_argsHelper.getInstance());
			}
			
			
			private vipapis.vipcard.CancelCardResponse recv_cancelCard(){
				
				cancelCard_result result = new cancelCard_result();
				ReceiveBase(result, cancelCard_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public bool? cancelSoldCard(string shop_name_,string shop_area_,int client_id_,int type_,string card_code_,int trans_id_,int sale_trans_id_,string merchant_code_) {
				
				send_cancelSoldCard(shop_name_,shop_area_,client_id_,type_,card_code_,trans_id_,sale_trans_id_,merchant_code_);
				return recv_cancelSoldCard(); 
				
			}
			
			
			private void send_cancelSoldCard(string shop_name_,string shop_area_,int client_id_,int type_,string card_code_,int trans_id_,int sale_trans_id_,string merchant_code_){
				
				InitInvocation("cancelSoldCard");
				
				cancelSoldCard_args args = new cancelSoldCard_args();
				args.SetShop_name(shop_name_);
				args.SetShop_area(shop_area_);
				args.SetClient_id(client_id_);
				args.SetType(type_);
				args.SetCard_code(card_code_);
				args.SetTrans_id(trans_id_);
				args.SetSale_trans_id(sale_trans_id_);
				args.SetMerchant_code(merchant_code_);
				
				SendBase(args, cancelSoldCard_argsHelper.getInstance());
			}
			
			
			private bool? recv_cancelSoldCard(){
				
				cancelSoldCard_result result = new cancelSoldCard_result();
				ReceiveBase(result, cancelSoldCard_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.vipcard.ActivateCodeInfo> getActivateCode(List<string> card_code_,string merchant_code_) {
				
				send_getActivateCode(card_code_,merchant_code_);
				return recv_getActivateCode(); 
				
			}
			
			
			private void send_getActivateCode(List<string> card_code_,string merchant_code_){
				
				InitInvocation("getActivateCode");
				
				getActivateCode_args args = new getActivateCode_args();
				args.SetCard_code(card_code_);
				args.SetMerchant_code(merchant_code_);
				
				SendBase(args, getActivateCode_argsHelper.getInstance());
			}
			
			
			private List<vipapis.vipcard.ActivateCodeInfo> recv_getActivateCode(){
				
				getActivateCode_result result = new getActivateCode_result();
				ReceiveBase(result, getActivateCode_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.vipcard.CardNumberList getCardNumberList(string merchant_code_,int group_id_,int status_filter_,int? page_,int? limit_) {
				
				send_getCardNumberList(merchant_code_,group_id_,status_filter_,page_,limit_);
				return recv_getCardNumberList(); 
				
			}
			
			
			private void send_getCardNumberList(string merchant_code_,int group_id_,int status_filter_,int? page_,int? limit_){
				
				InitInvocation("getCardNumberList");
				
				getCardNumberList_args args = new getCardNumberList_args();
				args.SetMerchant_code(merchant_code_);
				args.SetGroup_id(group_id_);
				args.SetStatus_filter(status_filter_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getCardNumberList_argsHelper.getInstance());
			}
			
			
			private vipapis.vipcard.CardNumberList recv_getCardNumberList(){
				
				getCardNumberList_result result = new getCardNumberList_result();
				ReceiveBase(result, getCardNumberList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.vipcard.VipCard> getCardStatus(string shop_name_,string shop_area_,int client_id_,int type_,List<string> card_code_,string merchant_code_) {
				
				send_getCardStatus(shop_name_,shop_area_,client_id_,type_,card_code_,merchant_code_);
				return recv_getCardStatus(); 
				
			}
			
			
			private void send_getCardStatus(string shop_name_,string shop_area_,int client_id_,int type_,List<string> card_code_,string merchant_code_){
				
				InitInvocation("getCardStatus");
				
				getCardStatus_args args = new getCardStatus_args();
				args.SetShop_name(shop_name_);
				args.SetShop_area(shop_area_);
				args.SetClient_id(client_id_);
				args.SetType(type_);
				args.SetCard_code(card_code_);
				args.SetMerchant_code(merchant_code_);
				
				SendBase(args, getCardStatus_argsHelper.getInstance());
			}
			
			
			private List<vipapis.vipcard.VipCard> recv_getCardStatus(){
				
				getCardStatus_result result = new getCardStatus_result();
				ReceiveBase(result, getCardStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.vipcard.GroupInfo getGroupInfo(string merchant_code_,int group_id_) {
				
				send_getGroupInfo(merchant_code_,group_id_);
				return recv_getGroupInfo(); 
				
			}
			
			
			private void send_getGroupInfo(string merchant_code_,int group_id_){
				
				InitInvocation("getGroupInfo");
				
				getGroupInfo_args args = new getGroupInfo_args();
				args.SetMerchant_code(merchant_code_);
				args.SetGroup_id(group_id_);
				
				SendBase(args, getGroupInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.vipcard.GroupInfo recv_getGroupInfo(){
				
				getGroupInfo_result result = new getGroupInfo_result();
				ReceiveBase(result, getGroupInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.vipcard.VipCardInfo> getUserVipCardInfo(int client_id_,int type_,List<string> card_code_,string merchant_code_) {
				
				send_getUserVipCardInfo(client_id_,type_,card_code_,merchant_code_);
				return recv_getUserVipCardInfo(); 
				
			}
			
			
			private void send_getUserVipCardInfo(int client_id_,int type_,List<string> card_code_,string merchant_code_){
				
				InitInvocation("getUserVipCardInfo");
				
				getUserVipCardInfo_args args = new getUserVipCardInfo_args();
				args.SetClient_id(client_id_);
				args.SetType(type_);
				args.SetCard_code(card_code_);
				args.SetMerchant_code(merchant_code_);
				
				SendBase(args, getUserVipCardInfo_argsHelper.getInstance());
			}
			
			
			private List<vipapis.vipcard.VipCardInfo> recv_getUserVipCardInfo(){
				
				getUserVipCardInfo_result result = new getUserVipCardInfo_result();
				ReceiveBase(result, getUserVipCardInfo_resultHelper.getInstance());
				
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
			
			
			public bool? sellCard(string shop_name_,string shop_area_,int client_id_,int type_,string card_code_,int trans_id_,string merchant_code_) {
				
				send_sellCard(shop_name_,shop_area_,client_id_,type_,card_code_,trans_id_,merchant_code_);
				return recv_sellCard(); 
				
			}
			
			
			private void send_sellCard(string shop_name_,string shop_area_,int client_id_,int type_,string card_code_,int trans_id_,string merchant_code_){
				
				InitInvocation("sellCard");
				
				sellCard_args args = new sellCard_args();
				args.SetShop_name(shop_name_);
				args.SetShop_area(shop_area_);
				args.SetClient_id(client_id_);
				args.SetType(type_);
				args.SetCard_code(card_code_);
				args.SetTrans_id(trans_id_);
				args.SetMerchant_code(merchant_code_);
				
				SendBase(args, sellCard_argsHelper.getInstance());
			}
			
			
			private bool? recv_sellCard(){
				
				sellCard_result result = new sellCard_result();
				ReceiveBase(result, sellCard_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.vipcard.SellCardResponse sellVipCard(int client_id_,int type_,string card_code_,int trans_id_,string merchant_code_,int? is_return_act_) {
				
				send_sellVipCard(client_id_,type_,card_code_,trans_id_,merchant_code_,is_return_act_);
				return recv_sellVipCard(); 
				
			}
			
			
			private void send_sellVipCard(int client_id_,int type_,string card_code_,int trans_id_,string merchant_code_,int? is_return_act_){
				
				InitInvocation("sellVipCard");
				
				sellVipCard_args args = new sellVipCard_args();
				args.SetClient_id(client_id_);
				args.SetType(type_);
				args.SetCard_code(card_code_);
				args.SetTrans_id(trans_id_);
				args.SetMerchant_code(merchant_code_);
				args.SetIs_return_act(is_return_act_);
				
				SendBase(args, sellVipCard_argsHelper.getInstance());
			}
			
			
			private vipapis.vipcard.SellCardResponse recv_sellVipCard(){
				
				sellVipCard_result result = new sellVipCard_result();
				ReceiveBase(result, sellVipCard_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}