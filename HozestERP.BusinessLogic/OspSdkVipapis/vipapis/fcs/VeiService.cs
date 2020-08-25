using System;
using System.Collections.Generic;

namespace vipapis.fcs{
	
	
	public interface VeiService {
		
		
		com.vip.fcs.vei.service.BaseRetMsg acceptExternalInvoiceData( com.vip.fcs.vei.service.EinvoiceVo einvoiceVo_ );
		
		com.vip.fcs.vei.service.CanInvoicingResModel canInvoicing( com.vip.fcs.vei.service.CanInvoicingReqModel canInvoicingReqModel_ );
		
		com.vip.fcs.vei.service.CanInvoicingResModel2 canInvoicing2( com.vip.fcs.vei.service.CanInvoicingReqModel canInvoicingReqModel_ );
		
		com.vip.fcs.vei.service.CanInvoicingResModel3 canInvoicing3( com.vip.fcs.vei.service.CanInvoicingReqModel3 canInvoicingReqModel_ );
		
		com.vip.fcs.vei.service.CanInvoicingResModel4 canInvoicing4( com.vip.fcs.vei.service.CanInvoicingReqModel4 canInvoicingReqModel_ );
		
		com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel downloadElectronicInvoice( com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel reqModel_ );
		
		com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel downloadElectronicInvoice2( com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 reqModel_ );
		
		com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModel downloadElectronicInvoicePicture( com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModel reqModel_ );
		
		com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel downloadMedicineElectronicInvoice( com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 reqModel_ );
		
		com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel downloadRedElectronicInvoice( com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel reqModel_ );
		
		com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModel getExternalInvoiceHandleState( com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModel reqModel_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.fcs.vei.service.InvoiceOrderDataResModel invoiceOrderData( com.vip.fcs.vei.service.InvoiceOrderDataReqModel reqModel_ );
		
		com.vip.fcs.vei.service.VCanInvoicingResModel vCanInvoicing( com.vip.fcs.vei.service.VCanInvoicingReqModel reqModel_ );
		
	}
	
}