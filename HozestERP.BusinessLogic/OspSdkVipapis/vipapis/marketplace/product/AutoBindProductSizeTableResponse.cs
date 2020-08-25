using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class AutoBindProductSizeTableResponse {
		
		///<summary>
		/// 商品spu编码
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 尺码表模板id
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 商品SKUID映射尺码详细ID信息,key:skuid；value:尺码表详情id，存在部分绑定成功：只返回绑定成功的skuId
		///</summary>
		
		private Dictionary<string, long?> sku_size_detail_id_mappings_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
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
		
	}
	
}