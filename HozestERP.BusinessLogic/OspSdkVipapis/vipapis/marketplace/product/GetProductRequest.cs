using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class GetProductRequest {
		
		///<summary>
		/// 商品spu编号
		/// @sampleValue spu_id 113113302011
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 款号(商家在唯品会新增商品时自己录入的spu标识编码)(不可重复)
		/// @sampleValue outer_spu_id 12322111
		///</summary>
		
		private string outer_spu_id_;
		
		///<summary>
		/// 商品状态编码 （1：上架，0：下架）
		/// @sampleValue shelf_status 1
		///</summary>
		
		private string shelf_status_;
		
		///<summary>
		/// 商品审核状态（11待提交，12待审核，13审核通过，14审核不通过）
		/// @sampleValue audit_status 11
		///</summary>
		
		private string audit_status_;
		
		///<summary>
		/// 每页数量，默认50 最大200
		/// @sampleValue limit 50
		///</summary>
		
		private int? limit_;
		
		///<summary>
		/// 页码
		/// @sampleValue page 1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 类目ID 一级
		/// @sampleValue first_category_id 12
		///</summary>
		
		private int? first_category_id_;
		
		///<summary>
		/// 类目ID 二级
		/// @sampleValue second_category_id 22
		///</summary>
		
		private int? second_category_id_;
		
		///<summary>
		/// 类目ID 三级
		/// @sampleValue third_category_id 916
		///</summary>
		
		private int? third_category_id_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public string GetOuter_spu_id(){
			return this.outer_spu_id_;
		}
		
		public void SetOuter_spu_id(string value){
			this.outer_spu_id_ = value;
		}
		public string GetShelf_status(){
			return this.shelf_status_;
		}
		
		public void SetShelf_status(string value){
			this.shelf_status_ = value;
		}
		public string GetAudit_status(){
			return this.audit_status_;
		}
		
		public void SetAudit_status(string value){
			this.audit_status_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetFirst_category_id(){
			return this.first_category_id_;
		}
		
		public void SetFirst_category_id(int? value){
			this.first_category_id_ = value;
		}
		public int? GetSecond_category_id(){
			return this.second_category_id_;
		}
		
		public void SetSecond_category_id(int? value){
			this.second_category_id_ = value;
		}
		public int? GetThird_category_id(){
			return this.third_category_id_;
		}
		
		public void SetThird_category_id(int? value){
			this.third_category_id_ = value;
		}
		
	}
	
}