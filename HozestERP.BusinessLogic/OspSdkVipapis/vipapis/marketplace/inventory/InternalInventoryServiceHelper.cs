using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.marketplace.inventory{
	
	
	public class InternalInventoryServiceHelper {
		
		
		
		public class batchTotalUpdateSkuInventory_args {
			
			///<summary>
			/// 门店id
			///</summary>
			
			private string storeId_;
			
			///<summary>
			/// sku库存列表
			///</summary>
			
			private List<vipapis.marketplace.inventory.ProductSkuStock> skuStocks_;
			
			public string GetStoreId(){
				return this.storeId_;
			}
			
			public void SetStoreId(string value){
				this.storeId_ = value;
			}
			public List<vipapis.marketplace.inventory.ProductSkuStock> GetSkuStocks(){
				return this.skuStocks_;
			}
			
			public void SetSkuStocks(List<vipapis.marketplace.inventory.ProductSkuStock> value){
				this.skuStocks_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class totalUpdateSkuInventory_args {
			
			///<summary>
			/// 全量库存更新请求
			///</summary>
			
			private vipapis.marketplace.inventory.StoreSkuStock stock_;
			
			public vipapis.marketplace.inventory.StoreSkuStock GetStock(){
				return this.stock_;
			}
			
			public void SetStock(vipapis.marketplace.inventory.StoreSkuStock value){
				this.stock_ = value;
			}
			
		}
		
		
		
		
		public class batchTotalUpdateSkuInventory_result {
			
			///<summary>
			///</summary>
			
			private Dictionary<string, vipapis.marketplace.inventory.UpdateSkuStockResult> success_;
			
			public Dictionary<string, vipapis.marketplace.inventory.UpdateSkuStockResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(Dictionary<string, vipapis.marketplace.inventory.UpdateSkuStockResult> value){
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
		
		
		
		
		public class totalUpdateSkuInventory_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.inventory.UpdateSkuStockResult success_;
			
			public vipapis.marketplace.inventory.UpdateSkuStockResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.inventory.UpdateSkuStockResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class batchTotalUpdateSkuInventory_argsHelper : TBeanSerializer<batchTotalUpdateSkuInventory_args>
		{
			
			public static batchTotalUpdateSkuInventory_argsHelper OBJ = new batchTotalUpdateSkuInventory_argsHelper();
			
			public static batchTotalUpdateSkuInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchTotalUpdateSkuInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStoreId(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.marketplace.inventory.ProductSkuStock> value;
					
					value = new List<vipapis.marketplace.inventory.ProductSkuStock>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.marketplace.inventory.ProductSkuStock elem1;
							
							elem1 = new vipapis.marketplace.inventory.ProductSkuStock();
							vipapis.marketplace.inventory.ProductSkuStockHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSkuStocks(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchTotalUpdateSkuInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetStoreId() != null) {
					
					oprot.WriteFieldBegin("storeId");
					oprot.WriteString(structs.GetStoreId());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSkuStocks() != null) {
					
					oprot.WriteFieldBegin("skuStocks");
					
					oprot.WriteListBegin();
					foreach(vipapis.marketplace.inventory.ProductSkuStock _item0 in structs.GetSkuStocks()){
						
						
						vipapis.marketplace.inventory.ProductSkuStockHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("skuStocks can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchTotalUpdateSkuInventory_args bean){
				
				
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
		
		
		
		
		public class totalUpdateSkuInventory_argsHelper : TBeanSerializer<totalUpdateSkuInventory_args>
		{
			
			public static totalUpdateSkuInventory_argsHelper OBJ = new totalUpdateSkuInventory_argsHelper();
			
			public static totalUpdateSkuInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(totalUpdateSkuInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.inventory.StoreSkuStock value;
					
					value = new vipapis.marketplace.inventory.StoreSkuStock();
					vipapis.marketplace.inventory.StoreSkuStockHelper.getInstance().Read(value, iprot);
					
					structs.SetStock(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(totalUpdateSkuInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetStock() != null) {
					
					oprot.WriteFieldBegin("stock");
					
					vipapis.marketplace.inventory.StoreSkuStockHelper.getInstance().Write(structs.GetStock(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("stock can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(totalUpdateSkuInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchTotalUpdateSkuInventory_resultHelper : TBeanSerializer<batchTotalUpdateSkuInventory_result>
		{
			
			public static batchTotalUpdateSkuInventory_resultHelper OBJ = new batchTotalUpdateSkuInventory_resultHelper();
			
			public static batchTotalUpdateSkuInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchTotalUpdateSkuInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					Dictionary<string, vipapis.marketplace.inventory.UpdateSkuStockResult> value;
					
					value = new Dictionary<string, vipapis.marketplace.inventory.UpdateSkuStockResult>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							string _key0;
							vipapis.marketplace.inventory.UpdateSkuStockResult _val0;
							_key0 = iprot.ReadString();
							
							
							_val0 = new vipapis.marketplace.inventory.UpdateSkuStockResult();
							vipapis.marketplace.inventory.UpdateSkuStockResultHelper.getInstance().Read(_val0, iprot);
							
							value.Add(_key0, _val0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchTotalUpdateSkuInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, vipapis.marketplace.inventory.UpdateSkuStockResult > _ir0 in structs.GetSuccess()){
						
						string _key0 = _ir0.Key;
						vipapis.marketplace.inventory.UpdateSkuStockResult _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						
						vipapis.marketplace.inventory.UpdateSkuStockResultHelper.getInstance().Write(_value0, oprot);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchTotalUpdateSkuInventory_result bean){
				
				
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
		
		
		
		
		public class totalUpdateSkuInventory_resultHelper : TBeanSerializer<totalUpdateSkuInventory_result>
		{
			
			public static totalUpdateSkuInventory_resultHelper OBJ = new totalUpdateSkuInventory_resultHelper();
			
			public static totalUpdateSkuInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(totalUpdateSkuInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.inventory.UpdateSkuStockResult value;
					
					value = new vipapis.marketplace.inventory.UpdateSkuStockResult();
					vipapis.marketplace.inventory.UpdateSkuStockResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(totalUpdateSkuInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.inventory.UpdateSkuStockResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(totalUpdateSkuInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class InternalInventoryServiceClient : OspRestStub , InternalInventoryService  {
			
			
			public InternalInventoryServiceClient():base("vipapis.marketplace.inventory.InternalInventoryService","1.0.0") {
				
				
			}
			
			
			
			public Dictionary<string, vipapis.marketplace.inventory.UpdateSkuStockResult> batchTotalUpdateSkuInventory(string storeId_,List<vipapis.marketplace.inventory.ProductSkuStock> skuStocks_) {
				
				send_batchTotalUpdateSkuInventory(storeId_,skuStocks_);
				return recv_batchTotalUpdateSkuInventory(); 
				
			}
			
			
			private void send_batchTotalUpdateSkuInventory(string storeId_,List<vipapis.marketplace.inventory.ProductSkuStock> skuStocks_){
				
				InitInvocation("batchTotalUpdateSkuInventory");
				
				batchTotalUpdateSkuInventory_args args = new batchTotalUpdateSkuInventory_args();
				args.SetStoreId(storeId_);
				args.SetSkuStocks(skuStocks_);
				
				SendBase(args, batchTotalUpdateSkuInventory_argsHelper.getInstance());
			}
			
			
			private Dictionary<string, vipapis.marketplace.inventory.UpdateSkuStockResult> recv_batchTotalUpdateSkuInventory(){
				
				batchTotalUpdateSkuInventory_result result = new batchTotalUpdateSkuInventory_result();
				ReceiveBase(result, batchTotalUpdateSkuInventory_resultHelper.getInstance());
				
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
			
			
			public vipapis.marketplace.inventory.UpdateSkuStockResult totalUpdateSkuInventory(vipapis.marketplace.inventory.StoreSkuStock stock_) {
				
				send_totalUpdateSkuInventory(stock_);
				return recv_totalUpdateSkuInventory(); 
				
			}
			
			
			private void send_totalUpdateSkuInventory(vipapis.marketplace.inventory.StoreSkuStock stock_){
				
				InitInvocation("totalUpdateSkuInventory");
				
				totalUpdateSkuInventory_args args = new totalUpdateSkuInventory_args();
				args.SetStock(stock_);
				
				SendBase(args, totalUpdateSkuInventory_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.inventory.UpdateSkuStockResult recv_totalUpdateSkuInventory(){
				
				totalUpdateSkuInventory_result result = new totalUpdateSkuInventory_result();
				ReceiveBase(result, totalUpdateSkuInventory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}