using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.logistics{
	
	
	
	
	
	public class Order {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 包裹数量
		///</summary>
		
		private int? package_no_;
		
		///<summary>
		/// 包裹列表
		///</summary>
		
		private List<com.vip.vop.omni.logistics.Package> packages_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public int? GetPackage_no(){
			return this.package_no_;
		}
		
		public void SetPackage_no(int? value){
			this.package_no_ = value;
		}
		public List<com.vip.vop.omni.logistics.Package> GetPackages(){
			return this.packages_;
		}
		
		public void SetPackages(List<com.vip.vop.omni.logistics.Package> value){
			this.packages_ = value;
		}
		
	}
	
}