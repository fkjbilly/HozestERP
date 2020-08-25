using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetActualStorageInfoResponse {
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storage_no_;
		
		///<summary>
		/// 实际入库时间，格式：yyyy-mm-dd hh:mm:ss
		///</summary>
		
		private string storage_time_;
		
		///<summary>
		/// 记录总数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 实际入库明细列表
		///</summary>
		
		private List<vipapis.delivery.ActualStorageInfo> actual_storage_list_;
		
		public string GetStorage_no(){
			return this.storage_no_;
		}
		
		public void SetStorage_no(string value){
			this.storage_no_ = value;
		}
		public string GetStorage_time(){
			return this.storage_time_;
		}
		
		public void SetStorage_time(string value){
			this.storage_time_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.delivery.ActualStorageInfo> GetActual_storage_list(){
			return this.actual_storage_list_;
		}
		
		public void SetActual_storage_list(List<vipapis.delivery.ActualStorageInfo> value){
			this.actual_storage_list_ = value;
		}
		
	}
	
}