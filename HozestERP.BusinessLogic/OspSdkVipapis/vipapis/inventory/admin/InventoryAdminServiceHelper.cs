using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.inventory.admin{
	
	
	public class InventoryAdminServiceHelper {
		
		
		
		public class delInvUpdateRetryRequest_args {
			
			///<summary>
			/// 常态合作编码
			///</summary>
			
			private int? cooperationNo_;
			
			///<summary>
			/// 仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 商品条码
			///</summary>
			
			private string barcode_;
			
			public int? GetCooperationNo(){
				return this.cooperationNo_;
			}
			
			public void SetCooperationNo(int? value){
				this.cooperationNo_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetBarcode(){
				return this.barcode_;
			}
			
			public void SetBarcode(string value){
				this.barcode_ = value;
			}
			
		}
		
		
		
		
		public class getWhiInvUpdateHealth_args {
			
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class listInvUpdateRetryRequest_args {
			
			///<summary>
			/// 起始索引
			///</summary>
			
			private int? startIndex_;
			
			///<summary>
			/// 结束索引
			///</summary>
			
			private int? endIndex_;
			
			public int? GetStartIndex(){
				return this.startIndex_;
			}
			
			public void SetStartIndex(int? value){
				this.startIndex_ = value;
			}
			public int? GetEndIndex(){
				return this.endIndex_;
			}
			
			public void SetEndIndex(int? value){
				this.endIndex_ = value;
			}
			
		}
		
		
		
		
		public class saveInvUpdateRetryRequest_args {
			
			///<summary>
			/// 库存更新重试请求
			///</summary>
			
			private vipapis.inventory.admin.InvUpdateRetryRequest retryRequest_;
			
			public vipapis.inventory.admin.InvUpdateRetryRequest GetRetryRequest(){
				return this.retryRequest_;
			}
			
			public void SetRetryRequest(vipapis.inventory.admin.InvUpdateRetryRequest value){
				this.retryRequest_ = value;
			}
			
		}
		
		
		
		
		public class saveWhiInvUpdateHealth_args {
			
			///<summary>
			/// 健康状态（green/red）
			///</summary>
			
			private string health_;
			
			public string GetHealth(){
				return this.health_;
			}
			
			public void SetHealth(string value){
				this.health_ = value;
			}
			
		}
		
		
		
		
		public class updateStockRetry_args {
			
			///<summary>
			/// 库存更新重试请求
			///</summary>
			
			private vipapis.inventory.admin.InvUpdateRetryRequest retryRequest_;
			
			public vipapis.inventory.admin.InvUpdateRetryRequest GetRetryRequest(){
				return this.retryRequest_;
			}
			
			public void SetRetryRequest(vipapis.inventory.admin.InvUpdateRetryRequest value){
				this.retryRequest_ = value;
			}
			
		}
		
		
		
		
		public class delInvUpdateRetryRequest_result {
			
			
		}
		
		
		
		
		public class getWhiInvUpdateHealth_result {
			
			///<summary>
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
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
		
		
		
		
		public class listInvUpdateRetryRequest_result {
			
			///<summary>
			///</summary>
			
			private vipapis.inventory.admin.ListInvRequestRetryRequestResult success_;
			
			public vipapis.inventory.admin.ListInvRequestRetryRequestResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.inventory.admin.ListInvRequestRetryRequestResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class saveInvUpdateRetryRequest_result {
			
			
		}
		
		
		
		
		public class saveWhiInvUpdateHealth_result {
			
			
		}
		
		
		
		
		public class updateStockRetry_result {
			
			
		}
		
		
		
		
		
		public class delInvUpdateRetryRequest_argsHelper : TBeanSerializer<delInvUpdateRetryRequest_args>
		{
			
			public static delInvUpdateRetryRequest_argsHelper OBJ = new delInvUpdateRetryRequest_argsHelper();
			
			public static delInvUpdateRetryRequest_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(delInvUpdateRetryRequest_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCooperationNo(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBarcode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(delInvUpdateRetryRequest_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCooperationNo() != null) {
					
					oprot.WriteFieldBegin("cooperationNo");
					oprot.WriteI32((int)structs.GetCooperationNo()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("cooperationNo can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBarcode() != null) {
					
					oprot.WriteFieldBegin("barcode");
					oprot.WriteString(structs.GetBarcode());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(delInvUpdateRetryRequest_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getWhiInvUpdateHealth_argsHelper : TBeanSerializer<getWhiInvUpdateHealth_args>
		{
			
			public static getWhiInvUpdateHealth_argsHelper OBJ = new getWhiInvUpdateHealth_argsHelper();
			
			public static getWhiInvUpdateHealth_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getWhiInvUpdateHealth_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getWhiInvUpdateHealth_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getWhiInvUpdateHealth_args bean){
				
				
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
		
		
		
		
		public class listInvUpdateRetryRequest_argsHelper : TBeanSerializer<listInvUpdateRetryRequest_args>
		{
			
			public static listInvUpdateRetryRequest_argsHelper OBJ = new listInvUpdateRetryRequest_argsHelper();
			
			public static listInvUpdateRetryRequest_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listInvUpdateRetryRequest_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetStartIndex(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetEndIndex(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(listInvUpdateRetryRequest_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetStartIndex() != null) {
					
					oprot.WriteFieldBegin("startIndex");
					oprot.WriteI32((int)structs.GetStartIndex()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("startIndex can not be null!");
				}
				
				
				if(structs.GetEndIndex() != null) {
					
					oprot.WriteFieldBegin("endIndex");
					oprot.WriteI32((int)structs.GetEndIndex()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("endIndex can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(listInvUpdateRetryRequest_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class saveInvUpdateRetryRequest_argsHelper : TBeanSerializer<saveInvUpdateRetryRequest_args>
		{
			
			public static saveInvUpdateRetryRequest_argsHelper OBJ = new saveInvUpdateRetryRequest_argsHelper();
			
			public static saveInvUpdateRetryRequest_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(saveInvUpdateRetryRequest_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.admin.InvUpdateRetryRequest value;
					
					value = new vipapis.inventory.admin.InvUpdateRetryRequest();
					vipapis.inventory.admin.InvUpdateRetryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRetryRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(saveInvUpdateRetryRequest_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRetryRequest() != null) {
					
					oprot.WriteFieldBegin("retryRequest");
					
					vipapis.inventory.admin.InvUpdateRetryRequestHelper.getInstance().Write(structs.GetRetryRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(saveInvUpdateRetryRequest_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class saveWhiInvUpdateHealth_argsHelper : TBeanSerializer<saveWhiInvUpdateHealth_args>
		{
			
			public static saveWhiInvUpdateHealth_argsHelper OBJ = new saveWhiInvUpdateHealth_argsHelper();
			
			public static saveWhiInvUpdateHealth_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(saveWhiInvUpdateHealth_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetHealth(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(saveWhiInvUpdateHealth_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHealth() != null) {
					
					oprot.WriteFieldBegin("health");
					oprot.WriteString(structs.GetHealth());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("health can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(saveWhiInvUpdateHealth_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateStockRetry_argsHelper : TBeanSerializer<updateStockRetry_args>
		{
			
			public static updateStockRetry_argsHelper OBJ = new updateStockRetry_argsHelper();
			
			public static updateStockRetry_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStockRetry_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.admin.InvUpdateRetryRequest value;
					
					value = new vipapis.inventory.admin.InvUpdateRetryRequest();
					vipapis.inventory.admin.InvUpdateRetryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRetryRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStockRetry_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRetryRequest() != null) {
					
					oprot.WriteFieldBegin("retryRequest");
					
					vipapis.inventory.admin.InvUpdateRetryRequestHelper.getInstance().Write(structs.GetRetryRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateStockRetry_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class delInvUpdateRetryRequest_resultHelper : TBeanSerializer<delInvUpdateRetryRequest_result>
		{
			
			public static delInvUpdateRetryRequest_resultHelper OBJ = new delInvUpdateRetryRequest_resultHelper();
			
			public static delInvUpdateRetryRequest_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(delInvUpdateRetryRequest_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(delInvUpdateRetryRequest_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(delInvUpdateRetryRequest_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getWhiInvUpdateHealth_resultHelper : TBeanSerializer<getWhiInvUpdateHealth_result>
		{
			
			public static getWhiInvUpdateHealth_resultHelper OBJ = new getWhiInvUpdateHealth_resultHelper();
			
			public static getWhiInvUpdateHealth_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getWhiInvUpdateHealth_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getWhiInvUpdateHealth_result structs, Protocol oprot){
				
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
			
			
			public void Validate(getWhiInvUpdateHealth_result bean){
				
				
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
		
		
		
		
		public class listInvUpdateRetryRequest_resultHelper : TBeanSerializer<listInvUpdateRetryRequest_result>
		{
			
			public static listInvUpdateRetryRequest_resultHelper OBJ = new listInvUpdateRetryRequest_resultHelper();
			
			public static listInvUpdateRetryRequest_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listInvUpdateRetryRequest_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.inventory.admin.ListInvRequestRetryRequestResult value;
					
					value = new vipapis.inventory.admin.ListInvRequestRetryRequestResult();
					vipapis.inventory.admin.ListInvRequestRetryRequestResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(listInvUpdateRetryRequest_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.inventory.admin.ListInvRequestRetryRequestResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(listInvUpdateRetryRequest_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class saveInvUpdateRetryRequest_resultHelper : TBeanSerializer<saveInvUpdateRetryRequest_result>
		{
			
			public static saveInvUpdateRetryRequest_resultHelper OBJ = new saveInvUpdateRetryRequest_resultHelper();
			
			public static saveInvUpdateRetryRequest_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(saveInvUpdateRetryRequest_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(saveInvUpdateRetryRequest_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(saveInvUpdateRetryRequest_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class saveWhiInvUpdateHealth_resultHelper : TBeanSerializer<saveWhiInvUpdateHealth_result>
		{
			
			public static saveWhiInvUpdateHealth_resultHelper OBJ = new saveWhiInvUpdateHealth_resultHelper();
			
			public static saveWhiInvUpdateHealth_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(saveWhiInvUpdateHealth_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(saveWhiInvUpdateHealth_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(saveWhiInvUpdateHealth_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateStockRetry_resultHelper : TBeanSerializer<updateStockRetry_result>
		{
			
			public static updateStockRetry_resultHelper OBJ = new updateStockRetry_resultHelper();
			
			public static updateStockRetry_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateStockRetry_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateStockRetry_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateStockRetry_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class InventoryAdminServiceClient : OspRestStub , InventoryAdminService  {
			
			
			public InventoryAdminServiceClient():base("vipapis.inventory.admin.InventoryAdminService","1.0.0") {
				
				
			}
			
			
			
			public void delInvUpdateRetryRequest(int cooperationNo_,string warehouse_,string barcode_) {
				
				send_delInvUpdateRetryRequest(cooperationNo_,warehouse_,barcode_);
				recv_delInvUpdateRetryRequest();
				
			}
			
			
			private void send_delInvUpdateRetryRequest(int cooperationNo_,string warehouse_,string barcode_){
				
				InitInvocation("delInvUpdateRetryRequest");
				
				delInvUpdateRetryRequest_args args = new delInvUpdateRetryRequest_args();
				args.SetCooperationNo(cooperationNo_);
				args.SetWarehouse(warehouse_);
				args.SetBarcode(barcode_);
				
				SendBase(args, delInvUpdateRetryRequest_argsHelper.getInstance());
			}
			
			
			private void recv_delInvUpdateRetryRequest(){
				
				delInvUpdateRetryRequest_result result = new delInvUpdateRetryRequest_result();
				ReceiveBase(result, delInvUpdateRetryRequest_resultHelper.getInstance());
				
				
			}
			
			
			public string getWhiInvUpdateHealth() {
				
				send_getWhiInvUpdateHealth();
				return recv_getWhiInvUpdateHealth(); 
				
			}
			
			
			private void send_getWhiInvUpdateHealth(){
				
				InitInvocation("getWhiInvUpdateHealth");
				
				getWhiInvUpdateHealth_args args = new getWhiInvUpdateHealth_args();
				
				SendBase(args, getWhiInvUpdateHealth_argsHelper.getInstance());
			}
			
			
			private string recv_getWhiInvUpdateHealth(){
				
				getWhiInvUpdateHealth_result result = new getWhiInvUpdateHealth_result();
				ReceiveBase(result, getWhiInvUpdateHealth_resultHelper.getInstance());
				
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
			
			
			public vipapis.inventory.admin.ListInvRequestRetryRequestResult listInvUpdateRetryRequest(int startIndex_,int endIndex_) {
				
				send_listInvUpdateRetryRequest(startIndex_,endIndex_);
				return recv_listInvUpdateRetryRequest(); 
				
			}
			
			
			private void send_listInvUpdateRetryRequest(int startIndex_,int endIndex_){
				
				InitInvocation("listInvUpdateRetryRequest");
				
				listInvUpdateRetryRequest_args args = new listInvUpdateRetryRequest_args();
				args.SetStartIndex(startIndex_);
				args.SetEndIndex(endIndex_);
				
				SendBase(args, listInvUpdateRetryRequest_argsHelper.getInstance());
			}
			
			
			private vipapis.inventory.admin.ListInvRequestRetryRequestResult recv_listInvUpdateRetryRequest(){
				
				listInvUpdateRetryRequest_result result = new listInvUpdateRetryRequest_result();
				ReceiveBase(result, listInvUpdateRetryRequest_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void saveInvUpdateRetryRequest(vipapis.inventory.admin.InvUpdateRetryRequest retryRequest_) {
				
				send_saveInvUpdateRetryRequest(retryRequest_);
				recv_saveInvUpdateRetryRequest();
				
			}
			
			
			private void send_saveInvUpdateRetryRequest(vipapis.inventory.admin.InvUpdateRetryRequest retryRequest_){
				
				InitInvocation("saveInvUpdateRetryRequest");
				
				saveInvUpdateRetryRequest_args args = new saveInvUpdateRetryRequest_args();
				args.SetRetryRequest(retryRequest_);
				
				SendBase(args, saveInvUpdateRetryRequest_argsHelper.getInstance());
			}
			
			
			private void recv_saveInvUpdateRetryRequest(){
				
				saveInvUpdateRetryRequest_result result = new saveInvUpdateRetryRequest_result();
				ReceiveBase(result, saveInvUpdateRetryRequest_resultHelper.getInstance());
				
				
			}
			
			
			public void saveWhiInvUpdateHealth(string health_) {
				
				send_saveWhiInvUpdateHealth(health_);
				recv_saveWhiInvUpdateHealth();
				
			}
			
			
			private void send_saveWhiInvUpdateHealth(string health_){
				
				InitInvocation("saveWhiInvUpdateHealth");
				
				saveWhiInvUpdateHealth_args args = new saveWhiInvUpdateHealth_args();
				args.SetHealth(health_);
				
				SendBase(args, saveWhiInvUpdateHealth_argsHelper.getInstance());
			}
			
			
			private void recv_saveWhiInvUpdateHealth(){
				
				saveWhiInvUpdateHealth_result result = new saveWhiInvUpdateHealth_result();
				ReceiveBase(result, saveWhiInvUpdateHealth_resultHelper.getInstance());
				
				
			}
			
			
			public void updateStockRetry(vipapis.inventory.admin.InvUpdateRetryRequest retryRequest_) {
				
				send_updateStockRetry(retryRequest_);
				recv_updateStockRetry();
				
			}
			
			
			private void send_updateStockRetry(vipapis.inventory.admin.InvUpdateRetryRequest retryRequest_){
				
				InitInvocation("updateStockRetry");
				
				updateStockRetry_args args = new updateStockRetry_args();
				args.SetRetryRequest(retryRequest_);
				
				SendBase(args, updateStockRetry_argsHelper.getInstance());
			}
			
			
			private void recv_updateStockRetry(){
				
				updateStockRetry_result result = new updateStockRetry_result();
				ReceiveBase(result, updateStockRetry_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}