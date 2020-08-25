using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.vcloud.jit{
	
	
	public class JitDeliveryInfoServiceHelper {
		
		
		
		public class addbox_args {
			
			///<summary>
			/// 入库单号
			///</summary>
			
			private string storageNo_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendorId_;
			
			public string GetStorageNo(){
				return this.storageNo_;
			}
			
			public void SetStorageNo(string value){
				this.storageNo_ = value;
			}
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			
		}
		
		
		
		
		public class boxItem_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendorId_;
			
			///<summary>
			/// po号
			///</summary>
			
			private string poNo_;
			
			///<summary>
			/// 入库单号
			///</summary>
			
			private string storageNo_;
			
			///<summary>
			/// 供应商类型：只可传：COMMON或3PL
			///</summary>
			
			private string vendorType_;
			
			///<summary>
			/// 商品条码
			///</summary>
			
			private string barcode_;
			
			///<summary>
			/// 供应商箱号
			///</summary>
			
			private string boxNo_;
			
			///<summary>
			/// 数量
			///</summary>
			
			private int? amount_;
			
			///<summary>
			/// 商品名称
			///</summary>
			
			private string productName_;
			
			///<summary>
			/// 门店拣货单号
			///</summary>
			
			private string subPickNo_;
			
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			public string GetPoNo(){
				return this.poNo_;
			}
			
			public void SetPoNo(string value){
				this.poNo_ = value;
			}
			public string GetStorageNo(){
				return this.storageNo_;
			}
			
			public void SetStorageNo(string value){
				this.storageNo_ = value;
			}
			public string GetVendorType(){
				return this.vendorType_;
			}
			
			public void SetVendorType(string value){
				this.vendorType_ = value;
			}
			public string GetBarcode(){
				return this.barcode_;
			}
			
			public void SetBarcode(string value){
				this.barcode_ = value;
			}
			public string GetBoxNo(){
				return this.boxNo_;
			}
			
			public void SetBoxNo(string value){
				this.boxNo_ = value;
			}
			public int? GetAmount(){
				return this.amount_;
			}
			
			public void SetAmount(int? value){
				this.amount_ = value;
			}
			public string GetProductName(){
				return this.productName_;
			}
			
			public void SetProductName(string value){
				this.productName_ = value;
			}
			public string GetSubPickNo(){
				return this.subPickNo_;
			}
			
			public void SetSubPickNo(string value){
				this.subPickNo_ = value;
			}
			
		}
		
		
		
		
		public class confirmDelivery_args {
			
			///<summary>
			/// 确认出仓单请求
			///</summary>
			
			private com.vip.vop.vcloud.jit.ConfirmDeliveryRequest request_;
			
			public com.vip.vop.vcloud.jit.ConfirmDeliveryRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.vcloud.jit.ConfirmDeliveryRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class createDelivery_args {
			
			///<summary>
			/// 创建出仓单请求
			///</summary>
			
			private com.vip.vop.vcloud.jit.CreateDeliveryRequest request_;
			
			public com.vip.vop.vcloud.jit.CreateDeliveryRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.vcloud.jit.CreateDeliveryRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class deleteBoxedItem_args {
			
			///<summary>
			/// 删除装箱
			///</summary>
			
			private string boxNo_;
			
			///<summary>
			/// 条码
			///</summary>
			
			private string barcode_;
			
			///<summary>
			/// 入库单号
			///</summary>
			
			private string storageNo_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendorId_;
			
			public string GetBoxNo(){
				return this.boxNo_;
			}
			
			public void SetBoxNo(string value){
				this.boxNo_ = value;
			}
			public string GetBarcode(){
				return this.barcode_;
			}
			
			public void SetBarcode(string value){
				this.barcode_ = value;
			}
			public string GetStorageNo(){
				return this.storageNo_;
			}
			
			public void SetStorageNo(string value){
				this.storageNo_ = value;
			}
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			
		}
		
		
		
		
		public class deleteDeliveryDetail_args {
			
			///<summary>
			/// 删除出仓单导入明细请求
			///</summary>
			
			private com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequest request_;
			
			public com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class editDelivery_args {
			
			///<summary>
			/// 编辑出仓单请求
			///</summary>
			
			private com.vip.vop.vcloud.jit.EditDeliveryRequest request_;
			
			public com.vip.vop.vcloud.jit.EditDeliveryRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.vcloud.jit.EditDeliveryRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getBox_args {
			
			///<summary>
			/// 入库单号
			///</summary>
			
			private string storageNo_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendorId_;
			
			public string GetStorageNo(){
				return this.storageNo_;
			}
			
			public void SetStorageNo(string value){
				this.storageNo_ = value;
			}
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			
		}
		
		
		
		
		public class getBoxItem_args {
			
			///<summary>
			/// 送货单ID
			///</summary>
			
			private long? deliveryId_;
			
			///<summary>
			/// 箱号
			///</summary>
			
			private string boxNo_;
			
			public long? GetDeliveryId(){
				return this.deliveryId_;
			}
			
			public void SetDeliveryId(long? value){
				this.deliveryId_ = value;
			}
			public string GetBoxNo(){
				return this.boxNo_;
			}
			
			public void SetBoxNo(string value){
				this.boxNo_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryDetail_args {
			
			///<summary>
			/// 出仓详情
			///</summary>
			
			private com.vip.vop.vcloud.jit.GetDeliveryDetailRequest request_;
			
			public com.vip.vop.vcloud.jit.GetDeliveryDetailRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.vcloud.jit.GetDeliveryDetailRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryGoods_args {
			
			///<summary>
			/// 查询出仓单导入明细请求
			///</summary>
			
			private com.vip.vop.vcloud.jit.GetDeliveryGoodsRequest request_;
			
			public com.vip.vop.vcloud.jit.GetDeliveryGoodsRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.vcloud.jit.GetDeliveryGoodsRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryList_args {
			
			///<summary>
			/// 查询出仓单请求
			///</summary>
			
			private com.vip.vop.vcloud.jit.GetDeliveryListRequest request_;
			
			public com.vip.vop.vcloud.jit.GetDeliveryListRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.vcloud.jit.GetDeliveryListRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getDeliverySubPick_args {
			
			///<summary>
			/// 入库单号
			///</summary>
			
			private string storageNo_;
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendorId_;
			
			public string GetStorageNo(){
				return this.storageNo_;
			}
			
			public void SetStorageNo(string value){
				this.storageNo_ = value;
			}
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryTrace_args {
			
			///<summary>
			/// 获取运单物流信息
			///</summary>
			
			private com.vip.vop.vcloud.jit.GetDeliveryTraceRequest request_;
			
			public com.vip.vop.vcloud.jit.GetDeliveryTraceRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.vcloud.jit.GetDeliveryTraceRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class importDeliveryDetail_args {
			
			///<summary>
			/// 导入出仓明细请求
			///</summary>
			
			private com.vip.vop.vcloud.jit.ImportDeliveryDetailRequest request_;
			
			public com.vip.vop.vcloud.jit.ImportDeliveryDetailRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.vop.vcloud.jit.ImportDeliveryDetailRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class submitDelivery_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendorId_;
			
			///<summary>
			/// 送货单号
			///</summary>
			
			private string storageNo_;
			
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			public string GetStorageNo(){
				return this.storageNo_;
			}
			
			public void SetStorageNo(string value){
				this.storageNo_ = value;
			}
			
		}
		
		
		
		
		public class syncDeliveryInfo_args {
			
			
		}
		
		
		
		
		public class addbox_result {
			
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
		
		
		
		
		public class boxItem_result {
			
			
		}
		
		
		
		
		public class confirmDelivery_result {
			
			
		}
		
		
		
		
		public class createDelivery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vcloud.jit.CreateDeliveryResponse success_;
			
			public com.vip.vop.vcloud.jit.CreateDeliveryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vcloud.jit.CreateDeliveryResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deleteBoxedItem_result {
			
			
		}
		
		
		
		
		public class deleteDeliveryDetail_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.vcloud.jit.DeletedDeliveryDetail> success_;
			
			public List<com.vip.vop.vcloud.jit.DeletedDeliveryDetail> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.vop.vcloud.jit.DeletedDeliveryDetail> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class editDelivery_result {
			
			
		}
		
		
		
		
		public class getBox_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.vcloud.jit.DeliveryBox> success_;
			
			public List<com.vip.vop.vcloud.jit.DeliveryBox> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.vop.vcloud.jit.DeliveryBox> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getBoxItem_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.vcloud.jit.DeliveryDetail> success_;
			
			public List<com.vip.vop.vcloud.jit.DeliveryDetail> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.vop.vcloud.jit.DeliveryDetail> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryDetail_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vcloud.jit.GetDeliveryDetailResponse success_;
			
			public com.vip.vop.vcloud.jit.GetDeliveryDetailResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vcloud.jit.GetDeliveryDetailResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryGoods_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vcloud.jit.GetDeliveryGoodsResponse success_;
			
			public com.vip.vop.vcloud.jit.GetDeliveryGoodsResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vcloud.jit.GetDeliveryGoodsResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vcloud.jit.GetDeliveryListResponse success_;
			
			public com.vip.vop.vcloud.jit.GetDeliveryListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vcloud.jit.GetDeliveryListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getDeliverySubPick_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.vcloud.jit.DeliverySubPick> success_;
			
			public List<com.vip.vop.vcloud.jit.DeliverySubPick> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.vop.vcloud.jit.DeliverySubPick> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getDeliveryTrace_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.vcloud.jit.DeliveryTrace> success_;
			
			public List<com.vip.vop.vcloud.jit.DeliveryTrace> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.vop.vcloud.jit.DeliveryTrace> value){
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
		
		
		
		
		public class importDeliveryDetail_result {
			
			
		}
		
		
		
		
		public class submitDelivery_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vcloud.jit.SubmitDeliveryResponse success_;
			
			public com.vip.vop.vcloud.jit.SubmitDeliveryResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vcloud.jit.SubmitDeliveryResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class syncDeliveryInfo_result {
			
			
		}
		
		
		
		
		
		public class addbox_argsHelper : TBeanSerializer<addbox_args>
		{
			
			public static addbox_argsHelper OBJ = new addbox_argsHelper();
			
			public static addbox_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addbox_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorageNo(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addbox_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetStorageNo() != null) {
					
					oprot.WriteFieldBegin("storageNo");
					oprot.WriteString(structs.GetStorageNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addbox_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class boxItem_argsHelper : TBeanSerializer<boxItem_args>
		{
			
			public static boxItem_argsHelper OBJ = new boxItem_argsHelper();
			
			public static boxItem_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(boxItem_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPoNo(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorageNo(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendorType(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBarcode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBoxNo(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetAmount(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetProductName(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSubPickNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(boxItem_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				if(structs.GetPoNo() != null) {
					
					oprot.WriteFieldBegin("poNo");
					oprot.WriteString(structs.GetPoNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStorageNo() != null) {
					
					oprot.WriteFieldBegin("storageNo");
					oprot.WriteString(structs.GetStorageNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetVendorType() != null) {
					
					oprot.WriteFieldBegin("vendorType");
					oprot.WriteString(structs.GetVendorType());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBarcode() != null) {
					
					oprot.WriteFieldBegin("barcode");
					oprot.WriteString(structs.GetBarcode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBoxNo() != null) {
					
					oprot.WriteFieldBegin("boxNo");
					oprot.WriteString(structs.GetBoxNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetAmount() != null) {
					
					oprot.WriteFieldBegin("amount");
					oprot.WriteI32((int)structs.GetAmount()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetProductName() != null) {
					
					oprot.WriteFieldBegin("productName");
					oprot.WriteString(structs.GetProductName());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSubPickNo() != null) {
					
					oprot.WriteFieldBegin("subPickNo");
					oprot.WriteString(structs.GetSubPickNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(boxItem_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmDelivery_argsHelper : TBeanSerializer<confirmDelivery_args>
		{
			
			public static confirmDelivery_argsHelper OBJ = new confirmDelivery_argsHelper();
			
			public static confirmDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.ConfirmDeliveryRequest value;
					
					value = new com.vip.vop.vcloud.jit.ConfirmDeliveryRequest();
					com.vip.vop.vcloud.jit.ConfirmDeliveryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.vcloud.jit.ConfirmDeliveryRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createDelivery_argsHelper : TBeanSerializer<createDelivery_args>
		{
			
			public static createDelivery_argsHelper OBJ = new createDelivery_argsHelper();
			
			public static createDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.CreateDeliveryRequest value;
					
					value = new com.vip.vop.vcloud.jit.CreateDeliveryRequest();
					com.vip.vop.vcloud.jit.CreateDeliveryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.vcloud.jit.CreateDeliveryRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteBoxedItem_argsHelper : TBeanSerializer<deleteBoxedItem_args>
		{
			
			public static deleteBoxedItem_argsHelper OBJ = new deleteBoxedItem_argsHelper();
			
			public static deleteBoxedItem_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteBoxedItem_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBoxNo(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBarcode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorageNo(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteBoxedItem_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetBoxNo() != null) {
					
					oprot.WriteFieldBegin("boxNo");
					oprot.WriteString(structs.GetBoxNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBarcode() != null) {
					
					oprot.WriteFieldBegin("barcode");
					oprot.WriteString(structs.GetBarcode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStorageNo() != null) {
					
					oprot.WriteFieldBegin("storageNo");
					oprot.WriteString(structs.GetStorageNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteBoxedItem_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteDeliveryDetail_argsHelper : TBeanSerializer<deleteDeliveryDetail_args>
		{
			
			public static deleteDeliveryDetail_argsHelper OBJ = new deleteDeliveryDetail_argsHelper();
			
			public static deleteDeliveryDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteDeliveryDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequest value;
					
					value = new com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequest();
					com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteDeliveryDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteDeliveryDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editDelivery_argsHelper : TBeanSerializer<editDelivery_args>
		{
			
			public static editDelivery_argsHelper OBJ = new editDelivery_argsHelper();
			
			public static editDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.EditDeliveryRequest value;
					
					value = new com.vip.vop.vcloud.jit.EditDeliveryRequest();
					com.vip.vop.vcloud.jit.EditDeliveryRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.vcloud.jit.EditDeliveryRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBox_argsHelper : TBeanSerializer<getBox_args>
		{
			
			public static getBox_argsHelper OBJ = new getBox_argsHelper();
			
			public static getBox_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBox_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorageNo(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBox_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetStorageNo() != null) {
					
					oprot.WriteFieldBegin("storageNo");
					oprot.WriteString(structs.GetStorageNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBox_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBoxItem_argsHelper : TBeanSerializer<getBoxItem_args>
		{
			
			public static getBoxItem_argsHelper OBJ = new getBoxItem_argsHelper();
			
			public static getBoxItem_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBoxItem_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetDeliveryId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBoxNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBoxItem_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetDeliveryId() != null) {
					
					oprot.WriteFieldBegin("deliveryId");
					oprot.WriteI64((long)structs.GetDeliveryId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBoxNo() != null) {
					
					oprot.WriteFieldBegin("boxNo");
					oprot.WriteString(structs.GetBoxNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBoxItem_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryDetail_argsHelper : TBeanSerializer<getDeliveryDetail_args>
		{
			
			public static getDeliveryDetail_argsHelper OBJ = new getDeliveryDetail_argsHelper();
			
			public static getDeliveryDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.GetDeliveryDetailRequest value;
					
					value = new com.vip.vop.vcloud.jit.GetDeliveryDetailRequest();
					com.vip.vop.vcloud.jit.GetDeliveryDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.vcloud.jit.GetDeliveryDetailRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryGoods_argsHelper : TBeanSerializer<getDeliveryGoods_args>
		{
			
			public static getDeliveryGoods_argsHelper OBJ = new getDeliveryGoods_argsHelper();
			
			public static getDeliveryGoods_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryGoods_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.GetDeliveryGoodsRequest value;
					
					value = new com.vip.vop.vcloud.jit.GetDeliveryGoodsRequest();
					com.vip.vop.vcloud.jit.GetDeliveryGoodsRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryGoods_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.vcloud.jit.GetDeliveryGoodsRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryGoods_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryList_argsHelper : TBeanSerializer<getDeliveryList_args>
		{
			
			public static getDeliveryList_argsHelper OBJ = new getDeliveryList_argsHelper();
			
			public static getDeliveryList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.GetDeliveryListRequest value;
					
					value = new com.vip.vop.vcloud.jit.GetDeliveryListRequest();
					com.vip.vop.vcloud.jit.GetDeliveryListRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.vcloud.jit.GetDeliveryListRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliverySubPick_argsHelper : TBeanSerializer<getDeliverySubPick_args>
		{
			
			public static getDeliverySubPick_argsHelper OBJ = new getDeliverySubPick_argsHelper();
			
			public static getDeliverySubPick_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliverySubPick_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorageNo(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliverySubPick_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetStorageNo() != null) {
					
					oprot.WriteFieldBegin("storageNo");
					oprot.WriteString(structs.GetStorageNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliverySubPick_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryTrace_argsHelper : TBeanSerializer<getDeliveryTrace_args>
		{
			
			public static getDeliveryTrace_argsHelper OBJ = new getDeliveryTrace_argsHelper();
			
			public static getDeliveryTrace_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryTrace_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.GetDeliveryTraceRequest value;
					
					value = new com.vip.vop.vcloud.jit.GetDeliveryTraceRequest();
					com.vip.vop.vcloud.jit.GetDeliveryTraceRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryTrace_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.vcloud.jit.GetDeliveryTraceRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryTrace_args bean){
				
				
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
		
		
		
		
		public class importDeliveryDetail_argsHelper : TBeanSerializer<importDeliveryDetail_args>
		{
			
			public static importDeliveryDetail_argsHelper OBJ = new importDeliveryDetail_argsHelper();
			
			public static importDeliveryDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(importDeliveryDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.ImportDeliveryDetailRequest value;
					
					value = new com.vip.vop.vcloud.jit.ImportDeliveryDetailRequest();
					com.vip.vop.vcloud.jit.ImportDeliveryDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(importDeliveryDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.vop.vcloud.jit.ImportDeliveryDetailRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(importDeliveryDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class submitDelivery_argsHelper : TBeanSerializer<submitDelivery_args>
		{
			
			public static submitDelivery_argsHelper OBJ = new submitDelivery_argsHelper();
			
			public static submitDelivery_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitDelivery_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStorageNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(submitDelivery_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendorId can not be null!");
				}
				
				
				if(structs.GetStorageNo() != null) {
					
					oprot.WriteFieldBegin("storageNo");
					oprot.WriteString(structs.GetStorageNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitDelivery_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncDeliveryInfo_argsHelper : TBeanSerializer<syncDeliveryInfo_args>
		{
			
			public static syncDeliveryInfo_argsHelper OBJ = new syncDeliveryInfo_argsHelper();
			
			public static syncDeliveryInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncDeliveryInfo_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncDeliveryInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncDeliveryInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addbox_resultHelper : TBeanSerializer<addbox_result>
		{
			
			public static addbox_resultHelper OBJ = new addbox_resultHelper();
			
			public static addbox_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addbox_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addbox_result structs, Protocol oprot){
				
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
			
			
			public void Validate(addbox_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class boxItem_resultHelper : TBeanSerializer<boxItem_result>
		{
			
			public static boxItem_resultHelper OBJ = new boxItem_resultHelper();
			
			public static boxItem_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(boxItem_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(boxItem_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(boxItem_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class confirmDelivery_resultHelper : TBeanSerializer<confirmDelivery_result>
		{
			
			public static confirmDelivery_resultHelper OBJ = new confirmDelivery_resultHelper();
			
			public static confirmDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(confirmDelivery_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(confirmDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(confirmDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createDelivery_resultHelper : TBeanSerializer<createDelivery_result>
		{
			
			public static createDelivery_resultHelper OBJ = new createDelivery_resultHelper();
			
			public static createDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createDelivery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.CreateDeliveryResponse value;
					
					value = new com.vip.vop.vcloud.jit.CreateDeliveryResponse();
					com.vip.vop.vcloud.jit.CreateDeliveryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vcloud.jit.CreateDeliveryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteBoxedItem_resultHelper : TBeanSerializer<deleteBoxedItem_result>
		{
			
			public static deleteBoxedItem_resultHelper OBJ = new deleteBoxedItem_resultHelper();
			
			public static deleteBoxedItem_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteBoxedItem_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteBoxedItem_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteBoxedItem_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteDeliveryDetail_resultHelper : TBeanSerializer<deleteDeliveryDetail_result>
		{
			
			public static deleteDeliveryDetail_resultHelper OBJ = new deleteDeliveryDetail_resultHelper();
			
			public static deleteDeliveryDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteDeliveryDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.vcloud.jit.DeletedDeliveryDetail> value;
					
					value = new List<com.vip.vop.vcloud.jit.DeletedDeliveryDetail>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.vcloud.jit.DeletedDeliveryDetail elem0;
							
							elem0 = new com.vip.vop.vcloud.jit.DeletedDeliveryDetail();
							com.vip.vop.vcloud.jit.DeletedDeliveryDetailHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(deleteDeliveryDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.vcloud.jit.DeletedDeliveryDetail _item0 in structs.GetSuccess()){
						
						
						com.vip.vop.vcloud.jit.DeletedDeliveryDetailHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteDeliveryDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class editDelivery_resultHelper : TBeanSerializer<editDelivery_result>
		{
			
			public static editDelivery_resultHelper OBJ = new editDelivery_resultHelper();
			
			public static editDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(editDelivery_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(editDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(editDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBox_resultHelper : TBeanSerializer<getBox_result>
		{
			
			public static getBox_resultHelper OBJ = new getBox_resultHelper();
			
			public static getBox_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBox_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.vcloud.jit.DeliveryBox> value;
					
					value = new List<com.vip.vop.vcloud.jit.DeliveryBox>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.vcloud.jit.DeliveryBox elem1;
							
							elem1 = new com.vip.vop.vcloud.jit.DeliveryBox();
							com.vip.vop.vcloud.jit.DeliveryBoxHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getBox_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.vcloud.jit.DeliveryBox _item0 in structs.GetSuccess()){
						
						
						com.vip.vop.vcloud.jit.DeliveryBoxHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBox_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBoxItem_resultHelper : TBeanSerializer<getBoxItem_result>
		{
			
			public static getBoxItem_resultHelper OBJ = new getBoxItem_resultHelper();
			
			public static getBoxItem_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBoxItem_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.vcloud.jit.DeliveryDetail> value;
					
					value = new List<com.vip.vop.vcloud.jit.DeliveryDetail>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.vcloud.jit.DeliveryDetail elem1;
							
							elem1 = new com.vip.vop.vcloud.jit.DeliveryDetail();
							com.vip.vop.vcloud.jit.DeliveryDetailHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getBoxItem_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.vcloud.jit.DeliveryDetail _item0 in structs.GetSuccess()){
						
						
						com.vip.vop.vcloud.jit.DeliveryDetailHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBoxItem_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryDetail_resultHelper : TBeanSerializer<getDeliveryDetail_result>
		{
			
			public static getDeliveryDetail_resultHelper OBJ = new getDeliveryDetail_resultHelper();
			
			public static getDeliveryDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.GetDeliveryDetailResponse value;
					
					value = new com.vip.vop.vcloud.jit.GetDeliveryDetailResponse();
					com.vip.vop.vcloud.jit.GetDeliveryDetailResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vcloud.jit.GetDeliveryDetailResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryGoods_resultHelper : TBeanSerializer<getDeliveryGoods_result>
		{
			
			public static getDeliveryGoods_resultHelper OBJ = new getDeliveryGoods_resultHelper();
			
			public static getDeliveryGoods_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryGoods_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.GetDeliveryGoodsResponse value;
					
					value = new com.vip.vop.vcloud.jit.GetDeliveryGoodsResponse();
					com.vip.vop.vcloud.jit.GetDeliveryGoodsResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryGoods_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vcloud.jit.GetDeliveryGoodsResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryGoods_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryList_resultHelper : TBeanSerializer<getDeliveryList_result>
		{
			
			public static getDeliveryList_resultHelper OBJ = new getDeliveryList_resultHelper();
			
			public static getDeliveryList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.GetDeliveryListResponse value;
					
					value = new com.vip.vop.vcloud.jit.GetDeliveryListResponse();
					com.vip.vop.vcloud.jit.GetDeliveryListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDeliveryList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vcloud.jit.GetDeliveryListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliverySubPick_resultHelper : TBeanSerializer<getDeliverySubPick_result>
		{
			
			public static getDeliverySubPick_resultHelper OBJ = new getDeliverySubPick_resultHelper();
			
			public static getDeliverySubPick_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliverySubPick_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.vcloud.jit.DeliverySubPick> value;
					
					value = new List<com.vip.vop.vcloud.jit.DeliverySubPick>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.vcloud.jit.DeliverySubPick elem0;
							
							elem0 = new com.vip.vop.vcloud.jit.DeliverySubPick();
							com.vip.vop.vcloud.jit.DeliverySubPickHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getDeliverySubPick_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.vcloud.jit.DeliverySubPick _item0 in structs.GetSuccess()){
						
						
						com.vip.vop.vcloud.jit.DeliverySubPickHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliverySubPick_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDeliveryTrace_resultHelper : TBeanSerializer<getDeliveryTrace_result>
		{
			
			public static getDeliveryTrace_resultHelper OBJ = new getDeliveryTrace_resultHelper();
			
			public static getDeliveryTrace_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDeliveryTrace_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.vcloud.jit.DeliveryTrace> value;
					
					value = new List<com.vip.vop.vcloud.jit.DeliveryTrace>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.vcloud.jit.DeliveryTrace elem1;
							
							elem1 = new com.vip.vop.vcloud.jit.DeliveryTrace();
							com.vip.vop.vcloud.jit.DeliveryTraceHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getDeliveryTrace_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.vcloud.jit.DeliveryTrace _item0 in structs.GetSuccess()){
						
						
						com.vip.vop.vcloud.jit.DeliveryTraceHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDeliveryTrace_result bean){
				
				
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
		
		
		
		
		public class importDeliveryDetail_resultHelper : TBeanSerializer<importDeliveryDetail_result>
		{
			
			public static importDeliveryDetail_resultHelper OBJ = new importDeliveryDetail_resultHelper();
			
			public static importDeliveryDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(importDeliveryDetail_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(importDeliveryDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(importDeliveryDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class submitDelivery_resultHelper : TBeanSerializer<submitDelivery_result>
		{
			
			public static submitDelivery_resultHelper OBJ = new submitDelivery_resultHelper();
			
			public static submitDelivery_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(submitDelivery_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.jit.SubmitDeliveryResponse value;
					
					value = new com.vip.vop.vcloud.jit.SubmitDeliveryResponse();
					com.vip.vop.vcloud.jit.SubmitDeliveryResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(submitDelivery_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vcloud.jit.SubmitDeliveryResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(submitDelivery_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class syncDeliveryInfo_resultHelper : TBeanSerializer<syncDeliveryInfo_result>
		{
			
			public static syncDeliveryInfo_resultHelper OBJ = new syncDeliveryInfo_resultHelper();
			
			public static syncDeliveryInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(syncDeliveryInfo_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(syncDeliveryInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(syncDeliveryInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class JitDeliveryInfoServiceClient : OspRestStub , JitDeliveryInfoService  {
			
			
			public JitDeliveryInfoServiceClient():base("com.vip.vop.vcloud.jit.JitDeliveryInfoService","1.0.0") {
				
				
			}
			
			
			
			public string addbox(string storageNo_,int vendorId_) {
				
				send_addbox(storageNo_,vendorId_);
				return recv_addbox(); 
				
			}
			
			
			private void send_addbox(string storageNo_,int vendorId_){
				
				InitInvocation("addbox");
				
				addbox_args args = new addbox_args();
				args.SetStorageNo(storageNo_);
				args.SetVendorId(vendorId_);
				
				SendBase(args, addbox_argsHelper.getInstance());
			}
			
			
			private string recv_addbox(){
				
				addbox_result result = new addbox_result();
				ReceiveBase(result, addbox_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void boxItem(int vendorId_,string poNo_,string storageNo_,string vendorType_,string barcode_,string boxNo_,int? amount_,string productName_,string subPickNo_) {
				
				send_boxItem(vendorId_,poNo_,storageNo_,vendorType_,barcode_,boxNo_,amount_,productName_,subPickNo_);
				recv_boxItem();
				
			}
			
			
			private void send_boxItem(int vendorId_,string poNo_,string storageNo_,string vendorType_,string barcode_,string boxNo_,int? amount_,string productName_,string subPickNo_){
				
				InitInvocation("boxItem");
				
				boxItem_args args = new boxItem_args();
				args.SetVendorId(vendorId_);
				args.SetPoNo(poNo_);
				args.SetStorageNo(storageNo_);
				args.SetVendorType(vendorType_);
				args.SetBarcode(barcode_);
				args.SetBoxNo(boxNo_);
				args.SetAmount(amount_);
				args.SetProductName(productName_);
				args.SetSubPickNo(subPickNo_);
				
				SendBase(args, boxItem_argsHelper.getInstance());
			}
			
			
			private void recv_boxItem(){
				
				boxItem_result result = new boxItem_result();
				ReceiveBase(result, boxItem_resultHelper.getInstance());
				
				
			}
			
			
			public void confirmDelivery(com.vip.vop.vcloud.jit.ConfirmDeliveryRequest request_) {
				
				send_confirmDelivery(request_);
				recv_confirmDelivery();
				
			}
			
			
			private void send_confirmDelivery(com.vip.vop.vcloud.jit.ConfirmDeliveryRequest request_){
				
				InitInvocation("confirmDelivery");
				
				confirmDelivery_args args = new confirmDelivery_args();
				args.SetRequest(request_);
				
				SendBase(args, confirmDelivery_argsHelper.getInstance());
			}
			
			
			private void recv_confirmDelivery(){
				
				confirmDelivery_result result = new confirmDelivery_result();
				ReceiveBase(result, confirmDelivery_resultHelper.getInstance());
				
				
			}
			
			
			public com.vip.vop.vcloud.jit.CreateDeliveryResponse createDelivery(com.vip.vop.vcloud.jit.CreateDeliveryRequest request_) {
				
				send_createDelivery(request_);
				return recv_createDelivery(); 
				
			}
			
			
			private void send_createDelivery(com.vip.vop.vcloud.jit.CreateDeliveryRequest request_){
				
				InitInvocation("createDelivery");
				
				createDelivery_args args = new createDelivery_args();
				args.SetRequest(request_);
				
				SendBase(args, createDelivery_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vcloud.jit.CreateDeliveryResponse recv_createDelivery(){
				
				createDelivery_result result = new createDelivery_result();
				ReceiveBase(result, createDelivery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void deleteBoxedItem(string boxNo_,string barcode_,string storageNo_,int vendorId_) {
				
				send_deleteBoxedItem(boxNo_,barcode_,storageNo_,vendorId_);
				recv_deleteBoxedItem();
				
			}
			
			
			private void send_deleteBoxedItem(string boxNo_,string barcode_,string storageNo_,int vendorId_){
				
				InitInvocation("deleteBoxedItem");
				
				deleteBoxedItem_args args = new deleteBoxedItem_args();
				args.SetBoxNo(boxNo_);
				args.SetBarcode(barcode_);
				args.SetStorageNo(storageNo_);
				args.SetVendorId(vendorId_);
				
				SendBase(args, deleteBoxedItem_argsHelper.getInstance());
			}
			
			
			private void recv_deleteBoxedItem(){
				
				deleteBoxedItem_result result = new deleteBoxedItem_result();
				ReceiveBase(result, deleteBoxedItem_resultHelper.getInstance());
				
				
			}
			
			
			public List<com.vip.vop.vcloud.jit.DeletedDeliveryDetail> deleteDeliveryDetail(com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequest request_) {
				
				send_deleteDeliveryDetail(request_);
				return recv_deleteDeliveryDetail(); 
				
			}
			
			
			private void send_deleteDeliveryDetail(com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequest request_){
				
				InitInvocation("deleteDeliveryDetail");
				
				deleteDeliveryDetail_args args = new deleteDeliveryDetail_args();
				args.SetRequest(request_);
				
				SendBase(args, deleteDeliveryDetail_argsHelper.getInstance());
			}
			
			
			private List<com.vip.vop.vcloud.jit.DeletedDeliveryDetail> recv_deleteDeliveryDetail(){
				
				deleteDeliveryDetail_result result = new deleteDeliveryDetail_result();
				ReceiveBase(result, deleteDeliveryDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void editDelivery(com.vip.vop.vcloud.jit.EditDeliveryRequest request_) {
				
				send_editDelivery(request_);
				recv_editDelivery();
				
			}
			
			
			private void send_editDelivery(com.vip.vop.vcloud.jit.EditDeliveryRequest request_){
				
				InitInvocation("editDelivery");
				
				editDelivery_args args = new editDelivery_args();
				args.SetRequest(request_);
				
				SendBase(args, editDelivery_argsHelper.getInstance());
			}
			
			
			private void recv_editDelivery(){
				
				editDelivery_result result = new editDelivery_result();
				ReceiveBase(result, editDelivery_resultHelper.getInstance());
				
				
			}
			
			
			public List<com.vip.vop.vcloud.jit.DeliveryBox> getBox(string storageNo_,int vendorId_) {
				
				send_getBox(storageNo_,vendorId_);
				return recv_getBox(); 
				
			}
			
			
			private void send_getBox(string storageNo_,int vendorId_){
				
				InitInvocation("getBox");
				
				getBox_args args = new getBox_args();
				args.SetStorageNo(storageNo_);
				args.SetVendorId(vendorId_);
				
				SendBase(args, getBox_argsHelper.getInstance());
			}
			
			
			private List<com.vip.vop.vcloud.jit.DeliveryBox> recv_getBox(){
				
				getBox_result result = new getBox_result();
				ReceiveBase(result, getBox_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.vop.vcloud.jit.DeliveryDetail> getBoxItem(long? deliveryId_,string boxNo_) {
				
				send_getBoxItem(deliveryId_,boxNo_);
				return recv_getBoxItem(); 
				
			}
			
			
			private void send_getBoxItem(long? deliveryId_,string boxNo_){
				
				InitInvocation("getBoxItem");
				
				getBoxItem_args args = new getBoxItem_args();
				args.SetDeliveryId(deliveryId_);
				args.SetBoxNo(boxNo_);
				
				SendBase(args, getBoxItem_argsHelper.getInstance());
			}
			
			
			private List<com.vip.vop.vcloud.jit.DeliveryDetail> recv_getBoxItem(){
				
				getBoxItem_result result = new getBoxItem_result();
				ReceiveBase(result, getBoxItem_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.vop.vcloud.jit.GetDeliveryDetailResponse getDeliveryDetail(com.vip.vop.vcloud.jit.GetDeliveryDetailRequest request_) {
				
				send_getDeliveryDetail(request_);
				return recv_getDeliveryDetail(); 
				
			}
			
			
			private void send_getDeliveryDetail(com.vip.vop.vcloud.jit.GetDeliveryDetailRequest request_){
				
				InitInvocation("getDeliveryDetail");
				
				getDeliveryDetail_args args = new getDeliveryDetail_args();
				args.SetRequest(request_);
				
				SendBase(args, getDeliveryDetail_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vcloud.jit.GetDeliveryDetailResponse recv_getDeliveryDetail(){
				
				getDeliveryDetail_result result = new getDeliveryDetail_result();
				ReceiveBase(result, getDeliveryDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.vop.vcloud.jit.GetDeliveryGoodsResponse getDeliveryGoods(com.vip.vop.vcloud.jit.GetDeliveryGoodsRequest request_) {
				
				send_getDeliveryGoods(request_);
				return recv_getDeliveryGoods(); 
				
			}
			
			
			private void send_getDeliveryGoods(com.vip.vop.vcloud.jit.GetDeliveryGoodsRequest request_){
				
				InitInvocation("getDeliveryGoods");
				
				getDeliveryGoods_args args = new getDeliveryGoods_args();
				args.SetRequest(request_);
				
				SendBase(args, getDeliveryGoods_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vcloud.jit.GetDeliveryGoodsResponse recv_getDeliveryGoods(){
				
				getDeliveryGoods_result result = new getDeliveryGoods_result();
				ReceiveBase(result, getDeliveryGoods_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.vop.vcloud.jit.GetDeliveryListResponse getDeliveryList(com.vip.vop.vcloud.jit.GetDeliveryListRequest request_) {
				
				send_getDeliveryList(request_);
				return recv_getDeliveryList(); 
				
			}
			
			
			private void send_getDeliveryList(com.vip.vop.vcloud.jit.GetDeliveryListRequest request_){
				
				InitInvocation("getDeliveryList");
				
				getDeliveryList_args args = new getDeliveryList_args();
				args.SetRequest(request_);
				
				SendBase(args, getDeliveryList_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vcloud.jit.GetDeliveryListResponse recv_getDeliveryList(){
				
				getDeliveryList_result result = new getDeliveryList_result();
				ReceiveBase(result, getDeliveryList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.vop.vcloud.jit.DeliverySubPick> getDeliverySubPick(string storageNo_,int vendorId_) {
				
				send_getDeliverySubPick(storageNo_,vendorId_);
				return recv_getDeliverySubPick(); 
				
			}
			
			
			private void send_getDeliverySubPick(string storageNo_,int vendorId_){
				
				InitInvocation("getDeliverySubPick");
				
				getDeliverySubPick_args args = new getDeliverySubPick_args();
				args.SetStorageNo(storageNo_);
				args.SetVendorId(vendorId_);
				
				SendBase(args, getDeliverySubPick_argsHelper.getInstance());
			}
			
			
			private List<com.vip.vop.vcloud.jit.DeliverySubPick> recv_getDeliverySubPick(){
				
				getDeliverySubPick_result result = new getDeliverySubPick_result();
				ReceiveBase(result, getDeliverySubPick_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.vop.vcloud.jit.DeliveryTrace> getDeliveryTrace(com.vip.vop.vcloud.jit.GetDeliveryTraceRequest request_) {
				
				send_getDeliveryTrace(request_);
				return recv_getDeliveryTrace(); 
				
			}
			
			
			private void send_getDeliveryTrace(com.vip.vop.vcloud.jit.GetDeliveryTraceRequest request_){
				
				InitInvocation("getDeliveryTrace");
				
				getDeliveryTrace_args args = new getDeliveryTrace_args();
				args.SetRequest(request_);
				
				SendBase(args, getDeliveryTrace_argsHelper.getInstance());
			}
			
			
			private List<com.vip.vop.vcloud.jit.DeliveryTrace> recv_getDeliveryTrace(){
				
				getDeliveryTrace_result result = new getDeliveryTrace_result();
				ReceiveBase(result, getDeliveryTrace_resultHelper.getInstance());
				
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
			
			
			public void importDeliveryDetail(com.vip.vop.vcloud.jit.ImportDeliveryDetailRequest request_) {
				
				send_importDeliveryDetail(request_);
				recv_importDeliveryDetail();
				
			}
			
			
			private void send_importDeliveryDetail(com.vip.vop.vcloud.jit.ImportDeliveryDetailRequest request_){
				
				InitInvocation("importDeliveryDetail");
				
				importDeliveryDetail_args args = new importDeliveryDetail_args();
				args.SetRequest(request_);
				
				SendBase(args, importDeliveryDetail_argsHelper.getInstance());
			}
			
			
			private void recv_importDeliveryDetail(){
				
				importDeliveryDetail_result result = new importDeliveryDetail_result();
				ReceiveBase(result, importDeliveryDetail_resultHelper.getInstance());
				
				
			}
			
			
			public com.vip.vop.vcloud.jit.SubmitDeliveryResponse submitDelivery(int vendorId_,string storageNo_) {
				
				send_submitDelivery(vendorId_,storageNo_);
				return recv_submitDelivery(); 
				
			}
			
			
			private void send_submitDelivery(int vendorId_,string storageNo_){
				
				InitInvocation("submitDelivery");
				
				submitDelivery_args args = new submitDelivery_args();
				args.SetVendorId(vendorId_);
				args.SetStorageNo(storageNo_);
				
				SendBase(args, submitDelivery_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vcloud.jit.SubmitDeliveryResponse recv_submitDelivery(){
				
				submitDelivery_result result = new submitDelivery_result();
				ReceiveBase(result, submitDelivery_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void syncDeliveryInfo() {
				
				send_syncDeliveryInfo();
				recv_syncDeliveryInfo();
				
			}
			
			
			private void send_syncDeliveryInfo(){
				
				InitInvocation("syncDeliveryInfo");
				
				syncDeliveryInfo_args args = new syncDeliveryInfo_args();
				
				SendBase(args, syncDeliveryInfo_argsHelper.getInstance());
			}
			
			
			private void recv_syncDeliveryInfo(){
				
				syncDeliveryInfo_result result = new syncDeliveryInfo_result();
				ReceiveBase(result, syncDeliveryInfo_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}