using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.sales{
	
	
	public class SalesServiceHelper {
		
		
		
		public class getEndingSalesSkus_args {
			
			///<summary>
			/// 供应商名称
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 品牌ID
			///</summary>
			
			private string brand_id_;
			
			///<summary>
			/// 查询时间段的开始时间，返回专场下线时间在此时间段内的结果（Epoch格式）
			///</summary>
			
			private long? st_query_;
			
			///<summary>
			/// 查询时间段的结束时间，返回专场下线时间在此时间段内的结果（Epoch格式）
			///</summary>
			
			private long? et_query_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页查询条数(最多支持200条)
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(string value){
				this.brand_id_ = value;
			}
			public long? GetSt_query(){
				return this.st_query_;
			}
			
			public void SetSt_query(long? value){
				this.st_query_ = value;
			}
			public long? GetEt_query(){
				return this.et_query_;
			}
			
			public void SetEt_query(long? value){
				this.et_query_ = value;
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
		
		
		
		
		public class getSalesList_args {
			
			///<summary>
			/// 供应商id
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 按专场开售时间过滤,查询时间段的开始时间，返回专场开售时间在此时间段内的结果（Epoch格式，默认为最近30天）
			///</summary>
			
			private long? st_query_;
			
			///<summary>
			/// 按专场开售时间过滤,查询时间段的开始时间，返回专场开售时间在此时间段内的结果（Epoch格式，默认为最近30天）
			///</summary>
			
			private long? et_query_;
			
			///<summary>
			/// 页码
			/// @sampleValue page 1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页查询条数（最大200条，默认200条）
			/// @sampleValue limit 50
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public long? GetSt_query(){
				return this.st_query_;
			}
			
			public void SetSt_query(long? value){
				this.st_query_ = value;
			}
			public long? GetEt_query(){
				return this.et_query_;
			}
			
			public void SetEt_query(long? value){
				this.et_query_ = value;
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
		
		
		
		
		public class getSalesSkuList_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 专场id
			///</summary>
			
			private long? sales_no_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页查询条数
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public long? GetSales_no(){
				return this.sales_no_;
			}
			
			public void SetSales_no(long? value){
				this.sales_no_ = value;
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
		
		
		
		
		public class getUpcomingSalesSkus_args {
			
			///<summary>
			/// 供应商名称
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 品牌ID
			///</summary>
			
			private string brand_id_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页查询条数（最大200条，默认200条）
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(string value){
				this.brand_id_ = value;
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
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateSalesSkusInventory_args {
			
			///<summary>
			/// 批次号（不支持负数,相同供应商ID不允许重复，否则忽略重复请求）
			///</summary>
			
			private int? batch_no_;
			
			///<summary>
			/// 供应商id
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 首次采用此接口进行库存同步必须是全量同步，再次同步必须是增量同步
			/// @sampleValue is_full 全量同步：true，增量同步：false
			///</summary>
			
			private bool? is_full_;
			
			///<summary>
			/// 供应商仓库编码
			///</summary>
			
			private string warehouse_supplier_;
			
			///<summary>
			/// 商品库存数，最大50条记录
			///</summary>
			
			private List<vipapis.sales.BarcodeInventory> inventories_;
			
			public int? GetBatch_no(){
				return this.batch_no_;
			}
			
			public void SetBatch_no(int? value){
				this.batch_no_ = value;
			}
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public bool? GetIs_full(){
				return this.is_full_;
			}
			
			public void SetIs_full(bool? value){
				this.is_full_ = value;
			}
			public string GetWarehouse_supplier(){
				return this.warehouse_supplier_;
			}
			
			public void SetWarehouse_supplier(string value){
				this.warehouse_supplier_ = value;
			}
			public List<vipapis.sales.BarcodeInventory> GetInventories(){
				return this.inventories_;
			}
			
			public void SetInventories(List<vipapis.sales.BarcodeInventory> value){
				this.inventories_ = value;
			}
			
		}
		
		
		
		
		public class getEndingSalesSkus_result {
			
			///<summary>
			///</summary>
			
			private vipapis.sales.GetEndingSalesSkusResult success_;
			
			public vipapis.sales.GetEndingSalesSkusResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.sales.GetEndingSalesSkusResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSalesList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.sales.GetSalesListResult success_;
			
			public vipapis.sales.GetSalesListResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.sales.GetSalesListResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSalesSkuList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.sales.GetSalesSkuListResult success_;
			
			public vipapis.sales.GetSalesSkuListResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.sales.GetSalesSkuListResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getUpcomingSalesSkus_result {
			
			///<summary>
			///</summary>
			
			private vipapis.sales.GetUpcomingSalesSkusResult success_;
			
			public vipapis.sales.GetUpcomingSalesSkusResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.sales.GetUpcomingSalesSkusResult value){
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
		
		
		
		
		public class updateSalesSkusInventory_result {
			
			///<summary>
			///</summary>
			
			private vipapis.sales.SetSkuInventoryResult success_;
			
			public vipapis.sales.SetSkuInventoryResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.sales.SetSkuInventoryResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getEndingSalesSkus_argsHelper : TBeanSerializer<getEndingSalesSkus_args>
		{
			
			public static getEndingSalesSkus_argsHelper OBJ = new getEndingSalesSkus_argsHelper();
			
			public static getEndingSalesSkus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getEndingSalesSkus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSt_query(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetEt_query(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getEndingSalesSkus_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteString(structs.GetBrand_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_query() != null) {
					
					oprot.WriteFieldBegin("st_query");
					oprot.WriteI64((long)structs.GetSt_query()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("st_query can not be null!");
				}
				
				
				if(structs.GetEt_query() != null) {
					
					oprot.WriteFieldBegin("et_query");
					oprot.WriteI64((long)structs.GetEt_query()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("et_query can not be null!");
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("page can not be null!");
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("limit can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getEndingSalesSkus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSalesList_argsHelper : TBeanSerializer<getSalesList_args>
		{
			
			public static getSalesList_argsHelper OBJ = new getSalesList_argsHelper();
			
			public static getSalesList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSalesList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSt_query(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetEt_query(value);
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
			
			
			public void Write(getSalesList_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSt_query() != null) {
					
					oprot.WriteFieldBegin("st_query");
					oprot.WriteI64((long)structs.GetSt_query()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEt_query() != null) {
					
					oprot.WriteFieldBegin("et_query");
					oprot.WriteI64((long)structs.GetEt_query()); 
					
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
			
			
			public void Validate(getSalesList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSalesSkuList_argsHelper : TBeanSerializer<getSalesSkuList_args>
		{
			
			public static getSalesSkuList_argsHelper OBJ = new getSalesSkuList_argsHelper();
			
			public static getSalesSkuList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSalesSkuList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSales_no(value);
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
			
			
			public void Write(getSalesSkuList_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSales_no() != null) {
					
					oprot.WriteFieldBegin("sales_no");
					oprot.WriteI64((long)structs.GetSales_no()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sales_no can not be null!");
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
			
			
			public void Validate(getSalesSkuList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUpcomingSalesSkus_argsHelper : TBeanSerializer<getUpcomingSalesSkus_args>
		{
			
			public static getUpcomingSalesSkus_argsHelper OBJ = new getUpcomingSalesSkus_argsHelper();
			
			public static getUpcomingSalesSkus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUpcomingSalesSkus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUpcomingSalesSkus_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteString(structs.GetBrand_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("page can not be null!");
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("limit can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUpcomingSalesSkus_args bean){
				
				
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
		
		
		
		
		public class updateSalesSkusInventory_argsHelper : TBeanSerializer<updateSalesSkusInventory_args>
		{
			
			public static updateSalesSkusInventory_argsHelper OBJ = new updateSalesSkusInventory_argsHelper();
			
			public static updateSalesSkusInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSalesSkusInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetBatch_no(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetIs_full(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse_supplier(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.sales.BarcodeInventory> value;
					
					value = new List<vipapis.sales.BarcodeInventory>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.sales.BarcodeInventory elem0;
							
							elem0 = new vipapis.sales.BarcodeInventory();
							vipapis.sales.BarcodeInventoryHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetInventories(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSalesSkusInventory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetBatch_no() != null) {
					
					oprot.WriteFieldBegin("batch_no");
					oprot.WriteI32((int)structs.GetBatch_no()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("batch_no can not be null!");
				}
				
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetIs_full() != null) {
					
					oprot.WriteFieldBegin("is_full");
					oprot.WriteBool((bool)structs.GetIs_full());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("is_full can not be null!");
				}
				
				
				if(structs.GetWarehouse_supplier() != null) {
					
					oprot.WriteFieldBegin("warehouse_supplier");
					oprot.WriteString(structs.GetWarehouse_supplier());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetInventories() != null) {
					
					oprot.WriteFieldBegin("inventories");
					
					oprot.WriteListBegin();
					foreach(vipapis.sales.BarcodeInventory _item0 in structs.GetInventories()){
						
						
						vipapis.sales.BarcodeInventoryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("inventories can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSalesSkusInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getEndingSalesSkus_resultHelper : TBeanSerializer<getEndingSalesSkus_result>
		{
			
			public static getEndingSalesSkus_resultHelper OBJ = new getEndingSalesSkus_resultHelper();
			
			public static getEndingSalesSkus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getEndingSalesSkus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.sales.GetEndingSalesSkusResult value;
					
					value = new vipapis.sales.GetEndingSalesSkusResult();
					vipapis.sales.GetEndingSalesSkusResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getEndingSalesSkus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.sales.GetEndingSalesSkusResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getEndingSalesSkus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSalesList_resultHelper : TBeanSerializer<getSalesList_result>
		{
			
			public static getSalesList_resultHelper OBJ = new getSalesList_resultHelper();
			
			public static getSalesList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSalesList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.sales.GetSalesListResult value;
					
					value = new vipapis.sales.GetSalesListResult();
					vipapis.sales.GetSalesListResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSalesList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.sales.GetSalesListResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSalesList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSalesSkuList_resultHelper : TBeanSerializer<getSalesSkuList_result>
		{
			
			public static getSalesSkuList_resultHelper OBJ = new getSalesSkuList_resultHelper();
			
			public static getSalesSkuList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSalesSkuList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.sales.GetSalesSkuListResult value;
					
					value = new vipapis.sales.GetSalesSkuListResult();
					vipapis.sales.GetSalesSkuListResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSalesSkuList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.sales.GetSalesSkuListResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSalesSkuList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUpcomingSalesSkus_resultHelper : TBeanSerializer<getUpcomingSalesSkus_result>
		{
			
			public static getUpcomingSalesSkus_resultHelper OBJ = new getUpcomingSalesSkus_resultHelper();
			
			public static getUpcomingSalesSkus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUpcomingSalesSkus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.sales.GetUpcomingSalesSkusResult value;
					
					value = new vipapis.sales.GetUpcomingSalesSkusResult();
					vipapis.sales.GetUpcomingSalesSkusResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUpcomingSalesSkus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.sales.GetUpcomingSalesSkusResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUpcomingSalesSkus_result bean){
				
				
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
		
		
		
		
		public class updateSalesSkusInventory_resultHelper : TBeanSerializer<updateSalesSkusInventory_result>
		{
			
			public static updateSalesSkusInventory_resultHelper OBJ = new updateSalesSkusInventory_resultHelper();
			
			public static updateSalesSkusInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSalesSkusInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.sales.SetSkuInventoryResult value;
					
					value = new vipapis.sales.SetSkuInventoryResult();
					vipapis.sales.SetSkuInventoryResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSalesSkusInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.sales.SetSkuInventoryResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSalesSkusInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class SalesServiceClient : OspRestStub , SalesService  {
			
			
			public SalesServiceClient():base("vipapis.sales.SalesService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.sales.GetEndingSalesSkusResult getEndingSalesSkus(int vendor_id_,string brand_id_,long st_query_,long et_query_,int page_,int limit_) {
				
				send_getEndingSalesSkus(vendor_id_,brand_id_,st_query_,et_query_,page_,limit_);
				return recv_getEndingSalesSkus(); 
				
			}
			
			
			private void send_getEndingSalesSkus(int vendor_id_,string brand_id_,long st_query_,long et_query_,int page_,int limit_){
				
				InitInvocation("getEndingSalesSkus");
				
				getEndingSalesSkus_args args = new getEndingSalesSkus_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSt_query(st_query_);
				args.SetEt_query(et_query_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getEndingSalesSkus_argsHelper.getInstance());
			}
			
			
			private vipapis.sales.GetEndingSalesSkusResult recv_getEndingSalesSkus(){
				
				getEndingSalesSkus_result result = new getEndingSalesSkus_result();
				ReceiveBase(result, getEndingSalesSkus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.sales.GetSalesListResult getSalesList(int vendor_id_,long? st_query_,long? et_query_,int? page_,int? limit_) {
				
				send_getSalesList(vendor_id_,st_query_,et_query_,page_,limit_);
				return recv_getSalesList(); 
				
			}
			
			
			private void send_getSalesList(int vendor_id_,long? st_query_,long? et_query_,int? page_,int? limit_){
				
				InitInvocation("getSalesList");
				
				getSalesList_args args = new getSalesList_args();
				args.SetVendor_id(vendor_id_);
				args.SetSt_query(st_query_);
				args.SetEt_query(et_query_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getSalesList_argsHelper.getInstance());
			}
			
			
			private vipapis.sales.GetSalesListResult recv_getSalesList(){
				
				getSalesList_result result = new getSalesList_result();
				ReceiveBase(result, getSalesList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.sales.GetSalesSkuListResult getSalesSkuList(int vendor_id_,long sales_no_,int? page_,int? limit_) {
				
				send_getSalesSkuList(vendor_id_,sales_no_,page_,limit_);
				return recv_getSalesSkuList(); 
				
			}
			
			
			private void send_getSalesSkuList(int vendor_id_,long sales_no_,int? page_,int? limit_){
				
				InitInvocation("getSalesSkuList");
				
				getSalesSkuList_args args = new getSalesSkuList_args();
				args.SetVendor_id(vendor_id_);
				args.SetSales_no(sales_no_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getSalesSkuList_argsHelper.getInstance());
			}
			
			
			private vipapis.sales.GetSalesSkuListResult recv_getSalesSkuList(){
				
				getSalesSkuList_result result = new getSalesSkuList_result();
				ReceiveBase(result, getSalesSkuList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.sales.GetUpcomingSalesSkusResult getUpcomingSalesSkus(int vendor_id_,string brand_id_,int page_,int limit_) {
				
				send_getUpcomingSalesSkus(vendor_id_,brand_id_,page_,limit_);
				return recv_getUpcomingSalesSkus(); 
				
			}
			
			
			private void send_getUpcomingSalesSkus(int vendor_id_,string brand_id_,int page_,int limit_){
				
				InitInvocation("getUpcomingSalesSkus");
				
				getUpcomingSalesSkus_args args = new getUpcomingSalesSkus_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getUpcomingSalesSkus_argsHelper.getInstance());
			}
			
			
			private vipapis.sales.GetUpcomingSalesSkusResult recv_getUpcomingSalesSkus(){
				
				getUpcomingSalesSkus_result result = new getUpcomingSalesSkus_result();
				ReceiveBase(result, getUpcomingSalesSkus_resultHelper.getInstance());
				
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
			
			
			public vipapis.sales.SetSkuInventoryResult updateSalesSkusInventory(int batch_no_,int vendor_id_,bool is_full_,string warehouse_supplier_,List<vipapis.sales.BarcodeInventory> inventories_) {
				
				send_updateSalesSkusInventory(batch_no_,vendor_id_,is_full_,warehouse_supplier_,inventories_);
				return recv_updateSalesSkusInventory(); 
				
			}
			
			
			private void send_updateSalesSkusInventory(int batch_no_,int vendor_id_,bool is_full_,string warehouse_supplier_,List<vipapis.sales.BarcodeInventory> inventories_){
				
				InitInvocation("updateSalesSkusInventory");
				
				updateSalesSkusInventory_args args = new updateSalesSkusInventory_args();
				args.SetBatch_no(batch_no_);
				args.SetVendor_id(vendor_id_);
				args.SetIs_full(is_full_);
				args.SetWarehouse_supplier(warehouse_supplier_);
				args.SetInventories(inventories_);
				
				SendBase(args, updateSalesSkusInventory_argsHelper.getInstance());
			}
			
			
			private vipapis.sales.SetSkuInventoryResult recv_updateSalesSkusInventory(){
				
				updateSalesSkusInventory_result result = new updateSalesSkusInventory_result();
				ReceiveBase(result, updateSalesSkusInventory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}