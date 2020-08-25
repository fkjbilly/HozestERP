using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class UpdateWarehouseInventory {
		
		///<summary>
		/// 门店名称
		/// @sampleValue storeName 
		///</summary>
		
		private string storeName_;
		
		///<summary>
		/// 产品编号
		/// @sampleValue barcode 
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 库存数量
		/// @sampleValue num 
		///</summary>
		
		private string num_;
		
		///<summary>
		/// 操作类型
		/// @sampleValue action_type 460 库存全量同步
		///</summary>
		
		private string action_type_;
		
		///<summary>
		/// 流水号
		/// @sampleValue transaction_id 
		///</summary>
		
		private string transaction_id_;
		
		public string GetStoreName(){
			return this.storeName_;
		}
		
		public void SetStoreName(string value){
			this.storeName_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetNum(){
			return this.num_;
		}
		
		public void SetNum(string value){
			this.num_ = value;
		}
		public string GetAction_type(){
			return this.action_type_;
		}
		
		public void SetAction_type(string value){
			this.action_type_ = value;
		}
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		
	}
	
}