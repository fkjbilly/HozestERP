using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.marketplace.product{
	
	
	public class ProductServiceHelper {
		
		
		
		public class addProduct_args {
			
			///<summary>
			/// 新增商品参数
			///</summary>
			
			private vipapis.marketplace.product.AddProductRequest request_;
			
			public vipapis.marketplace.product.AddProductRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.product.AddProductRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class appendSkus_args {
			
			///<summary>
			/// 为SPU添加SKU信息请求
			///</summary>
			
			private vipapis.marketplace.product.AppendSkusRequest request_;
			
			public vipapis.marketplace.product.AppendSkusRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.product.AppendSkusRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class autoBindProductSizeTable_args {
			
			///<summary>
			/// 根据尺码表模板自动绑定请求体
			///</summary>
			
			private vipapis.marketplace.product.AutoBindProductSizeTableRequest autoBindProductSizeTableRequest_;
			
			public vipapis.marketplace.product.AutoBindProductSizeTableRequest GetAutoBindProductSizeTableRequest(){
				return this.autoBindProductSizeTableRequest_;
			}
			
			public void SetAutoBindProductSizeTableRequest(vipapis.marketplace.product.AutoBindProductSizeTableRequest value){
				this.autoBindProductSizeTableRequest_ = value;
			}
			
		}
		
		
		
		
		public class bindProductColorImage_args {
			
			///<summary>
			/// 商品色图绑定模型
			///</summary>
			
			private vipapis.marketplace.product.ProductColorImageBindModel bindModel_;
			
			public vipapis.marketplace.product.ProductColorImageBindModel GetBindModel(){
				return this.bindModel_;
			}
			
			public void SetBindModel(vipapis.marketplace.product.ProductColorImageBindModel value){
				this.bindModel_ = value;
			}
			
		}
		
		
		
		
		public class bindProductImage_args {
			
			///<summary>
			/// 商品款图绑定模型
			///</summary>
			
			private vipapis.marketplace.product.ProductImageBindModel bindModel_;
			
			public vipapis.marketplace.product.ProductImageBindModel GetBindModel(){
				return this.bindModel_;
			}
			
			public void SetBindModel(vipapis.marketplace.product.ProductImageBindModel value){
				this.bindModel_ = value;
			}
			
		}
		
		
		
		
		public class editProduct_args {
			
			///<summary>
			/// 编辑商品参数
			///</summary>
			
			private vipapis.marketplace.product.EditProductRequest request_;
			
			public vipapis.marketplace.product.EditProductRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.product.EditProductRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getProductById_args {
			
			///<summary>
			/// spu_id
			///</summary>
			
			private string spu_id_;
			
			public string GetSpu_id(){
				return this.spu_id_;
			}
			
			public void SetSpu_id(string value){
				this.spu_id_ = value;
			}
			
		}
		
		
		
		
		public class getProductPreviewUrl_args {
			
			///<summary>
			/// 商品编码
			///</summary>
			
			private string spu_id_;
			
			///<summary>
			/// sku编码
			///</summary>
			
			private string sku_id_;
			
			public string GetSpu_id(){
				return this.spu_id_;
			}
			
			public void SetSpu_id(string value){
				this.spu_id_ = value;
			}
			public string GetSku_id(){
				return this.sku_id_;
			}
			
			public void SetSku_id(string value){
				this.sku_id_ = value;
			}
			
		}
		
		
		
		
		public class getProducts_args {
			
			///<summary>
			/// 商品列表查询参数
			///</summary>
			
			private vipapis.marketplace.product.GetProductRequest request_;
			
			public vipapis.marketplace.product.GetProductRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.marketplace.product.GetProductRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getSkuById_args {
			
			///<summary>
			/// 商品列表查询参数
			///</summary>
			
			private string sku_id_;
			
			public string GetSku_id(){
				return this.sku_id_;
			}
			
			public void SetSku_id(string value){
				this.sku_id_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class offShelf_args {
			
			///<summary>
			/// 即将下架商品
			///</summary>
			
			private vipapis.marketplace.product.OffShelfProduct offShelfProduct_;
			
			public vipapis.marketplace.product.OffShelfProduct GetOffShelfProduct(){
				return this.offShelfProduct_;
			}
			
			public void SetOffShelfProduct(vipapis.marketplace.product.OffShelfProduct value){
				this.offShelfProduct_ = value;
			}
			
		}
		
		
		
		
		public class onShelf_args {
			
			///<summary>
			/// 即将上架商品
			///</summary>
			
			private vipapis.marketplace.product.OnShelfProduct onShelfProduct_;
			
			public vipapis.marketplace.product.OnShelfProduct GetOnShelfProduct(){
				return this.onShelfProduct_;
			}
			
			public void SetOnShelfProduct(vipapis.marketplace.product.OnShelfProduct value){
				this.onShelfProduct_ = value;
			}
			
		}
		
		
		
		
		public class submitProducts_args {
			
			///<summary>
			/// 商品spuId列表
			///</summary>
			
			private List<string> spu_ids_;
			
			public List<string> GetSpu_ids(){
				return this.spu_ids_;
			}
			
			public void SetSpu_ids(List<string> value){
				this.spu_ids_ = value;
			}
			
		}
		
		
		
		
		public class unbindProductImage_args {
			
			///<summary>
			/// 商品色图绑定模型
			///</summary>
			
			private vipapis.marketplace.product.UnbindProductImageRequest unbindProductImageRequest_;
			
			public vipapis.marketplace.product.UnbindProductImageRequest GetUnbindProductImageRequest(){
				return this.unbindProductImageRequest_;
			}
			
			public void SetUnbindProductImageRequest(vipapis.marketplace.product.UnbindProductImageRequest value){
				this.unbindProductImageRequest_ = value;
			}
			
		}
		
		
		
		
		public class uploadImage_args {
			
			///<summary>
			/// 文件名(要以.jpg结尾)
			/// @sampleValue file_name 13MP202AHSL.jpg
			///</summary>
			
			private string file_name_;
			
			///<summary>
			/// 是否需要覆盖,1:覆盖，其它:不覆盖
			/// @sampleValue is_override 1
			///</summary>
			
			private string is_override_;
			
			///<summary>
			/// 图片内容
			/// @sampleValue img_content value是图片文件内容的Base64编码值
			///</summary>
			
			private string img_content_;
			
			public string GetFile_name(){
				return this.file_name_;
			}
			
			public void SetFile_name(string value){
				this.file_name_ = value;
			}
			public string GetIs_override(){
				return this.is_override_;
			}
			
			public void SetIs_override(string value){
				this.is_override_ = value;
			}
			public string GetImg_content(){
				return this.img_content_;
			}
			
			public void SetImg_content(string value){
				this.img_content_ = value;
			}
			
		}
		
		
		
		
		public class addProduct_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.AddProductResponse success_;
			
			public vipapis.marketplace.product.AddProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.AddProductResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class appendSkus_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.AppendSkusResponse success_;
			
			public vipapis.marketplace.product.AppendSkusResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.AppendSkusResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class autoBindProductSizeTable_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.AutoBindProductSizeTableResponse success_;
			
			public vipapis.marketplace.product.AutoBindProductSizeTableResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.AutoBindProductSizeTableResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class bindProductColorImage_result {
			
			
		}
		
		
		
		
		public class bindProductImage_result {
			
			
		}
		
		
		
		
		public class editProduct_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.EditProductResponse success_;
			
			public vipapis.marketplace.product.EditProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.EditProductResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getProductById_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.ProductDetail success_;
			
			public vipapis.marketplace.product.ProductDetail GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.ProductDetail value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getProductPreviewUrl_result {
			
			///<summary>
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getProducts_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.GetProductsResponse success_;
			
			public vipapis.marketplace.product.GetProductsResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.GetProductsResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSkuById_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.SkuDetail success_;
			
			public vipapis.marketplace.product.SkuDetail GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.SkuDetail value){
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
		
		
		
		
		public class offShelf_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.OffShelfResponse success_;
			
			public vipapis.marketplace.product.OffShelfResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.OffShelfResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class onShelf_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.OnShelfResponse success_;
			
			public vipapis.marketplace.product.OnShelfResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.OnShelfResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class submitProducts_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.SubmitProductsResponse success_;
			
			public vipapis.marketplace.product.SubmitProductsResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.SubmitProductsResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class unbindProductImage_result {
			
			
		}
		
		
		
		
		public class uploadImage_result {
			
			///<summary>
			///</summary>
			
			private vipapis.marketplace.product.ImageInfo success_;
			
			public vipapis.marketplace.product.ImageInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.marketplace.product.ImageInfo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class addProduct_argsHelper : TBeanSerializer<addProduct_args>
		{
			
			public static addProduct_argsHelper OBJ = new addProduct_argsHelper();
			
			public static addProduct_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addProduct_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.AddProductRequest value;
					
					value = new vipapis.marketplace.product.AddProductRequest();
					vipapis.marketplace.product.AddProductRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addProduct_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.product.AddProductRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addProduct_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class appendSkus_argsHelper : TBeanSerializer<appendSkus_args>
		{
			
			public static appendSkus_argsHelper OBJ = new appendSkus_argsHelper();
			
			public static appendSkus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(appendSkus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.AppendSkusRequest value;
					
					value = new vipapis.marketplace.product.AppendSkusRequest();
					vipapis.marketplace.product.AppendSkusRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(appendSkus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.product.AppendSkusRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(appendSkus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoBindProductSizeTable_argsHelper : TBeanSerializer<autoBindProductSizeTable_args>
		{
			
			public static autoBindProductSizeTable_argsHelper OBJ = new autoBindProductSizeTable_argsHelper();
			
			public static autoBindProductSizeTable_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoBindProductSizeTable_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.AutoBindProductSizeTableRequest value;
					
					value = new vipapis.marketplace.product.AutoBindProductSizeTableRequest();
					vipapis.marketplace.product.AutoBindProductSizeTableRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetAutoBindProductSizeTableRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoBindProductSizeTable_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetAutoBindProductSizeTableRequest() != null) {
					
					oprot.WriteFieldBegin("autoBindProductSizeTableRequest");
					
					vipapis.marketplace.product.AutoBindProductSizeTableRequestHelper.getInstance().Write(structs.GetAutoBindProductSizeTableRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("autoBindProductSizeTableRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(autoBindProductSizeTable_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class bindProductColorImage_argsHelper : TBeanSerializer<bindProductColorImage_args>
		{
			
			public static bindProductColorImage_argsHelper OBJ = new bindProductColorImage_argsHelper();
			
			public static bindProductColorImage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(bindProductColorImage_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.ProductColorImageBindModel value;
					
					value = new vipapis.marketplace.product.ProductColorImageBindModel();
					vipapis.marketplace.product.ProductColorImageBindModelHelper.getInstance().Read(value, iprot);
					
					structs.SetBindModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(bindProductColorImage_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetBindModel() != null) {
					
					oprot.WriteFieldBegin("bindModel");
					
					vipapis.marketplace.product.ProductColorImageBindModelHelper.getInstance().Write(structs.GetBindModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("bindModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(bindProductColorImage_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class bindProductImage_argsHelper : TBeanSerializer<bindProductImage_args>
		{
			
			public static bindProductImage_argsHelper OBJ = new bindProductImage_argsHelper();
			
			public static bindProductImage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(bindProductImage_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.ProductImageBindModel value;
					
					value = new vipapis.marketplace.product.ProductImageBindModel();
					vipapis.marketplace.product.ProductImageBindModelHelper.getInstance().Read(value, iprot);
					
					structs.SetBindModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(bindProductImage_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetBindModel() != null) {
					
					oprot.WriteFieldBegin("bindModel");
					
					vipapis.marketplace.product.ProductImageBindModelHelper.getInstance().Write(structs.GetBindModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("bindModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(bindProductImage_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editProduct_argsHelper : TBeanSerializer<editProduct_args>
		{
			
			public static editProduct_argsHelper OBJ = new editProduct_argsHelper();
			
			public static editProduct_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editProduct_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.EditProductRequest value;
					
					value = new vipapis.marketplace.product.EditProductRequest();
					vipapis.marketplace.product.EditProductRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editProduct_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.product.EditProductRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editProduct_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductById_argsHelper : TBeanSerializer<getProductById_args>
		{
			
			public static getProductById_argsHelper OBJ = new getProductById_argsHelper();
			
			public static getProductById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSpu_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductById_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSpu_id() != null) {
					
					oprot.WriteFieldBegin("spu_id");
					oprot.WriteString(structs.GetSpu_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("spu_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductById_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductPreviewUrl_argsHelper : TBeanSerializer<getProductPreviewUrl_args>
		{
			
			public static getProductPreviewUrl_argsHelper OBJ = new getProductPreviewUrl_argsHelper();
			
			public static getProductPreviewUrl_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductPreviewUrl_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSpu_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSku_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductPreviewUrl_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSpu_id() != null) {
					
					oprot.WriteFieldBegin("spu_id");
					oprot.WriteString(structs.GetSpu_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("spu_id can not be null!");
				}
				
				
				if(structs.GetSku_id() != null) {
					
					oprot.WriteFieldBegin("sku_id");
					oprot.WriteString(structs.GetSku_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductPreviewUrl_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProducts_argsHelper : TBeanSerializer<getProducts_args>
		{
			
			public static getProducts_argsHelper OBJ = new getProducts_argsHelper();
			
			public static getProducts_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProducts_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.GetProductRequest value;
					
					value = new vipapis.marketplace.product.GetProductRequest();
					vipapis.marketplace.product.GetProductRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProducts_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.marketplace.product.GetProductRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProducts_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuById_argsHelper : TBeanSerializer<getSkuById_args>
		{
			
			public static getSkuById_argsHelper OBJ = new getSkuById_argsHelper();
			
			public static getSkuById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSku_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuById_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSku_id() != null) {
					
					oprot.WriteFieldBegin("sku_id");
					oprot.WriteString(structs.GetSku_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sku_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuById_args bean){
				
				
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
		
		
		
		
		public class offShelf_argsHelper : TBeanSerializer<offShelf_args>
		{
			
			public static offShelf_argsHelper OBJ = new offShelf_argsHelper();
			
			public static offShelf_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(offShelf_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.OffShelfProduct value;
					
					value = new vipapis.marketplace.product.OffShelfProduct();
					vipapis.marketplace.product.OffShelfProductHelper.getInstance().Read(value, iprot);
					
					structs.SetOffShelfProduct(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(offShelf_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOffShelfProduct() != null) {
					
					oprot.WriteFieldBegin("offShelfProduct");
					
					vipapis.marketplace.product.OffShelfProductHelper.getInstance().Write(structs.GetOffShelfProduct(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("offShelfProduct can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(offShelf_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class onShelf_argsHelper : TBeanSerializer<onShelf_args>
		{
			
			public static onShelf_argsHelper OBJ = new onShelf_argsHelper();
			
			public static onShelf_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(onShelf_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.OnShelfProduct value;
					
					value = new vipapis.marketplace.product.OnShelfProduct();
					vipapis.marketplace.product.OnShelfProductHelper.getInstance().Read(value, iprot);
					
					structs.SetOnShelfProduct(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(onShelf_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOnShelfProduct() != null) {
					
					oprot.WriteFieldBegin("onShelfProduct");
					
					vipapis.marketplace.product.OnShelfProductHelper.getInstance().Write(structs.GetOnShelfProduct(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("onShelfProduct can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(onShelf_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class submitProducts_argsHelper : TBeanSerializer<submitProducts_args>
		{
			
			public static submitProducts_argsHelper OBJ = new submitProducts_argsHelper();
			
			public static submitProducts_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitProducts_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSpu_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(submitProducts_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSpu_ids() != null) {
					
					oprot.WriteFieldBegin("spu_ids");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSpu_ids()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("spu_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitProducts_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class unbindProductImage_argsHelper : TBeanSerializer<unbindProductImage_args>
		{
			
			public static unbindProductImage_argsHelper OBJ = new unbindProductImage_argsHelper();
			
			public static unbindProductImage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(unbindProductImage_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.UnbindProductImageRequest value;
					
					value = new vipapis.marketplace.product.UnbindProductImageRequest();
					vipapis.marketplace.product.UnbindProductImageRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetUnbindProductImageRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(unbindProductImage_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetUnbindProductImageRequest() != null) {
					
					oprot.WriteFieldBegin("unbindProductImageRequest");
					
					vipapis.marketplace.product.UnbindProductImageRequestHelper.getInstance().Write(structs.GetUnbindProductImageRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("unbindProductImageRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(unbindProductImage_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadImage_argsHelper : TBeanSerializer<uploadImage_args>
		{
			
			public static uploadImage_argsHelper OBJ = new uploadImage_argsHelper();
			
			public static uploadImage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadImage_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFile_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetIs_override(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImg_content(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadImage_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetFile_name() != null) {
					
					oprot.WriteFieldBegin("file_name");
					oprot.WriteString(structs.GetFile_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("file_name can not be null!");
				}
				
				
				if(structs.GetIs_override() != null) {
					
					oprot.WriteFieldBegin("is_override");
					oprot.WriteString(structs.GetIs_override());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("is_override can not be null!");
				}
				
				
				if(structs.GetImg_content() != null) {
					
					oprot.WriteFieldBegin("img_content");
					oprot.WriteString(structs.GetImg_content());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("img_content can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadImage_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addProduct_resultHelper : TBeanSerializer<addProduct_result>
		{
			
			public static addProduct_resultHelper OBJ = new addProduct_resultHelper();
			
			public static addProduct_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addProduct_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.AddProductResponse value;
					
					value = new vipapis.marketplace.product.AddProductResponse();
					vipapis.marketplace.product.AddProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addProduct_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.AddProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addProduct_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class appendSkus_resultHelper : TBeanSerializer<appendSkus_result>
		{
			
			public static appendSkus_resultHelper OBJ = new appendSkus_resultHelper();
			
			public static appendSkus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(appendSkus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.AppendSkusResponse value;
					
					value = new vipapis.marketplace.product.AppendSkusResponse();
					vipapis.marketplace.product.AppendSkusResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(appendSkus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.AppendSkusResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(appendSkus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoBindProductSizeTable_resultHelper : TBeanSerializer<autoBindProductSizeTable_result>
		{
			
			public static autoBindProductSizeTable_resultHelper OBJ = new autoBindProductSizeTable_resultHelper();
			
			public static autoBindProductSizeTable_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoBindProductSizeTable_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.AutoBindProductSizeTableResponse value;
					
					value = new vipapis.marketplace.product.AutoBindProductSizeTableResponse();
					vipapis.marketplace.product.AutoBindProductSizeTableResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoBindProductSizeTable_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.AutoBindProductSizeTableResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(autoBindProductSizeTable_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class bindProductColorImage_resultHelper : TBeanSerializer<bindProductColorImage_result>
		{
			
			public static bindProductColorImage_resultHelper OBJ = new bindProductColorImage_resultHelper();
			
			public static bindProductColorImage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(bindProductColorImage_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(bindProductColorImage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(bindProductColorImage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class bindProductImage_resultHelper : TBeanSerializer<bindProductImage_result>
		{
			
			public static bindProductImage_resultHelper OBJ = new bindProductImage_resultHelper();
			
			public static bindProductImage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(bindProductImage_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(bindProductImage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(bindProductImage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editProduct_resultHelper : TBeanSerializer<editProduct_result>
		{
			
			public static editProduct_resultHelper OBJ = new editProduct_resultHelper();
			
			public static editProduct_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editProduct_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.EditProductResponse value;
					
					value = new vipapis.marketplace.product.EditProductResponse();
					vipapis.marketplace.product.EditProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editProduct_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.EditProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editProduct_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductById_resultHelper : TBeanSerializer<getProductById_result>
		{
			
			public static getProductById_resultHelper OBJ = new getProductById_resultHelper();
			
			public static getProductById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.ProductDetail value;
					
					value = new vipapis.marketplace.product.ProductDetail();
					vipapis.marketplace.product.ProductDetailHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.ProductDetailHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductById_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductPreviewUrl_resultHelper : TBeanSerializer<getProductPreviewUrl_result>
		{
			
			public static getProductPreviewUrl_resultHelper OBJ = new getProductPreviewUrl_resultHelper();
			
			public static getProductPreviewUrl_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductPreviewUrl_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductPreviewUrl_result structs, Protocol oprot){
				
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
			
			
			public void Validate(getProductPreviewUrl_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProducts_resultHelper : TBeanSerializer<getProducts_result>
		{
			
			public static getProducts_resultHelper OBJ = new getProducts_resultHelper();
			
			public static getProducts_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProducts_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.GetProductsResponse value;
					
					value = new vipapis.marketplace.product.GetProductsResponse();
					vipapis.marketplace.product.GetProductsResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProducts_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.GetProductsResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProducts_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSkuById_resultHelper : TBeanSerializer<getSkuById_result>
		{
			
			public static getSkuById_resultHelper OBJ = new getSkuById_resultHelper();
			
			public static getSkuById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSkuById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.SkuDetail value;
					
					value = new vipapis.marketplace.product.SkuDetail();
					vipapis.marketplace.product.SkuDetailHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSkuById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.SkuDetailHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSkuById_result bean){
				
				
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
		
		
		
		
		public class offShelf_resultHelper : TBeanSerializer<offShelf_result>
		{
			
			public static offShelf_resultHelper OBJ = new offShelf_resultHelper();
			
			public static offShelf_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(offShelf_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.OffShelfResponse value;
					
					value = new vipapis.marketplace.product.OffShelfResponse();
					vipapis.marketplace.product.OffShelfResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(offShelf_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.OffShelfResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(offShelf_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class onShelf_resultHelper : TBeanSerializer<onShelf_result>
		{
			
			public static onShelf_resultHelper OBJ = new onShelf_resultHelper();
			
			public static onShelf_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(onShelf_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.OnShelfResponse value;
					
					value = new vipapis.marketplace.product.OnShelfResponse();
					vipapis.marketplace.product.OnShelfResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(onShelf_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.OnShelfResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(onShelf_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class submitProducts_resultHelper : TBeanSerializer<submitProducts_result>
		{
			
			public static submitProducts_resultHelper OBJ = new submitProducts_resultHelper();
			
			public static submitProducts_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitProducts_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.SubmitProductsResponse value;
					
					value = new vipapis.marketplace.product.SubmitProductsResponse();
					vipapis.marketplace.product.SubmitProductsResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(submitProducts_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.SubmitProductsResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitProducts_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class unbindProductImage_resultHelper : TBeanSerializer<unbindProductImage_result>
		{
			
			public static unbindProductImage_resultHelper OBJ = new unbindProductImage_resultHelper();
			
			public static unbindProductImage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(unbindProductImage_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(unbindProductImage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(unbindProductImage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadImage_resultHelper : TBeanSerializer<uploadImage_result>
		{
			
			public static uploadImage_resultHelper OBJ = new uploadImage_resultHelper();
			
			public static uploadImage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadImage_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.marketplace.product.ImageInfo value;
					
					value = new vipapis.marketplace.product.ImageInfo();
					vipapis.marketplace.product.ImageInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadImage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.marketplace.product.ImageInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadImage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class ProductServiceClient : OspRestStub , ProductService  {
			
			
			public ProductServiceClient():base("vipapis.marketplace.product.ProductService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.marketplace.product.AddProductResponse addProduct(vipapis.marketplace.product.AddProductRequest request_) {
				
				send_addProduct(request_);
				return recv_addProduct(); 
				
			}
			
			
			private void send_addProduct(vipapis.marketplace.product.AddProductRequest request_){
				
				InitInvocation("addProduct");
				
				addProduct_args args = new addProduct_args();
				args.SetRequest(request_);
				
				SendBase(args, addProduct_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.AddProductResponse recv_addProduct(){
				
				addProduct_result result = new addProduct_result();
				ReceiveBase(result, addProduct_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.product.AppendSkusResponse appendSkus(vipapis.marketplace.product.AppendSkusRequest request_) {
				
				send_appendSkus(request_);
				return recv_appendSkus(); 
				
			}
			
			
			private void send_appendSkus(vipapis.marketplace.product.AppendSkusRequest request_){
				
				InitInvocation("appendSkus");
				
				appendSkus_args args = new appendSkus_args();
				args.SetRequest(request_);
				
				SendBase(args, appendSkus_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.AppendSkusResponse recv_appendSkus(){
				
				appendSkus_result result = new appendSkus_result();
				ReceiveBase(result, appendSkus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.product.AutoBindProductSizeTableResponse autoBindProductSizeTable(vipapis.marketplace.product.AutoBindProductSizeTableRequest autoBindProductSizeTableRequest_) {
				
				send_autoBindProductSizeTable(autoBindProductSizeTableRequest_);
				return recv_autoBindProductSizeTable(); 
				
			}
			
			
			private void send_autoBindProductSizeTable(vipapis.marketplace.product.AutoBindProductSizeTableRequest autoBindProductSizeTableRequest_){
				
				InitInvocation("autoBindProductSizeTable");
				
				autoBindProductSizeTable_args args = new autoBindProductSizeTable_args();
				args.SetAutoBindProductSizeTableRequest(autoBindProductSizeTableRequest_);
				
				SendBase(args, autoBindProductSizeTable_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.AutoBindProductSizeTableResponse recv_autoBindProductSizeTable(){
				
				autoBindProductSizeTable_result result = new autoBindProductSizeTable_result();
				ReceiveBase(result, autoBindProductSizeTable_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void bindProductColorImage(vipapis.marketplace.product.ProductColorImageBindModel bindModel_) {
				
				send_bindProductColorImage(bindModel_);
				recv_bindProductColorImage();
				
			}
			
			
			private void send_bindProductColorImage(vipapis.marketplace.product.ProductColorImageBindModel bindModel_){
				
				InitInvocation("bindProductColorImage");
				
				bindProductColorImage_args args = new bindProductColorImage_args();
				args.SetBindModel(bindModel_);
				
				SendBase(args, bindProductColorImage_argsHelper.getInstance());
			}
			
			
			private void recv_bindProductColorImage(){
				
				bindProductColorImage_result result = new bindProductColorImage_result();
				ReceiveBase(result, bindProductColorImage_resultHelper.getInstance());
				
				
			}
			
			
			public void bindProductImage(vipapis.marketplace.product.ProductImageBindModel bindModel_) {
				
				send_bindProductImage(bindModel_);
				recv_bindProductImage();
				
			}
			
			
			private void send_bindProductImage(vipapis.marketplace.product.ProductImageBindModel bindModel_){
				
				InitInvocation("bindProductImage");
				
				bindProductImage_args args = new bindProductImage_args();
				args.SetBindModel(bindModel_);
				
				SendBase(args, bindProductImage_argsHelper.getInstance());
			}
			
			
			private void recv_bindProductImage(){
				
				bindProductImage_result result = new bindProductImage_result();
				ReceiveBase(result, bindProductImage_resultHelper.getInstance());
				
				
			}
			
			
			public vipapis.marketplace.product.EditProductResponse editProduct(vipapis.marketplace.product.EditProductRequest request_) {
				
				send_editProduct(request_);
				return recv_editProduct(); 
				
			}
			
			
			private void send_editProduct(vipapis.marketplace.product.EditProductRequest request_){
				
				InitInvocation("editProduct");
				
				editProduct_args args = new editProduct_args();
				args.SetRequest(request_);
				
				SendBase(args, editProduct_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.EditProductResponse recv_editProduct(){
				
				editProduct_result result = new editProduct_result();
				ReceiveBase(result, editProduct_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.product.ProductDetail getProductById(string spu_id_) {
				
				send_getProductById(spu_id_);
				return recv_getProductById(); 
				
			}
			
			
			private void send_getProductById(string spu_id_){
				
				InitInvocation("getProductById");
				
				getProductById_args args = new getProductById_args();
				args.SetSpu_id(spu_id_);
				
				SendBase(args, getProductById_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.ProductDetail recv_getProductById(){
				
				getProductById_result result = new getProductById_result();
				ReceiveBase(result, getProductById_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string getProductPreviewUrl(string spu_id_,string sku_id_) {
				
				send_getProductPreviewUrl(spu_id_,sku_id_);
				return recv_getProductPreviewUrl(); 
				
			}
			
			
			private void send_getProductPreviewUrl(string spu_id_,string sku_id_){
				
				InitInvocation("getProductPreviewUrl");
				
				getProductPreviewUrl_args args = new getProductPreviewUrl_args();
				args.SetSpu_id(spu_id_);
				args.SetSku_id(sku_id_);
				
				SendBase(args, getProductPreviewUrl_argsHelper.getInstance());
			}
			
			
			private string recv_getProductPreviewUrl(){
				
				getProductPreviewUrl_result result = new getProductPreviewUrl_result();
				ReceiveBase(result, getProductPreviewUrl_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.product.GetProductsResponse getProducts(vipapis.marketplace.product.GetProductRequest request_) {
				
				send_getProducts(request_);
				return recv_getProducts(); 
				
			}
			
			
			private void send_getProducts(vipapis.marketplace.product.GetProductRequest request_){
				
				InitInvocation("getProducts");
				
				getProducts_args args = new getProducts_args();
				args.SetRequest(request_);
				
				SendBase(args, getProducts_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.GetProductsResponse recv_getProducts(){
				
				getProducts_result result = new getProducts_result();
				ReceiveBase(result, getProducts_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.product.SkuDetail getSkuById(string sku_id_) {
				
				send_getSkuById(sku_id_);
				return recv_getSkuById(); 
				
			}
			
			
			private void send_getSkuById(string sku_id_){
				
				InitInvocation("getSkuById");
				
				getSkuById_args args = new getSkuById_args();
				args.SetSku_id(sku_id_);
				
				SendBase(args, getSkuById_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.SkuDetail recv_getSkuById(){
				
				getSkuById_result result = new getSkuById_result();
				ReceiveBase(result, getSkuById_resultHelper.getInstance());
				
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
			
			
			public vipapis.marketplace.product.OffShelfResponse offShelf(vipapis.marketplace.product.OffShelfProduct offShelfProduct_) {
				
				send_offShelf(offShelfProduct_);
				return recv_offShelf(); 
				
			}
			
			
			private void send_offShelf(vipapis.marketplace.product.OffShelfProduct offShelfProduct_){
				
				InitInvocation("offShelf");
				
				offShelf_args args = new offShelf_args();
				args.SetOffShelfProduct(offShelfProduct_);
				
				SendBase(args, offShelf_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.OffShelfResponse recv_offShelf(){
				
				offShelf_result result = new offShelf_result();
				ReceiveBase(result, offShelf_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.product.OnShelfResponse onShelf(vipapis.marketplace.product.OnShelfProduct onShelfProduct_) {
				
				send_onShelf(onShelfProduct_);
				return recv_onShelf(); 
				
			}
			
			
			private void send_onShelf(vipapis.marketplace.product.OnShelfProduct onShelfProduct_){
				
				InitInvocation("onShelf");
				
				onShelf_args args = new onShelf_args();
				args.SetOnShelfProduct(onShelfProduct_);
				
				SendBase(args, onShelf_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.OnShelfResponse recv_onShelf(){
				
				onShelf_result result = new onShelf_result();
				ReceiveBase(result, onShelf_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.marketplace.product.SubmitProductsResponse submitProducts(List<string> spu_ids_) {
				
				send_submitProducts(spu_ids_);
				return recv_submitProducts(); 
				
			}
			
			
			private void send_submitProducts(List<string> spu_ids_){
				
				InitInvocation("submitProducts");
				
				submitProducts_args args = new submitProducts_args();
				args.SetSpu_ids(spu_ids_);
				
				SendBase(args, submitProducts_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.SubmitProductsResponse recv_submitProducts(){
				
				submitProducts_result result = new submitProducts_result();
				ReceiveBase(result, submitProducts_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void unbindProductImage(vipapis.marketplace.product.UnbindProductImageRequest unbindProductImageRequest_) {
				
				send_unbindProductImage(unbindProductImageRequest_);
				recv_unbindProductImage();
				
			}
			
			
			private void send_unbindProductImage(vipapis.marketplace.product.UnbindProductImageRequest unbindProductImageRequest_){
				
				InitInvocation("unbindProductImage");
				
				unbindProductImage_args args = new unbindProductImage_args();
				args.SetUnbindProductImageRequest(unbindProductImageRequest_);
				
				SendBase(args, unbindProductImage_argsHelper.getInstance());
			}
			
			
			private void recv_unbindProductImage(){
				
				unbindProductImage_result result = new unbindProductImage_result();
				ReceiveBase(result, unbindProductImage_resultHelper.getInstance());
				
				
			}
			
			
			public vipapis.marketplace.product.ImageInfo uploadImage(string file_name_,string is_override_,string img_content_) {
				
				send_uploadImage(file_name_,is_override_,img_content_);
				return recv_uploadImage(); 
				
			}
			
			
			private void send_uploadImage(string file_name_,string is_override_,string img_content_){
				
				InitInvocation("uploadImage");
				
				uploadImage_args args = new uploadImage_args();
				args.SetFile_name(file_name_);
				args.SetIs_override(is_override_);
				args.SetImg_content(img_content_);
				
				SendBase(args, uploadImage_argsHelper.getInstance());
			}
			
			
			private vipapis.marketplace.product.ImageInfo recv_uploadImage(){
				
				uploadImage_result result = new uploadImage_result();
				ReceiveBase(result, uploadImage_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}