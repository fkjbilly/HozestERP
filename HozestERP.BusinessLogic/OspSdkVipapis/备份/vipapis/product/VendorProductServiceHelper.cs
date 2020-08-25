using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.product{
	
	
	public class VendorProductServiceHelper {
		
		
		
		public class createProduct_args {
			
			///<summary>
			/// 商品信息
			///</summary>
			
			private List<vipapis.product.CreateProductItem> vendor_products_;
			
			public List<vipapis.product.CreateProductItem> GetVendor_products(){
				return this.vendor_products_;
			}
			
			public void SetVendor_products(List<vipapis.product.CreateProductItem> value){
				this.vendor_products_ = value;
			}
			
		}
		
		
		
		
		public class deleteVendorProductSizeTableRelationship_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 456413215
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// 货号
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(int? value){
				this.brand_id_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
			
		}
		
		
		
		
		public class editProduct_args {
			
			///<summary>
			/// 商品信息
			///</summary>
			
			private List<vipapis.product.EditProductItem> vendor_products_;
			
			public List<vipapis.product.EditProductItem> GetVendor_products(){
				return this.vendor_products_;
			}
			
			public void SetVendor_products(List<vipapis.product.EditProductItem> value){
				this.vendor_products_ = value;
			}
			
		}
		
		
		
		
		public class getVendorImageRelationshipTaskStatus_args {
			
			///<summary>
			/// 供应商图片上传任务ID
			/// @sampleValue task_id_list 1111
			///</summary>
			
			private List<long?> task_id_list_;
			
			public List<long?> GetTask_id_list(){
				return this.task_id_list_;
			}
			
			public void SetTask_id_list(List<long?> value){
				this.task_id_list_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class multiGetProductSkuInfo_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 条形码
			/// @sampleValue barcode 113113302011245
			///</summary>
			
			private string barcode_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 456413215
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// 分类ID(只可录入三级分类ID)
			/// @sampleValue category_id 111
			///</summary>
			
			private int? category_id_;
			
			///<summary>
			/// 货号
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 页码
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetBarcode(){
				return this.barcode_;
			}
			
			public void SetBarcode(string value){
				this.barcode_ = value;
			}
			public int? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(int? value){
				this.brand_id_ = value;
			}
			public int? GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(int? value){
				this.category_id_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class multiGetProductSpuInfo_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 456413215
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// 分类ID(只可录入三级分类ID)
			/// @sampleValue category_id 111
			///</summary>
			
			private int? category_id_;
			
			///<summary>
			/// 货号
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 商品状态
			/// @sampleValue status 待提交
			///</summary>
			
			private vipapis.product.ProductStatus? status_;
			
			///<summary>
			/// 页码
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(int? value){
				this.brand_id_ = value;
			}
			public int? GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(int? value){
				this.category_id_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
			public vipapis.product.ProductStatus? GetStatus(){
				return this.status_;
			}
			
			public void SetStatus(vipapis.product.ProductStatus? value){
				this.status_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class saveVendorProductSizeTableRelationship_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 456413215
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// 货号
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 尺码id
			/// @sampleValue size_table_id 
			///</summary>
			
			private long? size_table_id_;
			
			///<summary>
			/// 供应商SKUID映射尺码详细ID信息,key:条码；value:尺码详情id
			/// @sampleValue sku_size_detail_id_mappings 
			///</summary>
			
			private Dictionary<string, long?> sku_size_detail_id_mappings_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(int? value){
				this.brand_id_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
			public long? GetSize_table_id(){
				return this.size_table_id_;
			}
			
			public void SetSize_table_id(long? value){
				this.size_table_id_ = value;
			}
			public Dictionary<string, long?> GetSku_size_detail_id_mappings(){
				return this.sku_size_detail_id_mappings_;
			}
			
			public void SetSku_size_detail_id_mappings(Dictionary<string, long?> value){
				this.sku_size_detail_id_mappings_ = value;
			}
			
		}
		
		
		
		
		public class submitProducts_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 供应商商品货号
			///</summary>
			
			private List<vipapis.product.VendorProductSN> vendor_productSN_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.product.VendorProductSN> GetVendor_productSN_list(){
				return this.vendor_productSN_list_;
			}
			
			public void SetVendor_productSN_list(List<vipapis.product.VendorProductSN> value){
				this.vendor_productSN_list_ = value;
			}
			
		}
		
		
		
		
		public class uploadVendorProductImage_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 20000311
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// 货号
			/// @sampleValue sn 13MP202AHSL
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 图片内容
			/// @sampleValue product_image_map key是图片类型索引号, value是图片文件内容的Base64编码值
			///</summary>
			
			private Dictionary<int?, string> product_image_map_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(int? value){
				this.brand_id_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
			public Dictionary<int?, string> GetProduct_image_map(){
				return this.product_image_map_;
			}
			
			public void SetProduct_image_map(Dictionary<int?, string> value){
				this.product_image_map_ = value;
			}
			
		}
		
		
		
		
		public class createProduct_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.VendorProductResponse success_;
			
			public vipapis.product.VendorProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.VendorProductResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deleteVendorProductSizeTableRelationship_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.DeleteVSpuSizeTableRelationResponse success_;
			
			public vipapis.product.DeleteVSpuSizeTableRelationResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.DeleteVSpuSizeTableRelationResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class editProduct_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.VendorProductResponse success_;
			
			public vipapis.product.VendorProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.VendorProductResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getVendorImageRelationshipTaskStatus_result {
			
			///<summary>
			///</summary>
			
			private Dictionary<long?, vipapis.product.UploadTaskExecutionResult> success_;
			
			public Dictionary<long?, vipapis.product.UploadTaskExecutionResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(Dictionary<long?, vipapis.product.UploadTaskExecutionResult> value){
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
		
		
		
		
		public class multiGetProductSkuInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.MultiGetProductSkuResponse success_;
			
			public vipapis.product.MultiGetProductSkuResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.MultiGetProductSkuResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class multiGetProductSpuInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.MultiGetProductSpuResponse success_;
			
			public vipapis.product.MultiGetProductSpuResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.MultiGetProductSpuResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class saveVendorProductSizeTableRelationship_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.SaveVSpuSizeTableRelationResponse success_;
			
			public vipapis.product.SaveVSpuSizeTableRelationResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.SaveVSpuSizeTableRelationResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class submitProducts_result {
			
			///<summary>
			/// 提交审核返回结果集
			///</summary>
			
			private List<vipapis.product.VendorProductSubmitResult> success_;
			
			public List<vipapis.product.VendorProductSubmitResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.product.VendorProductSubmitResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadVendorProductImage_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.ImageUploadResult success_;
			
			public vipapis.product.ImageUploadResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.ImageUploadResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class createProduct_argsHelper : BeanSerializer<createProduct_args>
		{
			
			public static createProduct_argsHelper OBJ = new createProduct_argsHelper();
			
			public static createProduct_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createProduct_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.product.CreateProductItem> value;
					
					value = new List<vipapis.product.CreateProductItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.CreateProductItem elem0;
							
							elem0 = new vipapis.product.CreateProductItem();
							vipapis.product.CreateProductItemHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetVendor_products(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createProduct_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_products() != null) {
					
					oprot.WriteFieldBegin("vendor_products");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.CreateProductItem _item0 in structs.GetVendor_products()){
						
						
						vipapis.product.CreateProductItemHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_products can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createProduct_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteVendorProductSizeTableRelationship_argsHelper : BeanSerializer<deleteVendorProductSizeTableRelationship_args>
		{
			
			public static deleteVendorProductSizeTableRelationship_argsHelper OBJ = new deleteVendorProductSizeTableRelationship_argsHelper();
			
			public static deleteVendorProductSizeTableRelationship_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteVendorProductSizeTableRelationship_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteVendorProductSizeTableRelationship_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI32((int)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("brand_id can not be null!");
				}
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sn can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteVendorProductSizeTableRelationship_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editProduct_argsHelper : BeanSerializer<editProduct_args>
		{
			
			public static editProduct_argsHelper OBJ = new editProduct_argsHelper();
			
			public static editProduct_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editProduct_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.product.EditProductItem> value;
					
					value = new List<vipapis.product.EditProductItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.EditProductItem elem0;
							
							elem0 = new vipapis.product.EditProductItem();
							vipapis.product.EditProductItemHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetVendor_products(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editProduct_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_products() != null) {
					
					oprot.WriteFieldBegin("vendor_products");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.EditProductItem _item0 in structs.GetVendor_products()){
						
						
						vipapis.product.EditProductItemHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_products can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editProduct_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVendorImageRelationshipTaskStatus_argsHelper : BeanSerializer<getVendorImageRelationshipTaskStatus_args>
		{
			
			public static getVendorImageRelationshipTaskStatus_argsHelper OBJ = new getVendorImageRelationshipTaskStatus_argsHelper();
			
			public static getVendorImageRelationshipTaskStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVendorImageRelationshipTaskStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem1;
							elem1 = iprot.ReadI64(); 
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetTask_id_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getVendorImageRelationshipTaskStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetTask_id_list() != null) {
					
					oprot.WriteFieldBegin("task_id_list");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetTask_id_list()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("task_id_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVendorImageRelationshipTaskStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : BeanSerializer<healthCheck_args>
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
		
		
		
		
		public class multiGetProductSkuInfo_argsHelper : BeanSerializer<multiGetProductSkuInfo_args>
		{
			
			public static multiGetProductSkuInfo_argsHelper OBJ = new multiGetProductSkuInfo_argsHelper();
			
			public static multiGetProductSkuInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(multiGetProductSkuInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBarcode(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(multiGetProductSkuInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetBarcode() != null) {
					
					oprot.WriteFieldBegin("barcode");
					oprot.WriteString(structs.GetBarcode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI32((int)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteI32((int)structs.GetCategory_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiGetProductSkuInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class multiGetProductSpuInfo_argsHelper : BeanSerializer<multiGetProductSpuInfo_args>
		{
			
			public static multiGetProductSpuInfo_argsHelper OBJ = new multiGetProductSpuInfo_argsHelper();
			
			public static multiGetProductSpuInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(multiGetProductSpuInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.product.ProductStatus? value;
					
					value = vipapis.product.ProductStatusUtil.FindByName(iprot.ReadString());
					
					structs.SetStatus(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(multiGetProductSpuInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI32((int)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteI32((int)structs.GetCategory_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStatus() != null) {
					
					oprot.WriteFieldBegin("status");
					oprot.WriteString(structs.GetStatus().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiGetProductSpuInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class saveVendorProductSizeTableRelationship_argsHelper : BeanSerializer<saveVendorProductSizeTableRelationship_args>
		{
			
			public static saveVendorProductSizeTableRelationship_argsHelper OBJ = new saveVendorProductSizeTableRelationship_argsHelper();
			
			public static saveVendorProductSizeTableRelationship_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(saveVendorProductSizeTableRelationship_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSize_table_id(value);
				}
				
				
				
				
				
				if(true){
					
					Dictionary<string, long?> value;
					
					value = new Dictionary<string, long?>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							string _key0;
							long _val0;
							_key0 = iprot.ReadString();
							
							_val0 = iprot.ReadI64(); 
							
							value.Add(_key0, _val0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetSku_size_detail_id_mappings(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(saveVendorProductSizeTableRelationship_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI32((int)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("brand_id can not be null!");
				}
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sn can not be null!");
				}
				
				
				if(structs.GetSize_table_id() != null) {
					
					oprot.WriteFieldBegin("size_table_id");
					oprot.WriteI64((long)structs.GetSize_table_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size_table_id can not be null!");
				}
				
				
				if(structs.GetSku_size_detail_id_mappings() != null) {
					
					oprot.WriteFieldBegin("sku_size_detail_id_mappings");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, long? > _ir0 in structs.GetSku_size_detail_id_mappings()){
						
						string _key0 = _ir0.Key;
						long? _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						oprot.WriteI64((long)_value0); 
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(saveVendorProductSizeTableRelationship_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class submitProducts_argsHelper : BeanSerializer<submitProducts_args>
		{
			
			public static submitProducts_argsHelper OBJ = new submitProducts_argsHelper();
			
			public static submitProducts_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitProducts_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.product.VendorProductSN> value;
					
					value = new List<vipapis.product.VendorProductSN>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.VendorProductSN elem1;
							
							elem1 = new vipapis.product.VendorProductSN();
							vipapis.product.VendorProductSNHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetVendor_productSN_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(submitProducts_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetVendor_productSN_list() != null) {
					
					oprot.WriteFieldBegin("vendor_productSN_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.VendorProductSN _item0 in structs.GetVendor_productSN_list()){
						
						
						vipapis.product.VendorProductSNHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_productSN_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitProducts_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadVendorProductImage_argsHelper : BeanSerializer<uploadVendorProductImage_args>
		{
			
			public static uploadVendorProductImage_argsHelper OBJ = new uploadVendorProductImage_argsHelper();
			
			public static uploadVendorProductImage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadVendorProductImage_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				
				if(true){
					
					Dictionary<int?, string> value;
					
					value = new Dictionary<int?, string>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							int _key1;
							string _val1;
							_key1 = iprot.ReadI32(); 
							
							_val1 = iprot.ReadString();
							
							value.Add(_key1, _val1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetProduct_image_map(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadVendorProductImage_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI32((int)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("brand_id can not be null!");
				}
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sn can not be null!");
				}
				
				
				if(structs.GetProduct_image_map() != null) {
					
					oprot.WriteFieldBegin("product_image_map");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< int?, string > _ir0 in structs.GetProduct_image_map()){
						
						int? _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteI32((int)_key0); 
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("product_image_map can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadVendorProductImage_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createProduct_resultHelper : BeanSerializer<createProduct_result>
		{
			
			public static createProduct_resultHelper OBJ = new createProduct_resultHelper();
			
			public static createProduct_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createProduct_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.VendorProductResponse value;
					
					value = new vipapis.product.VendorProductResponse();
					vipapis.product.VendorProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createProduct_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.VendorProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createProduct_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteVendorProductSizeTableRelationship_resultHelper : BeanSerializer<deleteVendorProductSizeTableRelationship_result>
		{
			
			public static deleteVendorProductSizeTableRelationship_resultHelper OBJ = new deleteVendorProductSizeTableRelationship_resultHelper();
			
			public static deleteVendorProductSizeTableRelationship_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteVendorProductSizeTableRelationship_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.DeleteVSpuSizeTableRelationResponse value;
					
					value = new vipapis.product.DeleteVSpuSizeTableRelationResponse();
					vipapis.product.DeleteVSpuSizeTableRelationResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteVendorProductSizeTableRelationship_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.DeleteVSpuSizeTableRelationResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteVendorProductSizeTableRelationship_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editProduct_resultHelper : BeanSerializer<editProduct_result>
		{
			
			public static editProduct_resultHelper OBJ = new editProduct_resultHelper();
			
			public static editProduct_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editProduct_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.VendorProductResponse value;
					
					value = new vipapis.product.VendorProductResponse();
					vipapis.product.VendorProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editProduct_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.VendorProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editProduct_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVendorImageRelationshipTaskStatus_resultHelper : BeanSerializer<getVendorImageRelationshipTaskStatus_result>
		{
			
			public static getVendorImageRelationshipTaskStatus_resultHelper OBJ = new getVendorImageRelationshipTaskStatus_resultHelper();
			
			public static getVendorImageRelationshipTaskStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVendorImageRelationshipTaskStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					Dictionary<long?, vipapis.product.UploadTaskExecutionResult> value;
					
					value = new Dictionary<long?, vipapis.product.UploadTaskExecutionResult>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							long _key0;
							vipapis.product.UploadTaskExecutionResult _val0;
							_key0 = iprot.ReadI64(); 
							
							
							_val0 = new vipapis.product.UploadTaskExecutionResult();
							vipapis.product.UploadTaskExecutionResultHelper.getInstance().Read(_val0, iprot);
							
							value.Add(_key0, _val0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getVendorImageRelationshipTaskStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< long?, vipapis.product.UploadTaskExecutionResult > _ir0 in structs.GetSuccess()){
						
						long? _key0 = _ir0.Key;
						vipapis.product.UploadTaskExecutionResult _value0 = _ir0.Value;
						oprot.WriteI64((long)_key0); 
						
						
						vipapis.product.UploadTaskExecutionResultHelper.getInstance().Write(_value0, oprot);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVendorImageRelationshipTaskStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : BeanSerializer<healthCheck_result>
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
		
		
		
		
		public class multiGetProductSkuInfo_resultHelper : BeanSerializer<multiGetProductSkuInfo_result>
		{
			
			public static multiGetProductSkuInfo_resultHelper OBJ = new multiGetProductSkuInfo_resultHelper();
			
			public static multiGetProductSkuInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(multiGetProductSkuInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.MultiGetProductSkuResponse value;
					
					value = new vipapis.product.MultiGetProductSkuResponse();
					vipapis.product.MultiGetProductSkuResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(multiGetProductSkuInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.MultiGetProductSkuResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiGetProductSkuInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class multiGetProductSpuInfo_resultHelper : BeanSerializer<multiGetProductSpuInfo_result>
		{
			
			public static multiGetProductSpuInfo_resultHelper OBJ = new multiGetProductSpuInfo_resultHelper();
			
			public static multiGetProductSpuInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(multiGetProductSpuInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.MultiGetProductSpuResponse value;
					
					value = new vipapis.product.MultiGetProductSpuResponse();
					vipapis.product.MultiGetProductSpuResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(multiGetProductSpuInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.MultiGetProductSpuResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiGetProductSpuInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class saveVendorProductSizeTableRelationship_resultHelper : BeanSerializer<saveVendorProductSizeTableRelationship_result>
		{
			
			public static saveVendorProductSizeTableRelationship_resultHelper OBJ = new saveVendorProductSizeTableRelationship_resultHelper();
			
			public static saveVendorProductSizeTableRelationship_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(saveVendorProductSizeTableRelationship_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.SaveVSpuSizeTableRelationResponse value;
					
					value = new vipapis.product.SaveVSpuSizeTableRelationResponse();
					vipapis.product.SaveVSpuSizeTableRelationResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(saveVendorProductSizeTableRelationship_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.SaveVSpuSizeTableRelationResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(saveVendorProductSizeTableRelationship_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class submitProducts_resultHelper : BeanSerializer<submitProducts_result>
		{
			
			public static submitProducts_resultHelper OBJ = new submitProducts_resultHelper();
			
			public static submitProducts_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitProducts_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.product.VendorProductSubmitResult> value;
					
					value = new List<vipapis.product.VendorProductSubmitResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.VendorProductSubmitResult elem0;
							
							elem0 = new vipapis.product.VendorProductSubmitResult();
							vipapis.product.VendorProductSubmitResultHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(submitProducts_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.VendorProductSubmitResult _item0 in structs.GetSuccess()){
						
						
						vipapis.product.VendorProductSubmitResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitProducts_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadVendorProductImage_resultHelper : BeanSerializer<uploadVendorProductImage_result>
		{
			
			public static uploadVendorProductImage_resultHelper OBJ = new uploadVendorProductImage_resultHelper();
			
			public static uploadVendorProductImage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadVendorProductImage_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.ImageUploadResult value;
					
					value = new vipapis.product.ImageUploadResult();
					vipapis.product.ImageUploadResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadVendorProductImage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.ImageUploadResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadVendorProductImage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorProductServiceClient : OspRestStub , VendorProductService  {
			
			
			public VendorProductServiceClient():base("vipapis.product.VendorProductService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.product.VendorProductResponse createProduct(List<vipapis.product.CreateProductItem> vendor_products_) {
				
				send_createProduct(vendor_products_);
				return recv_createProduct(); 
				
			}
			
			
			private void send_createProduct(List<vipapis.product.CreateProductItem> vendor_products_){
				
				InitInvocation("createProduct");
				
				createProduct_args args = new createProduct_args();
				args.SetVendor_products(vendor_products_);
				
				SendBase(args, createProduct_argsHelper.getInstance());
			}
			
			
			private vipapis.product.VendorProductResponse recv_createProduct(){
				
				createProduct_result result = new createProduct_result();
				ReceiveBase(result, createProduct_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.DeleteVSpuSizeTableRelationResponse deleteVendorProductSizeTableRelationship(int vendor_id_,int brand_id_,string sn_) {
				
				send_deleteVendorProductSizeTableRelationship(vendor_id_,brand_id_,sn_);
				return recv_deleteVendorProductSizeTableRelationship(); 
				
			}
			
			
			private void send_deleteVendorProductSizeTableRelationship(int vendor_id_,int brand_id_,string sn_){
				
				InitInvocation("deleteVendorProductSizeTableRelationship");
				
				deleteVendorProductSizeTableRelationship_args args = new deleteVendorProductSizeTableRelationship_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				
				SendBase(args, deleteVendorProductSizeTableRelationship_argsHelper.getInstance());
			}
			
			
			private vipapis.product.DeleteVSpuSizeTableRelationResponse recv_deleteVendorProductSizeTableRelationship(){
				
				deleteVendorProductSizeTableRelationship_result result = new deleteVendorProductSizeTableRelationship_result();
				ReceiveBase(result, deleteVendorProductSizeTableRelationship_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.VendorProductResponse editProduct(List<vipapis.product.EditProductItem> vendor_products_) {
				
				send_editProduct(vendor_products_);
				return recv_editProduct(); 
				
			}
			
			
			private void send_editProduct(List<vipapis.product.EditProductItem> vendor_products_){
				
				InitInvocation("editProduct");
				
				editProduct_args args = new editProduct_args();
				args.SetVendor_products(vendor_products_);
				
				SendBase(args, editProduct_argsHelper.getInstance());
			}
			
			
			private vipapis.product.VendorProductResponse recv_editProduct(){
				
				editProduct_result result = new editProduct_result();
				ReceiveBase(result, editProduct_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public Dictionary<long?, vipapis.product.UploadTaskExecutionResult> getVendorImageRelationshipTaskStatus(List<long?> task_id_list_) {
				
				send_getVendorImageRelationshipTaskStatus(task_id_list_);
				return recv_getVendorImageRelationshipTaskStatus(); 
				
			}
			
			
			private void send_getVendorImageRelationshipTaskStatus(List<long?> task_id_list_){
				
				InitInvocation("getVendorImageRelationshipTaskStatus");
				
				getVendorImageRelationshipTaskStatus_args args = new getVendorImageRelationshipTaskStatus_args();
				args.SetTask_id_list(task_id_list_);
				
				SendBase(args, getVendorImageRelationshipTaskStatus_argsHelper.getInstance());
			}
			
			
			private Dictionary<long?, vipapis.product.UploadTaskExecutionResult> recv_getVendorImageRelationshipTaskStatus(){
				
				getVendorImageRelationshipTaskStatus_result result = new getVendorImageRelationshipTaskStatus_result();
				ReceiveBase(result, getVendorImageRelationshipTaskStatus_resultHelper.getInstance());
				
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
			
			
			public vipapis.product.MultiGetProductSkuResponse multiGetProductSkuInfo(int vendor_id_,string barcode_,int? brand_id_,int? category_id_,string sn_,int? page_,int? limit_) {
				
				send_multiGetProductSkuInfo(vendor_id_,barcode_,brand_id_,category_id_,sn_,page_,limit_);
				return recv_multiGetProductSkuInfo(); 
				
			}
			
			
			private void send_multiGetProductSkuInfo(int vendor_id_,string barcode_,int? brand_id_,int? category_id_,string sn_,int? page_,int? limit_){
				
				InitInvocation("multiGetProductSkuInfo");
				
				multiGetProductSkuInfo_args args = new multiGetProductSkuInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetBarcode(barcode_);
				args.SetBrand_id(brand_id_);
				args.SetCategory_id(category_id_);
				args.SetSn(sn_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, multiGetProductSkuInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.product.MultiGetProductSkuResponse recv_multiGetProductSkuInfo(){
				
				multiGetProductSkuInfo_result result = new multiGetProductSkuInfo_result();
				ReceiveBase(result, multiGetProductSkuInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.MultiGetProductSpuResponse multiGetProductSpuInfo(int vendor_id_,int? brand_id_,int? category_id_,string sn_,vipapis.product.ProductStatus? status_,int? page_,int? limit_) {
				
				send_multiGetProductSpuInfo(vendor_id_,brand_id_,category_id_,sn_,status_,page_,limit_);
				return recv_multiGetProductSpuInfo(); 
				
			}
			
			
			private void send_multiGetProductSpuInfo(int vendor_id_,int? brand_id_,int? category_id_,string sn_,vipapis.product.ProductStatus? status_,int? page_,int? limit_){
				
				InitInvocation("multiGetProductSpuInfo");
				
				multiGetProductSpuInfo_args args = new multiGetProductSpuInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetCategory_id(category_id_);
				args.SetSn(sn_);
				args.SetStatus(status_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, multiGetProductSpuInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.product.MultiGetProductSpuResponse recv_multiGetProductSpuInfo(){
				
				multiGetProductSpuInfo_result result = new multiGetProductSpuInfo_result();
				ReceiveBase(result, multiGetProductSpuInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.SaveVSpuSizeTableRelationResponse saveVendorProductSizeTableRelationship(int vendor_id_,int brand_id_,string sn_,long size_table_id_,Dictionary<string, long?> sku_size_detail_id_mappings_) {
				
				send_saveVendorProductSizeTableRelationship(vendor_id_,brand_id_,sn_,size_table_id_,sku_size_detail_id_mappings_);
				return recv_saveVendorProductSizeTableRelationship(); 
				
			}
			
			
			private void send_saveVendorProductSizeTableRelationship(int vendor_id_,int brand_id_,string sn_,long size_table_id_,Dictionary<string, long?> sku_size_detail_id_mappings_){
				
				InitInvocation("saveVendorProductSizeTableRelationship");
				
				saveVendorProductSizeTableRelationship_args args = new saveVendorProductSizeTableRelationship_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetSize_table_id(size_table_id_);
				args.SetSku_size_detail_id_mappings(sku_size_detail_id_mappings_);
				
				SendBase(args, saveVendorProductSizeTableRelationship_argsHelper.getInstance());
			}
			
			
			private vipapis.product.SaveVSpuSizeTableRelationResponse recv_saveVendorProductSizeTableRelationship(){
				
				saveVendorProductSizeTableRelationship_result result = new saveVendorProductSizeTableRelationship_result();
				ReceiveBase(result, saveVendorProductSizeTableRelationship_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.product.VendorProductSubmitResult> submitProducts(int vendor_id_,List<vipapis.product.VendorProductSN> vendor_productSN_list_) {
				
				send_submitProducts(vendor_id_,vendor_productSN_list_);
				return recv_submitProducts(); 
				
			}
			
			
			private void send_submitProducts(int vendor_id_,List<vipapis.product.VendorProductSN> vendor_productSN_list_){
				
				InitInvocation("submitProducts");
				
				submitProducts_args args = new submitProducts_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_productSN_list(vendor_productSN_list_);
				
				SendBase(args, submitProducts_argsHelper.getInstance());
			}
			
			
			private List<vipapis.product.VendorProductSubmitResult> recv_submitProducts(){
				
				submitProducts_result result = new submitProducts_result();
				ReceiveBase(result, submitProducts_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.ImageUploadResult uploadVendorProductImage(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, string> product_image_map_) {
				
				send_uploadVendorProductImage(vendor_id_,brand_id_,sn_,product_image_map_);
				return recv_uploadVendorProductImage(); 
				
			}
			
			
			private void send_uploadVendorProductImage(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, string> product_image_map_){
				
				InitInvocation("uploadVendorProductImage");
				
				uploadVendorProductImage_args args = new uploadVendorProductImage_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetProduct_image_map(product_image_map_);
				
				SendBase(args, uploadVendorProductImage_argsHelper.getInstance());
			}
			
			
			private vipapis.product.ImageUploadResult recv_uploadVendorProductImage(){
				
				uploadVendorProductImage_result result = new uploadVendorProductImage_result();
				ReceiveBase(result, uploadVendorProductImage_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}