using System;
using System.Collections.Generic;

namespace com.vip.arplatform.face.service{
	
	
	public interface FaceService {
		
		
		com.vip.arplatform.face.service.CartoonModel faceCartoon( string imageInPath_,   string faceUrl_,   string facelessUrl_,   int? cr_,   int? cb_,   string point_ );
		
		com.vip.arplatform.face.service.FacesetCompareResult faceSimilarity( string image_url1_,   string image_url2_ );
		
		com.vip.arplatform.face.service.FacesetCreateModel facesetCreate( string faceset_key_,   string image_urls_ );
		
		List<string> facesetDelete( string faceset_key_,   string image_urls_ );
		
		com.vip.arplatform.face.service.FacesetCreateModel facesetStatus( string faceset_key_ );
		
		com.vip.arplatform.face.service.FacesetCreateModel facesetUpdate( string faceset_key_,   string image_urls_ );
		
		com.vip.arplatform.face.service.CrCbModel getCrCb( string facelessUrl_,   string point_ );
		
		List<string> getFacesetUrl( string faceset_key_ );
		
		com.vip.arplatform.face.service.CompareResponse getSearchResult( string token_ );
		
		com.vip.arplatform.face.service.SearchWithFeaturesResultModel getSearchWithFeaturesResult( com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModel getSearchWithFeaturesParamResultModel_ );
		
		com.vip.hermes.core.health.CheckResult healthCheck();
		
		com.vip.arplatform.face.service.ImageStylizationModel imageStylize( string imageInPath_,   string type_ );
		
		com.vip.arplatform.face.service.CompareResponse search( string faceset_key_,   string image_url_,   int results_count_,   int asynchronization_ );
		
		com.vip.arplatform.face.service.SearchWithFeaturesResultModel searchWithFeatures( com.vip.arplatform.face.service.SearchWithFeaturesParamModel searchWithFeaturesParamModel_ );
		
		com.vip.arplatform.face.service.ShapeSimilarityModel shapeSimilarity( string img_src_,   string img_target_ );
		
	}
	
}