using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class FavVOHelper : TBeanSerializer<FavVO>
	{
		
		public static FavVOHelper OBJ = new FavVOHelper();
		
		public static FavVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FavVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("activeType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetActiveType(value);
					}
					
					
					
					
					
					if ("activeField".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetActiveField(value);
					}
					
					
					
					
					
					if ("favDetailList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.FavDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.FavDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.FavDetailVO elem2;
								
								elem2 = new com.vip.order.common.pojo.order.vo.FavDetailVO();
								com.vip.order.common.pojo.order.vo.FavDetailVOHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFavDetailList(value);
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
		
		
		public void Write(FavVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetActiveType() != null) {
				
				oprot.WriteFieldBegin("activeType");
				oprot.WriteI32((int)structs.GetActiveType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveField() != null) {
				
				oprot.WriteFieldBegin("activeField");
				oprot.WriteI32((int)structs.GetActiveField()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFavDetailList() != null) {
				
				oprot.WriteFieldBegin("favDetailList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.FavDetailVO _item0 in structs.GetFavDetailList()){
					
					
					com.vip.order.common.pojo.order.vo.FavDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(FavVO bean){
			
			
		}
		
	}
	
}