using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class SaveVSpuSizeTableRelationResponse {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private int? brand_id_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 尺码id
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 供应商SKUID映射尺码详细ID信息,key:条码；value:尺码详情id
		///</summary>
		
		private Dictionary<string, long?> sku_size_detail_id_mappings_;
		
		///<summary>
		/// 是否成功
		///</summary>
		
		private bool? is_success_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(int? value){
			this.brand_id_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		public long? GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(long? value){
			this.size_table_id_ = value;
		}
		public Dictionary<string, long?> GetSku_size_detail_id_mappings(){
			return this.sku_size_detail_id_mappings_;
		}
		
		public void SetSku_size_detail_id_mappings(Dictionary<string, long?> value){
			this.sku_size_detail_id_mappings_ = value;
		}
		public bool? GetIs_success(){
			return this.is_success_;
		}
		
		public void SetIs_success(bool? value){
			this.is_success_ = value;
		}
		
	}
	
}