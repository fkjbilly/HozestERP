using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.price{
	
	
	public class JitPriceServiceHelper {
		
		
		
		public class confirmPriceApplication_args {
			
			///<summary>
			/// 确认价格清单数据推送完成请求
			///</summary>
			
			private vipapis.price.ConfirmPriceApplicationRequest request_;
			
			public vipapis.price.ConfirmPriceApplicationRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.price.ConfirmPriceApplicationRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class createPriceApplicationId_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			
		}
		
		
		
		
		public class getPriceApplication_args {
			
			///<summary>
			/// 获取价格清单明细请求
			///</summary>
			
			private vipapis.price.GetPriceApplicationRequest request_;
			
			public vipapis.price.GetPriceApplicationRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.price.GetPriceApplicationRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getPriceApplicationStatus_args {
			
			///<summary>
			/// 获取价格申请单状态请求
			///</summary>
			
			private vipapis.price.GetPriceApplicationStatusRequest request_;
			
			public vipapis.price.GetPriceApplicationStatusRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.price.GetPriceApplicationStatusRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class submitPriceApplication_args {
			
			///<summary>
			/// 提交价格申请单请求
			///</summary>
			
			private vipapis.price.SubmitPriceApplicationRequest request_;
			
			public vipapis.price.SubmitPriceApplicationRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.price.SubmitPriceApplicationRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class updatePriceApplication_args {
			
			///<summary>
			/// 更新价格清单
			///</summary>
			
			private vipapis.price.UpdatePriceApplicationRequest request_;
			
			public vipapis.price.UpdatePriceApplicationRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.price.UpdatePriceApplicationRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class confirmPriceApplication_result {
			
			
		}
		
		
		
		
		public class createPriceApplicationId_result {
			
			///<summary>
			/// 返回一个新的价格申请单id
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPriceApplication_result {
			
			///<summary>
			/// 价格申请单明细信息
			///</summary>
			
			private vipapis.price.GetPriceApplicationResponse success_;
			
			public vipapis.price.GetPriceApplicationResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.price.GetPriceApplicationResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPriceApplicationStatus_result {
			
			///<summary>
			/// 价格申请单状态列表
			///</summary>
			
			private List<vipapis.price.PriceApplicationStatus> success_;
			
			public List<vipapis.price.PriceApplicationStatus> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.price.PriceApplicationStatus> value){
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
		
		
		
		
		public class submitPriceApplication_result {
			
			
		}
		
		
		
		
		public class updatePriceApplication_result {
			
			
		}
		
		
		
		
		
		public class confirmPriceApplication_argsHelper : TBeanSerializer<confirmPriceApplication_args>
		{
			
			public static confirmPriceApplication_argsHelper OBJ = new confirmPriceApplication_argsHelper();
			
			public static confirmPriceApplication_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmPriceApplication_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.price.ConfirmPriceApplicationRequest value;
					
					value = new vipapis.price.ConfirmPriceApplicationRequest();
					vipapis.price.ConfirmPriceApplicationRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmPriceApplication_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.price.ConfirmPriceApplicationRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmPriceApplication_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPriceApplicationId_argsHelper : TBeanSerializer<createPriceApplicationId_args>
		{
			
			public static createPriceApplicationId_argsHelper OBJ = new createPriceApplicationId_argsHelper();
			
			public static createPriceApplicationId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPriceApplicationId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPriceApplicationId_args structs, Protocol oprot){
				
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
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createPriceApplicationId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPriceApplication_argsHelper : TBeanSerializer<getPriceApplication_args>
		{
			
			public static getPriceApplication_argsHelper OBJ = new getPriceApplication_argsHelper();
			
			public static getPriceApplication_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPriceApplication_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.price.GetPriceApplicationRequest value;
					
					value = new vipapis.price.GetPriceApplicationRequest();
					vipapis.price.GetPriceApplicationRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPriceApplication_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.price.GetPriceApplicationRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPriceApplication_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPriceApplicationStatus_argsHelper : TBeanSerializer<getPriceApplicationStatus_args>
		{
			
			public static getPriceApplicationStatus_argsHelper OBJ = new getPriceApplicationStatus_argsHelper();
			
			public static getPriceApplicationStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPriceApplicationStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.price.GetPriceApplicationStatusRequest value;
					
					value = new vipapis.price.GetPriceApplicationStatusRequest();
					vipapis.price.GetPriceApplicationStatusRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPriceApplicationStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.price.GetPriceApplicationStatusRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPriceApplicationStatus_args bean){
				
				
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
		
		
		
		
		public class submitPriceApplication_argsHelper : TBeanSerializer<submitPriceApplication_args>
		{
			
			public static submitPriceApplication_argsHelper OBJ = new submitPriceApplication_argsHelper();
			
			public static submitPriceApplication_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitPriceApplication_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.price.SubmitPriceApplicationRequest value;
					
					value = new vipapis.price.SubmitPriceApplicationRequest();
					vipapis.price.SubmitPriceApplicationRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(submitPriceApplication_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.price.SubmitPriceApplicationRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitPriceApplication_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updatePriceApplication_argsHelper : TBeanSerializer<updatePriceApplication_args>
		{
			
			public static updatePriceApplication_argsHelper OBJ = new updatePriceApplication_argsHelper();
			
			public static updatePriceApplication_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updatePriceApplication_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.price.UpdatePriceApplicationRequest value;
					
					value = new vipapis.price.UpdatePriceApplicationRequest();
					vipapis.price.UpdatePriceApplicationRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updatePriceApplication_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.price.UpdatePriceApplicationRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updatePriceApplication_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmPriceApplication_resultHelper : TBeanSerializer<confirmPriceApplication_result>
		{
			
			public static confirmPriceApplication_resultHelper OBJ = new confirmPriceApplication_resultHelper();
			
			public static confirmPriceApplication_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmPriceApplication_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmPriceApplication_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmPriceApplication_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPriceApplicationId_resultHelper : TBeanSerializer<createPriceApplicationId_result>
		{
			
			public static createPriceApplicationId_resultHelper OBJ = new createPriceApplicationId_resultHelper();
			
			public static createPriceApplicationId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPriceApplicationId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPriceApplicationId_result structs, Protocol oprot){
				
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
			
			
			public void Validate(createPriceApplicationId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPriceApplication_resultHelper : TBeanSerializer<getPriceApplication_result>
		{
			
			public static getPriceApplication_resultHelper OBJ = new getPriceApplication_resultHelper();
			
			public static getPriceApplication_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPriceApplication_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.price.GetPriceApplicationResponse value;
					
					value = new vipapis.price.GetPriceApplicationResponse();
					vipapis.price.GetPriceApplicationResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPriceApplication_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.price.GetPriceApplicationResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPriceApplication_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPriceApplicationStatus_resultHelper : TBeanSerializer<getPriceApplicationStatus_result>
		{
			
			public static getPriceApplicationStatus_resultHelper OBJ = new getPriceApplicationStatus_resultHelper();
			
			public static getPriceApplicationStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPriceApplicationStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.price.PriceApplicationStatus> value;
					
					value = new List<vipapis.price.PriceApplicationStatus>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.price.PriceApplicationStatus elem0;
							
							elem0 = new vipapis.price.PriceApplicationStatus();
							vipapis.price.PriceApplicationStatusHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getPriceApplicationStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.price.PriceApplicationStatus _item0 in structs.GetSuccess()){
						
						
						vipapis.price.PriceApplicationStatusHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPriceApplicationStatus_result bean){
				
				
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
		
		
		
		
		public class submitPriceApplication_resultHelper : TBeanSerializer<submitPriceApplication_result>
		{
			
			public static submitPriceApplication_resultHelper OBJ = new submitPriceApplication_resultHelper();
			
			public static submitPriceApplication_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitPriceApplication_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(submitPriceApplication_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitPriceApplication_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updatePriceApplication_resultHelper : TBeanSerializer<updatePriceApplication_result>
		{
			
			public static updatePriceApplication_resultHelper OBJ = new updatePriceApplication_resultHelper();
			
			public static updatePriceApplication_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updatePriceApplication_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updatePriceApplication_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updatePriceApplication_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class JitPriceServiceClient : OspRestStub , JitPriceService  {
			
			
			public JitPriceServiceClient():base("vipapis.price.JitPriceService","1.0.0") {
				
				
			}
			
			
			
			public void confirmPriceApplication(vipapis.price.ConfirmPriceApplicationRequest request_) {
				
				send_confirmPriceApplication(request_);
				recv_confirmPriceApplication();
				
			}
			
			
			private void send_confirmPriceApplication(vipapis.price.ConfirmPriceApplicationRequest request_){
				
				InitInvocation("confirmPriceApplication");
				
				confirmPriceApplication_args args = new confirmPriceApplication_args();
				args.SetRequest(request_);
				
				SendBase(args, confirmPriceApplication_argsHelper.getInstance());
			}
			
			
			private void recv_confirmPriceApplication(){
				
				confirmPriceApplication_result result = new confirmPriceApplication_result();
				ReceiveBase(result, confirmPriceApplication_resultHelper.getInstance());
				
				
			}
			
			
			public string createPriceApplicationId(int vendor_id_) {
				
				send_createPriceApplicationId(vendor_id_);
				return recv_createPriceApplicationId(); 
				
			}
			
			
			private void send_createPriceApplicationId(int vendor_id_){
				
				InitInvocation("createPriceApplicationId");
				
				createPriceApplicationId_args args = new createPriceApplicationId_args();
				args.SetVendor_id(vendor_id_);
				
				SendBase(args, createPriceApplicationId_argsHelper.getInstance());
			}
			
			
			private string recv_createPriceApplicationId(){
				
				createPriceApplicationId_result result = new createPriceApplicationId_result();
				ReceiveBase(result, createPriceApplicationId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.price.GetPriceApplicationResponse getPriceApplication(vipapis.price.GetPriceApplicationRequest request_) {
				
				send_getPriceApplication(request_);
				return recv_getPriceApplication(); 
				
			}
			
			
			private void send_getPriceApplication(vipapis.price.GetPriceApplicationRequest request_){
				
				InitInvocation("getPriceApplication");
				
				getPriceApplication_args args = new getPriceApplication_args();
				args.SetRequest(request_);
				
				SendBase(args, getPriceApplication_argsHelper.getInstance());
			}
			
			
			private vipapis.price.GetPriceApplicationResponse recv_getPriceApplication(){
				
				getPriceApplication_result result = new getPriceApplication_result();
				ReceiveBase(result, getPriceApplication_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.price.PriceApplicationStatus> getPriceApplicationStatus(vipapis.price.GetPriceApplicationStatusRequest request_) {
				
				send_getPriceApplicationStatus(request_);
				return recv_getPriceApplicationStatus(); 
				
			}
			
			
			private void send_getPriceApplicationStatus(vipapis.price.GetPriceApplicationStatusRequest request_){
				
				InitInvocation("getPriceApplicationStatus");
				
				getPriceApplicationStatus_args args = new getPriceApplicationStatus_args();
				args.SetRequest(request_);
				
				SendBase(args, getPriceApplicationStatus_argsHelper.getInstance());
			}
			
			
			private List<vipapis.price.PriceApplicationStatus> recv_getPriceApplicationStatus(){
				
				getPriceApplicationStatus_result result = new getPriceApplicationStatus_result();
				ReceiveBase(result, getPriceApplicationStatus_resultHelper.getInstance());
				
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
			
			
			public void submitPriceApplication(vipapis.price.SubmitPriceApplicationRequest request_) {
				
				send_submitPriceApplication(request_);
				recv_submitPriceApplication();
				
			}
			
			
			private void send_submitPriceApplication(vipapis.price.SubmitPriceApplicationRequest request_){
				
				InitInvocation("submitPriceApplication");
				
				submitPriceApplication_args args = new submitPriceApplication_args();
				args.SetRequest(request_);
				
				SendBase(args, submitPriceApplication_argsHelper.getInstance());
			}
			
			
			private void recv_submitPriceApplication(){
				
				submitPriceApplication_result result = new submitPriceApplication_result();
				ReceiveBase(result, submitPriceApplication_resultHelper.getInstance());
				
				
			}
			
			
			public void updatePriceApplication(vipapis.price.UpdatePriceApplicationRequest request_) {
				
				send_updatePriceApplication(request_);
				recv_updatePriceApplication();
				
			}
			
			
			private void send_updatePriceApplication(vipapis.price.UpdatePriceApplicationRequest request_){
				
				InitInvocation("updatePriceApplication");
				
				updatePriceApplication_args args = new updatePriceApplication_args();
				args.SetRequest(request_);
				
				SendBase(args, updatePriceApplication_argsHelper.getInstance());
			}
			
			
			private void recv_updatePriceApplication(){
				
				updatePriceApplication_result result = new updatePriceApplication_result();
				ReceiveBase(result, updatePriceApplication_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}