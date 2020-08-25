using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class SizeTemplateDo {
		
		///<summary>
		/// 主键id
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 模板编码
		///</summary>
		
		private string code_;
		
		///<summary>
		/// 模板名称
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 尺码详情
		///</summary>
		
		private List<vipapis.size.SizeDetailDo> size_detail_does_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public string GetCode(){
			return this.code_;
		}
		
		public void SetCode(string value){
			this.code_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public List<vipapis.size.SizeDetailDo> GetSize_detail_does(){
			return this.size_detail_does_;
		}
		
		public void SetSize_detail_does(List<vipapis.size.SizeDetailDo> value){
			this.size_detail_does_ = value;
		}
		
	}
	
}