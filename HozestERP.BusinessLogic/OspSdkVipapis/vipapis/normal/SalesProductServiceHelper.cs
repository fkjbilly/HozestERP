using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.normal{
	
	
	public class SalesProductServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class listingSpu_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 常态合作编码
			///</summary>
			
			private string cooperation_no_;
			
			///<summary>
			/// 供应商仓库编码
			///</summary>
			
			private string warehouse_supplier_;
			
			///<summary>
			/// 货号列表
			///</summary>
			
			private string sn_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetCooperation_no(){
				return this.cooperation_no_;
			}
			
			public void SetCooperation_no(string value){
				this.cooperation_no_ = value;
			}
			public string GetWarehouse_supplier(){
				return this.warehouse_supplier_;
			}
			
			public void SetWarehouse_supplier(string value){
				this.warehouse_supplier_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
			
		}
		
		
		
		
		public class unlistingSpu_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 常态合作编码
			///</summary>
			
			private string cooperation_no_;
			
			///<summary>
			/// 供应商仓库编码
			///</summary>
			
			private string warehouse_supplier_;
			
			///<summary>
			/// 货号列表
			///</summary>
			
			private string sn_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetCooperation_no(){
				return this.cooperation_no_;
			}
			
			public void SetCooperation_no(string value){
				this.cooperation_no_ = value;
			}
			public string GetWarehouse_supplier(){
				return this.warehouse_supplier_;
			}
			
			public void SetWarehouse_supplier(string value){
				this.warehouse_supplier_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
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
		
		
		
		
		public class listingSpu_result {
			
			
		}
		
		
		
		
		public class unlistingSpu_result {
			
			
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
		
		
		
		
		public class listingSpu_argsHelper : TBeanSerializer<listingSpu_args>
		{
			
			public static listingSpu_argsHelper OBJ = new listingSpu_argsHelper();
			
			public static listingSpu_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listingSpu_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCooperation_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse_supplier(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(listingSpu_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetCooperation_no() != null) {
					
					oprot.WriteFieldBegin("cooperation_no");
					oprot.WriteString(structs.GetCooperation_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetWarehouse_supplier() != null) {
					
					oprot.WriteFieldBegin("warehouse_supplier");
					oprot.WriteString(structs.GetWarehouse_supplier());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sn can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(listingSpu_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class unlistingSpu_argsHelper : TBeanSerializer<unlistingSpu_args>
		{
			
			public static unlistingSpu_argsHelper OBJ = new unlistingSpu_argsHelper();
			
			public static unlistingSpu_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(unlistingSpu_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCooperation_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse_supplier(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(unlistingSpu_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetCooperation_no() != null) {
					
					oprot.WriteFieldBegin("cooperation_no");
					oprot.WriteString(structs.GetCooperation_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetWarehouse_supplier() != null) {
					
					oprot.WriteFieldBegin("warehouse_supplier");
					oprot.WriteString(structs.GetWarehouse_supplier());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sn can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(unlistingSpu_args bean){
				
				
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
		
		
		
		
		public class listingSpu_resultHelper : TBeanSerializer<listingSpu_result>
		{
			
			public static listingSpu_resultHelper OBJ = new listingSpu_resultHelper();
			
			public static listingSpu_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listingSpu_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(listingSpu_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(listingSpu_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class unlistingSpu_resultHelper : TBeanSerializer<unlistingSpu_result>
		{
			
			public static unlistingSpu_resultHelper OBJ = new unlistingSpu_resultHelper();
			
			public static unlistingSpu_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(unlistingSpu_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(unlistingSpu_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(unlistingSpu_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class SalesProductServiceClient : OspRestStub , SalesProductService  {
			
			
			public SalesProductServiceClient():base("vipapis.normal.SalesProductService","1.0.0") {
				
				
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
			
			
			public void listingSpu(int vendor_id_,string cooperation_no_,string warehouse_supplier_,string sn_) {
				
				send_listingSpu(vendor_id_,cooperation_no_,warehouse_supplier_,sn_);
				recv_listingSpu();
				
			}
			
			
			private void send_listingSpu(int vendor_id_,string cooperation_no_,string warehouse_supplier_,string sn_){
				
				InitInvocation("listingSpu");
				
				listingSpu_args args = new listingSpu_args();
				args.SetVendor_id(vendor_id_);
				args.SetCooperation_no(cooperation_no_);
				args.SetWarehouse_supplier(warehouse_supplier_);
				args.SetSn(sn_);
				
				SendBase(args, listingSpu_argsHelper.getInstance());
			}
			
			
			private void recv_listingSpu(){
				
				listingSpu_result result = new listingSpu_result();
				ReceiveBase(result, listingSpu_resultHelper.getInstance());
				
				
			}
			
			
			public void unlistingSpu(int vendor_id_,string cooperation_no_,string warehouse_supplier_,string sn_) {
				
				send_unlistingSpu(vendor_id_,cooperation_no_,warehouse_supplier_,sn_);
				recv_unlistingSpu();
				
			}
			
			
			private void send_unlistingSpu(int vendor_id_,string cooperation_no_,string warehouse_supplier_,string sn_){
				
				InitInvocation("unlistingSpu");
				
				unlistingSpu_args args = new unlistingSpu_args();
				args.SetVendor_id(vendor_id_);
				args.SetCooperation_no(cooperation_no_);
				args.SetWarehouse_supplier(warehouse_supplier_);
				args.SetSn(sn_);
				
				SendBase(args, unlistingSpu_argsHelper.getInstance());
			}
			
			
			private void recv_unlistingSpu(){
				
				unlistingSpu_result result = new unlistingSpu_result();
				ReceiveBase(result, unlistingSpu_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}