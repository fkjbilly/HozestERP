using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutOubShipmentDatailInfo {
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barCode_;
		
		///<summary>
		/// 商品货号
		///</summary>
		
		private string gCode_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private double? qty_;
		
		///<summary>
		/// 商品真知码
		///</summary>
		
		private string zCode_;
		
		///<summary>
		/// 入仓批次号
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 提单号
		///</summary>
		
		private string blNo_;
		
		///<summary>
		/// PO号
		///</summary>
		
		private string poNo_;
		
		public string GetBarCode(){
			return this.barCode_;
		}
		
		public void SetBarCode(string value){
			this.barCode_ = value;
		}
		public string GetGCode(){
			return this.gCode_;
		}
		
		public void SetGCode(string value){
			this.gCode_ = value;
		}
		public double? GetQty(){
			return this.qty_;
		}
		
		public void SetQty(double? value){
			this.qty_ = value;
		}
		public string GetZCode(){
			return this.zCode_;
		}
		
		public void SetZCode(string value){
			this.zCode_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public string GetBlNo(){
			return this.blNo_;
		}
		
		public void SetBlNo(string value){
			this.blNo_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		
	}
	
}