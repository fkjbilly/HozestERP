using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class GetDeliveryListRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// po号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 出仓单号(送货单号)
		///</summary>
		
		private string storageNo_;
		
		///<summary>
		/// 送货仓库编码
		///</summary>
		
		private string vipWarehouse_;
		
		///<summary>
		/// 出仓状态
		///</summary>
		
		private int? outFlag_;
		
		///<summary>
		/// 出仓时间(开始时间)
		///</summary>
		
		private System.DateTime? outTimeFrom_;
		
		///<summary>
		/// 出仓时间(结束时间)
		///</summary>
		
		private System.DateTime? outTimeTo_;
		
		///<summary>
		/// 预计到货时间(开始时间)
		///</summary>
		
		private System.DateTime? arrivalTimeFrom_;
		
		///<summary>
		/// 预计到货时间(结束时间)
		///</summary>
		
		private System.DateTime? arrivalTimeTo_;
		
		///<summary>
		/// 实际到货时间(开始时间)
		///</summary>
		
		private System.DateTime? realArrivalTimeFrom_;
		
		///<summary>
		/// 实际到货时间(结束时间)
		///</summary>
		
		private System.DateTime? realArrivalTimeTo_;
		
		///<summary>
		/// ERP送货仓库
		///</summary>
		
		private string erpWarehouse_;
		
		///<summary>
		/// 分页信息
		///</summary>
		
		private com.vip.vop.vcloud.common.api.Pagination pagination_;
		
		///<summary>
		/// 发货时间(开始时间)
		///</summary>
		
		private System.DateTime? deliveryTimeFrom_;
		
		///<summary>
		/// 发货时间(结束时间)
		///</summary>
		
		private System.DateTime? deliveryTimeTo_;
		
		///<summary>
		/// 是否推送
		///</summary>
		
		private int? needPush_;
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public string GetStorageNo(){
			return this.storageNo_;
		}
		
		public void SetStorageNo(string value){
			this.storageNo_ = value;
		}
		public string GetVipWarehouse(){
			return this.vipWarehouse_;
		}
		
		public void SetVipWarehouse(string value){
			this.vipWarehouse_ = value;
		}
		public int? GetOutFlag(){
			return this.outFlag_;
		}
		
		public void SetOutFlag(int? value){
			this.outFlag_ = value;
		}
		public System.DateTime? GetOutTimeFrom(){
			return this.outTimeFrom_;
		}
		
		public void SetOutTimeFrom(System.DateTime? value){
			this.outTimeFrom_ = value;
		}
		public System.DateTime? GetOutTimeTo(){
			return this.outTimeTo_;
		}
		
		public void SetOutTimeTo(System.DateTime? value){
			this.outTimeTo_ = value;
		}
		public System.DateTime? GetArrivalTimeFrom(){
			return this.arrivalTimeFrom_;
		}
		
		public void SetArrivalTimeFrom(System.DateTime? value){
			this.arrivalTimeFrom_ = value;
		}
		public System.DateTime? GetArrivalTimeTo(){
			return this.arrivalTimeTo_;
		}
		
		public void SetArrivalTimeTo(System.DateTime? value){
			this.arrivalTimeTo_ = value;
		}
		public System.DateTime? GetRealArrivalTimeFrom(){
			return this.realArrivalTimeFrom_;
		}
		
		public void SetRealArrivalTimeFrom(System.DateTime? value){
			this.realArrivalTimeFrom_ = value;
		}
		public System.DateTime? GetRealArrivalTimeTo(){
			return this.realArrivalTimeTo_;
		}
		
		public void SetRealArrivalTimeTo(System.DateTime? value){
			this.realArrivalTimeTo_ = value;
		}
		public string GetErpWarehouse(){
			return this.erpWarehouse_;
		}
		
		public void SetErpWarehouse(string value){
			this.erpWarehouse_ = value;
		}
		public com.vip.vop.vcloud.common.api.Pagination GetPagination(){
			return this.pagination_;
		}
		
		public void SetPagination(com.vip.vop.vcloud.common.api.Pagination value){
			this.pagination_ = value;
		}
		public System.DateTime? GetDeliveryTimeFrom(){
			return this.deliveryTimeFrom_;
		}
		
		public void SetDeliveryTimeFrom(System.DateTime? value){
			this.deliveryTimeFrom_ = value;
		}
		public System.DateTime? GetDeliveryTimeTo(){
			return this.deliveryTimeTo_;
		}
		
		public void SetDeliveryTimeTo(System.DateTime? value){
			this.deliveryTimeTo_ = value;
		}
		public int? GetNeedPush(){
			return this.needPush_;
		}
		
		public void SetNeedPush(int? value){
			this.needPush_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		
	}
	
}