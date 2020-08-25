using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.product{
	
	
	public class ImprovedVendorProductServiceHelper {
		
		
		
		public class createBaseProducts_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 非标准商品信息
			///</summary>
			
			private List<vipapis.product.CreateBaseProductItem> vendor_products_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.product.CreateBaseProductItem> GetVendor_products(){
				return this.vendor_products_;
			}
			
			public void SetVendor_products(List<vipapis.product.CreateBaseProductItem> value){
				this.vendor_products_ = value;
			}
			
		}
		
		
		
		
		public class createProductWithProdInfoMapping_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 供应商类目树id
			///</summary>
			
			private int? vendor_category_tree_id_;
			
			///<summary>
			/// 商品信息
			///</summary>
			
			private List<vipapis.product.CreateVendorProductItem> vendor_products_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetVendor_category_tree_id(){
				return this.vendor_category_tree_id_;
			}
			
			public void SetVendor_category_tree_id(int? value){
				this.vendor_category_tree_id_ = value;
			}
			public List<vipapis.product.CreateVendorProductItem> GetVendor_products(){
				return this.vendor_products_;
			}
			
			public void SetVendor_products(List<vipapis.product.CreateVendorProductItem> value){
				this.vendor_products_ = value;
			}
			
		}
		
		
		
		
		public class editProductWithProdInfoMapping_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 供应商类目树id
			///</summary>
			
			private int? vendor_category_tree_id_;
			
			///<summary>
			/// 商品信息
			///</summary>
			
			private List<vipapis.product.EditVendorProductItem> vendor_products_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public int? GetVendor_category_tree_id(){
				return this.vendor_category_tree_id_;
			}
			
			public void SetVendor_category_tree_id(int? value){
				this.vendor_category_tree_id_ = value;
			}
			public List<vipapis.product.EditVendorProductItem> GetVendor_products(){
				return this.vendor_products_;
			}
			
			public void SetVendor_products(List<vipapis.product.EditVendorProductItem> value){
				this.vendor_products_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class uploadVendorCategory_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 供应商类目表名称
			///</summary>
			
			private string vendor_category_tree_name_;
			
			///<summary>
			/// 类目属性名称
			///</summary>
			
			private List<vipapis.product.VendorCategory> vendor_categories_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetVendor_category_tree_name(){
				return this.vendor_category_tree_name_;
			}
			
			public void SetVendor_category_tree_name(string value){
				this.vendor_category_tree_name_ = value;
			}
			public List<vipapis.product.VendorCategory> GetVendor_categories(){
				return this.vendor_categories_;
			}
			
			public void SetVendor_categories(List<vipapis.product.VendorCategory> value){
				this.vendor_categories_ = value;
			}
			
		}
		
		
		
		
		public class uploadVendorFullScaleProductImage_args {
			
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
			/// 图号与图片内容映射表（图号支持1, 2, 3, 4, 5, 6, 7, 15, 16, 110, 111, 112, 113, 114, 601至699）
			///</summary>
			
			private Dictionary<int?, vipapis.product.UploadImageInfo> product_image_map_;
			
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
			public Dictionary<int?, vipapis.product.UploadImageInfo> GetProduct_image_map(){
				return this.product_image_map_;
			}
			
			public void SetProduct_image_map(Dictionary<int?, vipapis.product.UploadImageInfo> value){
				this.product_image_map_ = value;
			}
			
		}
		
		
		
		
		public class createBaseProducts_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.CreateBaseProductResponse success_;
			
			public vipapis.product.CreateBaseProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.CreateBaseProductResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class createProductWithProdInfoMapping_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.ImprovedVendorProductResponse success_;
			
			public vipapis.product.ImprovedVendorProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.ImprovedVendorProductResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class editProductWithProdInfoMapping_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.ImprovedVendorProductResponse success_;
			
			public vipapis.product.ImprovedVendorProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.ImprovedVendorProductResponse value){
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
		
		
		
		
		public class uploadVendorCategory_result {
			
			///<summary>
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadVendorFullScaleProductImage_result {
			
			///<summary>
			///</summary>
			
			private Dictionary<int?, vipapis.product.UploadImageResult> success_;
			
			public Dictionary<int?, vipapis.product.UploadImageResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(Dictionary<int?, vipapis.product.UploadImageResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class createBaseProducts_argsHelper : TBeanSerializer<createBaseProducts_args>
		{
			
			public static createBaseProducts_argsHelper OBJ = new createBaseProducts_argsHelper();
			
			public static createBaseProducts_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createBaseProducts_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.product.CreateBaseProductItem> value;
					
					value = new List<vipapis.product.CreateBaseProductItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.CreateBaseProductItem elem1;
							
							elem1 = new vipapis.product.CreateBaseProductItem();
							vipapis.product.CreateBaseProductItemHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
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
			
			
			public void Write(createBaseProducts_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetVendor_products() != null) {
					
					oprot.WriteFieldBegin("vendor_products");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.CreateBaseProductItem _item0 in structs.GetVendor_products()){
						
						
						vipapis.product.CreateBaseProductItemHelper.getInstance().Write(_item0, oprot);
						
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
			
			
			public void Validate(createBaseProducts_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createProductWithProdInfoMapping_argsHelper : TBeanSerializer<createProductWithProdInfoMapping_args>
		{
			
			public static createProductWithProdInfoMapping_argsHelper OBJ = new createProductWithProdInfoMapping_argsHelper();
			
			public static createProductWithProdInfoMapping_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createProductWithProdInfoMapping_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_category_tree_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.product.CreateVendorProductItem> value;
					
					value = new List<vipapis.product.CreateVendorProductItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.CreateVendorProductItem elem1;
							
							elem1 = new vipapis.product.CreateVendorProductItem();
							vipapis.product.CreateVendorProductItemHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
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
			
			
			public void Write(createProductWithProdInfoMapping_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetVendor_category_tree_id() != null) {
					
					oprot.WriteFieldBegin("vendor_category_tree_id");
					oprot.WriteI32((int)structs.GetVendor_category_tree_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_category_tree_id can not be null!");
				}
				
				
				if(structs.GetVendor_products() != null) {
					
					oprot.WriteFieldBegin("vendor_products");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.CreateVendorProductItem _item0 in structs.GetVendor_products()){
						
						
						vipapis.product.CreateVendorProductItemHelper.getInstance().Write(_item0, oprot);
						
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
			
			
			public void Validate(createProductWithProdInfoMapping_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editProductWithProdInfoMapping_argsHelper : TBeanSerializer<editProductWithProdInfoMapping_args>
		{
			
			public static editProductWithProdInfoMapping_argsHelper OBJ = new editProductWithProdInfoMapping_argsHelper();
			
			public static editProductWithProdInfoMapping_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editProductWithProdInfoMapping_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_category_tree_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.product.EditVendorProductItem> value;
					
					value = new List<vipapis.product.EditVendorProductItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.EditVendorProductItem elem1;
							
							elem1 = new vipapis.product.EditVendorProductItem();
							vipapis.product.EditVendorProductItemHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
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
			
			
			public void Write(editProductWithProdInfoMapping_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetVendor_category_tree_id() != null) {
					
					oprot.WriteFieldBegin("vendor_category_tree_id");
					oprot.WriteI32((int)structs.GetVendor_category_tree_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_category_tree_id can not be null!");
				}
				
				
				if(structs.GetVendor_products() != null) {
					
					oprot.WriteFieldBegin("vendor_products");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.EditVendorProductItem _item0 in structs.GetVendor_products()){
						
						
						vipapis.product.EditVendorProductItemHelper.getInstance().Write(_item0, oprot);
						
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
			
			
			public void Validate(editProductWithProdInfoMapping_args bean){
				
				
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
		
		
		
		
		public class uploadVendorCategory_argsHelper : TBeanSerializer<uploadVendorCategory_args>
		{
			
			public static uploadVendorCategory_argsHelper OBJ = new uploadVendorCategory_argsHelper();
			
			public static uploadVendorCategory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadVendorCategory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_category_tree_name(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.product.VendorCategory> value;
					
					value = new List<vipapis.product.VendorCategory>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.VendorCategory elem1;
							
							elem1 = new vipapis.product.VendorCategory();
							vipapis.product.VendorCategoryHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetVendor_categories(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadVendorCategory_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetVendor_category_tree_name() != null) {
					
					oprot.WriteFieldBegin("vendor_category_tree_name");
					oprot.WriteString(structs.GetVendor_category_tree_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_category_tree_name can not be null!");
				}
				
				
				if(structs.GetVendor_categories() != null) {
					
					oprot.WriteFieldBegin("vendor_categories");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.VendorCategory _item0 in structs.GetVendor_categories()){
						
						
						vipapis.product.VendorCategoryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_categories can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadVendorCategory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadVendorFullScaleProductImage_argsHelper : TBeanSerializer<uploadVendorFullScaleProductImage_args>
		{
			
			public static uploadVendorFullScaleProductImage_argsHelper OBJ = new uploadVendorFullScaleProductImage_argsHelper();
			
			public static uploadVendorFullScaleProductImage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadVendorFullScaleProductImage_args structs, Protocol iprot){
				
				
				
				
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
					
					Dictionary<int?, vipapis.product.UploadImageInfo> value;
					
					value = new Dictionary<int?, vipapis.product.UploadImageInfo>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							int _key1;
							vipapis.product.UploadImageInfo _val1;
							_key1 = iprot.ReadI32(); 
							
							
							_val1 = new vipapis.product.UploadImageInfo();
							vipapis.product.UploadImageInfoHelper.getInstance().Read(_val1, iprot);
							
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
			
			
			public void Write(uploadVendorFullScaleProductImage_args structs, Protocol oprot){
				
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
					foreach(KeyValuePair< int?, vipapis.product.UploadImageInfo > _ir0 in structs.GetProduct_image_map()){
						
						int? _key0 = _ir0.Key;
						vipapis.product.UploadImageInfo _value0 = _ir0.Value;
						oprot.WriteI32((int)_key0); 
						
						
						vipapis.product.UploadImageInfoHelper.getInstance().Write(_value0, oprot);
						
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
			
			
			public void Validate(uploadVendorFullScaleProductImage_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createBaseProducts_resultHelper : TBeanSerializer<createBaseProducts_result>
		{
			
			public static createBaseProducts_resultHelper OBJ = new createBaseProducts_resultHelper();
			
			public static createBaseProducts_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createBaseProducts_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.CreateBaseProductResponse value;
					
					value = new vipapis.product.CreateBaseProductResponse();
					vipapis.product.CreateBaseProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createBaseProducts_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.CreateBaseProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createBaseProducts_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createProductWithProdInfoMapping_resultHelper : TBeanSerializer<createProductWithProdInfoMapping_result>
		{
			
			public static createProductWithProdInfoMapping_resultHelper OBJ = new createProductWithProdInfoMapping_resultHelper();
			
			public static createProductWithProdInfoMapping_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createProductWithProdInfoMapping_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.ImprovedVendorProductResponse value;
					
					value = new vipapis.product.ImprovedVendorProductResponse();
					vipapis.product.ImprovedVendorProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createProductWithProdInfoMapping_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.ImprovedVendorProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createProductWithProdInfoMapping_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editProductWithProdInfoMapping_resultHelper : TBeanSerializer<editProductWithProdInfoMapping_result>
		{
			
			public static editProductWithProdInfoMapping_resultHelper OBJ = new editProductWithProdInfoMapping_resultHelper();
			
			public static editProductWithProdInfoMapping_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editProductWithProdInfoMapping_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.ImprovedVendorProductResponse value;
					
					value = new vipapis.product.ImprovedVendorProductResponse();
					vipapis.product.ImprovedVendorProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editProductWithProdInfoMapping_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.ImprovedVendorProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editProductWithProdInfoMapping_result bean){
				
				
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
		
		
		
		
		public class uploadVendorCategory_resultHelper : TBeanSerializer<uploadVendorCategory_result>
		{
			
			public static uploadVendorCategory_resultHelper OBJ = new uploadVendorCategory_resultHelper();
			
			public static uploadVendorCategory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadVendorCategory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadVendorCategory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadVendorCategory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadVendorFullScaleProductImage_resultHelper : TBeanSerializer<uploadVendorFullScaleProductImage_result>
		{
			
			public static uploadVendorFullScaleProductImage_resultHelper OBJ = new uploadVendorFullScaleProductImage_resultHelper();
			
			public static uploadVendorFullScaleProductImage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadVendorFullScaleProductImage_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					Dictionary<int?, vipapis.product.UploadImageResult> value;
					
					value = new Dictionary<int?, vipapis.product.UploadImageResult>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							int _key0;
							vipapis.product.UploadImageResult _val0;
							_key0 = iprot.ReadI32(); 
							
							
							_val0 = new vipapis.product.UploadImageResult();
							vipapis.product.UploadImageResultHelper.getInstance().Read(_val0, iprot);
							
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
			
			
			public void Write(uploadVendorFullScaleProductImage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< int?, vipapis.product.UploadImageResult > _ir0 in structs.GetSuccess()){
						
						int? _key0 = _ir0.Key;
						vipapis.product.UploadImageResult _value0 = _ir0.Value;
						oprot.WriteI32((int)_key0); 
						
						
						vipapis.product.UploadImageResultHelper.getInstance().Write(_value0, oprot);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadVendorFullScaleProductImage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class ImprovedVendorProductServiceClient : OspRestStub , ImprovedVendorProductService  {
			
			
			public ImprovedVendorProductServiceClient():base("vipapis.product.ImprovedVendorProductService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.product.CreateBaseProductResponse createBaseProducts(int vendor_id_,List<vipapis.product.CreateBaseProductItem> vendor_products_) {
				
				send_createBaseProducts(vendor_id_,vendor_products_);
				return recv_createBaseProducts(); 
				
			}
			
			
			private void send_createBaseProducts(int vendor_id_,List<vipapis.product.CreateBaseProductItem> vendor_products_){
				
				InitInvocation("createBaseProducts");
				
				createBaseProducts_args args = new createBaseProducts_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_products(vendor_products_);
				
				SendBase(args, createBaseProducts_argsHelper.getInstance());
			}
			
			
			private vipapis.product.CreateBaseProductResponse recv_createBaseProducts(){
				
				createBaseProducts_result result = new createBaseProducts_result();
				ReceiveBase(result, createBaseProducts_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.ImprovedVendorProductResponse createProductWithProdInfoMapping(int vendor_id_,int vendor_category_tree_id_,List<vipapis.product.CreateVendorProductItem> vendor_products_) {
				
				send_createProductWithProdInfoMapping(vendor_id_,vendor_category_tree_id_,vendor_products_);
				return recv_createProductWithProdInfoMapping(); 
				
			}
			
			
			private void send_createProductWithProdInfoMapping(int vendor_id_,int vendor_category_tree_id_,List<vipapis.product.CreateVendorProductItem> vendor_products_){
				
				InitInvocation("createProductWithProdInfoMapping");
				
				createProductWithProdInfoMapping_args args = new createProductWithProdInfoMapping_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_category_tree_id(vendor_category_tree_id_);
				args.SetVendor_products(vendor_products_);
				
				SendBase(args, createProductWithProdInfoMapping_argsHelper.getInstance());
			}
			
			
			private vipapis.product.ImprovedVendorProductResponse recv_createProductWithProdInfoMapping(){
				
				createProductWithProdInfoMapping_result result = new createProductWithProdInfoMapping_result();
				ReceiveBase(result, createProductWithProdInfoMapping_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.ImprovedVendorProductResponse editProductWithProdInfoMapping(int vendor_id_,int vendor_category_tree_id_,List<vipapis.product.EditVendorProductItem> vendor_products_) {
				
				send_editProductWithProdInfoMapping(vendor_id_,vendor_category_tree_id_,vendor_products_);
				return recv_editProductWithProdInfoMapping(); 
				
			}
			
			
			private void send_editProductWithProdInfoMapping(int vendor_id_,int vendor_category_tree_id_,List<vipapis.product.EditVendorProductItem> vendor_products_){
				
				InitInvocation("editProductWithProdInfoMapping");
				
				editProductWithProdInfoMapping_args args = new editProductWithProdInfoMapping_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_category_tree_id(vendor_category_tree_id_);
				args.SetVendor_products(vendor_products_);
				
				SendBase(args, editProductWithProdInfoMapping_argsHelper.getInstance());
			}
			
			
			private vipapis.product.ImprovedVendorProductResponse recv_editProductWithProdInfoMapping(){
				
				editProductWithProdInfoMapping_result result = new editProductWithProdInfoMapping_result();
				ReceiveBase(result, editProductWithProdInfoMapping_resultHelper.getInstance());
				
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
			
			
			public int? uploadVendorCategory(int vendor_id_,string vendor_category_tree_name_,List<vipapis.product.VendorCategory> vendor_categories_) {
				
				send_uploadVendorCategory(vendor_id_,vendor_category_tree_name_,vendor_categories_);
				return recv_uploadVendorCategory(); 
				
			}
			
			
			private void send_uploadVendorCategory(int vendor_id_,string vendor_category_tree_name_,List<vipapis.product.VendorCategory> vendor_categories_){
				
				InitInvocation("uploadVendorCategory");
				
				uploadVendorCategory_args args = new uploadVendorCategory_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_category_tree_name(vendor_category_tree_name_);
				args.SetVendor_categories(vendor_categories_);
				
				SendBase(args, uploadVendorCategory_argsHelper.getInstance());
			}
			
			
			private int? recv_uploadVendorCategory(){
				
				uploadVendorCategory_result result = new uploadVendorCategory_result();
				ReceiveBase(result, uploadVendorCategory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public Dictionary<int?, vipapis.product.UploadImageResult> uploadVendorFullScaleProductImage(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, vipapis.product.UploadImageInfo> product_image_map_) {
				
				send_uploadVendorFullScaleProductImage(vendor_id_,brand_id_,sn_,product_image_map_);
				return recv_uploadVendorFullScaleProductImage(); 
				
			}
			
			
			private void send_uploadVendorFullScaleProductImage(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, vipapis.product.UploadImageInfo> product_image_map_){
				
				InitInvocation("uploadVendorFullScaleProductImage");
				
				uploadVendorFullScaleProductImage_args args = new uploadVendorFullScaleProductImage_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetProduct_image_map(product_image_map_);
				
				SendBase(args, uploadVendorFullScaleProductImage_argsHelper.getInstance());
			}
			
			
			private Dictionary<int?, vipapis.product.UploadImageResult> recv_uploadVendorFullScaleProductImage(){
				
				uploadVendorFullScaleProductImage_result result = new uploadVendorFullScaleProductImage_result();
				ReceiveBase(result, uploadVendorFullScaleProductImage_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}