using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutReturnOrderPackage {
		
		///<summary>
		/// 调用端名称
		///</summary>
		
		private string appName_;
		
		///<summary>
		/// 仓库代码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 省
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 区
		///</summary>
		
		private string region_;
		
		///<summary>
		/// 镇
		///</summary>
		
		private string town_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 大包号
		///</summary>
		
		private string packageNo_;
		
		///<summary>
		/// 明细信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageDetail> details_;
		
		public string GetAppName(){
			return this.appName_;
		}
		
		public void SetAppName(string value){
			this.appName_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetRegion(){
			return this.region_;
		}
		
		public void SetRegion(string value){
			this.region_ = value;
		}
		public string GetTown(){
			return this.town_;
		}
		
		public void SetTown(string value){
			this.town_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public string GetPackageNo(){
			return this.packageNo_;
		}
		
		public void SetPackageNo(string value){
			this.packageNo_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageDetail> GetDetails(){
			return this.details_;
		}
		
		public void SetDetails(List<com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageDetail> value){
			this.details_ = value;
		}
		
	}
	
}