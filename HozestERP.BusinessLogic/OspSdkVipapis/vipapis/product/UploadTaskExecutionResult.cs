using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class UploadTaskExecutionResult {
		
		///<summary>
		/// 任务id
		///</summary>
		
		private long? task_id_;
		
		///<summary>
		/// 处理状态。0：处理中；1：处理成功；2:转换被忽略（同一个图片连续两个操作，前面的操作将被忽略）；3：处理失败（需要重试）；4:处理错误（不需要重试）
		///</summary>
		
		private short? process_status_;
		
		///<summary>
		/// 错误码。3：OSP异常失败；4：   调用ImageApi异常；5：其他异常；8：图片index非法
		///</summary>
		
		private short? failure_code_;
		
		///<summary>
		/// 失败原因描述
		///</summary>
		
		private string failure_reason_;
		
		public long? GetTask_id(){
			return this.task_id_;
		}
		
		public void SetTask_id(long? value){
			this.task_id_ = value;
		}
		public short? GetProcess_status(){
			return this.process_status_;
		}
		
		public void SetProcess_status(short? value){
			this.process_status_ = value;
		}
		public short? GetFailure_code(){
			return this.failure_code_;
		}
		
		public void SetFailure_code(short? value){
			this.failure_code_ = value;
		}
		public string GetFailure_reason(){
			return this.failure_reason_;
		}
		
		public void SetFailure_reason(string value){
			this.failure_reason_ = value;
		}
		
	}
	
}