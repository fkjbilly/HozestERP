using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class GoodRecordAttachParam {
		
		///<summary>
		/// 报关行编码
		///</summary>
		
		private string carrierCode_;
		
		///<summary>
		/// 关口编码
		///</summary>
		
		private string customsCode_;
		
		///<summary>
		/// 备案类型：000-BBC与BC通用，001-BC，003-BBC，008-个人物品
		///</summary>
		
		private string recordType_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string goodSn_;
		
		///<summary>
		/// 备案申请号
		///</summary>
		
		private string recordNo_;
		
		public string GetCarrierCode(){
			return this.carrierCode_;
		}
		
		public void SetCarrierCode(string value){
			this.carrierCode_ = value;
		}
		public string GetCustomsCode(){
			return this.customsCode_;
		}
		
		public void SetCustomsCode(string value){
			this.customsCode_ = value;
		}
		public string GetRecordType(){
			return this.recordType_;
		}
		
		public void SetRecordType(string value){
			this.recordType_ = value;
		}
		public string GetGoodSn(){
			return this.goodSn_;
		}
		
		public void SetGoodSn(string value){
			this.goodSn_ = value;
		}
		public string GetRecordNo(){
			return this.recordNo_;
		}
		
		public void SetRecordNo(string value){
			this.recordNo_ = value;
		}
		
	}
	
}