using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.vendor{
	
	
	public class VendorInfoServiceHelper {
		
		
		
		public class getVendorIdByVendorCode_args {
			
			///<summary>
			/// 供应商编码
			///</summary>
			
			private string vendorCode_;
			
			public string GetVendorCode(){
				return this.vendorCode_;
			}
			
			public void SetVendorCode(string value){
				this.vendorCode_ = value;
			}
			
		}
		
		
		
		
		public class getVisVendorById_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendorId_;
			
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class selectByVendorName_args {
			
			///<summary>
			/// 供应商名称
			///</summary>
			
			private string vendorName_;
			
			public string GetVendorName(){
				return this.vendorName_;
			}
			
			public void SetVendorName(string value){
				this.vendorName_ = value;
			}
			
		}
		
		
		
		
		public class selectCodeByVendorId_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendorId_;
			
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			
		}
		
		
		
		
		public class selectVendorInfoByDevId_args {
			
			///<summary>
			/// 开发者id
			///</summary>
			
			private int? devId_;
			
			public int? GetDevId(){
				return this.devId_;
			}
			
			public void SetDevId(int? value){
				this.devId_ = value;
			}
			
		}
		
		
		
		
		public class getVendorIdByVendorCode_result {
			
			///<summary>
			///</summary>
			
			private long? success_;
			
			public long? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(long? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getVisVendorById_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vendor.VisVendorInfo success_;
			
			public com.vip.vop.vendor.VisVendorInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vendor.VisVendorInfo value){
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
		
		
		
		
		public class selectByVendorName_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.vendor.VendorInfo> success_;
			
			public List<com.vip.vop.vendor.VendorInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.vop.vendor.VendorInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class selectCodeByVendorId_result {
			
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
		
		
		
		
		public class selectVendorInfoByDevId_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vendor.VendorInfo success_;
			
			public com.vip.vop.vendor.VendorInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vendor.VendorInfo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getVendorIdByVendorCode_argsHelper : TBeanSerializer<getVendorIdByVendorCode_args>
		{
			
			public static getVendorIdByVendorCode_argsHelper OBJ = new getVendorIdByVendorCode_argsHelper();
			
			public static getVendorIdByVendorCode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVendorIdByVendorCode_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendorCode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getVendorIdByVendorCode_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorCode() != null) {
					
					oprot.WriteFieldBegin("vendorCode");
					oprot.WriteString(structs.GetVendorCode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorCode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVendorIdByVendorCode_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVisVendorById_argsHelper : TBeanSerializer<getVisVendorById_args>
		{
			
			public static getVisVendorById_argsHelper OBJ = new getVisVendorById_argsHelper();
			
			public static getVisVendorById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVisVendorById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getVisVendorById_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVisVendorById_args bean){
				
				
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
		
		
		
		
		public class selectByVendorName_argsHelper : TBeanSerializer<selectByVendorName_args>
		{
			
			public static selectByVendorName_argsHelper OBJ = new selectByVendorName_argsHelper();
			
			public static selectByVendorName_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByVendorName_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendorName(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectByVendorName_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorName() != null) {
					
					oprot.WriteFieldBegin("vendorName");
					oprot.WriteString(structs.GetVendorName());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorName can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByVendorName_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectCodeByVendorId_argsHelper : TBeanSerializer<selectCodeByVendorId_args>
		{
			
			public static selectCodeByVendorId_argsHelper OBJ = new selectCodeByVendorId_argsHelper();
			
			public static selectCodeByVendorId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectCodeByVendorId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectCodeByVendorId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectCodeByVendorId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectVendorInfoByDevId_argsHelper : TBeanSerializer<selectVendorInfoByDevId_args>
		{
			
			public static selectVendorInfoByDevId_argsHelper OBJ = new selectVendorInfoByDevId_argsHelper();
			
			public static selectVendorInfoByDevId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectVendorInfoByDevId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetDevId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectVendorInfoByDevId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetDevId() != null) {
					
					oprot.WriteFieldBegin("devId");
					oprot.WriteI32((int)structs.GetDevId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("devId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectVendorInfoByDevId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVendorIdByVendorCode_resultHelper : TBeanSerializer<getVendorIdByVendorCode_result>
		{
			
			public static getVendorIdByVendorCode_resultHelper OBJ = new getVendorIdByVendorCode_resultHelper();
			
			public static getVendorIdByVendorCode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVendorIdByVendorCode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getVendorIdByVendorCode_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI64((long)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVendorIdByVendorCode_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVisVendorById_resultHelper : TBeanSerializer<getVisVendorById_result>
		{
			
			public static getVisVendorById_resultHelper OBJ = new getVisVendorById_resultHelper();
			
			public static getVisVendorById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVisVendorById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vendor.VisVendorInfo value;
					
					value = new com.vip.vop.vendor.VisVendorInfo();
					com.vip.vop.vendor.VisVendorInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getVisVendorById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vendor.VisVendorInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVisVendorById_result bean){
				
				
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
		
		
		
		
		public class selectByVendorName_resultHelper : TBeanSerializer<selectByVendorName_result>
		{
			
			public static selectByVendorName_resultHelper OBJ = new selectByVendorName_resultHelper();
			
			public static selectByVendorName_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByVendorName_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.vendor.VendorInfo> value;
					
					value = new List<com.vip.vop.vendor.VendorInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.vendor.VendorInfo elem0;
							
							elem0 = new com.vip.vop.vendor.VendorInfo();
							com.vip.vop.vendor.VendorInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(selectByVendorName_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.vendor.VendorInfo _item0 in structs.GetSuccess()){
						
						
						com.vip.vop.vendor.VendorInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByVendorName_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectCodeByVendorId_resultHelper : TBeanSerializer<selectCodeByVendorId_result>
		{
			
			public static selectCodeByVendorId_resultHelper OBJ = new selectCodeByVendorId_resultHelper();
			
			public static selectCodeByVendorId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectCodeByVendorId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectCodeByVendorId_result structs, Protocol oprot){
				
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
			
			
			public void Validate(selectCodeByVendorId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectVendorInfoByDevId_resultHelper : TBeanSerializer<selectVendorInfoByDevId_result>
		{
			
			public static selectVendorInfoByDevId_resultHelper OBJ = new selectVendorInfoByDevId_resultHelper();
			
			public static selectVendorInfoByDevId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectVendorInfoByDevId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vendor.VendorInfo value;
					
					value = new com.vip.vop.vendor.VendorInfo();
					com.vip.vop.vendor.VendorInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectVendorInfoByDevId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vendor.VendorInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectVendorInfoByDevId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorInfoServiceClient : OspRestStub , VendorInfoService  {
			
			
			public VendorInfoServiceClient():base("com.vip.vop.vendor.VendorInfoService","1.0.0") {
				
				
			}
			
			
			
			public long? getVendorIdByVendorCode(string vendorCode_) {
				
				send_getVendorIdByVendorCode(vendorCode_);
				return recv_getVendorIdByVendorCode(); 
				
			}
			
			
			private void send_getVendorIdByVendorCode(string vendorCode_){
				
				InitInvocation("getVendorIdByVendorCode");
				
				getVendorIdByVendorCode_args args = new getVendorIdByVendorCode_args();
				args.SetVendorCode(vendorCode_);
				
				SendBase(args, getVendorIdByVendorCode_argsHelper.getInstance());
			}
			
			
			private long? recv_getVendorIdByVendorCode(){
				
				getVendorIdByVendorCode_result result = new getVendorIdByVendorCode_result();
				ReceiveBase(result, getVendorIdByVendorCode_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.vop.vendor.VisVendorInfo getVisVendorById(int vendorId_) {
				
				send_getVisVendorById(vendorId_);
				return recv_getVisVendorById(); 
				
			}
			
			
			private void send_getVisVendorById(int vendorId_){
				
				InitInvocation("getVisVendorById");
				
				getVisVendorById_args args = new getVisVendorById_args();
				args.SetVendorId(vendorId_);
				
				SendBase(args, getVisVendorById_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vendor.VisVendorInfo recv_getVisVendorById(){
				
				getVisVendorById_result result = new getVisVendorById_result();
				ReceiveBase(result, getVisVendorById_resultHelper.getInstance());
				
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
			
			
			public List<com.vip.vop.vendor.VendorInfo> selectByVendorName(string vendorName_) {
				
				send_selectByVendorName(vendorName_);
				return recv_selectByVendorName(); 
				
			}
			
			
			private void send_selectByVendorName(string vendorName_){
				
				InitInvocation("selectByVendorName");
				
				selectByVendorName_args args = new selectByVendorName_args();
				args.SetVendorName(vendorName_);
				
				SendBase(args, selectByVendorName_argsHelper.getInstance());
			}
			
			
			private List<com.vip.vop.vendor.VendorInfo> recv_selectByVendorName(){
				
				selectByVendorName_result result = new selectByVendorName_result();
				ReceiveBase(result, selectByVendorName_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string selectCodeByVendorId(int vendorId_) {
				
				send_selectCodeByVendorId(vendorId_);
				return recv_selectCodeByVendorId(); 
				
			}
			
			
			private void send_selectCodeByVendorId(int vendorId_){
				
				InitInvocation("selectCodeByVendorId");
				
				selectCodeByVendorId_args args = new selectCodeByVendorId_args();
				args.SetVendorId(vendorId_);
				
				SendBase(args, selectCodeByVendorId_argsHelper.getInstance());
			}
			
			
			private string recv_selectCodeByVendorId(){
				
				selectCodeByVendorId_result result = new selectCodeByVendorId_result();
				ReceiveBase(result, selectCodeByVendorId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.vop.vendor.VendorInfo selectVendorInfoByDevId(int devId_) {
				
				send_selectVendorInfoByDevId(devId_);
				return recv_selectVendorInfoByDevId(); 
				
			}
			
			
			private void send_selectVendorInfoByDevId(int devId_){
				
				InitInvocation("selectVendorInfoByDevId");
				
				selectVendorInfoByDevId_args args = new selectVendorInfoByDevId_args();
				args.SetDevId(devId_);
				
				SendBase(args, selectVendorInfoByDevId_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vendor.VendorInfo recv_selectVendorInfoByDevId(){
				
				selectVendorInfoByDevId_result result = new selectVendorInfoByDevId_result();
				ReceiveBase(result, selectVendorInfoByDevId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}