using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class UploadSuccessResult {
		
		///<summary>
		/// 图片索引号,图片索引允许取值：1, 2, 3, 4, 5, 6, 7, 15, 16, 17, 18, 19, 20, 21, 22, 30,110, 111, 112, 113, 114，601-650, 651-699。<br>销售图(列表图)：5,7<br>详情图:601-650<br>美妆详情图: 651-699<br>展示图：1、2、3、4、15、16、17、18、19、20、21、22<br>透明底图：30 (透明底图只支持png格式图片，大小100K-600K)
		/// @sampleValue img_index 1
		///</summary>
		
		private int? img_index_;
		
		///<summary>
		/// 图片url
		/// @sampleValue url http://a.vpimg4.com/upload/merchandise/268892/josiny-14417742401-1_1.jpg
		///</summary>
		
		private string url_;
		
		public int? GetImg_index(){
			return this.img_index_;
		}
		
		public void SetImg_index(int? value){
			this.img_index_ = value;
		}
		public string GetUrl(){
			return this.url_;
		}
		
		public void SetUrl(string value){
			this.url_ = value;
		}
		
	}
	
}