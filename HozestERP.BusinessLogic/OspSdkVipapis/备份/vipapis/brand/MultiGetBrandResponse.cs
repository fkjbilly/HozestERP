using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.brand{
	
	
	
	
	
	public class MultiGetBrandResponse {
		
		///<summary>
		/// 品牌信息列表
		///</summary>
		
		private List<vipapis.brand.BrandInfo> brands_;
		
		///<summary>
		/// 总记录条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.brand.BrandInfo> GetBrands(){
			return this.brands_;
		}
		
		public void SetBrands(List<vipapis.brand.BrandInfo> value){
			this.brands_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}