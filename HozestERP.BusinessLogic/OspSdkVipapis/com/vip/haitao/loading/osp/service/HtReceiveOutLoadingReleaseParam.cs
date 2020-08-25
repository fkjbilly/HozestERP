using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class HtReceiveOutLoadingReleaseParam {
		
		///<summary>
		/// 调用方用户id
		///</summary>
		
		private string userId_;
		
		///<summary>
		/// 装载单号
		///</summary>
		
		private string listNo_;
		
		///<summary>
		/// 装载审批完成时间
		///</summary>
		
		private string idAuditDate_;
		
		///<summary>
		/// 车牌号码
		///</summary>
		
		private string carNo_;
		
		///<summary>
		/// 总毛重
		///</summary>
		
		private double? sumWeight_;
		
		///<summary>
		/// 装载单的订单总数
		///</summary>
		
		private int? totalCount_;
		
		///<summary>
		/// 命令类型:ADD、MODIFY、CANCEL
		///</summary>
		
		private string cmdType_;
		
		///<summary>
		/// 核放订单列表
		///</summary>
		
		private List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrders> orders_;
		
		public string GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(string value){
			this.userId_ = value;
		}
		public string GetListNo(){
			return this.listNo_;
		}
		
		public void SetListNo(string value){
			this.listNo_ = value;
		}
		public string GetIdAuditDate(){
			return this.idAuditDate_;
		}
		
		public void SetIdAuditDate(string value){
			this.idAuditDate_ = value;
		}
		public string GetCarNo(){
			return this.carNo_;
		}
		
		public void SetCarNo(string value){
			this.carNo_ = value;
		}
		public double? GetSumWeight(){
			return this.sumWeight_;
		}
		
		public void SetSumWeight(double? value){
			this.sumWeight_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		public string GetCmdType(){
			return this.cmdType_;
		}
		
		public void SetCmdType(string value){
			this.cmdType_ = value;
		}
		public List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrders> GetOrders(){
			return this.orders_;
		}
		
		public void SetOrders(List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrders> value){
			this.orders_ = value;
		}
		
	}
	
}