using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vsizetable{
	
	
	
	
	
	public class GetDimensionInfoResponse {
		
		///<summary>
		/// 尺码表模板维度信息列表
		///</summary>
		
		private List<vipapis.vsizetable.DimensionInfo> dimension_infos_;
		
		public List<vipapis.vsizetable.DimensionInfo> GetDimension_infos(){
			return this.dimension_infos_;
		}
		
		public void SetDimension_infos(List<vipapis.vsizetable.DimensionInfo> value){
			this.dimension_infos_ = value;
		}
		
	}
	
}