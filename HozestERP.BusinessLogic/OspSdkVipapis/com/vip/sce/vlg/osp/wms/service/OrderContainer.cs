using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OrderContainer {
		
		///<summary>
		/// 数据唯一标识（ 海外WMS生成）
		///</summary>
		
		private string id_;
		
		///<summary>
		/// 订单号码
		///</summary>
		
		private string order_sn_;
		
		///<summary>
		/// 重量，默认单位为kg
		///</summary>
		
		private double? weight_;
		
		///<summary>
		/// 长度，默认单位为cm
		///</summary>
		
		private double? length_;
		
		///<summary>
		/// 宽度，默认单位为cm
		///</summary>
		
		private double? width_;
		
		///<summary>
		/// 高度，默认单位为cm
		///</summary>
		
		private double? height_;
		
		///<summary>
		/// 体积，默认单位为cm
		///</summary>
		
		private double? volume_;
		
		///<summary>
		/// 箱号。仓库 编码+自定义字符串（年月日+4位编码）
		///</summary>
		
		private string box_id_;
		
		///<summary>
		/// 出库时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string creat_time_;
		
		///<summary>
		/// 总箱数
		///</summary>
		
		private int? box_num_;
		
		///<summary>
		/// 命令类型(ADD:新增、MODEFIY：修改、CANCEL：取消)
		///</summary>
		
		private string cmd_type_;
		
		///<summary>
		/// 包装材料编码
		///</summary>
		
		private string material_code_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string cust_code_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 分拣码
		///</summary>
		
		private string pick_code_;
		
		///<summary>
		/// 出仓定义
		///</summary>
		
		private string out_type_;
		
		///<summary>
		/// 订单出仓通知-明细
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OrderContainerDetail> order_detail_;
		
		public string GetId(){
			return this.id_;
		}
		
		public void SetId(string value){
			this.id_ = value;
		}
		public string GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(string value){
			this.order_sn_ = value;
		}
		public double? GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(double? value){
			this.weight_ = value;
		}
		public double? GetLength(){
			return this.length_;
		}
		
		public void SetLength(double? value){
			this.length_ = value;
		}
		public double? GetWidth(){
			return this.width_;
		}
		
		public void SetWidth(double? value){
			this.width_ = value;
		}
		public double? GetHeight(){
			return this.height_;
		}
		
		public void SetHeight(double? value){
			this.height_ = value;
		}
		public double? GetVolume(){
			return this.volume_;
		}
		
		public void SetVolume(double? value){
			this.volume_ = value;
		}
		public string GetBox_id(){
			return this.box_id_;
		}
		
		public void SetBox_id(string value){
			this.box_id_ = value;
		}
		public string GetCreat_time(){
			return this.creat_time_;
		}
		
		public void SetCreat_time(string value){
			this.creat_time_ = value;
		}
		public int? GetBox_num(){
			return this.box_num_;
		}
		
		public void SetBox_num(int? value){
			this.box_num_ = value;
		}
		public string GetCmd_type(){
			return this.cmd_type_;
		}
		
		public void SetCmd_type(string value){
			this.cmd_type_ = value;
		}
		public string GetMaterial_code(){
			return this.material_code_;
		}
		
		public void SetMaterial_code(string value){
			this.material_code_ = value;
		}
		public string GetCust_code(){
			return this.cust_code_;
		}
		
		public void SetCust_code(string value){
			this.cust_code_ = value;
		}
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public string GetPick_code(){
			return this.pick_code_;
		}
		
		public void SetPick_code(string value){
			this.pick_code_ = value;
		}
		public string GetOut_type(){
			return this.out_type_;
		}
		
		public void SetOut_type(string value){
			this.out_type_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OrderContainerDetail> GetOrder_detail(){
			return this.order_detail_;
		}
		
		public void SetOrder_detail(List<com.vip.sce.vlg.osp.wms.service.OrderContainerDetail> value){
			this.order_detail_ = value;
		}
		
	}
	
}