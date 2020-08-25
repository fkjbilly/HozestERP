using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.isv.vreceipt{
	
	
	public class ReceiptContainerServiceHelper {
		
		
		
		public class addReceiptContainer_args {
			
			///<summary>
			/// 采购入库收货信息
			///</summary>
			
			private com.vip.isv.vreceipt.Revinfo revinfo_;
			
			public com.vip.isv.vreceipt.Revinfo GetRevinfo(){
				return this.revinfo_;
			}
			
			public void SetRevinfo(com.vip.isv.vreceipt.Revinfo value){
				this.revinfo_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class addReceiptContainer_result {
			
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
		
		
		
		
		
		public class addReceiptContainer_argsHelper : TBeanSerializer<addReceiptContainer_args>
		{
			
			public static addReceiptContainer_argsHelper OBJ = new addReceiptContainer_argsHelper();
			
			public static addReceiptContainer_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addReceiptContainer_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.vreceipt.Revinfo value;
					
					value = new com.vip.isv.vreceipt.Revinfo();
					com.vip.isv.vreceipt.RevinfoHelper.getInstance().Read(value, iprot);
					
					structs.SetRevinfo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addReceiptContainer_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRevinfo() != null) {
					
					oprot.WriteFieldBegin("revinfo");
					
					com.vip.isv.vreceipt.RevinfoHelper.getInstance().Write(structs.GetRevinfo(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("revinfo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addReceiptContainer_args bean){
				
				
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
		
		
		
		
		public class addReceiptContainer_resultHelper : TBeanSerializer<addReceiptContainer_result>
		{
			
			public static addReceiptContainer_resultHelper OBJ = new addReceiptContainer_resultHelper();
			
			public static addReceiptContainer_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addReceiptContainer_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool? value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addReceiptContainer_result structs, Protocol oprot){
				
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
			
			
			public void Validate(addReceiptContainer_result bean){
				
				
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
		
		
		
		
		public class ReceiptContainerServiceClient : OspRestStub , ReceiptContainerService  {
			
			
			public ReceiptContainerServiceClient():base("com.vip.isv.vreceipt.ReceiptContainerService","1.0.0") {
				
				
			}
			
			
			
			public bool? addReceiptContainer(com.vip.isv.vreceipt.Revinfo revinfo_) {
				
				send_addReceiptContainer(revinfo_);
				return recv_addReceiptContainer(); 
				
			}
			
			
			private void send_addReceiptContainer(com.vip.isv.vreceipt.Revinfo revinfo_){
				
				InitInvocation("addReceiptContainer");
				
				addReceiptContainer_args args = new addReceiptContainer_args();
				args.SetRevinfo(revinfo_);
				
				SendBase(args, addReceiptContainer_argsHelper.getInstance());
			}
			
			
			private bool? recv_addReceiptContainer(){
				
				addReceiptContainer_result result = new addReceiptContainer_result();
				ReceiveBase(result, addReceiptContainer_resultHelper.getInstance());
				
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