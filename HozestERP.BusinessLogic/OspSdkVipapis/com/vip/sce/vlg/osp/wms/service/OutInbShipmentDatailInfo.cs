using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutInbShipmentDatailInfo {
		
		///<summary>
		/// 序号
		///</summary>
		
		private string Id_;
		
		///<summary>
		/// 商品货号
		///</summary>
		
		private string gCode_;
		
		///<summary>
		/// 商品海关备案号
		///</summary>
		
		private string custGoodsno_;
		
		///<summary>
		/// 商品国检备案号
		///</summary>
		
		private string ciqGoodsno_;
		
		///<summary>
		/// 标准数量(保留两位小数)
		///</summary>
		
		private double? qty_;
		
		public string GetId(){
			return this.Id_;
		}
		
		public void SetId(string value){
			this.Id_ = value;
		}
		public string GetGCode(){
			return this.gCode_;
		}
		
		public void SetGCode(string value){
			this.gCode_ = value;
		}
		public string GetCustGoodsno(){
			return this.custGoodsno_;
		}
		
		public void SetCustGoodsno(string value){
			this.custGoodsno_ = value;
		}
		public string GetCiqGoodsno(){
			return this.ciqGoodsno_;
		}
		
		public void SetCiqGoodsno(string value){
			this.ciqGoodsno_ = value;
		}
		public double? GetQty(){
			return this.qty_;
		}
		
		public void SetQty(double? value){
			this.qty_ = value;
		}
		
	}
	
}