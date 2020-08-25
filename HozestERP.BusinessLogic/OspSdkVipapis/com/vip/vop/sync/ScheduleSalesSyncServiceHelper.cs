using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.sync{
	
	
	public class ScheduleSalesSyncServiceHelper {
		
		
		
		public class handleSellingJitSchedules_args {
			
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class releaseSalesStock_args {
			
			
		}
		
		
		
		
		public class syncInventoryTask_args {
			
			
		}
		
		
		
		
		public class syncLockSkusToCache_args {
			
			
		}
		
		
		
		
		public class syncMasterSalesSkus_args {
			
			
		}
		
		
		
		
		public class syncMasterSalesSkusBySharding_args {
			
			///<summary>
			/// 分片总数
			///</summary>
			
			private int? shardingTotalCount_;
			
			///<summary>
			/// 分片ID
			///</summary>
			
			private int? shardItem_;
			
			public int? GetShardingTotalCount(){
				return this.shardingTotalCount_;
			}
			
			public void SetShardingTotalCount(int? value){
				this.shardingTotalCount_ = value;
			}
			public int? GetShardItem(){
				return this.shardItem_;
			}
			
			public void SetShardItem(int? value){
				this.shardItem_ = value;
			}
			
		}
		
		
		
		
		public class syncSalesToRedis_args {
			
			
		}
		
		
		
		
		public class syncScheduleSalesToRedis_args {
			
			
		}
		
		
		
		
		public class syncScheduleSkuByVendorId_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private long? vendorId_;
			
			public long? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(long? value){
				this.vendorId_ = value;
			}
			
		}
		
		
		
		
		public class syncScheduleSkusToRedis_args {
			
			
		}
		
		
		
		
		public class syncSkuByVendorIdAndScheduleId_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendorId_;
			
			///<summary>
			/// 档期id
			///</summary>
			
			private int? scheduleId_;
			
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			public int? GetScheduleId(){
				return this.scheduleId_;
			}
			
			public void SetScheduleId(int? value){
				this.scheduleId_ = value;
			}
			
		}
		
		
		
		
		public class syncSpecialSales_args {
			
			
		}
		
		
		
		
		public class syncSpecialSalesSku_args {
			
			
		}
		
		
		
		
		public class syncVendorSchedule_args {
			
			
		}
		
		
		
		
		public class handleSellingJitSchedules_result {
			
			
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
		
		
		
		
		public class releaseSalesStock_result {
			
			
		}
		
		
		
		
		public class syncInventoryTask_result {
			
			
		}
		
		
		
		
		public class syncLockSkusToCache_result {
			
			
		}
		
		
		
		
		public class syncMasterSalesSkus_result {
			
			
		}
		
		
		
		
		public class syncMasterSalesSkusBySharding_result {
			
			
		}
		
		
		
		
		public class syncSalesToRedis_result {
			
			
		}
		
		
		
		
		public class syncScheduleSalesToRedis_result {
			
			
		}
		
		
		
		
		public class syncScheduleSkuByVendorId_result {
			
			
		}
		
		
		
		
		public class syncScheduleSkusToRedis_result {
			
			
		}
		
		
		
		
		public class syncSkuByVendorIdAndScheduleId_result {
			
			
		}
		
		
		
		
		public class syncSpecialSales_result {
			
			
		}
		
		
		
		
		public class syncSpecialSalesSku_result {
			
			
		}
		
		
		
		
		public class syncVendorSchedule_result {
			
			
		}
		
		
		
		
		
		public class handleSellingJitSchedules_argsHelper : TBeanSerializer<handleSellingJitSchedules_args>
		{
			
			public static handleSellingJitSchedules_argsHelper OBJ = new handleSellingJitSchedules_argsHelper();
			
			public static handleSellingJitSchedules_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(handleSellingJitSchedules_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(handleSellingJitSchedules_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(handleSellingJitSchedules_args bean){
				
				
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
		
		
		
		
		public class releaseSalesStock_argsHelper : TBeanSerializer<releaseSalesStock_args>
		{
			
			public static releaseSalesStock_argsHelper OBJ = new releaseSalesStock_argsHelper();
			
			public static releaseSalesStock_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(releaseSalesStock_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(releaseSalesStock_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(releaseSalesStock_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncInventoryTask_argsHelper : TBeanSerializer<syncInventoryTask_args>
		{
			
			public static syncInventoryTask_argsHelper OBJ = new syncInventoryTask_argsHelper();
			
			public static syncInventoryTask_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncInventoryTask_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncInventoryTask_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncInventoryTask_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncLockSkusToCache_argsHelper : TBeanSerializer<syncLockSkusToCache_args>
		{
			
			public static syncLockSkusToCache_argsHelper OBJ = new syncLockSkusToCache_argsHelper();
			
			public static syncLockSkusToCache_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncLockSkusToCache_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncLockSkusToCache_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncLockSkusToCache_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncMasterSalesSkus_argsHelper : TBeanSerializer<syncMasterSalesSkus_args>
		{
			
			public static syncMasterSalesSkus_argsHelper OBJ = new syncMasterSalesSkus_argsHelper();
			
			public static syncMasterSalesSkus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncMasterSalesSkus_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncMasterSalesSkus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncMasterSalesSkus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncMasterSalesSkusBySharding_argsHelper : TBeanSerializer<syncMasterSalesSkusBySharding_args>
		{
			
			public static syncMasterSalesSkusBySharding_argsHelper OBJ = new syncMasterSalesSkusBySharding_argsHelper();
			
			public static syncMasterSalesSkusBySharding_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncMasterSalesSkusBySharding_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetShardingTotalCount(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetShardItem(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncMasterSalesSkusBySharding_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetShardingTotalCount() != null) {
					
					oprot.WriteFieldBegin("shardingTotalCount");
					oprot.WriteI32((int)structs.GetShardingTotalCount()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("shardingTotalCount can not be null!");
				}
				
				
				if(structs.GetShardItem() != null) {
					
					oprot.WriteFieldBegin("shardItem");
					oprot.WriteI32((int)structs.GetShardItem()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncMasterSalesSkusBySharding_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncSalesToRedis_argsHelper : TBeanSerializer<syncSalesToRedis_args>
		{
			
			public static syncSalesToRedis_argsHelper OBJ = new syncSalesToRedis_argsHelper();
			
			public static syncSalesToRedis_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncSalesToRedis_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncSalesToRedis_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncSalesToRedis_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncScheduleSalesToRedis_argsHelper : TBeanSerializer<syncScheduleSalesToRedis_args>
		{
			
			public static syncScheduleSalesToRedis_argsHelper OBJ = new syncScheduleSalesToRedis_argsHelper();
			
			public static syncScheduleSalesToRedis_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncScheduleSalesToRedis_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncScheduleSalesToRedis_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncScheduleSalesToRedis_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncScheduleSkuByVendorId_argsHelper : TBeanSerializer<syncScheduleSkuByVendorId_args>
		{
			
			public static syncScheduleSkuByVendorId_argsHelper OBJ = new syncScheduleSkuByVendorId_argsHelper();
			
			public static syncScheduleSkuByVendorId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncScheduleSkuByVendorId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncScheduleSkuByVendorId_args structs, Protocol oprot){
				
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
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncScheduleSkuByVendorId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncScheduleSkusToRedis_argsHelper : TBeanSerializer<syncScheduleSkusToRedis_args>
		{
			
			public static syncScheduleSkusToRedis_argsHelper OBJ = new syncScheduleSkusToRedis_argsHelper();
			
			public static syncScheduleSkusToRedis_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncScheduleSkusToRedis_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncScheduleSkusToRedis_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncScheduleSkusToRedis_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncSkuByVendorIdAndScheduleId_argsHelper : TBeanSerializer<syncSkuByVendorIdAndScheduleId_args>
		{
			
			public static syncSkuByVendorIdAndScheduleId_argsHelper OBJ = new syncSkuByVendorIdAndScheduleId_argsHelper();
			
			public static syncSkuByVendorIdAndScheduleId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncSkuByVendorIdAndScheduleId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetScheduleId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncSkuByVendorIdAndScheduleId_args structs, Protocol oprot){
				
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
			
			
			public void Validate(syncSkuByVendorIdAndScheduleId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncSpecialSales_argsHelper : TBeanSerializer<syncSpecialSales_args>
		{
			
			public static syncSpecialSales_argsHelper OBJ = new syncSpecialSales_argsHelper();
			
			public static syncSpecialSales_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncSpecialSales_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncSpecialSales_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncSpecialSales_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncSpecialSalesSku_argsHelper : TBeanSerializer<syncSpecialSalesSku_args>
		{
			
			public static syncSpecialSalesSku_argsHelper OBJ = new syncSpecialSalesSku_argsHelper();
			
			public static syncSpecialSalesSku_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncSpecialSalesSku_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncSpecialSalesSku_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncSpecialSalesSku_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncVendorSchedule_argsHelper : TBeanSerializer<syncVendorSchedule_args>
		{
			
			public static syncVendorSchedule_argsHelper OBJ = new syncVendorSchedule_argsHelper();
			
			public static syncVendorSchedule_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVendorSchedule_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVendorSchedule_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVendorSchedule_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class handleSellingJitSchedules_resultHelper : TBeanSerializer<handleSellingJitSchedules_result>
		{
			
			public static handleSellingJitSchedules_resultHelper OBJ = new handleSellingJitSchedules_resultHelper();
			
			public static handleSellingJitSchedules_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(handleSellingJitSchedules_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(handleSellingJitSchedules_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(handleSellingJitSchedules_result bean){
				
				
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
		
		
		
		
		public class releaseSalesStock_resultHelper : TBeanSerializer<releaseSalesStock_result>
		{
			
			public static releaseSalesStock_resultHelper OBJ = new releaseSalesStock_resultHelper();
			
			public static releaseSalesStock_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(releaseSalesStock_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(releaseSalesStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(releaseSalesStock_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncInventoryTask_resultHelper : TBeanSerializer<syncInventoryTask_result>
		{
			
			public static syncInventoryTask_resultHelper OBJ = new syncInventoryTask_resultHelper();
			
			public static syncInventoryTask_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncInventoryTask_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncInventoryTask_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncInventoryTask_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncLockSkusToCache_resultHelper : TBeanSerializer<syncLockSkusToCache_result>
		{
			
			public static syncLockSkusToCache_resultHelper OBJ = new syncLockSkusToCache_resultHelper();
			
			public static syncLockSkusToCache_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncLockSkusToCache_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncLockSkusToCache_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncLockSkusToCache_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncMasterSalesSkus_resultHelper : TBeanSerializer<syncMasterSalesSkus_result>
		{
			
			public static syncMasterSalesSkus_resultHelper OBJ = new syncMasterSalesSkus_resultHelper();
			
			public static syncMasterSalesSkus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncMasterSalesSkus_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncMasterSalesSkus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncMasterSalesSkus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncMasterSalesSkusBySharding_resultHelper : TBeanSerializer<syncMasterSalesSkusBySharding_result>
		{
			
			public static syncMasterSalesSkusBySharding_resultHelper OBJ = new syncMasterSalesSkusBySharding_resultHelper();
			
			public static syncMasterSalesSkusBySharding_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncMasterSalesSkusBySharding_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncMasterSalesSkusBySharding_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncMasterSalesSkusBySharding_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncSalesToRedis_resultHelper : TBeanSerializer<syncSalesToRedis_result>
		{
			
			public static syncSalesToRedis_resultHelper OBJ = new syncSalesToRedis_resultHelper();
			
			public static syncSalesToRedis_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncSalesToRedis_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncSalesToRedis_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncSalesToRedis_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncScheduleSalesToRedis_resultHelper : TBeanSerializer<syncScheduleSalesToRedis_result>
		{
			
			public static syncScheduleSalesToRedis_resultHelper OBJ = new syncScheduleSalesToRedis_resultHelper();
			
			public static syncScheduleSalesToRedis_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncScheduleSalesToRedis_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncScheduleSalesToRedis_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncScheduleSalesToRedis_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncScheduleSkuByVendorId_resultHelper : TBeanSerializer<syncScheduleSkuByVendorId_result>
		{
			
			public static syncScheduleSkuByVendorId_resultHelper OBJ = new syncScheduleSkuByVendorId_resultHelper();
			
			public static syncScheduleSkuByVendorId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncScheduleSkuByVendorId_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncScheduleSkuByVendorId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncScheduleSkuByVendorId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncScheduleSkusToRedis_resultHelper : TBeanSerializer<syncScheduleSkusToRedis_result>
		{
			
			public static syncScheduleSkusToRedis_resultHelper OBJ = new syncScheduleSkusToRedis_resultHelper();
			
			public static syncScheduleSkusToRedis_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncScheduleSkusToRedis_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncScheduleSkusToRedis_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncScheduleSkusToRedis_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncSkuByVendorIdAndScheduleId_resultHelper : TBeanSerializer<syncSkuByVendorIdAndScheduleId_result>
		{
			
			public static syncSkuByVendorIdAndScheduleId_resultHelper OBJ = new syncSkuByVendorIdAndScheduleId_resultHelper();
			
			public static syncSkuByVendorIdAndScheduleId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncSkuByVendorIdAndScheduleId_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncSkuByVendorIdAndScheduleId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncSkuByVendorIdAndScheduleId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncSpecialSales_resultHelper : TBeanSerializer<syncSpecialSales_result>
		{
			
			public static syncSpecialSales_resultHelper OBJ = new syncSpecialSales_resultHelper();
			
			public static syncSpecialSales_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncSpecialSales_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncSpecialSales_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncSpecialSales_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncSpecialSalesSku_resultHelper : TBeanSerializer<syncSpecialSalesSku_result>
		{
			
			public static syncSpecialSalesSku_resultHelper OBJ = new syncSpecialSalesSku_resultHelper();
			
			public static syncSpecialSalesSku_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncSpecialSalesSku_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncSpecialSalesSku_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncSpecialSalesSku_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncVendorSchedule_resultHelper : TBeanSerializer<syncVendorSchedule_result>
		{
			
			public static syncVendorSchedule_resultHelper OBJ = new syncVendorSchedule_resultHelper();
			
			public static syncVendorSchedule_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncVendorSchedule_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncVendorSchedule_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncVendorSchedule_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class ScheduleSalesSyncServiceClient : OspRestStub , ScheduleSalesSyncService  {
			
			
			public ScheduleSalesSyncServiceClient():base("com.vip.vop.sync.ScheduleSalesSyncService","1.0.0") {
				
				
			}
			
			
			
			public void handleSellingJitSchedules() {
				
				send_handleSellingJitSchedules();
				recv_handleSellingJitSchedules();
				
			}
			
			
			private void send_handleSellingJitSchedules(){
				
				InitInvocation("handleSellingJitSchedules");
				
				handleSellingJitSchedules_args args = new handleSellingJitSchedules_args();
				
				SendBase(args, handleSellingJitSchedules_argsHelper.getInstance());
			}
			
			
			private void recv_handleSellingJitSchedules(){
				
				handleSellingJitSchedules_result result = new handleSellingJitSchedules_result();
				ReceiveBase(result, handleSellingJitSchedules_resultHelper.getInstance());
				
				
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
			
			
			public void releaseSalesStock() {
				
				send_releaseSalesStock();
				recv_releaseSalesStock();
				
			}
			
			
			private void send_releaseSalesStock(){
				
				InitInvocation("releaseSalesStock");
				
				releaseSalesStock_args args = new releaseSalesStock_args();
				
				SendBase(args, releaseSalesStock_argsHelper.getInstance());
			}
			
			
			private void recv_releaseSalesStock(){
				
				releaseSalesStock_result result = new releaseSalesStock_result();
				ReceiveBase(result, releaseSalesStock_resultHelper.getInstance());
				
				
			}
			
			
			public void syncInventoryTask() {
				
				send_syncInventoryTask();
				recv_syncInventoryTask();
				
			}
			
			
			private void send_syncInventoryTask(){
				
				InitInvocation("syncInventoryTask");
				
				syncInventoryTask_args args = new syncInventoryTask_args();
				
				SendBase(args, syncInventoryTask_argsHelper.getInstance());
			}
			
			
			private void recv_syncInventoryTask(){
				
				syncInventoryTask_result result = new syncInventoryTask_result();
				ReceiveBase(result, syncInventoryTask_resultHelper.getInstance());
				
				
			}
			
			
			public void syncLockSkusToCache() {
				
				send_syncLockSkusToCache();
				recv_syncLockSkusToCache();
				
			}
			
			
			private void send_syncLockSkusToCache(){
				
				InitInvocation("syncLockSkusToCache");
				
				syncLockSkusToCache_args args = new syncLockSkusToCache_args();
				
				SendBase(args, syncLockSkusToCache_argsHelper.getInstance());
			}
			
			
			private void recv_syncLockSkusToCache(){
				
				syncLockSkusToCache_result result = new syncLockSkusToCache_result();
				ReceiveBase(result, syncLockSkusToCache_resultHelper.getInstance());
				
				
			}
			
			
			public void syncMasterSalesSkus() {
				
				send_syncMasterSalesSkus();
				recv_syncMasterSalesSkus();
				
			}
			
			
			private void send_syncMasterSalesSkus(){
				
				InitInvocation("syncMasterSalesSkus");
				
				syncMasterSalesSkus_args args = new syncMasterSalesSkus_args();
				
				SendBase(args, syncMasterSalesSkus_argsHelper.getInstance());
			}
			
			
			private void recv_syncMasterSalesSkus(){
				
				syncMasterSalesSkus_result result = new syncMasterSalesSkus_result();
				ReceiveBase(result, syncMasterSalesSkus_resultHelper.getInstance());
				
				
			}
			
			
			public void syncMasterSalesSkusBySharding(int shardingTotalCount_,int? shardItem_) {
				
				send_syncMasterSalesSkusBySharding(shardingTotalCount_,shardItem_);
				recv_syncMasterSalesSkusBySharding();
				
			}
			
			
			private void send_syncMasterSalesSkusBySharding(int shardingTotalCount_,int? shardItem_){
				
				InitInvocation("syncMasterSalesSkusBySharding");
				
				syncMasterSalesSkusBySharding_args args = new syncMasterSalesSkusBySharding_args();
				args.SetShardingTotalCount(shardingTotalCount_);
				args.SetShardItem(shardItem_);
				
				SendBase(args, syncMasterSalesSkusBySharding_argsHelper.getInstance());
			}
			
			
			private void recv_syncMasterSalesSkusBySharding(){
				
				syncMasterSalesSkusBySharding_result result = new syncMasterSalesSkusBySharding_result();
				ReceiveBase(result, syncMasterSalesSkusBySharding_resultHelper.getInstance());
				
				
			}
			
			
			public void syncSalesToRedis() {
				
				send_syncSalesToRedis();
				recv_syncSalesToRedis();
				
			}
			
			
			private void send_syncSalesToRedis(){
				
				InitInvocation("syncSalesToRedis");
				
				syncSalesToRedis_args args = new syncSalesToRedis_args();
				
				SendBase(args, syncSalesToRedis_argsHelper.getInstance());
			}
			
			
			private void recv_syncSalesToRedis(){
				
				syncSalesToRedis_result result = new syncSalesToRedis_result();
				ReceiveBase(result, syncSalesToRedis_resultHelper.getInstance());
				
				
			}
			
			
			public void syncScheduleSalesToRedis() {
				
				send_syncScheduleSalesToRedis();
				recv_syncScheduleSalesToRedis();
				
			}
			
			
			private void send_syncScheduleSalesToRedis(){
				
				InitInvocation("syncScheduleSalesToRedis");
				
				syncScheduleSalesToRedis_args args = new syncScheduleSalesToRedis_args();
				
				SendBase(args, syncScheduleSalesToRedis_argsHelper.getInstance());
			}
			
			
			private void recv_syncScheduleSalesToRedis(){
				
				syncScheduleSalesToRedis_result result = new syncScheduleSalesToRedis_result();
				ReceiveBase(result, syncScheduleSalesToRedis_resultHelper.getInstance());
				
				
			}
			
			
			public void syncScheduleSkuByVendorId(long vendorId_) {
				
				send_syncScheduleSkuByVendorId(vendorId_);
				recv_syncScheduleSkuByVendorId();
				
			}
			
			
			private void send_syncScheduleSkuByVendorId(long vendorId_){
				
				InitInvocation("syncScheduleSkuByVendorId");
				
				syncScheduleSkuByVendorId_args args = new syncScheduleSkuByVendorId_args();
				args.SetVendorId(vendorId_);
				
				SendBase(args, syncScheduleSkuByVendorId_argsHelper.getInstance());
			}
			
			
			private void recv_syncScheduleSkuByVendorId(){
				
				syncScheduleSkuByVendorId_result result = new syncScheduleSkuByVendorId_result();
				ReceiveBase(result, syncScheduleSkuByVendorId_resultHelper.getInstance());
				
				
			}
			
			
			public void syncScheduleSkusToRedis() {
				
				send_syncScheduleSkusToRedis();
				recv_syncScheduleSkusToRedis();
				
			}
			
			
			private void send_syncScheduleSkusToRedis(){
				
				InitInvocation("syncScheduleSkusToRedis");
				
				syncScheduleSkusToRedis_args args = new syncScheduleSkusToRedis_args();
				
				SendBase(args, syncScheduleSkusToRedis_argsHelper.getInstance());
			}
			
			
			private void recv_syncScheduleSkusToRedis(){
				
				syncScheduleSkusToRedis_result result = new syncScheduleSkusToRedis_result();
				ReceiveBase(result, syncScheduleSkusToRedis_resultHelper.getInstance());
				
				
			}
			
			
			public void syncSkuByVendorIdAndScheduleId(int vendorId_,int scheduleId_) {
				
				send_syncSkuByVendorIdAndScheduleId(vendorId_,scheduleId_);
				recv_syncSkuByVendorIdAndScheduleId();
				
			}
			
			
			private void send_syncSkuByVendorIdAndScheduleId(int vendorId_,int scheduleId_){
				
				InitInvocation("syncSkuByVendorIdAndScheduleId");
				
				syncSkuByVendorIdAndScheduleId_args args = new syncSkuByVendorIdAndScheduleId_args();
				args.SetVendorId(vendorId_);
				args.SetScheduleId(scheduleId_);
				
				SendBase(args, syncSkuByVendorIdAndScheduleId_argsHelper.getInstance());
			}
			
			
			private void recv_syncSkuByVendorIdAndScheduleId(){
				
				syncSkuByVendorIdAndScheduleId_result result = new syncSkuByVendorIdAndScheduleId_result();
				ReceiveBase(result, syncSkuByVendorIdAndScheduleId_resultHelper.getInstance());
				
				
			}
			
			
			public void syncSpecialSales() {
				
				send_syncSpecialSales();
				recv_syncSpecialSales();
				
			}
			
			
			private void send_syncSpecialSales(){
				
				InitInvocation("syncSpecialSales");
				
				syncSpecialSales_args args = new syncSpecialSales_args();
				
				SendBase(args, syncSpecialSales_argsHelper.getInstance());
			}
			
			
			private void recv_syncSpecialSales(){
				
				syncSpecialSales_result result = new syncSpecialSales_result();
				ReceiveBase(result, syncSpecialSales_resultHelper.getInstance());
				
				
			}
			
			
			public void syncSpecialSalesSku() {
				
				send_syncSpecialSalesSku();
				recv_syncSpecialSalesSku();
				
			}
			
			
			private void send_syncSpecialSalesSku(){
				
				InitInvocation("syncSpecialSalesSku");
				
				syncSpecialSalesSku_args args = new syncSpecialSalesSku_args();
				
				SendBase(args, syncSpecialSalesSku_argsHelper.getInstance());
			}
			
			
			private void recv_syncSpecialSalesSku(){
				
				syncSpecialSalesSku_result result = new syncSpecialSalesSku_result();
				ReceiveBase(result, syncSpecialSalesSku_resultHelper.getInstance());
				
				
			}
			
			
			public void syncVendorSchedule() {
				
				send_syncVendorSchedule();
				recv_syncVendorSchedule();
				
			}
			
			
			private void send_syncVendorSchedule(){
				
				InitInvocation("syncVendorSchedule");
				
				syncVendorSchedule_args args = new syncVendorSchedule_args();
				
				SendBase(args, syncVendorSchedule_argsHelper.getInstance());
			}
			
			
			private void recv_syncVendorSchedule(){
				
				syncVendorSchedule_result result = new syncVendorSchedule_result();
				ReceiveBase(result, syncVendorSchedule_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}