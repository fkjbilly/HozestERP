using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.size{
	
	
	
	public class FindSizeMappingResponseHelper : TBeanSerializer<FindSizeMappingResponse>
	{
		
		public static FindSizeMappingResponseHelper OBJ = new FindSizeMappingResponseHelper();
		
		public static FindSizeMappingResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FindSizeMappingResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("size_mappings".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.size.SizeMapping> value;
						
						value = new List<vipapis.size.SizeMapping>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.size.SizeMapping elem1;
								
								elem1 = new vipapis.size.SizeMapping();
								vipapis.size.SizeMappingHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSize_mappings(value);
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
		
		
		public void Write(FindSizeMappingResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSize_mappings() != null) {
				
				oprot.WriteFieldBegin("size_mappings");
				
				oprot.WriteListBegin();
				foreach(vipapis.size.SizeMapping _item0 in structs.GetSize_mappings()){
					
					
					vipapis.size.SizeMappingHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(FindSizeMappingResponse bean){
			
			
		}
		
	}
	
}