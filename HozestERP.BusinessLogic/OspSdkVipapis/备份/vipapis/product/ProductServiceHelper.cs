using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.product{
	
	
	public class ProductServiceHelper {
		
		
		
		public class getProductList_args {
			
			///<summary>
			/// 仓库
			/// @sampleValue warehouse VIP_NH
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 档期ID,支持多个值,以竖线分隔
			/// @sampleValue schedule_id schedule_id=13092
			///</summary>
			
			private string schedule_id_;
			
			///<summary>
			/// 频道ID
			/// @sampleValue channel_id channel_id=4
			///</summary>
			
			private int? channel_id_;
			
			///<summary>
			/// 商品分类ID
			/// @sampleValue category_id category_id=11
			///</summary>
			
			private int? category_id_;
			
			///<summary>
			/// 查询开始时间，按开售时间sell_time_from查(格式：yyyyMMddHHmmss)
			/// @sampleValue start_time start_time=20140602160000
			///</summary>
			
			private string start_time_;
			
			///<summary>
			/// 查询结束时间，按开售时间sell_time_from查(格式：yyyyMMddHHmmss)
			/// @sampleValue end_time end_time=20140702160000
			///</summary>
			
			private string end_time_;
			
			///<summary>
			/// 商品ID,支持多个值,以竖线分隔
			/// @sampleValue product_id product_id=13593233|1564867|123545
			///</summary>
			
			private string product_id_;
			
			///<summary>
			/// 商品名称关键字
			/// @sampleValue product_name product_name="女装"
			///</summary>
			
			private string product_name_;
			
			///<summary>
			/// 销售价格区间下限
			/// @sampleValue sell_price_min sell_price_min=29
			///</summary>
			
			private int? sell_price_min_;
			
			///<summary>
			/// 销售价格区间上限
			/// @sampleValue sell_price_max sell_price_max=289
			///</summary>
			
			private int? sell_price_max_;
			
			///<summary>
			/// 销售折扣区间下限
			/// @sampleValue discount_min discount_min=0.22
			///</summary>
			
			private double? discount_min_;
			
			///<summary>
			/// 销售折扣区间上限
			/// @sampleValue discount_max discount_max=0.60
			///</summary>
			
			private double? discount_max_;
			
			///<summary>
			/// 排序ID DEFAULT=默认、DISCOUNT_DOWN=折扣降序、DISCOUNT_UP=折扣升序、PRICE_DOWN=价格降序、PRICE_UP=价格升序、SALECOUNT_DOWN=销量降序 、SALECOUNT_UP=销量升序
			/// @sampleValue sort_type SortType.SORT_DEFAULT
			///</summary>
			
			private vipapis.product.SortType? sort_type_;
			
			///<summary>
			/// SHOW_ALL=全部显示 SHOW_STOCK=只显示有库存
			/// @sampleValue stock_show_type stock_show_type=StockShowType.SHOW_ALL
			///</summary>
			
			private vipapis.product.StockShowType? stock_show_type_;
			
			///<summary>
			/// 页码，当使用cursorMark时page值是无效的，建议弃用page改用cursorMark。如果坚持使用page参数从性能考虑只能查询前100页。
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数，默认每页20条，最大每页100条
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			///<summary>
			/// 游标，强烈建议使用，用于加速翻页性能，取第一页数据时输入“*”，取下一页数据则输入当前返回的nextCursorMark的值，使用游标时page字段是失效的
			/// @sampleValue cursorMark cursorMark="AoF//Jpm"
			///</summary>
			
			private string cursorMark_;
			
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetSchedule_id(){
				return this.schedule_id_;
			}
			
			public void SetSchedule_id(string value){
				this.schedule_id_ = value;
			}
			public int? GetChannel_id(){
				return this.channel_id_;
			}
			
			public void SetChannel_id(int? value){
				this.channel_id_ = value;
			}
			public int? GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(int? value){
				this.category_id_ = value;
			}
			public string GetStart_time(){
				return this.start_time_;
			}
			
			public void SetStart_time(string value){
				this.start_time_ = value;
			}
			public string GetEnd_time(){
				return this.end_time_;
			}
			
			public void SetEnd_time(string value){
				this.end_time_ = value;
			}
			public string GetProduct_id(){
				return this.product_id_;
			}
			
			public void SetProduct_id(string value){
				this.product_id_ = value;
			}
			public string GetProduct_name(){
				return this.product_name_;
			}
			
			public void SetProduct_name(string value){
				this.product_name_ = value;
			}
			public int? GetSell_price_min(){
				return this.sell_price_min_;
			}
			
			public void SetSell_price_min(int? value){
				this.sell_price_min_ = value;
			}
			public int? GetSell_price_max(){
				return this.sell_price_max_;
			}
			
			public void SetSell_price_max(int? value){
				this.sell_price_max_ = value;
			}
			public double? GetDiscount_min(){
				return this.discount_min_;
			}
			
			public void SetDiscount_min(double? value){
				this.discount_min_ = value;
			}
			public double? GetDiscount_max(){
				return this.discount_max_;
			}
			
			public void SetDiscount_max(double? value){
				this.discount_max_ = value;
			}
			public vipapis.product.SortType? GetSort_type(){
				return this.sort_type_;
			}
			
			public void SetSort_type(vipapis.product.SortType? value){
				this.sort_type_ = value;
			}
			public vipapis.product.StockShowType? GetStock_show_type(){
				return this.stock_show_type_;
			}
			
			public void SetStock_show_type(vipapis.product.StockShowType? value){
				this.stock_show_type_ = value;
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
			public string GetCursorMark(){
				return this.cursorMark_;
			}
			
			public void SetCursorMark(string value){
				this.cursorMark_ = value;
			}
			
		}
		
		
		
		
		public class getProductStock_args {
			
			///<summary>
			/// 仓库
			/// @sampleValue warehouse VIP_NH
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 档期ID,支持多个值,以竖线分隔
			/// @sampleValue schedule_id schedule_id=13092
			///</summary>
			
			private string schedule_id_;
			
			///<summary>
			/// 频道ID
			/// @sampleValue channel_id channel_id=4
			///</summary>
			
			private int? channel_id_;
			
			///<summary>
			/// 商品分类ID
			/// @sampleValue category_id category_id=11
			///</summary>
			
			private int? category_id_;
			
			///<summary>
			/// 查询开始时间，按开售时间sell_time_from查(格式：yyyyMMddHHmmss)
			/// @sampleValue start_time start_time=20140602160000
			///</summary>
			
			private string start_time_;
			
			///<summary>
			/// 查询结束时间，按开售时间sell_time_from查(格式：yyyyMMddHHmmss)
			/// @sampleValue end_time end_time=20140702160000
			///</summary>
			
			private string end_time_;
			
			///<summary>
			/// 商品ID,支持多个值,以竖线分隔
			/// @sampleValue product_id product_id=13593233|1564867|123545
			///</summary>
			
			private string product_id_;
			
			///<summary>
			/// 商品名称关键字
			/// @sampleValue product_name product_name="女装"
			///</summary>
			
			private string product_name_;
			
			///<summary>
			/// 销售价格区间下限
			/// @sampleValue sell_price_min sell_price_min=29
			///</summary>
			
			private int? sell_price_min_;
			
			///<summary>
			/// 销售价格区间上限
			/// @sampleValue sell_price_max sell_price_max=289
			///</summary>
			
			private int? sell_price_max_;
			
			///<summary>
			/// 销售折扣区间下限
			/// @sampleValue discount_min discount_min=0.22
			///</summary>
			
			private double? discount_min_;
			
			///<summary>
			/// 销售折扣区间上限
			/// @sampleValue discount_max discount_max=0.60
			///</summary>
			
			private double? discount_max_;
			
			///<summary>
			/// 排序ID DEFAULT=默认、DISCOUNT_DOWN=折扣降序、DISCOUNT_UP=折扣升序、PRICE_DOWN=价格降序、PRICE_UP=价格升序、SALECOUNT_DOWN=销量降序 、SALECOUNT_UP=销量升序
			/// @sampleValue sort_type SortType.SORT_DEFAULT
			///</summary>
			
			private vipapis.product.SortType? sort_type_;
			
			///<summary>
			/// SHOW_ALL=全部显示 SHOW_STOCK=只显示有库存
			/// @sampleValue stock_show_type stock_show_type=StockShowType.SHOW_ALL
			///</summary>
			
			private vipapis.product.StockShowType? stock_show_type_;
			
			///<summary>
			/// 页码，当使用cursorMark时page值是无效的，建议弃用page改用cursorMark。如果坚持使用page参数从性能考虑只能查询前100页。
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数，默认每页20条，最大100条
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			///<summary>
			/// 游标，强烈建议使用，用于加速翻页性能，取第一页数据时输入“*”，取下一页数据则输入当前返回的nextCursorMark的值，使用游标时page字段是失效的
			/// @sampleValue cursorMark cursorMark="AoF//Jpm"
			///</summary>
			
			private string cursorMark_;
			
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetSchedule_id(){
				return this.schedule_id_;
			}
			
			public void SetSchedule_id(string value){
				this.schedule_id_ = value;
			}
			public int? GetChannel_id(){
				return this.channel_id_;
			}
			
			public void SetChannel_id(int? value){
				this.channel_id_ = value;
			}
			public int? GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(int? value){
				this.category_id_ = value;
			}
			public string GetStart_time(){
				return this.start_time_;
			}
			
			public void SetStart_time(string value){
				this.start_time_ = value;
			}
			public string GetEnd_time(){
				return this.end_time_;
			}
			
			public void SetEnd_time(string value){
				this.end_time_ = value;
			}
			public string GetProduct_id(){
				return this.product_id_;
			}
			
			public void SetProduct_id(string value){
				this.product_id_ = value;
			}
			public string GetProduct_name(){
				return this.product_name_;
			}
			
			public void SetProduct_name(string value){
				this.product_name_ = value;
			}
			public int? GetSell_price_min(){
				return this.sell_price_min_;
			}
			
			public void SetSell_price_min(int? value){
				this.sell_price_min_ = value;
			}
			public int? GetSell_price_max(){
				return this.sell_price_max_;
			}
			
			public void SetSell_price_max(int? value){
				this.sell_price_max_ = value;
			}
			public double? GetDiscount_min(){
				return this.discount_min_;
			}
			
			public void SetDiscount_min(double? value){
				this.discount_min_ = value;
			}
			public double? GetDiscount_max(){
				return this.discount_max_;
			}
			
			public void SetDiscount_max(double? value){
				this.discount_max_ = value;
			}
			public vipapis.product.SortType? GetSort_type(){
				return this.sort_type_;
			}
			
			public void SetSort_type(vipapis.product.SortType? value){
				this.sort_type_ = value;
			}
			public vipapis.product.StockShowType? GetStock_show_type(){
				return this.stock_show_type_;
			}
			
			public void SetStock_show_type(vipapis.product.StockShowType? value){
				this.stock_show_type_ = value;
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
			public string GetCursorMark(){
				return this.cursorMark_;
			}
			
			public void SetCursorMark(string value){
				this.cursorMark_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getProductList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.GetProductListResponse success_;
			
			public vipapis.product.GetProductListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.GetProductListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getProductStock_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.GetProductStockResponse success_;
			
			public vipapis.product.GetProductStockResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.GetProductStockResponse value){
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
		
		
		
		
		
		public class getProductList_argsHelper : BeanSerializer<getProductList_args>
		{
			
			public static getProductList_argsHelper OBJ = new getProductList_argsHelper();
			
			public static getProductList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSchedule_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetChannel_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStart_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEnd_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetProduct_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetProduct_name(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSell_price_min(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSell_price_max(value);
				}
				
				
				
				
				
				if(true){
					
					double? value;
					value = iprot.ReadDouble();
					
					structs.SetDiscount_min(value);
				}
				
				
				
				
				
				if(true){
					
					double? value;
					value = iprot.ReadDouble();
					
					structs.SetDiscount_max(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.product.SortType? value;
					
					value = vipapis.product.SortTypeUtil.FindByName(iprot.ReadString());
					
					structs.SetSort_type(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.product.StockShowType? value;
					
					value = vipapis.product.StockShowTypeUtil.FindByName(iprot.ReadString());
					
					structs.SetStock_show_type(value);
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
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCursorMark(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSchedule_id() != null) {
					
					oprot.WriteFieldBegin("schedule_id");
					oprot.WriteString(structs.GetSchedule_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetChannel_id() != null) {
					
					oprot.WriteFieldBegin("channel_id");
					oprot.WriteI32((int)structs.GetChannel_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteI32((int)structs.GetCategory_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStart_time() != null) {
					
					oprot.WriteFieldBegin("start_time");
					oprot.WriteString(structs.GetStart_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEnd_time() != null) {
					
					oprot.WriteFieldBegin("end_time");
					oprot.WriteString(structs.GetEnd_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetProduct_id() != null) {
					
					oprot.WriteFieldBegin("product_id");
					oprot.WriteString(structs.GetProduct_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetProduct_name() != null) {
					
					oprot.WriteFieldBegin("product_name");
					oprot.WriteString(structs.GetProduct_name());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSell_price_min() != null) {
					
					oprot.WriteFieldBegin("sell_price_min");
					oprot.WriteI32((int)structs.GetSell_price_min()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSell_price_max() != null) {
					
					oprot.WriteFieldBegin("sell_price_max");
					oprot.WriteI32((int)structs.GetSell_price_max()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDiscount_min() != null) {
					
					oprot.WriteFieldBegin("discount_min");
					oprot.WriteDouble((double)structs.GetDiscount_min());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDiscount_max() != null) {
					
					oprot.WriteFieldBegin("discount_max");
					oprot.WriteDouble((double)structs.GetDiscount_max());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSort_type() != null) {
					
					oprot.WriteFieldBegin("sort_type");
					oprot.WriteString(structs.GetSort_type().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStock_show_type() != null) {
					
					oprot.WriteFieldBegin("stock_show_type");
					oprot.WriteString(structs.GetStock_show_type().ToString());  
					
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
				
				
				if(structs.GetCursorMark() != null) {
					
					oprot.WriteFieldBegin("cursorMark");
					oprot.WriteString(structs.GetCursorMark());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductStock_argsHelper : BeanSerializer<getProductStock_args>
		{
			
			public static getProductStock_argsHelper OBJ = new getProductStock_argsHelper();
			
			public static getProductStock_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductStock_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSchedule_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetChannel_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStart_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEnd_time(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetProduct_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetProduct_name(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSell_price_min(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSell_price_max(value);
				}
				
				
				
				
				
				if(true){
					
					double? value;
					value = iprot.ReadDouble();
					
					structs.SetDiscount_min(value);
				}
				
				
				
				
				
				if(true){
					
					double? value;
					value = iprot.ReadDouble();
					
					structs.SetDiscount_max(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.product.SortType? value;
					
					value = vipapis.product.SortTypeUtil.FindByName(iprot.ReadString());
					
					structs.SetSort_type(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.product.StockShowType? value;
					
					value = vipapis.product.StockShowTypeUtil.FindByName(iprot.ReadString());
					
					structs.SetStock_show_type(value);
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
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCursorMark(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductStock_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSchedule_id() != null) {
					
					oprot.WriteFieldBegin("schedule_id");
					oprot.WriteString(structs.GetSchedule_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetChannel_id() != null) {
					
					oprot.WriteFieldBegin("channel_id");
					oprot.WriteI32((int)structs.GetChannel_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteI32((int)structs.GetCategory_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStart_time() != null) {
					
					oprot.WriteFieldBegin("start_time");
					oprot.WriteString(structs.GetStart_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEnd_time() != null) {
					
					oprot.WriteFieldBegin("end_time");
					oprot.WriteString(structs.GetEnd_time());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetProduct_id() != null) {
					
					oprot.WriteFieldBegin("product_id");
					oprot.WriteString(structs.GetProduct_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetProduct_name() != null) {
					
					oprot.WriteFieldBegin("product_name");
					oprot.WriteString(structs.GetProduct_name());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSell_price_min() != null) {
					
					oprot.WriteFieldBegin("sell_price_min");
					oprot.WriteI32((int)structs.GetSell_price_min()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSell_price_max() != null) {
					
					oprot.WriteFieldBegin("sell_price_max");
					oprot.WriteI32((int)structs.GetSell_price_max()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDiscount_min() != null) {
					
					oprot.WriteFieldBegin("discount_min");
					oprot.WriteDouble((double)structs.GetDiscount_min());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDiscount_max() != null) {
					
					oprot.WriteFieldBegin("discount_max");
					oprot.WriteDouble((double)structs.GetDiscount_max());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSort_type() != null) {
					
					oprot.WriteFieldBegin("sort_type");
					oprot.WriteString(structs.GetSort_type().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStock_show_type() != null) {
					
					oprot.WriteFieldBegin("stock_show_type");
					oprot.WriteString(structs.GetStock_show_type().ToString());  
					
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
				
				
				if(structs.GetCursorMark() != null) {
					
					oprot.WriteFieldBegin("cursorMark");
					oprot.WriteString(structs.GetCursorMark());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductStock_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : BeanSerializer<healthCheck_args>
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
		
		
		
		
		public class getProductList_resultHelper : BeanSerializer<getProductList_result>
		{
			
			public static getProductList_resultHelper OBJ = new getProductList_resultHelper();
			
			public static getProductList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.GetProductListResponse value;
					
					value = new vipapis.product.GetProductListResponse();
					vipapis.product.GetProductListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.GetProductListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductStock_resultHelper : BeanSerializer<getProductStock_result>
		{
			
			public static getProductStock_resultHelper OBJ = new getProductStock_resultHelper();
			
			public static getProductStock_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductStock_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.GetProductStockResponse value;
					
					value = new vipapis.product.GetProductStockResponse();
					vipapis.product.GetProductStockResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.GetProductStockResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductStock_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : BeanSerializer<healthCheck_result>
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
		
		
		
		
		public class ProductServiceClient : OspRestStub , ProductService  {
			
			
			public ProductServiceClient():base("vipapis.product.ProductService","1.0.1") {
				
				
			}
			
			
			
			public vipapis.product.GetProductListResponse getProductList(vipapis.common.Warehouse? warehouse_,string schedule_id_,int? channel_id_,int? category_id_,string start_time_,string end_time_,string product_id_,string product_name_,int? sell_price_min_,int? sell_price_max_,double? discount_min_,double? discount_max_,vipapis.product.SortType? sort_type_,vipapis.product.StockShowType? stock_show_type_,int? page_,int? limit_,string cursorMark_) {
				
				send_getProductList(warehouse_,schedule_id_,channel_id_,category_id_,start_time_,end_time_,product_id_,product_name_,sell_price_min_,sell_price_max_,discount_min_,discount_max_,sort_type_,stock_show_type_,page_,limit_,cursorMark_);
				return recv_getProductList(); 
				
			}
			
			
			private void send_getProductList(vipapis.common.Warehouse? warehouse_,string schedule_id_,int? channel_id_,int? category_id_,string start_time_,string end_time_,string product_id_,string product_name_,int? sell_price_min_,int? sell_price_max_,double? discount_min_,double? discount_max_,vipapis.product.SortType? sort_type_,vipapis.product.StockShowType? stock_show_type_,int? page_,int? limit_,string cursorMark_){
				
				InitInvocation("getProductList");
				
				getProductList_args args = new getProductList_args();
				args.SetWarehouse(warehouse_);
				args.SetSchedule_id(schedule_id_);
				args.SetChannel_id(channel_id_);
				args.SetCategory_id(category_id_);
				args.SetStart_time(start_time_);
				args.SetEnd_time(end_time_);
				args.SetProduct_id(product_id_);
				args.SetProduct_name(product_name_);
				args.SetSell_price_min(sell_price_min_);
				args.SetSell_price_max(sell_price_max_);
				args.SetDiscount_min(discount_min_);
				args.SetDiscount_max(discount_max_);
				args.SetSort_type(sort_type_);
				args.SetStock_show_type(stock_show_type_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				args.SetCursorMark(cursorMark_);
				
				SendBase(args, getProductList_argsHelper.getInstance());
			}
			
			
			private vipapis.product.GetProductListResponse recv_getProductList(){
				
				getProductList_result result = new getProductList_result();
				ReceiveBase(result, getProductList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.GetProductStockResponse getProductStock(vipapis.common.Warehouse? warehouse_,string schedule_id_,int? channel_id_,int? category_id_,string start_time_,string end_time_,string product_id_,string product_name_,int? sell_price_min_,int? sell_price_max_,double? discount_min_,double? discount_max_,vipapis.product.SortType? sort_type_,vipapis.product.StockShowType? stock_show_type_,int? page_,int? limit_,string cursorMark_) {
				
				send_getProductStock(warehouse_,schedule_id_,channel_id_,category_id_,start_time_,end_time_,product_id_,product_name_,sell_price_min_,sell_price_max_,discount_min_,discount_max_,sort_type_,stock_show_type_,page_,limit_,cursorMark_);
				return recv_getProductStock(); 
				
			}
			
			
			private void send_getProductStock(vipapis.common.Warehouse? warehouse_,string schedule_id_,int? channel_id_,int? category_id_,string start_time_,string end_time_,string product_id_,string product_name_,int? sell_price_min_,int? sell_price_max_,double? discount_min_,double? discount_max_,vipapis.product.SortType? sort_type_,vipapis.product.StockShowType? stock_show_type_,int? page_,int? limit_,string cursorMark_){
				
				InitInvocation("getProductStock");
				
				getProductStock_args args = new getProductStock_args();
				args.SetWarehouse(warehouse_);
				args.SetSchedule_id(schedule_id_);
				args.SetChannel_id(channel_id_);
				args.SetCategory_id(category_id_);
				args.SetStart_time(start_time_);
				args.SetEnd_time(end_time_);
				args.SetProduct_id(product_id_);
				args.SetProduct_name(product_name_);
				args.SetSell_price_min(sell_price_min_);
				args.SetSell_price_max(sell_price_max_);
				args.SetDiscount_min(discount_min_);
				args.SetDiscount_max(discount_max_);
				args.SetSort_type(sort_type_);
				args.SetStock_show_type(stock_show_type_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				args.SetCursorMark(cursorMark_);
				
				SendBase(args, getProductStock_argsHelper.getInstance());
			}
			
			
			private vipapis.product.GetProductStockResponse recv_getProductStock(){
				
				getProductStock_result result = new getProductStock_result();
				ReceiveBase(result, getProductStock_resultHelper.getInstance());
				
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