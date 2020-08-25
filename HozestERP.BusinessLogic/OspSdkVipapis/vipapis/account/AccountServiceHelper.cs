using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.account{
	
	
	public class AccountServiceHelper {
		
		
		
		public class getEnterpriseAccounts_args {
			
			///<summary>
			/// 查询企业账号升级结果查询请求
			///</summary>
			
			private vipapis.account.EnterpriseAccountQueryRequest request_;
			
			public vipapis.account.EnterpriseAccountQueryRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.account.EnterpriseAccountQueryRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getEnterpriseOrders_args {
			
			///<summary>
			/// 查询企业订单请求
			///</summary>
			
			private vipapis.account.EnterpriseOrderQueryRequest request_;
			
			public vipapis.account.EnterpriseOrderQueryRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.account.EnterpriseOrderQueryRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateEnterpriseAccount_args {
			
			///<summary>
			/// 企业账号升级请求
			///</summary>
			
			private vipapis.account.EnterpriseAccountUpdateRequest request_;
			
			public vipapis.account.EnterpriseAccountUpdateRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.account.EnterpriseAccountUpdateRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class updateEnterpriseAccounts_args {
			
			///<summary>
			/// 企业账号升级批量请求
			///</summary>
			
			private vipapis.account.EnterpriseAccountBatchUpdateRequest request_;
			
			public vipapis.account.EnterpriseAccountBatchUpdateRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.account.EnterpriseAccountBatchUpdateRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getEnterpriseAccounts_result {
			
			///<summary>
			///</summary>
			
			private vipapis.account.EnterpriseAccountResponse success_;
			
			public vipapis.account.EnterpriseAccountResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.account.EnterpriseAccountResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getEnterpriseOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.account.EnterpriseOrderResponse success_;
			
			public vipapis.account.EnterpriseOrderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.account.EnterpriseOrderResponse value){
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
		
		
		
		
		public class updateEnterpriseAccount_result {
			
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
		
		
		
		
		public class updateEnterpriseAccounts_result {
			
			///<summary>
			///</summary>
			
			private vipapis.account.EnterpriseAccountsApplyResponse success_;
			
			public vipapis.account.EnterpriseAccountsApplyResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.account.EnterpriseAccountsApplyResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getEnterpriseAccounts_argsHelper : TBeanSerializer<getEnterpriseAccounts_args>
		{
			
			public static getEnterpriseAccounts_argsHelper OBJ = new getEnterpriseAccounts_argsHelper();
			
			public static getEnterpriseAccounts_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getEnterpriseAccounts_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.account.EnterpriseAccountQueryRequest value;
					
					value = new vipapis.account.EnterpriseAccountQueryRequest();
					vipapis.account.EnterpriseAccountQueryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getEnterpriseAccounts_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.account.EnterpriseAccountQueryRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getEnterpriseAccounts_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getEnterpriseOrders_argsHelper : TBeanSerializer<getEnterpriseOrders_args>
		{
			
			public static getEnterpriseOrders_argsHelper OBJ = new getEnterpriseOrders_argsHelper();
			
			public static getEnterpriseOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getEnterpriseOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.account.EnterpriseOrderQueryRequest value;
					
					value = new vipapis.account.EnterpriseOrderQueryRequest();
					vipapis.account.EnterpriseOrderQueryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getEnterpriseOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.account.EnterpriseOrderQueryRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getEnterpriseOrders_args bean){
				
				
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
		
		
		
		
		public class updateEnterpriseAccount_argsHelper : TBeanSerializer<updateEnterpriseAccount_args>
		{
			
			public static updateEnterpriseAccount_argsHelper OBJ = new updateEnterpriseAccount_argsHelper();
			
			public static updateEnterpriseAccount_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateEnterpriseAccount_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.account.EnterpriseAccountUpdateRequest value;
					
					value = new vipapis.account.EnterpriseAccountUpdateRequest();
					vipapis.account.EnterpriseAccountUpdateRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateEnterpriseAccount_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.account.EnterpriseAccountUpdateRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateEnterpriseAccount_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateEnterpriseAccounts_argsHelper : TBeanSerializer<updateEnterpriseAccounts_args>
		{
			
			public static updateEnterpriseAccounts_argsHelper OBJ = new updateEnterpriseAccounts_argsHelper();
			
			public static updateEnterpriseAccounts_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateEnterpriseAccounts_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.account.EnterpriseAccountBatchUpdateRequest value;
					
					value = new vipapis.account.EnterpriseAccountBatchUpdateRequest();
					vipapis.account.EnterpriseAccountBatchUpdateRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateEnterpriseAccounts_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.account.EnterpriseAccountBatchUpdateRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateEnterpriseAccounts_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getEnterpriseAccounts_resultHelper : TBeanSerializer<getEnterpriseAccounts_result>
		{
			
			public static getEnterpriseAccounts_resultHelper OBJ = new getEnterpriseAccounts_resultHelper();
			
			public static getEnterpriseAccounts_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getEnterpriseAccounts_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.account.EnterpriseAccountResponse value;
					
					value = new vipapis.account.EnterpriseAccountResponse();
					vipapis.account.EnterpriseAccountResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getEnterpriseAccounts_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.account.EnterpriseAccountResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getEnterpriseAccounts_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getEnterpriseOrders_resultHelper : TBeanSerializer<getEnterpriseOrders_result>
		{
			
			public static getEnterpriseOrders_resultHelper OBJ = new getEnterpriseOrders_resultHelper();
			
			public static getEnterpriseOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getEnterpriseOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.account.EnterpriseOrderResponse value;
					
					value = new vipapis.account.EnterpriseOrderResponse();
					vipapis.account.EnterpriseOrderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getEnterpriseOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.account.EnterpriseOrderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getEnterpriseOrders_result bean){
				
				
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
		
		
		
		
		public class updateEnterpriseAccount_resultHelper : TBeanSerializer<updateEnterpriseAccount_result>
		{
			
			public static updateEnterpriseAccount_resultHelper OBJ = new updateEnterpriseAccount_resultHelper();
			
			public static updateEnterpriseAccount_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateEnterpriseAccount_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateEnterpriseAccount_result structs, Protocol oprot){
				
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
			
			
			public void Validate(updateEnterpriseAccount_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateEnterpriseAccounts_resultHelper : TBeanSerializer<updateEnterpriseAccounts_result>
		{
			
			public static updateEnterpriseAccounts_resultHelper OBJ = new updateEnterpriseAccounts_resultHelper();
			
			public static updateEnterpriseAccounts_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateEnterpriseAccounts_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.account.EnterpriseAccountsApplyResponse value;
					
					value = new vipapis.account.EnterpriseAccountsApplyResponse();
					vipapis.account.EnterpriseAccountsApplyResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateEnterpriseAccounts_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.account.EnterpriseAccountsApplyResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateEnterpriseAccounts_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class AccountServiceClient : OspRestStub , AccountService  {
			
			
			public AccountServiceClient():base("vipapis.account.AccountService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.account.EnterpriseAccountResponse getEnterpriseAccounts(vipapis.account.EnterpriseAccountQueryRequest request_) {
				
				send_getEnterpriseAccounts(request_);
				return recv_getEnterpriseAccounts(); 
				
			}
			
			
			private void send_getEnterpriseAccounts(vipapis.account.EnterpriseAccountQueryRequest request_){
				
				InitInvocation("getEnterpriseAccounts");
				
				getEnterpriseAccounts_args args = new getEnterpriseAccounts_args();
				args.SetRequest(request_);
				
				SendBase(args, getEnterpriseAccounts_argsHelper.getInstance());
			}
			
			
			private vipapis.account.EnterpriseAccountResponse recv_getEnterpriseAccounts(){
				
				getEnterpriseAccounts_result result = new getEnterpriseAccounts_result();
				ReceiveBase(result, getEnterpriseAccounts_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.account.EnterpriseOrderResponse getEnterpriseOrders(vipapis.account.EnterpriseOrderQueryRequest request_) {
				
				send_getEnterpriseOrders(request_);
				return recv_getEnterpriseOrders(); 
				
			}
			
			
			private void send_getEnterpriseOrders(vipapis.account.EnterpriseOrderQueryRequest request_){
				
				InitInvocation("getEnterpriseOrders");
				
				getEnterpriseOrders_args args = new getEnterpriseOrders_args();
				args.SetRequest(request_);
				
				SendBase(args, getEnterpriseOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.account.EnterpriseOrderResponse recv_getEnterpriseOrders(){
				
				getEnterpriseOrders_result result = new getEnterpriseOrders_result();
				ReceiveBase(result, getEnterpriseOrders_resultHelper.getInstance());
				
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
			
			
			public bool? updateEnterpriseAccount(vipapis.account.EnterpriseAccountUpdateRequest request_) {
				
				send_updateEnterpriseAccount(request_);
				return recv_updateEnterpriseAccount(); 
				
			}
			
			
			private void send_updateEnterpriseAccount(vipapis.account.EnterpriseAccountUpdateRequest request_){
				
				InitInvocation("updateEnterpriseAccount");
				
				updateEnterpriseAccount_args args = new updateEnterpriseAccount_args();
				args.SetRequest(request_);
				
				SendBase(args, updateEnterpriseAccount_argsHelper.getInstance());
			}
			
			
			private bool? recv_updateEnterpriseAccount(){
				
				updateEnterpriseAccount_result result = new updateEnterpriseAccount_result();
				ReceiveBase(result, updateEnterpriseAccount_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.account.EnterpriseAccountsApplyResponse updateEnterpriseAccounts(vipapis.account.EnterpriseAccountBatchUpdateRequest request_) {
				
				send_updateEnterpriseAccounts(request_);
				return recv_updateEnterpriseAccounts(); 
				
			}
			
			
			private void send_updateEnterpriseAccounts(vipapis.account.EnterpriseAccountBatchUpdateRequest request_){
				
				InitInvocation("updateEnterpriseAccounts");
				
				updateEnterpriseAccounts_args args = new updateEnterpriseAccounts_args();
				args.SetRequest(request_);
				
				SendBase(args, updateEnterpriseAccounts_argsHelper.getInstance());
			}
			
			
			private vipapis.account.EnterpriseAccountsApplyResponse recv_updateEnterpriseAccounts(){
				
				updateEnterpriseAccounts_result result = new updateEnterpriseAccounts_result();
				ReceiveBase(result, updateEnterpriseAccounts_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}