using System;
using System.Collections.Generic;

namespace vipapis.size{
	
	
	public interface VendorSizeMappingService {
		
		
		int? addSizeCategories( List<vipapis.size.SizeCategoryDo> size_category_does_ );
		
		string addSizeTable( vipapis.size.AddSizeTableRequest req_ );
		
		long? addSizeTemplate( string size_template_code_,   string size_template_name_ );
		
		List<vipapis.size.SizeDetailDo> findAllSizeDetail();
		
		List<vipapis.size.SizeCategoryDo> findBindedCategory( string category_id_ );
		
		List<vipapis.size.SizeCategoryDo> findCategoryByTemplateId( long? size_template_id_ );
		
		vipapis.size.FindSizeMappingResponse findSizeMapping( vipapis.size.FindSizeMappingRequest req_ );
		
		List<vipapis.size.SizeTemplateDo> findSizeTemplateDetail( vipapis.size.SizeTemplateDo size_template_do_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		vipapis.size.ListVendorSizeTableResponse listVendorSizeTable( vipapis.size.ListVendorSizeTableRequest request_ );
		
		List<vipapis.size.VendorSizeMappingDo> selectByCondition( vipapis.size.VendorSizeMappingDo condition_ );
		
		int? unBindingCategory( string category_id_ );
		
		string updateSizeTable( vipapis.size.UpdateSizeTableRequest req_ );
		
		int? updateSizeTemplate( vipapis.size.SizeTemplateDo size_template_do_ );
		
		int? updateSizeTemplateDetail( long size_template_id_,   List<long?> size_detail_id_ );
		
	}
	
}