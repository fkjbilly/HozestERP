using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class SizeCategoryDo {
		
		///<summary>
		/// 主键id
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 唯品会三级类目id
		///</summary>
		
		private int? category_id_;
		
		///<summary>
		/// 示例图片
		///</summary>
		
		private string size_pic_;
		
		///<summary>
		/// 尺码模板id
		///</summary>
		
		private long? size_template_id_;
		
		///<summary>
		/// 尺码详情
		///</summary>
		
		private List<vipapis.size.SizeDetailDo> size_detail_does_;
		
		///<summary>
		/// 尺码模板
		///</summary>
		
		private vipapis.size.SizeTemplateDo size_template_do_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public int? GetCategory_id(){
			return this.category_id_;
		}
		
		public void SetCategory_id(int? value){
			this.category_id_ = value;
		}
		public string GetSize_pic(){
			return this.size_pic_;
		}
		
		public void SetSize_pic(string value){
			this.size_pic_ = value;
		}
		public long? GetSize_template_id(){
			return this.size_template_id_;
		}
		
		public void SetSize_template_id(long? value){
			this.size_template_id_ = value;
		}
		public List<vipapis.size.SizeDetailDo> GetSize_detail_does(){
			return this.size_detail_does_;
		}
		
		public void SetSize_detail_does(List<vipapis.size.SizeDetailDo> value){
			this.size_detail_does_ = value;
		}
		public vipapis.size.SizeTemplateDo GetSize_template_do(){
			return this.size_template_do_;
		}
		
		public void SetSize_template_do(vipapis.size.SizeTemplateDo value){
			this.size_template_do_ = value;
		}
		
	}
	
}