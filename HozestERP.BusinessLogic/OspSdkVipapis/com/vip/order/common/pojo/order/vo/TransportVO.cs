using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class TransportVO {
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transportNumber_;
		
		///<summary>
		/// 操作过程
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.TransportOperateLogVO> transportOperatorLogList_;
		
		///<summary>
		/// 是否搭配落地标识，1：是；0：否
		///</summary>
		
		private int? isCod_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string transportName_;
		
		///<summary>
		/// 承运商id
		///</summary>
		
		private string transportId_;
		
		///<summary>
		/// 发货时间戳，单位为秒
		///</summary>
		
		private long? transportTime_;
		
		public string GetTransportNumber(){
			return this.transportNumber_;
		}
		
		public void SetTransportNumber(string value){
			this.transportNumber_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.TransportOperateLogVO> GetTransportOperatorLogList(){
			return this.transportOperatorLogList_;
		}
		
		public void SetTransportOperatorLogList(List<com.vip.order.common.pojo.order.vo.TransportOperateLogVO> value){
			this.transportOperatorLogList_ = value;
		}
		public int? GetIsCod(){
			return this.isCod_;
		}
		
		public void SetIsCod(int? value){
			this.isCod_ = value;
		}
		public string GetTransportName(){
			return this.transportName_;
		}
		
		public void SetTransportName(string value){
			this.transportName_ = value;
		}
		public string GetTransportId(){
			return this.transportId_;
		}
		
		public void SetTransportId(string value){
			this.transportId_ = value;
		}
		public long? GetTransportTime(){
			return this.transportTime_;
		}
		
		public void SetTransportTime(long? value){
			this.transportTime_ = value;
		}
		
	}
	
}