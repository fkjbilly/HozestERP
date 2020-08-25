using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class VipGoodRecordAttachResponse {
		
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
		
		private Dictionary<string, string> data_;
		
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
		public Dictionary<string, string> GetData(){
			return this.data_;
		}
		
		public void SetData(Dictionary<string, string> value){
			this.data_ = value;
		}
		
	}
	
}