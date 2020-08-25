using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class ShipPackage {
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 包裹明细
		///</summary>
		
		private List<vipapis.marketplace.delivery.ShipPackageProduct> package_product_list_;
		
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public List<vipapis.marketplace.delivery.ShipPackageProduct> GetPackage_product_list(){
			return this.package_product_list_;
		}
		
		public void SetPackage_product_list(List<vipapis.marketplace.delivery.ShipPackageProduct> value){
			this.package_product_list_ = value;
		}
		
	}
	
}