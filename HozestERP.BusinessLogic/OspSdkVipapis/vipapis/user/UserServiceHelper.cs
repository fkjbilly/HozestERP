using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.user{
	
	
	public class UserServiceHelper {
		
		
		
		public class getGroups_args {
			
			///<summary>
			/// 获取用户群请求
			///</summary>
			
			private vipapis.user.GetGroupsRequest request_;
			
			public vipapis.user.GetGroupsRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.user.GetGroupsRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getUsersByGroupCode_args {
			
			///<summary>
			/// 获取特定人群请求
			///</summary>
			
			private vipapis.user.GetUsersByGroupCodeRequest request_;
			
			public vipapis.user.GetUsersByGroupCodeRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.user.GetUsersByGroupCodeRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getGroups_result {
			
			///<summary>
			/// 获取用户群结果返回
			///</summary>
			
			private vipapis.user.GetGroupsResponse success_;
			
			public vipapis.user.GetGroupsResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.user.GetGroupsResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getUsersByGroupCode_result {
			
			///<summary>
			/// 获取特定人群数据结果返回
			///</summary>
			
			private vipapis.user.GetUsersByGroupCodeResponse success_;
			
			public vipapis.user.GetUsersByGroupCodeResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.user.GetUsersByGroupCodeResponse value){
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
		
		
		
		
		
		public class getGroups_argsHelper : TBeanSerializer<getGroups_args>
		{
			
			public static getGroups_argsHelper OBJ = new getGroups_argsHelper();
			
			public static getGroups_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGroups_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.user.GetGroupsRequest value;
					
					value = new vipapis.user.GetGroupsRequest();
					vipapis.user.GetGroupsRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGroups_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.user.GetGroupsRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGroups_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUsersByGroupCode_argsHelper : TBeanSerializer<getUsersByGroupCode_args>
		{
			
			public static getUsersByGroupCode_argsHelper OBJ = new getUsersByGroupCode_argsHelper();
			
			public static getUsersByGroupCode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUsersByGroupCode_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.user.GetUsersByGroupCodeRequest value;
					
					value = new vipapis.user.GetUsersByGroupCodeRequest();
					vipapis.user.GetUsersByGroupCodeRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUsersByGroupCode_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.user.GetUsersByGroupCodeRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUsersByGroupCode_args bean){
				
				
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
		
		
		
		
		public class getGroups_resultHelper : TBeanSerializer<getGroups_result>
		{
			
			public static getGroups_resultHelper OBJ = new getGroups_resultHelper();
			
			public static getGroups_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGroups_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.user.GetGroupsResponse value;
					
					value = new vipapis.user.GetGroupsResponse();
					vipapis.user.GetGroupsResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGroups_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.user.GetGroupsResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGroups_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUsersByGroupCode_resultHelper : TBeanSerializer<getUsersByGroupCode_result>
		{
			
			public static getUsersByGroupCode_resultHelper OBJ = new getUsersByGroupCode_resultHelper();
			
			public static getUsersByGroupCode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUsersByGroupCode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.user.GetUsersByGroupCodeResponse value;
					
					value = new vipapis.user.GetUsersByGroupCodeResponse();
					vipapis.user.GetUsersByGroupCodeResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUsersByGroupCode_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.user.GetUsersByGroupCodeResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUsersByGroupCode_result bean){
				
				
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
		
		
		
		
		public class UserServiceClient : OspRestStub , UserService  {
			
			
			public UserServiceClient():base("vipapis.user.UserService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.user.GetGroupsResponse getGroups(vipapis.user.GetGroupsRequest request_) {
				
				send_getGroups(request_);
				return recv_getGroups(); 
				
			}
			
			
			private void send_getGroups(vipapis.user.GetGroupsRequest request_){
				
				InitInvocation("getGroups");
				
				getGroups_args args = new getGroups_args();
				args.SetRequest(request_);
				
				SendBase(args, getGroups_argsHelper.getInstance());
			}
			
			
			private vipapis.user.GetGroupsResponse recv_getGroups(){
				
				getGroups_result result = new getGroups_result();
				ReceiveBase(result, getGroups_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.user.GetUsersByGroupCodeResponse getUsersByGroupCode(vipapis.user.GetUsersByGroupCodeRequest request_) {
				
				send_getUsersByGroupCode(request_);
				return recv_getUsersByGroupCode(); 
				
			}
			
			
			private void send_getUsersByGroupCode(vipapis.user.GetUsersByGroupCodeRequest request_){
				
				InitInvocation("getUsersByGroupCode");
				
				getUsersByGroupCode_args args = new getUsersByGroupCode_args();
				args.SetRequest(request_);
				
				SendBase(args, getUsersByGroupCode_argsHelper.getInstance());
			}
			
			
			private vipapis.user.GetUsersByGroupCodeResponse recv_getUsersByGroupCode(){
				
				getUsersByGroupCode_result result = new getUsersByGroupCode_result();
				ReceiveBase(result, getUsersByGroupCode_resultHelper.getInstance());
				
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
			
			
		}
		
		
	}
	
}