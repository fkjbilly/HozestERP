using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.address{
	
	
	
	
	
	public class ProvinceWarehouse {
		
		///<summary>
		/// 所属编码
		/// @sampleValue warehouse VIP_BJ
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 省/市/区
		///</summary>
		
		private List<vipapis.address.City> children_;
		
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public List<vipapis.address.City> GetChildren(){
			return this.children_;
		}
		
		public void SetChildren(List<vipapis.address.City> value){
			this.children_ = value;
		}
		
	}
	
}