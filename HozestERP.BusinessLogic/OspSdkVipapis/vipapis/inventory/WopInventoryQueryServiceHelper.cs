using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.inventory{
	
	
	public class WopInventoryQueryServiceHelper {
		
		
		
		public class getChannelInventory_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 页码
			/// @sampleValue page_index page_index=1
			///</summary>
			
			private int? page_index_;
			
			///<summary>
			/// 每页记录数
			/// @sampleValue page_count page_count=20
			///</summary>
			
			private int? page_count_;
			
			///<summary>
			/// 渠道库存查询条件
			/// @sampleValue queryCondition ChannelInventoryQueryCondition
			///</summary>
			
			private com.vip.domain.inventory.ChannelInventoryQueryCondition queryCondition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public int? GetPage_index(){
				return this.page_index_;
			}
			
			public void SetPage_index(int? value){
				this.page_index_ = value;
			}
			public int? GetPage_count(){
				return this.page_count_;
			}
			
			public void SetPage_count(int? value){
				this.page_count_ = value;
			}
			public com.vip.domain.inventory.ChannelInventoryQueryCondition GetQueryCondition(){
				return this.queryCondition_;
			}
			
			public void SetQueryCondition(com.vip.domain.inventory.ChannelInventoryQueryCondition value){
				this.queryCondition_ = value;
			}
			
		}
		
		
		
		
		public class getInbound_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 页码
			/// @sampleValue page_index page_index=1
			///</summary>
			
			private int? page_index_;
			
			///<summary>
			/// 每页记录数
			/// @sampleValue page_count page_count=20
			///</summary>
			
			private int? page_count_;
			
			///<summary>
			/// 入库可视化查询条件
			///</summary>
			
			private com.vip.domain.inventory.InboundCondition queryCondition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public int? GetPage_index(){
				return this.page_index_;
			}
			
			public void SetPage_index(int? value){
				this.page_index_ = value;
			}
			public int? GetPage_count(){
				return this.page_count_;
			}
			
			public void SetPage_count(int? value){
				this.page_count_ = value;
			}
			public com.vip.domain.inventory.InboundCondition GetQueryCondition(){
				return this.queryCondition_;
			}
			
			public void SetQueryCondition(com.vip.domain.inventory.InboundCondition value){
				this.queryCondition_ = value;
			}
			
		}
		
		
		
		
		public class getPurchaseSalesInventory_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 页码
			/// @sampleValue page_index page_index=1
			///</summary>
			
			private int? page_index_;
			
			///<summary>
			/// 每页记录数
			/// @sampleValue page_count page_count=20
			///</summary>
			
			private int? page_count_;
			
			///<summary>
			/// 进销存查询条件
			/// @sampleValue queryCondition PurchaseSalesInventoryCondition
			///</summary>
			
			private com.vip.domain.inventory.PurchaseSalesInventoryCondition queryCondition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public int? GetPage_index(){
				return this.page_index_;
			}
			
			public void SetPage_index(int? value){
				this.page_index_ = value;
			}
			public int? GetPage_count(){
				return this.page_count_;
			}
			
			public void SetPage_count(int? value){
				this.page_count_ = value;
			}
			public com.vip.domain.inventory.PurchaseSalesInventoryCondition GetQueryCondition(){
				return this.queryCondition_;
			}
			
			public void SetQueryCondition(com.vip.domain.inventory.PurchaseSalesInventoryCondition value){
				this.queryCondition_ = value;
			}
			
		}
		
		
		
		
		public class getRealtimeInventory_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private string vendor_id_;
			
			///<summary>
			/// 页码
			/// @sampleValue page_index page_index=1
			///</summary>
			
			private int? page_index_;
			
			///<summary>
			/// 每页记录数
			/// @sampleValue page_count page_count=20
			///</summary>
			
			private int? page_count_;
			
			///<summary>
			/// 实时库存查询条件
			/// @sampleValue queryCondition RealtimeInventoryCondition
			///</summary>
			
			private com.vip.domain.inventory.RealtimeInventoryCondition queryCondition_;
			
			public string GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(string value){
				this.vendor_id_ = value;
			}
			public int? GetPage_index(){
				return this.page_index_;
			}
			
			public void SetPage_index(int? value){
				this.page_index_ = value;
			}
			public int? GetPage_count(){
				return this.page_count_;
			}
			
			public void SetPage_count(int? value){
				this.page_count_ = value;
			}
			public com.vip.domain.inventory.RealtimeInventoryCondition GetQueryCondition(){
				return this.queryCondition_;
			}
			
			public void SetQueryCondition(com.vip.domain.inventory.RealtimeInventoryCondition value){
				this.queryCondition_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getChannelInventory_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.GetChannelInventoryResponse success_;
			
			public com.vip.domain.inventory.GetChannelInventoryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.GetChannelInventoryResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getInbound_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.GetInboundResponse success_;
			
			public com.vip.domain.inventory.GetInboundResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.GetInboundResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPurchaseSalesInventory_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.PurchaseSalesInventoryResponse success_;
			
			public com.vip.domain.inventory.PurchaseSalesInventoryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.PurchaseSalesInventoryResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getRealtimeInventory_result {
			
			///<summary>
			///</summary>
			
			private com.vip.domain.inventory.GetRealtimeInventoryResponse success_;
			
			public com.vip.domain.inventory.GetRealtimeInventoryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.domain.inventory.GetRealtimeInventoryResponse value){
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
		
		
		
		
		
		public class getChannelInventory_argsHelper : TBeanSerializer<getChannelInventory_args>
		{
			
			public static getChannelInventory_argsHelper OBJ = new getChannelInventory_argsHelper();
			
			public static getChannelInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getChannelInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage_index(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage_count(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.ChannelInventoryQueryCondition value;
					
					value = new com.vip.domain.inventory.ChannelInventoryQueryCondition();
					com.vip.domain.inventory.ChannelInventoryQueryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetQueryCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getChannelInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPage_index() != null) {
					
					oprot.WriteFieldBegin("page_index");
					oprot.WriteI32((int)structs.GetPage_index()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage_count() != null) {
					
					oprot.WriteFieldBegin("page_count");
					oprot.WriteI32((int)structs.GetPage_count()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetQueryCondition() != null) {
					
					oprot.WriteFieldBegin("queryCondition");
					
					com.vip.domain.inventory.ChannelInventoryQueryConditionHelper.getInstance().Write(structs.GetQueryCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("queryCondition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getChannelInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInbound_argsHelper : TBeanSerializer<getInbound_args>
		{
			
			public static getInbound_argsHelper OBJ = new getInbound_argsHelper();
			
			public static getInbound_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInbound_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage_index(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage_count(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.InboundCondition value;
					
					value = new com.vip.domain.inventory.InboundCondition();
					com.vip.domain.inventory.InboundConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetQueryCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInbound_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPage_index() != null) {
					
					oprot.WriteFieldBegin("page_index");
					oprot.WriteI32((int)structs.GetPage_index()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage_count() != null) {
					
					oprot.WriteFieldBegin("page_count");
					oprot.WriteI32((int)structs.GetPage_count()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetQueryCondition() != null) {
					
					oprot.WriteFieldBegin("queryCondition");
					
					com.vip.domain.inventory.InboundConditionHelper.getInstance().Write(structs.GetQueryCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("queryCondition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInbound_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPurchaseSalesInventory_argsHelper : TBeanSerializer<getPurchaseSalesInventory_args>
		{
			
			public static getPurchaseSalesInventory_argsHelper OBJ = new getPurchaseSalesInventory_argsHelper();
			
			public static getPurchaseSalesInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPurchaseSalesInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage_index(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage_count(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.PurchaseSalesInventoryCondition value;
					
					value = new com.vip.domain.inventory.PurchaseSalesInventoryCondition();
					com.vip.domain.inventory.PurchaseSalesInventoryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetQueryCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPurchaseSalesInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage_index() != null) {
					
					oprot.WriteFieldBegin("page_index");
					oprot.WriteI32((int)structs.GetPage_index()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage_count() != null) {
					
					oprot.WriteFieldBegin("page_count");
					oprot.WriteI32((int)structs.GetPage_count()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetQueryCondition() != null) {
					
					oprot.WriteFieldBegin("queryCondition");
					
					com.vip.domain.inventory.PurchaseSalesInventoryConditionHelper.getInstance().Write(structs.GetQueryCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("queryCondition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPurchaseSalesInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRealtimeInventory_argsHelper : TBeanSerializer<getRealtimeInventory_args>
		{
			
			public static getRealtimeInventory_argsHelper OBJ = new getRealtimeInventory_argsHelper();
			
			public static getRealtimeInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRealtimeInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage_index(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage_count(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.RealtimeInventoryCondition value;
					
					value = new com.vip.domain.inventory.RealtimeInventoryCondition();
					com.vip.domain.inventory.RealtimeInventoryConditionHelper.getInstance().Read(value, iprot);
					
					structs.SetQueryCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRealtimeInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteString(structs.GetVendor_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPage_index() != null) {
					
					oprot.WriteFieldBegin("page_index");
					oprot.WriteI32((int)structs.GetPage_index()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage_count() != null) {
					
					oprot.WriteFieldBegin("page_count");
					oprot.WriteI32((int)structs.GetPage_count()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetQueryCondition() != null) {
					
					oprot.WriteFieldBegin("queryCondition");
					
					com.vip.domain.inventory.RealtimeInventoryConditionHelper.getInstance().Write(structs.GetQueryCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("queryCondition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRealtimeInventory_args bean){
				
				
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
		
		
		
		
		public class getChannelInventory_resultHelper : TBeanSerializer<getChannelInventory_result>
		{
			
			public static getChannelInventory_resultHelper OBJ = new getChannelInventory_resultHelper();
			
			public static getChannelInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getChannelInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.GetChannelInventoryResponse value;
					
					value = new com.vip.domain.inventory.GetChannelInventoryResponse();
					com.vip.domain.inventory.GetChannelInventoryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getChannelInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.GetChannelInventoryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getChannelInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getInbound_resultHelper : TBeanSerializer<getInbound_result>
		{
			
			public static getInbound_resultHelper OBJ = new getInbound_resultHelper();
			
			public static getInbound_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getInbound_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.GetInboundResponse value;
					
					value = new com.vip.domain.inventory.GetInboundResponse();
					com.vip.domain.inventory.GetInboundResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getInbound_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.GetInboundResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getInbound_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPurchaseSalesInventory_resultHelper : TBeanSerializer<getPurchaseSalesInventory_result>
		{
			
			public static getPurchaseSalesInventory_resultHelper OBJ = new getPurchaseSalesInventory_resultHelper();
			
			public static getPurchaseSalesInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPurchaseSalesInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.PurchaseSalesInventoryResponse value;
					
					value = new com.vip.domain.inventory.PurchaseSalesInventoryResponse();
					com.vip.domain.inventory.PurchaseSalesInventoryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPurchaseSalesInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.PurchaseSalesInventoryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPurchaseSalesInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRealtimeInventory_resultHelper : TBeanSerializer<getRealtimeInventory_result>
		{
			
			public static getRealtimeInventory_resultHelper OBJ = new getRealtimeInventory_resultHelper();
			
			public static getRealtimeInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRealtimeInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.domain.inventory.GetRealtimeInventoryResponse value;
					
					value = new com.vip.domain.inventory.GetRealtimeInventoryResponse();
					com.vip.domain.inventory.GetRealtimeInventoryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRealtimeInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.domain.inventory.GetRealtimeInventoryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRealtimeInventory_result bean){
				
				
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
		
		
		
		
		public class WopInventoryQueryServiceClient : OspRestStub , WopInventoryQueryService  {
			
			
			public WopInventoryQueryServiceClient():base("vipapis.inventory.WopInventoryQueryService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.domain.inventory.GetChannelInventoryResponse getChannelInventory(string vendor_id_,int? page_index_,int? page_count_,com.vip.domain.inventory.ChannelInventoryQueryCondition queryCondition_) {
				
				send_getChannelInventory(vendor_id_,page_index_,page_count_,queryCondition_);
				return recv_getChannelInventory(); 
				
			}
			
			
			private void send_getChannelInventory(string vendor_id_,int? page_index_,int? page_count_,com.vip.domain.inventory.ChannelInventoryQueryCondition queryCondition_){
				
				InitInvocation("getChannelInventory");
				
				getChannelInventory_args args = new getChannelInventory_args();
				args.SetVendor_id(vendor_id_);
				args.SetPage_index(page_index_);
				args.SetPage_count(page_count_);
				args.SetQueryCondition(queryCondition_);
				
				SendBase(args, getChannelInventory_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.GetChannelInventoryResponse recv_getChannelInventory(){
				
				getChannelInventory_result result = new getChannelInventory_result();
				ReceiveBase(result, getChannelInventory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.GetInboundResponse getInbound(string vendor_id_,int? page_index_,int? page_count_,com.vip.domain.inventory.InboundCondition queryCondition_) {
				
				send_getInbound(vendor_id_,page_index_,page_count_,queryCondition_);
				return recv_getInbound(); 
				
			}
			
			
			private void send_getInbound(string vendor_id_,int? page_index_,int? page_count_,com.vip.domain.inventory.InboundCondition queryCondition_){
				
				InitInvocation("getInbound");
				
				getInbound_args args = new getInbound_args();
				args.SetVendor_id(vendor_id_);
				args.SetPage_index(page_index_);
				args.SetPage_count(page_count_);
				args.SetQueryCondition(queryCondition_);
				
				SendBase(args, getInbound_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.GetInboundResponse recv_getInbound(){
				
				getInbound_result result = new getInbound_result();
				ReceiveBase(result, getInbound_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.PurchaseSalesInventoryResponse getPurchaseSalesInventory(string vendor_id_,int? page_index_,int? page_count_,com.vip.domain.inventory.PurchaseSalesInventoryCondition queryCondition_) {
				
				send_getPurchaseSalesInventory(vendor_id_,page_index_,page_count_,queryCondition_);
				return recv_getPurchaseSalesInventory(); 
				
			}
			
			
			private void send_getPurchaseSalesInventory(string vendor_id_,int? page_index_,int? page_count_,com.vip.domain.inventory.PurchaseSalesInventoryCondition queryCondition_){
				
				InitInvocation("getPurchaseSalesInventory");
				
				getPurchaseSalesInventory_args args = new getPurchaseSalesInventory_args();
				args.SetVendor_id(vendor_id_);
				args.SetPage_index(page_index_);
				args.SetPage_count(page_count_);
				args.SetQueryCondition(queryCondition_);
				
				SendBase(args, getPurchaseSalesInventory_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.PurchaseSalesInventoryResponse recv_getPurchaseSalesInventory(){
				
				getPurchaseSalesInventory_result result = new getPurchaseSalesInventory_result();
				ReceiveBase(result, getPurchaseSalesInventory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.domain.inventory.GetRealtimeInventoryResponse getRealtimeInventory(string vendor_id_,int? page_index_,int? page_count_,com.vip.domain.inventory.RealtimeInventoryCondition queryCondition_) {
				
				send_getRealtimeInventory(vendor_id_,page_index_,page_count_,queryCondition_);
				return recv_getRealtimeInventory(); 
				
			}
			
			
			private void send_getRealtimeInventory(string vendor_id_,int? page_index_,int? page_count_,com.vip.domain.inventory.RealtimeInventoryCondition queryCondition_){
				
				InitInvocation("getRealtimeInventory");
				
				getRealtimeInventory_args args = new getRealtimeInventory_args();
				args.SetVendor_id(vendor_id_);
				args.SetPage_index(page_index_);
				args.SetPage_count(page_count_);
				args.SetQueryCondition(queryCondition_);
				
				SendBase(args, getRealtimeInventory_argsHelper.getInstance());
			}
			
			
			private com.vip.domain.inventory.GetRealtimeInventoryResponse recv_getRealtimeInventory(){
				
				getRealtimeInventory_result result = new getRealtimeInventory_result();
				ReceiveBase(result, getRealtimeInventory_resultHelper.getInstance());
				
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