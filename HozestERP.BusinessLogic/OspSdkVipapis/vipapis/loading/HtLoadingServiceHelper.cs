using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.loading{
	
	
	public class HtLoadingServiceHelper {
		
		
		
		public class getOutRLHandleResult_args {
			
			///<summary>
			/// 调用方用户id
			///</summary>
			
			private string userId_;
			
			///<summary>
			/// 装载单号
			///</summary>
			
			private string listNo_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<string> orders_;
			
			public string GetUserId(){
				return this.userId_;
			}
			
			public void SetUserId(string value){
				this.userId_ = value;
			}
			public string GetListNo(){
				return this.listNo_;
			}
			
			public void SetListNo(string value){
				this.listNo_ = value;
			}
			public List<string> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<string> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class receiveInLRInfo_args {
			
			///<summary>
			/// 海关编码
			/// @sampleValue customsCode gzhg
			///</summary>
			
			private string customsCode_;
			
			///<summary>
			/// 调用方编号
			/// @sampleValue userId zhuozhi
			///</summary>
			
			private string userId_;
			
			///<summary>
			/// 装载单号
			/// @sampleValue loadingId 16112200001675
			///</summary>
			
			private string loadingId_;
			
			///<summary>
			/// 车牌号
			/// @sampleValue carLicense 粤AS9706
			///</summary>
			
			private string carLicense_;
			
			///<summary>
			/// 装载核放数量
			/// @sampleValue loadingNumber 1000
			///</summary>
			
			private string loadingNumber_;
			
			///<summary>
			/// 海关核放单号
			/// @sampleValue customsReleaseNo CUSTZZ161121000006
			///</summary>
			
			private string customsReleaseNo_;
			
			///<summary>
			/// 核放订单列表
			/// @sampleValue orders [16002227625728,16012227625729]
			///</summary>
			
			private List<string> orders_;
			
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			public string GetUserId(){
				return this.userId_;
			}
			
			public void SetUserId(string value){
				this.userId_ = value;
			}
			public string GetLoadingId(){
				return this.loadingId_;
			}
			
			public void SetLoadingId(string value){
				this.loadingId_ = value;
			}
			public string GetCarLicense(){
				return this.carLicense_;
			}
			
			public void SetCarLicense(string value){
				this.carLicense_ = value;
			}
			public string GetLoadingNumber(){
				return this.loadingNumber_;
			}
			
			public void SetLoadingNumber(string value){
				this.loadingNumber_ = value;
			}
			public string GetCustomsReleaseNo(){
				return this.customsReleaseNo_;
			}
			
			public void SetCustomsReleaseNo(string value){
				this.customsReleaseNo_ = value;
			}
			public List<string> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<string> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class receiveOutLRInfo_args {
			
			///<summary>
			/// 装载单详情
			///</summary>
			
			private com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParam param_;
			
			public com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParam GetParam(){
				return this.param_;
			}
			
			public void SetParam(com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParam value){
				this.param_ = value;
			}
			
		}
		
		
		
		
		public class sendLoadingDeclare_args {
			
			///<summary>
			/// 实例编码
			///</summary>
			
			private string instanceCode_;
			
			///<summary>
			/// 节点编码
			///</summary>
			
			private string nodeCode_;
			
			public string GetInstanceCode(){
				return this.instanceCode_;
			}
			
			public void SetInstanceCode(string value){
				this.instanceCode_ = value;
			}
			public string GetNodeCode(){
				return this.nodeCode_;
			}
			
			public void SetNodeCode(string value){
				this.nodeCode_ = value;
			}
			
		}
		
		
		
		
		public class getOutRLHandleResult_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.loading.osp.service.OutRLHandleResult success_;
			
			public com.vip.haitao.loading.osp.service.OutRLHandleResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.loading.osp.service.OutRLHandleResult value){
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
		
		
		
		
		public class receiveInLRInfo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.loading.osp.service.CommonResponse success_;
			
			public com.vip.haitao.loading.osp.service.CommonResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.loading.osp.service.CommonResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class receiveOutLRInfo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.loading.osp.service.PostResponse success_;
			
			public com.vip.haitao.loading.osp.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.loading.osp.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class sendLoadingDeclare_result {
			
			
		}
		
		
		
		
		
		public class getOutRLHandleResult_argsHelper : TBeanSerializer<getOutRLHandleResult_args>
		{
			
			public static getOutRLHandleResult_argsHelper OBJ = new getOutRLHandleResult_argsHelper();
			
			public static getOutRLHandleResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutRLHandleResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetUserId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetListNo(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrders(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutRLHandleResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetUserId() != null) {
					
					oprot.WriteFieldBegin("userId");
					oprot.WriteString(structs.GetUserId());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("userId can not be null!");
				}
				
				
				if(structs.GetListNo() != null) {
					
					oprot.WriteFieldBegin("listNo");
					oprot.WriteString(structs.GetListNo());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("listNo can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrders()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orders can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutRLHandleResult_args bean){
				
				
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
		
		
		
		
		public class receiveInLRInfo_argsHelper : TBeanSerializer<receiveInLRInfo_args>
		{
			
			public static receiveInLRInfo_argsHelper OBJ = new receiveInLRInfo_argsHelper();
			
			public static receiveInLRInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveInLRInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetUserId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetLoadingId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCarLicense(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetLoadingNumber(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsReleaseNo(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrders(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveInLRInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("customsCode can not be null!");
				}
				
				
				if(structs.GetUserId() != null) {
					
					oprot.WriteFieldBegin("userId");
					oprot.WriteString(structs.GetUserId());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("userId can not be null!");
				}
				
				
				if(structs.GetLoadingId() != null) {
					
					oprot.WriteFieldBegin("loadingId");
					oprot.WriteString(structs.GetLoadingId());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("loadingId can not be null!");
				}
				
				
				if(structs.GetCarLicense() != null) {
					
					oprot.WriteFieldBegin("carLicense");
					oprot.WriteString(structs.GetCarLicense());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("carLicense can not be null!");
				}
				
				
				if(structs.GetLoadingNumber() != null) {
					
					oprot.WriteFieldBegin("loadingNumber");
					oprot.WriteString(structs.GetLoadingNumber());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("loadingNumber can not be null!");
				}
				
				
				if(structs.GetCustomsReleaseNo() != null) {
					
					oprot.WriteFieldBegin("customsReleaseNo");
					oprot.WriteString(structs.GetCustomsReleaseNo());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("customsReleaseNo can not be null!");
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrders()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orders can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveInLRInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class receiveOutLRInfo_argsHelper : TBeanSerializer<receiveOutLRInfo_args>
		{
			
			public static receiveOutLRInfo_argsHelper OBJ = new receiveOutLRInfo_argsHelper();
			
			public static receiveOutLRInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveOutLRInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParam value;
					
					value = new com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParam();
					com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParamHelper.getInstance().Read(value, iprot);
					
					structs.SetParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveOutLRInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetParam() != null) {
					
					oprot.WriteFieldBegin("param");
					
					com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParamHelper.getInstance().Write(structs.GetParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("param can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveOutLRInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class sendLoadingDeclare_argsHelper : TBeanSerializer<sendLoadingDeclare_args>
		{
			
			public static sendLoadingDeclare_argsHelper OBJ = new sendLoadingDeclare_argsHelper();
			
			public static sendLoadingDeclare_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sendLoadingDeclare_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetInstanceCode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetNodeCode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sendLoadingDeclare_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetInstanceCode() != null) {
					
					oprot.WriteFieldBegin("instanceCode");
					oprot.WriteString(structs.GetInstanceCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("instanceCode can not be null!");
				}
				
				
				if(structs.GetNodeCode() != null) {
					
					oprot.WriteFieldBegin("nodeCode");
					oprot.WriteString(structs.GetNodeCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("nodeCode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(sendLoadingDeclare_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutRLHandleResult_resultHelper : TBeanSerializer<getOutRLHandleResult_result>
		{
			
			public static getOutRLHandleResult_resultHelper OBJ = new getOutRLHandleResult_resultHelper();
			
			public static getOutRLHandleResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutRLHandleResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.loading.osp.service.OutRLHandleResult value;
					
					value = new com.vip.haitao.loading.osp.service.OutRLHandleResult();
					com.vip.haitao.loading.osp.service.OutRLHandleResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutRLHandleResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.loading.osp.service.OutRLHandleResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutRLHandleResult_result bean){
				
				
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
		
		
		
		
		public class receiveInLRInfo_resultHelper : TBeanSerializer<receiveInLRInfo_result>
		{
			
			public static receiveInLRInfo_resultHelper OBJ = new receiveInLRInfo_resultHelper();
			
			public static receiveInLRInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveInLRInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.loading.osp.service.CommonResponse value;
					
					value = new com.vip.haitao.loading.osp.service.CommonResponse();
					com.vip.haitao.loading.osp.service.CommonResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveInLRInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.loading.osp.service.CommonResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveInLRInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class receiveOutLRInfo_resultHelper : TBeanSerializer<receiveOutLRInfo_result>
		{
			
			public static receiveOutLRInfo_resultHelper OBJ = new receiveOutLRInfo_resultHelper();
			
			public static receiveOutLRInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveOutLRInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.loading.osp.service.PostResponse value;
					
					value = new com.vip.haitao.loading.osp.service.PostResponse();
					com.vip.haitao.loading.osp.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveOutLRInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.loading.osp.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveOutLRInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class sendLoadingDeclare_resultHelper : TBeanSerializer<sendLoadingDeclare_result>
		{
			
			public static sendLoadingDeclare_resultHelper OBJ = new sendLoadingDeclare_resultHelper();
			
			public static sendLoadingDeclare_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sendLoadingDeclare_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sendLoadingDeclare_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(sendLoadingDeclare_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class HtLoadingServiceClient : OspRestStub , HtLoadingService  {
			
			
			public HtLoadingServiceClient():base("vipapis.loading.HtLoadingService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.haitao.loading.osp.service.OutRLHandleResult getOutRLHandleResult(string userId_,string listNo_,List<string> orders_) {
				
				send_getOutRLHandleResult(userId_,listNo_,orders_);
				return recv_getOutRLHandleResult(); 
				
			}
			
			
			private void send_getOutRLHandleResult(string userId_,string listNo_,List<string> orders_){
				
				InitInvocation("getOutRLHandleResult");
				
				getOutRLHandleResult_args args = new getOutRLHandleResult_args();
				args.SetUserId(userId_);
				args.SetListNo(listNo_);
				args.SetOrders(orders_);
				
				SendBase(args, getOutRLHandleResult_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.loading.osp.service.OutRLHandleResult recv_getOutRLHandleResult(){
				
				getOutRLHandleResult_result result = new getOutRLHandleResult_result();
				ReceiveBase(result, getOutRLHandleResult_resultHelper.getInstance());
				
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
			
			
			public com.vip.haitao.loading.osp.service.CommonResponse receiveInLRInfo(string customsCode_,string userId_,string loadingId_,string carLicense_,string loadingNumber_,string customsReleaseNo_,List<string> orders_) {
				
				send_receiveInLRInfo(customsCode_,userId_,loadingId_,carLicense_,loadingNumber_,customsReleaseNo_,orders_);
				return recv_receiveInLRInfo(); 
				
			}
			
			
			private void send_receiveInLRInfo(string customsCode_,string userId_,string loadingId_,string carLicense_,string loadingNumber_,string customsReleaseNo_,List<string> orders_){
				
				InitInvocation("receiveInLRInfo");
				
				receiveInLRInfo_args args = new receiveInLRInfo_args();
				args.SetCustomsCode(customsCode_);
				args.SetUserId(userId_);
				args.SetLoadingId(loadingId_);
				args.SetCarLicense(carLicense_);
				args.SetLoadingNumber(loadingNumber_);
				args.SetCustomsReleaseNo(customsReleaseNo_);
				args.SetOrders(orders_);
				
				SendBase(args, receiveInLRInfo_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.loading.osp.service.CommonResponse recv_receiveInLRInfo(){
				
				receiveInLRInfo_result result = new receiveInLRInfo_result();
				ReceiveBase(result, receiveInLRInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.loading.osp.service.PostResponse receiveOutLRInfo(com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParam param_) {
				
				send_receiveOutLRInfo(param_);
				return recv_receiveOutLRInfo(); 
				
			}
			
			
			private void send_receiveOutLRInfo(com.vip.haitao.loading.osp.service.HtReceiveOutLoadingReleaseParam param_){
				
				InitInvocation("receiveOutLRInfo");
				
				receiveOutLRInfo_args args = new receiveOutLRInfo_args();
				args.SetParam(param_);
				
				SendBase(args, receiveOutLRInfo_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.loading.osp.service.PostResponse recv_receiveOutLRInfo(){
				
				receiveOutLRInfo_result result = new receiveOutLRInfo_result();
				ReceiveBase(result, receiveOutLRInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void sendLoadingDeclare(string instanceCode_,string nodeCode_) {
				
				send_sendLoadingDeclare(instanceCode_,nodeCode_);
				recv_sendLoadingDeclare();
				
			}
			
			
			private void send_sendLoadingDeclare(string instanceCode_,string nodeCode_){
				
				InitInvocation("sendLoadingDeclare");
				
				sendLoadingDeclare_args args = new sendLoadingDeclare_args();
				args.SetInstanceCode(instanceCode_);
				args.SetNodeCode(nodeCode_);
				
				SendBase(args, sendLoadingDeclare_argsHelper.getInstance());
			}
			
			
			private void recv_sendLoadingDeclare(){
				
				sendLoadingDeclare_result result = new sendLoadingDeclare_result();
				ReceiveBase(result, sendLoadingDeclare_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}