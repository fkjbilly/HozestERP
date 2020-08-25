using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class UploadImageResult {
		
		///<summary>
		/// 处理状态;0:处理成功；1：处理失败
		/// @sampleValue process_status 0
		///</summary>
		
		private int? process_status_;
		
		///<summary>
		/// 失败信息
		/// @sampleValue failure_info 找不到对应的商品信息
		///</summary>
		
		private string failure_info_;
		
		public int? GetProcess_status(){
			return this.process_status_;
		}
		
		public void SetProcess_status(int? value){
			this.process_status_ = value;
		}
		public string GetFailure_info(){
			return this.failure_info_;
		}
		
		public void SetFailure_info(string value){
			this.failure_info_ = value;
		}
		
	}
	
}