using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class VendorScheduleRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.VendorScheduleDo> vendorScheduleDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.VendorScheduleDo> GetVendorScheduleDos(){
			return this.vendorScheduleDos_;
		}
		
		public void SetVendorScheduleDos(List<com.vip.isv.tools.VendorScheduleDo> value){
			this.vendorScheduleDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}