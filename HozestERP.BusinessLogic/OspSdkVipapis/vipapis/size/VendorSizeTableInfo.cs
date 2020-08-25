using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class VendorSizeTableInfo {
		
		///<summary>
		/// 尺码表id
		///</summary>
		
		private long? sizetable_id_;
		
		///<summary>
		/// 尺码表名称
		///</summary>
		
		private string sizetable_name_;
		
		///<summary>
		/// 尺码表详情信息列表
		/// @sampleValue sizedetails 
		///</summary>
		
		private List<vipapis.size.VendorSizeDetail> sizedetails_;
		
		public long? GetSizetable_id(){
			return this.sizetable_id_;
		}
		
		public void SetSizetable_id(long? value){
			this.sizetable_id_ = value;
		}
		public string GetSizetable_name(){
			return this.sizetable_name_;
		}
		
		public void SetSizetable_name(string value){
			this.sizetable_name_ = value;
		}
		public List<vipapis.size.VendorSizeDetail> GetSizedetails(){
			return this.sizedetails_;
		}
		
		public void SetSizedetails(List<vipapis.size.VendorSizeDetail> value){
			this.sizedetails_ = value;
		}
		
	}
	
}