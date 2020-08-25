using System;
using System.Collections.Generic;

namespace vipapis.vsizetable{
	
	
	public interface VendorSizeTableService {
		
		
		vipapis.vsizetable.SizeDetail addSizeDetail( int vendor_id_,   vipapis.vsizetable.SizeDetailRequest sizedetail_ );
		
		vipapis.vsizetable.SizeTableInfo addSizeTableInfo( int vendor_id_,   vipapis.vsizetable.SizeTableInfoRequest sizetable_ );
		
		vipapis.vsizetable.AddSizeTableTemplateResponse addSizeTableTemplate( vipapis.vsizetable.AddSizeTableTemplateRequest request_ );
		
		List<long?> deleteSizeDetailByIds( int vendor_id_,   List<long?> sizedetail_ids_ );
		
		long? deleteSizeTable( int vendor_id_,   long sizetable_id_ );
		
		int? deleteSizeTableTemplate( int vendor_id_,   int template_id_ );
		
		vipapis.vsizetable.GetDimensionInfoResponse getDimensionInfos( List<int?> template_types_ );
		
		List<vipapis.vsizetable.SizeDetail> getSizeDetailList( int vendor_id_,   long sizetable_id_ );
		
		List<vipapis.vsizetable.SizeDetail> getSizeDetailListByIds( int vendor_id_,   List<long?> sizedetail_ids_ );
		
		vipapis.vsizetable.SizeTableInfo getSizeTableInfo( int vendor_id_,   long sizetable_id_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.vsizetable.QuerySizeTableTemplateResponse querySizeTableTemplate( int vendor_id_,   int? page_,   int? limit_,   int? sizetable_template_id_,   string sizetable_template_name_ );
		
		long? updateSizeDetail( int vendor_id_,   vipapis.vsizetable.SizeDetailRequest sizedetail_ );
		
		long? updateSizeTableInfo( int vendor_id_,   vipapis.vsizetable.SizeTableInfoRequest sizetable_ );
		
	}
	
}