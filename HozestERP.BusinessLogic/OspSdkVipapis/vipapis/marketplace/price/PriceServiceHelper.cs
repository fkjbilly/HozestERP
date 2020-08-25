using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.marketplace.price{
	
	
	public class PriceServiceHelper {
		
		
		
		public class getSkuPrice_args {
			
			///<summary>
			/// 商品sku id
			/// @sampleValue sku_id sku_34532423424
			///</summary>
			
			private string sku_id_;
			
			public string GetSku_id(){
				return this.sku_id_;
			}
			
			public void SetSku_id(string value){
				this.sku_id_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateSkuPrice_args {
			
			///<summary>
			/// 商品sku id
			/// @sampleValue sku_id sku_34532423424
			///</summary>
			
			private string sku_id_;
			
			///<summary>
			/// 商品市场价
			/// @sampleValue market_price 100.00
			///</summary>
			
			private double? market_price_;
			
			///<summary>
			/// 商品销售价
			/// @sampleValue sale_price 90.00
			///</summary>
			
			private double? sale_price_;
			
			public string GetSku_id(){
				return this.sku_id_;
			}
			
			public void SetSku_id(string value){
				this.sku_id_ = value;
			}
			public double? GetMarket_price(){
				return this.market_price_;
			}
			
			public void SetMarket_price(double? value){
				this.market_price_ = value;
			}
			public double? GetSale_price(){
				return this.sale_price_;
			}
			
			public void SetSale_price(double? value){
				this.sale_price_ = value;
			}
			
		}
		
		
		
		
		public class getSkuPrice_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.price.GetSkuPriceResponse success_;
			
			public vipapis.marketplace.price.GetSkuPriceResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.price.GetSkuPriceResponse value){
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
		
		
		
		
		public class updateSkuPrice_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.price.UpdateSkuPriceResponse success_;
			
			public vipapis.marketplace.price.UpdateSkuPriceResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.price.UpdateSkuPriceResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getSkuPrice_argsHelper : TBeanSerializer<getSkuPrice_args>
		{
			
			public static getSkuPrice_argsHelper OBJ = new getSkuPrice_argsHelper();
			
			public static getSkuPrice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuPrice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSku_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuPrice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSku_id() != null) {
					
					oprot.WriteFieldBegin("sku_id");
					oprot.WriteString(structs.GetSku_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sku_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuPrice_args bean){
				
				
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
		
		
		
		
		public class updateSkuPrice_argsHelper : TBeanSerializer<updateSkuPrice_args>
		{
			
			public static updateSkuPrice_argsHelper OBJ = new updateSkuPrice_argsHelper();
			
			public static updateSkuPrice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSkuPrice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSku_id(value);
				}
				
				
				
				
				
				if(true){
					
					double value;
					value = iprot.ReadDouble();
					
					structs.SetMarket_price(value);
				}
				
				
				
				
				
				if(true){
					
					double value;
					value = iprot.ReadDouble();
					
					structs.SetSale_price(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSkuPrice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSku_id() != null) {
					
					oprot.WriteFieldBegin("sku_id");
					oprot.WriteString(structs.GetSku_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sku_id can not be null!");
				}
				
				
				if(structs.GetMarket_price() != null) {
					
					oprot.WriteFieldBegin("market_price");
					oprot.WriteDouble((double)structs.GetMarket_price());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("market_price can not be null!");
				}
				
				
				if(structs.GetSale_price() != null) {
					
					oprot.WriteFieldBegin("sale_price");
					oprot.WriteDouble((double)structs.GetSale_price());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sale_price can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSkuPrice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuPrice_resultHelper : TBeanSerializer<getSkuPrice_result>
		{
			
			public static getSkuPrice_resultHelper OBJ = new getSkuPrice_resultHelper();
			
			public static getSkuPrice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuPrice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.price.GetSkuPriceResponse value;
					
					value = new vipapis.marketplace.price.GetSkuPriceResponse();
					vipapis.marketplace.price.GetSkuPriceResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuPrice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.price.GetSkuPriceResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuPrice_result bean){
				
				
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
		
		
		
		
		public class updateSkuPrice_resultHelper : TBeanSerializer<updateSkuPrice_result>
		{
			
			public static updateSkuPrice_resultHelper OBJ = new updateSkuPrice_resultHelper();
			
			public static updateSkuPrice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSkuPrice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.price.UpdateSkuPriceResponse value;
					
					value = new vipapis.marketplace.price.UpdateSkuPriceResponse();
					vipapis.marketplace.price.UpdateSkuPriceResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSkuPrice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.price.UpdateSkuPriceResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSkuPrice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class PriceServiceClient : OspRestStub , PriceService  {
			
			
			public PriceServiceClient():base("vipapis.marketplace.price.PriceService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.marketplace.price.GetSkuPriceResponse getSkuPrice(string sku_id_) {
				
				send_getSkuPrice(sku_id_);
				return recv_getSkuPrice(); 
				
			}
			
			
			private void send_getSkuPrice(string sku_id_){
				
				InitInvocation("getSkuPrice");
				
				getSkuPrice_args args = new getSkuPrice_args();
				args.SetSku_id(sku_id_);
				
				SendBase(args, getSkuPrice_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.price.GetSkuPriceResponse recv_getSkuPrice(){
				
				getSkuPrice_result result = new getSkuPrice_result();
				ReceiveBase(result, getSkuPrice_resultHelper.getInstance());
				
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
			
			
			public vipapis.marketplace.price.UpdateSkuPriceResponse updateSkuPrice(string sku_id_,double market_price_,double sale_price_) {
				
				send_updateSkuPrice(sku_id_,market_price_,sale_price_);
				return recv_updateSkuPrice(); 
				
			}
			
			
			private void send_updateSkuPrice(string sku_id_,double market_price_,double sale_price_){
				
				InitInvocation("updateSkuPrice");
				
				updateSkuPrice_args args = new updateSkuPrice_args();
				args.SetSku_id(sku_id_);
				args.SetMarket_price(market_price_);
				args.SetSale_price(sale_price_);
				
				SendBase(args, updateSkuPrice_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.price.UpdateSkuPriceResponse recv_updateSkuPrice(){
				
				updateSkuPrice_result result = new updateSkuPrice_result();
				ReceiveBase(result, updateSkuPrice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}