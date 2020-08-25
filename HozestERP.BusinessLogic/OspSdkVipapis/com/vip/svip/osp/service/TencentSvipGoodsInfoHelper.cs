using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class TencentSvipGoodsInfoHelper : TBeanSerializer<TencentSvipGoodsInfo>
	{
		
		public static TencentSvipGoodsInfoHelper OBJ = new TencentSvipGoodsInfoHelper();
		
		public static TencentSvipGoodsInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(TencentSvipGoodsInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("tencentCard".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.svip.osp.service.SvipGoodsInfo> value;
						
						value = new List<com.vip.svip.osp.service.SvipGoodsInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.svip.osp.service.SvipGoodsInfo elem0;
								
								elem0 = new com.vip.svip.osp.service.SvipGoodsInfo();
								com.vip.svip.osp.service.SvipGoodsInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTencentCard(value);
					}
					
					
					
					
					
					if ("svipCard".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.svip.osp.service.SvipGoodsInfo> value;
						
						value = new List<com.vip.svip.osp.service.SvipGoodsInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.svip.osp.service.SvipGoodsInfo elem2;
								
								elem2 = new com.vip.svip.osp.service.SvipGoodsInfo();
								com.vip.svip.osp.service.SvipGoodsInfoHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSvipCard(value);
					}
					
					
					
					
					
					if ("limitStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetLimitStatus(value);
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
		
		
		public void Write(TencentSvipGoodsInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTencentCard() != null) {
				
				oprot.WriteFieldBegin("tencentCard");
				
				oprot.WriteListBegin();
				foreach(com.vip.svip.osp.service.SvipGoodsInfo _item0 in structs.GetTencentCard()){
					
					
					com.vip.svip.osp.service.SvipGoodsInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSvipCard() != null) {
				
				oprot.WriteFieldBegin("svipCard");
				
				oprot.WriteListBegin();
				foreach(com.vip.svip.osp.service.SvipGoodsInfo _item0 in structs.GetSvipCard()){
					
					
					com.vip.svip.osp.service.SvipGoodsInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLimitStatus() != null) {
				
				oprot.WriteFieldBegin("limitStatus");
				oprot.WriteI32((int)structs.GetLimitStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("limitStatus can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(TencentSvipGoodsInfo bean){
			
			
		}
		
	}
	
}