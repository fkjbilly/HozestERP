using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.isv.tools{
	
	
	public class CloudToolsServiceHelper {
		
		
		
		public class getSkuSaleCountInfos_args {
			
			///<summary>
			/// 查询条件
			///</summary>
			
			private com.vip.isv.tools.SkuSaleCountInfoQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.SkuSaleCountInfoQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.SkuSaleCountInfoQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class getSkuSaleCountInfosCount_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.SkuSaleCountInfoQueryReq req_;
			
			public com.vip.isv.tools.SkuSaleCountInfoQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.SkuSaleCountInfoQueryReq value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class inventoryApplyDetailPageQuery_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.InventoryApplyDetailQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.InventoryApplyDetailQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.InventoryApplyDetailQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class listCloudCooperationNoLog_args {
			
			///<summary>
			/// 查询条件
			///</summary>
			
			private com.vip.isv.tools.CloudCooperationNoLogReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.CloudCooperationNoLogReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.CloudCooperationNoLogReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class listInventoryRetryLog_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.InventoryRetryLogQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.InventoryRetryLogQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.InventoryRetryLogQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class occupiedOrderPageQuery_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.OccupiedOrderQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.OccupiedOrderQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.OccupiedOrderQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class returnSaleOrderPageQuery_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.ReturnSaleOrderQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.ReturnSaleOrderQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.ReturnSaleOrderQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class salesSkusPageQuery_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.SalesSkusQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.SalesSkusQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.SalesSkusQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class scheduleSkusPageQuery_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.ScheduleSkusQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.ScheduleSkusQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.ScheduleSkusQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class skuSaleInfoPageQuery_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.SkuSaleCountInfoQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.SkuSaleCountInfoQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.SkuSaleCountInfoQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class vendorInventoryLogPageQuery_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.VendorInventoryLogQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.VendorInventoryLogQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.VendorInventoryLogQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class vendorSalesPageQuery_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.VendorSalesQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.VendorSalesQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.VendorSalesQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class vendorScheduleDelete_args {
			
			///<summary>
			/// 主键
			///</summary>
			
			private List<long?> ids_;
			
			public List<long?> GetIds(){
				return this.ids_;
			}
			
			public void SetIds(List<long?> value){
				this.ids_ = value;
			}
			
		}
		
		
		
		
		public class vendorSchedulePageQuery_args {
			
			///<summary>
			/// 分页查询条件
			///</summary>
			
			private com.vip.isv.tools.VendorScheduleQueryReq req_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			///</summary>
			
			private int? limit_;
			
			public com.vip.isv.tools.VendorScheduleQueryReq GetReq(){
				return this.req_;
			}
			
			public void SetReq(com.vip.isv.tools.VendorScheduleQueryReq value){
				this.req_ = value;
			}
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
		
		
		
		
		public class vendorScheduleRevert_args {
			
			///<summary>
			/// 主键
			///</summary>
			
			private List<long?> ids_;
			
			public List<long?> GetIds(){
				return this.ids_;
			}
			
			public void SetIds(List<long?> value){
				this.ids_ = value;
			}
			
		}
		
		
		
		
		public class getSkuSaleCountInfos_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.isv.tools.SkuSaleCountInfoDo> success_;
			
			public List<com.vip.isv.tools.SkuSaleCountInfoDo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.tools.SkuSaleCountInfoDo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSkuSaleCountInfosCount_result {
			
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
		
		
		
		
		public class inventoryApplyDetailPageQuery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.InventoryApplyDetailRes success_;
			
			public com.vip.isv.tools.InventoryApplyDetailRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.InventoryApplyDetailRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class listCloudCooperationNoLog_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.CloudCooperationNoLogRes success_;
			
			public com.vip.isv.tools.CloudCooperationNoLogRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.CloudCooperationNoLogRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class listInventoryRetryLog_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.InventoryRetryLogRes success_;
			
			public com.vip.isv.tools.InventoryRetryLogRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.InventoryRetryLogRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class occupiedOrderPageQuery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.OccupiedOrderRes success_;
			
			public com.vip.isv.tools.OccupiedOrderRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.OccupiedOrderRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class returnSaleOrderPageQuery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.ReturnSaleOrderRes success_;
			
			public com.vip.isv.tools.ReturnSaleOrderRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.ReturnSaleOrderRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class salesSkusPageQuery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.SalesSkusRes success_;
			
			public com.vip.isv.tools.SalesSkusRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.SalesSkusRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class scheduleSkusPageQuery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.ScheduleSkusRes success_;
			
			public com.vip.isv.tools.ScheduleSkusRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.ScheduleSkusRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class skuSaleInfoPageQuery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.SkuSaleCountInfoRes success_;
			
			public com.vip.isv.tools.SkuSaleCountInfoRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.SkuSaleCountInfoRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class vendorInventoryLogPageQuery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.VendorInventoryLogRes success_;
			
			public com.vip.isv.tools.VendorInventoryLogRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.VendorInventoryLogRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class vendorSalesPageQuery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.VendorSalesRes success_;
			
			public com.vip.isv.tools.VendorSalesRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.VendorSalesRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class vendorScheduleDelete_result {
			
			
		}
		
		
		
		
		public class vendorSchedulePageQuery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.tools.VendorScheduleRes success_;
			
			public com.vip.isv.tools.VendorScheduleRes GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.tools.VendorScheduleRes value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class vendorScheduleRevert_result {
			
			
		}
		
		
		
		
		
		public class getSkuSaleCountInfos_argsHelper : TBeanSerializer<getSkuSaleCountInfos_args>
		{
			
			public static getSkuSaleCountInfos_argsHelper OBJ = new getSkuSaleCountInfos_argsHelper();
			
			public static getSkuSaleCountInfos_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuSaleCountInfos_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.SkuSaleCountInfoQueryReq value;
					
					value = new com.vip.isv.tools.SkuSaleCountInfoQueryReq();
					com.vip.isv.tools.SkuSaleCountInfoQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(getSkuSaleCountInfos_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.SkuSaleCountInfoQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
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
			
			
			public void Validate(getSkuSaleCountInfos_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuSaleCountInfosCount_argsHelper : TBeanSerializer<getSkuSaleCountInfosCount_args>
		{
			
			public static getSkuSaleCountInfosCount_argsHelper OBJ = new getSkuSaleCountInfosCount_argsHelper();
			
			public static getSkuSaleCountInfosCount_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuSaleCountInfosCount_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.SkuSaleCountInfoQueryReq value;
					
					value = new com.vip.isv.tools.SkuSaleCountInfoQueryReq();
					com.vip.isv.tools.SkuSaleCountInfoQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuSaleCountInfosCount_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.SkuSaleCountInfoQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuSaleCountInfosCount_args bean){
				
				
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
		
		
		
		
		public class inventoryApplyDetailPageQuery_argsHelper : TBeanSerializer<inventoryApplyDetailPageQuery_args>
		{
			
			public static inventoryApplyDetailPageQuery_argsHelper OBJ = new inventoryApplyDetailPageQuery_argsHelper();
			
			public static inventoryApplyDetailPageQuery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(inventoryApplyDetailPageQuery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.InventoryApplyDetailQueryReq value;
					
					value = new com.vip.isv.tools.InventoryApplyDetailQueryReq();
					com.vip.isv.tools.InventoryApplyDetailQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(inventoryApplyDetailPageQuery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.InventoryApplyDetailQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
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
			
			
			public void Validate(inventoryApplyDetailPageQuery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class listCloudCooperationNoLog_argsHelper : TBeanSerializer<listCloudCooperationNoLog_args>
		{
			
			public static listCloudCooperationNoLog_argsHelper OBJ = new listCloudCooperationNoLog_argsHelper();
			
			public static listCloudCooperationNoLog_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listCloudCooperationNoLog_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.CloudCooperationNoLogReq value;
					
					value = new com.vip.isv.tools.CloudCooperationNoLogReq();
					com.vip.isv.tools.CloudCooperationNoLogReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(listCloudCooperationNoLog_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.CloudCooperationNoLogReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
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
			
			
			public void Validate(listCloudCooperationNoLog_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class listInventoryRetryLog_argsHelper : TBeanSerializer<listInventoryRetryLog_args>
		{
			
			public static listInventoryRetryLog_argsHelper OBJ = new listInventoryRetryLog_argsHelper();
			
			public static listInventoryRetryLog_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listInventoryRetryLog_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.InventoryRetryLogQueryReq value;
					
					value = new com.vip.isv.tools.InventoryRetryLogQueryReq();
					com.vip.isv.tools.InventoryRetryLogQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(listInventoryRetryLog_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.InventoryRetryLogQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
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
			
			
			public void Validate(listInventoryRetryLog_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class occupiedOrderPageQuery_argsHelper : TBeanSerializer<occupiedOrderPageQuery_args>
		{
			
			public static occupiedOrderPageQuery_argsHelper OBJ = new occupiedOrderPageQuery_argsHelper();
			
			public static occupiedOrderPageQuery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(occupiedOrderPageQuery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.OccupiedOrderQueryReq value;
					
					value = new com.vip.isv.tools.OccupiedOrderQueryReq();
					com.vip.isv.tools.OccupiedOrderQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(occupiedOrderPageQuery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.OccupiedOrderQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
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
			
			
			public void Validate(occupiedOrderPageQuery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class returnSaleOrderPageQuery_argsHelper : TBeanSerializer<returnSaleOrderPageQuery_args>
		{
			
			public static returnSaleOrderPageQuery_argsHelper OBJ = new returnSaleOrderPageQuery_argsHelper();
			
			public static returnSaleOrderPageQuery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(returnSaleOrderPageQuery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.ReturnSaleOrderQueryReq value;
					
					value = new com.vip.isv.tools.ReturnSaleOrderQueryReq();
					com.vip.isv.tools.ReturnSaleOrderQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(returnSaleOrderPageQuery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.ReturnSaleOrderQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
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
			
			
			public void Validate(returnSaleOrderPageQuery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class salesSkusPageQuery_argsHelper : TBeanSerializer<salesSkusPageQuery_args>
		{
			
			public static salesSkusPageQuery_argsHelper OBJ = new salesSkusPageQuery_argsHelper();
			
			public static salesSkusPageQuery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(salesSkusPageQuery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.SalesSkusQueryReq value;
					
					value = new com.vip.isv.tools.SalesSkusQueryReq();
					com.vip.isv.tools.SalesSkusQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(salesSkusPageQuery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.SalesSkusQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
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
			
			
			public void Validate(salesSkusPageQuery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class scheduleSkusPageQuery_argsHelper : TBeanSerializer<scheduleSkusPageQuery_args>
		{
			
			public static scheduleSkusPageQuery_argsHelper OBJ = new scheduleSkusPageQuery_argsHelper();
			
			public static scheduleSkusPageQuery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(scheduleSkusPageQuery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.ScheduleSkusQueryReq value;
					
					value = new com.vip.isv.tools.ScheduleSkusQueryReq();
					com.vip.isv.tools.ScheduleSkusQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(scheduleSkusPageQuery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.ScheduleSkusQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
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
			
			
			public void Validate(scheduleSkusPageQuery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class skuSaleInfoPageQuery_argsHelper : TBeanSerializer<skuSaleInfoPageQuery_args>
		{
			
			public static skuSaleInfoPageQuery_argsHelper OBJ = new skuSaleInfoPageQuery_argsHelper();
			
			public static skuSaleInfoPageQuery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(skuSaleInfoPageQuery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.SkuSaleCountInfoQueryReq value;
					
					value = new com.vip.isv.tools.SkuSaleCountInfoQueryReq();
					com.vip.isv.tools.SkuSaleCountInfoQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(skuSaleInfoPageQuery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.SkuSaleCountInfoQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
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
			
			
			public void Validate(skuSaleInfoPageQuery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorInventoryLogPageQuery_argsHelper : TBeanSerializer<vendorInventoryLogPageQuery_args>
		{
			
			public static vendorInventoryLogPageQuery_argsHelper OBJ = new vendorInventoryLogPageQuery_argsHelper();
			
			public static vendorInventoryLogPageQuery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorInventoryLogPageQuery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.VendorInventoryLogQueryReq value;
					
					value = new com.vip.isv.tools.VendorInventoryLogQueryReq();
					com.vip.isv.tools.VendorInventoryLogQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(vendorInventoryLogPageQuery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.VendorInventoryLogQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
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
			
			
			public void Validate(vendorInventoryLogPageQuery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorSalesPageQuery_argsHelper : TBeanSerializer<vendorSalesPageQuery_args>
		{
			
			public static vendorSalesPageQuery_argsHelper OBJ = new vendorSalesPageQuery_argsHelper();
			
			public static vendorSalesPageQuery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorSalesPageQuery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.VendorSalesQueryReq value;
					
					value = new com.vip.isv.tools.VendorSalesQueryReq();
					com.vip.isv.tools.VendorSalesQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(vendorSalesPageQuery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.VendorSalesQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
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
			
			
			public void Validate(vendorSalesPageQuery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorScheduleDelete_argsHelper : TBeanSerializer<vendorScheduleDelete_args>
		{
			
			public static vendorScheduleDelete_argsHelper OBJ = new vendorScheduleDelete_argsHelper();
			
			public static vendorScheduleDelete_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorScheduleDelete_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem0;
							elem0 = iprot.ReadI64(); 
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetIds(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(vendorScheduleDelete_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetIds() != null) {
					
					oprot.WriteFieldBegin("ids");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetIds()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(vendorScheduleDelete_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorSchedulePageQuery_argsHelper : TBeanSerializer<vendorSchedulePageQuery_args>
		{
			
			public static vendorSchedulePageQuery_argsHelper OBJ = new vendorSchedulePageQuery_argsHelper();
			
			public static vendorSchedulePageQuery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorSchedulePageQuery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.VendorScheduleQueryReq value;
					
					value = new com.vip.isv.tools.VendorScheduleQueryReq();
					com.vip.isv.tools.VendorScheduleQueryReqHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				
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
			
			
			public void Write(vendorSchedulePageQuery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					com.vip.isv.tools.VendorScheduleQueryReqHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
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
			
			
			public void Validate(vendorSchedulePageQuery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorScheduleRevert_argsHelper : TBeanSerializer<vendorScheduleRevert_args>
		{
			
			public static vendorScheduleRevert_argsHelper OBJ = new vendorScheduleRevert_argsHelper();
			
			public static vendorScheduleRevert_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorScheduleRevert_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem0;
							elem0 = iprot.ReadI64(); 
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetIds(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(vendorScheduleRevert_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetIds() != null) {
					
					oprot.WriteFieldBegin("ids");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetIds()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(vendorScheduleRevert_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuSaleCountInfos_resultHelper : TBeanSerializer<getSkuSaleCountInfos_result>
		{
			
			public static getSkuSaleCountInfos_resultHelper OBJ = new getSkuSaleCountInfos_resultHelper();
			
			public static getSkuSaleCountInfos_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuSaleCountInfos_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.tools.SkuSaleCountInfoDo> value;
					
					value = new List<com.vip.isv.tools.SkuSaleCountInfoDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.tools.SkuSaleCountInfoDo elem1;
							
							elem1 = new com.vip.isv.tools.SkuSaleCountInfoDo();
							com.vip.isv.tools.SkuSaleCountInfoDoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
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
			
			
			public void Write(getSkuSaleCountInfos_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.tools.SkuSaleCountInfoDo _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.tools.SkuSaleCountInfoDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuSaleCountInfos_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuSaleCountInfosCount_resultHelper : TBeanSerializer<getSkuSaleCountInfosCount_result>
		{
			
			public static getSkuSaleCountInfosCount_resultHelper OBJ = new getSkuSaleCountInfosCount_resultHelper();
			
			public static getSkuSaleCountInfosCount_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuSaleCountInfosCount_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuSaleCountInfosCount_result structs, Protocol oprot){
				
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
			
			
			public void Validate(getSkuSaleCountInfosCount_result bean){
				
				
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
		
		
		
		
		public class inventoryApplyDetailPageQuery_resultHelper : TBeanSerializer<inventoryApplyDetailPageQuery_result>
		{
			
			public static inventoryApplyDetailPageQuery_resultHelper OBJ = new inventoryApplyDetailPageQuery_resultHelper();
			
			public static inventoryApplyDetailPageQuery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(inventoryApplyDetailPageQuery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.InventoryApplyDetailRes value;
					
					value = new com.vip.isv.tools.InventoryApplyDetailRes();
					com.vip.isv.tools.InventoryApplyDetailResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(inventoryApplyDetailPageQuery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.InventoryApplyDetailResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(inventoryApplyDetailPageQuery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class listCloudCooperationNoLog_resultHelper : TBeanSerializer<listCloudCooperationNoLog_result>
		{
			
			public static listCloudCooperationNoLog_resultHelper OBJ = new listCloudCooperationNoLog_resultHelper();
			
			public static listCloudCooperationNoLog_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listCloudCooperationNoLog_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.CloudCooperationNoLogRes value;
					
					value = new com.vip.isv.tools.CloudCooperationNoLogRes();
					com.vip.isv.tools.CloudCooperationNoLogResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(listCloudCooperationNoLog_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.CloudCooperationNoLogResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(listCloudCooperationNoLog_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class listInventoryRetryLog_resultHelper : TBeanSerializer<listInventoryRetryLog_result>
		{
			
			public static listInventoryRetryLog_resultHelper OBJ = new listInventoryRetryLog_resultHelper();
			
			public static listInventoryRetryLog_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listInventoryRetryLog_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.InventoryRetryLogRes value;
					
					value = new com.vip.isv.tools.InventoryRetryLogRes();
					com.vip.isv.tools.InventoryRetryLogResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(listInventoryRetryLog_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.InventoryRetryLogResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(listInventoryRetryLog_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class occupiedOrderPageQuery_resultHelper : TBeanSerializer<occupiedOrderPageQuery_result>
		{
			
			public static occupiedOrderPageQuery_resultHelper OBJ = new occupiedOrderPageQuery_resultHelper();
			
			public static occupiedOrderPageQuery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(occupiedOrderPageQuery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.OccupiedOrderRes value;
					
					value = new com.vip.isv.tools.OccupiedOrderRes();
					com.vip.isv.tools.OccupiedOrderResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(occupiedOrderPageQuery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.OccupiedOrderResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(occupiedOrderPageQuery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class returnSaleOrderPageQuery_resultHelper : TBeanSerializer<returnSaleOrderPageQuery_result>
		{
			
			public static returnSaleOrderPageQuery_resultHelper OBJ = new returnSaleOrderPageQuery_resultHelper();
			
			public static returnSaleOrderPageQuery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(returnSaleOrderPageQuery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.ReturnSaleOrderRes value;
					
					value = new com.vip.isv.tools.ReturnSaleOrderRes();
					com.vip.isv.tools.ReturnSaleOrderResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(returnSaleOrderPageQuery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.ReturnSaleOrderResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(returnSaleOrderPageQuery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class salesSkusPageQuery_resultHelper : TBeanSerializer<salesSkusPageQuery_result>
		{
			
			public static salesSkusPageQuery_resultHelper OBJ = new salesSkusPageQuery_resultHelper();
			
			public static salesSkusPageQuery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(salesSkusPageQuery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.SalesSkusRes value;
					
					value = new com.vip.isv.tools.SalesSkusRes();
					com.vip.isv.tools.SalesSkusResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(salesSkusPageQuery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.SalesSkusResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(salesSkusPageQuery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class scheduleSkusPageQuery_resultHelper : TBeanSerializer<scheduleSkusPageQuery_result>
		{
			
			public static scheduleSkusPageQuery_resultHelper OBJ = new scheduleSkusPageQuery_resultHelper();
			
			public static scheduleSkusPageQuery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(scheduleSkusPageQuery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.ScheduleSkusRes value;
					
					value = new com.vip.isv.tools.ScheduleSkusRes();
					com.vip.isv.tools.ScheduleSkusResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(scheduleSkusPageQuery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.ScheduleSkusResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(scheduleSkusPageQuery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class skuSaleInfoPageQuery_resultHelper : TBeanSerializer<skuSaleInfoPageQuery_result>
		{
			
			public static skuSaleInfoPageQuery_resultHelper OBJ = new skuSaleInfoPageQuery_resultHelper();
			
			public static skuSaleInfoPageQuery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(skuSaleInfoPageQuery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.SkuSaleCountInfoRes value;
					
					value = new com.vip.isv.tools.SkuSaleCountInfoRes();
					com.vip.isv.tools.SkuSaleCountInfoResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(skuSaleInfoPageQuery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.SkuSaleCountInfoResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(skuSaleInfoPageQuery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorInventoryLogPageQuery_resultHelper : TBeanSerializer<vendorInventoryLogPageQuery_result>
		{
			
			public static vendorInventoryLogPageQuery_resultHelper OBJ = new vendorInventoryLogPageQuery_resultHelper();
			
			public static vendorInventoryLogPageQuery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorInventoryLogPageQuery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.VendorInventoryLogRes value;
					
					value = new com.vip.isv.tools.VendorInventoryLogRes();
					com.vip.isv.tools.VendorInventoryLogResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(vendorInventoryLogPageQuery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.VendorInventoryLogResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(vendorInventoryLogPageQuery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorSalesPageQuery_resultHelper : TBeanSerializer<vendorSalesPageQuery_result>
		{
			
			public static vendorSalesPageQuery_resultHelper OBJ = new vendorSalesPageQuery_resultHelper();
			
			public static vendorSalesPageQuery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorSalesPageQuery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.VendorSalesRes value;
					
					value = new com.vip.isv.tools.VendorSalesRes();
					com.vip.isv.tools.VendorSalesResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(vendorSalesPageQuery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.VendorSalesResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(vendorSalesPageQuery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorScheduleDelete_resultHelper : TBeanSerializer<vendorScheduleDelete_result>
		{
			
			public static vendorScheduleDelete_resultHelper OBJ = new vendorScheduleDelete_resultHelper();
			
			public static vendorScheduleDelete_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorScheduleDelete_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(vendorScheduleDelete_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(vendorScheduleDelete_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorSchedulePageQuery_resultHelper : TBeanSerializer<vendorSchedulePageQuery_result>
		{
			
			public static vendorSchedulePageQuery_resultHelper OBJ = new vendorSchedulePageQuery_resultHelper();
			
			public static vendorSchedulePageQuery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorSchedulePageQuery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.tools.VendorScheduleRes value;
					
					value = new com.vip.isv.tools.VendorScheduleRes();
					com.vip.isv.tools.VendorScheduleResHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(vendorSchedulePageQuery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.tools.VendorScheduleResHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(vendorSchedulePageQuery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vendorScheduleRevert_resultHelper : TBeanSerializer<vendorScheduleRevert_result>
		{
			
			public static vendorScheduleRevert_resultHelper OBJ = new vendorScheduleRevert_resultHelper();
			
			public static vendorScheduleRevert_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vendorScheduleRevert_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(vendorScheduleRevert_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(vendorScheduleRevert_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class CloudToolsServiceClient : OspRestStub , CloudToolsService  {
			
			
			public CloudToolsServiceClient():base("com.vip.isv.tools.CloudToolsService","1.0.0") {
				
				
			}
			
			
			
			public List<com.vip.isv.tools.SkuSaleCountInfoDo> getSkuSaleCountInfos(com.vip.isv.tools.SkuSaleCountInfoQueryReq req_,int? page_,int? limit_) {
				
				send_getSkuSaleCountInfos(req_,page_,limit_);
				return recv_getSkuSaleCountInfos(); 
				
			}
			
			
			private void send_getSkuSaleCountInfos(com.vip.isv.tools.SkuSaleCountInfoQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("getSkuSaleCountInfos");
				
				getSkuSaleCountInfos_args args = new getSkuSaleCountInfos_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getSkuSaleCountInfos_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.tools.SkuSaleCountInfoDo> recv_getSkuSaleCountInfos(){
				
				getSkuSaleCountInfos_result result = new getSkuSaleCountInfos_result();
				ReceiveBase(result, getSkuSaleCountInfos_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? getSkuSaleCountInfosCount(com.vip.isv.tools.SkuSaleCountInfoQueryReq req_) {
				
				send_getSkuSaleCountInfosCount(req_);
				return recv_getSkuSaleCountInfosCount(); 
				
			}
			
			
			private void send_getSkuSaleCountInfosCount(com.vip.isv.tools.SkuSaleCountInfoQueryReq req_){
				
				InitInvocation("getSkuSaleCountInfosCount");
				
				getSkuSaleCountInfosCount_args args = new getSkuSaleCountInfosCount_args();
				args.SetReq(req_);
				
				SendBase(args, getSkuSaleCountInfosCount_argsHelper.getInstance());
			}
			
			
			private int? recv_getSkuSaleCountInfosCount(){
				
				getSkuSaleCountInfosCount_result result = new getSkuSaleCountInfosCount_result();
				ReceiveBase(result, getSkuSaleCountInfosCount_resultHelper.getInstance());
				
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
			
			
			public com.vip.isv.tools.InventoryApplyDetailRes inventoryApplyDetailPageQuery(com.vip.isv.tools.InventoryApplyDetailQueryReq req_,int? page_,int? limit_) {
				
				send_inventoryApplyDetailPageQuery(req_,page_,limit_);
				return recv_inventoryApplyDetailPageQuery(); 
				
			}
			
			
			private void send_inventoryApplyDetailPageQuery(com.vip.isv.tools.InventoryApplyDetailQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("inventoryApplyDetailPageQuery");
				
				inventoryApplyDetailPageQuery_args args = new inventoryApplyDetailPageQuery_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, inventoryApplyDetailPageQuery_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.InventoryApplyDetailRes recv_inventoryApplyDetailPageQuery(){
				
				inventoryApplyDetailPageQuery_result result = new inventoryApplyDetailPageQuery_result();
				ReceiveBase(result, inventoryApplyDetailPageQuery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.tools.CloudCooperationNoLogRes listCloudCooperationNoLog(com.vip.isv.tools.CloudCooperationNoLogReq req_,int? page_,int? limit_) {
				
				send_listCloudCooperationNoLog(req_,page_,limit_);
				return recv_listCloudCooperationNoLog(); 
				
			}
			
			
			private void send_listCloudCooperationNoLog(com.vip.isv.tools.CloudCooperationNoLogReq req_,int? page_,int? limit_){
				
				InitInvocation("listCloudCooperationNoLog");
				
				listCloudCooperationNoLog_args args = new listCloudCooperationNoLog_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, listCloudCooperationNoLog_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.CloudCooperationNoLogRes recv_listCloudCooperationNoLog(){
				
				listCloudCooperationNoLog_result result = new listCloudCooperationNoLog_result();
				ReceiveBase(result, listCloudCooperationNoLog_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.tools.InventoryRetryLogRes listInventoryRetryLog(com.vip.isv.tools.InventoryRetryLogQueryReq req_,int? page_,int? limit_) {
				
				send_listInventoryRetryLog(req_,page_,limit_);
				return recv_listInventoryRetryLog(); 
				
			}
			
			
			private void send_listInventoryRetryLog(com.vip.isv.tools.InventoryRetryLogQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("listInventoryRetryLog");
				
				listInventoryRetryLog_args args = new listInventoryRetryLog_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, listInventoryRetryLog_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.InventoryRetryLogRes recv_listInventoryRetryLog(){
				
				listInventoryRetryLog_result result = new listInventoryRetryLog_result();
				ReceiveBase(result, listInventoryRetryLog_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.tools.OccupiedOrderRes occupiedOrderPageQuery(com.vip.isv.tools.OccupiedOrderQueryReq req_,int? page_,int? limit_) {
				
				send_occupiedOrderPageQuery(req_,page_,limit_);
				return recv_occupiedOrderPageQuery(); 
				
			}
			
			
			private void send_occupiedOrderPageQuery(com.vip.isv.tools.OccupiedOrderQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("occupiedOrderPageQuery");
				
				occupiedOrderPageQuery_args args = new occupiedOrderPageQuery_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, occupiedOrderPageQuery_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.OccupiedOrderRes recv_occupiedOrderPageQuery(){
				
				occupiedOrderPageQuery_result result = new occupiedOrderPageQuery_result();
				ReceiveBase(result, occupiedOrderPageQuery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.tools.ReturnSaleOrderRes returnSaleOrderPageQuery(com.vip.isv.tools.ReturnSaleOrderQueryReq req_,int? page_,int? limit_) {
				
				send_returnSaleOrderPageQuery(req_,page_,limit_);
				return recv_returnSaleOrderPageQuery(); 
				
			}
			
			
			private void send_returnSaleOrderPageQuery(com.vip.isv.tools.ReturnSaleOrderQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("returnSaleOrderPageQuery");
				
				returnSaleOrderPageQuery_args args = new returnSaleOrderPageQuery_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, returnSaleOrderPageQuery_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.ReturnSaleOrderRes recv_returnSaleOrderPageQuery(){
				
				returnSaleOrderPageQuery_result result = new returnSaleOrderPageQuery_result();
				ReceiveBase(result, returnSaleOrderPageQuery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.tools.SalesSkusRes salesSkusPageQuery(com.vip.isv.tools.SalesSkusQueryReq req_,int? page_,int? limit_) {
				
				send_salesSkusPageQuery(req_,page_,limit_);
				return recv_salesSkusPageQuery(); 
				
			}
			
			
			private void send_salesSkusPageQuery(com.vip.isv.tools.SalesSkusQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("salesSkusPageQuery");
				
				salesSkusPageQuery_args args = new salesSkusPageQuery_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, salesSkusPageQuery_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.SalesSkusRes recv_salesSkusPageQuery(){
				
				salesSkusPageQuery_result result = new salesSkusPageQuery_result();
				ReceiveBase(result, salesSkusPageQuery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.tools.ScheduleSkusRes scheduleSkusPageQuery(com.vip.isv.tools.ScheduleSkusQueryReq req_,int? page_,int? limit_) {
				
				send_scheduleSkusPageQuery(req_,page_,limit_);
				return recv_scheduleSkusPageQuery(); 
				
			}
			
			
			private void send_scheduleSkusPageQuery(com.vip.isv.tools.ScheduleSkusQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("scheduleSkusPageQuery");
				
				scheduleSkusPageQuery_args args = new scheduleSkusPageQuery_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, scheduleSkusPageQuery_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.ScheduleSkusRes recv_scheduleSkusPageQuery(){
				
				scheduleSkusPageQuery_result result = new scheduleSkusPageQuery_result();
				ReceiveBase(result, scheduleSkusPageQuery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.tools.SkuSaleCountInfoRes skuSaleInfoPageQuery(com.vip.isv.tools.SkuSaleCountInfoQueryReq req_,int? page_,int? limit_) {
				
				send_skuSaleInfoPageQuery(req_,page_,limit_);
				return recv_skuSaleInfoPageQuery(); 
				
			}
			
			
			private void send_skuSaleInfoPageQuery(com.vip.isv.tools.SkuSaleCountInfoQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("skuSaleInfoPageQuery");
				
				skuSaleInfoPageQuery_args args = new skuSaleInfoPageQuery_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, skuSaleInfoPageQuery_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.SkuSaleCountInfoRes recv_skuSaleInfoPageQuery(){
				
				skuSaleInfoPageQuery_result result = new skuSaleInfoPageQuery_result();
				ReceiveBase(result, skuSaleInfoPageQuery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.tools.VendorInventoryLogRes vendorInventoryLogPageQuery(com.vip.isv.tools.VendorInventoryLogQueryReq req_,int? page_,int? limit_) {
				
				send_vendorInventoryLogPageQuery(req_,page_,limit_);
				return recv_vendorInventoryLogPageQuery(); 
				
			}
			
			
			private void send_vendorInventoryLogPageQuery(com.vip.isv.tools.VendorInventoryLogQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("vendorInventoryLogPageQuery");
				
				vendorInventoryLogPageQuery_args args = new vendorInventoryLogPageQuery_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, vendorInventoryLogPageQuery_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.VendorInventoryLogRes recv_vendorInventoryLogPageQuery(){
				
				vendorInventoryLogPageQuery_result result = new vendorInventoryLogPageQuery_result();
				ReceiveBase(result, vendorInventoryLogPageQuery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.tools.VendorSalesRes vendorSalesPageQuery(com.vip.isv.tools.VendorSalesQueryReq req_,int? page_,int? limit_) {
				
				send_vendorSalesPageQuery(req_,page_,limit_);
				return recv_vendorSalesPageQuery(); 
				
			}
			
			
			private void send_vendorSalesPageQuery(com.vip.isv.tools.VendorSalesQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("vendorSalesPageQuery");
				
				vendorSalesPageQuery_args args = new vendorSalesPageQuery_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, vendorSalesPageQuery_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.VendorSalesRes recv_vendorSalesPageQuery(){
				
				vendorSalesPageQuery_result result = new vendorSalesPageQuery_result();
				ReceiveBase(result, vendorSalesPageQuery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void vendorScheduleDelete(List<long?> ids_) {
				
				send_vendorScheduleDelete(ids_);
				recv_vendorScheduleDelete();
				
			}
			
			
			private void send_vendorScheduleDelete(List<long?> ids_){
				
				InitInvocation("vendorScheduleDelete");
				
				vendorScheduleDelete_args args = new vendorScheduleDelete_args();
				args.SetIds(ids_);
				
				SendBase(args, vendorScheduleDelete_argsHelper.getInstance());
			}
			
			
			private void recv_vendorScheduleDelete(){
				
				vendorScheduleDelete_result result = new vendorScheduleDelete_result();
				ReceiveBase(result, vendorScheduleDelete_resultHelper.getInstance());
				
				
			}
			
			
			public com.vip.isv.tools.VendorScheduleRes vendorSchedulePageQuery(com.vip.isv.tools.VendorScheduleQueryReq req_,int? page_,int? limit_) {
				
				send_vendorSchedulePageQuery(req_,page_,limit_);
				return recv_vendorSchedulePageQuery(); 
				
			}
			
			
			private void send_vendorSchedulePageQuery(com.vip.isv.tools.VendorScheduleQueryReq req_,int? page_,int? limit_){
				
				InitInvocation("vendorSchedulePageQuery");
				
				vendorSchedulePageQuery_args args = new vendorSchedulePageQuery_args();
				args.SetReq(req_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, vendorSchedulePageQuery_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.tools.VendorScheduleRes recv_vendorSchedulePageQuery(){
				
				vendorSchedulePageQuery_result result = new vendorSchedulePageQuery_result();
				ReceiveBase(result, vendorSchedulePageQuery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void vendorScheduleRevert(List<long?> ids_) {
				
				send_vendorScheduleRevert(ids_);
				recv_vendorScheduleRevert();
				
			}
			
			
			private void send_vendorScheduleRevert(List<long?> ids_){
				
				InitInvocation("vendorScheduleRevert");
				
				vendorScheduleRevert_args args = new vendorScheduleRevert_args();
				args.SetIds(ids_);
				
				SendBase(args, vendorScheduleRevert_argsHelper.getInstance());
			}
			
			
			private void recv_vendorScheduleRevert(){
				
				vendorScheduleRevert_result result = new vendorScheduleRevert_result();
				ReceiveBase(result, vendorScheduleRevert_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}