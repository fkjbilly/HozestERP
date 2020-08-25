using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.schedule{
	
	
	public class OxoVendorScheduleServiceHelper {
		
		
		
		public class getScheduleListByCooperationNo_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private long? vendorId_;
			
			///<summary>
			/// 常态合作编码
			///</summary>
			
			private long? cooperationNo_;
			
			///<summary>
			/// 仓库编码
			///</summary>
			
			private string warehouse_;
			
			public long? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(long? value){
				this.vendorId_ = value;
			}
			public long? GetCooperationNo(){
				return this.cooperationNo_;
			}
			
			public void SetCooperationNo(long? value){
				this.cooperationNo_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			
		}
		
		
		
		
		public class getSkuByScheduleIdAndBarcode_args {
			
			///<summary>
			/// 档期id
			///</summary>
			
			private long? scheduleId_;
			
			///<summary>
			/// 商品条码
			///</summary>
			
			private string barcode_;
			
			public long? GetScheduleId(){
				return this.scheduleId_;
			}
			
			public void SetScheduleId(long? value){
				this.scheduleId_ = value;
			}
			public string GetBarcode(){
				return this.barcode_;
			}
			
			public void SetBarcode(string value){
				this.barcode_ = value;
			}
			
		}
		
		
		
		
		public class getSkuInventoryPushStatus_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private long? vendorId_;
			
			///<summary>
			/// 常态合作编码
			///</summary>
			
			private long? cooperationNo_;
			
			///<summary>
			/// 仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 商品条形码
			///</summary>
			
			private string barcode_;
			
			public long? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(long? value){
				this.vendorId_ = value;
			}
			public long? GetCooperationNo(){
				return this.cooperationNo_;
			}
			
			public void SetCooperationNo(long? value){
				this.cooperationNo_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetBarcode(){
				return this.barcode_;
			}
			
			public void SetBarcode(string value){
				this.barcode_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class setSkuInventoryPushStatusImported_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private long? vendorId_;
			
			///<summary>
			/// 档期id
			///</summary>
			
			private long? scheduleId_;
			
			///<summary>
			/// 商品条形码
			///</summary>
			
			private string barcode_;
			
			public long? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(long? value){
				this.vendorId_ = value;
			}
			public long? GetScheduleId(){
				return this.scheduleId_;
			}
			
			public void SetScheduleId(long? value){
				this.scheduleId_ = value;
			}
			public string GetBarcode(){
				return this.barcode_;
			}
			
			public void SetBarcode(string value){
				this.barcode_ = value;
			}
			
		}
		
		
		
		
		public class syncVendorScheduleSkus_args {
			
			
		}
		
		
		
		
		public class syncVendorScheduleSkusToCache_args {
			
			
		}
		
		
		
		
		public class syncVendorSchedules_args {
			
			
		}
		
		
		
		
		public class getScheduleListByCooperationNo_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.schedule.VendorSchedule> success_;
			
			public List<com.vip.vop.schedule.VendorSchedule> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.vop.schedule.VendorSchedule> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSkuByScheduleIdAndBarcode_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.schedule.VendorScheduleSku success_;
			
			public com.vip.vop.schedule.VendorScheduleSku GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.schedule.VendorScheduleSku value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSkuInventoryPushStatus_result {
			
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
		
		
		
		
		public class setSkuInventoryPushStatusImported_result {
			
			
		}
		
		
		
		
		public class syncVendorScheduleSkus_result {
			
			
		}
		
		
		
		
		public class syncVendorScheduleSkusToCache_result {
			
			
		}
		
		
		
		
		public class syncVendorSchedules_result {
			
			
		}
		
		
		
		
		
		public class getScheduleListByCooperationNo_argsHelper : TBeanSerializer<getScheduleListByCooperationNo_args>
		{
			
			public static getScheduleListByCooperationNo_argsHelper OBJ = new getScheduleListByCooperationNo_argsHelper();
			
			public static getScheduleListByCooperationNo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getScheduleListByCooperationNo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetCooperationNo(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getScheduleListByCooperationNo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI64((long)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				if(structs.GetCooperationNo() != null) {
					
					oprot.WriteFieldBegin("cooperationNo");
					oprot.WriteI64((long)structs.GetCooperationNo()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("cooperationNo can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getScheduleListByCooperationNo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuByScheduleIdAndBarcode_argsHelper : TBeanSerializer<getSkuByScheduleIdAndBarcode_args>
		{
			
			public static getSkuByScheduleIdAndBarcode_argsHelper OBJ = new getSkuByScheduleIdAndBarcode_argsHelper();
			
			public static getSkuByScheduleIdAndBarcode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuByScheduleIdAndBarcode_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetScheduleId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBarcode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuByScheduleIdAndBarcode_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetScheduleId() != null) {
					
					oprot.WriteFieldBegin("scheduleId");
					oprot.WriteI64((long)structs.GetScheduleId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("scheduleId can not be null!");
				}
				
				
				if(structs.GetBarcode() != null) {
					
					oprot.WriteFieldBegin("barcode");
					oprot.WriteString(structs.GetBarcode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("barcode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuByScheduleIdAndBarcode_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuInventoryPushStatus_argsHelper : TBeanSerializer<getSkuInventoryPushStatus_args>
		{
			
			public static getSkuInventoryPushStatus_argsHelper OBJ = new getSkuInventoryPushStatus_argsHelper();
			
			public static getSkuInventoryPushStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuInventoryPushStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetCooperationNo(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBarcode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuInventoryPushStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI64((long)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				if(structs.GetCooperationNo() != null) {
					
					oprot.WriteFieldBegin("cooperationNo");
					oprot.WriteI64((long)structs.GetCooperationNo()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("cooperationNo can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetBarcode() != null) {
					
					oprot.WriteFieldBegin("barcode");
					oprot.WriteString(structs.GetBarcode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("barcode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuInventoryPushStatus_args bean){
				
				
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
		
		
		
		
		public class setSkuInventoryPushStatusImported_argsHelper : TBeanSerializer<setSkuInventoryPushStatusImported_args>
		{
			
			public static setSkuInventoryPushStatusImported_argsHelper OBJ = new setSkuInventoryPushStatusImported_argsHelper();
			
			public static setSkuInventoryPushStatusImported_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(setSkuInventoryPushStatusImported_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetScheduleId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBarcode(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(setSkuInventoryPushStatusImported_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI64((long)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				if(structs.GetScheduleId() != null) {
					
					oprot.WriteFieldBegin("scheduleId");
					oprot.WriteI64((long)structs.GetScheduleId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("scheduleId can not be null!");
				}
				
				
				if(structs.GetBarcode() != null) {
					
					oprot.WriteFieldBegin("barcode");
					oprot.WriteString(structs.GetBarcode());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("barcode can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(setSkuInventoryPushStatusImported_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncVendorScheduleSkus_argsHelper : TBeanSerializer<syncVendorScheduleSkus_args>
		{
			
			public static syncVendorScheduleSkus_argsHelper OBJ = new syncVendorScheduleSkus_argsHelper();
			
			public static syncVendorScheduleSkus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVendorScheduleSkus_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVendorScheduleSkus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVendorScheduleSkus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncVendorScheduleSkusToCache_argsHelper : TBeanSerializer<syncVendorScheduleSkusToCache_args>
		{
			
			public static syncVendorScheduleSkusToCache_argsHelper OBJ = new syncVendorScheduleSkusToCache_argsHelper();
			
			public static syncVendorScheduleSkusToCache_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVendorScheduleSkusToCache_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVendorScheduleSkusToCache_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVendorScheduleSkusToCache_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncVendorSchedules_argsHelper : TBeanSerializer<syncVendorSchedules_args>
		{
			
			public static syncVendorSchedules_argsHelper OBJ = new syncVendorSchedules_argsHelper();
			
			public static syncVendorSchedules_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVendorSchedules_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVendorSchedules_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVendorSchedules_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getScheduleListByCooperationNo_resultHelper : TBeanSerializer<getScheduleListByCooperationNo_result>
		{
			
			public static getScheduleListByCooperationNo_resultHelper OBJ = new getScheduleListByCooperationNo_resultHelper();
			
			public static getScheduleListByCooperationNo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getScheduleListByCooperationNo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.schedule.VendorSchedule> value;
					
					value = new List<com.vip.vop.schedule.VendorSchedule>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.schedule.VendorSchedule elem0;
							
							elem0 = new com.vip.vop.schedule.VendorSchedule();
							com.vip.vop.schedule.VendorScheduleHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getScheduleListByCooperationNo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.schedule.VendorSchedule _item0 in structs.GetSuccess()){
						
						
						com.vip.vop.schedule.VendorScheduleHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getScheduleListByCooperationNo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuByScheduleIdAndBarcode_resultHelper : TBeanSerializer<getSkuByScheduleIdAndBarcode_result>
		{
			
			public static getSkuByScheduleIdAndBarcode_resultHelper OBJ = new getSkuByScheduleIdAndBarcode_resultHelper();
			
			public static getSkuByScheduleIdAndBarcode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuByScheduleIdAndBarcode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.schedule.VendorScheduleSku value;
					
					value = new com.vip.vop.schedule.VendorScheduleSku();
					com.vip.vop.schedule.VendorScheduleSkuHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuByScheduleIdAndBarcode_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.schedule.VendorScheduleSkuHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuByScheduleIdAndBarcode_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuInventoryPushStatus_resultHelper : TBeanSerializer<getSkuInventoryPushStatus_result>
		{
			
			public static getSkuInventoryPushStatus_resultHelper OBJ = new getSkuInventoryPushStatus_resultHelper();
			
			public static getSkuInventoryPushStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuInventoryPushStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuInventoryPushStatus_result structs, Protocol oprot){
				
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
			
			
			public void Validate(getSkuInventoryPushStatus_result bean){
				
				
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
		
		
		
		
		public class setSkuInventoryPushStatusImported_resultHelper : TBeanSerializer<setSkuInventoryPushStatusImported_result>
		{
			
			public static setSkuInventoryPushStatusImported_resultHelper OBJ = new setSkuInventoryPushStatusImported_resultHelper();
			
			public static setSkuInventoryPushStatusImported_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(setSkuInventoryPushStatusImported_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(setSkuInventoryPushStatusImported_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(setSkuInventoryPushStatusImported_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncVendorScheduleSkus_resultHelper : TBeanSerializer<syncVendorScheduleSkus_result>
		{
			
			public static syncVendorScheduleSkus_resultHelper OBJ = new syncVendorScheduleSkus_resultHelper();
			
			public static syncVendorScheduleSkus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVendorScheduleSkus_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVendorScheduleSkus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVendorScheduleSkus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncVendorScheduleSkusToCache_resultHelper : TBeanSerializer<syncVendorScheduleSkusToCache_result>
		{
			
			public static syncVendorScheduleSkusToCache_resultHelper OBJ = new syncVendorScheduleSkusToCache_resultHelper();
			
			public static syncVendorScheduleSkusToCache_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVendorScheduleSkusToCache_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVendorScheduleSkusToCache_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVendorScheduleSkusToCache_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncVendorSchedules_resultHelper : TBeanSerializer<syncVendorSchedules_result>
		{
			
			public static syncVendorSchedules_resultHelper OBJ = new syncVendorSchedules_resultHelper();
			
			public static syncVendorSchedules_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVendorSchedules_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVendorSchedules_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVendorSchedules_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OxoVendorScheduleServiceClient : OspRestStub , OxoVendorScheduleService  {
			
			
			public OxoVendorScheduleServiceClient():base("com.vip.vop.schedule.OxoVendorScheduleService","1.0.0") {
				
				
			}
			
			
			
			public List<com.vip.vop.schedule.VendorSchedule> getScheduleListByCooperationNo(long vendorId_,long cooperationNo_,string warehouse_) {
				
				send_getScheduleListByCooperationNo(vendorId_,cooperationNo_,warehouse_);
				return recv_getScheduleListByCooperationNo(); 
				
			}
			
			
			private void send_getScheduleListByCooperationNo(long vendorId_,long cooperationNo_,string warehouse_){
				
				InitInvocation("getScheduleListByCooperationNo");
				
				getScheduleListByCooperationNo_args args = new getScheduleListByCooperationNo_args();
				args.SetVendorId(vendorId_);
				args.SetCooperationNo(cooperationNo_);
				args.SetWarehouse(warehouse_);
				
				SendBase(args, getScheduleListByCooperationNo_argsHelper.getInstance());
			}
			
			
			private List<com.vip.vop.schedule.VendorSchedule> recv_getScheduleListByCooperationNo(){
				
				getScheduleListByCooperationNo_result result = new getScheduleListByCooperationNo_result();
				ReceiveBase(result, getScheduleListByCooperationNo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.vop.schedule.VendorScheduleSku getSkuByScheduleIdAndBarcode(long scheduleId_,string barcode_) {
				
				send_getSkuByScheduleIdAndBarcode(scheduleId_,barcode_);
				return recv_getSkuByScheduleIdAndBarcode(); 
				
			}
			
			
			private void send_getSkuByScheduleIdAndBarcode(long scheduleId_,string barcode_){
				
				InitInvocation("getSkuByScheduleIdAndBarcode");
				
				getSkuByScheduleIdAndBarcode_args args = new getSkuByScheduleIdAndBarcode_args();
				args.SetScheduleId(scheduleId_);
				args.SetBarcode(barcode_);
				
				SendBase(args, getSkuByScheduleIdAndBarcode_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.schedule.VendorScheduleSku recv_getSkuByScheduleIdAndBarcode(){
				
				getSkuByScheduleIdAndBarcode_result result = new getSkuByScheduleIdAndBarcode_result();
				ReceiveBase(result, getSkuByScheduleIdAndBarcode_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? getSkuInventoryPushStatus(long vendorId_,long cooperationNo_,string warehouse_,string barcode_) {
				
				send_getSkuInventoryPushStatus(vendorId_,cooperationNo_,warehouse_,barcode_);
				return recv_getSkuInventoryPushStatus(); 
				
			}
			
			
			private void send_getSkuInventoryPushStatus(long vendorId_,long cooperationNo_,string warehouse_,string barcode_){
				
				InitInvocation("getSkuInventoryPushStatus");
				
				getSkuInventoryPushStatus_args args = new getSkuInventoryPushStatus_args();
				args.SetVendorId(vendorId_);
				args.SetCooperationNo(cooperationNo_);
				args.SetWarehouse(warehouse_);
				args.SetBarcode(barcode_);
				
				SendBase(args, getSkuInventoryPushStatus_argsHelper.getInstance());
			}
			
			
			private int? recv_getSkuInventoryPushStatus(){
				
				getSkuInventoryPushStatus_result result = new getSkuInventoryPushStatus_result();
				ReceiveBase(result, getSkuInventoryPushStatus_resultHelper.getInstance());
				
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
			
			
			public void setSkuInventoryPushStatusImported(long vendorId_,long scheduleId_,string barcode_) {
				
				send_setSkuInventoryPushStatusImported(vendorId_,scheduleId_,barcode_);
				recv_setSkuInventoryPushStatusImported();
				
			}
			
			
			private void send_setSkuInventoryPushStatusImported(long vendorId_,long scheduleId_,string barcode_){
				
				InitInvocation("setSkuInventoryPushStatusImported");
				
				setSkuInventoryPushStatusImported_args args = new setSkuInventoryPushStatusImported_args();
				args.SetVendorId(vendorId_);
				args.SetScheduleId(scheduleId_);
				args.SetBarcode(barcode_);
				
				SendBase(args, setSkuInventoryPushStatusImported_argsHelper.getInstance());
			}
			
			
			private void recv_setSkuInventoryPushStatusImported(){
				
				setSkuInventoryPushStatusImported_result result = new setSkuInventoryPushStatusImported_result();
				ReceiveBase(result, setSkuInventoryPushStatusImported_resultHelper.getInstance());
				
				
			}
			
			
			public void syncVendorScheduleSkus() {
				
				send_syncVendorScheduleSkus();
				recv_syncVendorScheduleSkus();
				
			}
			
			
			private void send_syncVendorScheduleSkus(){
				
				InitInvocation("syncVendorScheduleSkus");
				
				syncVendorScheduleSkus_args args = new syncVendorScheduleSkus_args();
				
				SendBase(args, syncVendorScheduleSkus_argsHelper.getInstance());
			}
			
			
			private void recv_syncVendorScheduleSkus(){
				
				syncVendorScheduleSkus_result result = new syncVendorScheduleSkus_result();
				ReceiveBase(result, syncVendorScheduleSkus_resultHelper.getInstance());
				
				
			}
			
			
			public void syncVendorScheduleSkusToCache() {
				
				send_syncVendorScheduleSkusToCache();
				recv_syncVendorScheduleSkusToCache();
				
			}
			
			
			private void send_syncVendorScheduleSkusToCache(){
				
				InitInvocation("syncVendorScheduleSkusToCache");
				
				syncVendorScheduleSkusToCache_args args = new syncVendorScheduleSkusToCache_args();
				
				SendBase(args, syncVendorScheduleSkusToCache_argsHelper.getInstance());
			}
			
			
			private void recv_syncVendorScheduleSkusToCache(){
				
				syncVendorScheduleSkusToCache_result result = new syncVendorScheduleSkusToCache_result();
				ReceiveBase(result, syncVendorScheduleSkusToCache_resultHelper.getInstance());
				
				
			}
			
			
			public void syncVendorSchedules() {
				
				send_syncVendorSchedules();
				recv_syncVendorSchedules();
				
			}
			
			
			private void send_syncVendorSchedules(){
				
				InitInvocation("syncVendorSchedules");
				
				syncVendorSchedules_args args = new syncVendorSchedules_args();
				
				SendBase(args, syncVendorSchedules_argsHelper.getInstance());
			}
			
			
			private void recv_syncVendorSchedules(){
				
				syncVendorSchedules_result result = new syncVendorSchedules_result();
				ReceiveBase(result, syncVendorSchedules_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}