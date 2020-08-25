using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class UpdateInventoryResult {
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batch_no_;
		
		///<summary>
		/// 库存调整状态 0、未发送 1、推送成功 3、失败
		/// @sampleValue status 0
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 常态档期id
		///</summary>
		
		private int? schedule_id_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 实际库存调整值
		///</summary>
		
		private int? real_quantity_;
		
		///<summary>
		/// 失败原因
		///</summary>
		
		private string message_;
		
		public string GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(string value){
			this.batch_no_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public int? GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(int? value){
			this.schedule_id_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetReal_quantity(){
			return this.real_quantity_;
		}
		
		public void SetReal_quantity(int? value){
			this.real_quantity_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}