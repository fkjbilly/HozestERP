using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vsizetable{
	
	
	
	public class GetDimensionInfoResponseHelper : TBeanSerializer<GetDimensionInfoResponse>
	{
		
		public static GetDimensionInfoResponseHelper OBJ = new GetDimensionInfoResponseHelper();
		
		public static GetDimensionInfoResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetDimensionInfoResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("dimension_infos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.vsizetable.DimensionInfo> value;
						
						value = new List<vipapis.vsizetable.DimensionInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.vsizetable.DimensionInfo elem1;
								
								elem1 = new vipapis.vsizetable.DimensionInfo();
								vipapis.vsizetable.DimensionInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDimension_infos(value);
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
		
		
		public void Write(GetDimensionInfoResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDimension_infos() != null) {
				
				oprot.WriteFieldBegin("dimension_infos");
				
				oprot.WriteListBegin();
				foreach(vipapis.vsizetable.DimensionInfo _item0 in structs.GetDimension_infos()){
					
					
					vipapis.vsizetable.DimensionInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetDimensionInfoResponse bean){
			
			
		}
		
	}
	
}