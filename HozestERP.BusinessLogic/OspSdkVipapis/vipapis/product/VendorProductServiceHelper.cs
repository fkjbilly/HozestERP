using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.product{
	
	
	public class VendorProductServiceHelper {
		
		
		
		public class appendSkus_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 123
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// sku信息,上限100条
			///</summary>
			
			private List<vipapis.product.CreateSkuItem> sku_item_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
			public int? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(int? value){
				this.brand_id_ = value;
			}
			public List<vipapis.product.CreateSkuItem> GetSku_item_list(){
				return this.sku_item_list_;
			}
			
			public void SetSku_item_list(List<vipapis.product.CreateSkuItem> value){
				this.sku_item_list_ = value;
			}
			
		}
		
		
		
		
		public class autoBindVendorProductSizeTableRelationship_args {
			
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
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 13MP202AHSL
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 尺码表模板id
			/// @sampleValue sizetable_tpl_id 1234132
			///</summary>
			
			private int? sizetable_tpl_id_;
			
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
			public int? GetSizetable_tpl_id(){
				return this.sizetable_tpl_id_;
			}
			
			public void SetSizetable_tpl_id(int? value){
				this.sizetable_tpl_id_ = value;
			}
			
		}
		
		
		
		
		public class batchBindVendorProductImages_args {
			
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
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 13M不抛出异常代表成功P202AHSL
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// key是图片类型索引号, value是图片的url,图片索引允许取值：1, 2, 3, 4, 5, 6, 7, 15, 16, 17, 18, 19, 20, 21, 22, 30,110, 111, 112, 113, 114，601-650, 651-699。<br>销售图(列表图)：5,7<br>详情图:601-650<br>美妆详情图: 651-699<br>展示图：1、2、3、4、15、16、17、18、19、20、21、22<br>透明底图：30 (透明底图只支持png格式图片，大小100K-600K)
			/// @sampleValue url_map 1
			///</summary>
			
			private Dictionary<int?, string> url_map_;
			
			///<summary>
			/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码
			/// @sampleValue group_sn rqwer1341234143
			///</summary>
			
			private string group_sn_;
			
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
			public Dictionary<int?, string> GetUrl_map(){
				return this.url_map_;
			}
			
			public void SetUrl_map(Dictionary<int?, string> value){
				this.url_map_ = value;
			}
			public string GetGroup_sn(){
				return this.group_sn_;
			}
			
			public void SetGroup_sn(string value){
				this.group_sn_ = value;
			}
			
		}
		
		
		
		
		public class batchUploadAndBindVendorProductImage_args {
			
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
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 13MP202AHSL
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// key是图片类型索引号, 图片索引允许取值：1, 2, 3, 4, 5, 6, 7, 15, 16, 17, 18, 19, 20, 21, 22, 30,110, 111, 112, 113, 114，601-650, 651-699。<br>销售图(列表图)：5,7<br>详情图:601-650<br>美妆详情图: 651-699<br>展示图：1、2、3、4、15、16、17、18、19、20、21、22<br>透明底图：30 (透明底图只支持png格式图片，大小100K-600K)
			/// @sampleValue product_image_map 1
			///</summary>
			
			private Dictionary<int?, string> product_image_map_;
			
			///<summary>
			/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码
			/// @sampleValue group_sn rqwer1341234143
			///</summary>
			
			private string group_sn_;
			
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
			public string GetGroup_sn(){
				return this.group_sn_;
			}
			
			public void SetGroup_sn(string value){
				this.group_sn_ = value;
			}
			
		}
		
		
		
		
		public class cancelProductSubmission_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 商品spu信息
			///</summary>
			
			private List<vipapis.product.VendorProductSN> snList_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.product.VendorProductSN> GetSnList(){
				return this.snList_;
			}
			
			public void SetSnList(List<vipapis.product.VendorProductSN> value){
				this.snList_ = value;
			}
			
		}
		
		
		
		
		public class createProduct_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 商品信息
			///</summary>
			
			private List<vipapis.product.CreateProductItem> vendor_products_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.product.CreateProductItem> GetVendor_products(){
				return this.vendor_products_;
			}
			
			public void SetVendor_products(List<vipapis.product.CreateProductItem> value){
				this.vendor_products_ = value;
			}
			
		}
		
		
		
		
		public class createProductForMultiColor_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 商品信息,上限100条
			///</summary>
			
			private List<vipapis.product.CreateSpuItem> spu_item_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.product.CreateSpuItem> GetSpu_item_list(){
				return this.spu_item_list_;
			}
			
			public void SetSpu_item_list(List<vipapis.product.CreateSpuItem> value){
				this.spu_item_list_ = value;
			}
			
		}
		
		
		
		
		public class deleteVendorImageRelationship_args {
			
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
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 13MP202AHSL
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 图片索引列表
			/// @sampleValue img_index_list 以下取值：1,2,3,4,5,6,7,15,16,110,111,112,113,114,601-699
			///</summary>
			
			private List<int?> img_index_list_;
			
			///<summary>
			/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码
			/// @sampleValue group_sn rqwer1341234143
			///</summary>
			
			private string group_sn_;
			
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
			public List<int?> GetImg_index_list(){
				return this.img_index_list_;
			}
			
			public void SetImg_index_list(List<int?> value){
				this.img_index_list_ = value;
			}
			public string GetGroup_sn(){
				return this.group_sn_;
			}
			
			public void SetGroup_sn(string value){
				this.group_sn_ = value;
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
			/// 款号，同一款号商品不区分颜色、尺码
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
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 商品信息
			///</summary>
			
			private List<vipapis.product.EditProductItem> vendor_products_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<vipapis.product.EditProductItem> GetVendor_products(){
				return this.vendor_products_;
			}
			
			public void SetVendor_products(List<vipapis.product.EditProductItem> value){
				this.vendor_products_ = value;
			}
			
		}
		
		
		
		
		public class editProductForMultiColor_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 123
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// 商品信息
			///</summary>
			
			private vipapis.product.EditSpuItem edit_spu_item_list_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
			public int? GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(int? value){
				this.brand_id_ = value;
			}
			public vipapis.product.EditSpuItem GetEdit_spu_item_list(){
				return this.edit_spu_item_list_;
			}
			
			public void SetEdit_spu_item_list(vipapis.product.EditSpuItem value){
				this.edit_spu_item_list_ = value;
			}
			
		}
		
		
		
		
		public class getProductPreviewData_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 123
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码
			/// @sampleValue group_sn rqwer1341234143
			///</summary>
			
			private string group_sn_;
			
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
			public string GetGroup_sn(){
				return this.group_sn_;
			}
			
			public void SetGroup_sn(string value){
				this.group_sn_ = value;
			}
			
		}
		
		
		
		
		public class getProductPreviewUrl_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 525
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 品牌ID
			/// @sampleValue brand_id 123
			///</summary>
			
			private int? brand_id_;
			
			///<summary>
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码
			/// @sampleValue group_sn rqwer1341234143
			///</summary>
			
			private string group_sn_;
			
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
			public string GetGroup_sn(){
				return this.group_sn_;
			}
			
			public void SetGroup_sn(string value){
				this.group_sn_ = value;
			}
			
		}
		
		
		
		
		public class getRealVendorSkuByBarcode_args {
			
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
			/// 表示查询唯品会商品资料数据源自哪个库，默认查询发布库。<br>1：发布库。表示商品资料经过审核，已正式发布生效；<br>0：草稿库。表示商品资料已经提交到唯品会，但是未经过最后审核确认，是中间状态。
			///</summary>
			
			private int? source_;
			
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
			public int? GetSource(){
				return this.source_;
			}
			
			public void SetSource(int? value){
				this.source_ = value;
			}
			
		}
		
		
		
		
		public class getSpuBySnVendorIdAndBrandId_args {
			
			///<summary>
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
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
			/// 表示查询唯品会商品资料数据源自哪个库，默认查询发布库。<br>1：发布库。表示商品资料经过审核，已正式发布生效；<br>0：草稿库。表示商品资料已经提交到唯品会，但是未经过最后审核确认，是中间状态。
			///</summary>
			
			private int? source_;
			
			public string GetSn(){
				return this.sn_;
			}
			
			public void SetSn(string value){
				this.sn_ = value;
			}
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
			public int? GetSource(){
				return this.source_;
			}
			
			public void SetSource(int? value){
				this.source_ = value;
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
			/// 款号，同一款号商品不区分颜色、尺码
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
			
			///<summary>
			/// 表示查询唯品会商品资料源自哪个库，默认查询发布库。<br>1：发布库。表示商品资料经过审核，已正式发布生效；<br>0：草稿库。表示商品资料已经提交到唯品会，但是未经过最后审核确认，是中间状态。
			///</summary>
			
			private int? source_;
			
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
			public int? GetSource(){
				return this.source_;
			}
			
			public void SetSource(int? value){
				this.source_ = value;
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
			/// 款号，同一款号商品不区分颜色、尺码
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
			
			///<summary>
			/// 表示查询唯品会商品资料源自哪个库，默认查询发布库。<br>1：发布库。表示商品资料经过审核，已正式发布生效；<br>0：草稿库。表示商品资料已经提交到唯品会，但是未经过最后审核确认，是中间状态。
			///</summary>
			
			private int? source_;
			
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
			public int? GetSource(){
				return this.source_;
			}
			
			public void SetSource(int? value){
				this.source_ = value;
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
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 113113302011
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 尺码id
			/// @sampleValue size_table_id 
			///</summary>
			
			private long? size_table_id_;
			
			///<summary>
			/// 供应商SKUID映射尺码详细ID信息,key:条码;value:尺码详情id
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
			/// 供应商商品款号
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
		
		
		
		
		public class uploadAndBindVendorProductImage_args {
			
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
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 13MP202AHSL
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 图片索引允许取值：1, 2, 3, 4, 5, 6, 7, 15, 16, 17, 18, 19, 20, 21, 22, 30,110, 111, 112, 113, 114，601-650, 651-699。<br>销售图(列表图)：5,7<br>详情图:601-650<br>美妆详情图: 651-699<br>展示图：1、2、3、4、15、16、17、18、19、20、21、22<br>透明底图：30 (透明底图只支持png格式图片，大小100K-600K)
			/// @sampleValue img_index 1
			///</summary>
			
			private int? img_index_;
			
			///<summary>
			/// 图片内容
			/// @sampleValue img_content 图片文件内容的Base64编码值
			///</summary>
			
			private string img_content_;
			
			///<summary>
			/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码
			/// @sampleValue group_sn rqwer1341234143
			///</summary>
			
			private string group_sn_;
			
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
			public int? GetImg_index(){
				return this.img_index_;
			}
			
			public void SetImg_index(int? value){
				this.img_index_ = value;
			}
			public string GetImg_content(){
				return this.img_content_;
			}
			
			public void SetImg_content(string value){
				this.img_content_ = value;
			}
			public string GetGroup_sn(){
				return this.group_sn_;
			}
			
			public void SetGroup_sn(string value){
				this.group_sn_ = value;
			}
			
		}
		
		
		
		
		public class uploadImage_args {
			
			///<summary>
			/// 供应商ID
			/// @sampleValue vendor_id 550
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 文件名(要以.jpg或者.png结尾)
			/// @sampleValue file_name 13MP202AHSL.jpg
			///</summary>
			
			private string file_name_;
			
			///<summary>
			/// 是否需要覆盖,1:覆盖，其它不覆盖
			/// @sampleValue is_override 1
			///</summary>
			
			private string is_override_;
			
			///<summary>
			/// 图片内容
			/// @sampleValue img_content value是图片文件内容的Base64编码值
			///</summary>
			
			private string img_content_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
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
			/// 款号，同一款号商品不区分颜色、尺码
			/// @sampleValue sn 13MP202AHSL
			///</summary>
			
			private string sn_;
			
			///<summary>
			/// 图片内容,key是图片类型索引号, 图片索引允许取值：1, 2, 3, 4, 5, 6, 7, 15, 16, 17, 18, 19, 20, 21, 22, 30,110, 111, 112, 113, 114，601-650, 651-699。<br>销售图(列表图)：5,7<br>详情图:601-650<br>美妆详情图: 651-699<br>展示图：1、2、3、4、15、16、17、18、19、20、21、22<br>透明底图：30 (透明底图只支持png格式图片，大小100K-600K)
			/// @sampleValue product_image_map 1
			///</summary>
			
			private Dictionary<int?, string> product_image_map_;
			
			///<summary>
			/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码
			/// @sampleValue group_sn rqwer1341234143
			///</summary>
			
			private string group_sn_;
			
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
			public string GetGroup_sn(){
				return this.group_sn_;
			}
			
			public void SetGroup_sn(string value){
				this.group_sn_ = value;
			}
			
		}
		
		
		
		
		public class appendSkus_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.AppendSkuResponse success_;
			
			public vipapis.product.AppendSkuResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.AppendSkuResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class autoBindVendorProductSizeTableRelationship_result {
			
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
		
		
		
		
		public class batchBindVendorProductImages_result {
			
			
		}
		
		
		
		
		public class batchUploadAndBindVendorProductImage_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.BatchUploadAndBindImageResult success_;
			
			public vipapis.product.BatchUploadAndBindImageResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.BatchUploadAndBindImageResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class cancelProductSubmission_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.product.CancelSubmissionResult> success_;
			
			public List<vipapis.product.CancelSubmissionResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.product.CancelSubmissionResult> value){
				this.success_ = value;
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
		
		
		
		
		public class createProductForMultiColor_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.product.ProductForMultiColorResponse> success_;
			
			public List<vipapis.product.ProductForMultiColorResponse> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.product.ProductForMultiColorResponse> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deleteVendorImageRelationship_result {
			
			///<summary>
			/// 是否删除成功
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
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
		
		
		
		
		public class editProductForMultiColor_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.ProductForMultiColorResponse success_;
			
			public vipapis.product.ProductForMultiColorResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.ProductForMultiColorResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getProductPreviewData_result {
			
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
		
		
		
		
		public class getRealVendorSkuByBarcode_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.ProductSkuInfo success_;
			
			public vipapis.product.ProductSkuInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.ProductSkuInfo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSpuBySnVendorIdAndBrandId_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.ProductSpuInfo success_;
			
			public vipapis.product.ProductSpuInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.ProductSpuInfo value){
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
		
		
		
		
		public class uploadAndBindVendorProductImage_result {
			
			///<summary>
			///</summary>
			
			private vipapis.product.UploadAndBindImageResult success_;
			
			public vipapis.product.UploadAndBindImageResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.UploadAndBindImageResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadImage_result {
			
			///<summary>
			/// 返回上传后的图片url
			///</summary>
			
			private vipapis.product.ImageInfo success_;
			
			public vipapis.product.ImageInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.product.ImageInfo value){
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
		
		
		
		
		
		public class appendSkus_argsHelper : TBeanSerializer<appendSkus_args>
		{
			
			public static appendSkus_argsHelper OBJ = new appendSkus_argsHelper();
			
			public static appendSkus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(appendSkus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.product.CreateSkuItem> value;
					
					value = new List<vipapis.product.CreateSkuItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.CreateSkuItem elem1;
							
							elem1 = new vipapis.product.CreateSkuItem();
							vipapis.product.CreateSkuItemHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSku_item_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(appendSkus_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sn can not be null!");
				}
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI32((int)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("brand_id can not be null!");
				}
				
				
				if(structs.GetSku_item_list() != null) {
					
					oprot.WriteFieldBegin("sku_item_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.CreateSkuItem _item0 in structs.GetSku_item_list()){
						
						
						vipapis.product.CreateSkuItemHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sku_item_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(appendSkus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoBindVendorProductSizeTableRelationship_argsHelper : TBeanSerializer<autoBindVendorProductSizeTableRelationship_args>
		{
			
			public static autoBindVendorProductSizeTableRelationship_argsHelper OBJ = new autoBindVendorProductSizeTableRelationship_argsHelper();
			
			public static autoBindVendorProductSizeTableRelationship_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoBindVendorProductSizeTableRelationship_args structs, Protocol iprot){
				
				
				
				
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
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSizetable_tpl_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoBindVendorProductSizeTableRelationship_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizetable_tpl_id() != null) {
					
					oprot.WriteFieldBegin("sizetable_tpl_id");
					oprot.WriteI32((int)structs.GetSizetable_tpl_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizetable_tpl_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(autoBindVendorProductSizeTableRelationship_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchBindVendorProductImages_argsHelper : TBeanSerializer<batchBindVendorProductImages_args>
		{
			
			public static batchBindVendorProductImages_argsHelper OBJ = new batchBindVendorProductImages_argsHelper();
			
			public static batchBindVendorProductImages_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchBindVendorProductImages_args structs, Protocol iprot){
				
				
				
				
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
							
							int _key0;
							string _val0;
							_key0 = iprot.ReadI32(); 
							
							_val0 = iprot.ReadString();
							
							value.Add(_key0, _val0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetUrl_map(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetGroup_sn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchBindVendorProductImages_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetUrl_map() != null) {
					
					oprot.WriteFieldBegin("url_map");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< int?, string > _ir0 in structs.GetUrl_map()){
						
						int? _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteI32((int)_key0); 
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("url_map can not be null!");
				}
				
				
				if(structs.GetGroup_sn() != null) {
					
					oprot.WriteFieldBegin("group_sn");
					oprot.WriteString(structs.GetGroup_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchBindVendorProductImages_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchUploadAndBindVendorProductImage_argsHelper : TBeanSerializer<batchUploadAndBindVendorProductImage_args>
		{
			
			public static batchUploadAndBindVendorProductImage_argsHelper OBJ = new batchUploadAndBindVendorProductImage_argsHelper();
			
			public static batchUploadAndBindVendorProductImage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchUploadAndBindVendorProductImage_args structs, Protocol iprot){
				
				
				
				
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
							
							int _key0;
							string _val0;
							_key0 = iprot.ReadI32(); 
							
							_val0 = iprot.ReadString();
							
							value.Add(_key0, _val0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetProduct_image_map(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetGroup_sn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchUploadAndBindVendorProductImage_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetGroup_sn() != null) {
					
					oprot.WriteFieldBegin("group_sn");
					oprot.WriteString(structs.GetGroup_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchUploadAndBindVendorProductImage_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelProductSubmission_argsHelper : TBeanSerializer<cancelProductSubmission_args>
		{
			
			public static cancelProductSubmission_argsHelper OBJ = new cancelProductSubmission_argsHelper();
			
			public static cancelProductSubmission_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelProductSubmission_args structs, Protocol iprot){
				
				
				
				
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
							
							vipapis.product.VendorProductSN elem0;
							
							elem0 = new vipapis.product.VendorProductSN();
							vipapis.product.VendorProductSNHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSnList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelProductSubmission_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSnList() != null) {
					
					oprot.WriteFieldBegin("snList");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.VendorProductSN _item0 in structs.GetSnList()){
						
						
						vipapis.product.VendorProductSNHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelProductSubmission_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createProduct_argsHelper : TBeanSerializer<createProduct_args>
		{
			
			public static createProduct_argsHelper OBJ = new createProduct_argsHelper();
			
			public static createProduct_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createProduct_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.product.CreateProductItem> value;
					
					value = new List<vipapis.product.CreateProductItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.CreateProductItem elem1;
							
							elem1 = new vipapis.product.CreateProductItem();
							vipapis.product.CreateProductItemHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(createProduct_args structs, Protocol oprot){
				
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
		
		
		
		
		public class createProductForMultiColor_argsHelper : TBeanSerializer<createProductForMultiColor_args>
		{
			
			public static createProductForMultiColor_argsHelper OBJ = new createProductForMultiColor_argsHelper();
			
			public static createProductForMultiColor_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createProductForMultiColor_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.product.CreateSpuItem> value;
					
					value = new List<vipapis.product.CreateSpuItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.CreateSpuItem elem1;
							
							elem1 = new vipapis.product.CreateSpuItem();
							vipapis.product.CreateSpuItemHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSpu_item_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createProductForMultiColor_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSpu_item_list() != null) {
					
					oprot.WriteFieldBegin("spu_item_list");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.CreateSpuItem _item0 in structs.GetSpu_item_list()){
						
						
						vipapis.product.CreateSpuItemHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("spu_item_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createProductForMultiColor_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteVendorImageRelationship_argsHelper : TBeanSerializer<deleteVendorImageRelationship_args>
		{
			
			public static deleteVendorImageRelationship_argsHelper OBJ = new deleteVendorImageRelationship_argsHelper();
			
			public static deleteVendorImageRelationship_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteVendorImageRelationship_args structs, Protocol iprot){
				
				
				
				
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
					
					List<int?> value;
					
					value = new List<int?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							int elem1;
							elem1 = iprot.ReadI32(); 
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetImg_index_list(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetGroup_sn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteVendorImageRelationship_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetImg_index_list() != null) {
					
					oprot.WriteFieldBegin("img_index_list");
					
					oprot.WriteListBegin();
					foreach(int _item0 in structs.GetImg_index_list()){
						
						oprot.WriteI32((int)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("img_index_list can not be null!");
				}
				
				
				if(structs.GetGroup_sn() != null) {
					
					oprot.WriteFieldBegin("group_sn");
					oprot.WriteString(structs.GetGroup_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteVendorImageRelationship_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteVendorProductSizeTableRelationship_argsHelper : TBeanSerializer<deleteVendorProductSizeTableRelationship_args>
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
		
		
		
		
		public class editProduct_argsHelper : TBeanSerializer<editProduct_args>
		{
			
			public static editProduct_argsHelper OBJ = new editProduct_argsHelper();
			
			public static editProduct_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editProduct_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
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
		
		
		
		
		public class editProductForMultiColor_argsHelper : TBeanSerializer<editProductForMultiColor_args>
		{
			
			public static editProductForMultiColor_argsHelper OBJ = new editProductForMultiColor_argsHelper();
			
			public static editProductForMultiColor_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editProductForMultiColor_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.product.EditSpuItem value;
					
					value = new vipapis.product.EditSpuItem();
					vipapis.product.EditSpuItemHelper.getInstance().Read(value, iprot);
					
					structs.SetEdit_spu_item_list(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editProductForMultiColor_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sn can not be null!");
				}
				
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteI32((int)structs.GetBrand_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("brand_id can not be null!");
				}
				
				
				if(structs.GetEdit_spu_item_list() != null) {
					
					oprot.WriteFieldBegin("edit_spu_item_list");
					
					vipapis.product.EditSpuItemHelper.getInstance().Write(structs.GetEdit_spu_item_list(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("edit_spu_item_list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editProductForMultiColor_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductPreviewData_argsHelper : TBeanSerializer<getProductPreviewData_args>
		{
			
			public static getProductPreviewData_argsHelper OBJ = new getProductPreviewData_argsHelper();
			
			public static getProductPreviewData_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductPreviewData_args structs, Protocol iprot){
				
				
				
				
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
					
					string value;
					value = iprot.ReadString();
					
					structs.SetGroup_sn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductPreviewData_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetGroup_sn() != null) {
					
					oprot.WriteFieldBegin("group_sn");
					oprot.WriteString(structs.GetGroup_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductPreviewData_args bean){
				
				
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
					
					string value;
					value = iprot.ReadString();
					
					structs.SetGroup_sn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductPreviewUrl_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetGroup_sn() != null) {
					
					oprot.WriteFieldBegin("group_sn");
					oprot.WriteString(structs.GetGroup_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductPreviewUrl_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRealVendorSkuByBarcode_argsHelper : TBeanSerializer<getRealVendorSkuByBarcode_args>
		{
			
			public static getRealVendorSkuByBarcode_argsHelper OBJ = new getRealVendorSkuByBarcode_argsHelper();
			
			public static getRealVendorSkuByBarcode_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRealVendorSkuByBarcode_args structs, Protocol iprot){
				
				
				
				
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
					
					structs.SetSource(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRealVendorSkuByBarcode_args structs, Protocol oprot){
				
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
				
				else{
					throw new ArgumentException("barcode can not be null!");
				}
				
				
				if(structs.GetSource() != null) {
					
					oprot.WriteFieldBegin("source");
					oprot.WriteI32((int)structs.GetSource()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRealVendorSkuByBarcode_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSpuBySnVendorIdAndBrandId_argsHelper : TBeanSerializer<getSpuBySnVendorIdAndBrandId_args>
		{
			
			public static getSpuBySnVendorIdAndBrandId_argsHelper OBJ = new getSpuBySnVendorIdAndBrandId_argsHelper();
			
			public static getSpuBySnVendorIdAndBrandId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSpuBySnVendorIdAndBrandId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSn(value);
				}
				
				
				
				
				
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
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSource(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSpuBySnVendorIdAndBrandId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSn() != null) {
					
					oprot.WriteFieldBegin("sn");
					oprot.WriteString(structs.GetSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sn can not be null!");
				}
				
				
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
				
				
				if(structs.GetSource() != null) {
					
					oprot.WriteFieldBegin("source");
					oprot.WriteI32((int)structs.GetSource()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSpuBySnVendorIdAndBrandId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVendorImageRelationshipTaskStatus_argsHelper : TBeanSerializer<getVendorImageRelationshipTaskStatus_args>
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
							
							long elem0;
							elem0 = iprot.ReadI64(); 
							
							value.Add(elem0);
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
		
		
		
		
		public class multiGetProductSkuInfo_argsHelper : TBeanSerializer<multiGetProductSkuInfo_args>
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
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSource(value);
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
				
				
				if(structs.GetSource() != null) {
					
					oprot.WriteFieldBegin("source");
					oprot.WriteI32((int)structs.GetSource()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiGetProductSkuInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class multiGetProductSpuInfo_argsHelper : TBeanSerializer<multiGetProductSpuInfo_args>
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
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSource(value);
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
				
				
				if(structs.GetSource() != null) {
					
					oprot.WriteFieldBegin("source");
					oprot.WriteI32((int)structs.GetSource()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiGetProductSpuInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class saveVendorProductSizeTableRelationship_argsHelper : TBeanSerializer<saveVendorProductSizeTableRelationship_args>
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
		
		
		
		
		public class submitProducts_argsHelper : TBeanSerializer<submitProducts_args>
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
		
		
		
		
		public class uploadAndBindVendorProductImage_argsHelper : TBeanSerializer<uploadAndBindVendorProductImage_args>
		{
			
			public static uploadAndBindVendorProductImage_argsHelper OBJ = new uploadAndBindVendorProductImage_argsHelper();
			
			public static uploadAndBindVendorProductImage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadAndBindVendorProductImage_args structs, Protocol iprot){
				
				
				
				
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
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetImg_index(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImg_content(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetGroup_sn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadAndBindVendorProductImage_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetImg_index() != null) {
					
					oprot.WriteFieldBegin("img_index");
					oprot.WriteI32((int)structs.GetImg_index()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("img_index can not be null!");
				}
				
				
				if(structs.GetImg_content() != null) {
					
					oprot.WriteFieldBegin("img_content");
					oprot.WriteString(structs.GetImg_content());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("img_content can not be null!");
				}
				
				
				if(structs.GetGroup_sn() != null) {
					
					oprot.WriteFieldBegin("group_sn");
					oprot.WriteString(structs.GetGroup_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadAndBindVendorProductImage_args bean){
				
				
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
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
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
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
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
		
		
		
		
		public class uploadVendorProductImage_argsHelper : TBeanSerializer<uploadVendorProductImage_args>
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
							
							int _key0;
							string _val0;
							_key0 = iprot.ReadI32(); 
							
							_val0 = iprot.ReadString();
							
							value.Add(_key0, _val0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetProduct_image_map(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetGroup_sn(value);
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
				
				
				if(structs.GetGroup_sn() != null) {
					
					oprot.WriteFieldBegin("group_sn");
					oprot.WriteString(structs.GetGroup_sn());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadVendorProductImage_args bean){
				
				
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
					
					vipapis.product.AppendSkuResponse value;
					
					value = new vipapis.product.AppendSkuResponse();
					vipapis.product.AppendSkuResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(appendSkus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.AppendSkuResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(appendSkus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class autoBindVendorProductSizeTableRelationship_resultHelper : TBeanSerializer<autoBindVendorProductSizeTableRelationship_result>
		{
			
			public static autoBindVendorProductSizeTableRelationship_resultHelper OBJ = new autoBindVendorProductSizeTableRelationship_resultHelper();
			
			public static autoBindVendorProductSizeTableRelationship_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(autoBindVendorProductSizeTableRelationship_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.SaveVSpuSizeTableRelationResponse value;
					
					value = new vipapis.product.SaveVSpuSizeTableRelationResponse();
					vipapis.product.SaveVSpuSizeTableRelationResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(autoBindVendorProductSizeTableRelationship_result structs, Protocol oprot){
				
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
			
			
			public void Validate(autoBindVendorProductSizeTableRelationship_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchBindVendorProductImages_resultHelper : TBeanSerializer<batchBindVendorProductImages_result>
		{
			
			public static batchBindVendorProductImages_resultHelper OBJ = new batchBindVendorProductImages_resultHelper();
			
			public static batchBindVendorProductImages_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchBindVendorProductImages_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchBindVendorProductImages_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchBindVendorProductImages_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class batchUploadAndBindVendorProductImage_resultHelper : TBeanSerializer<batchUploadAndBindVendorProductImage_result>
		{
			
			public static batchUploadAndBindVendorProductImage_resultHelper OBJ = new batchUploadAndBindVendorProductImage_resultHelper();
			
			public static batchUploadAndBindVendorProductImage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(batchUploadAndBindVendorProductImage_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.BatchUploadAndBindImageResult value;
					
					value = new vipapis.product.BatchUploadAndBindImageResult();
					vipapis.product.BatchUploadAndBindImageResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(batchUploadAndBindVendorProductImage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.BatchUploadAndBindImageResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(batchUploadAndBindVendorProductImage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelProductSubmission_resultHelper : TBeanSerializer<cancelProductSubmission_result>
		{
			
			public static cancelProductSubmission_resultHelper OBJ = new cancelProductSubmission_resultHelper();
			
			public static cancelProductSubmission_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelProductSubmission_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.product.CancelSubmissionResult> value;
					
					value = new List<vipapis.product.CancelSubmissionResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.CancelSubmissionResult elem0;
							
							elem0 = new vipapis.product.CancelSubmissionResult();
							vipapis.product.CancelSubmissionResultHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(cancelProductSubmission_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.CancelSubmissionResult _item0 in structs.GetSuccess()){
						
						
						vipapis.product.CancelSubmissionResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelProductSubmission_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createProduct_resultHelper : TBeanSerializer<createProduct_result>
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
		
		
		
		
		public class createProductForMultiColor_resultHelper : TBeanSerializer<createProductForMultiColor_result>
		{
			
			public static createProductForMultiColor_resultHelper OBJ = new createProductForMultiColor_resultHelper();
			
			public static createProductForMultiColor_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createProductForMultiColor_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.product.ProductForMultiColorResponse> value;
					
					value = new List<vipapis.product.ProductForMultiColorResponse>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.product.ProductForMultiColorResponse elem0;
							
							elem0 = new vipapis.product.ProductForMultiColorResponse();
							vipapis.product.ProductForMultiColorResponseHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(createProductForMultiColor_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.product.ProductForMultiColorResponse _item0 in structs.GetSuccess()){
						
						
						vipapis.product.ProductForMultiColorResponseHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createProductForMultiColor_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteVendorImageRelationship_resultHelper : TBeanSerializer<deleteVendorImageRelationship_result>
		{
			
			public static deleteVendorImageRelationship_resultHelper OBJ = new deleteVendorImageRelationship_resultHelper();
			
			public static deleteVendorImageRelationship_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteVendorImageRelationship_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteVendorImageRelationship_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteVendorImageRelationship_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteVendorProductSizeTableRelationship_resultHelper : TBeanSerializer<deleteVendorProductSizeTableRelationship_result>
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
		
		
		
		
		public class editProduct_resultHelper : TBeanSerializer<editProduct_result>
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
		
		
		
		
		public class editProductForMultiColor_resultHelper : TBeanSerializer<editProductForMultiColor_result>
		{
			
			public static editProductForMultiColor_resultHelper OBJ = new editProductForMultiColor_resultHelper();
			
			public static editProductForMultiColor_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editProductForMultiColor_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.ProductForMultiColorResponse value;
					
					value = new vipapis.product.ProductForMultiColorResponse();
					vipapis.product.ProductForMultiColorResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editProductForMultiColor_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.ProductForMultiColorResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editProductForMultiColor_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductPreviewData_resultHelper : TBeanSerializer<getProductPreviewData_result>
		{
			
			public static getProductPreviewData_resultHelper OBJ = new getProductPreviewData_resultHelper();
			
			public static getProductPreviewData_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductPreviewData_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductPreviewData_result structs, Protocol oprot){
				
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
			
			
			public void Validate(getProductPreviewData_result bean){
				
				
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
		
		
		
		
		public class getRealVendorSkuByBarcode_resultHelper : TBeanSerializer<getRealVendorSkuByBarcode_result>
		{
			
			public static getRealVendorSkuByBarcode_resultHelper OBJ = new getRealVendorSkuByBarcode_resultHelper();
			
			public static getRealVendorSkuByBarcode_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRealVendorSkuByBarcode_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.ProductSkuInfo value;
					
					value = new vipapis.product.ProductSkuInfo();
					vipapis.product.ProductSkuInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRealVendorSkuByBarcode_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.ProductSkuInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRealVendorSkuByBarcode_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSpuBySnVendorIdAndBrandId_resultHelper : TBeanSerializer<getSpuBySnVendorIdAndBrandId_result>
		{
			
			public static getSpuBySnVendorIdAndBrandId_resultHelper OBJ = new getSpuBySnVendorIdAndBrandId_resultHelper();
			
			public static getSpuBySnVendorIdAndBrandId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSpuBySnVendorIdAndBrandId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.ProductSpuInfo value;
					
					value = new vipapis.product.ProductSpuInfo();
					vipapis.product.ProductSpuInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSpuBySnVendorIdAndBrandId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.ProductSpuInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSpuBySnVendorIdAndBrandId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVendorImageRelationshipTaskStatus_resultHelper : TBeanSerializer<getVendorImageRelationshipTaskStatus_result>
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
		
		
		
		
		public class multiGetProductSkuInfo_resultHelper : TBeanSerializer<multiGetProductSkuInfo_result>
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
		
		
		
		
		public class multiGetProductSpuInfo_resultHelper : TBeanSerializer<multiGetProductSpuInfo_result>
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
		
		
		
		
		public class saveVendorProductSizeTableRelationship_resultHelper : TBeanSerializer<saveVendorProductSizeTableRelationship_result>
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
		
		
		
		
		public class submitProducts_resultHelper : TBeanSerializer<submitProducts_result>
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
		
		
		
		
		public class uploadAndBindVendorProductImage_resultHelper : TBeanSerializer<uploadAndBindVendorProductImage_result>
		{
			
			public static uploadAndBindVendorProductImage_resultHelper OBJ = new uploadAndBindVendorProductImage_resultHelper();
			
			public static uploadAndBindVendorProductImage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadAndBindVendorProductImage_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.product.UploadAndBindImageResult value;
					
					value = new vipapis.product.UploadAndBindImageResult();
					vipapis.product.UploadAndBindImageResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadAndBindVendorProductImage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.UploadAndBindImageResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadAndBindVendorProductImage_result bean){
				
				
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
					
					vipapis.product.ImageInfo value;
					
					value = new vipapis.product.ImageInfo();
					vipapis.product.ImageInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadImage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.product.ImageInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadImage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadVendorProductImage_resultHelper : TBeanSerializer<uploadVendorProductImage_result>
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
			
			
			
			public vipapis.product.AppendSkuResponse appendSkus(int vendor_id_,string sn_,int brand_id_,List<vipapis.product.CreateSkuItem> sku_item_list_) {
				
				send_appendSkus(vendor_id_,sn_,brand_id_,sku_item_list_);
				return recv_appendSkus(); 
				
			}
			
			
			private void send_appendSkus(int vendor_id_,string sn_,int brand_id_,List<vipapis.product.CreateSkuItem> sku_item_list_){
				
				InitInvocation("appendSkus");
				
				appendSkus_args args = new appendSkus_args();
				args.SetVendor_id(vendor_id_);
				args.SetSn(sn_);
				args.SetBrand_id(brand_id_);
				args.SetSku_item_list(sku_item_list_);
				
				SendBase(args, appendSkus_argsHelper.getInstance());
			}
			
			
			private vipapis.product.AppendSkuResponse recv_appendSkus(){
				
				appendSkus_result result = new appendSkus_result();
				ReceiveBase(result, appendSkus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.SaveVSpuSizeTableRelationResponse autoBindVendorProductSizeTableRelationship(int vendor_id_,int brand_id_,string sn_,int sizetable_tpl_id_) {
				
				send_autoBindVendorProductSizeTableRelationship(vendor_id_,brand_id_,sn_,sizetable_tpl_id_);
				return recv_autoBindVendorProductSizeTableRelationship(); 
				
			}
			
			
			private void send_autoBindVendorProductSizeTableRelationship(int vendor_id_,int brand_id_,string sn_,int sizetable_tpl_id_){
				
				InitInvocation("autoBindVendorProductSizeTableRelationship");
				
				autoBindVendorProductSizeTableRelationship_args args = new autoBindVendorProductSizeTableRelationship_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetSizetable_tpl_id(sizetable_tpl_id_);
				
				SendBase(args, autoBindVendorProductSizeTableRelationship_argsHelper.getInstance());
			}
			
			
			private vipapis.product.SaveVSpuSizeTableRelationResponse recv_autoBindVendorProductSizeTableRelationship(){
				
				autoBindVendorProductSizeTableRelationship_result result = new autoBindVendorProductSizeTableRelationship_result();
				ReceiveBase(result, autoBindVendorProductSizeTableRelationship_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void batchBindVendorProductImages(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, string> url_map_,string group_sn_) {
				
				send_batchBindVendorProductImages(vendor_id_,brand_id_,sn_,url_map_,group_sn_);
				recv_batchBindVendorProductImages();
				
			}
			
			
			private void send_batchBindVendorProductImages(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, string> url_map_,string group_sn_){
				
				InitInvocation("batchBindVendorProductImages");
				
				batchBindVendorProductImages_args args = new batchBindVendorProductImages_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetUrl_map(url_map_);
				args.SetGroup_sn(group_sn_);
				
				SendBase(args, batchBindVendorProductImages_argsHelper.getInstance());
			}
			
			
			private void recv_batchBindVendorProductImages(){
				
				batchBindVendorProductImages_result result = new batchBindVendorProductImages_result();
				ReceiveBase(result, batchBindVendorProductImages_resultHelper.getInstance());
				
				
			}
			
			
			public vipapis.product.BatchUploadAndBindImageResult batchUploadAndBindVendorProductImage(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, string> product_image_map_,string group_sn_) {
				
				send_batchUploadAndBindVendorProductImage(vendor_id_,brand_id_,sn_,product_image_map_,group_sn_);
				return recv_batchUploadAndBindVendorProductImage(); 
				
			}
			
			
			private void send_batchUploadAndBindVendorProductImage(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, string> product_image_map_,string group_sn_){
				
				InitInvocation("batchUploadAndBindVendorProductImage");
				
				batchUploadAndBindVendorProductImage_args args = new batchUploadAndBindVendorProductImage_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetProduct_image_map(product_image_map_);
				args.SetGroup_sn(group_sn_);
				
				SendBase(args, batchUploadAndBindVendorProductImage_argsHelper.getInstance());
			}
			
			
			private vipapis.product.BatchUploadAndBindImageResult recv_batchUploadAndBindVendorProductImage(){
				
				batchUploadAndBindVendorProductImage_result result = new batchUploadAndBindVendorProductImage_result();
				ReceiveBase(result, batchUploadAndBindVendorProductImage_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.product.CancelSubmissionResult> cancelProductSubmission(int vendor_id_,List<vipapis.product.VendorProductSN> snList_) {
				
				send_cancelProductSubmission(vendor_id_,snList_);
				return recv_cancelProductSubmission(); 
				
			}
			
			
			private void send_cancelProductSubmission(int vendor_id_,List<vipapis.product.VendorProductSN> snList_){
				
				InitInvocation("cancelProductSubmission");
				
				cancelProductSubmission_args args = new cancelProductSubmission_args();
				args.SetVendor_id(vendor_id_);
				args.SetSnList(snList_);
				
				SendBase(args, cancelProductSubmission_argsHelper.getInstance());
			}
			
			
			private List<vipapis.product.CancelSubmissionResult> recv_cancelProductSubmission(){
				
				cancelProductSubmission_result result = new cancelProductSubmission_result();
				ReceiveBase(result, cancelProductSubmission_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.VendorProductResponse createProduct(int vendor_id_,List<vipapis.product.CreateProductItem> vendor_products_) {
				
				send_createProduct(vendor_id_,vendor_products_);
				return recv_createProduct(); 
				
			}
			
			
			private void send_createProduct(int vendor_id_,List<vipapis.product.CreateProductItem> vendor_products_){
				
				InitInvocation("createProduct");
				
				createProduct_args args = new createProduct_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_products(vendor_products_);
				
				SendBase(args, createProduct_argsHelper.getInstance());
			}
			
			
			private vipapis.product.VendorProductResponse recv_createProduct(){
				
				createProduct_result result = new createProduct_result();
				ReceiveBase(result, createProduct_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.product.ProductForMultiColorResponse> createProductForMultiColor(int vendor_id_,List<vipapis.product.CreateSpuItem> spu_item_list_) {
				
				send_createProductForMultiColor(vendor_id_,spu_item_list_);
				return recv_createProductForMultiColor(); 
				
			}
			
			
			private void send_createProductForMultiColor(int vendor_id_,List<vipapis.product.CreateSpuItem> spu_item_list_){
				
				InitInvocation("createProductForMultiColor");
				
				createProductForMultiColor_args args = new createProductForMultiColor_args();
				args.SetVendor_id(vendor_id_);
				args.SetSpu_item_list(spu_item_list_);
				
				SendBase(args, createProductForMultiColor_argsHelper.getInstance());
			}
			
			
			private List<vipapis.product.ProductForMultiColorResponse> recv_createProductForMultiColor(){
				
				createProductForMultiColor_result result = new createProductForMultiColor_result();
				ReceiveBase(result, createProductForMultiColor_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public bool? deleteVendorImageRelationship(int vendor_id_,int brand_id_,string sn_,List<int?> img_index_list_,string group_sn_) {
				
				send_deleteVendorImageRelationship(vendor_id_,brand_id_,sn_,img_index_list_,group_sn_);
				return recv_deleteVendorImageRelationship(); 
				
			}
			
			
			private void send_deleteVendorImageRelationship(int vendor_id_,int brand_id_,string sn_,List<int?> img_index_list_,string group_sn_){
				
				InitInvocation("deleteVendorImageRelationship");
				
				deleteVendorImageRelationship_args args = new deleteVendorImageRelationship_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetImg_index_list(img_index_list_);
				args.SetGroup_sn(group_sn_);
				
				SendBase(args, deleteVendorImageRelationship_argsHelper.getInstance());
			}
			
			
			private bool? recv_deleteVendorImageRelationship(){
				
				deleteVendorImageRelationship_result result = new deleteVendorImageRelationship_result();
				ReceiveBase(result, deleteVendorImageRelationship_resultHelper.getInstance());
				
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
			
			
			public vipapis.product.VendorProductResponse editProduct(int vendor_id_,List<vipapis.product.EditProductItem> vendor_products_) {
				
				send_editProduct(vendor_id_,vendor_products_);
				return recv_editProduct(); 
				
			}
			
			
			private void send_editProduct(int vendor_id_,List<vipapis.product.EditProductItem> vendor_products_){
				
				InitInvocation("editProduct");
				
				editProduct_args args = new editProduct_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_products(vendor_products_);
				
				SendBase(args, editProduct_argsHelper.getInstance());
			}
			
			
			private vipapis.product.VendorProductResponse recv_editProduct(){
				
				editProduct_result result = new editProduct_result();
				ReceiveBase(result, editProduct_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.ProductForMultiColorResponse editProductForMultiColor(int vendor_id_,string sn_,int brand_id_,vipapis.product.EditSpuItem edit_spu_item_list_) {
				
				send_editProductForMultiColor(vendor_id_,sn_,brand_id_,edit_spu_item_list_);
				return recv_editProductForMultiColor(); 
				
			}
			
			
			private void send_editProductForMultiColor(int vendor_id_,string sn_,int brand_id_,vipapis.product.EditSpuItem edit_spu_item_list_){
				
				InitInvocation("editProductForMultiColor");
				
				editProductForMultiColor_args args = new editProductForMultiColor_args();
				args.SetVendor_id(vendor_id_);
				args.SetSn(sn_);
				args.SetBrand_id(brand_id_);
				args.SetEdit_spu_item_list(edit_spu_item_list_);
				
				SendBase(args, editProductForMultiColor_argsHelper.getInstance());
			}
			
			
			private vipapis.product.ProductForMultiColorResponse recv_editProductForMultiColor(){
				
				editProductForMultiColor_result result = new editProductForMultiColor_result();
				ReceiveBase(result, editProductForMultiColor_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string getProductPreviewData(int vendor_id_,int brand_id_,string sn_,string group_sn_) {
				
				send_getProductPreviewData(vendor_id_,brand_id_,sn_,group_sn_);
				return recv_getProductPreviewData(); 
				
			}
			
			
			private void send_getProductPreviewData(int vendor_id_,int brand_id_,string sn_,string group_sn_){
				
				InitInvocation("getProductPreviewData");
				
				getProductPreviewData_args args = new getProductPreviewData_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetGroup_sn(group_sn_);
				
				SendBase(args, getProductPreviewData_argsHelper.getInstance());
			}
			
			
			private string recv_getProductPreviewData(){
				
				getProductPreviewData_result result = new getProductPreviewData_result();
				ReceiveBase(result, getProductPreviewData_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string getProductPreviewUrl(int vendor_id_,int brand_id_,string sn_,string group_sn_) {
				
				send_getProductPreviewUrl(vendor_id_,brand_id_,sn_,group_sn_);
				return recv_getProductPreviewUrl(); 
				
			}
			
			
			private void send_getProductPreviewUrl(int vendor_id_,int brand_id_,string sn_,string group_sn_){
				
				InitInvocation("getProductPreviewUrl");
				
				getProductPreviewUrl_args args = new getProductPreviewUrl_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetGroup_sn(group_sn_);
				
				SendBase(args, getProductPreviewUrl_argsHelper.getInstance());
			}
			
			
			private string recv_getProductPreviewUrl(){
				
				getProductPreviewUrl_result result = new getProductPreviewUrl_result();
				ReceiveBase(result, getProductPreviewUrl_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.ProductSkuInfo getRealVendorSkuByBarcode(int vendor_id_,string barcode_,int? source_) {
				
				send_getRealVendorSkuByBarcode(vendor_id_,barcode_,source_);
				return recv_getRealVendorSkuByBarcode(); 
				
			}
			
			
			private void send_getRealVendorSkuByBarcode(int vendor_id_,string barcode_,int? source_){
				
				InitInvocation("getRealVendorSkuByBarcode");
				
				getRealVendorSkuByBarcode_args args = new getRealVendorSkuByBarcode_args();
				args.SetVendor_id(vendor_id_);
				args.SetBarcode(barcode_);
				args.SetSource(source_);
				
				SendBase(args, getRealVendorSkuByBarcode_argsHelper.getInstance());
			}
			
			
			private vipapis.product.ProductSkuInfo recv_getRealVendorSkuByBarcode(){
				
				getRealVendorSkuByBarcode_result result = new getRealVendorSkuByBarcode_result();
				ReceiveBase(result, getRealVendorSkuByBarcode_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.ProductSpuInfo getSpuBySnVendorIdAndBrandId(string sn_,int vendor_id_,int brand_id_,int? source_) {
				
				send_getSpuBySnVendorIdAndBrandId(sn_,vendor_id_,brand_id_,source_);
				return recv_getSpuBySnVendorIdAndBrandId(); 
				
			}
			
			
			private void send_getSpuBySnVendorIdAndBrandId(string sn_,int vendor_id_,int brand_id_,int? source_){
				
				InitInvocation("getSpuBySnVendorIdAndBrandId");
				
				getSpuBySnVendorIdAndBrandId_args args = new getSpuBySnVendorIdAndBrandId_args();
				args.SetSn(sn_);
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSource(source_);
				
				SendBase(args, getSpuBySnVendorIdAndBrandId_argsHelper.getInstance());
			}
			
			
			private vipapis.product.ProductSpuInfo recv_getSpuBySnVendorIdAndBrandId(){
				
				getSpuBySnVendorIdAndBrandId_result result = new getSpuBySnVendorIdAndBrandId_result();
				ReceiveBase(result, getSpuBySnVendorIdAndBrandId_resultHelper.getInstance());
				
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
			
			
			public vipapis.product.MultiGetProductSkuResponse multiGetProductSkuInfo(int vendor_id_,string barcode_,int? brand_id_,int? category_id_,string sn_,int? page_,int? limit_,int? source_) {
				
				send_multiGetProductSkuInfo(vendor_id_,barcode_,brand_id_,category_id_,sn_,page_,limit_,source_);
				return recv_multiGetProductSkuInfo(); 
				
			}
			
			
			private void send_multiGetProductSkuInfo(int vendor_id_,string barcode_,int? brand_id_,int? category_id_,string sn_,int? page_,int? limit_,int? source_){
				
				InitInvocation("multiGetProductSkuInfo");
				
				multiGetProductSkuInfo_args args = new multiGetProductSkuInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetBarcode(barcode_);
				args.SetBrand_id(brand_id_);
				args.SetCategory_id(category_id_);
				args.SetSn(sn_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				args.SetSource(source_);
				
				SendBase(args, multiGetProductSkuInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.product.MultiGetProductSkuResponse recv_multiGetProductSkuInfo(){
				
				multiGetProductSkuInfo_result result = new multiGetProductSkuInfo_result();
				ReceiveBase(result, multiGetProductSkuInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.MultiGetProductSpuResponse multiGetProductSpuInfo(int vendor_id_,int? brand_id_,int? category_id_,string sn_,vipapis.product.ProductStatus? status_,int? page_,int? limit_,int? source_) {
				
				send_multiGetProductSpuInfo(vendor_id_,brand_id_,category_id_,sn_,status_,page_,limit_,source_);
				return recv_multiGetProductSpuInfo(); 
				
			}
			
			
			private void send_multiGetProductSpuInfo(int vendor_id_,int? brand_id_,int? category_id_,string sn_,vipapis.product.ProductStatus? status_,int? page_,int? limit_,int? source_){
				
				InitInvocation("multiGetProductSpuInfo");
				
				multiGetProductSpuInfo_args args = new multiGetProductSpuInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetCategory_id(category_id_);
				args.SetSn(sn_);
				args.SetStatus(status_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				args.SetSource(source_);
				
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
			
			
			public vipapis.product.UploadAndBindImageResult uploadAndBindVendorProductImage(int vendor_id_,int brand_id_,string sn_,int img_index_,string img_content_,string group_sn_) {
				
				send_uploadAndBindVendorProductImage(vendor_id_,brand_id_,sn_,img_index_,img_content_,group_sn_);
				return recv_uploadAndBindVendorProductImage(); 
				
			}
			
			
			private void send_uploadAndBindVendorProductImage(int vendor_id_,int brand_id_,string sn_,int img_index_,string img_content_,string group_sn_){
				
				InitInvocation("uploadAndBindVendorProductImage");
				
				uploadAndBindVendorProductImage_args args = new uploadAndBindVendorProductImage_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetImg_index(img_index_);
				args.SetImg_content(img_content_);
				args.SetGroup_sn(group_sn_);
				
				SendBase(args, uploadAndBindVendorProductImage_argsHelper.getInstance());
			}
			
			
			private vipapis.product.UploadAndBindImageResult recv_uploadAndBindVendorProductImage(){
				
				uploadAndBindVendorProductImage_result result = new uploadAndBindVendorProductImage_result();
				ReceiveBase(result, uploadAndBindVendorProductImage_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.ImageInfo uploadImage(int vendor_id_,string file_name_,string is_override_,string img_content_) {
				
				send_uploadImage(vendor_id_,file_name_,is_override_,img_content_);
				return recv_uploadImage(); 
				
			}
			
			
			private void send_uploadImage(int vendor_id_,string file_name_,string is_override_,string img_content_){
				
				InitInvocation("uploadImage");
				
				uploadImage_args args = new uploadImage_args();
				args.SetVendor_id(vendor_id_);
				args.SetFile_name(file_name_);
				args.SetIs_override(is_override_);
				args.SetImg_content(img_content_);
				
				SendBase(args, uploadImage_argsHelper.getInstance());
			}
			
			
			private vipapis.product.ImageInfo recv_uploadImage(){
				
				uploadImage_result result = new uploadImage_result();
				ReceiveBase(result, uploadImage_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.product.ImageUploadResult uploadVendorProductImage(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, string> product_image_map_,string group_sn_) {
				
				send_uploadVendorProductImage(vendor_id_,brand_id_,sn_,product_image_map_,group_sn_);
				return recv_uploadVendorProductImage(); 
				
			}
			
			
			private void send_uploadVendorProductImage(int vendor_id_,int brand_id_,string sn_,Dictionary<int?, string> product_image_map_,string group_sn_){
				
				InitInvocation("uploadVendorProductImage");
				
				uploadVendorProductImage_args args = new uploadVendorProductImage_args();
				args.SetVendor_id(vendor_id_);
				args.SetBrand_id(brand_id_);
				args.SetSn(sn_);
				args.SetProduct_image_map(product_image_map_);
				args.SetGroup_sn(group_sn_);
				
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