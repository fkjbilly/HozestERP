using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class SearchPoRequest {
		
		///<summary>
		/// 系统入库凭证
		///</summary>
		
		private string systemPoNo_;
		
		///<summary>
		/// 客户入库凭证
		///</summary>
		
		private string clientPoNo_;
		
		///<summary>
		/// 收货仓编码
		///</summary>
		
		private string warehouseCode_;
		
		///<summary>
		/// 入库单状态  0-新增。1-同步商务审批，2-商务审核中，3-审核不通过，4-审批成功，5-同步WMS 失败，6-取消中，7-取消成功，8-同步WMS 上架时间
		///</summary>
		
		private string poStatus_;
		
		///<summary>
		/// 创建日期起 YYYY-MM-DD hh:mm:ss
		///</summary>
		
		private string createDateStart_;
		
		///<summary>
		/// 创建日期止 YYYY-MM-DD hh:mm:ss
		///</summary>
		
		private string createDateEnd_;
		
		///<summary>
		/// 上架时间起 YYYY-MM-DD hh:mm:ss
		///</summary>
		
		private string startOnRacksTimeStart_;
		
		///<summary>
		/// 上架时间止 YYYY-MM-DD hh:mm:ss
		///</summary>
		
		private string startOnRacksTimeEnd_;
		
		public string GetSystemPoNo(){
			return this.systemPoNo_;
		}
		
		public void SetSystemPoNo(string value){
			this.systemPoNo_ = value;
		}
		public string GetClientPoNo(){
			return this.clientPoNo_;
		}
		
		public void SetClientPoNo(string value){
			this.clientPoNo_ = value;
		}
		public string GetWarehouseCode(){
			return this.warehouseCode_;
		}
		
		public void SetWarehouseCode(string value){
			this.warehouseCode_ = value;
		}
		public string GetPoStatus(){
			return this.poStatus_;
		}
		
		public void SetPoStatus(string value){
			this.poStatus_ = value;
		}
		public string GetCreateDateStart(){
			return this.createDateStart_;
		}
		
		public void SetCreateDateStart(string value){
			this.createDateStart_ = value;
		}
		public string GetCreateDateEnd(){
			return this.createDateEnd_;
		}
		
		public void SetCreateDateEnd(string value){
			this.createDateEnd_ = value;
		}
		public string GetStartOnRacksTimeStart(){
			return this.startOnRacksTimeStart_;
		}
		
		public void SetStartOnRacksTimeStart(string value){
			this.startOnRacksTimeStart_ = value;
		}
		public string GetStartOnRacksTimeEnd(){
			return this.startOnRacksTimeEnd_;
		}
		
		public void SetStartOnRacksTimeEnd(string value){
			this.startOnRacksTimeEnd_ = value;
		}
		
	}
	
}