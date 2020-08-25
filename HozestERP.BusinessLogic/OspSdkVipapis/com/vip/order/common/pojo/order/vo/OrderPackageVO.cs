using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderPackageVO {
		
		///<summary>
		/// 包裹id
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 订单id
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 包裹序号
		///</summary>
		
		private int? packageNo_;
		
		///<summary>
		/// 创建时间，单位为秒
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 更新时间，单位为秒
		///</summary>
		
		private long? updateTime_;
		
		///<summary>
		/// 状态: 1有效,0无效
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 详情列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderPackageDetailVO> detailList_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public int? GetPackageNo(){
			return this.packageNo_;
		}
		
		public void SetPackageNo(int? value){
			this.packageNo_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public long? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(long? value){
			this.updateTime_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderPackageDetailVO> GetDetailList(){
			return this.detailList_;
		}
		
		public void SetDetailList(List<com.vip.order.common.pojo.order.vo.OrderPackageDetailVO> value){
			this.detailList_ = value;
		}
		
	}
	
}