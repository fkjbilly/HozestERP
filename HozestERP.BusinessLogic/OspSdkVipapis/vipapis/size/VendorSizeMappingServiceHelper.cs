using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.size{
	
	
	public class VendorSizeMappingServiceHelper {
		
		
		
		public class addSizeCategories_args {
			
			///<summary>
			/// 类目
			///</summary>
			
			private List<vipapis.size.SizeCategoryDo> size_category_does_;
			
			public List<vipapis.size.SizeCategoryDo> GetSize_category_does(){
				return this.size_category_does_;
			}
			
			public void SetSize_category_does(List<vipapis.size.SizeCategoryDo> value){
				this.size_category_does_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTable_args {
			
			///<summary>
			/// 新增请求结构体
			///</summary>
			
			private vipapis.size.AddSizeTableRequest req_;
			
			public vipapis.size.AddSizeTableRequest GetReq(){
				return this.req_;
			}
			
			public void SetReq(vipapis.size.AddSizeTableRequest value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTemplate_args {
			
			///<summary>
			/// 尺码模板代码
			///</summary>
			
			private string size_template_code_;
			
			///<summary>
			/// 尺码模板名称
			///</summary>
			
			private string size_template_name_;
			
			public string GetSize_template_code(){
				return this.size_template_code_;
			}
			
			public void SetSize_template_code(string value){
				this.size_template_code_ = value;
			}
			public string GetSize_template_name(){
				return this.size_template_name_;
			}
			
			public void SetSize_template_name(string value){
				this.size_template_name_ = value;
			}
			
		}
		
		
		
		
		public class findAllSizeDetail_args {
			
			
		}
		
		
		
		
		public class findBindedCategory_args {
			
			///<summary>
			/// 类目Id
			///</summary>
			
			private string category_id_;
			
			public string GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(string value){
				this.category_id_ = value;
			}
			
		}
		
		
		
		
		public class findCategoryByTemplateId_args {
			
			///<summary>
			/// 尺码模板id
			///</summary>
			
			private long? size_template_id_;
			
			public long? GetSize_template_id(){
				return this.size_template_id_;
			}
			
			public void SetSize_template_id(long? value){
				this.size_template_id_ = value;
			}
			
		}
		
		
		
		
		public class findSizeMapping_args {
			
			///<summary>
			/// 查询请求结构体
			///</summary>
			
			private vipapis.size.FindSizeMappingRequest req_;
			
			public vipapis.size.FindSizeMappingRequest GetReq(){
				return this.req_;
			}
			
			public void SetReq(vipapis.size.FindSizeMappingRequest value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class findSizeTemplateDetail_args {
			
			///<summary>
			/// 尺码模板
			///</summary>
			
			private vipapis.size.SizeTemplateDo size_template_do_;
			
			public vipapis.size.SizeTemplateDo GetSize_template_do(){
				return this.size_template_do_;
			}
			
			public void SetSize_template_do(vipapis.size.SizeTemplateDo value){
				this.size_template_do_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class listVendorSizeTable_args {
			
			///<summary>
			/// 供应商ID查询供应商尺码表信息请求
			///</summary>
			
			private vipapis.size.ListVendorSizeTableRequest request_;
			
			public vipapis.size.ListVendorSizeTableRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.size.ListVendorSizeTableRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class selectByCondition_args {
			
			///<summary>
			/// 
			///</summary>
			
			private vipapis.size.VendorSizeMappingDo condition_;
			
			public vipapis.size.VendorSizeMappingDo GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(vipapis.size.VendorSizeMappingDo value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class unBindingCategory_args {
			
			///<summary>
			/// 类目Id
			///</summary>
			
			private string category_id_;
			
			public string GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(string value){
				this.category_id_ = value;
			}
			
		}
		
		
		
		
		public class updateSizeTable_args {
			
			///<summary>
			/// 更新请求结构体
			///</summary>
			
			private vipapis.size.UpdateSizeTableRequest req_;
			
			public vipapis.size.UpdateSizeTableRequest GetReq(){
				return this.req_;
			}
			
			public void SetReq(vipapis.size.UpdateSizeTableRequest value){
				this.req_ = value;
			}
			
		}
		
		
		
		
		public class updateSizeTemplate_args {
			
			///<summary>
			/// 尺码模板
			///</summary>
			
			private vipapis.size.SizeTemplateDo size_template_do_;
			
			public vipapis.size.SizeTemplateDo GetSize_template_do(){
				return this.size_template_do_;
			}
			
			public void SetSize_template_do(vipapis.size.SizeTemplateDo value){
				this.size_template_do_ = value;
			}
			
		}
		
		
		
		
		public class updateSizeTemplateDetail_args {
			
			///<summary>
			/// 尺码模板id
			///</summary>
			
			private long? size_template_id_;
			
			///<summary>
			/// 尺码详情id
			///</summary>
			
			private List<long?> size_detail_id_;
			
			public long? GetSize_template_id(){
				return this.size_template_id_;
			}
			
			public void SetSize_template_id(long? value){
				this.size_template_id_ = value;
			}
			public List<long?> GetSize_detail_id(){
				return this.size_detail_id_;
			}
			
			public void SetSize_detail_id(List<long?> value){
				this.size_detail_id_ = value;
			}
			
		}
		
		
		
		
		public class addSizeCategories_result {
			
			///<summary>
			/// 成功记录数
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTable_result {
			
			///<summary>
			/// 尺码表ID
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTemplate_result {
			
			///<summary>
			/// 模板id
			///</summary>
			
			private long? success_;
			
			public long? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(long? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class findAllSizeDetail_result {
			
			///<summary>
			/// 尺码详情列表
			///</summary>
			
			private List<vipapis.size.SizeDetailDo> success_;
			
			public List<vipapis.size.SizeDetailDo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.size.SizeDetailDo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class findBindedCategory_result {
			
			///<summary>
			/// 查询类目-模板绑定信息
			///</summary>
			
			private List<vipapis.size.SizeCategoryDo> success_;
			
			public List<vipapis.size.SizeCategoryDo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.size.SizeCategoryDo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class findCategoryByTemplateId_result {
			
			///<summary>
			/// 尺码列表
			///</summary>
			
			private List<vipapis.size.SizeCategoryDo> success_;
			
			public List<vipapis.size.SizeCategoryDo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.size.SizeCategoryDo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class findSizeMapping_result {
			
			///<summary>
			/// 类目和尺码表匹配信息
			///</summary>
			
			private vipapis.size.FindSizeMappingResponse success_;
			
			public vipapis.size.FindSizeMappingResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.size.FindSizeMappingResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class findSizeTemplateDetail_result {
			
			///<summary>
			/// 尺码模板
			///</summary>
			
			private List<vipapis.size.SizeTemplateDo> success_;
			
			public List<vipapis.size.SizeTemplateDo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.size.SizeTemplateDo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_result {
			
			///<summary>
			///</summary>
			
			private com.vip.hermes.core.health.CheckResult success_;
			
			public com.vip.hermes.core.health.CheckResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.hermes.core.health.CheckResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class listVendorSizeTable_result {
			
			///<summary>
			/// 供应商尺码表信息
			///</summary>
			
			private vipapis.size.ListVendorSizeTableResponse success_;
			
			public vipapis.size.ListVendorSizeTableResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.size.ListVendorSizeTableResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class selectByCondition_result {
			
			///<summary>
			/// 列表
			///</summary>
			
			private List<vipapis.size.VendorSizeMappingDo> success_;
			
			public List<vipapis.size.VendorSizeMappingDo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.size.VendorSizeMappingDo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class unBindingCategory_result {
			
			///<summary>
			/// 0-失败，1-成功
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateSizeTable_result {
			
			///<summary>
			/// 尺码表ID
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateSizeTemplate_result {
			
			///<summary>
			/// 0-失败，1-成功
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateSizeTemplateDetail_result {
			
			///<summary>
			/// 修改记录数
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class addSizeCategories_argsHelper : TBeanSerializer<addSizeCategories_args>
		{
			
			public static addSizeCategories_argsHelper OBJ = new addSizeCategories_argsHelper();
			
			public static addSizeCategories_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeCategories_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.size.SizeCategoryDo> value;
					
					value = new List<vipapis.size.SizeCategoryDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.size.SizeCategoryDo elem0;
							
							elem0 = new vipapis.size.SizeCategoryDo();
							vipapis.size.SizeCategoryDoHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSize_category_does(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeCategories_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSize_category_does() != null) {
					
					oprot.WriteFieldBegin("size_category_does");
					
					oprot.WriteListBegin();
					foreach(vipapis.size.SizeCategoryDo _item0 in structs.GetSize_category_does()){
						
						
						vipapis.size.SizeCategoryDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeCategories_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTable_argsHelper : TBeanSerializer<addSizeTable_args>
		{
			
			public static addSizeTable_argsHelper OBJ = new addSizeTable_argsHelper();
			
			public static addSizeTable_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTable_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.size.AddSizeTableRequest value;
					
					value = new vipapis.size.AddSizeTableRequest();
					vipapis.size.AddSizeTableRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTable_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					vipapis.size.AddSizeTableRequestHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTable_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTemplate_argsHelper : TBeanSerializer<addSizeTemplate_args>
		{
			
			public static addSizeTemplate_argsHelper OBJ = new addSizeTemplate_argsHelper();
			
			public static addSizeTemplate_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTemplate_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSize_template_code(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSize_template_name(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTemplate_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSize_template_code() != null) {
					
					oprot.WriteFieldBegin("size_template_code");
					oprot.WriteString(structs.GetSize_template_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size_template_code can not be null!");
				}
				
				
				if(structs.GetSize_template_name() != null) {
					
					oprot.WriteFieldBegin("size_template_name");
					oprot.WriteString(structs.GetSize_template_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size_template_name can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTemplate_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findAllSizeDetail_argsHelper : TBeanSerializer<findAllSizeDetail_args>
		{
			
			public static findAllSizeDetail_argsHelper OBJ = new findAllSizeDetail_argsHelper();
			
			public static findAllSizeDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findAllSizeDetail_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findAllSizeDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findAllSizeDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findBindedCategory_argsHelper : TBeanSerializer<findBindedCategory_args>
		{
			
			public static findBindedCategory_argsHelper OBJ = new findBindedCategory_argsHelper();
			
			public static findBindedCategory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findBindedCategory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findBindedCategory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteString(structs.GetCategory_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findBindedCategory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findCategoryByTemplateId_argsHelper : TBeanSerializer<findCategoryByTemplateId_args>
		{
			
			public static findCategoryByTemplateId_argsHelper OBJ = new findCategoryByTemplateId_argsHelper();
			
			public static findCategoryByTemplateId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findCategoryByTemplateId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSize_template_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findCategoryByTemplateId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSize_template_id() != null) {
					
					oprot.WriteFieldBegin("size_template_id");
					oprot.WriteI64((long)structs.GetSize_template_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findCategoryByTemplateId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findSizeMapping_argsHelper : TBeanSerializer<findSizeMapping_args>
		{
			
			public static findSizeMapping_argsHelper OBJ = new findSizeMapping_argsHelper();
			
			public static findSizeMapping_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findSizeMapping_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.size.FindSizeMappingRequest value;
					
					value = new vipapis.size.FindSizeMappingRequest();
					vipapis.size.FindSizeMappingRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findSizeMapping_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					vipapis.size.FindSizeMappingRequestHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findSizeMapping_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findSizeTemplateDetail_argsHelper : TBeanSerializer<findSizeTemplateDetail_args>
		{
			
			public static findSizeTemplateDetail_argsHelper OBJ = new findSizeTemplateDetail_argsHelper();
			
			public static findSizeTemplateDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findSizeTemplateDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.size.SizeTemplateDo value;
					
					value = new vipapis.size.SizeTemplateDo();
					vipapis.size.SizeTemplateDoHelper.getInstance().Read(value, iprot);
					
					structs.SetSize_template_do(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findSizeTemplateDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSize_template_do() != null) {
					
					oprot.WriteFieldBegin("size_template_do");
					
					vipapis.size.SizeTemplateDoHelper.getInstance().Write(structs.GetSize_template_do(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findSizeTemplateDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : TBeanSerializer<healthCheck_args>
		{
			
			public static healthCheck_argsHelper OBJ = new healthCheck_argsHelper();
			
			public static healthCheck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class listVendorSizeTable_argsHelper : TBeanSerializer<listVendorSizeTable_args>
		{
			
			public static listVendorSizeTable_argsHelper OBJ = new listVendorSizeTable_argsHelper();
			
			public static listVendorSizeTable_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listVendorSizeTable_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.size.ListVendorSizeTableRequest value;
					
					value = new vipapis.size.ListVendorSizeTableRequest();
					vipapis.size.ListVendorSizeTableRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(listVendorSizeTable_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.size.ListVendorSizeTableRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(listVendorSizeTable_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectByCondition_argsHelper : TBeanSerializer<selectByCondition_args>
		{
			
			public static selectByCondition_argsHelper OBJ = new selectByCondition_argsHelper();
			
			public static selectByCondition_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByCondition_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.size.VendorSizeMappingDo value;
					
					value = new vipapis.size.VendorSizeMappingDo();
					vipapis.size.VendorSizeMappingDoHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectByCondition_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					vipapis.size.VendorSizeMappingDoHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByCondition_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class unBindingCategory_argsHelper : TBeanSerializer<unBindingCategory_args>
		{
			
			public static unBindingCategory_argsHelper OBJ = new unBindingCategory_argsHelper();
			
			public static unBindingCategory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(unBindingCategory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(unBindingCategory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteString(structs.GetCategory_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(unBindingCategory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTable_argsHelper : TBeanSerializer<updateSizeTable_args>
		{
			
			public static updateSizeTable_argsHelper OBJ = new updateSizeTable_argsHelper();
			
			public static updateSizeTable_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTable_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.size.UpdateSizeTableRequest value;
					
					value = new vipapis.size.UpdateSizeTableRequest();
					vipapis.size.UpdateSizeTableRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetReq(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTable_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReq() != null) {
					
					oprot.WriteFieldBegin("req");
					
					vipapis.size.UpdateSizeTableRequestHelper.getInstance().Write(structs.GetReq(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("req can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTable_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTemplate_argsHelper : TBeanSerializer<updateSizeTemplate_args>
		{
			
			public static updateSizeTemplate_argsHelper OBJ = new updateSizeTemplate_argsHelper();
			
			public static updateSizeTemplate_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTemplate_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.size.SizeTemplateDo value;
					
					value = new vipapis.size.SizeTemplateDo();
					vipapis.size.SizeTemplateDoHelper.getInstance().Read(value, iprot);
					
					structs.SetSize_template_do(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTemplate_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSize_template_do() != null) {
					
					oprot.WriteFieldBegin("size_template_do");
					
					vipapis.size.SizeTemplateDoHelper.getInstance().Write(structs.GetSize_template_do(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTemplate_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTemplateDetail_argsHelper : TBeanSerializer<updateSizeTemplateDetail_args>
		{
			
			public static updateSizeTemplateDetail_argsHelper OBJ = new updateSizeTemplateDetail_argsHelper();
			
			public static updateSizeTemplateDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTemplateDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSize_template_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem0;
							elem0 = iprot.ReadI64(); 
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSize_detail_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTemplateDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSize_template_id() != null) {
					
					oprot.WriteFieldBegin("size_template_id");
					oprot.WriteI64((long)structs.GetSize_template_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size_template_id can not be null!");
				}
				
				
				if(structs.GetSize_detail_id() != null) {
					
					oprot.WriteFieldBegin("size_detail_id");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetSize_detail_id()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size_detail_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTemplateDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeCategories_resultHelper : TBeanSerializer<addSizeCategories_result>
		{
			
			public static addSizeCategories_resultHelper OBJ = new addSizeCategories_resultHelper();
			
			public static addSizeCategories_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeCategories_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeCategories_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeCategories_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTable_resultHelper : TBeanSerializer<addSizeTable_result>
		{
			
			public static addSizeTable_resultHelper OBJ = new addSizeTable_resultHelper();
			
			public static addSizeTable_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTable_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTable_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTable_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTemplate_resultHelper : TBeanSerializer<addSizeTemplate_result>
		{
			
			public static addSizeTemplate_resultHelper OBJ = new addSizeTemplate_resultHelper();
			
			public static addSizeTemplate_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTemplate_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTemplate_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI64((long)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTemplate_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findAllSizeDetail_resultHelper : TBeanSerializer<findAllSizeDetail_result>
		{
			
			public static findAllSizeDetail_resultHelper OBJ = new findAllSizeDetail_resultHelper();
			
			public static findAllSizeDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findAllSizeDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.size.SizeDetailDo> value;
					
					value = new List<vipapis.size.SizeDetailDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.size.SizeDetailDo elem0;
							
							elem0 = new vipapis.size.SizeDetailDo();
							vipapis.size.SizeDetailDoHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findAllSizeDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.size.SizeDetailDo _item0 in structs.GetSuccess()){
						
						
						vipapis.size.SizeDetailDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findAllSizeDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findBindedCategory_resultHelper : TBeanSerializer<findBindedCategory_result>
		{
			
			public static findBindedCategory_resultHelper OBJ = new findBindedCategory_resultHelper();
			
			public static findBindedCategory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findBindedCategory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.size.SizeCategoryDo> value;
					
					value = new List<vipapis.size.SizeCategoryDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.size.SizeCategoryDo elem1;
							
							elem1 = new vipapis.size.SizeCategoryDo();
							vipapis.size.SizeCategoryDoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findBindedCategory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.size.SizeCategoryDo _item0 in structs.GetSuccess()){
						
						
						vipapis.size.SizeCategoryDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findBindedCategory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findCategoryByTemplateId_resultHelper : TBeanSerializer<findCategoryByTemplateId_result>
		{
			
			public static findCategoryByTemplateId_resultHelper OBJ = new findCategoryByTemplateId_resultHelper();
			
			public static findCategoryByTemplateId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findCategoryByTemplateId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.size.SizeCategoryDo> value;
					
					value = new List<vipapis.size.SizeCategoryDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.size.SizeCategoryDo elem1;
							
							elem1 = new vipapis.size.SizeCategoryDo();
							vipapis.size.SizeCategoryDoHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findCategoryByTemplateId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.size.SizeCategoryDo _item0 in structs.GetSuccess()){
						
						
						vipapis.size.SizeCategoryDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findCategoryByTemplateId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findSizeMapping_resultHelper : TBeanSerializer<findSizeMapping_result>
		{
			
			public static findSizeMapping_resultHelper OBJ = new findSizeMapping_resultHelper();
			
			public static findSizeMapping_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findSizeMapping_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.size.FindSizeMappingResponse value;
					
					value = new vipapis.size.FindSizeMappingResponse();
					vipapis.size.FindSizeMappingResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findSizeMapping_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.size.FindSizeMappingResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findSizeMapping_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findSizeTemplateDetail_resultHelper : TBeanSerializer<findSizeTemplateDetail_result>
		{
			
			public static findSizeTemplateDetail_resultHelper OBJ = new findSizeTemplateDetail_resultHelper();
			
			public static findSizeTemplateDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findSizeTemplateDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.size.SizeTemplateDo> value;
					
					value = new List<vipapis.size.SizeTemplateDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.size.SizeTemplateDo elem0;
							
							elem0 = new vipapis.size.SizeTemplateDo();
							vipapis.size.SizeTemplateDoHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findSizeTemplateDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.size.SizeTemplateDo _item0 in structs.GetSuccess()){
						
						
						vipapis.size.SizeTemplateDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findSizeTemplateDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : TBeanSerializer<healthCheck_result>
		{
			
			public static healthCheck_resultHelper OBJ = new healthCheck_resultHelper();
			
			public static healthCheck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.hermes.core.health.CheckResult value;
					
					value = new com.vip.hermes.core.health.CheckResult();
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class listVendorSizeTable_resultHelper : TBeanSerializer<listVendorSizeTable_result>
		{
			
			public static listVendorSizeTable_resultHelper OBJ = new listVendorSizeTable_resultHelper();
			
			public static listVendorSizeTable_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(listVendorSizeTable_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.size.ListVendorSizeTableResponse value;
					
					value = new vipapis.size.ListVendorSizeTableResponse();
					vipapis.size.ListVendorSizeTableResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(listVendorSizeTable_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.size.ListVendorSizeTableResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(listVendorSizeTable_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectByCondition_resultHelper : TBeanSerializer<selectByCondition_result>
		{
			
			public static selectByCondition_resultHelper OBJ = new selectByCondition_resultHelper();
			
			public static selectByCondition_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByCondition_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.size.VendorSizeMappingDo> value;
					
					value = new List<vipapis.size.VendorSizeMappingDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.size.VendorSizeMappingDo elem0;
							
							elem0 = new vipapis.size.VendorSizeMappingDo();
							vipapis.size.VendorSizeMappingDoHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectByCondition_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.size.VendorSizeMappingDo _item0 in structs.GetSuccess()){
						
						
						vipapis.size.VendorSizeMappingDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByCondition_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class unBindingCategory_resultHelper : TBeanSerializer<unBindingCategory_result>
		{
			
			public static unBindingCategory_resultHelper OBJ = new unBindingCategory_resultHelper();
			
			public static unBindingCategory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(unBindingCategory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(unBindingCategory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(unBindingCategory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTable_resultHelper : TBeanSerializer<updateSizeTable_result>
		{
			
			public static updateSizeTable_resultHelper OBJ = new updateSizeTable_resultHelper();
			
			public static updateSizeTable_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTable_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTable_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTable_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTemplate_resultHelper : TBeanSerializer<updateSizeTemplate_result>
		{
			
			public static updateSizeTemplate_resultHelper OBJ = new updateSizeTemplate_resultHelper();
			
			public static updateSizeTemplate_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTemplate_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTemplate_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTemplate_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTemplateDetail_resultHelper : TBeanSerializer<updateSizeTemplateDetail_result>
		{
			
			public static updateSizeTemplateDetail_resultHelper OBJ = new updateSizeTemplateDetail_resultHelper();
			
			public static updateSizeTemplateDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTemplateDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTemplateDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTemplateDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorSizeMappingServiceClient : OspRestStub , VendorSizeMappingService  {
			
			
			public VendorSizeMappingServiceClient():base("vipapis.size.VendorSizeMappingService","1.0.0") {
				
				
			}
			
			
			
			public int? addSizeCategories(List<vipapis.size.SizeCategoryDo> size_category_does_) {
				
				send_addSizeCategories(size_category_does_);
				return recv_addSizeCategories(); 
				
			}
			
			
			private void send_addSizeCategories(List<vipapis.size.SizeCategoryDo> size_category_does_){
				
				InitInvocation("addSizeCategories");
				
				addSizeCategories_args args = new addSizeCategories_args();
				args.SetSize_category_does(size_category_does_);
				
				SendBase(args, addSizeCategories_argsHelper.getInstance());
			}
			
			
			private int? recv_addSizeCategories(){
				
				addSizeCategories_result result = new addSizeCategories_result();
				ReceiveBase(result, addSizeCategories_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string addSizeTable(vipapis.size.AddSizeTableRequest req_) {
				
				send_addSizeTable(req_);
				return recv_addSizeTable(); 
				
			}
			
			
			private void send_addSizeTable(vipapis.size.AddSizeTableRequest req_){
				
				InitInvocation("addSizeTable");
				
				addSizeTable_args args = new addSizeTable_args();
				args.SetReq(req_);
				
				SendBase(args, addSizeTable_argsHelper.getInstance());
			}
			
			
			private string recv_addSizeTable(){
				
				addSizeTable_result result = new addSizeTable_result();
				ReceiveBase(result, addSizeTable_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public long? addSizeTemplate(string size_template_code_,string size_template_name_) {
				
				send_addSizeTemplate(size_template_code_,size_template_name_);
				return recv_addSizeTemplate(); 
				
			}
			
			
			private void send_addSizeTemplate(string size_template_code_,string size_template_name_){
				
				InitInvocation("addSizeTemplate");
				
				addSizeTemplate_args args = new addSizeTemplate_args();
				args.SetSize_template_code(size_template_code_);
				args.SetSize_template_name(size_template_name_);
				
				SendBase(args, addSizeTemplate_argsHelper.getInstance());
			}
			
			
			private long? recv_addSizeTemplate(){
				
				addSizeTemplate_result result = new addSizeTemplate_result();
				ReceiveBase(result, addSizeTemplate_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.size.SizeDetailDo> findAllSizeDetail() {
				
				send_findAllSizeDetail();
				return recv_findAllSizeDetail(); 
				
			}
			
			
			private void send_findAllSizeDetail(){
				
				InitInvocation("findAllSizeDetail");
				
				findAllSizeDetail_args args = new findAllSizeDetail_args();
				
				SendBase(args, findAllSizeDetail_argsHelper.getInstance());
			}
			
			
			private List<vipapis.size.SizeDetailDo> recv_findAllSizeDetail(){
				
				findAllSizeDetail_result result = new findAllSizeDetail_result();
				ReceiveBase(result, findAllSizeDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.size.SizeCategoryDo> findBindedCategory(string category_id_) {
				
				send_findBindedCategory(category_id_);
				return recv_findBindedCategory(); 
				
			}
			
			
			private void send_findBindedCategory(string category_id_){
				
				InitInvocation("findBindedCategory");
				
				findBindedCategory_args args = new findBindedCategory_args();
				args.SetCategory_id(category_id_);
				
				SendBase(args, findBindedCategory_argsHelper.getInstance());
			}
			
			
			private List<vipapis.size.SizeCategoryDo> recv_findBindedCategory(){
				
				findBindedCategory_result result = new findBindedCategory_result();
				ReceiveBase(result, findBindedCategory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.size.SizeCategoryDo> findCategoryByTemplateId(long? size_template_id_) {
				
				send_findCategoryByTemplateId(size_template_id_);
				return recv_findCategoryByTemplateId(); 
				
			}
			
			
			private void send_findCategoryByTemplateId(long? size_template_id_){
				
				InitInvocation("findCategoryByTemplateId");
				
				findCategoryByTemplateId_args args = new findCategoryByTemplateId_args();
				args.SetSize_template_id(size_template_id_);
				
				SendBase(args, findCategoryByTemplateId_argsHelper.getInstance());
			}
			
			
			private List<vipapis.size.SizeCategoryDo> recv_findCategoryByTemplateId(){
				
				findCategoryByTemplateId_result result = new findCategoryByTemplateId_result();
				ReceiveBase(result, findCategoryByTemplateId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.size.FindSizeMappingResponse findSizeMapping(vipapis.size.FindSizeMappingRequest req_) {
				
				send_findSizeMapping(req_);
				return recv_findSizeMapping(); 
				
			}
			
			
			private void send_findSizeMapping(vipapis.size.FindSizeMappingRequest req_){
				
				InitInvocation("findSizeMapping");
				
				findSizeMapping_args args = new findSizeMapping_args();
				args.SetReq(req_);
				
				SendBase(args, findSizeMapping_argsHelper.getInstance());
			}
			
			
			private vipapis.size.FindSizeMappingResponse recv_findSizeMapping(){
				
				findSizeMapping_result result = new findSizeMapping_result();
				ReceiveBase(result, findSizeMapping_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.size.SizeTemplateDo> findSizeTemplateDetail(vipapis.size.SizeTemplateDo size_template_do_) {
				
				send_findSizeTemplateDetail(size_template_do_);
				return recv_findSizeTemplateDetail(); 
				
			}
			
			
			private void send_findSizeTemplateDetail(vipapis.size.SizeTemplateDo size_template_do_){
				
				InitInvocation("findSizeTemplateDetail");
				
				findSizeTemplateDetail_args args = new findSizeTemplateDetail_args();
				args.SetSize_template_do(size_template_do_);
				
				SendBase(args, findSizeTemplateDetail_argsHelper.getInstance());
			}
			
			
			private List<vipapis.size.SizeTemplateDo> recv_findSizeTemplateDetail(){
				
				findSizeTemplateDetail_result result = new findSizeTemplateDetail_result();
				ReceiveBase(result, findSizeTemplateDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.hermes.core.health.CheckResult healthCheck() {
				
				send_healthCheck();
				return recv_healthCheck(); 
				
			}
			
			
			private void send_healthCheck(){
				
				InitInvocation("healthCheck");
				
				healthCheck_args args = new healthCheck_args();
				
				SendBase(args, healthCheck_argsHelper.getInstance());
			}
			
			
			private com.vip.hermes.core.health.CheckResult recv_healthCheck(){
				
				healthCheck_result result = new healthCheck_result();
				ReceiveBase(result, healthCheck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.size.ListVendorSizeTableResponse listVendorSizeTable(vipapis.size.ListVendorSizeTableRequest request_) {
				
				send_listVendorSizeTable(request_);
				return recv_listVendorSizeTable(); 
				
			}
			
			
			private void send_listVendorSizeTable(vipapis.size.ListVendorSizeTableRequest request_){
				
				InitInvocation("listVendorSizeTable");
				
				listVendorSizeTable_args args = new listVendorSizeTable_args();
				args.SetRequest(request_);
				
				SendBase(args, listVendorSizeTable_argsHelper.getInstance());
			}
			
			
			private vipapis.size.ListVendorSizeTableResponse recv_listVendorSizeTable(){
				
				listVendorSizeTable_result result = new listVendorSizeTable_result();
				ReceiveBase(result, listVendorSizeTable_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.size.VendorSizeMappingDo> selectByCondition(vipapis.size.VendorSizeMappingDo condition_) {
				
				send_selectByCondition(condition_);
				return recv_selectByCondition(); 
				
			}
			
			
			private void send_selectByCondition(vipapis.size.VendorSizeMappingDo condition_){
				
				InitInvocation("selectByCondition");
				
				selectByCondition_args args = new selectByCondition_args();
				args.SetCondition(condition_);
				
				SendBase(args, selectByCondition_argsHelper.getInstance());
			}
			
			
			private List<vipapis.size.VendorSizeMappingDo> recv_selectByCondition(){
				
				selectByCondition_result result = new selectByCondition_result();
				ReceiveBase(result, selectByCondition_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? unBindingCategory(string category_id_) {
				
				send_unBindingCategory(category_id_);
				return recv_unBindingCategory(); 
				
			}
			
			
			private void send_unBindingCategory(string category_id_){
				
				InitInvocation("unBindingCategory");
				
				unBindingCategory_args args = new unBindingCategory_args();
				args.SetCategory_id(category_id_);
				
				SendBase(args, unBindingCategory_argsHelper.getInstance());
			}
			
			
			private int? recv_unBindingCategory(){
				
				unBindingCategory_result result = new unBindingCategory_result();
				ReceiveBase(result, unBindingCategory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string updateSizeTable(vipapis.size.UpdateSizeTableRequest req_) {
				
				send_updateSizeTable(req_);
				return recv_updateSizeTable(); 
				
			}
			
			
			private void send_updateSizeTable(vipapis.size.UpdateSizeTableRequest req_){
				
				InitInvocation("updateSizeTable");
				
				updateSizeTable_args args = new updateSizeTable_args();
				args.SetReq(req_);
				
				SendBase(args, updateSizeTable_argsHelper.getInstance());
			}
			
			
			private string recv_updateSizeTable(){
				
				updateSizeTable_result result = new updateSizeTable_result();
				ReceiveBase(result, updateSizeTable_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? updateSizeTemplate(vipapis.size.SizeTemplateDo size_template_do_) {
				
				send_updateSizeTemplate(size_template_do_);
				return recv_updateSizeTemplate(); 
				
			}
			
			
			private void send_updateSizeTemplate(vipapis.size.SizeTemplateDo size_template_do_){
				
				InitInvocation("updateSizeTemplate");
				
				updateSizeTemplate_args args = new updateSizeTemplate_args();
				args.SetSize_template_do(size_template_do_);
				
				SendBase(args, updateSizeTemplate_argsHelper.getInstance());
			}
			
			
			private int? recv_updateSizeTemplate(){
				
				updateSizeTemplate_result result = new updateSizeTemplate_result();
				ReceiveBase(result, updateSizeTemplate_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? updateSizeTemplateDetail(long size_template_id_,List<long?> size_detail_id_) {
				
				send_updateSizeTemplateDetail(size_template_id_,size_detail_id_);
				return recv_updateSizeTemplateDetail(); 
				
			}
			
			
			private void send_updateSizeTemplateDetail(long size_template_id_,List<long?> size_detail_id_){
				
				InitInvocation("updateSizeTemplateDetail");
				
				updateSizeTemplateDetail_args args = new updateSizeTemplateDetail_args();
				args.SetSize_template_id(size_template_id_);
				args.SetSize_detail_id(size_detail_id_);
				
				SendBase(args, updateSizeTemplateDetail_argsHelper.getInstance());
			}
			
			
			private int? recv_updateSizeTemplateDetail(){
				
				updateSizeTemplateDetail_result result = new updateSizeTemplateDetail_result();
				ReceiveBase(result, updateSizeTemplateDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}