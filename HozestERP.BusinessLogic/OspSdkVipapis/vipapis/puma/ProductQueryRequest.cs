using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class ProductQueryRequest {
		
		///<summary>
		/// 分页结构体
		///</summary>
		
		private vipapis.puma.Pagination pagination_;
		
		///<summary>
		/// 商品ID列表，最多100个
		///</summary>
		
		private List<long?> product_ids_;
		
		///<summary>
		/// 对应的品牌库中的品牌ID，最多10个
		///</summary>
		
		private List<string> brand_sns_;
		
		///<summary>
		/// 三级分类ID，最多10个
		///</summary>
		
		private List<int?> third_level_category_ids_;
		
		///<summary>
		/// 查询类型，可同时支持多个 1、商品运营信息 2、SPU信息 3、价格信息 4、推广页信息 5、库存信息
		///</summary>
		
		private List<int?> query_types_;
		
		///<summary>
		/// 在售状态： 0、在售 1、不在售  不传值：在售与不在售商品都返回
		///</summary>
		
		private int? is_on_sale_;
		
		public vipapis.puma.Pagination GetPagination(){
			return this.pagination_;
		}
		
		public void SetPagination(vipapis.puma.Pagination value){
			this.pagination_ = value;
		}
		public List<long?> GetProduct_ids(){
			return this.product_ids_;
		}
		
		public void SetProduct_ids(List<long?> value){
			this.product_ids_ = value;
		}
		public List<string> GetBrand_sns(){
			return this.brand_sns_;
		}
		
		public void SetBrand_sns(List<string> value){
			this.brand_sns_ = value;
		}
		public List<int?> GetThird_level_category_ids(){
			return this.third_level_category_ids_;
		}
		
		public void SetThird_level_category_ids(List<int?> value){
			this.third_level_category_ids_ = value;
		}
		public List<int?> GetQuery_types(){
			return this.query_types_;
		}
		
		public void SetQuery_types(List<int?> value){
			this.query_types_ = value;
		}
		public int? GetIs_on_sale(){
			return this.is_on_sale_;
		}
		
		public void SetIs_on_sale(int? value){
			this.is_on_sale_ = value;
		}
		
	}
	
}