using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class ReturnOutInfo {
		
		///<summary>
		/// 传输ID
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 退供单号
		///</summary>
		
		private string return_sn_;
		
		///<summary>
		/// 出仓时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string out_time_;
		
		///<summary>
		/// 总箱数
		///</summary>
		
		private double? total_cases_;
		
		///<summary>
		/// 总商品条码数
		///</summary>
		
		private double? total_skus_;
		
		///<summary>
		/// 总商品数
		///</summary>
		
		private double? total_qtys_;
		
		///<summary>
		/// 退供单类型
		///</summary>
		
		private string return_type_;
		
		///<summary>
		/// 退供子单号
		///</summary>
		
		private string sub_return_sn_;
		
		///<summary>
		/// 退供子单标识
		///</summary>
		
		private string sub_return_flag_;
		
		///<summary>
		/// 退供出仓明细信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfo> detail_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public string GetReturn_sn(){
			return this.return_sn_;
		}
		
		public void SetReturn_sn(string value){
			this.return_sn_ = value;
		}
		public string GetOut_time(){
			return this.out_time_;
		}
		
		public void SetOut_time(string value){
			this.out_time_ = value;
		}
		public double? GetTotal_cases(){
			return this.total_cases_;
		}
		
		public void SetTotal_cases(double? value){
			this.total_cases_ = value;
		}
		public double? GetTotal_skus(){
			return this.total_skus_;
		}
		
		public void SetTotal_skus(double? value){
			this.total_skus_ = value;
		}
		public double? GetTotal_qtys(){
			return this.total_qtys_;
		}
		
		public void SetTotal_qtys(double? value){
			this.total_qtys_ = value;
		}
		public string GetReturn_type(){
			return this.return_type_;
		}
		
		public void SetReturn_type(string value){
			this.return_type_ = value;
		}
		public string GetSub_return_sn(){
			return this.sub_return_sn_;
		}
		
		public void SetSub_return_sn(string value){
			this.sub_return_sn_ = value;
		}
		public string GetSub_return_flag(){
			return this.sub_return_flag_;
		}
		
		public void SetSub_return_flag(string value){
			this.sub_return_flag_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfo> GetDetail(){
			return this.detail_;
		}
		
		public void SetDetail(List<com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfo> value){
			this.detail_ = value;
		}
		
	}
	
}