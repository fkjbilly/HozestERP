using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.merchModel.service{
	
	
	
	
	
	public class Jd3dModelData {
		
		///<summary>
		/// 模型ID
		///</summary>
		
		private string mid_;
		
		///<summary>
		/// category
		///</summary>
		
		private string category_;
		
		///<summary>
		/// barcode
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// osn
		///</summary>
		
		private string osn_;
		
		///<summary>
		/// brand_name
		///</summary>
		
		private string brandName_;
		
		///<summary>
		/// title
		///</summary>
		
		private string title_;
		
		///<summary>
		/// color
		///</summary>
		
		private string color_;
		
		///<summary>
		/// size
		///</summary>
		
		private int? size_;
		
		///<summary>
		/// jd3dModelInfo
		///</summary>
		
		private com.vip.arplatform.merchModel.service.Jd3dModelInfo jd3dModelInfo_;
		
		public string GetMid(){
			return this.mid_;
		}
		
		public void SetMid(string value){
			this.mid_ = value;
		}
		public string GetCategory(){
			return this.category_;
		}
		
		public void SetCategory(string value){
			this.category_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetOsn(){
			return this.osn_;
		}
		
		public void SetOsn(string value){
			this.osn_ = value;
		}
		public string GetBrandName(){
			return this.brandName_;
		}
		
		public void SetBrandName(string value){
			this.brandName_ = value;
		}
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public string GetColor(){
			return this.color_;
		}
		
		public void SetColor(string value){
			this.color_ = value;
		}
		public int? GetSize(){
			return this.size_;
		}
		
		public void SetSize(int? value){
			this.size_ = value;
		}
		public com.vip.arplatform.merchModel.service.Jd3dModelInfo GetJd3dModelInfo(){
			return this.jd3dModelInfo_;
		}
		
		public void SetJd3dModelInfo(com.vip.arplatform.merchModel.service.Jd3dModelInfo value){
			this.jd3dModelInfo_ = value;
		}
		
	}
	
}