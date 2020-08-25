using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.schedule{
	
	
	
	
	
	public class Schedule {
		
		///<summary>
		/// 档期ID
		/// @sampleValue schedule_id 204565
		///</summary>
		
		private int? schedule_id_;
		
		///<summary>
		/// 档期名
		/// @sampleValue schedule_name XXX唯品会专场
		///</summary>
		
		private string schedule_name_;
		
		///<summary>
		/// 档期上线时间(格式yyyy-MM-dd HH:mm:ss)
		/// @sampleValue start_time 2014-07-01 10:00:00
		///</summary>
		
		private string start_time_;
		
		///<summary>
		/// 档期下线时间(格式yyyy-MM-dd HH:mm:ss)
		/// @sampleValue end_time 2014-08-15 23:59:59
		///</summary>
		
		private string end_time_;
		
		///<summary>
		/// 首页大图(预售图)
		/// @sampleValue index_image http://a.vpimg1.com/upload/brand/201406/2014062718434639161.jpg
		///</summary>
		
		private string index_image_;
		
		///<summary>
		/// 首页开售预告图
		/// @sampleValue index_advance_image http://a.vpimg1.com/upload/brand/201406/2014062718434640182.jpg
		///</summary>
		
		private string index_advance_image_;
		
		///<summary>
		/// 档期LOGO
		/// @sampleValue schedule_self_logo http://a.vpimg1.com/upload/brand/201406/2014060614445262401.jpg
		///</summary>
		
		private string schedule_self_logo_;
		
		///<summary>
		/// (放在首页)导航LOGO
		/// @sampleValue logo http://a.vpimg1.com/upload/brand/201406/2014060614445237392.jpg
		///</summary>
		
		private string logo_;
		
		///<summary>
		/// 档期折扣信息
		/// @sampleValue agio 
		///</summary>
		
		private string agio_;
		
		///<summary>
		/// 品牌库编号
		/// @sampleValue brand_store_sn ["10014734"]
		///</summary>
		
		private List<string> brand_store_sn_;
		
		///<summary>
		/// 品牌中文名
		/// @sampleValue brand_name ["广汽"]
		///</summary>
		
		private List<string> brand_name_;
		
		///<summary>
		/// 品牌英文名
		/// @sampleValue brand_name_eng ["TOYOTA"]
		///</summary>
		
		private List<string> brand_name_eng_;
		
		///<summary>
		/// 品牌地址
		/// @sampleValue brand_url [""]
		///</summary>
		
		private List<string> brand_url_;
		
		///<summary>
		/// 档期对应PC端的跳转URL
		/// @sampleValue schedule_url http://www.vip.com/show-204565.html
		///</summary>
		
		private string schedule_url_;
		
		///<summary>
		/// 档期对应的观看flash
		/// @sampleValue schedule_flash 
		///</summary>
		
		private string schedule_flash_;
		
		///<summary>
		/// 档期对应移动端的跳转url
		/// @sampleValue schedule_mobile_url http://m.vip.com/brand-204565-0-0-0-1-0-1-40.html
		///</summary>
		
		private string schedule_mobile_url_;
		
		///<summary>
		/// 移动端档期图url
		/// @sampleValue mobile_image_one 
		///</summary>
		
		private string mobile_image_one_;
		
		///<summary>
		/// 移动端预售图url
		/// @sampleValue mobile_image_two 
		///</summary>
		
		private string mobile_image_two_;
		
		///<summary>
		/// 移动端开售时间(格式yyyy-MM-dd HH:mm:ss))
		/// @sampleValue mobile_show_from 2014-07-01 10:00:00
		///</summary>
		
		private string mobile_show_from_;
		
		///<summary>
		/// 移动端截止时间(格式yyyy-MM-dd HH:mm:ss))
		/// @sampleValue mobile_show_to 2014-08-15 23:59:59
		///</summary>
		
		private string mobile_show_to_;
		
		///<summary>
		/// Pc端开售时间(格式yyyy-MM-dd HH:mm:ss))
		/// @sampleValue pc_show_from 2014-07-01 10:00:00
		///</summary>
		
		private string pc_show_from_;
		
		///<summary>
		/// Pc端截至时间(格式yyyy-MM-dd HH:mm:ss))
		/// @sampleValue pc_show_to 2014-08-15 23:59:59
		///</summary>
		
		private string pc_show_to_;
		
		///<summary>
		/// 频道ID,0: 首页,1：女士,2：男士,3：儿童,4：生活,5：奢侈品,6：闪购,8：品牌夜宴,9：服饰鞋包,10：美妆,11：亲子,12：居家
		///</summary>
		
		private List<string> channels_;
		
		///<summary>
		/// 分仓代码
		/// @sampleValue warehouses VIP_NH
		///</summary>
		
		private List<string> warehouses_;
		
		public int? GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(int? value){
			this.schedule_id_ = value;
		}
		public string GetSchedule_name(){
			return this.schedule_name_;
		}
		
		public void SetSchedule_name(string value){
			this.schedule_name_ = value;
		}
		public string GetStart_time(){
			return this.start_time_;
		}
		
		public void SetStart_time(string value){
			this.start_time_ = value;
		}
		public string GetEnd_time(){
			return this.end_time_;
		}
		
		public void SetEnd_time(string value){
			this.end_time_ = value;
		}
		public string GetIndex_image(){
			return this.index_image_;
		}
		
		public void SetIndex_image(string value){
			this.index_image_ = value;
		}
		public string GetIndex_advance_image(){
			return this.index_advance_image_;
		}
		
		public void SetIndex_advance_image(string value){
			this.index_advance_image_ = value;
		}
		public string GetSchedule_self_logo(){
			return this.schedule_self_logo_;
		}
		
		public void SetSchedule_self_logo(string value){
			this.schedule_self_logo_ = value;
		}
		public string GetLogo(){
			return this.logo_;
		}
		
		public void SetLogo(string value){
			this.logo_ = value;
		}
		public string GetAgio(){
			return this.agio_;
		}
		
		public void SetAgio(string value){
			this.agio_ = value;
		}
		public List<string> GetBrand_store_sn(){
			return this.brand_store_sn_;
		}
		
		public void SetBrand_store_sn(List<string> value){
			this.brand_store_sn_ = value;
		}
		public List<string> GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(List<string> value){
			this.brand_name_ = value;
		}
		public List<string> GetBrand_name_eng(){
			return this.brand_name_eng_;
		}
		
		public void SetBrand_name_eng(List<string> value){
			this.brand_name_eng_ = value;
		}
		public List<string> GetBrand_url(){
			return this.brand_url_;
		}
		
		public void SetBrand_url(List<string> value){
			this.brand_url_ = value;
		}
		public string GetSchedule_url(){
			return this.schedule_url_;
		}
		
		public void SetSchedule_url(string value){
			this.schedule_url_ = value;
		}
		public string GetSchedule_flash(){
			return this.schedule_flash_;
		}
		
		public void SetSchedule_flash(string value){
			this.schedule_flash_ = value;
		}
		public string GetSchedule_mobile_url(){
			return this.schedule_mobile_url_;
		}
		
		public void SetSchedule_mobile_url(string value){
			this.schedule_mobile_url_ = value;
		}
		public string GetMobile_image_one(){
			return this.mobile_image_one_;
		}
		
		public void SetMobile_image_one(string value){
			this.mobile_image_one_ = value;
		}
		public string GetMobile_image_two(){
			return this.mobile_image_two_;
		}
		
		public void SetMobile_image_two(string value){
			this.mobile_image_two_ = value;
		}
		public string GetMobile_show_from(){
			return this.mobile_show_from_;
		}
		
		public void SetMobile_show_from(string value){
			this.mobile_show_from_ = value;
		}
		public string GetMobile_show_to(){
			return this.mobile_show_to_;
		}
		
		public void SetMobile_show_to(string value){
			this.mobile_show_to_ = value;
		}
		public string GetPc_show_from(){
			return this.pc_show_from_;
		}
		
		public void SetPc_show_from(string value){
			this.pc_show_from_ = value;
		}
		public string GetPc_show_to(){
			return this.pc_show_to_;
		}
		
		public void SetPc_show_to(string value){
			this.pc_show_to_ = value;
		}
		public List<string> GetChannels(){
			return this.channels_;
		}
		
		public void SetChannels(List<string> value){
			this.channels_ = value;
		}
		public List<string> GetWarehouses(){
			return this.warehouses_;
		}
		
		public void SetWarehouses(List<string> value){
			this.warehouses_ = value;
		}
		
	}
	
}