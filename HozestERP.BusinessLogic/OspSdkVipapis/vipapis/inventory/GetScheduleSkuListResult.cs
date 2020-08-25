using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory{
	
	
	
	
	
	public class GetScheduleSkuListResult {
		
		///<summary>
		/// 是否有下一页，用于标识是否需要继续分页查询，true：还有下一页，false：无下一页
		/// @sampleValue has_next false
		///</summary>
		
		private bool? has_next_;
		
		///<summary>
		/// 档期商品列表
		///</summary>
		
		private List<vipapis.inventory.ScheduleSku> list_;
		
		public bool? GetHas_next(){
			return this.has_next_;
		}
		
		public void SetHas_next(bool? value){
			this.has_next_ = value;
		}
		public List<vipapis.inventory.ScheduleSku> GetList(){
			return this.list_;
		}
		
		public void SetList(List<vipapis.inventory.ScheduleSku> value){
			this.list_ = value;
		}
		
	}
	
}