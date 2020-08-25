using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.ezr{
	
	
	public class ChannelEzrServiceHelper {
		
		
		
		public class closePCStore_args {
			
			///<summary>
			/// 手机号
			///</summary>
			
			private string phoneNo_;
			
			///<summary>
			/// 供应商编码
			///</summary>
			
			private long? vendorCode_;
			
			public string GetPhoneNo(){
				return this.phoneNo_;
			}
			
			public void SetPhoneNo(string value){
				this.phoneNo_ = value;
			}
			public long? GetVendorCode(){
				return this.vendorCode_;
			}
			
			public void SetVendorCode(long? value){
				this.vendorCode_ = value;
			}
			
		}
		
		
		
		
		public class createPCStore_args {
			
			///<summary>
			/// 手机号
			///</summary>
			
			private string phoneNo_;
			
			///<summary>
			/// 供应商编码
			///</summary>
			
			private long? vendorCode_;
			
			///<summary>
			/// 店铺名称
			///</summary>
			
			private string storeName_;
			
			public string GetPhoneNo(){
				return this.phoneNo_;
			}
			
			public void SetPhoneNo(string value){
				this.phoneNo_ = value;
			}
			public long? GetVendorCode(){
				return this.vendorCode_;
			}
			
			public void SetVendorCode(long? value){
				this.vendorCode_ = value;
			}
			public string GetStoreName(){
				return this.storeName_;
			}
			
			public void SetStoreName(string value){
				this.storeName_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class closePCStore_result {
			
			
		}
		
		
		
		
		public class createPCStore_result {
			
			
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
		
		
		
		
		
		public class closePCStore_argsHelper : TBeanSerializer<closePCStore_args>
		{
			
			public static closePCStore_argsHelper OBJ = new closePCStore_argsHelper();
			
			public static closePCStore_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(closePCStore_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPhoneNo(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendorCode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(closePCStore_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetPhoneNo() != null) {
					
					oprot.WriteFieldBegin("phoneNo");
					oprot.WriteString(structs.GetPhoneNo());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("phoneNo can not be null!");
				}
				
				
				if(structs.GetVendorCode() != null) {
					
					oprot.WriteFieldBegin("vendorCode");
					oprot.WriteI64((long)structs.GetVendorCode()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorCode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(closePCStore_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPCStore_argsHelper : TBeanSerializer<createPCStore_args>
		{
			
			public static createPCStore_argsHelper OBJ = new createPCStore_argsHelper();
			
			public static createPCStore_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPCStore_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPhoneNo(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendorCode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStoreName(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPCStore_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetPhoneNo() != null) {
					
					oprot.WriteFieldBegin("phoneNo");
					oprot.WriteString(structs.GetPhoneNo());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("phoneNo can not be null!");
				}
				
				
				if(structs.GetVendorCode() != null) {
					
					oprot.WriteFieldBegin("vendorCode");
					oprot.WriteI64((long)structs.GetVendorCode()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorCode can not be null!");
				}
				
				
				if(structs.GetStoreName() != null) {
					
					oprot.WriteFieldBegin("storeName");
					oprot.WriteString(structs.GetStoreName());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("storeName can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createPCStore_args bean){
				
				
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
		
		
		
		
		public class closePCStore_resultHelper : TBeanSerializer<closePCStore_result>
		{
			
			public static closePCStore_resultHelper OBJ = new closePCStore_resultHelper();
			
			public static closePCStore_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(closePCStore_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(closePCStore_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(closePCStore_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createPCStore_resultHelper : TBeanSerializer<createPCStore_result>
		{
			
			public static createPCStore_resultHelper OBJ = new createPCStore_resultHelper();
			
			public static createPCStore_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createPCStore_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createPCStore_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createPCStore_result bean){
				
				
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
		
		
		
		
		public class ChannelEzrServiceClient : OspRestStub , ChannelEzrService  {
			
			
			public ChannelEzrServiceClient():base("vipapis.ezr.ChannelEzrService","1.0.0") {
				
				
			}
			
			
			
			public void closePCStore(string phoneNo_,long vendorCode_) {
				
				send_closePCStore(phoneNo_,vendorCode_);
				recv_closePCStore();
				
			}
			
			
			private void send_closePCStore(string phoneNo_,long vendorCode_){
				
				InitInvocation("closePCStore");
				
				closePCStore_args args = new closePCStore_args();
				args.SetPhoneNo(phoneNo_);
				args.SetVendorCode(vendorCode_);
				
				SendBase(args, closePCStore_argsHelper.getInstance());
			}
			
			
			private void recv_closePCStore(){
				
				closePCStore_result result = new closePCStore_result();
				ReceiveBase(result, closePCStore_resultHelper.getInstance());
				
				
			}
			
			
			public void createPCStore(string phoneNo_,long vendorCode_,string storeName_) {
				
				send_createPCStore(phoneNo_,vendorCode_,storeName_);
				recv_createPCStore();
				
			}
			
			
			private void send_createPCStore(string phoneNo_,long vendorCode_,string storeName_){
				
				InitInvocation("createPCStore");
				
				createPCStore_args args = new createPCStore_args();
				args.SetPhoneNo(phoneNo_);
				args.SetVendorCode(vendorCode_);
				args.SetStoreName(storeName_);
				
				SendBase(args, createPCStore_argsHelper.getInstance());
			}
			
			
			private void recv_createPCStore(){
				
				createPCStore_result result = new createPCStore_result();
				ReceiveBase(result, createPCStore_resultHelper.getInstance());
				
				
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