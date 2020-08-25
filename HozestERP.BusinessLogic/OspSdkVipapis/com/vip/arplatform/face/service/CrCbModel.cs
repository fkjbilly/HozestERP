using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class CrCbModel {
		
		///<summary>
		/// 红色差信号
		///</summary>
		
		private int? cr_;
		
		///<summary>
		/// 蓝色差信号
		///</summary>
		
		private int? cb_;
		
		public int? GetCr(){
			return this.cr_;
		}
		
		public void SetCr(int? value){
			this.cr_ = value;
		}
		public int? GetCb(){
			return this.cb_;
		}
		
		public void SetCb(int? value){
			this.cb_ = value;
		}
		
	}
	
}