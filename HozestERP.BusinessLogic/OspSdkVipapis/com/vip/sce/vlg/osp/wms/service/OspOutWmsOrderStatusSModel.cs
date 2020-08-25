using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OspOutWmsOrderStatusSModel {
		
		///<summary>
		/// 流水号 仓库编号+id（自定义数字,十一位自增值）
		///</summary>
		
		private string logisticsId_;
		
		///<summary>
		///  订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		///  订单状态（004，在海外仓库内；005，拣货中；006，缺货，此时对应的memo字段会写入缺货原因；007，已OQC交接；）
		///</summary>
		
		private string orderStatus_;
		
		///<summary>
		/// 描述信息（当order_status=006时，memo写入备注）
		///</summary>
		
		private string memo_;
		
		///<summary>
		/// 创建时间（仓库上抛时间）,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string createTime_;
		
		public string GetLogisticsId(){
			return this.logisticsId_;
		}
		
		public void SetLogisticsId(string value){
			this.logisticsId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetOrderStatus(){
			return this.orderStatus_;
		}
		
		public void SetOrderStatus(string value){
			this.orderStatus_ = value;
		}
		public string GetMemo(){
			return this.memo_;
		}
		
		public void SetMemo(string value){
			this.memo_ = value;
		}
		public string GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(string value){
			this.createTime_ = value;
		}
		
	}
	
}