using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetEbsGoodsListRespHelper : TBeanSerializer<GetEbsGoodsListResp>
	{
		
		public static GetEbsGoodsListRespHelper OBJ = new GetEbsGoodsListRespHelper();
		
		public static GetEbsGoodsListRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetEbsGoodsListResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.result.Result value;
						
						value = new com.vip.order.common.pojo.order.result.Result();
						com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Read(value, iprot);
						
						structs.SetResult(value);
					}
					
					
					
					
					
					if ("ebsGoodList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.EbsGoodsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.EbsGoodsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.EbsGoodsVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.EbsGoodsVO();
								com.vip.order.common.pojo.order.vo.EbsGoodsVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetEbsGoodList(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(GetEbsGoodsListResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEbsGoodList() != null) {
				
				oprot.WriteFieldBegin("ebsGoodList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.EbsGoodsVO _item0 in structs.GetEbsGoodList()){
					
					
					com.vip.order.common.pojo.order.vo.EbsGoodsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetEbsGoodsListResp bean){
			
			
		}
		
	}
	
}