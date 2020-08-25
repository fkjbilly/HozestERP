using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class UpdateWarehouseInventoryResponse {
		
		///<summary>
		/// 成功的数据
		/// @sampleValue success_data 
		///</summary>
		
		private List<vipapis.stock.UpdateWarehouseInventoryResult> success_data_;
		
		///<summary>
		/// 失败的数据
		/// @sampleValue fail_data 
		///</summary>
		
		private List<vipapis.stock.UpdateWarehouseInventoryResult> fail_data_;
		
		public List<vipapis.stock.UpdateWarehouseInventoryResult> GetSuccess_data(){
			return this.success_data_;
		}
		
		public void SetSuccess_data(List<vipapis.stock.UpdateWarehouseInventoryResult> value){
			this.success_data_ = value;
		}
		public List<vipapis.stock.UpdateWarehouseInventoryResult> GetFail_data(){
			return this.fail_data_;
		}
		
		public void SetFail_data(List<vipapis.stock.UpdateWarehouseInventoryResult> value){
			this.fail_data_ = value;
		}
		
	}
	
}