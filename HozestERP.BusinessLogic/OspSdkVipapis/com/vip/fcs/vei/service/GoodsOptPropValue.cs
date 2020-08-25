using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class GoodsOptPropValue {
		
		///<summary>
		/// 属性编码
		///</summary>
		
		private string attrCode_;
		
		///<summary>
		/// 扩展属性值
		///</summary>
		
		private string extAttrValue_;
		
		public string GetAttrCode(){
			return this.attrCode_;
		}
		
		public void SetAttrCode(string value){
			this.attrCode_ = value;
		}
		public string GetExtAttrValue(){
			return this.extAttrValue_;
		}
		
		public void SetExtAttrValue(string value){
			this.extAttrValue_ = value;
		}
		
	}
	
}