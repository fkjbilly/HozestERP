using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class Package {
		
		///<summary>
		/// 包裹产品信息列表
		/// @sampleValue package_product_list 
		///</summary>
		
		private List<vipapis.delivery.PackageProduct> package_product_list_;
		
		///<summary>
		/// 运单号
		/// @sampleValue transport_no 
		///</summary>
		
		private string transport_no_;
		
		public List<vipapis.delivery.PackageProduct> GetPackage_product_list(){
			return this.package_product_list_;
		}
		
		public void SetPackage_product_list(List<vipapis.delivery.PackageProduct> value){
			this.package_product_list_ = value;
		}
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		
	}
	
}