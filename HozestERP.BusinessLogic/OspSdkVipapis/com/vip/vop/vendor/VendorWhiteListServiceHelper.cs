using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.vendor{
	
	
	public class VendorWhiteListServiceHelper {
		
		
		
		public class batchGetCooperationNoConfigInfo_args {
			
			///<summary>
			/// 页码,默认1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 条数，默认50（最大200）
			///</summary>
			
			private int? limit_;
			
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getCooperationNoConfigInfo_args {
			
			///<summary>
			/// 供应商Id
			///</summary>
			
			private int? vendorId_;
			
			///<summary>
			/// 常态合作编码
			///</summary>
			
			private int? cooperationNo_;
			
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			public int? GetCooperationNo(){
				return this.cooperationNo_;
			}
			
			public void SetCooperationNo(int? value){
				this.cooperationNo_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryUpdatePath_args {
			
			///<summary>
			/// 供应商编码
			///</summary>
			
			private string vendorCode_;
			
			///<summary>
			/// 常态合作编码
			///</summary>
			
			private int? cooperationNo_;
			
			public string GetVendorCode(){
				return this.vendorCode_;
			}
			
			public void SetVendorCode(string value){
				this.vendorCode_ = value;
			}
			public int? GetCooperationNo(){
				return this.cooperationNo_;
			}
			
			public void SetCooperationNo(int? value){
				this.cooperationNo_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class isCooperationNoInWhiteList_args {
			
			///<summary>
			/// 供应商编码
			///</summary>
			
			private string vendorCode_;
			
			///<summary>
			/// 常态合作编码
			///</summary>
			
			private int? cooperationNo_;
			
			public string GetVendorCode(){
				return this.vendorCode_;
			}
			
			public void SetVendorCode(string value){
				this.vendorCode_ = value;
			}
			public int? GetCooperationNo(){
				return this.cooperationNo_;
			}
			
			public void SetCooperationNo(int? value){
				this.cooperationNo_ = value;
			}
			
		}
		
		
		
		
		public class isScheduleInWhiteList_args {
			
			///<summary>
			/// 供应商编码
			///</summary>
			
			private string vendorCode_;
			
			///<summary>
			/// 档期id
			///</summary>
			
			private int? scheduleId_;
			
			public string GetVendorCode(){
				return this.vendorCode_;
			}
			
			public void SetVendorCode(string value){
				this.vendorCode_ = value;
			}
			public int? GetScheduleId(){
				return this.scheduleId_;
			}
			
			public void SetScheduleId(int? value){
				this.scheduleId_ = value;
			}
			
		}
		
		
		
		
		public class isVopVendorByVendorCode_args {
			
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
		
		
		
		
		public class isVopVendorByVendorId_args {
			
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
		
		
		
		
		public class batchGetCooperationNoConfigInfo_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.vendor.CooperationNoConfigInfo> success_;
			
			public List<com.vip.vop.vendor.CooperationNoConfigInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.vop.vendor.CooperationNoConfigInfo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCooperationNoConfigInfo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vendor.CooperationNoConfigInfo success_;
			
			public com.vip.vop.vendor.CooperationNoConfigInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vendor.CooperationNoConfigInfo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInventoryUpdatePath_result {
			
			///<summary>
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
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
		
		
		
		
		public class isCooperationNoInWhiteList_result {
			
			///<summary>
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class isScheduleInWhiteList_result {
			
			///<summary>
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class isVopVendorByVendorCode_result {
			
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
		
		
		
		
		public class isVopVendorByVendorId_result {
			
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
		
		
		
		
		
		public class batchGetCooperationNoConfigInfo_argsHelper : TBeanSerializer<batchGetCooperationNoConfigInfo_args>
		{
			
			public static batchGetCooperationNoConfigInfo_argsHelper OBJ = new batchGetCooperationNoConfigInfo_argsHelper();
			
			public static batchGetCooperationNoConfigInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetCooperationNoConfigInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchGetCooperationNoConfigInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetCooperationNoConfigInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCooperationNoConfigInfo_argsHelper : TBeanSerializer<getCooperationNoConfigInfo_args>
		{
			
			public static getCooperationNoConfigInfo_argsHelper OBJ = new getCooperationNoConfigInfo_argsHelper();
			
			public static getCooperationNoConfigInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCooperationNoConfigInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCooperationNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCooperationNoConfigInfo_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetCooperationNo() != null) {
					
					oprot.WriteFieldBegin("cooperationNo");
					oprot.WriteI32((int)structs.GetCooperationNo()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("cooperationNo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCooperationNoConfigInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryUpdatePath_argsHelper : TBeanSerializer<getInventoryUpdatePath_args>
		{
			
			public static getInventoryUpdatePath_argsHelper OBJ = new getInventoryUpdatePath_argsHelper();
			
			public static getInventoryUpdatePath_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryUpdatePath_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendorCode(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCooperationNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryUpdatePath_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetCooperationNo() != null) {
					
					oprot.WriteFieldBegin("cooperationNo");
					oprot.WriteI32((int)structs.GetCooperationNo()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("cooperationNo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryUpdatePath_args bean){
				
				
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
		
		
		
		
		public class isCooperationNoInWhiteList_argsHelper : TBeanSerializer<isCooperationNoInWhiteList_args>
		{
			
			public static isCooperationNoInWhiteList_argsHelper OBJ = new isCooperationNoInWhiteList_argsHelper();
			
			public static isCooperationNoInWhiteList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isCooperationNoInWhiteList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendorCode(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCooperationNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isCooperationNoInWhiteList_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetCooperationNo() != null) {
					
					oprot.WriteFieldBegin("cooperationNo");
					oprot.WriteI32((int)structs.GetCooperationNo()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("cooperationNo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(isCooperationNoInWhiteList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class isScheduleInWhiteList_argsHelper : TBeanSerializer<isScheduleInWhiteList_args>
		{
			
			public static isScheduleInWhiteList_argsHelper OBJ = new isScheduleInWhiteList_argsHelper();
			
			public static isScheduleInWhiteList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isScheduleInWhiteList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendorCode(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetScheduleId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isScheduleInWhiteList_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetScheduleId() != null) {
					
					oprot.WriteFieldBegin("scheduleId");
					oprot.WriteI32((int)structs.GetScheduleId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("scheduleId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(isScheduleInWhiteList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class isVopVendorByVendorCode_argsHelper : TBeanSerializer<isVopVendorByVendorCode_args>
		{
			
			public static isVopVendorByVendorCode_argsHelper OBJ = new isVopVendorByVendorCode_argsHelper();
			
			public static isVopVendorByVendorCode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isVopVendorByVendorCode_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendorCode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isVopVendorByVendorCode_args structs, Protocol oprot){
				
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
			
			
			public void Validate(isVopVendorByVendorCode_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class isVopVendorByVendorId_argsHelper : TBeanSerializer<isVopVendorByVendorId_args>
		{
			
			public static isVopVendorByVendorId_argsHelper OBJ = new isVopVendorByVendorId_argsHelper();
			
			public static isVopVendorByVendorId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isVopVendorByVendorId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isVopVendorByVendorId_args structs, Protocol oprot){
				
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
			
			
			public void Validate(isVopVendorByVendorId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchGetCooperationNoConfigInfo_resultHelper : TBeanSerializer<batchGetCooperationNoConfigInfo_result>
		{
			
			public static batchGetCooperationNoConfigInfo_resultHelper OBJ = new batchGetCooperationNoConfigInfo_resultHelper();
			
			public static batchGetCooperationNoConfigInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchGetCooperationNoConfigInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.vendor.CooperationNoConfigInfo> value;
					
					value = new List<com.vip.vop.vendor.CooperationNoConfigInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.vendor.CooperationNoConfigInfo elem0;
							
							elem0 = new com.vip.vop.vendor.CooperationNoConfigInfo();
							com.vip.vop.vendor.CooperationNoConfigInfoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(batchGetCooperationNoConfigInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.vendor.CooperationNoConfigInfo _item0 in structs.GetSuccess()){
						
						
						com.vip.vop.vendor.CooperationNoConfigInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchGetCooperationNoConfigInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCooperationNoConfigInfo_resultHelper : TBeanSerializer<getCooperationNoConfigInfo_result>
		{
			
			public static getCooperationNoConfigInfo_resultHelper OBJ = new getCooperationNoConfigInfo_resultHelper();
			
			public static getCooperationNoConfigInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCooperationNoConfigInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vendor.CooperationNoConfigInfo value;
					
					value = new com.vip.vop.vendor.CooperationNoConfigInfo();
					com.vip.vop.vendor.CooperationNoConfigInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCooperationNoConfigInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vendor.CooperationNoConfigInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCooperationNoConfigInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInventoryUpdatePath_resultHelper : TBeanSerializer<getInventoryUpdatePath_result>
		{
			
			public static getInventoryUpdatePath_resultHelper OBJ = new getInventoryUpdatePath_resultHelper();
			
			public static getInventoryUpdatePath_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInventoryUpdatePath_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInventoryUpdatePath_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInventoryUpdatePath_result bean){
				
				
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
		
		
		
		
		public class isCooperationNoInWhiteList_resultHelper : TBeanSerializer<isCooperationNoInWhiteList_result>
		{
			
			public static isCooperationNoInWhiteList_resultHelper OBJ = new isCooperationNoInWhiteList_resultHelper();
			
			public static isCooperationNoInWhiteList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isCooperationNoInWhiteList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isCooperationNoInWhiteList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(isCooperationNoInWhiteList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class isScheduleInWhiteList_resultHelper : TBeanSerializer<isScheduleInWhiteList_result>
		{
			
			public static isScheduleInWhiteList_resultHelper OBJ = new isScheduleInWhiteList_resultHelper();
			
			public static isScheduleInWhiteList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isScheduleInWhiteList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isScheduleInWhiteList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(isScheduleInWhiteList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class isVopVendorByVendorCode_resultHelper : TBeanSerializer<isVopVendorByVendorCode_result>
		{
			
			public static isVopVendorByVendorCode_resultHelper OBJ = new isVopVendorByVendorCode_resultHelper();
			
			public static isVopVendorByVendorCode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isVopVendorByVendorCode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isVopVendorByVendorCode_result structs, Protocol oprot){
				
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
			
			
			public void Validate(isVopVendorByVendorCode_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class isVopVendorByVendorId_resultHelper : TBeanSerializer<isVopVendorByVendorId_result>
		{
			
			public static isVopVendorByVendorId_resultHelper OBJ = new isVopVendorByVendorId_resultHelper();
			
			public static isVopVendorByVendorId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isVopVendorByVendorId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isVopVendorByVendorId_result structs, Protocol oprot){
				
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
			
			
			public void Validate(isVopVendorByVendorId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorWhiteListServiceClient : OspRestStub , VendorWhiteListService  {
			
			
			public VendorWhiteListServiceClient():base("com.vip.vop.vendor.VendorWhiteListService","1.0.0") {
				
				
			}
			
			
			
			public List<com.vip.vop.vendor.CooperationNoConfigInfo> batchGetCooperationNoConfigInfo(int? page_,int? limit_) {
				
				send_batchGetCooperationNoConfigInfo(page_,limit_);
				return recv_batchGetCooperationNoConfigInfo(); 
				
			}
			
			
			private void send_batchGetCooperationNoConfigInfo(int? page_,int? limit_){
				
				InitInvocation("batchGetCooperationNoConfigInfo");
				
				batchGetCooperationNoConfigInfo_args args = new batchGetCooperationNoConfigInfo_args();
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, batchGetCooperationNoConfigInfo_argsHelper.getInstance());
			}
			
			
			private List<com.vip.vop.vendor.CooperationNoConfigInfo> recv_batchGetCooperationNoConfigInfo(){
				
				batchGetCooperationNoConfigInfo_result result = new batchGetCooperationNoConfigInfo_result();
				ReceiveBase(result, batchGetCooperationNoConfigInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.vop.vendor.CooperationNoConfigInfo getCooperationNoConfigInfo(int vendorId_,int cooperationNo_) {
				
				send_getCooperationNoConfigInfo(vendorId_,cooperationNo_);
				return recv_getCooperationNoConfigInfo(); 
				
			}
			
			
			private void send_getCooperationNoConfigInfo(int vendorId_,int cooperationNo_){
				
				InitInvocation("getCooperationNoConfigInfo");
				
				getCooperationNoConfigInfo_args args = new getCooperationNoConfigInfo_args();
				args.SetVendorId(vendorId_);
				args.SetCooperationNo(cooperationNo_);
				
				SendBase(args, getCooperationNoConfigInfo_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vendor.CooperationNoConfigInfo recv_getCooperationNoConfigInfo(){
				
				getCooperationNoConfigInfo_result result = new getCooperationNoConfigInfo_result();
				ReceiveBase(result, getCooperationNoConfigInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? getInventoryUpdatePath(string vendorCode_,int cooperationNo_) {
				
				send_getInventoryUpdatePath(vendorCode_,cooperationNo_);
				return recv_getInventoryUpdatePath(); 
				
			}
			
			
			private void send_getInventoryUpdatePath(string vendorCode_,int cooperationNo_){
				
				InitInvocation("getInventoryUpdatePath");
				
				getInventoryUpdatePath_args args = new getInventoryUpdatePath_args();
				args.SetVendorCode(vendorCode_);
				args.SetCooperationNo(cooperationNo_);
				
				SendBase(args, getInventoryUpdatePath_argsHelper.getInstance());
			}
			
			
			private int? recv_getInventoryUpdatePath(){
				
				getInventoryUpdatePath_result result = new getInventoryUpdatePath_result();
				ReceiveBase(result, getInventoryUpdatePath_resultHelper.getInstance());
				
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
			
			
			public int? isCooperationNoInWhiteList(string vendorCode_,int cooperationNo_) {
				
				send_isCooperationNoInWhiteList(vendorCode_,cooperationNo_);
				return recv_isCooperationNoInWhiteList(); 
				
			}
			
			
			private void send_isCooperationNoInWhiteList(string vendorCode_,int cooperationNo_){
				
				InitInvocation("isCooperationNoInWhiteList");
				
				isCooperationNoInWhiteList_args args = new isCooperationNoInWhiteList_args();
				args.SetVendorCode(vendorCode_);
				args.SetCooperationNo(cooperationNo_);
				
				SendBase(args, isCooperationNoInWhiteList_argsHelper.getInstance());
			}
			
			
			private int? recv_isCooperationNoInWhiteList(){
				
				isCooperationNoInWhiteList_result result = new isCooperationNoInWhiteList_result();
				ReceiveBase(result, isCooperationNoInWhiteList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? isScheduleInWhiteList(string vendorCode_,int scheduleId_) {
				
				send_isScheduleInWhiteList(vendorCode_,scheduleId_);
				return recv_isScheduleInWhiteList(); 
				
			}
			
			
			private void send_isScheduleInWhiteList(string vendorCode_,int scheduleId_){
				
				InitInvocation("isScheduleInWhiteList");
				
				isScheduleInWhiteList_args args = new isScheduleInWhiteList_args();
				args.SetVendorCode(vendorCode_);
				args.SetScheduleId(scheduleId_);
				
				SendBase(args, isScheduleInWhiteList_argsHelper.getInstance());
			}
			
			
			private int? recv_isScheduleInWhiteList(){
				
				isScheduleInWhiteList_result result = new isScheduleInWhiteList_result();
				ReceiveBase(result, isScheduleInWhiteList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public bool? isVopVendorByVendorCode(string vendorCode_) {
				
				send_isVopVendorByVendorCode(vendorCode_);
				return recv_isVopVendorByVendorCode(); 
				
			}
			
			
			private void send_isVopVendorByVendorCode(string vendorCode_){
				
				InitInvocation("isVopVendorByVendorCode");
				
				isVopVendorByVendorCode_args args = new isVopVendorByVendorCode_args();
				args.SetVendorCode(vendorCode_);
				
				SendBase(args, isVopVendorByVendorCode_argsHelper.getInstance());
			}
			
			
			private bool? recv_isVopVendorByVendorCode(){
				
				isVopVendorByVendorCode_result result = new isVopVendorByVendorCode_result();
				ReceiveBase(result, isVopVendorByVendorCode_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public bool? isVopVendorByVendorId(int vendorId_) {
				
				send_isVopVendorByVendorId(vendorId_);
				return recv_isVopVendorByVendorId(); 
				
			}
			
			
			private void send_isVopVendorByVendorId(int vendorId_){
				
				InitInvocation("isVopVendorByVendorId");
				
				isVopVendorByVendorId_args args = new isVopVendorByVendorId_args();
				args.SetVendorId(vendorId_);
				
				SendBase(args, isVopVendorByVendorId_argsHelper.getInstance());
			}
			
			
			private bool? recv_isVopVendorByVendorId(){
				
				isVopVendorByVendorId_result result = new isVopVendorByVendorId_result();
				ReceiveBase(result, isVopVendorByVendorId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}