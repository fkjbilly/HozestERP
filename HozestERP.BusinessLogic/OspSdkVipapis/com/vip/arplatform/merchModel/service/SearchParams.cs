using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.merchModel.service{
	
	
	
	
	
	public class SearchParams {
		
		///<summary>
		/// serviceType, 参见EnumServiceType
		///</summary>
		
		private int? serviceType_;
		
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
		/// 模型来源，JD / vendor
		///</summary>
		
		private string _from_;
		
		///<summary>
		/// 启用状态, 0=关闭, 1=启用, 2=全部
		///</summary>
		
		private byte? status_;
		
		public int? GetServiceType(){
			return this.serviceType_;
		}
		
		public void SetServiceType(int? value){
			this.serviceType_ = value;
		}
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
		public string Get_from(){
			return this._from_;
		}
		
		public void Set_from(string value){
			this._from_ = value;
		}
		public byte? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(byte? value){
			this.status_ = value;
		}
		
	}
	
}