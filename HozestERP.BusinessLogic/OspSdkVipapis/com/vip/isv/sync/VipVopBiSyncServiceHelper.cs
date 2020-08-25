using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.isv.sync{
	
	
	public class VipVopBiSyncServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class syncReturnDetail_args {
			
			
		}
		
		
		
		
		public class syncReturnHeader_args {
			
			
		}
		
		
		
		
		public class syncReturnOrder_args {
			
			
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
		
		
		
		
		public class syncReturnDetail_result {
			
			
		}
		
		
		
		
		public class syncReturnHeader_result {
			
			
		}
		
		
		
		
		public class syncReturnOrder_result {
			
			
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
		
		
		
		
		public class syncReturnDetail_argsHelper : TBeanSerializer<syncReturnDetail_args>
		{
			
			public static syncReturnDetail_argsHelper OBJ = new syncReturnDetail_argsHelper();
			
			public static syncReturnDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncReturnDetail_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncReturnDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncReturnDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncReturnHeader_argsHelper : TBeanSerializer<syncReturnHeader_args>
		{
			
			public static syncReturnHeader_argsHelper OBJ = new syncReturnHeader_argsHelper();
			
			public static syncReturnHeader_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncReturnHeader_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncReturnHeader_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncReturnHeader_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncReturnOrder_argsHelper : TBeanSerializer<syncReturnOrder_args>
		{
			
			public static syncReturnOrder_argsHelper OBJ = new syncReturnOrder_argsHelper();
			
			public static syncReturnOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncReturnOrder_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncReturnOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncReturnOrder_args bean){
				
				
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
		
		
		
		
		public class syncReturnDetail_resultHelper : TBeanSerializer<syncReturnDetail_result>
		{
			
			public static syncReturnDetail_resultHelper OBJ = new syncReturnDetail_resultHelper();
			
			public static syncReturnDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncReturnDetail_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncReturnDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncReturnDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncReturnHeader_resultHelper : TBeanSerializer<syncReturnHeader_result>
		{
			
			public static syncReturnHeader_resultHelper OBJ = new syncReturnHeader_resultHelper();
			
			public static syncReturnHeader_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncReturnHeader_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncReturnHeader_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncReturnHeader_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncReturnOrder_resultHelper : TBeanSerializer<syncReturnOrder_result>
		{
			
			public static syncReturnOrder_resultHelper OBJ = new syncReturnOrder_resultHelper();
			
			public static syncReturnOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncReturnOrder_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncReturnOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncReturnOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VipVopBiSyncServiceClient : OspRestStub , VipVopBiSyncService  {
			
			
			public VipVopBiSyncServiceClient():base("com.vip.isv.sync.VipVopBiSyncService","1.0.0") {
				
				
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
			
			
			public void syncReturnDetail() {
				
				send_syncReturnDetail();
				recv_syncReturnDetail();
				
			}
			
			
			private void send_syncReturnDetail(){
				
				InitInvocation("syncReturnDetail");
				
				syncReturnDetail_args args = new syncReturnDetail_args();
				
				SendBase(args, syncReturnDetail_argsHelper.getInstance());
			}
			
			
			private void recv_syncReturnDetail(){
				
				syncReturnDetail_result result = new syncReturnDetail_result();
				ReceiveBase(result, syncReturnDetail_resultHelper.getInstance());
				
				
			}
			
			
			public void syncReturnHeader() {
				
				send_syncReturnHeader();
				recv_syncReturnHeader();
				
			}
			
			
			private void send_syncReturnHeader(){
				
				InitInvocation("syncReturnHeader");
				
				syncReturnHeader_args args = new syncReturnHeader_args();
				
				SendBase(args, syncReturnHeader_argsHelper.getInstance());
			}
			
			
			private void recv_syncReturnHeader(){
				
				syncReturnHeader_result result = new syncReturnHeader_result();
				ReceiveBase(result, syncReturnHeader_resultHelper.getInstance());
				
				
			}
			
			
			public void syncReturnOrder() {
				
				send_syncReturnOrder();
				recv_syncReturnOrder();
				
			}
			
			
			private void send_syncReturnOrder(){
				
				InitInvocation("syncReturnOrder");
				
				syncReturnOrder_args args = new syncReturnOrder_args();
				
				SendBase(args, syncReturnOrder_argsHelper.getInstance());
			}
			
			
			private void recv_syncReturnOrder(){
				
				syncReturnOrder_result result = new syncReturnOrder_result();
				ReceiveBase(result, syncReturnOrder_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}