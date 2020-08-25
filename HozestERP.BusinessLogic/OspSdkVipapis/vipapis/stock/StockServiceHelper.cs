using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.stock{
	
	
	public class StockServiceHelper {
		
		
		
		public class addWarehouseInfo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 新增单
			/// @sampleValue add_warehouse_list 
			///</summary>
			
			private List<vipapis.stock.AddWarehouseInfo> add_warehouse_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.stock.AddWarehouseInfo> GetAdd_warehouse_list(){
				return this.add_warehouse_list_;
			}
			
			public void SetAdd_warehouse_list(List<vipapis.stock.AddWarehouseInfo> value){
				this.add_warehouse_list_ = value;
			}
			
		}
		
		
		
		
		public class confirmFrozenInventory_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 冻结批次号
			/// @sampleValue frozen_trans_id 
			///</summary>
			
			private int? frozen_trans_id_;
			
			///<summary>
			/// 仓库类型,462：JIT 463：OXO
			/// @sampleValue inventory_type 462
			///</summary>
			
			private int? inventory_type_;
			
			///<summary>
			/// 确认冻结库存列表
			/// @sampleValue confirm_frozen_inventory_list 
			///</summary>
			
			private List<vipapis.stock.ConfirmFrozenInventory> confirm_frozen_inventory_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetFrozen_trans_id(){
				return this.frozen_trans_id_;
			}
			
			public void SetFrozen_trans_id(int? value){
				this.frozen_trans_id_ = value;
			}
			public int? GetInventory_type(){
				return this.inventory_type_;
			}
			
			public void SetInventory_type(int? value){
				this.inventory_type_ = value;
			}
			public List<vipapis.stock.ConfirmFrozenInventory> GetConfirm_frozen_inventory_list(){
				return this.confirm_frozen_inventory_list_;
			}
			
			public void SetConfirm_frozen_inventory_list(List<vipapis.stock.ConfirmFrozenInventory> value){
				this.confirm_frozen_inventory_list_ = value;
			}
			
		}
		
		
		
		
		public class confirmUnfrozenInventory_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 冻结批次号
			/// @sampleValue frozen_trans_ids 154
			///</summary>
			
			private List<int?> frozen_trans_ids_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<int?> GetFrozen_trans_ids(){
				return this.frozen_trans_ids_;
			}
			
			public void SetFrozen_trans_ids(List<int?> value){
				this.frozen_trans_ids_ = value;
			}
			
		}
		
		
		
		
		public class delWarehouseInfo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 仓库编号
			/// @sampleValue vendor_warehouse_id_list 
			///</summary>
			
			private List<vipapis.stock.InputWarehouseInfo> vendor_warehouse_id_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.stock.InputWarehouseInfo> GetVendor_warehouse_id_list(){
				return this.vendor_warehouse_id_list_;
			}
			
			public void SetVendor_warehouse_id_list(List<vipapis.stock.InputWarehouseInfo> value){
				this.vendor_warehouse_id_list_ = value;
			}
			
		}
		
		
		
		
		public class getFreezeStockTransId_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 是否冻结,1:冻结，2:解冻
			/// @sampleValue frozeType 1
			///</summary>
			
			private int? frozeType_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetFrozeType(){
				return this.frozeType_;
			}
			
			public void SetFrozeType(int? value){
				this.frozeType_ = value;
			}
			
		}
		
		
		
		
		public class getFreezingStockDetails_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 冻结批次号
			/// @sampleValue frozen_trans_id 
			///</summary>
			
			private int? frozen_trans_id_;
			
			///<summary>
			/// 页码
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			/// @sampleValue limit limit=50
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetFrozen_trans_id(){
				return this.frozen_trans_id_;
			}
			
			public void SetFrozen_trans_id(int? value){
				this.frozen_trans_id_ = value;
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
		
		
		
		
		public class getOxoShopOrderForJit_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 唯品会仓库编码
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 仓库编码/门店编号
			///</summary>
			
			private string vendor_warehouse_id_;
			
			///<summary>
			/// 起始下单时间
			///</summary>
			
			private string start_date_;
			
			///<summary>
			/// 截止下单时间
			///</summary>
			
			private string end_date_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数,建议不超过100条
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetVendor_warehouse_id(){
				return this.vendor_warehouse_id_;
			}
			
			public void SetVendor_warehouse_id(string value){
				this.vendor_warehouse_id_ = value;
			}
			public string GetStart_date(){
				return this.start_date_;
			}
			
			public void SetStart_date(string value){
				this.start_date_ = value;
			}
			public string GetEnd_date(){
				return this.end_date_;
			}
			
			public void SetEnd_date(string value){
				this.end_date_ = value;
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
		
		
		
		
		public class getOxoShopOrderForPop_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 唯品会仓库编码
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 仓库编码/门店编号
			///</summary>
			
			private string vendor_warehouse_id_;
			
			///<summary>
			/// 起始下单时间
			///</summary>
			
			private string start_date_;
			
			///<summary>
			/// 截止下单时间
			///</summary>
			
			private string end_date_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数,建议不超过100条
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetVendor_warehouse_id(){
				return this.vendor_warehouse_id_;
			}
			
			public void SetVendor_warehouse_id(string value){
				this.vendor_warehouse_id_ = value;
			}
			public string GetStart_date(){
				return this.start_date_;
			}
			
			public void SetStart_date(string value){
				this.start_date_ = value;
			}
			public string GetEnd_date(){
				return this.end_date_;
			}
			
			public void SetEnd_date(string value){
				this.end_date_ = value;
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
		
		
		
		
		public class getPoNoFrozenTransIdRelationship_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 冻结批次号与采购编号必填其一
			/// @sampleValue frozen_trans_id 
			///</summary>
			
			private int? frozen_trans_id_;
			
			///<summary>
			/// 采购编号与冻结批次号必填其一
			/// @sampleValue po_no 
			///</summary>
			
			private string po_no_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetFrozen_trans_id(){
				return this.frozen_trans_id_;
			}
			
			public void SetFrozen_trans_id(int? value){
				this.frozen_trans_id_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			
		}
		
		
		
		
		public class getVendorScheduleFreezeStock_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 仓库编号
			/// @sampleValue get_vendor_schedule_freeze_stock 
			///</summary>
			
			private vipapis.stock.GetVendorScheduleFreezeStock get_vendor_schedule_freeze_stock_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.stock.GetVendorScheduleFreezeStock GetGet_vendor_schedule_freeze_stock(){
				return this.get_vendor_schedule_freeze_stock_;
			}
			
			public void SetGet_vendor_schedule_freeze_stock(vipapis.stock.GetVendorScheduleFreezeStock value){
				this.get_vendor_schedule_freeze_stock_ = value;
			}
			
		}
		
		
		
		
		public class getWarehouseInfo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 仓库编号（仓库编号、唯品会仓库编码必填一个）
			///</summary>
			
			private string vendor_warehouse_id_;
			
			///<summary>
			/// 唯品会仓库编码（仓库编号、唯品会仓库编码必填一个）
			///</summary>
			
			private vipapis.common.Warehouse? vip_warehouse_code_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetVendor_warehouse_id(){
				return this.vendor_warehouse_id_;
			}
			
			public void SetVendor_warehouse_id(string value){
				this.vendor_warehouse_id_ = value;
			}
			public vipapis.common.Warehouse? GetVip_warehouse_code(){
				return this.vip_warehouse_code_;
			}
			
			public void SetVip_warehouse_code(vipapis.common.Warehouse? value){
				this.vip_warehouse_code_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateVendorWarehouseAndVIPWarehouseMap_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 接口参数集合
			/// @sampleValue update_warehousemap_list 
			///</summary>
			
			private List<vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap> update_warehousemap_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap> GetUpdate_warehousemap_list(){
				return this.update_warehousemap_list_;
			}
			
			public void SetUpdate_warehousemap_list(List<vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap> value){
				this.update_warehousemap_list_ = value;
			}
			
		}
		
		
		
		
		public class updateWarehouseInfo_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 仓库信息列表
			/// @sampleValue update_warehouse_list 
			///</summary>
			
			private List<vipapis.stock.UpdateWarehouseInfo> update_warehouse_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.stock.UpdateWarehouseInfo> GetUpdate_warehouse_list(){
				return this.update_warehouse_list_;
			}
			
			public void SetUpdate_warehouse_list(List<vipapis.stock.UpdateWarehouseInfo> value){
				this.update_warehouse_list_ = value;
			}
			
		}
		
		
		
		
		public class updateWarehouseInventory_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 库存明细列表
			///</summary>
			
			private List<vipapis.stock.UpdateWarehouseInventory> update_warehouse_inventory_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.stock.UpdateWarehouseInventory> GetUpdate_warehouse_inventory_list(){
				return this.update_warehouse_inventory_list_;
			}
			
			public void SetUpdate_warehouse_inventory_list(List<vipapis.stock.UpdateWarehouseInventory> value){
				this.update_warehouse_inventory_list_ = value;
			}
			
		}
		
		
		
		
		public class addWarehouseInfo_result {
			
			///<summary>
			/// 集合
			///</summary>
			
			private List<vipapis.stock.AddWarehouseInfoResult> success_;
			
			public List<vipapis.stock.AddWarehouseInfoResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.stock.AddWarehouseInfoResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class confirmFrozenInventory_result {
			
			///<summary>
			/// 确认是否成功
			///</summary>
			
			private vipapis.stock.ConfirmFrozenInventoryResponse success_;
			
			public vipapis.stock.ConfirmFrozenInventoryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.stock.ConfirmFrozenInventoryResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class confirmUnfrozenInventory_result {
			
			///<summary>
			/// 库存解冻确认是否成功
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class delWarehouseInfo_result {
			
			///<summary>
			/// 仓库信息删除处理结果
			///</summary>
			
			private List<vipapis.stock.DelResult> success_;
			
			public List<vipapis.stock.DelResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.stock.DelResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getFreezeStockTransId_result {
			
			///<summary>
			/// 冻结/解冻的批次号列表
			///</summary>
			
			private List<vipapis.stock.FreezeTransIdAndInventoryType> success_;
			
			public List<vipapis.stock.FreezeTransIdAndInventoryType> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.stock.FreezeTransIdAndInventoryType> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getFreezingStockDetails_result {
			
			///<summary>
			/// 已冻结的库存列表
			///</summary>
			
			private vipapis.stock.GetFrozenStockDetailsResponse success_;
			
			public vipapis.stock.GetFrozenStockDetailsResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.stock.GetFrozenStockDetailsResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOxoShopOrderForJit_result {
			
			///<summary>
			/// JIT门店订单信息查询
			///</summary>
			
			private vipapis.stock.GetOxoShopOrderForJitResponse success_;
			
			public vipapis.stock.GetOxoShopOrderForJitResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.stock.GetOxoShopOrderForJitResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOxoShopOrderForPop_result {
			
			///<summary>
			/// 直发门店订单信息查询
			///</summary>
			
			private vipapis.stock.GetOxoShopOrderForPopResponse success_;
			
			public vipapis.stock.GetOxoShopOrderForPopResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.stock.GetOxoShopOrderForPopResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPoNoFrozenTransIdRelationship_result {
			
			///<summary>
			/// 采购编号与批次号的关系
			///</summary>
			
			private vipapis.stock.PoNoFrozenTransIdRelationShip success_;
			
			public vipapis.stock.PoNoFrozenTransIdRelationShip GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.stock.PoNoFrozenTransIdRelationShip value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getVendorScheduleFreezeStock_result {
			
			///<summary>
			/// 获取供应商档期门店锁定库存
			///</summary>
			
			private List<vipapis.stock.GetVendorScheduleFreezeStockResult> success_;
			
			public List<vipapis.stock.GetVendorScheduleFreezeStockResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.stock.GetVendorScheduleFreezeStockResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getWarehouseInfo_result {
			
			///<summary>
			/// 仓库基础信息
			///</summary>
			
			private vipapis.stock.GetWarehouseInfoResponse success_;
			
			public vipapis.stock.GetWarehouseInfoResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.stock.GetWarehouseInfoResponse value){
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
		
		
		
		
		public class updateVendorWarehouseAndVIPWarehouseMap_result {
			
			///<summary>
			/// 集合 供应商仓库与唯品会仓库的更新
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateWarehouseInfo_result {
			
			///<summary>
			/// 集合
			///</summary>
			
			private List<vipapis.stock.UpdateWarehouseInfoResult> success_;
			
			public List<vipapis.stock.UpdateWarehouseInfoResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.stock.UpdateWarehouseInfoResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateWarehouseInventory_result {
			
			///<summary>
			/// 库存更新结果集
			///</summary>
			
			private vipapis.stock.UpdateWarehouseInventoryResponse success_;
			
			public vipapis.stock.UpdateWarehouseInventoryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.stock.UpdateWarehouseInventoryResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class addWarehouseInfo_argsHelper : TBeanSerializer<addWarehouseInfo_args>
		{
			
			public static addWarehouseInfo_argsHelper OBJ = new addWarehouseInfo_argsHelper();
			
			public static addWarehouseInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addWarehouseInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.stock.AddWarehouseInfo> value;
					
					value = new List<vipapis.stock.AddWarehouseInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.AddWarehouseInfo elem1;
							
							elem1 = new vipapis.stock.AddWarehouseInfo();
							vipapis.stock.AddWarehouseInfoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetAdd_warehouse_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addWarehouseInfo_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetAdd_warehouse_list() != null) {
					
					oprot.WriteFieldBegin("add_warehouse_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.AddWarehouseInfo _item0 in structs.GetAdd_warehouse_list()){
						
						
						vipapis.stock.AddWarehouseInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("add_warehouse_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addWarehouseInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmFrozenInventory_argsHelper : TBeanSerializer<confirmFrozenInventory_args>
		{
			
			public static confirmFrozenInventory_argsHelper OBJ = new confirmFrozenInventory_argsHelper();
			
			public static confirmFrozenInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmFrozenInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetFrozen_trans_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetInventory_type(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.stock.ConfirmFrozenInventory> value;
					
					value = new List<vipapis.stock.ConfirmFrozenInventory>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.ConfirmFrozenInventory elem1;
							
							elem1 = new vipapis.stock.ConfirmFrozenInventory();
							vipapis.stock.ConfirmFrozenInventoryHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetConfirm_frozen_inventory_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmFrozenInventory_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetFrozen_trans_id() != null) {
					
					oprot.WriteFieldBegin("frozen_trans_id");
					oprot.WriteI32((int)structs.GetFrozen_trans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("frozen_trans_id can not be null!");
				}
				
				
				if(structs.GetInventory_type() != null) {
					
					oprot.WriteFieldBegin("inventory_type");
					oprot.WriteI32((int)structs.GetInventory_type()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("inventory_type can not be null!");
				}
				
				
				if(structs.GetConfirm_frozen_inventory_list() != null) {
					
					oprot.WriteFieldBegin("confirm_frozen_inventory_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.ConfirmFrozenInventory _item0 in structs.GetConfirm_frozen_inventory_list()){
						
						
						vipapis.stock.ConfirmFrozenInventoryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("confirm_frozen_inventory_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmFrozenInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmUnfrozenInventory_argsHelper : TBeanSerializer<confirmUnfrozenInventory_args>
		{
			
			public static confirmUnfrozenInventory_argsHelper OBJ = new confirmUnfrozenInventory_argsHelper();
			
			public static confirmUnfrozenInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmUnfrozenInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<int?> value;
					
					value = new List<int?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							int elem1;
							elem1 = iprot.ReadI32(); 
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetFrozen_trans_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmUnfrozenInventory_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetFrozen_trans_ids() != null) {
					
					oprot.WriteFieldBegin("frozen_trans_ids");
					
					oprot.WriteListBegin();
					foreach(int _item0 in structs.GetFrozen_trans_ids()){
						
						oprot.WriteI32((int)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("frozen_trans_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmUnfrozenInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class delWarehouseInfo_argsHelper : TBeanSerializer<delWarehouseInfo_args>
		{
			
			public static delWarehouseInfo_argsHelper OBJ = new delWarehouseInfo_argsHelper();
			
			public static delWarehouseInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(delWarehouseInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.stock.InputWarehouseInfo> value;
					
					value = new List<vipapis.stock.InputWarehouseInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.InputWarehouseInfo elem1;
							
							elem1 = new vipapis.stock.InputWarehouseInfo();
							vipapis.stock.InputWarehouseInfoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetVendor_warehouse_id_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(delWarehouseInfo_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetVendor_warehouse_id_list() != null) {
					
					oprot.WriteFieldBegin("vendor_warehouse_id_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.InputWarehouseInfo _item0 in structs.GetVendor_warehouse_id_list()){
						
						
						vipapis.stock.InputWarehouseInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_warehouse_id_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(delWarehouseInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getFreezeStockTransId_argsHelper : TBeanSerializer<getFreezeStockTransId_args>
		{
			
			public static getFreezeStockTransId_argsHelper OBJ = new getFreezeStockTransId_argsHelper();
			
			public static getFreezeStockTransId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFreezeStockTransId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetFrozeType(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getFreezeStockTransId_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetFrozeType() != null) {
					
					oprot.WriteFieldBegin("frozeType");
					oprot.WriteI32((int)structs.GetFrozeType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("frozeType can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getFreezeStockTransId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getFreezingStockDetails_argsHelper : TBeanSerializer<getFreezingStockDetails_args>
		{
			
			public static getFreezingStockDetails_argsHelper OBJ = new getFreezingStockDetails_argsHelper();
			
			public static getFreezingStockDetails_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFreezingStockDetails_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetFrozen_trans_id(value);
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
			
			
			public void Write(getFreezingStockDetails_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetFrozen_trans_id() != null) {
					
					oprot.WriteFieldBegin("frozen_trans_id");
					oprot.WriteI32((int)structs.GetFrozen_trans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("frozen_trans_id can not be null!");
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
			
			
			public void Validate(getFreezingStockDetails_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOxoShopOrderForJit_argsHelper : TBeanSerializer<getOxoShopOrderForJit_args>
		{
			
			public static getOxoShopOrderForJit_argsHelper OBJ = new getOxoShopOrderForJit_argsHelper();
			
			public static getOxoShopOrderForJit_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOxoShopOrderForJit_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_warehouse_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStart_date(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEnd_date(value);
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
			
			
			public void Write(getOxoShopOrderForJit_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetVendor_warehouse_id() != null) {
					
					oprot.WriteFieldBegin("vendor_warehouse_id");
					oprot.WriteString(structs.GetVendor_warehouse_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_warehouse_id can not be null!");
				}
				
				
				if(structs.GetStart_date() != null) {
					
					oprot.WriteFieldBegin("start_date");
					oprot.WriteString(structs.GetStart_date());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEnd_date() != null) {
					
					oprot.WriteFieldBegin("end_date");
					oprot.WriteString(structs.GetEnd_date());
					
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
			
			
			public void Validate(getOxoShopOrderForJit_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOxoShopOrderForPop_argsHelper : TBeanSerializer<getOxoShopOrderForPop_args>
		{
			
			public static getOxoShopOrderForPop_argsHelper OBJ = new getOxoShopOrderForPop_argsHelper();
			
			public static getOxoShopOrderForPop_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOxoShopOrderForPop_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_warehouse_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStart_date(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEnd_date(value);
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
			
			
			public void Write(getOxoShopOrderForPop_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetVendor_warehouse_id() != null) {
					
					oprot.WriteFieldBegin("vendor_warehouse_id");
					oprot.WriteString(structs.GetVendor_warehouse_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_warehouse_id can not be null!");
				}
				
				
				if(structs.GetStart_date() != null) {
					
					oprot.WriteFieldBegin("start_date");
					oprot.WriteString(structs.GetStart_date());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEnd_date() != null) {
					
					oprot.WriteFieldBegin("end_date");
					oprot.WriteString(structs.GetEnd_date());
					
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
			
			
			public void Validate(getOxoShopOrderForPop_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoNoFrozenTransIdRelationship_argsHelper : TBeanSerializer<getPoNoFrozenTransIdRelationship_args>
		{
			
			public static getPoNoFrozenTransIdRelationship_argsHelper OBJ = new getPoNoFrozenTransIdRelationship_argsHelper();
			
			public static getPoNoFrozenTransIdRelationship_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoNoFrozenTransIdRelationship_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetFrozen_trans_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoNoFrozenTransIdRelationship_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetFrozen_trans_id() != null) {
					
					oprot.WriteFieldBegin("frozen_trans_id");
					oprot.WriteI32((int)structs.GetFrozen_trans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoNoFrozenTransIdRelationship_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVendorScheduleFreezeStock_argsHelper : TBeanSerializer<getVendorScheduleFreezeStock_args>
		{
			
			public static getVendorScheduleFreezeStock_argsHelper OBJ = new getVendorScheduleFreezeStock_argsHelper();
			
			public static getVendorScheduleFreezeStock_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVendorScheduleFreezeStock_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.stock.GetVendorScheduleFreezeStock value;
					
					value = new vipapis.stock.GetVendorScheduleFreezeStock();
					vipapis.stock.GetVendorScheduleFreezeStockHelper.getInstance().Read(value, iprot);
					
					structs.SetGet_vendor_schedule_freeze_stock(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getVendorScheduleFreezeStock_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetGet_vendor_schedule_freeze_stock() != null) {
					
					oprot.WriteFieldBegin("get_vendor_schedule_freeze_stock");
					
					vipapis.stock.GetVendorScheduleFreezeStockHelper.getInstance().Write(structs.GetGet_vendor_schedule_freeze_stock(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVendorScheduleFreezeStock_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getWarehouseInfo_argsHelper : TBeanSerializer<getWarehouseInfo_args>
		{
			
			public static getWarehouseInfo_argsHelper OBJ = new getWarehouseInfo_argsHelper();
			
			public static getWarehouseInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getWarehouseInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_warehouse_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetVip_warehouse_code(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getWarehouseInfo_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetVendor_warehouse_id() != null) {
					
					oprot.WriteFieldBegin("vendor_warehouse_id");
					oprot.WriteString(structs.GetVendor_warehouse_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetVip_warehouse_code() != null) {
					
					oprot.WriteFieldBegin("vip_warehouse_code");
					oprot.WriteString(structs.GetVip_warehouse_code().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getWarehouseInfo_args bean){
				
				
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
		
		
		
		
		public class updateVendorWarehouseAndVIPWarehouseMap_argsHelper : TBeanSerializer<updateVendorWarehouseAndVIPWarehouseMap_args>
		{
			
			public static updateVendorWarehouseAndVIPWarehouseMap_argsHelper OBJ = new updateVendorWarehouseAndVIPWarehouseMap_argsHelper();
			
			public static updateVendorWarehouseAndVIPWarehouseMap_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateVendorWarehouseAndVIPWarehouseMap_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap> value;
					
					value = new List<vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap elem0;
							
							elem0 = new vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap();
							vipapis.stock.updateVendorWarehouseAndVIPWarehouseMapHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetUpdate_warehousemap_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateVendorWarehouseAndVIPWarehouseMap_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetUpdate_warehousemap_list() != null) {
					
					oprot.WriteFieldBegin("update_warehousemap_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap _item0 in structs.GetUpdate_warehousemap_list()){
						
						
						vipapis.stock.updateVendorWarehouseAndVIPWarehouseMapHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("update_warehousemap_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateVendorWarehouseAndVIPWarehouseMap_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateWarehouseInfo_argsHelper : TBeanSerializer<updateWarehouseInfo_args>
		{
			
			public static updateWarehouseInfo_argsHelper OBJ = new updateWarehouseInfo_argsHelper();
			
			public static updateWarehouseInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateWarehouseInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.stock.UpdateWarehouseInfo> value;
					
					value = new List<vipapis.stock.UpdateWarehouseInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.UpdateWarehouseInfo elem1;
							
							elem1 = new vipapis.stock.UpdateWarehouseInfo();
							vipapis.stock.UpdateWarehouseInfoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetUpdate_warehouse_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateWarehouseInfo_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetUpdate_warehouse_list() != null) {
					
					oprot.WriteFieldBegin("update_warehouse_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.UpdateWarehouseInfo _item0 in structs.GetUpdate_warehouse_list()){
						
						
						vipapis.stock.UpdateWarehouseInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("update_warehouse_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateWarehouseInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateWarehouseInventory_argsHelper : TBeanSerializer<updateWarehouseInventory_args>
		{
			
			public static updateWarehouseInventory_argsHelper OBJ = new updateWarehouseInventory_argsHelper();
			
			public static updateWarehouseInventory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateWarehouseInventory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.stock.UpdateWarehouseInventory> value;
					
					value = new List<vipapis.stock.UpdateWarehouseInventory>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.UpdateWarehouseInventory elem1;
							
							elem1 = new vipapis.stock.UpdateWarehouseInventory();
							vipapis.stock.UpdateWarehouseInventoryHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetUpdate_warehouse_inventory_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateWarehouseInventory_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetUpdate_warehouse_inventory_list() != null) {
					
					oprot.WriteFieldBegin("update_warehouse_inventory_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.UpdateWarehouseInventory _item0 in structs.GetUpdate_warehouse_inventory_list()){
						
						
						vipapis.stock.UpdateWarehouseInventoryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("update_warehouse_inventory_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateWarehouseInventory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addWarehouseInfo_resultHelper : TBeanSerializer<addWarehouseInfo_result>
		{
			
			public static addWarehouseInfo_resultHelper OBJ = new addWarehouseInfo_resultHelper();
			
			public static addWarehouseInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addWarehouseInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.stock.AddWarehouseInfoResult> value;
					
					value = new List<vipapis.stock.AddWarehouseInfoResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.AddWarehouseInfoResult elem1;
							
							elem1 = new vipapis.stock.AddWarehouseInfoResult();
							vipapis.stock.AddWarehouseInfoResultHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(addWarehouseInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.AddWarehouseInfoResult _item0 in structs.GetSuccess()){
						
						
						vipapis.stock.AddWarehouseInfoResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addWarehouseInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmFrozenInventory_resultHelper : TBeanSerializer<confirmFrozenInventory_result>
		{
			
			public static confirmFrozenInventory_resultHelper OBJ = new confirmFrozenInventory_resultHelper();
			
			public static confirmFrozenInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmFrozenInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.stock.ConfirmFrozenInventoryResponse value;
					
					value = new vipapis.stock.ConfirmFrozenInventoryResponse();
					vipapis.stock.ConfirmFrozenInventoryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmFrozenInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.stock.ConfirmFrozenInventoryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmFrozenInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmUnfrozenInventory_resultHelper : TBeanSerializer<confirmUnfrozenInventory_result>
		{
			
			public static confirmUnfrozenInventory_resultHelper OBJ = new confirmUnfrozenInventory_resultHelper();
			
			public static confirmUnfrozenInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmUnfrozenInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmUnfrozenInventory_result structs, Protocol oprot){
				
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
			
			
			public void Validate(confirmUnfrozenInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class delWarehouseInfo_resultHelper : TBeanSerializer<delWarehouseInfo_result>
		{
			
			public static delWarehouseInfo_resultHelper OBJ = new delWarehouseInfo_resultHelper();
			
			public static delWarehouseInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(delWarehouseInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.stock.DelResult> value;
					
					value = new List<vipapis.stock.DelResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.DelResult elem0;
							
							elem0 = new vipapis.stock.DelResult();
							vipapis.stock.DelResultHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(delWarehouseInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.DelResult _item0 in structs.GetSuccess()){
						
						
						vipapis.stock.DelResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(delWarehouseInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getFreezeStockTransId_resultHelper : TBeanSerializer<getFreezeStockTransId_result>
		{
			
			public static getFreezeStockTransId_resultHelper OBJ = new getFreezeStockTransId_resultHelper();
			
			public static getFreezeStockTransId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFreezeStockTransId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.stock.FreezeTransIdAndInventoryType> value;
					
					value = new List<vipapis.stock.FreezeTransIdAndInventoryType>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.FreezeTransIdAndInventoryType elem1;
							
							elem1 = new vipapis.stock.FreezeTransIdAndInventoryType();
							vipapis.stock.FreezeTransIdAndInventoryTypeHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getFreezeStockTransId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.FreezeTransIdAndInventoryType _item0 in structs.GetSuccess()){
						
						
						vipapis.stock.FreezeTransIdAndInventoryTypeHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getFreezeStockTransId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getFreezingStockDetails_resultHelper : TBeanSerializer<getFreezingStockDetails_result>
		{
			
			public static getFreezingStockDetails_resultHelper OBJ = new getFreezingStockDetails_resultHelper();
			
			public static getFreezingStockDetails_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFreezingStockDetails_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.stock.GetFrozenStockDetailsResponse value;
					
					value = new vipapis.stock.GetFrozenStockDetailsResponse();
					vipapis.stock.GetFrozenStockDetailsResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getFreezingStockDetails_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.stock.GetFrozenStockDetailsResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getFreezingStockDetails_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOxoShopOrderForJit_resultHelper : TBeanSerializer<getOxoShopOrderForJit_result>
		{
			
			public static getOxoShopOrderForJit_resultHelper OBJ = new getOxoShopOrderForJit_resultHelper();
			
			public static getOxoShopOrderForJit_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOxoShopOrderForJit_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.stock.GetOxoShopOrderForJitResponse value;
					
					value = new vipapis.stock.GetOxoShopOrderForJitResponse();
					vipapis.stock.GetOxoShopOrderForJitResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOxoShopOrderForJit_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.stock.GetOxoShopOrderForJitResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOxoShopOrderForJit_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOxoShopOrderForPop_resultHelper : TBeanSerializer<getOxoShopOrderForPop_result>
		{
			
			public static getOxoShopOrderForPop_resultHelper OBJ = new getOxoShopOrderForPop_resultHelper();
			
			public static getOxoShopOrderForPop_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOxoShopOrderForPop_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.stock.GetOxoShopOrderForPopResponse value;
					
					value = new vipapis.stock.GetOxoShopOrderForPopResponse();
					vipapis.stock.GetOxoShopOrderForPopResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOxoShopOrderForPop_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.stock.GetOxoShopOrderForPopResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOxoShopOrderForPop_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoNoFrozenTransIdRelationship_resultHelper : TBeanSerializer<getPoNoFrozenTransIdRelationship_result>
		{
			
			public static getPoNoFrozenTransIdRelationship_resultHelper OBJ = new getPoNoFrozenTransIdRelationship_resultHelper();
			
			public static getPoNoFrozenTransIdRelationship_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoNoFrozenTransIdRelationship_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.stock.PoNoFrozenTransIdRelationShip value;
					
					value = new vipapis.stock.PoNoFrozenTransIdRelationShip();
					vipapis.stock.PoNoFrozenTransIdRelationShipHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoNoFrozenTransIdRelationship_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.stock.PoNoFrozenTransIdRelationShipHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoNoFrozenTransIdRelationship_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVendorScheduleFreezeStock_resultHelper : TBeanSerializer<getVendorScheduleFreezeStock_result>
		{
			
			public static getVendorScheduleFreezeStock_resultHelper OBJ = new getVendorScheduleFreezeStock_resultHelper();
			
			public static getVendorScheduleFreezeStock_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVendorScheduleFreezeStock_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.stock.GetVendorScheduleFreezeStockResult> value;
					
					value = new List<vipapis.stock.GetVendorScheduleFreezeStockResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.GetVendorScheduleFreezeStockResult elem0;
							
							elem0 = new vipapis.stock.GetVendorScheduleFreezeStockResult();
							vipapis.stock.GetVendorScheduleFreezeStockResultHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getVendorScheduleFreezeStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.GetVendorScheduleFreezeStockResult _item0 in structs.GetSuccess()){
						
						
						vipapis.stock.GetVendorScheduleFreezeStockResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVendorScheduleFreezeStock_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getWarehouseInfo_resultHelper : TBeanSerializer<getWarehouseInfo_result>
		{
			
			public static getWarehouseInfo_resultHelper OBJ = new getWarehouseInfo_resultHelper();
			
			public static getWarehouseInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getWarehouseInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.stock.GetWarehouseInfoResponse value;
					
					value = new vipapis.stock.GetWarehouseInfoResponse();
					vipapis.stock.GetWarehouseInfoResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getWarehouseInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.stock.GetWarehouseInfoResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getWarehouseInfo_result bean){
				
				
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
		
		
		
		
		public class updateVendorWarehouseAndVIPWarehouseMap_resultHelper : TBeanSerializer<updateVendorWarehouseAndVIPWarehouseMap_result>
		{
			
			public static updateVendorWarehouseAndVIPWarehouseMap_resultHelper OBJ = new updateVendorWarehouseAndVIPWarehouseMap_resultHelper();
			
			public static updateVendorWarehouseAndVIPWarehouseMap_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateVendorWarehouseAndVIPWarehouseMap_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateVendorWarehouseAndVIPWarehouseMap_result structs, Protocol oprot){
				
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
			
			
			public void Validate(updateVendorWarehouseAndVIPWarehouseMap_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateWarehouseInfo_resultHelper : TBeanSerializer<updateWarehouseInfo_result>
		{
			
			public static updateWarehouseInfo_resultHelper OBJ = new updateWarehouseInfo_resultHelper();
			
			public static updateWarehouseInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateWarehouseInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.stock.UpdateWarehouseInfoResult> value;
					
					value = new List<vipapis.stock.UpdateWarehouseInfoResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.stock.UpdateWarehouseInfoResult elem0;
							
							elem0 = new vipapis.stock.UpdateWarehouseInfoResult();
							vipapis.stock.UpdateWarehouseInfoResultHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(updateWarehouseInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.stock.UpdateWarehouseInfoResult _item0 in structs.GetSuccess()){
						
						
						vipapis.stock.UpdateWarehouseInfoResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateWarehouseInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateWarehouseInventory_resultHelper : TBeanSerializer<updateWarehouseInventory_result>
		{
			
			public static updateWarehouseInventory_resultHelper OBJ = new updateWarehouseInventory_resultHelper();
			
			public static updateWarehouseInventory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateWarehouseInventory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.stock.UpdateWarehouseInventoryResponse value;
					
					value = new vipapis.stock.UpdateWarehouseInventoryResponse();
					vipapis.stock.UpdateWarehouseInventoryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateWarehouseInventory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.stock.UpdateWarehouseInventoryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateWarehouseInventory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class StockServiceClient : OspRestStub , StockService  {
			
			
			public StockServiceClient():base("vipapis.stock.StockService","1.0.0") {
				
				
			}
			
			
			
			public List<vipapis.stock.AddWarehouseInfoResult> addWarehouseInfo(int vendor_id_,List<vipapis.stock.AddWarehouseInfo> add_warehouse_list_) {
				
				send_addWarehouseInfo(vendor_id_,add_warehouse_list_);
				return recv_addWarehouseInfo(); 
				
			}
			
			
			private void send_addWarehouseInfo(int vendor_id_,List<vipapis.stock.AddWarehouseInfo> add_warehouse_list_){
				
				InitInvocation("addWarehouseInfo");
				
				addWarehouseInfo_args args = new addWarehouseInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetAdd_warehouse_list(add_warehouse_list_);
				
				SendBase(args, addWarehouseInfo_argsHelper.getInstance());
			}
			
			
			private List<vipapis.stock.AddWarehouseInfoResult> recv_addWarehouseInfo(){
				
				addWarehouseInfo_result result = new addWarehouseInfo_result();
				ReceiveBase(result, addWarehouseInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.stock.ConfirmFrozenInventoryResponse confirmFrozenInventory(int vendor_id_,int frozen_trans_id_,int inventory_type_,List<vipapis.stock.ConfirmFrozenInventory> confirm_frozen_inventory_list_) {
				
				send_confirmFrozenInventory(vendor_id_,frozen_trans_id_,inventory_type_,confirm_frozen_inventory_list_);
				return recv_confirmFrozenInventory(); 
				
			}
			
			
			private void send_confirmFrozenInventory(int vendor_id_,int frozen_trans_id_,int inventory_type_,List<vipapis.stock.ConfirmFrozenInventory> confirm_frozen_inventory_list_){
				
				InitInvocation("confirmFrozenInventory");
				
				confirmFrozenInventory_args args = new confirmFrozenInventory_args();
				args.SetVendor_id(vendor_id_);
				args.SetFrozen_trans_id(frozen_trans_id_);
				args.SetInventory_type(inventory_type_);
				args.SetConfirm_frozen_inventory_list(confirm_frozen_inventory_list_);
				
				SendBase(args, confirmFrozenInventory_argsHelper.getInstance());
			}
			
			
			private vipapis.stock.ConfirmFrozenInventoryResponse recv_confirmFrozenInventory(){
				
				confirmFrozenInventory_result result = new confirmFrozenInventory_result();
				ReceiveBase(result, confirmFrozenInventory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public bool? confirmUnfrozenInventory(int vendor_id_,List<int?> frozen_trans_ids_) {
				
				send_confirmUnfrozenInventory(vendor_id_,frozen_trans_ids_);
				return recv_confirmUnfrozenInventory(); 
				
			}
			
			
			private void send_confirmUnfrozenInventory(int vendor_id_,List<int?> frozen_trans_ids_){
				
				InitInvocation("confirmUnfrozenInventory");
				
				confirmUnfrozenInventory_args args = new confirmUnfrozenInventory_args();
				args.SetVendor_id(vendor_id_);
				args.SetFrozen_trans_ids(frozen_trans_ids_);
				
				SendBase(args, confirmUnfrozenInventory_argsHelper.getInstance());
			}
			
			
			private bool? recv_confirmUnfrozenInventory(){
				
				confirmUnfrozenInventory_result result = new confirmUnfrozenInventory_result();
				ReceiveBase(result, confirmUnfrozenInventory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.stock.DelResult> delWarehouseInfo(int vendor_id_,List<vipapis.stock.InputWarehouseInfo> vendor_warehouse_id_list_) {
				
				send_delWarehouseInfo(vendor_id_,vendor_warehouse_id_list_);
				return recv_delWarehouseInfo(); 
				
			}
			
			
			private void send_delWarehouseInfo(int vendor_id_,List<vipapis.stock.InputWarehouseInfo> vendor_warehouse_id_list_){
				
				InitInvocation("delWarehouseInfo");
				
				delWarehouseInfo_args args = new delWarehouseInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_warehouse_id_list(vendor_warehouse_id_list_);
				
				SendBase(args, delWarehouseInfo_argsHelper.getInstance());
			}
			
			
			private List<vipapis.stock.DelResult> recv_delWarehouseInfo(){
				
				delWarehouseInfo_result result = new delWarehouseInfo_result();
				ReceiveBase(result, delWarehouseInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.stock.FreezeTransIdAndInventoryType> getFreezeStockTransId(int vendor_id_,int frozeType_) {
				
				send_getFreezeStockTransId(vendor_id_,frozeType_);
				return recv_getFreezeStockTransId(); 
				
			}
			
			
			private void send_getFreezeStockTransId(int vendor_id_,int frozeType_){
				
				InitInvocation("getFreezeStockTransId");
				
				getFreezeStockTransId_args args = new getFreezeStockTransId_args();
				args.SetVendor_id(vendor_id_);
				args.SetFrozeType(frozeType_);
				
				SendBase(args, getFreezeStockTransId_argsHelper.getInstance());
			}
			
			
			private List<vipapis.stock.FreezeTransIdAndInventoryType> recv_getFreezeStockTransId(){
				
				getFreezeStockTransId_result result = new getFreezeStockTransId_result();
				ReceiveBase(result, getFreezeStockTransId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.stock.GetFrozenStockDetailsResponse getFreezingStockDetails(int vendor_id_,int frozen_trans_id_,int? page_,int? limit_) {
				
				send_getFreezingStockDetails(vendor_id_,frozen_trans_id_,page_,limit_);
				return recv_getFreezingStockDetails(); 
				
			}
			
			
			private void send_getFreezingStockDetails(int vendor_id_,int frozen_trans_id_,int? page_,int? limit_){
				
				InitInvocation("getFreezingStockDetails");
				
				getFreezingStockDetails_args args = new getFreezingStockDetails_args();
				args.SetVendor_id(vendor_id_);
				args.SetFrozen_trans_id(frozen_trans_id_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getFreezingStockDetails_argsHelper.getInstance());
			}
			
			
			private vipapis.stock.GetFrozenStockDetailsResponse recv_getFreezingStockDetails(){
				
				getFreezingStockDetails_result result = new getFreezingStockDetails_result();
				ReceiveBase(result, getFreezingStockDetails_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.stock.GetOxoShopOrderForJitResponse getOxoShopOrderForJit(int vendor_id_,vipapis.common.Warehouse? warehouse_,string vendor_warehouse_id_,string start_date_,string end_date_,int? page_,int? limit_) {
				
				send_getOxoShopOrderForJit(vendor_id_,warehouse_,vendor_warehouse_id_,start_date_,end_date_,page_,limit_);
				return recv_getOxoShopOrderForJit(); 
				
			}
			
			
			private void send_getOxoShopOrderForJit(int vendor_id_,vipapis.common.Warehouse? warehouse_,string vendor_warehouse_id_,string start_date_,string end_date_,int? page_,int? limit_){
				
				InitInvocation("getOxoShopOrderForJit");
				
				getOxoShopOrderForJit_args args = new getOxoShopOrderForJit_args();
				args.SetVendor_id(vendor_id_);
				args.SetWarehouse(warehouse_);
				args.SetVendor_warehouse_id(vendor_warehouse_id_);
				args.SetStart_date(start_date_);
				args.SetEnd_date(end_date_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getOxoShopOrderForJit_argsHelper.getInstance());
			}
			
			
			private vipapis.stock.GetOxoShopOrderForJitResponse recv_getOxoShopOrderForJit(){
				
				getOxoShopOrderForJit_result result = new getOxoShopOrderForJit_result();
				ReceiveBase(result, getOxoShopOrderForJit_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.stock.GetOxoShopOrderForPopResponse getOxoShopOrderForPop(int vendor_id_,vipapis.common.Warehouse? warehouse_,string vendor_warehouse_id_,string start_date_,string end_date_,int? page_,int? limit_) {
				
				send_getOxoShopOrderForPop(vendor_id_,warehouse_,vendor_warehouse_id_,start_date_,end_date_,page_,limit_);
				return recv_getOxoShopOrderForPop(); 
				
			}
			
			
			private void send_getOxoShopOrderForPop(int vendor_id_,vipapis.common.Warehouse? warehouse_,string vendor_warehouse_id_,string start_date_,string end_date_,int? page_,int? limit_){
				
				InitInvocation("getOxoShopOrderForPop");
				
				getOxoShopOrderForPop_args args = new getOxoShopOrderForPop_args();
				args.SetVendor_id(vendor_id_);
				args.SetWarehouse(warehouse_);
				args.SetVendor_warehouse_id(vendor_warehouse_id_);
				args.SetStart_date(start_date_);
				args.SetEnd_date(end_date_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getOxoShopOrderForPop_argsHelper.getInstance());
			}
			
			
			private vipapis.stock.GetOxoShopOrderForPopResponse recv_getOxoShopOrderForPop(){
				
				getOxoShopOrderForPop_result result = new getOxoShopOrderForPop_result();
				ReceiveBase(result, getOxoShopOrderForPop_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.stock.PoNoFrozenTransIdRelationShip getPoNoFrozenTransIdRelationship(int vendor_id_,int? frozen_trans_id_,string po_no_) {
				
				send_getPoNoFrozenTransIdRelationship(vendor_id_,frozen_trans_id_,po_no_);
				return recv_getPoNoFrozenTransIdRelationship(); 
				
			}
			
			
			private void send_getPoNoFrozenTransIdRelationship(int vendor_id_,int? frozen_trans_id_,string po_no_){
				
				InitInvocation("getPoNoFrozenTransIdRelationship");
				
				getPoNoFrozenTransIdRelationship_args args = new getPoNoFrozenTransIdRelationship_args();
				args.SetVendor_id(vendor_id_);
				args.SetFrozen_trans_id(frozen_trans_id_);
				args.SetPo_no(po_no_);
				
				SendBase(args, getPoNoFrozenTransIdRelationship_argsHelper.getInstance());
			}
			
			
			private vipapis.stock.PoNoFrozenTransIdRelationShip recv_getPoNoFrozenTransIdRelationship(){
				
				getPoNoFrozenTransIdRelationship_result result = new getPoNoFrozenTransIdRelationship_result();
				ReceiveBase(result, getPoNoFrozenTransIdRelationship_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.stock.GetVendorScheduleFreezeStockResult> getVendorScheduleFreezeStock(int vendor_id_,vipapis.stock.GetVendorScheduleFreezeStock get_vendor_schedule_freeze_stock_) {
				
				send_getVendorScheduleFreezeStock(vendor_id_,get_vendor_schedule_freeze_stock_);
				return recv_getVendorScheduleFreezeStock(); 
				
			}
			
			
			private void send_getVendorScheduleFreezeStock(int vendor_id_,vipapis.stock.GetVendorScheduleFreezeStock get_vendor_schedule_freeze_stock_){
				
				InitInvocation("getVendorScheduleFreezeStock");
				
				getVendorScheduleFreezeStock_args args = new getVendorScheduleFreezeStock_args();
				args.SetVendor_id(vendor_id_);
				args.SetGet_vendor_schedule_freeze_stock(get_vendor_schedule_freeze_stock_);
				
				SendBase(args, getVendorScheduleFreezeStock_argsHelper.getInstance());
			}
			
			
			private List<vipapis.stock.GetVendorScheduleFreezeStockResult> recv_getVendorScheduleFreezeStock(){
				
				getVendorScheduleFreezeStock_result result = new getVendorScheduleFreezeStock_result();
				ReceiveBase(result, getVendorScheduleFreezeStock_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.stock.GetWarehouseInfoResponse getWarehouseInfo(int vendor_id_,string vendor_warehouse_id_,vipapis.common.Warehouse? vip_warehouse_code_) {
				
				send_getWarehouseInfo(vendor_id_,vendor_warehouse_id_,vip_warehouse_code_);
				return recv_getWarehouseInfo(); 
				
			}
			
			
			private void send_getWarehouseInfo(int vendor_id_,string vendor_warehouse_id_,vipapis.common.Warehouse? vip_warehouse_code_){
				
				InitInvocation("getWarehouseInfo");
				
				getWarehouseInfo_args args = new getWarehouseInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_warehouse_id(vendor_warehouse_id_);
				args.SetVip_warehouse_code(vip_warehouse_code_);
				
				SendBase(args, getWarehouseInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.stock.GetWarehouseInfoResponse recv_getWarehouseInfo(){
				
				getWarehouseInfo_result result = new getWarehouseInfo_result();
				ReceiveBase(result, getWarehouseInfo_resultHelper.getInstance());
				
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
			
			
			public string updateVendorWarehouseAndVIPWarehouseMap(int vendor_id_,List<vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap> update_warehousemap_list_) {
				
				send_updateVendorWarehouseAndVIPWarehouseMap(vendor_id_,update_warehousemap_list_);
				return recv_updateVendorWarehouseAndVIPWarehouseMap(); 
				
			}
			
			
			private void send_updateVendorWarehouseAndVIPWarehouseMap(int vendor_id_,List<vipapis.stock.updateVendorWarehouseAndVIPWarehouseMap> update_warehousemap_list_){
				
				InitInvocation("updateVendorWarehouseAndVIPWarehouseMap");
				
				updateVendorWarehouseAndVIPWarehouseMap_args args = new updateVendorWarehouseAndVIPWarehouseMap_args();
				args.SetVendor_id(vendor_id_);
				args.SetUpdate_warehousemap_list(update_warehousemap_list_);
				
				SendBase(args, updateVendorWarehouseAndVIPWarehouseMap_argsHelper.getInstance());
			}
			
			
			private string recv_updateVendorWarehouseAndVIPWarehouseMap(){
				
				updateVendorWarehouseAndVIPWarehouseMap_result result = new updateVendorWarehouseAndVIPWarehouseMap_result();
				ReceiveBase(result, updateVendorWarehouseAndVIPWarehouseMap_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.stock.UpdateWarehouseInfoResult> updateWarehouseInfo(int vendor_id_,List<vipapis.stock.UpdateWarehouseInfo> update_warehouse_list_) {
				
				send_updateWarehouseInfo(vendor_id_,update_warehouse_list_);
				return recv_updateWarehouseInfo(); 
				
			}
			
			
			private void send_updateWarehouseInfo(int vendor_id_,List<vipapis.stock.UpdateWarehouseInfo> update_warehouse_list_){
				
				InitInvocation("updateWarehouseInfo");
				
				updateWarehouseInfo_args args = new updateWarehouseInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetUpdate_warehouse_list(update_warehouse_list_);
				
				SendBase(args, updateWarehouseInfo_argsHelper.getInstance());
			}
			
			
			private List<vipapis.stock.UpdateWarehouseInfoResult> recv_updateWarehouseInfo(){
				
				updateWarehouseInfo_result result = new updateWarehouseInfo_result();
				ReceiveBase(result, updateWarehouseInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.stock.UpdateWarehouseInventoryResponse updateWarehouseInventory(int vendor_id_,List<vipapis.stock.UpdateWarehouseInventory> update_warehouse_inventory_list_) {
				
				send_updateWarehouseInventory(vendor_id_,update_warehouse_inventory_list_);
				return recv_updateWarehouseInventory(); 
				
			}
			
			
			private void send_updateWarehouseInventory(int vendor_id_,List<vipapis.stock.UpdateWarehouseInventory> update_warehouse_inventory_list_){
				
				InitInvocation("updateWarehouseInventory");
				
				updateWarehouseInventory_args args = new updateWarehouseInventory_args();
				args.SetVendor_id(vendor_id_);
				args.SetUpdate_warehouse_inventory_list(update_warehouse_inventory_list_);
				
				SendBase(args, updateWarehouseInventory_argsHelper.getInstance());
			}
			
			
			private vipapis.stock.UpdateWarehouseInventoryResponse recv_updateWarehouseInventory(){
				
				updateWarehouseInventory_result result = new updateWarehouseInventory_result();
				ReceiveBase(result, updateWarehouseInventory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}