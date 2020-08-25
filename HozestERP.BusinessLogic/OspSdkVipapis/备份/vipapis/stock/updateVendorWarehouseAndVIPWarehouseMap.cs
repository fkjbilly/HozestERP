using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class updateVendorWarehouseAndVIPWarehouseMap {
		
		///<summary>
		/// 仓库编号
		/// @sampleValue vendor_warehouse_id 
		///</summary>
		
		private string vendor_warehouse_id_;
		
		///<summary>
		/// 唯品会仓库编码
		/// @sampleValue vip_warehouse_code VIP_NH（华南：南海仓），VIP_SH（华东：上海仓），VIP_CD（西北：成都仓），VIP_BJ（北京仓），VIP_HZ（华中：鄂州仓）。只允许这几个值。
		///</summary>
		
		private string vip_warehouse_code_;
		
		///<summary>
		/// 优先级
		/// @sampleValue priority 
		///</summary>
		
		private string priority_;
		
		public string GetVendor_warehouse_id(){
			return this.vendor_warehouse_id_;
		}
		
		public void SetVendor_warehouse_id(string value){
			this.vendor_warehouse_id_ = value;
		}
		public string GetVip_warehouse_code(){
			return this.vip_warehouse_code_;
		}
		
		public void SetVip_warehouse_code(string value){
			this.vip_warehouse_code_ = value;
		}
		public string GetPriority(){
			return this.priority_;
		}
		
		public void SetPriority(string value){
			this.priority_ = value;
		}
		
	}
	
}