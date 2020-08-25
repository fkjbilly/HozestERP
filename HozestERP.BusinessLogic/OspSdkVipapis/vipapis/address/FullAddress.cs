using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.address{
	
	
	
	
	
	public class FullAddress {
		
		///<summary>
		/// 省/市/区列表
		///</summary>
		
		private List<vipapis.address.City> cities_;
		
		///<summary>
		/// 地址信息
		///</summary>
		
		private vipapis.address.Address address_;
		
		public List<vipapis.address.City> GetCities(){
			return this.cities_;
		}
		
		public void SetCities(List<vipapis.address.City> value){
			this.cities_ = value;
		}
		public vipapis.address.Address GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(vipapis.address.Address value){
			this.address_ = value;
		}
		
	}
	
}