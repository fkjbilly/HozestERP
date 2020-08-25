using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class SvipGoodsInfo {
		
		///<summary>
		/// level
		///</summary>
		
		private string level_;
		
		///<summary>
		/// bizType
		///</summary>
		
		private int? bizType_;
		
		///<summary>
		/// goodsType
		///</summary>
		
		private int? goodsType_;
		
		///<summary>
		/// vpid
		///</summary>
		
		private string vpid_;
		
		///<summary>
		/// price
		///</summary>
		
		private string price_;
		
		///<summary>
		/// remark
		///</summary>
		
		private string remark_;
		
		public string GetLevel(){
			return this.level_;
		}
		
		public void SetLevel(string value){
			this.level_ = value;
		}
		public int? GetBizType(){
			return this.bizType_;
		}
		
		public void SetBizType(int? value){
			this.bizType_ = value;
		}
		public int? GetGoodsType(){
			return this.goodsType_;
		}
		
		public void SetGoodsType(int? value){
			this.goodsType_ = value;
		}
		public string GetVpid(){
			return this.vpid_;
		}
		
		public void SetVpid(string value){
			this.vpid_ = value;
		}
		public string GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(string value){
			this.price_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}