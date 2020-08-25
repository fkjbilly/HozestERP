using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class VipGoodRecordResponse {
		
		///<summary>
		/// 响应码：100-成功，其它-失败
		///</summary>
		
		private string respCode_;
		
		///<summary>
		/// 返回信息
		///</summary>
		
		private string msg_;
		
		///<summary>
		/// 商品备案信息列表
		///</summary>
		
		private List<com.vip.haitao.base.osp.service.record.VipGoodRecordResult> dataList_;
		
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
		public List<com.vip.haitao.base.osp.service.record.VipGoodRecordResult> GetDataList(){
			return this.dataList_;
		}
		
		public void SetDataList(List<com.vip.haitao.base.osp.service.record.VipGoodRecordResult> value){
			this.dataList_ = value;
		}
		
	}
	
}