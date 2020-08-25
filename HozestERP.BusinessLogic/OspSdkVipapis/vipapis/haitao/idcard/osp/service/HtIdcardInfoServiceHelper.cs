using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.haitao.idcard.osp.service{
	
	
	public class HtIdcardInfoServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class queryIdcardPic_args {
			
			///<summary>
			/// 请求对象
			///</summary>
			
			private com.vip.haitao.idcard.osp.service.HtIdCardInfoRequest request_;
			
			public com.vip.haitao.idcard.osp.service.HtIdCardInfoRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.haitao.idcard.osp.service.HtIdCardInfoRequest value){
				this.request_ = value;
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
		
		
		
		
		public class queryIdcardPic_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.idcard.osp.service.HtIdCardInfoResponse success_;
			
			public com.vip.haitao.idcard.osp.service.HtIdCardInfoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.idcard.osp.service.HtIdCardInfoResponse value){
				this.success_ = value;
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
		
		
		
		
		public class queryIdcardPic_argsHelper : TBeanSerializer<queryIdcardPic_args>
		{
			
			public static queryIdcardPic_argsHelper OBJ = new queryIdcardPic_argsHelper();
			
			public static queryIdcardPic_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryIdcardPic_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.idcard.osp.service.HtIdCardInfoRequest value;
					
					value = new com.vip.haitao.idcard.osp.service.HtIdCardInfoRequest();
					com.vip.haitao.idcard.osp.service.HtIdCardInfoRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(queryIdcardPic_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.haitao.idcard.osp.service.HtIdCardInfoRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(queryIdcardPic_args bean){
				
				
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
		
		
		
		
		public class queryIdcardPic_resultHelper : TBeanSerializer<queryIdcardPic_result>
		{
			
			public static queryIdcardPic_resultHelper OBJ = new queryIdcardPic_resultHelper();
			
			public static queryIdcardPic_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(queryIdcardPic_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.idcard.osp.service.HtIdCardInfoResponse value;
					
					value = new com.vip.haitao.idcard.osp.service.HtIdCardInfoResponse();
					com.vip.haitao.idcard.osp.service.HtIdCardInfoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(queryIdcardPic_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.idcard.osp.service.HtIdCardInfoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(queryIdcardPic_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class HtIdcardInfoServiceClient : OspRestStub , HtIdcardInfoService  {
			
			
			public HtIdcardInfoServiceClient():base("vipapis.haitao.idcard.osp.service.HtIdcardInfoService","1.0.0") {
				
				
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
			
			
			public com.vip.haitao.idcard.osp.service.HtIdCardInfoResponse queryIdcardPic(com.vip.haitao.idcard.osp.service.HtIdCardInfoRequest request_) {
				
				send_queryIdcardPic(request_);
				return recv_queryIdcardPic(); 
				
			}
			
			
			private void send_queryIdcardPic(com.vip.haitao.idcard.osp.service.HtIdCardInfoRequest request_){
				
				InitInvocation("queryIdcardPic");
				
				queryIdcardPic_args args = new queryIdcardPic_args();
				args.SetRequest(request_);
				
				SendBase(args, queryIdcardPic_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.idcard.osp.service.HtIdCardInfoResponse recv_queryIdcardPic(){
				
				queryIdcardPic_result result = new queryIdcardPic_result();
				ReceiveBase(result, queryIdcardPic_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}