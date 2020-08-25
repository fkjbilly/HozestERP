using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class GoodRecordResponse {
		
		///<summary>
		/// 响应码：100-成功，其它-失败
		///</summary>
		
		private string respCode_;
		
		///<summary>
		/// 返回信息
		///</summary>
		
		private string msg_;
		
		///<summary>
		/// 需要备案的商品列表
		///</summary>
		
		private List<com.vip.haitao.base.osp.service.record.HtGoodRecordModel> goodRecordList_;
		
		///<summary>
		/// 失败时返回对应条码，成功时返回取消接收的条码
		///</summary>
		
		private List<string> sizeSnList_;
		
		public string GetRespCode(){
			return this.respCode_;
		}
		
		public void SetRespCode(string value){
			this.respCode_ = value;
		}
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		public List<com.vip.haitao.base.osp.service.record.HtGoodRecordModel> GetGoodRecordList(){
			return this.goodRecordList_;
		}
		
		public void SetGoodRecordList(List<com.vip.haitao.base.osp.service.record.HtGoodRecordModel> value){
			this.goodRecordList_ = value;
		}
		public List<string> GetSizeSnList(){
			return this.sizeSnList_;
		}
		
		public void SetSizeSnList(List<string> value){
			this.sizeSnList_ = value;
		}
		
	}
	
}