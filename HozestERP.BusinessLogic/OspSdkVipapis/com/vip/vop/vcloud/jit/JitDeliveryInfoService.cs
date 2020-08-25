using System;
using System.Collections.Generic;

namespace com.vip.vop.vcloud.jit{
	
	
	public interface JitDeliveryInfoService {
		
		
		string addbox( string storageNo_,   int vendorId_ );
		
		void boxItem( int vendorId_,   string poNo_,   string storageNo_,   string vendorType_,   string barcode_,   string boxNo_,   int? amount_,   string productName_,   string subPickNo_ );
		
		void confirmDelivery( com.vip.vop.vcloud.jit.ConfirmDeliveryRequest request_ );
		
		com.vip.vop.vcloud.jit.CreateDeliveryResponse createDelivery( com.vip.vop.vcloud.jit.CreateDeliveryRequest request_ );
		
		void deleteBoxedItem( string boxNo_,   string barcode_,   string storageNo_,   int vendorId_ );
		
		List<com.vip.vop.vcloud.jit.DeletedDeliveryDetail> deleteDeliveryDetail( com.vip.vop.vcloud.jit.DeleteDeliveryDetailRequest request_ );
		
		void editDelivery( com.vip.vop.vcloud.jit.EditDeliveryRequest request_ );
		
		List<com.vip.vop.vcloud.jit.DeliveryBox> getBox( string storageNo_,   int vendorId_ );
		
		List<com.vip.vop.vcloud.jit.DeliveryDetail> getBoxItem( long? deliveryId_,   string boxNo_ );
		
		com.vip.vop.vcloud.jit.GetDeliveryDetailResponse getDeliveryDetail( com.vip.vop.vcloud.jit.GetDeliveryDetailRequest request_ );
		
		com.vip.vop.vcloud.jit.GetDeliveryGoodsResponse getDeliveryGoods( com.vip.vop.vcloud.jit.GetDeliveryGoodsRequest request_ );
		
		com.vip.vop.vcloud.jit.GetDeliveryListResponse getDeliveryList( com.vip.vop.vcloud.jit.GetDeliveryListRequest request_ );
		
		List<com.vip.vop.vcloud.jit.DeliverySubPick> getDeliverySubPick( string storageNo_,   int vendorId_ );
		
		List<com.vip.vop.vcloud.jit.DeliveryTrace> getDeliveryTrace( com.vip.vop.vcloud.jit.GetDeliveryTraceRequest request_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void importDeliveryDetail( com.vip.vop.vcloud.jit.ImportDeliveryDetailRequest request_ );
		
		com.vip.vop.vcloud.jit.SubmitDeliveryResponse submitDelivery( int vendorId_,   string storageNo_ );
		
		void syncDeliveryInfo();
		
	}
	
}