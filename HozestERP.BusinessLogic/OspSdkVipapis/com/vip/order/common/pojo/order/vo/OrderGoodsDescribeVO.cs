using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderGoodsDescribeVO {
		
		///<summary>
		/// 商品序号
		///</summary>
		
		private int? seqNum_;
		
		///<summary>
		/// 备注信息类型
		///</summary>
		
		private int? descType_;
		
		///<summary>
		/// 备注信息内容
		///</summary>
		
		private string descRemark_;
		
		public int? GetSeqNum(){
			return this.seqNum_;
		}
		
		public void SetSeqNum(int? value){
			this.seqNum_ = value;
		}
		public int? GetDescType(){
			return this.descType_;
		}
		
		public void SetDescType(int? value){
			this.descType_ = value;
		}
		public string GetDescRemark(){
			return this.descRemark_;
		}
		
		public void SetDescRemark(string value){
			this.descRemark_ = value;
		}
		
	}
	
}