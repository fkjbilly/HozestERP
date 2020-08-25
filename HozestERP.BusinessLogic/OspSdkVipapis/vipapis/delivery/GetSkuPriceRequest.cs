using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetSkuPriceRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// po号码
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 商品条形码列表,最大支持200
		///</summary>
		
		private List<string> barcodes_;
		
		///<summary>
		/// 生效时间点, 格式:yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string effective_time_;
		
		///<summary>
		/// 档期id
		///</summary>
		
		private long? schedule_id_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public List<string> GetBarcodes(){
			return this.barcodes_;
		}
		
		public void SetBarcodes(List<string> value){
			this.barcodes_ = value;
		}
		public string GetEffective_time(){
			return this.effective_time_;
		}
		
		public void SetEffective_time(string value){
			this.effective_time_ = value;
		}
		public long? GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(long? value){
			this.schedule_id_ = value;
		}
		
	}
	
}