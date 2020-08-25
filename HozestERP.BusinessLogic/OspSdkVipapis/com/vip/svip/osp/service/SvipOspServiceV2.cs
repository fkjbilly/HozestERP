using System;
using System.Collections.Generic;

namespace com.vip.svip.osp.service{
	
	
	public interface SvipOspServiceV2 {
		
		
		com.vip.svip.osp.service.BaseResult bindTxUserAccount( com.vip.svip.osp.service.BindTxAccRequest request_ );
		
		List<com.vip.svip.osp.service.BrandGiftItem> brandGiftDetailList( com.vip.svip.osp.service.BrandGiftDetailRequest request_ );
		
		com.vip.svip.osp.service.BaseResult checkTxAccLimit( com.vip.svip.osp.service.CheckTxAccLimitRequest request_ );
		
		com.vip.svip.osp.service.AccountInfoResult getBindAccountInfo( com.vip.svip.osp.service.GetBindAccountRequest request_ );
		
		com.vip.svip.osp.service.BrandGiftIdResult getBrandGiftIdList( com.vip.svip.osp.service.BrandGiftRequest request_ );
		
		com.vip.svip.osp.service.BuyLimitResult getBuyLimitResult( com.vip.svip.osp.service.BuyLimitRequestHeader header_,   com.vip.svip.osp.service.BuyLimitRequestParam param_ );
		
		com.vip.svip.osp.service.KTBaseInfoResult getSvipMainInfo( com.vip.svip.osp.service.BaseRequestHeader header_ );
		
		com.vip.svip.osp.service.TencentSvipGoodsInfo getTencentVipSvipCardInfo( long? userId_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.svip.osp.service.BuyLimitResult isSvipBuyLimit( com.vip.svip.osp.service.BuyLimitRequestHeader header_,   com.vip.svip.osp.service.BuyLimitRequestParam param_ );
		
		com.vip.svip.osp.service.BuyLimitState isSvipLimitUser( com.vip.svip.osp.service.BuyLimitStateRequest request_ );
		
		com.vip.svip.osp.service.DoubleSvipCreateResponse joinSvipForTencentVideoSide( com.vip.svip.osp.service.DoubleSvipRequest request_ );
		
		com.vip.svip.osp.service.BaseResult joinTencentVideoMemberAtVipSide( com.vip.svip.osp.service.DoubleSvipRequest request_ );
		
		com.vip.svip.osp.service.BuyLimitResult openLimitCheck( com.vip.svip.osp.service.OpenLimitRequest request_ );
		
		com.vip.svip.osp.service.DoubleSvipStatus prepareDoubleSvipAccess( com.vip.svip.osp.service.DoubleSvipRequest request_ );
		
		com.vip.svip.osp.service.BaseResult rejoinTencentMember( string serial_,   string admin_ );
		
		com.vip.svip.osp.service.BaseResult specialMemberTrySvip( com.vip.svip.osp.service.SimpleRequestHeader header_ );
		
		com.vip.svip.osp.service.TxGetSvipTokenResult txGetSvipToken( com.vip.svip.osp.service.TxGetTokenRequest request_ );
		
		com.vip.svip.osp.service.DoubleSvipCreateResponse txOpenSvip( com.vip.svip.osp.service.TxOpenSvipRequest request_ );
		
	}
	
}