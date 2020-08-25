using System;
using System.Collections.Generic;

namespace vipapis.vlg.wms{
	
	
	public interface OutTpsService {
		
		
		com.vip.sce.vlg.osp.wms.service.PostResponse callbackOutShipContainerResult( string sysKey_,   string warehouse_,   List<string> msgIds_ );
		
		com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponse getOutReturnOrderPackageResult( string appName_,   long maxId_,   int maxSize_ );
		
		com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponse getOutShipContainerResult( string sysKey_,   string warehouse_,   int pageSize_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.sce.vlg.osp.wms.service.PostResponse pushOutReturnOrderPackage( com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackage outReturnOrderPackage_ );
		
		com.vip.sce.vlg.osp.wms.service.PostResponse pushOutShipContainer( string sysKey_,   string warehouse_,   List<com.vip.sce.vlg.osp.wms.service.OutShipContainer> outShipContainers_ );
		
	}
	
}