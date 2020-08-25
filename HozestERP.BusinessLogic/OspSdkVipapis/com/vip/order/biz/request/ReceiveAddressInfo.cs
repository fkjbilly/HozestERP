using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ReceiveAddressInfo {
		
		///<summary>
		/// 地址ID
		///</summary>
		
		private long? addressId_;
		
		///<summary>
		/// 地址类型,1-家庭，2-工作,3-其他
		///</summary>
		
		private int? addressType_;
		
		///<summary>
		/// 配送天数
		///</summary>
		
		private int? transportDays_;
		
		///<summary>
		/// 配送时间,1:白天 2:全天 3:夜间
		///</summary>
		
		private int? transportTimeType_;
		
		public long? GetAddressId(){
			return this.addressId_;
		}
		
		public void SetAddressId(long? value){
			this.addressId_ = value;
		}
		public int? GetAddressType(){
			return this.addressType_;
		}
		
		public void SetAddressType(int? value){
			this.addressType_ = value;
		}
		public int? GetTransportDays(){
			return this.transportDays_;
		}
		
		public void SetTransportDays(int? value){
			this.transportDays_ = value;
		}
		public int? GetTransportTimeType(){
			return this.transportTimeType_;
		}
		
		public void SetTransportTimeType(int? value){
			this.transportTimeType_ = value;
		}
		
	}
	
}