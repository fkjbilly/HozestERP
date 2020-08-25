using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderExchangeGoodsVO {
		
		///<summary>
		/// 主键ID
		///</summary>
		
		private long? orderExchangeGoodsId_;
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 换货申请单单号
		///</summary>
		
		private long? applyId_;
		
		///<summary>
		/// 退货原因id
		///</summary>
		
		private int? reasonId_;
		
		///<summary>
		/// 对应新表 order_exchange的id
		///</summary>
		
		private long? orderExchangeTransportId_;
		
		///<summary>
		/// 档期、专场的SKU id(对应m_size_id，订单DB字段名为size_id)
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 档期、专场商品id(对应m_id，订单DB字段名为goods_id)
		///</summary>
		
		private long? merchandiseNo_;
		
		///<summary>
		/// 档期、专场的id(对应原brand_id)
		///</summary>
		
		private long? salesNo_;
		
		///<summary>
		/// 对应m_size.sn
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string goodsName_;
		
		///<summary>
		/// 档期、专场名称(原brand_name)
		///</summary>
		
		private string salesName_;
		
		///<summary>
		/// m_size名称
		///</summary>
		
		private string sizeName_;
		
		///<summary>
		/// 换货商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 档期、专场的SKU id(对应m_size_id，订单DB字段名为size_id)
		///</summary>
		
		private long? newMerItemNo_;
		
		///<summary>
		/// 档期、专场商品id(对应m_id，订单DB字段名为goods_id)
		///</summary>
		
		private long? newMerchandiseNo_;
		
		///<summary>
		/// 档期、专场的id(对应原brand_id)
		///</summary>
		
		private long? newSalesNo_;
		
		///<summary>
		/// 商品价格
		///</summary>
		
		private string sellPrice_;
		
		///<summary>
		/// 订单商品类型
		///</summary>
		
		private string goodsType_;
		
		///<summary>
		/// 0:已申请未退回；1：有申请已匹配 2:未申请却退回
		///</summary>
		
		private string goodsBackFlag_;
		
		///<summary>
		/// 收到包裹时间
		///</summary>
		
		private long? backTime_;
		
		///<summary>
		/// 库存来源1:goods,2:cis
		///</summary>
		
		private byte? stockSource_;
		
		///<summary>
		/// 库存状态：0 待扣库存 1 扣库存中 2 扣库存成功 3 扣库存失败 4 库存已释放
		///</summary>
		
		private string stockState_;
		
		///<summary>
		/// 数据是否删除，0：未被删除，1：已删除
		///</summary>
		
		private byte? isDeleted_;
		
		///<summary>
		/// 添加时间
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private long? updateTime_;
		
		///<summary>
		/// 新商品m_size名称
		///</summary>
		
		private string newSizeName_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 价格ID
		///</summary>
		
		private long? priceId_;
		
		///<summary>
		/// 商品SKU
		///</summary>
		
		private long? vSkuId_;
		
		///<summary>
		/// 换入商品priceId
		///</summary>
		
		private long? newPriceId_;
		
		///<summary>
		/// 换入商品SKU
		///</summary>
		
		private long? newVSkuId_;
		
		///<summary>
		/// 新商品条码
		///</summary>
		
		private string newSn_;
		
		///<summary>
		/// 换货商品数量
		///</summary>
		
		private string newAmount_;
		
		///<summary>
		/// 库存占用号
		///</summary>
		
		private string posNo_;
		
		///<summary>
		/// 价格时间(十位秒级时间戳)
		///</summary>
		
		private long? priceTime_;
		
		///<summary>
		/// 换入商品价格时间priceTime(十位秒级时间戳)
		///</summary>
		
		private long? newPriceTime_;
		
		///<summary>
		/// 整饰标识（0：无需整饰；1：等待整饰；2：已整饰）
		///</summary>
		
		private int? decorateFlag_;
		
		public long? GetOrderExchangeGoodsId(){
			return this.orderExchangeGoodsId_;
		}
		
		public void SetOrderExchangeGoodsId(long? value){
			this.orderExchangeGoodsId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetApplyId(){
			return this.applyId_;
		}
		
		public void SetApplyId(long? value){
			this.applyId_ = value;
		}
		public int? GetReasonId(){
			return this.reasonId_;
		}
		
		public void SetReasonId(int? value){
			this.reasonId_ = value;
		}
		public long? GetOrderExchangeTransportId(){
			return this.orderExchangeTransportId_;
		}
		
		public void SetOrderExchangeTransportId(long? value){
			this.orderExchangeTransportId_ = value;
		}
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public long? GetMerchandiseNo(){
			return this.merchandiseNo_;
		}
		
		public void SetMerchandiseNo(long? value){
			this.merchandiseNo_ = value;
		}
		public long? GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(long? value){
			this.salesNo_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		public string GetGoodsName(){
			return this.goodsName_;
		}
		
		public void SetGoodsName(string value){
			this.goodsName_ = value;
		}
		public string GetSalesName(){
			return this.salesName_;
		}
		
		public void SetSalesName(string value){
			this.salesName_ = value;
		}
		public string GetSizeName(){
			return this.sizeName_;
		}
		
		public void SetSizeName(string value){
			this.sizeName_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public long? GetNewMerItemNo(){
			return this.newMerItemNo_;
		}
		
		public void SetNewMerItemNo(long? value){
			this.newMerItemNo_ = value;
		}
		public long? GetNewMerchandiseNo(){
			return this.newMerchandiseNo_;
		}
		
		public void SetNewMerchandiseNo(long? value){
			this.newMerchandiseNo_ = value;
		}
		public long? GetNewSalesNo(){
			return this.newSalesNo_;
		}
		
		public void SetNewSalesNo(long? value){
			this.newSalesNo_ = value;
		}
		public string GetSellPrice(){
			return this.sellPrice_;
		}
		
		public void SetSellPrice(string value){
			this.sellPrice_ = value;
		}
		public string GetGoodsType(){
			return this.goodsType_;
		}
		
		public void SetGoodsType(string value){
			this.goodsType_ = value;
		}
		public string GetGoodsBackFlag(){
			return this.goodsBackFlag_;
		}
		
		public void SetGoodsBackFlag(string value){
			this.goodsBackFlag_ = value;
		}
		public long? GetBackTime(){
			return this.backTime_;
		}
		
		public void SetBackTime(long? value){
			this.backTime_ = value;
		}
		public byte? GetStockSource(){
			return this.stockSource_;
		}
		
		public void SetStockSource(byte? value){
			this.stockSource_ = value;
		}
		public string GetStockState(){
			return this.stockState_;
		}
		
		public void SetStockState(string value){
			this.stockState_ = value;
		}
		public byte? GetIsDeleted(){
			return this.isDeleted_;
		}
		
		public void SetIsDeleted(byte? value){
			this.isDeleted_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public long? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(long? value){
			this.updateTime_ = value;
		}
		public string GetNewSizeName(){
			return this.newSizeName_;
		}
		
		public void SetNewSizeName(string value){
			this.newSizeName_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public long? GetPriceId(){
			return this.priceId_;
		}
		
		public void SetPriceId(long? value){
			this.priceId_ = value;
		}
		public long? GetVSkuId(){
			return this.vSkuId_;
		}
		
		public void SetVSkuId(long? value){
			this.vSkuId_ = value;
		}
		public long? GetNewPriceId(){
			return this.newPriceId_;
		}
		
		public void SetNewPriceId(long? value){
			this.newPriceId_ = value;
		}
		public long? GetNewVSkuId(){
			return this.newVSkuId_;
		}
		
		public void SetNewVSkuId(long? value){
			this.newVSkuId_ = value;
		}
		public string GetNewSn(){
			return this.newSn_;
		}
		
		public void SetNewSn(string value){
			this.newSn_ = value;
		}
		public string GetNewAmount(){
			return this.newAmount_;
		}
		
		public void SetNewAmount(string value){
			this.newAmount_ = value;
		}
		public string GetPosNo(){
			return this.posNo_;
		}
		
		public void SetPosNo(string value){
			this.posNo_ = value;
		}
		public long? GetPriceTime(){
			return this.priceTime_;
		}
		
		public void SetPriceTime(long? value){
			this.priceTime_ = value;
		}
		public long? GetNewPriceTime(){
			return this.newPriceTime_;
		}
		
		public void SetNewPriceTime(long? value){
			this.newPriceTime_ = value;
		}
		public int? GetDecorateFlag(){
			return this.decorateFlag_;
		}
		
		public void SetDecorateFlag(int? value){
			this.decorateFlag_ = value;
		}
		
	}
	
}