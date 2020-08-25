using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class RollbackOrderReq {
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单号列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderIdSnVO> orderSnList_;
		
		///<summary>
		/// 错误类型:1 无法生成订单 2：回滚订单
		///</summary>
		
		private int? failType_;
		
		///<summary>
		/// 错误代码
		///</summary>
		
		private int? failCode_;
		
		///<summary>
		/// 失败信息
		///</summary>
		
		private string failMsg_;
		
		///<summary>
		/// 回滚订单ip
		///</summary>
		
		private string createIp_;
		
		///<summary>
		/// 回滚订单时间(yyyy-MM-dd HH:mm:ss)
		///</summary>
		
		private string createTime_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderIdSnVO> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<com.vip.order.common.pojo.order.vo.OrderIdSnVO> value){
			this.orderSnList_ = value;
		}
		public int? GetFailType(){
			return this.failType_;
		}
		
		public void SetFailType(int? value){
			this.failType_ = value;
		}
		public int? GetFailCode(){
			return this.failCode_;
		}
		
		public void SetFailCode(int? value){
			this.failCode_ = value;
		}
		public string GetFailMsg(){
			return this.failMsg_;
		}
		
		public void SetFailMsg(string value){
			this.failMsg_ = value;
		}
		public string GetCreateIp(){
			return this.createIp_;
		}
		
		public void SetCreateIp(string value){
			this.createIp_ = value;
		}
		public string GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(string value){
			this.createTime_ = value;
		}
		
	}
	
}