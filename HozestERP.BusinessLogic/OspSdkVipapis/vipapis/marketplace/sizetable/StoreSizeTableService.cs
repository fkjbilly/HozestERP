using System;
using System.Collections.Generic;

namespace vipapis.marketplace.sizetable{
	
	
	public interface StoreSizeTableService {
		
		
		vipapis.marketplace.sizetable.AddSizeDetailResponse addSizeDetail( vipapis.marketplace.sizetable.AddSizeDetailRequest request_ );
		
		vipapis.marketplace.sizetable.AddSizeTableResponse addSizeTable( vipapis.marketplace.sizetable.AddSizeTableRequest request_ );
		
		vipapis.marketplace.sizetable.AddSizeTableTemplateResponse addSizeTableTemplate( vipapis.marketplace.sizetable.AddSizeTableTemplateRequest request_ );
		
		List<vipapis.marketplace.sizetable.SizeDetail> batchGetSizeDetails( List<long?> size_detail_ids_ );
		
		void deleteSizeTableTemplate( int size_table_template_id_ );
		
		vipapis.marketplace.sizetable.SizeTable getSizeTable( long size_table_id_ );
		
		vipapis.marketplace.sizetable.GetSizeTableTemplateResponse getSizeTableTemplate( vipapis.marketplace.sizetable.GetSizeTableTemplateRequest request_ );
		
		vipapis.marketplace.sizetable.GetTemplateTypeResponse getTemplateTypes( List<int?> template_types_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		void updateSizeDetail( vipapis.marketplace.sizetable.UpdateSizeDetailRequest request_ );
		
		void updateSizeTable( vipapis.marketplace.sizetable.UpdateSizeTableRequest request_ );
		
	}
	
}