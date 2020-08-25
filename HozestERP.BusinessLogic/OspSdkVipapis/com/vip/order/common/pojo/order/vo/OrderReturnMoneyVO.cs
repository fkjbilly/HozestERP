using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderReturnMoneyVO {
		
		///<summary>
		/// 订单退款金额
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.ReturnMoneyVO returnMoney_;
		
		///<summary>
		/// 订单退款类型
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.ReturnTypeVO returnType_;
		
		///<summary>
		/// 退回的虚拟金额
		///</summary>
		
		private string returnVirtualMoney_;
		
		public com.vip.order.common.pojo.order.vo.ReturnMoneyVO GetReturnMoney(){
			return this.returnMoney_;
		}
		
		public void SetReturnMoney(com.vip.order.common.pojo.order.vo.ReturnMoneyVO value){
			this.returnMoney_ = value;
		}
		public com.vip.order.common.pojo.order.vo.ReturnTypeVO GetReturnType(){
			return this.returnType_;
		}
		
		public void SetReturnType(com.vip.order.common.pojo.order.vo.ReturnTypeVO value){
			this.returnType_ = value;
		}
		public string GetReturnVirtualMoney(){
			return this.returnVirtualMoney_;
		}
		
		public void SetReturnVirtualMoney(string value){
			this.returnVirtualMoney_ = value;
		}
		
	}
	
}