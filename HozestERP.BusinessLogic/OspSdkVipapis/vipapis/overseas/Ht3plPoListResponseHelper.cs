using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class Ht3plPoListResponseHelper : TBeanSerializer<Ht3plPoListResponse>
	{
		
		public static Ht3plPoListResponseHelper OBJ = new Ht3plPoListResponseHelper();
		
		public static Ht3plPoListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Ht3plPoListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("po_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.PoInfo> value;
						
						value = new List<vipapis.overseas.PoInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.PoInfo elem1;
								
								elem1 = new vipapis.overseas.PoInfo();
								vipapis.overseas.PoInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPo_list(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(Ht3plPoListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPo_list() != null) {
				
				oprot.WriteFieldBegin("po_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.PoInfo _item0 in structs.GetPo_list()){
					
					
					vipapis.overseas.PoInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Ht3plPoListResponse bean){
			
			
		}
		
	}
	
}