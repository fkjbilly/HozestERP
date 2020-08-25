using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class UnbindProductImageRequest {
		
		///<summary>
		/// 商品spu_id
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 图片索引
		///</summary>
		
		private int? index_;
		
		///<summary>
		/// 颜色，输入颜色时，表示解绑(或说删除)色图;不输入则解绑款图
		/// @sampleValue color 红色
		///</summary>
		
		private string color_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public int? GetIndex(){
			return this.index_;
		}
		
		public void SetIndex(int? value){
			this.index_ = value;
		}
		public string GetColor(){
			return this.color_;
		}
		
		public void SetColor(string value){
			this.color_ = value;
		}
		
	}
	
}